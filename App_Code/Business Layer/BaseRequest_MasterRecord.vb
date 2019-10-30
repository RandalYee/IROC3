' This class is "generated" and will be overwritten.
' Your customizations should be made in Request_MasterRecord.vb

Imports System.Data.SqlTypes
Imports BaseClasses
Imports BaseClasses.Data
Imports BaseClasses.Data.SqlProvider

Namespace IROC2.Business

''' <summary>
''' The generated superclass for the <see cref="Request_MasterRecord"></see> class.
''' </summary>
''' <remarks>
''' This class is not intended to be instantiated directly.  To obtain an instance of this class, 
''' use the methods of the <see cref="Request_MasterTable"></see> class.
''' </remarks>
''' <seealso cref="Request_MasterTable"></seealso>
''' <seealso cref="Request_MasterRecord"></seealso>

<Serializable()> Public Class BaseRequest_MasterRecord
	Inherits PrimaryKeyRecord
	

	Public Shared Shadows ReadOnly TableUtils As Request_MasterTable = Request_MasterTable.Instance

	' Constructors
 
	Protected Sub New()
		MyBase.New(TableUtils)
	End Sub

	Protected Sub New(ByVal record As PrimaryKeyRecord)
		MyBase.New(record, TableUtils)
	End Sub
	
	'Evaluates Initialize when->Inserting record formulas specified at the data access layer
    Public Overridable Sub Request_MasterRecord_InsertingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.InsertingRecord
        'Apply Initialize->Inserting record formula only if validation is successful.
        	        Dim Request_MasterRec As Request_MasterRecord = CType(sender,Request_MasterRecord)
        Validate_Inserting()
        If Not Request_MasterRec Is Nothing AndAlso Not Request_MasterRec.IsReadOnly Then
                End If
    End Sub

	'Evaluates Initialize when->Updating record formulas specified at the data access layer
    Public Overridable Sub Request_MasterRecord_UpdatingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.UpdatingRecord
        'Apply Initialize->Updating record formula only if validation is successful.
        	        Dim Request_MasterRec As Request_MasterRecord = CType(sender,Request_MasterRecord)
        Validate_Updating()
        If Not Request_MasterRec Is Nothing AndAlso Not Request_MasterRec.IsReadOnly Then
                End If
    End Sub
    
    'Evaluates Initialize when->Reading record formulas specified at the data access layer
    Public Overridable Sub Request_MasterRecord_ReadRecord(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReadRecord
        'Apply Initialize->Reading record formula only if validation is successful.
        	        Dim Request_MasterRec As Request_MasterRecord = CType(sender,Request_MasterRecord)
        If Not Request_MasterRec Is Nothing AndAlso Not Request_MasterRec.IsReadOnly Then
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
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Request_Id field.
	''' </summary>
	Public Function GetRequest_IdValue() As ColumnValue
		Return Me.GetValue(TableUtils.Request_IdColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Request_Id field.
	''' </summary>
	Public Function GetRequest_IdFieldValue() As Int32
		Return CType(Me.GetValue(TableUtils.Request_IdColumn).ToInt32(), Int32)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.IROC_Id field.
	''' </summary>
	Public Function GetIROC_IdValue() As ColumnValue
		Return Me.GetValue(TableUtils.IROC_IdColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.IROC_Id field.
	''' </summary>
	Public Function GetIROC_IdFieldValue() As String
		Return CType(Me.GetValue(TableUtils.IROC_IdColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.IROC_Id field.
	''' </summary>
	Public Sub SetIROC_IdFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.IROC_IdColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.IROC_Id field.
	''' </summary>
	Public Sub SetIROC_IdFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.IROC_IdColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Priority field.
	''' </summary>
	Public Function GetPriorityValue() As ColumnValue
		Return Me.GetValue(TableUtils.PriorityColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Priority field.
	''' </summary>
	Public Function GetPriorityFieldValue() As Int16
		Return CType(Me.GetValue(TableUtils.PriorityColumn).ToInt16(), Int16)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Priority field.
	''' </summary>
	Public Sub SetPriorityFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.PriorityColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Priority field.
	''' </summary>
	Public Sub SetPriorityFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.PriorityColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Priority field.
	''' </summary>
	Public Sub SetPriorityFieldValue(ByVal val As Double)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.PriorityColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Priority field.
	''' </summary>
	Public Sub SetPriorityFieldValue(ByVal val As Decimal)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.PriorityColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Priority field.
	''' </summary>
	Public Sub SetPriorityFieldValue(ByVal val As Int64)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.PriorityColumn)
	End Sub
	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Site_Name field.
	''' </summary>
	Public Function GetReq_Site_NameValue() As ColumnValue
		Return Me.GetValue(TableUtils.Req_Site_NameColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Site_Name field.
	''' </summary>
	Public Function GetReq_Site_NameFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Req_Site_NameColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Site_Name field.
	''' </summary>
	Public Sub SetReq_Site_NameFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Req_Site_NameColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Site_Name field.
	''' </summary>
	Public Sub SetReq_Site_NameFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Req_Site_NameColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Address field.
	''' </summary>
	Public Function GetReq_AddressValue() As ColumnValue
		Return Me.GetValue(TableUtils.Req_AddressColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Address field.
	''' </summary>
	Public Function GetReq_AddressFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Req_AddressColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Address field.
	''' </summary>
	Public Sub SetReq_AddressFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Req_AddressColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Address field.
	''' </summary>
	Public Sub SetReq_AddressFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Req_AddressColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_City field.
	''' </summary>
	Public Function GetReq_CityValue() As ColumnValue
		Return Me.GetValue(TableUtils.Req_CityColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_City field.
	''' </summary>
	Public Function GetReq_CityFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Req_CityColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_City field.
	''' </summary>
	Public Sub SetReq_CityFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Req_CityColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_City field.
	''' </summary>
	Public Sub SetReq_CityFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Req_CityColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Island field.
	''' </summary>
	Public Function GetReq_IslandValue() As ColumnValue
		Return Me.GetValue(TableUtils.Req_IslandColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Island field.
	''' </summary>
	Public Function GetReq_IslandFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Req_IslandColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Island field.
	''' </summary>
	Public Sub SetReq_IslandFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Req_IslandColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Island field.
	''' </summary>
	Public Sub SetReq_IslandFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Req_IslandColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_State field.
	''' </summary>
	Public Function GetReq_StateValue() As ColumnValue
		Return Me.GetValue(TableUtils.Req_StateColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_State field.
	''' </summary>
	Public Function GetReq_StateFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Req_StateColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_State field.
	''' </summary>
	Public Sub SetReq_StateFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Req_StateColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_State field.
	''' </summary>
	Public Sub SetReq_StateFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Req_StateColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Zip field.
	''' </summary>
	Public Function GetReq_ZipValue() As ColumnValue
		Return Me.GetValue(TableUtils.Req_ZipColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Zip field.
	''' </summary>
	Public Function GetReq_ZipFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Req_ZipColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Zip field.
	''' </summary>
	Public Sub SetReq_ZipFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Req_ZipColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Zip field.
	''' </summary>
	Public Sub SetReq_ZipFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Req_ZipColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Dt field.
	''' </summary>
	Public Function GetReq_DtValue() As ColumnValue
		Return Me.GetValue(TableUtils.Req_DtColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Dt field.
	''' </summary>
	Public Function GetReq_DtFieldValue() As DateTime
		Return CType(Me.GetValue(TableUtils.Req_DtColumn).ToDateTime(), DateTime)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Dt field.
	''' </summary>
	Public Sub SetReq_DtFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Req_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Dt field.
	''' </summary>
	Public Sub SetReq_DtFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.Req_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Dt field.
	''' </summary>
	Public Sub SetReq_DtFieldValue(ByVal val As DateTime)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Req_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Target_Dt field.
	''' </summary>
	Public Function GetReq_Target_DtValue() As ColumnValue
		Return Me.GetValue(TableUtils.Req_Target_DtColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Target_Dt field.
	''' </summary>
	Public Function GetReq_Target_DtFieldValue() As DateTime
		Return CType(Me.GetValue(TableUtils.Req_Target_DtColumn).ToDateTime(), DateTime)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Target_Dt field.
	''' </summary>
	Public Sub SetReq_Target_DtFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Req_Target_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Target_Dt field.
	''' </summary>
	Public Sub SetReq_Target_DtFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.Req_Target_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Target_Dt field.
	''' </summary>
	Public Sub SetReq_Target_DtFieldValue(ByVal val As DateTime)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Req_Target_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Completed_Dt field.
	''' </summary>
	Public Function GetReq_Completed_DtValue() As ColumnValue
		Return Me.GetValue(TableUtils.Req_Completed_DtColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Completed_Dt field.
	''' </summary>
	Public Function GetReq_Completed_DtFieldValue() As DateTime
		Return CType(Me.GetValue(TableUtils.Req_Completed_DtColumn).ToDateTime(), DateTime)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Completed_Dt field.
	''' </summary>
	Public Sub SetReq_Completed_DtFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Req_Completed_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Completed_Dt field.
	''' </summary>
	Public Sub SetReq_Completed_DtFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.Req_Completed_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Completed_Dt field.
	''' </summary>
	Public Sub SetReq_Completed_DtFieldValue(ByVal val As DateTime)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Req_Completed_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Status field.
	''' </summary>
	Public Function GetReq_StatusValue() As ColumnValue
		Return Me.GetValue(TableUtils.Req_StatusColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Status field.
	''' </summary>
	Public Function GetReq_StatusFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Req_StatusColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Status field.
	''' </summary>
	Public Sub SetReq_StatusFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Req_StatusColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Status field.
	''' </summary>
	Public Sub SetReq_StatusFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Req_StatusColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Funding_Src field.
	''' </summary>
	Public Function GetReq_Funding_SrcValue() As ColumnValue
		Return Me.GetValue(TableUtils.Req_Funding_SrcColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Funding_Src field.
	''' </summary>
	Public Function GetReq_Funding_SrcFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Req_Funding_SrcColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Funding_Src field.
	''' </summary>
	Public Sub SetReq_Funding_SrcFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Req_Funding_SrcColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Funding_Src field.
	''' </summary>
	Public Sub SetReq_Funding_SrcFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Req_Funding_SrcColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Enity field.
	''' </summary>
	Public Function GetReq_EnityValue() As ColumnValue
		Return Me.GetValue(TableUtils.Req_EnityColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Enity field.
	''' </summary>
	Public Function GetReq_EnityFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Req_EnityColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Enity field.
	''' </summary>
	Public Sub SetReq_EnityFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Req_EnityColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Enity field.
	''' </summary>
	Public Sub SetReq_EnityFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Req_EnityColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Comments field.
	''' </summary>
	Public Function GetReq_CommentsValue() As ColumnValue
		Return Me.GetValue(TableUtils.Req_CommentsColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Comments field.
	''' </summary>
	Public Function GetReq_CommentsFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Req_CommentsColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Comments field.
	''' </summary>
	Public Sub SetReq_CommentsFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Req_CommentsColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Comments field.
	''' </summary>
	Public Sub SetReq_CommentsFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Req_CommentsColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Quote_Respnse field.
	''' </summary>
	Public Function GetReq_Quote_RespnseValue() As ColumnValue
		Return Me.GetValue(TableUtils.Req_Quote_RespnseColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Quote_Respnse field.
	''' </summary>
	Public Function GetReq_Quote_RespnseFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Req_Quote_RespnseColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Quote_Respnse field.
	''' </summary>
	Public Sub SetReq_Quote_RespnseFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Req_Quote_RespnseColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Quote_Respnse field.
	''' </summary>
	Public Sub SetReq_Quote_RespnseFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Req_Quote_RespnseColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Quote_Approved field.
	''' </summary>
	Public Function GetReq_Quote_ApprovedValue() As ColumnValue
		Return Me.GetValue(TableUtils.Req_Quote_ApprovedColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Quote_Approved field.
	''' </summary>
	Public Function GetReq_Quote_ApprovedFieldValue() As DateTime
		Return CType(Me.GetValue(TableUtils.Req_Quote_ApprovedColumn).ToDateTime(), DateTime)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Quote_Approved field.
	''' </summary>
	Public Sub SetReq_Quote_ApprovedFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Req_Quote_ApprovedColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Quote_Approved field.
	''' </summary>
	Public Sub SetReq_Quote_ApprovedFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.Req_Quote_ApprovedColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Quote_Approved field.
	''' </summary>
	Public Sub SetReq_Quote_ApprovedFieldValue(ByVal val As DateTime)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Req_Quote_ApprovedColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.ICS_SOW_Needed field.
	''' </summary>
	Public Function GetICS_SOW_NeededValue() As ColumnValue
		Return Me.GetValue(TableUtils.ICS_SOW_NeededColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.ICS_SOW_Needed field.
	''' </summary>
	Public Function GetICS_SOW_NeededFieldValue() As Boolean
		Return CType(Me.GetValue(TableUtils.ICS_SOW_NeededColumn).ToBoolean(), Boolean)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.ICS_SOW_Needed field.
	''' </summary>
	Public Sub SetICS_SOW_NeededFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.ICS_SOW_NeededColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.ICS_SOW_Needed field.
	''' </summary>
	Public Sub SetICS_SOW_NeededFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.ICS_SOW_NeededColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.ICS_SOW_Needed field.
	''' </summary>
	Public Sub SetICS_SOW_NeededFieldValue(ByVal val As Boolean)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.ICS_SOW_NeededColumn)
	End Sub
	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.ICS_SOW_Uploaded field.
	''' </summary>
	Public Function GetICS_SOW_UploadedValue() As ColumnValue
		Return Me.GetValue(TableUtils.ICS_SOW_UploadedColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.ICS_SOW_Uploaded field.
	''' </summary>
	Public Function GetICS_SOW_UploadedFieldValue() As Boolean
		Return CType(Me.GetValue(TableUtils.ICS_SOW_UploadedColumn).ToBoolean(), Boolean)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.ICS_SOW_Uploaded field.
	''' </summary>
	Public Sub SetICS_SOW_UploadedFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.ICS_SOW_UploadedColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.ICS_SOW_Uploaded field.
	''' </summary>
	Public Sub SetICS_SOW_UploadedFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.ICS_SOW_UploadedColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.ICS_SOW_Uploaded field.
	''' </summary>
	Public Sub SetICS_SOW_UploadedFieldValue(ByVal val As Boolean)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.ICS_SOW_UploadedColumn)
	End Sub
	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.ICS_CATV_Comments field.
	''' </summary>
	Public Function GetICS_CATV_CommentsValue() As ColumnValue
		Return Me.GetValue(TableUtils.ICS_CATV_CommentsColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.ICS_CATV_Comments field.
	''' </summary>
	Public Function GetICS_CATV_CommentsFieldValue() As String
		Return CType(Me.GetValue(TableUtils.ICS_CATV_CommentsColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.ICS_CATV_Comments field.
	''' </summary>
	Public Sub SetICS_CATV_CommentsFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.ICS_CATV_CommentsColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.ICS_CATV_Comments field.
	''' </summary>
	Public Sub SetICS_CATV_CommentsFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.ICS_CATV_CommentsColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Cat_Cost_Free field.
	''' </summary>
	Public Function GetCat_Cost_FreeValue() As ColumnValue
		Return Me.GetValue(TableUtils.Cat_Cost_FreeColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Cat_Cost_Free field.
	''' </summary>
	Public Function GetCat_Cost_FreeFieldValue() As Boolean
		Return CType(Me.GetValue(TableUtils.Cat_Cost_FreeColumn).ToBoolean(), Boolean)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Cat_Cost_Free field.
	''' </summary>
	Public Sub SetCat_Cost_FreeFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Cat_Cost_FreeColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Cat_Cost_Free field.
	''' </summary>
	Public Sub SetCat_Cost_FreeFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.Cat_Cost_FreeColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Cat_Cost_Free field.
	''' </summary>
	Public Sub SetCat_Cost_FreeFieldValue(ByVal val As Boolean)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Cat_Cost_FreeColumn)
	End Sub
	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Cat_Franchise_Order_Number field.
	''' </summary>
	Public Function GetCat_Franchise_Order_NumberValue() As ColumnValue
		Return Me.GetValue(TableUtils.Cat_Franchise_Order_NumberColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Cat_Franchise_Order_Number field.
	''' </summary>
	Public Function GetCat_Franchise_Order_NumberFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Cat_Franchise_Order_NumberColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Cat_Franchise_Order_Number field.
	''' </summary>
	Public Sub SetCat_Franchise_Order_NumberFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Cat_Franchise_Order_NumberColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Cat_Franchise_Order_Number field.
	''' </summary>
	Public Sub SetCat_Franchise_Order_NumberFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Cat_Franchise_Order_NumberColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.County_Upload field.
	''' </summary>
	Public Function GetCounty_UploadValue() As ColumnValue
		Return Me.GetValue(TableUtils.County_UploadColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.County_Upload field.
	''' </summary>
	Public Function GetCounty_UploadFieldValue() As Boolean
		Return CType(Me.GetValue(TableUtils.County_UploadColumn).ToBoolean(), Boolean)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.County_Upload field.
	''' </summary>
	Public Sub SetCounty_UploadFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.County_UploadColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.County_Upload field.
	''' </summary>
	Public Sub SetCounty_UploadFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.County_UploadColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.County_Upload field.
	''' </summary>
	Public Sub SetCounty_UploadFieldValue(ByVal val As Boolean)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.County_UploadColumn)
	End Sub
	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Cat_OTWC_Comments field.
	''' </summary>
	Public Function GetCat_OTWC_CommentsValue() As ColumnValue
		Return Me.GetValue(TableUtils.Cat_OTWC_CommentsColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Cat_OTWC_Comments field.
	''' </summary>
	Public Function GetCat_OTWC_CommentsFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Cat_OTWC_CommentsColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Cat_OTWC_Comments field.
	''' </summary>
	Public Sub SetCat_OTWC_CommentsFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Cat_OTWC_CommentsColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Cat_OTWC_Comments field.
	''' </summary>
	Public Sub SetCat_OTWC_CommentsFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Cat_OTWC_CommentsColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_Quote field.
	''' </summary>
	Public Function GetOTW_QuoteValue() As ColumnValue
		Return Me.GetValue(TableUtils.OTW_QuoteColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_Quote field.
	''' </summary>
	Public Function GetOTW_QuoteFieldValue() As Int32
		Return CType(Me.GetValue(TableUtils.OTW_QuoteColumn).ToInt32(), Int32)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Quote field.
	''' </summary>
	Public Sub SetOTW_QuoteFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.OTW_QuoteColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Quote field.
	''' </summary>
	Public Sub SetOTW_QuoteFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.OTW_QuoteColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Quote field.
	''' </summary>
	Public Sub SetOTW_QuoteFieldValue(ByVal val As Double)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.OTW_QuoteColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Quote field.
	''' </summary>
	Public Sub SetOTW_QuoteFieldValue(ByVal val As Decimal)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.OTW_QuoteColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Quote field.
	''' </summary>
	Public Sub SetOTW_QuoteFieldValue(ByVal val As Int64)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.OTW_QuoteColumn)
	End Sub
	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_More_Info_Flag field.
	''' </summary>
	Public Function GetOTW_More_Info_FlagValue() As ColumnValue
		Return Me.GetValue(TableUtils.OTW_More_Info_FlagColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_More_Info_Flag field.
	''' </summary>
	Public Function GetOTW_More_Info_FlagFieldValue() As Boolean
		Return CType(Me.GetValue(TableUtils.OTW_More_Info_FlagColumn).ToBoolean(), Boolean)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_More_Info_Flag field.
	''' </summary>
	Public Sub SetOTW_More_Info_FlagFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.OTW_More_Info_FlagColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_More_Info_Flag field.
	''' </summary>
	Public Sub SetOTW_More_Info_FlagFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.OTW_More_Info_FlagColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_More_Info_Flag field.
	''' </summary>
	Public Sub SetOTW_More_Info_FlagFieldValue(ByVal val As Boolean)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.OTW_More_Info_FlagColumn)
	End Sub
	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_More_Info_Comments field.
	''' </summary>
	Public Function GetOTW_More_Info_CommentsValue() As ColumnValue
		Return Me.GetValue(TableUtils.OTW_More_Info_CommentsColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_More_Info_Comments field.
	''' </summary>
	Public Function GetOTW_More_Info_CommentsFieldValue() As String
		Return CType(Me.GetValue(TableUtils.OTW_More_Info_CommentsColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_More_Info_Comments field.
	''' </summary>
	Public Sub SetOTW_More_Info_CommentsFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.OTW_More_Info_CommentsColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_More_Info_Comments field.
	''' </summary>
	Public Sub SetOTW_More_Info_CommentsFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.OTW_More_Info_CommentsColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_Permit_Status field.
	''' </summary>
	Public Function GetOTW_Permit_StatusValue() As ColumnValue
		Return Me.GetValue(TableUtils.OTW_Permit_StatusColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_Permit_Status field.
	''' </summary>
	Public Function GetOTW_Permit_StatusFieldValue() As String
		Return CType(Me.GetValue(TableUtils.OTW_Permit_StatusColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Permit_Status field.
	''' </summary>
	Public Sub SetOTW_Permit_StatusFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.OTW_Permit_StatusColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Permit_Status field.
	''' </summary>
	Public Sub SetOTW_Permit_StatusFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.OTW_Permit_StatusColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_Premise Fiber Work Reqd field.
	''' </summary>
	Public Function GetOTW_Premise_Fiber_Work_ReqdValue() As ColumnValue
		Return Me.GetValue(TableUtils.OTW_Premise_Fiber_Work_ReqdColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_Premise Fiber Work Reqd field.
	''' </summary>
	Public Function GetOTW_Premise_Fiber_Work_ReqdFieldValue() As Boolean
		Return CType(Me.GetValue(TableUtils.OTW_Premise_Fiber_Work_ReqdColumn).ToBoolean(), Boolean)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Premise Fiber Work Reqd field.
	''' </summary>
	Public Sub SetOTW_Premise_Fiber_Work_ReqdFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.OTW_Premise_Fiber_Work_ReqdColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Premise Fiber Work Reqd field.
	''' </summary>
	Public Sub SetOTW_Premise_Fiber_Work_ReqdFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.OTW_Premise_Fiber_Work_ReqdColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Premise Fiber Work Reqd field.
	''' </summary>
	Public Sub SetOTW_Premise_Fiber_Work_ReqdFieldValue(ByVal val As Boolean)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.OTW_Premise_Fiber_Work_ReqdColumn)
	End Sub
	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_On-Net field.
	''' </summary>
	Public Function GetOTW_On_NetValue() As ColumnValue
		Return Me.GetValue(TableUtils.OTW_On_NetColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_On-Net field.
	''' </summary>
	Public Function GetOTW_On_NetFieldValue() As Boolean
		Return CType(Me.GetValue(TableUtils.OTW_On_NetColumn).ToBoolean(), Boolean)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_On-Net field.
	''' </summary>
	Public Sub SetOTW_On_NetFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.OTW_On_NetColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_On-Net field.
	''' </summary>
	Public Sub SetOTW_On_NetFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.OTW_On_NetColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_On-Net field.
	''' </summary>
	Public Sub SetOTW_On_NetFieldValue(ByVal val As Boolean)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.OTW_On_NetColumn)
	End Sub
	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_Scheduled_Deploy_Dt field.
	''' </summary>
	Public Function GetOTW_Scheduled_Deploy_DtValue() As ColumnValue
		Return Me.GetValue(TableUtils.OTW_Scheduled_Deploy_DtColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_Scheduled_Deploy_Dt field.
	''' </summary>
	Public Function GetOTW_Scheduled_Deploy_DtFieldValue() As DateTime
		Return CType(Me.GetValue(TableUtils.OTW_Scheduled_Deploy_DtColumn).ToDateTime(), DateTime)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Scheduled_Deploy_Dt field.
	''' </summary>
	Public Sub SetOTW_Scheduled_Deploy_DtFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.OTW_Scheduled_Deploy_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Scheduled_Deploy_Dt field.
	''' </summary>
	Public Sub SetOTW_Scheduled_Deploy_DtFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.OTW_Scheduled_Deploy_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Scheduled_Deploy_Dt field.
	''' </summary>
	Public Sub SetOTW_Scheduled_Deploy_DtFieldValue(ByVal val As DateTime)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.OTW_Scheduled_Deploy_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_Projected_Deploy_Dt field.
	''' </summary>
	Public Function GetOTW_Projected_Deploy_DtValue() As ColumnValue
		Return Me.GetValue(TableUtils.OTW_Projected_Deploy_DtColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_Projected_Deploy_Dt field.
	''' </summary>
	Public Function GetOTW_Projected_Deploy_DtFieldValue() As DateTime
		Return CType(Me.GetValue(TableUtils.OTW_Projected_Deploy_DtColumn).ToDateTime(), DateTime)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Projected_Deploy_Dt field.
	''' </summary>
	Public Sub SetOTW_Projected_Deploy_DtFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.OTW_Projected_Deploy_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Projected_Deploy_Dt field.
	''' </summary>
	Public Sub SetOTW_Projected_Deploy_DtFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.OTW_Projected_Deploy_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Projected_Deploy_Dt field.
	''' </summary>
	Public Sub SetOTW_Projected_Deploy_DtFieldValue(ByVal val As DateTime)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.OTW_Projected_Deploy_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_Deployment_Start_Dt field.
	''' </summary>
	Public Function GetOTW_Deployment_Start_DtValue() As ColumnValue
		Return Me.GetValue(TableUtils.OTW_Deployment_Start_DtColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_Deployment_Start_Dt field.
	''' </summary>
	Public Function GetOTW_Deployment_Start_DtFieldValue() As DateTime
		Return CType(Me.GetValue(TableUtils.OTW_Deployment_Start_DtColumn).ToDateTime(), DateTime)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Deployment_Start_Dt field.
	''' </summary>
	Public Sub SetOTW_Deployment_Start_DtFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.OTW_Deployment_Start_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Deployment_Start_Dt field.
	''' </summary>
	Public Sub SetOTW_Deployment_Start_DtFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.OTW_Deployment_Start_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Deployment_Start_Dt field.
	''' </summary>
	Public Sub SetOTW_Deployment_Start_DtFieldValue(ByVal val As DateTime)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.OTW_Deployment_Start_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_Construction_Status field.
	''' </summary>
	Public Function GetOTW_Construction_StatusValue() As ColumnValue
		Return Me.GetValue(TableUtils.OTW_Construction_StatusColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_Construction_Status field.
	''' </summary>
	Public Function GetOTW_Construction_StatusFieldValue() As String
		Return CType(Me.GetValue(TableUtils.OTW_Construction_StatusColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Construction_Status field.
	''' </summary>
	Public Sub SetOTW_Construction_StatusFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.OTW_Construction_StatusColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Construction_Status field.
	''' </summary>
	Public Sub SetOTW_Construction_StatusFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.OTW_Construction_StatusColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_Island completed field.
	''' </summary>
	Public Function GetOTW_Island_completedValue() As ColumnValue
		Return Me.GetValue(TableUtils.OTW_Island_completedColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_Island completed field.
	''' </summary>
	Public Function GetOTW_Island_completedFieldValue() As String
		Return CType(Me.GetValue(TableUtils.OTW_Island_completedColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Island completed field.
	''' </summary>
	Public Sub SetOTW_Island_completedFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.OTW_Island_completedColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Island completed field.
	''' </summary>
	Public Sub SetOTW_Island_completedFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.OTW_Island_completedColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_Completed_Dt field.
	''' </summary>
	Public Function GetOTW_Completed_DtValue() As ColumnValue
		Return Me.GetValue(TableUtils.OTW_Completed_DtColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_Completed_Dt field.
	''' </summary>
	Public Function GetOTW_Completed_DtFieldValue() As DateTime
		Return CType(Me.GetValue(TableUtils.OTW_Completed_DtColumn).ToDateTime(), DateTime)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Completed_Dt field.
	''' </summary>
	Public Sub SetOTW_Completed_DtFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.OTW_Completed_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Completed_Dt field.
	''' </summary>
	Public Sub SetOTW_Completed_DtFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.OTW_Completed_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Completed_Dt field.
	''' </summary>
	Public Sub SetOTW_Completed_DtFieldValue(ByVal val As DateTime)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.OTW_Completed_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Pending_Agency field.
	''' </summary>
	Public Function GetPending_AgencyValue() As ColumnValue
		Return Me.GetValue(TableUtils.Pending_AgencyColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Pending_Agency field.
	''' </summary>
	Public Function GetPending_AgencyFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Pending_AgencyColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Agency field.
	''' </summary>
	Public Sub SetPending_AgencyFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Pending_AgencyColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Agency field.
	''' </summary>
	Public Sub SetPending_AgencyFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Pending_AgencyColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Pending Action_Dt field.
	''' </summary>
	Public Function GetPending_Action_DtValue() As ColumnValue
		Return Me.GetValue(TableUtils.Pending_Action_DtColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Pending Action_Dt field.
	''' </summary>
	Public Function GetPending_Action_DtFieldValue() As DateTime
		Return CType(Me.GetValue(TableUtils.Pending_Action_DtColumn).ToDateTime(), DateTime)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending Action_Dt field.
	''' </summary>
	Public Sub SetPending_Action_DtFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Pending_Action_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending Action_Dt field.
	''' </summary>
	Public Sub SetPending_Action_DtFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.Pending_Action_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending Action_Dt field.
	''' </summary>
	Public Sub SetPending_Action_DtFieldValue(ByVal val As DateTime)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Pending_Action_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Pending_Action_Needed field.
	''' </summary>
	Public Function GetPending_Action_NeededValue() As ColumnValue
		Return Me.GetValue(TableUtils.Pending_Action_NeededColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Pending_Action_Needed field.
	''' </summary>
	Public Function GetPending_Action_NeededFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Pending_Action_NeededColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Action_Needed field.
	''' </summary>
	Public Sub SetPending_Action_NeededFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Pending_Action_NeededColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Action_Needed field.
	''' </summary>
	Public Sub SetPending_Action_NeededFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Pending_Action_NeededColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Pending_Interval_Days_1st field.
	''' </summary>
	Public Function GetPending_Interval_Days_1stValue() As ColumnValue
		Return Me.GetValue(TableUtils.Pending_Interval_Days_1stColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Pending_Interval_Days_1st field.
	''' </summary>
	Public Function GetPending_Interval_Days_1stFieldValue() As Int16
		Return CType(Me.GetValue(TableUtils.Pending_Interval_Days_1stColumn).ToInt16(), Int16)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Interval_Days_1st field.
	''' </summary>
	Public Sub SetPending_Interval_Days_1stFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Pending_Interval_Days_1stColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Interval_Days_1st field.
	''' </summary>
	Public Sub SetPending_Interval_Days_1stFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.Pending_Interval_Days_1stColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Interval_Days_1st field.
	''' </summary>
	Public Sub SetPending_Interval_Days_1stFieldValue(ByVal val As Double)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Pending_Interval_Days_1stColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Interval_Days_1st field.
	''' </summary>
	Public Sub SetPending_Interval_Days_1stFieldValue(ByVal val As Decimal)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Pending_Interval_Days_1stColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Interval_Days_1st field.
	''' </summary>
	Public Sub SetPending_Interval_Days_1stFieldValue(ByVal val As Int64)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Pending_Interval_Days_1stColumn)
	End Sub
	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Pending_Interval_Days_2nd field.
	''' </summary>
	Public Function GetPending_Interval_Days_2ndValue() As ColumnValue
		Return Me.GetValue(TableUtils.Pending_Interval_Days_2ndColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Pending_Interval_Days_2nd field.
	''' </summary>
	Public Function GetPending_Interval_Days_2ndFieldValue() As Int16
		Return CType(Me.GetValue(TableUtils.Pending_Interval_Days_2ndColumn).ToInt16(), Int16)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Interval_Days_2nd field.
	''' </summary>
	Public Sub SetPending_Interval_Days_2ndFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Pending_Interval_Days_2ndColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Interval_Days_2nd field.
	''' </summary>
	Public Sub SetPending_Interval_Days_2ndFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.Pending_Interval_Days_2ndColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Interval_Days_2nd field.
	''' </summary>
	Public Sub SetPending_Interval_Days_2ndFieldValue(ByVal val As Double)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Pending_Interval_Days_2ndColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Interval_Days_2nd field.
	''' </summary>
	Public Sub SetPending_Interval_Days_2ndFieldValue(ByVal val As Decimal)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Pending_Interval_Days_2ndColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Interval_Days_2nd field.
	''' </summary>
	Public Sub SetPending_Interval_Days_2ndFieldValue(ByVal val As Int64)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Pending_Interval_Days_2ndColumn)
	End Sub
	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Pending_Nterval_Days_Max field.
	''' </summary>
	Public Function GetPending_Nterval_Days_MaxValue() As ColumnValue
		Return Me.GetValue(TableUtils.Pending_Nterval_Days_MaxColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Pending_Nterval_Days_Max field.
	''' </summary>
	Public Function GetPending_Nterval_Days_MaxFieldValue() As Int16
		Return CType(Me.GetValue(TableUtils.Pending_Nterval_Days_MaxColumn).ToInt16(), Int16)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Nterval_Days_Max field.
	''' </summary>
	Public Sub SetPending_Nterval_Days_MaxFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Pending_Nterval_Days_MaxColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Nterval_Days_Max field.
	''' </summary>
	Public Sub SetPending_Nterval_Days_MaxFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.Pending_Nterval_Days_MaxColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Nterval_Days_Max field.
	''' </summary>
	Public Sub SetPending_Nterval_Days_MaxFieldValue(ByVal val As Double)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Pending_Nterval_Days_MaxColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Nterval_Days_Max field.
	''' </summary>
	Public Sub SetPending_Nterval_Days_MaxFieldValue(ByVal val As Decimal)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Pending_Nterval_Days_MaxColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Nterval_Days_Max field.
	''' </summary>
	Public Sub SetPending_Nterval_Days_MaxFieldValue(ByVal val As Int64)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Pending_Nterval_Days_MaxColumn)
	End Sub
	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Pending_Interval_Days_Cancel field.
	''' </summary>
	Public Function GetPending_Interval_Days_CancelValue() As ColumnValue
		Return Me.GetValue(TableUtils.Pending_Interval_Days_CancelColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Pending_Interval_Days_Cancel field.
	''' </summary>
	Public Function GetPending_Interval_Days_CancelFieldValue() As Int16
		Return CType(Me.GetValue(TableUtils.Pending_Interval_Days_CancelColumn).ToInt16(), Int16)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Interval_Days_Cancel field.
	''' </summary>
	Public Sub SetPending_Interval_Days_CancelFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Pending_Interval_Days_CancelColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Interval_Days_Cancel field.
	''' </summary>
	Public Sub SetPending_Interval_Days_CancelFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.Pending_Interval_Days_CancelColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Interval_Days_Cancel field.
	''' </summary>
	Public Sub SetPending_Interval_Days_CancelFieldValue(ByVal val As Double)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Pending_Interval_Days_CancelColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Interval_Days_Cancel field.
	''' </summary>
	Public Sub SetPending_Interval_Days_CancelFieldValue(ByVal val As Decimal)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Pending_Interval_Days_CancelColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Interval_Days_Cancel field.
	''' </summary>
	Public Sub SetPending_Interval_Days_CancelFieldValue(ByVal val As Int64)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Pending_Interval_Days_CancelColumn)
	End Sub
	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Pending_Interval_Days_Auto_Cancel field.
	''' </summary>
	Public Function GetPending_Interval_Days_Auto_CancelValue() As ColumnValue
		Return Me.GetValue(TableUtils.Pending_Interval_Days_Auto_CancelColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Pending_Interval_Days_Auto_Cancel field.
	''' </summary>
	Public Function GetPending_Interval_Days_Auto_CancelFieldValue() As Int16
		Return CType(Me.GetValue(TableUtils.Pending_Interval_Days_Auto_CancelColumn).ToInt16(), Int16)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Interval_Days_Auto_Cancel field.
	''' </summary>
	Public Sub SetPending_Interval_Days_Auto_CancelFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Pending_Interval_Days_Auto_CancelColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Interval_Days_Auto_Cancel field.
	''' </summary>
	Public Sub SetPending_Interval_Days_Auto_CancelFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.Pending_Interval_Days_Auto_CancelColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Interval_Days_Auto_Cancel field.
	''' </summary>
	Public Sub SetPending_Interval_Days_Auto_CancelFieldValue(ByVal val As Double)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Pending_Interval_Days_Auto_CancelColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Interval_Days_Auto_Cancel field.
	''' </summary>
	Public Sub SetPending_Interval_Days_Auto_CancelFieldValue(ByVal val As Decimal)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Pending_Interval_Days_Auto_CancelColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Interval_Days_Auto_Cancel field.
	''' </summary>
	Public Sub SetPending_Interval_Days_Auto_CancelFieldValue(ByVal val As Int64)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Pending_Interval_Days_Auto_CancelColumn)
	End Sub
	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_PO_No field.
	''' </summary>
	Public Function GetReq_PO_NoValue() As ColumnValue
		Return Me.GetValue(TableUtils.Req_PO_NoColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_PO_No field.
	''' </summary>
	Public Function GetReq_PO_NoFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Req_PO_NoColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_PO_No field.
	''' </summary>
	Public Sub SetReq_PO_NoFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Req_PO_NoColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_PO_No field.
	''' </summary>
	Public Sub SetReq_PO_NoFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Req_PO_NoColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_PO_Dt field.
	''' </summary>
	Public Function GetReq_PO_DtValue() As ColumnValue
		Return Me.GetValue(TableUtils.Req_PO_DtColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_PO_Dt field.
	''' </summary>
	Public Function GetReq_PO_DtFieldValue() As DateTime
		Return CType(Me.GetValue(TableUtils.Req_PO_DtColumn).ToDateTime(), DateTime)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_PO_Dt field.
	''' </summary>
	Public Sub SetReq_PO_DtFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Req_PO_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_PO_Dt field.
	''' </summary>
	Public Sub SetReq_PO_DtFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.Req_PO_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_PO_Dt field.
	''' </summary>
	Public Sub SetReq_PO_DtFieldValue(ByVal val As DateTime)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Req_PO_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_PO_Amt field.
	''' </summary>
	Public Function GetReq_PO_AmtValue() As ColumnValue
		Return Me.GetValue(TableUtils.Req_PO_AmtColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_PO_Amt field.
	''' </summary>
	Public Function GetReq_PO_AmtFieldValue() As Decimal
		Return CType(Me.GetValue(TableUtils.Req_PO_AmtColumn).ToDecimal(), Decimal)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_PO_Amt field.
	''' </summary>
	Public Sub SetReq_PO_AmtFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Req_PO_AmtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_PO_Amt field.
	''' </summary>
	Public Sub SetReq_PO_AmtFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.Req_PO_AmtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_PO_Amt field.
	''' </summary>
	Public Sub SetReq_PO_AmtFieldValue(ByVal val As Double)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Req_PO_AmtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_PO_Amt field.
	''' </summary>
	Public Sub SetReq_PO_AmtFieldValue(ByVal val As Decimal)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Req_PO_AmtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_PO_Amt field.
	''' </summary>
	Public Sub SetReq_PO_AmtFieldValue(ByVal val As Int64)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Req_PO_AmtColumn)
	End Sub
	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Invoice_Paid field.
	''' </summary>
	Public Function GetReq_Invoice_PaidValue() As ColumnValue
		Return Me.GetValue(TableUtils.Req_Invoice_PaidColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Invoice_Paid field.
	''' </summary>
	Public Function GetReq_Invoice_PaidFieldValue() As Boolean
		Return CType(Me.GetValue(TableUtils.Req_Invoice_PaidColumn).ToBoolean(), Boolean)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Invoice_Paid field.
	''' </summary>
	Public Sub SetReq_Invoice_PaidFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Req_Invoice_PaidColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Invoice_Paid field.
	''' </summary>
	Public Sub SetReq_Invoice_PaidFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.Req_Invoice_PaidColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Invoice_Paid field.
	''' </summary>
	Public Sub SetReq_Invoice_PaidFieldValue(ByVal val As Boolean)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Req_Invoice_PaidColumn)
	End Sub
	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Pymt_Check_No field.
	''' </summary>
	Public Function GetReq_Pymt_Check_NoValue() As ColumnValue
		Return Me.GetValue(TableUtils.Req_Pymt_Check_NoColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Pymt_Check_No field.
	''' </summary>
	Public Function GetReq_Pymt_Check_NoFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Req_Pymt_Check_NoColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Pymt_Check_No field.
	''' </summary>
	Public Sub SetReq_Pymt_Check_NoFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Req_Pymt_Check_NoColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Pymt_Check_No field.
	''' </summary>
	Public Sub SetReq_Pymt_Check_NoFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Req_Pymt_Check_NoColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Pymt_Dt field.
	''' </summary>
	Public Function GetReq_Pymt_DtValue() As ColumnValue
		Return Me.GetValue(TableUtils.Req_Pymt_DtColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Pymt_Dt field.
	''' </summary>
	Public Function GetReq_Pymt_DtFieldValue() As DateTime
		Return CType(Me.GetValue(TableUtils.Req_Pymt_DtColumn).ToDateTime(), DateTime)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Pymt_Dt field.
	''' </summary>
	Public Sub SetReq_Pymt_DtFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Req_Pymt_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Pymt_Dt field.
	''' </summary>
	Public Sub SetReq_Pymt_DtFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.Req_Pymt_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Pymt_Dt field.
	''' </summary>
	Public Sub SetReq_Pymt_DtFieldValue(ByVal val As DateTime)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Req_Pymt_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Pymt_Amt field.
	''' </summary>
	Public Function GetReq_Pymt_AmtValue() As ColumnValue
		Return Me.GetValue(TableUtils.Req_Pymt_AmtColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Pymt_Amt field.
	''' </summary>
	Public Function GetReq_Pymt_AmtFieldValue() As Decimal
		Return CType(Me.GetValue(TableUtils.Req_Pymt_AmtColumn).ToDecimal(), Decimal)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Pymt_Amt field.
	''' </summary>
	Public Sub SetReq_Pymt_AmtFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Req_Pymt_AmtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Pymt_Amt field.
	''' </summary>
	Public Sub SetReq_Pymt_AmtFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.Req_Pymt_AmtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Pymt_Amt field.
	''' </summary>
	Public Sub SetReq_Pymt_AmtFieldValue(ByVal val As Double)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Req_Pymt_AmtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Pymt_Amt field.
	''' </summary>
	Public Sub SetReq_Pymt_AmtFieldValue(ByVal val As Decimal)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Req_Pymt_AmtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Pymt_Amt field.
	''' </summary>
	Public Sub SetReq_Pymt_AmtFieldValue(ByVal val As Int64)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Req_Pymt_AmtColumn)
	End Sub
	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_Invoice_No field.
	''' </summary>
	Public Function GetOTW_Invoice_NoValue() As ColumnValue
		Return Me.GetValue(TableUtils.OTW_Invoice_NoColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_Invoice_No field.
	''' </summary>
	Public Function GetOTW_Invoice_NoFieldValue() As String
		Return CType(Me.GetValue(TableUtils.OTW_Invoice_NoColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Invoice_No field.
	''' </summary>
	Public Sub SetOTW_Invoice_NoFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.OTW_Invoice_NoColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Invoice_No field.
	''' </summary>
	Public Sub SetOTW_Invoice_NoFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.OTW_Invoice_NoColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_Invoice_Dt field.
	''' </summary>
	Public Function GetOTW_Invoice_DtValue() As ColumnValue
		Return Me.GetValue(TableUtils.OTW_Invoice_DtColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_Invoice_Dt field.
	''' </summary>
	Public Function GetOTW_Invoice_DtFieldValue() As DateTime
		Return CType(Me.GetValue(TableUtils.OTW_Invoice_DtColumn).ToDateTime(), DateTime)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Invoice_Dt field.
	''' </summary>
	Public Sub SetOTW_Invoice_DtFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.OTW_Invoice_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Invoice_Dt field.
	''' </summary>
	Public Sub SetOTW_Invoice_DtFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.OTW_Invoice_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Invoice_Dt field.
	''' </summary>
	Public Sub SetOTW_Invoice_DtFieldValue(ByVal val As DateTime)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.OTW_Invoice_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_Invoice_Amt field.
	''' </summary>
	Public Function GetOTW_Invoice_AmtValue() As ColumnValue
		Return Me.GetValue(TableUtils.OTW_Invoice_AmtColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_Invoice_Amt field.
	''' </summary>
	Public Function GetOTW_Invoice_AmtFieldValue() As Decimal
		Return CType(Me.GetValue(TableUtils.OTW_Invoice_AmtColumn).ToDecimal(), Decimal)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Invoice_Amt field.
	''' </summary>
	Public Sub SetOTW_Invoice_AmtFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.OTW_Invoice_AmtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Invoice_Amt field.
	''' </summary>
	Public Sub SetOTW_Invoice_AmtFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.OTW_Invoice_AmtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Invoice_Amt field.
	''' </summary>
	Public Sub SetOTW_Invoice_AmtFieldValue(ByVal val As Double)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.OTW_Invoice_AmtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Invoice_Amt field.
	''' </summary>
	Public Sub SetOTW_Invoice_AmtFieldValue(ByVal val As Decimal)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.OTW_Invoice_AmtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_Invoice_Amt field.
	''' </summary>
	Public Sub SetOTW_Invoice_AmtFieldValue(ByVal val As Int64)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.OTW_Invoice_AmtColumn)
	End Sub
	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Reg_Type field.
	''' </summary>
	Public Function GetReg_TypeValue() As ColumnValue
		Return Me.GetValue(TableUtils.Reg_TypeColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Reg_Type field.
	''' </summary>
	Public Function GetReg_TypeFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Reg_TypeColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Reg_Type field.
	''' </summary>
	Public Sub SetReg_TypeFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Reg_TypeColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Reg_Type field.
	''' </summary>
	Public Sub SetReg_TypeFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Reg_TypeColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Contact_Email field.
	''' </summary>
	Public Function GetReq_Contact_EmailValue() As ColumnValue
		Return Me.GetValue(TableUtils.Req_Contact_EmailColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Contact_Email field.
	''' </summary>
	Public Function GetReq_Contact_EmailFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Req_Contact_EmailColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Contact_Email field.
	''' </summary>
	Public Sub SetReq_Contact_EmailFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Req_Contact_EmailColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Contact_Email field.
	''' </summary>
	Public Sub SetReq_Contact_EmailFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Req_Contact_EmailColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Enity2 field.
	''' </summary>
	Public Function GetReq_Enity2Value() As ColumnValue
		Return Me.GetValue(TableUtils.Req_Enity2Column)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Enity2 field.
	''' </summary>
	Public Function GetReq_Enity2FieldValue() As String
		Return CType(Me.GetValue(TableUtils.Req_Enity2Column).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Enity2 field.
	''' </summary>
	Public Sub SetReq_Enity2FieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Req_Enity2Column)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Enity2 field.
	''' </summary>
	Public Sub SetReq_Enity2FieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Req_Enity2Column)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Funding_Src2 field.
	''' </summary>
	Public Function GetReq_Funding_Src2Value() As ColumnValue
		Return Me.GetValue(TableUtils.Req_Funding_Src2Column)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Funding_Src2 field.
	''' </summary>
	Public Function GetReq_Funding_Src2FieldValue() As String
		Return CType(Me.GetValue(TableUtils.Req_Funding_Src2Column).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Funding_Src2 field.
	''' </summary>
	Public Sub SetReq_Funding_Src2FieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Req_Funding_Src2Column)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Funding_Src2 field.
	''' </summary>
	Public Sub SetReq_Funding_Src2FieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Req_Funding_Src2Column)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Pending_Agency_Return field.
	''' </summary>
	Public Function GetPending_Agency_ReturnValue() As ColumnValue
		Return Me.GetValue(TableUtils.Pending_Agency_ReturnColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Pending_Agency_Return field.
	''' </summary>
	Public Function GetPending_Agency_ReturnFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Pending_Agency_ReturnColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Agency_Return field.
	''' </summary>
	Public Sub SetPending_Agency_ReturnFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Pending_Agency_ReturnColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Agency_Return field.
	''' </summary>
	Public Sub SetPending_Agency_ReturnFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Pending_Agency_ReturnColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Pending_Prev_Action_Needed field.
	''' </summary>
	Public Function GetPending_Prev_Action_NeededValue() As ColumnValue
		Return Me.GetValue(TableUtils.Pending_Prev_Action_NeededColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Pending_Prev_Action_Needed field.
	''' </summary>
	Public Function GetPending_Prev_Action_NeededFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Pending_Prev_Action_NeededColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Prev_Action_Needed field.
	''' </summary>
	Public Sub SetPending_Prev_Action_NeededFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Pending_Prev_Action_NeededColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Prev_Action_Needed field.
	''' </summary>
	Public Sub SetPending_Prev_Action_NeededFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Pending_Prev_Action_NeededColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Pending_Prev_Status field.
	''' </summary>
	Public Function GetPending_Prev_StatusValue() As ColumnValue
		Return Me.GetValue(TableUtils.Pending_Prev_StatusColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Pending_Prev_Status field.
	''' </summary>
	Public Function GetPending_Prev_StatusFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Pending_Prev_StatusColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Prev_Status field.
	''' </summary>
	Public Sub SetPending_Prev_StatusFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Pending_Prev_StatusColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Pending_Prev_Status field.
	''' </summary>
	Public Sub SetPending_Prev_StatusFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Pending_Prev_StatusColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Prov_Name field.
	''' </summary>
	Public Function GetProv_NameValue() As ColumnValue
		Return Me.GetValue(TableUtils.Prov_NameColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Prov_Name field.
	''' </summary>
	Public Function GetProv_NameFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Prov_NameColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Prov_Name field.
	''' </summary>
	Public Sub SetProv_NameFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Prov_NameColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Prov_Name field.
	''' </summary>
	Public Sub SetProv_NameFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Prov_NameColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Cat_Franchise_Order_Number2 field.
	''' </summary>
	Public Function GetCat_Franchise_Order_Number2Value() As ColumnValue
		Return Me.GetValue(TableUtils.Cat_Franchise_Order_Number2Column)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Cat_Franchise_Order_Number2 field.
	''' </summary>
	Public Function GetCat_Franchise_Order_Number2FieldValue() As String
		Return CType(Me.GetValue(TableUtils.Cat_Franchise_Order_Number2Column).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Cat_Franchise_Order_Number2 field.
	''' </summary>
	Public Sub SetCat_Franchise_Order_Number2FieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Cat_Franchise_Order_Number2Column)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Cat_Franchise_Order_Number2 field.
	''' </summary>
	Public Sub SetCat_Franchise_Order_Number2FieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Cat_Franchise_Order_Number2Column)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_On_Net_Dt field.
	''' </summary>
	Public Function GetOTW_On_Net_DtValue() As ColumnValue
		Return Me.GetValue(TableUtils.OTW_On_Net_DtColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.OTW_On_Net_Dt field.
	''' </summary>
	Public Function GetOTW_On_Net_DtFieldValue() As DateTime
		Return CType(Me.GetValue(TableUtils.OTW_On_Net_DtColumn).ToDateTime(), DateTime)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_On_Net_Dt field.
	''' </summary>
	Public Sub SetOTW_On_Net_DtFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.OTW_On_Net_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_On_Net_Dt field.
	''' </summary>
	Public Sub SetOTW_On_Net_DtFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.OTW_On_Net_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.OTW_On_Net_Dt field.
	''' </summary>
	Public Sub SetOTW_On_Net_DtFieldValue(ByVal val As DateTime)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.OTW_On_Net_DtColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Contact_Email2 field.
	''' </summary>
	Public Function GetReq_Contact_Email2Value() As ColumnValue
		Return Me.GetValue(TableUtils.Req_Contact_Email2Column)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Request_Master_.Req_Contact_Email2 field.
	''' </summary>
	Public Function GetReq_Contact_Email2FieldValue() As String
		Return CType(Me.GetValue(TableUtils.Req_Contact_Email2Column).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Contact_Email2 field.
	''' </summary>
	Public Sub SetReq_Contact_Email2FieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Req_Contact_Email2Column)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Request_Master_.Req_Contact_Email2 field.
	''' </summary>
	Public Sub SetReq_Contact_Email2FieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Req_Contact_Email2Column)
	End Sub



#End Region

#Region "Convenience methods to get field names"

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Request_Id field.
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
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.IROC_Id field.
	''' </summary>
	Public Property IROC_Id() As String
		Get 
			Return CType(Me.GetValue(TableUtils.IROC_IdColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.IROC_IdColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property IROC_IdSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.IROC_IdColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property IROC_IdDefault() As String
        Get
            Return TableUtils.IROC_IdColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Priority field.
	''' </summary>
	Public Property Priority() As Int16
		Get 
			Return CType(Me.GetValue(TableUtils.PriorityColumn).ToInt16(), Int16)
		End Get
		Set (ByVal val As Int16) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.PriorityColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property PrioritySpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.PriorityColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property PriorityDefault() As String
        Get
            Return TableUtils.PriorityColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Req_Site_Name field.
	''' </summary>
	Public Property Req_Site_Name() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Req_Site_NameColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Req_Site_NameColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Req_Site_NameSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Req_Site_NameColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Req_Site_NameDefault() As String
        Get
            Return TableUtils.Req_Site_NameColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Req_Address field.
	''' </summary>
	Public Property Req_Address() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Req_AddressColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Req_AddressColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Req_AddressSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Req_AddressColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Req_AddressDefault() As String
        Get
            Return TableUtils.Req_AddressColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Req_City field.
	''' </summary>
	Public Property Req_City() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Req_CityColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Req_CityColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Req_CitySpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Req_CityColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Req_CityDefault() As String
        Get
            Return TableUtils.Req_CityColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Req_Island field.
	''' </summary>
	Public Property Req_Island() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Req_IslandColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Req_IslandColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Req_IslandSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Req_IslandColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Req_IslandDefault() As String
        Get
            Return TableUtils.Req_IslandColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Req_State field.
	''' </summary>
	Public Property Req_State() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Req_StateColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Req_StateColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Req_StateSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Req_StateColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Req_StateDefault() As String
        Get
            Return TableUtils.Req_StateColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Req_Zip field.
	''' </summary>
	Public Property Req_Zip() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Req_ZipColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Req_ZipColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Req_ZipSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Req_ZipColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Req_ZipDefault() As String
        Get
            Return TableUtils.Req_ZipColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Req_Dt field.
	''' </summary>
	Public Property Req_Dt() As DateTime
		Get 
			Return CType(Me.GetValue(TableUtils.Req_DtColumn).ToDateTime(), DateTime)
		End Get
		Set (ByVal val As DateTime) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.Req_DtColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Req_DtSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Req_DtColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Req_DtDefault() As String
        Get
            Return TableUtils.Req_DtColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Req_Target_Dt field.
	''' </summary>
	Public Property Req_Target_Dt() As DateTime
		Get 
			Return CType(Me.GetValue(TableUtils.Req_Target_DtColumn).ToDateTime(), DateTime)
		End Get
		Set (ByVal val As DateTime) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.Req_Target_DtColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Req_Target_DtSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Req_Target_DtColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Req_Target_DtDefault() As String
        Get
            Return TableUtils.Req_Target_DtColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Req_Completed_Dt field.
	''' </summary>
	Public Property Req_Completed_Dt() As DateTime
		Get 
			Return CType(Me.GetValue(TableUtils.Req_Completed_DtColumn).ToDateTime(), DateTime)
		End Get
		Set (ByVal val As DateTime) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.Req_Completed_DtColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Req_Completed_DtSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Req_Completed_DtColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Req_Completed_DtDefault() As String
        Get
            Return TableUtils.Req_Completed_DtColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Req_Status field.
	''' </summary>
	Public Property Req_Status() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Req_StatusColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Req_StatusColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Req_StatusSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Req_StatusColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Req_StatusDefault() As String
        Get
            Return TableUtils.Req_StatusColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Req_Funding_Src field.
	''' </summary>
	Public Property Req_Funding_Src() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Req_Funding_SrcColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Req_Funding_SrcColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Req_Funding_SrcSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Req_Funding_SrcColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Req_Funding_SrcDefault() As String
        Get
            Return TableUtils.Req_Funding_SrcColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Req_Enity field.
	''' </summary>
	Public Property Req_Enity() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Req_EnityColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Req_EnityColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Req_EnitySpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Req_EnityColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Req_EnityDefault() As String
        Get
            Return TableUtils.Req_EnityColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Req_Comments field.
	''' </summary>
	Public Property Req_Comments() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Req_CommentsColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Req_CommentsColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Req_CommentsSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Req_CommentsColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Req_CommentsDefault() As String
        Get
            Return TableUtils.Req_CommentsColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Req_Quote_Respnse field.
	''' </summary>
	Public Property Req_Quote_Respnse() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Req_Quote_RespnseColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Req_Quote_RespnseColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Req_Quote_RespnseSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Req_Quote_RespnseColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Req_Quote_RespnseDefault() As String
        Get
            Return TableUtils.Req_Quote_RespnseColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Req_Quote_Approved field.
	''' </summary>
	Public Property Req_Quote_Approved() As DateTime
		Get 
			Return CType(Me.GetValue(TableUtils.Req_Quote_ApprovedColumn).ToDateTime(), DateTime)
		End Get
		Set (ByVal val As DateTime) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.Req_Quote_ApprovedColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Req_Quote_ApprovedSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Req_Quote_ApprovedColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Req_Quote_ApprovedDefault() As String
        Get
            Return TableUtils.Req_Quote_ApprovedColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.ICS_SOW_Needed field.
	''' </summary>
	Public Property ICS_SOW_Needed() As Boolean
		Get 
			Return CType(Me.GetValue(TableUtils.ICS_SOW_NeededColumn).ToBoolean(), Boolean)
		End Get
		Set (ByVal val As Boolean) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.ICS_SOW_NeededColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property ICS_SOW_NeededSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.ICS_SOW_NeededColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property ICS_SOW_NeededDefault() As String
        Get
            Return TableUtils.ICS_SOW_NeededColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.ICS_SOW_Uploaded field.
	''' </summary>
	Public Property ICS_SOW_Uploaded() As Boolean
		Get 
			Return CType(Me.GetValue(TableUtils.ICS_SOW_UploadedColumn).ToBoolean(), Boolean)
		End Get
		Set (ByVal val As Boolean) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.ICS_SOW_UploadedColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property ICS_SOW_UploadedSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.ICS_SOW_UploadedColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property ICS_SOW_UploadedDefault() As String
        Get
            Return TableUtils.ICS_SOW_UploadedColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.ICS_CATV_Comments field.
	''' </summary>
	Public Property ICS_CATV_Comments() As String
		Get 
			Return CType(Me.GetValue(TableUtils.ICS_CATV_CommentsColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.ICS_CATV_CommentsColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property ICS_CATV_CommentsSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.ICS_CATV_CommentsColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property ICS_CATV_CommentsDefault() As String
        Get
            Return TableUtils.ICS_CATV_CommentsColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Cat_Cost_Free field.
	''' </summary>
	Public Property Cat_Cost_Free() As Boolean
		Get 
			Return CType(Me.GetValue(TableUtils.Cat_Cost_FreeColumn).ToBoolean(), Boolean)
		End Get
		Set (ByVal val As Boolean) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.Cat_Cost_FreeColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Cat_Cost_FreeSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Cat_Cost_FreeColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Cat_Cost_FreeDefault() As String
        Get
            Return TableUtils.Cat_Cost_FreeColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Cat_Franchise_Order_Number field.
	''' </summary>
	Public Property Cat_Franchise_Order_Number() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Cat_Franchise_Order_NumberColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Cat_Franchise_Order_NumberColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Cat_Franchise_Order_NumberSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Cat_Franchise_Order_NumberColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Cat_Franchise_Order_NumberDefault() As String
        Get
            Return TableUtils.Cat_Franchise_Order_NumberColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.County_Upload field.
	''' </summary>
	Public Property County_Upload() As Boolean
		Get 
			Return CType(Me.GetValue(TableUtils.County_UploadColumn).ToBoolean(), Boolean)
		End Get
		Set (ByVal val As Boolean) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.County_UploadColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property County_UploadSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.County_UploadColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property County_UploadDefault() As String
        Get
            Return TableUtils.County_UploadColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Cat_OTWC_Comments field.
	''' </summary>
	Public Property Cat_OTWC_Comments() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Cat_OTWC_CommentsColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Cat_OTWC_CommentsColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Cat_OTWC_CommentsSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Cat_OTWC_CommentsColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Cat_OTWC_CommentsDefault() As String
        Get
            Return TableUtils.Cat_OTWC_CommentsColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.OTW_Quote field.
	''' </summary>
	Public Property OTW_Quote() As Int32
		Get 
			Return CType(Me.GetValue(TableUtils.OTW_QuoteColumn).ToInt32(), Int32)
		End Get
		Set (ByVal val As Int32) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.OTW_QuoteColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property OTW_QuoteSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.OTW_QuoteColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property OTW_QuoteDefault() As String
        Get
            Return TableUtils.OTW_QuoteColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.OTW_More_Info_Flag field.
	''' </summary>
	Public Property OTW_More_Info_Flag() As Boolean
		Get 
			Return CType(Me.GetValue(TableUtils.OTW_More_Info_FlagColumn).ToBoolean(), Boolean)
		End Get
		Set (ByVal val As Boolean) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.OTW_More_Info_FlagColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property OTW_More_Info_FlagSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.OTW_More_Info_FlagColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property OTW_More_Info_FlagDefault() As String
        Get
            Return TableUtils.OTW_More_Info_FlagColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.OTW_More_Info_Comments field.
	''' </summary>
	Public Property OTW_More_Info_Comments() As String
		Get 
			Return CType(Me.GetValue(TableUtils.OTW_More_Info_CommentsColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.OTW_More_Info_CommentsColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property OTW_More_Info_CommentsSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.OTW_More_Info_CommentsColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property OTW_More_Info_CommentsDefault() As String
        Get
            Return TableUtils.OTW_More_Info_CommentsColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.OTW_Permit_Status field.
	''' </summary>
	Public Property OTW_Permit_Status() As String
		Get 
			Return CType(Me.GetValue(TableUtils.OTW_Permit_StatusColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.OTW_Permit_StatusColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property OTW_Permit_StatusSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.OTW_Permit_StatusColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property OTW_Permit_StatusDefault() As String
        Get
            Return TableUtils.OTW_Permit_StatusColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.OTW_Premise Fiber Work Reqd field.
	''' </summary>
	Public Property OTW_Premise_Fiber_Work_Reqd() As Boolean
		Get 
			Return CType(Me.GetValue(TableUtils.OTW_Premise_Fiber_Work_ReqdColumn).ToBoolean(), Boolean)
		End Get
		Set (ByVal val As Boolean) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.OTW_Premise_Fiber_Work_ReqdColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property OTW_Premise_Fiber_Work_ReqdSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.OTW_Premise_Fiber_Work_ReqdColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property OTW_Premise_Fiber_Work_ReqdDefault() As String
        Get
            Return TableUtils.OTW_Premise_Fiber_Work_ReqdColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.OTW_On-Net field.
	''' </summary>
	Public Property OTW_On_Net() As Boolean
		Get 
			Return CType(Me.GetValue(TableUtils.OTW_On_NetColumn).ToBoolean(), Boolean)
		End Get
		Set (ByVal val As Boolean) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.OTW_On_NetColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property OTW_On_NetSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.OTW_On_NetColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property OTW_On_NetDefault() As String
        Get
            Return TableUtils.OTW_On_NetColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.OTW_Scheduled_Deploy_Dt field.
	''' </summary>
	Public Property OTW_Scheduled_Deploy_Dt() As DateTime
		Get 
			Return CType(Me.GetValue(TableUtils.OTW_Scheduled_Deploy_DtColumn).ToDateTime(), DateTime)
		End Get
		Set (ByVal val As DateTime) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.OTW_Scheduled_Deploy_DtColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property OTW_Scheduled_Deploy_DtSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.OTW_Scheduled_Deploy_DtColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property OTW_Scheduled_Deploy_DtDefault() As String
        Get
            Return TableUtils.OTW_Scheduled_Deploy_DtColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.OTW_Projected_Deploy_Dt field.
	''' </summary>
	Public Property OTW_Projected_Deploy_Dt() As DateTime
		Get 
			Return CType(Me.GetValue(TableUtils.OTW_Projected_Deploy_DtColumn).ToDateTime(), DateTime)
		End Get
		Set (ByVal val As DateTime) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.OTW_Projected_Deploy_DtColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property OTW_Projected_Deploy_DtSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.OTW_Projected_Deploy_DtColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property OTW_Projected_Deploy_DtDefault() As String
        Get
            Return TableUtils.OTW_Projected_Deploy_DtColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.OTW_Deployment_Start_Dt field.
	''' </summary>
	Public Property OTW_Deployment_Start_Dt() As DateTime
		Get 
			Return CType(Me.GetValue(TableUtils.OTW_Deployment_Start_DtColumn).ToDateTime(), DateTime)
		End Get
		Set (ByVal val As DateTime) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.OTW_Deployment_Start_DtColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property OTW_Deployment_Start_DtSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.OTW_Deployment_Start_DtColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property OTW_Deployment_Start_DtDefault() As String
        Get
            Return TableUtils.OTW_Deployment_Start_DtColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.OTW_Construction_Status field.
	''' </summary>
	Public Property OTW_Construction_Status() As String
		Get 
			Return CType(Me.GetValue(TableUtils.OTW_Construction_StatusColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.OTW_Construction_StatusColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property OTW_Construction_StatusSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.OTW_Construction_StatusColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property OTW_Construction_StatusDefault() As String
        Get
            Return TableUtils.OTW_Construction_StatusColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.OTW_Island completed field.
	''' </summary>
	Public Property OTW_Island_completed() As String
		Get 
			Return CType(Me.GetValue(TableUtils.OTW_Island_completedColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.OTW_Island_completedColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property OTW_Island_completedSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.OTW_Island_completedColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property OTW_Island_completedDefault() As String
        Get
            Return TableUtils.OTW_Island_completedColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.OTW_Completed_Dt field.
	''' </summary>
	Public Property OTW_Completed_Dt() As DateTime
		Get 
			Return CType(Me.GetValue(TableUtils.OTW_Completed_DtColumn).ToDateTime(), DateTime)
		End Get
		Set (ByVal val As DateTime) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.OTW_Completed_DtColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property OTW_Completed_DtSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.OTW_Completed_DtColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property OTW_Completed_DtDefault() As String
        Get
            Return TableUtils.OTW_Completed_DtColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Pending_Agency field.
	''' </summary>
	Public Property Pending_Agency() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Pending_AgencyColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Pending_AgencyColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Pending_AgencySpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Pending_AgencyColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Pending_AgencyDefault() As String
        Get
            Return TableUtils.Pending_AgencyColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Pending Action_Dt field.
	''' </summary>
	Public Property Pending_Action_Dt() As DateTime
		Get 
			Return CType(Me.GetValue(TableUtils.Pending_Action_DtColumn).ToDateTime(), DateTime)
		End Get
		Set (ByVal val As DateTime) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.Pending_Action_DtColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Pending_Action_DtSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Pending_Action_DtColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Pending_Action_DtDefault() As String
        Get
            Return TableUtils.Pending_Action_DtColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Pending_Action_Needed field.
	''' </summary>
	Public Property Pending_Action_Needed() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Pending_Action_NeededColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Pending_Action_NeededColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Pending_Action_NeededSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Pending_Action_NeededColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Pending_Action_NeededDefault() As String
        Get
            Return TableUtils.Pending_Action_NeededColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Pending_Interval_Days_1st field.
	''' </summary>
	Public Property Pending_Interval_Days_1st() As Int16
		Get 
			Return CType(Me.GetValue(TableUtils.Pending_Interval_Days_1stColumn).ToInt16(), Int16)
		End Get
		Set (ByVal val As Int16) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.Pending_Interval_Days_1stColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Pending_Interval_Days_1stSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Pending_Interval_Days_1stColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Pending_Interval_Days_1stDefault() As String
        Get
            Return TableUtils.Pending_Interval_Days_1stColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Pending_Interval_Days_2nd field.
	''' </summary>
	Public Property Pending_Interval_Days_2nd() As Int16
		Get 
			Return CType(Me.GetValue(TableUtils.Pending_Interval_Days_2ndColumn).ToInt16(), Int16)
		End Get
		Set (ByVal val As Int16) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.Pending_Interval_Days_2ndColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Pending_Interval_Days_2ndSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Pending_Interval_Days_2ndColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Pending_Interval_Days_2ndDefault() As String
        Get
            Return TableUtils.Pending_Interval_Days_2ndColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Pending_Nterval_Days_Max field.
	''' </summary>
	Public Property Pending_Nterval_Days_Max() As Int16
		Get 
			Return CType(Me.GetValue(TableUtils.Pending_Nterval_Days_MaxColumn).ToInt16(), Int16)
		End Get
		Set (ByVal val As Int16) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.Pending_Nterval_Days_MaxColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Pending_Nterval_Days_MaxSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Pending_Nterval_Days_MaxColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Pending_Nterval_Days_MaxDefault() As String
        Get
            Return TableUtils.Pending_Nterval_Days_MaxColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Pending_Interval_Days_Cancel field.
	''' </summary>
	Public Property Pending_Interval_Days_Cancel() As Int16
		Get 
			Return CType(Me.GetValue(TableUtils.Pending_Interval_Days_CancelColumn).ToInt16(), Int16)
		End Get
		Set (ByVal val As Int16) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.Pending_Interval_Days_CancelColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Pending_Interval_Days_CancelSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Pending_Interval_Days_CancelColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Pending_Interval_Days_CancelDefault() As String
        Get
            Return TableUtils.Pending_Interval_Days_CancelColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Pending_Interval_Days_Auto_Cancel field.
	''' </summary>
	Public Property Pending_Interval_Days_Auto_Cancel() As Int16
		Get 
			Return CType(Me.GetValue(TableUtils.Pending_Interval_Days_Auto_CancelColumn).ToInt16(), Int16)
		End Get
		Set (ByVal val As Int16) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.Pending_Interval_Days_Auto_CancelColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Pending_Interval_Days_Auto_CancelSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Pending_Interval_Days_Auto_CancelColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Pending_Interval_Days_Auto_CancelDefault() As String
        Get
            Return TableUtils.Pending_Interval_Days_Auto_CancelColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Req_PO_No field.
	''' </summary>
	Public Property Req_PO_No() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Req_PO_NoColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Req_PO_NoColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Req_PO_NoSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Req_PO_NoColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Req_PO_NoDefault() As String
        Get
            Return TableUtils.Req_PO_NoColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Req_PO_Dt field.
	''' </summary>
	Public Property Req_PO_Dt() As DateTime
		Get 
			Return CType(Me.GetValue(TableUtils.Req_PO_DtColumn).ToDateTime(), DateTime)
		End Get
		Set (ByVal val As DateTime) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.Req_PO_DtColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Req_PO_DtSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Req_PO_DtColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Req_PO_DtDefault() As String
        Get
            Return TableUtils.Req_PO_DtColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Req_PO_Amt field.
	''' </summary>
	Public Property Req_PO_Amt() As Decimal
		Get 
			Return CType(Me.GetValue(TableUtils.Req_PO_AmtColumn).ToDecimal(), Decimal)
		End Get
		Set (ByVal val As Decimal) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.Req_PO_AmtColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Req_PO_AmtSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Req_PO_AmtColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Req_PO_AmtDefault() As String
        Get
            Return TableUtils.Req_PO_AmtColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Req_Invoice_Paid field.
	''' </summary>
	Public Property Req_Invoice_Paid() As Boolean
		Get 
			Return CType(Me.GetValue(TableUtils.Req_Invoice_PaidColumn).ToBoolean(), Boolean)
		End Get
		Set (ByVal val As Boolean) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.Req_Invoice_PaidColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Req_Invoice_PaidSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Req_Invoice_PaidColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Req_Invoice_PaidDefault() As String
        Get
            Return TableUtils.Req_Invoice_PaidColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Req_Pymt_Check_No field.
	''' </summary>
	Public Property Req_Pymt_Check_No() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Req_Pymt_Check_NoColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Req_Pymt_Check_NoColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Req_Pymt_Check_NoSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Req_Pymt_Check_NoColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Req_Pymt_Check_NoDefault() As String
        Get
            Return TableUtils.Req_Pymt_Check_NoColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Req_Pymt_Dt field.
	''' </summary>
	Public Property Req_Pymt_Dt() As DateTime
		Get 
			Return CType(Me.GetValue(TableUtils.Req_Pymt_DtColumn).ToDateTime(), DateTime)
		End Get
		Set (ByVal val As DateTime) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.Req_Pymt_DtColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Req_Pymt_DtSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Req_Pymt_DtColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Req_Pymt_DtDefault() As String
        Get
            Return TableUtils.Req_Pymt_DtColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Req_Pymt_Amt field.
	''' </summary>
	Public Property Req_Pymt_Amt() As Decimal
		Get 
			Return CType(Me.GetValue(TableUtils.Req_Pymt_AmtColumn).ToDecimal(), Decimal)
		End Get
		Set (ByVal val As Decimal) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.Req_Pymt_AmtColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Req_Pymt_AmtSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Req_Pymt_AmtColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Req_Pymt_AmtDefault() As String
        Get
            Return TableUtils.Req_Pymt_AmtColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.OTW_Invoice_No field.
	''' </summary>
	Public Property OTW_Invoice_No() As String
		Get 
			Return CType(Me.GetValue(TableUtils.OTW_Invoice_NoColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.OTW_Invoice_NoColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property OTW_Invoice_NoSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.OTW_Invoice_NoColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property OTW_Invoice_NoDefault() As String
        Get
            Return TableUtils.OTW_Invoice_NoColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.OTW_Invoice_Dt field.
	''' </summary>
	Public Property OTW_Invoice_Dt() As DateTime
		Get 
			Return CType(Me.GetValue(TableUtils.OTW_Invoice_DtColumn).ToDateTime(), DateTime)
		End Get
		Set (ByVal val As DateTime) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.OTW_Invoice_DtColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property OTW_Invoice_DtSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.OTW_Invoice_DtColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property OTW_Invoice_DtDefault() As String
        Get
            Return TableUtils.OTW_Invoice_DtColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.OTW_Invoice_Amt field.
	''' </summary>
	Public Property OTW_Invoice_Amt() As Decimal
		Get 
			Return CType(Me.GetValue(TableUtils.OTW_Invoice_AmtColumn).ToDecimal(), Decimal)
		End Get
		Set (ByVal val As Decimal) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.OTW_Invoice_AmtColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property OTW_Invoice_AmtSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.OTW_Invoice_AmtColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property OTW_Invoice_AmtDefault() As String
        Get
            Return TableUtils.OTW_Invoice_AmtColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Reg_Type field.
	''' </summary>
	Public Property Reg_Type() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Reg_TypeColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Reg_TypeColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Reg_TypeSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Reg_TypeColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Reg_TypeDefault() As String
        Get
            Return TableUtils.Reg_TypeColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Req_Contact_Email field.
	''' </summary>
	Public Property Req_Contact_Email() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Req_Contact_EmailColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Req_Contact_EmailColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Req_Contact_EmailSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Req_Contact_EmailColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Req_Contact_EmailDefault() As String
        Get
            Return TableUtils.Req_Contact_EmailColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Req_Enity2 field.
	''' </summary>
	Public Property Req_Enity2() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Req_Enity2Column).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Req_Enity2Column)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Req_Enity2Specified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Req_Enity2Column)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Req_Enity2Default() As String
        Get
            Return TableUtils.Req_Enity2Column.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Req_Funding_Src2 field.
	''' </summary>
	Public Property Req_Funding_Src2() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Req_Funding_Src2Column).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Req_Funding_Src2Column)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Req_Funding_Src2Specified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Req_Funding_Src2Column)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Req_Funding_Src2Default() As String
        Get
            Return TableUtils.Req_Funding_Src2Column.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Pending_Agency_Return field.
	''' </summary>
	Public Property Pending_Agency_Return() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Pending_Agency_ReturnColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Pending_Agency_ReturnColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Pending_Agency_ReturnSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Pending_Agency_ReturnColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Pending_Agency_ReturnDefault() As String
        Get
            Return TableUtils.Pending_Agency_ReturnColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Pending_Prev_Action_Needed field.
	''' </summary>
	Public Property Pending_Prev_Action_Needed() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Pending_Prev_Action_NeededColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Pending_Prev_Action_NeededColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Pending_Prev_Action_NeededSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Pending_Prev_Action_NeededColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Pending_Prev_Action_NeededDefault() As String
        Get
            Return TableUtils.Pending_Prev_Action_NeededColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Pending_Prev_Status field.
	''' </summary>
	Public Property Pending_Prev_Status() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Pending_Prev_StatusColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Pending_Prev_StatusColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Pending_Prev_StatusSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Pending_Prev_StatusColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Pending_Prev_StatusDefault() As String
        Get
            Return TableUtils.Pending_Prev_StatusColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Prov_Name field.
	''' </summary>
	Public Property Prov_Name() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Prov_NameColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Prov_NameColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Prov_NameSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Prov_NameColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Prov_NameDefault() As String
        Get
            Return TableUtils.Prov_NameColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Cat_Franchise_Order_Number2 field.
	''' </summary>
	Public Property Cat_Franchise_Order_Number2() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Cat_Franchise_Order_Number2Column).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Cat_Franchise_Order_Number2Column)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Cat_Franchise_Order_Number2Specified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Cat_Franchise_Order_Number2Column)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Cat_Franchise_Order_Number2Default() As String
        Get
            Return TableUtils.Cat_Franchise_Order_Number2Column.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.OTW_On_Net_Dt field.
	''' </summary>
	Public Property OTW_On_Net_Dt() As DateTime
		Get 
			Return CType(Me.GetValue(TableUtils.OTW_On_Net_DtColumn).ToDateTime(), DateTime)
		End Get
		Set (ByVal val As DateTime) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.OTW_On_Net_DtColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property OTW_On_Net_DtSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.OTW_On_Net_DtColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property OTW_On_Net_DtDefault() As String
        Get
            Return TableUtils.OTW_On_Net_DtColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Request_Master_.Req_Contact_Email2 field.
	''' </summary>
	Public Property Req_Contact_Email2() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Req_Contact_Email2Column).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Req_Contact_Email2Column)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Req_Contact_Email2Specified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Req_Contact_Email2Column)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Req_Contact_Email2Default() As String
        Get
            Return TableUtils.Req_Contact_Email2Column.DefaultValue
        End Get
    End Property



#End Region

End Class
End Namespace
