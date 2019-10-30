' This class is "generated" and will be overwritten.
' Your customizations should be made in Users_RoleRecord.vb

Imports System.Data.SqlTypes
Imports BaseClasses
Imports BaseClasses.Data
Imports BaseClasses.Data.SqlProvider

Namespace IROC2.Business

''' <summary>
''' The generated superclass for the <see cref="Users_RoleRecord"></see> class.
''' </summary>
''' <remarks>
''' This class is not intended to be instantiated directly.  To obtain an instance of this class, 
''' use the methods of the <see cref="Users_RoleTable"></see> class.
''' </remarks>
''' <seealso cref="Users_RoleTable"></seealso>
''' <seealso cref="Users_RoleRecord"></seealso>

<Serializable()> Public Class BaseUsers_RoleRecord
	Inherits PrimaryKeyRecord
	Implements IUserRoleRecord


	Public Shared Shadows ReadOnly TableUtils As Users_RoleTable = Users_RoleTable.Instance

	' Constructors
 
	Protected Sub New()
		MyBase.New(TableUtils)
	End Sub

	Protected Sub New(ByVal record As PrimaryKeyRecord)
		MyBase.New(record, TableUtils)
	End Sub
	
	'Evaluates Initialize when->Inserting record formulas specified at the data access layer
    Public Overridable Sub Users_RoleRecord_InsertingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.InsertingRecord
        'Apply Initialize->Inserting record formula only if validation is successful.
        	        Dim Users_RoleRec As Users_RoleRecord = CType(sender,Users_RoleRecord)
        Validate_Inserting()
        If Not Users_RoleRec Is Nothing AndAlso Not Users_RoleRec.IsReadOnly Then
                End If
    End Sub

	'Evaluates Initialize when->Updating record formulas specified at the data access layer
    Public Overridable Sub Users_RoleRecord_UpdatingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.UpdatingRecord
        'Apply Initialize->Updating record formula only if validation is successful.
        	        Dim Users_RoleRec As Users_RoleRecord = CType(sender,Users_RoleRecord)
        Validate_Updating()
        If Not Users_RoleRec Is Nothing AndAlso Not Users_RoleRec.IsReadOnly Then
                End If
    End Sub
    
    'Evaluates Initialize when->Reading record formulas specified at the data access layer
    Public Overridable Sub Users_RoleRecord_ReadRecord(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReadRecord
        'Apply Initialize->Reading record formula only if validation is successful.
        	        Dim Users_RoleRec As Users_RoleRecord = CType(sender,Users_RoleRecord)
        If Not Users_RoleRec Is Nothing AndAlso Not Users_RoleRec.IsReadOnly Then
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

#Region "IUserRecord Members"

	' Get the user's unique identifier
	Public Function GetUserId() As String Implements IUserRecord.GetUserId
		Return CType(Me, IRecord).GetString(CType(Me.TableAccess, IUserTable).UserIdColumn)
	End Function

#End Region




#Region "IUserRoleRecord Members"

	' Get the role to which this user belongs
	Public Function GetUserRole() As String Implements IUserRoleRecord.GetUserRole
		Return CType(Me, IRecord).GetString(CType(Me.TableAccess, IUserRoleTable).UserRoleColumn)
	End Function

#End Region


#Region "Convenience methods to get/set values of fields"

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Users_Role_.User_ID field.
	''' </summary>
	Public Function GetUser_IDValue() As ColumnValue
		Return Me.GetValue(TableUtils.User_IDColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Users_Role_.User_ID field.
	''' </summary>
	Public Function GetUser_IDFieldValue() As Int32
		Return CType(Me.GetValue(TableUtils.User_IDColumn).ToInt32(), Int32)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Users_Role_.User_ID field.
	''' </summary>
	Public Sub SetUser_IDFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.User_IDColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Users_Role_.User_ID field.
	''' </summary>
	Public Sub SetUser_IDFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.User_IDColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Users_Role_.User_ID field.
	''' </summary>
	Public Sub SetUser_IDFieldValue(ByVal val As Double)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.User_IDColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Users_Role_.User_ID field.
	''' </summary>
	Public Sub SetUser_IDFieldValue(ByVal val As Decimal)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.User_IDColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Users_Role_.User_ID field.
	''' </summary>
	Public Sub SetUser_IDFieldValue(ByVal val As Int64)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.User_IDColumn)
	End Sub
	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Users_Role_.Role_ID field.
	''' </summary>
	Public Function GetRole_IDValue() As ColumnValue
		Return Me.GetValue(TableUtils.Role_IDColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Users_Role_.Role_ID field.
	''' </summary>
	Public Function GetRole_IDFieldValue() As Int32
		Return CType(Me.GetValue(TableUtils.Role_IDColumn).ToInt32(), Int32)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Users_Role_.Role_ID field.
	''' </summary>
	Public Sub SetRole_IDFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Role_IDColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Users_Role_.Role_ID field.
	''' </summary>
	Public Sub SetRole_IDFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.Role_IDColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Users_Role_.Role_ID field.
	''' </summary>
	Public Sub SetRole_IDFieldValue(ByVal val As Double)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Role_IDColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Users_Role_.Role_ID field.
	''' </summary>
	Public Sub SetRole_IDFieldValue(ByVal val As Decimal)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Role_IDColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Users_Role_.Role_ID field.
	''' </summary>
	Public Sub SetRole_IDFieldValue(ByVal val As Int64)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Role_IDColumn)
	End Sub


#End Region

#Region "Convenience methods to get field names"

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Users_Role_.User_ID field.
	''' </summary>
	Public Property User_ID() As Int32
		Get 
			Return CType(Me.GetValue(TableUtils.User_IDColumn).ToInt32(), Int32)
		End Get
		Set (ByVal val As Int32) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.User_IDColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property User_IDSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.User_IDColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property User_IDDefault() As String
        Get
            Return TableUtils.User_IDColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Users_Role_.Role_ID field.
	''' </summary>
	Public Property Role_ID() As Int32
		Get 
			Return CType(Me.GetValue(TableUtils.Role_IDColumn).ToInt32(), Int32)
		End Get
		Set (ByVal val As Int32) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.Role_IDColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Role_IDSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Role_IDColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Role_IDDefault() As String
        Get
            Return TableUtils.Role_IDColumn.DefaultValue
        End Get
    End Property



#End Region

End Class
End Namespace
