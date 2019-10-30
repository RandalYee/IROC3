' This class is "generated" and will be overwritten.
' Your customizations should be made in UsersRecord.vb

Imports System.Data.SqlTypes
Imports BaseClasses
Imports BaseClasses.Data
Imports BaseClasses.Data.SqlProvider

Namespace IROC2.Business

''' <summary>
''' The generated superclass for the <see cref="UsersRecord"></see> class.
''' </summary>
''' <remarks>
''' This class is not intended to be instantiated directly.  To obtain an instance of this class, 
''' use the methods of the <see cref="UsersTable"></see> class.
''' </remarks>
''' <seealso cref="UsersTable"></seealso>
''' <seealso cref="UsersRecord"></seealso>

<Serializable()> Public Class BaseUsersRecord
	Inherits PrimaryKeyRecord
	Implements IUserIdentityRecord


	Public Shared Shadows ReadOnly TableUtils As UsersTable = UsersTable.Instance

	' Constructors
 
	Protected Sub New()
		MyBase.New(TableUtils)
	End Sub

	Protected Sub New(ByVal record As PrimaryKeyRecord)
		MyBase.New(record, TableUtils)
	End Sub
	
	'Evaluates Initialize when->Inserting record formulas specified at the data access layer
    Public Overridable Sub UsersRecord_InsertingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.InsertingRecord
        'Apply Initialize->Inserting record formula only if validation is successful.
        	        Dim UsersRec As UsersRecord = CType(sender,UsersRecord)
        Validate_Inserting()
        If Not UsersRec Is Nothing AndAlso Not UsersRec.IsReadOnly Then
                End If
    End Sub

	'Evaluates Initialize when->Updating record formulas specified at the data access layer
    Public Overridable Sub UsersRecord_UpdatingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.UpdatingRecord
        'Apply Initialize->Updating record formula only if validation is successful.
        	        Dim UsersRec As UsersRecord = CType(sender,UsersRecord)
        Validate_Updating()
        If Not UsersRec Is Nothing AndAlso Not UsersRec.IsReadOnly Then
                End If
    End Sub
    
    'Evaluates Initialize when->Reading record formulas specified at the data access layer
    Public Overridable Sub UsersRecord_ReadRecord(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReadRecord
        'Apply Initialize->Reading record formula only if validation is successful.
        	        Dim UsersRec As UsersRecord = CType(sender,UsersRecord)
        If Not UsersRec Is Nothing AndAlso Not UsersRec.IsReadOnly Then
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


#Region "IUserIdentityRecord Members"

	' Get the user's name
	Public Function GetUserName() As String Implements IUserIdentityRecord.GetUserName
		Return CType(Me, IRecord).getString(CType(Me.TableAccess, IUserIdentityTable).UserNameColumn)
	End Function

	' Get the user's password
	Public Function GetUserPassword() As String Implements IUserIdentityRecord.GetUserPassword
		Return CType(Me, IRecord).getString(CType(Me.TableAccess, IUserIdentityTable).UserPasswordColumn)
	End Function

	' Get the user's email address
	Public Function GetUserEmail() As String Implements IUserIdentityRecord.GetUserEmail
		Return CType(Me, IRecord).getString(CType(Me.TableAccess, IUserIdentityTable).UserEmailColumn)
	End Function

	' Get a list of roles to which the user belongs
	Public Function GetUserRoles() As String() Implements IUserIdentityRecord.GetUserRoles
		Dim roles() As String
		If (TypeOf (Me) Is IUserRoleRecord) Then
			roles = New String(0) {}
			roles(0) = CType(Me, IUserRoleRecord).GetUserRole()
		Else
			Dim roleTable As IUserRoleTable = CType(Me.TableAccess, IUserIdentityTable).GetUserRoleTable()
			If (IsNothing(roleTable)) Then
				Return Nothing
#If False Then
			'Note: Not compiled for performance
			ElseIf (CType(roleTable, Object).Equals(Me.TableAccess)) Then
				'This should never occur because it should be handled above instead
#End If
			Else
				Dim filter As ColumnValueFilter = BaseFilter.CreateUserIdFilter(roleTable, Me.GetUserId())
				Dim order As New OrderBy(False, False)
				Dim join As BaseClasses.Data.BaseFilter = Nothing
				Dim roleRecords As ArrayList = roleTable.GetRecordList(join, filter, Nothing, order, BaseTable.MIN_PAGE_NUMBER, BaseTable.MAX_BATCH_SIZE)
				Dim roleRecord As IUserRoleRecord
				Dim roleList As New ArrayList(roleRecords.Count)
				For Each roleRecord In roleRecords
					roleList.Add(roleRecord.GetUserRole())
				Next
				roles = CType(roleList.ToArray(GetType(String)), String())
			End If
		End If
		Return roles
	End Function

#End Region




#Region "Convenience methods to get/set values of fields"

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Users_.User_ID field.
	''' </summary>
	Public Function GetUser_IDValue() As ColumnValue
		Return Me.GetValue(TableUtils.User_IDColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Users_.User_ID field.
	''' </summary>
	Public Function GetUser_IDFieldValue() As Int32
		Return CType(Me.GetValue(TableUtils.User_IDColumn).ToInt32(), Int32)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Users_.User_Name field.
	''' </summary>
	Public Function GetUser_NameValue() As ColumnValue
		Return Me.GetValue(TableUtils.User_NameColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Users_.User_Name field.
	''' </summary>
	Public Function GetUser_NameFieldValue() As String
		Return CType(Me.GetValue(TableUtils.User_NameColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Users_.User_Name field.
	''' </summary>
	Public Sub SetUser_NameFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.User_NameColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Users_.User_Name field.
	''' </summary>
	Public Sub SetUser_NameFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.User_NameColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Users_.Password field.
	''' </summary>
	Public Function GetPasswordValue() As ColumnValue
		Return Me.GetValue(TableUtils.PasswordColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Users_.Password field.
	''' </summary>
	Public Function GetPasswordFieldValue() As String
		Return CType(Me.GetValue(TableUtils.PasswordColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Users_.Password field.
	''' </summary>
	Public Sub SetPasswordFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.PasswordColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Users_.Password field.
	''' </summary>
	Public Sub SetPasswordFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.PasswordColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Users_.Email field.
	''' </summary>
	Public Function GetEmailValue() As ColumnValue
		Return Me.GetValue(TableUtils.EmailColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Users_.Email field.
	''' </summary>
	Public Function GetEmailFieldValue() As String
		Return CType(Me.GetValue(TableUtils.EmailColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Users_.Email field.
	''' </summary>
	Public Sub SetEmailFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.EmailColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Users_.Email field.
	''' </summary>
	Public Sub SetEmailFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.EmailColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Users_.IsActive field.
	''' </summary>
	Public Function GetIsActiveValue() As ColumnValue
		Return Me.GetValue(TableUtils.IsActiveColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Users_.IsActive field.
	''' </summary>
	Public Function GetIsActiveFieldValue() As Boolean
		Return CType(Me.GetValue(TableUtils.IsActiveColumn).ToBoolean(), Boolean)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Users_.IsActive field.
	''' </summary>
	Public Sub SetIsActiveFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.IsActiveColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Users_.IsActive field.
	''' </summary>
	Public Sub SetIsActiveFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.IsActiveColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Users_.IsActive field.
	''' </summary>
	Public Sub SetIsActiveFieldValue(ByVal val As Boolean)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.IsActiveColumn)
	End Sub
	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Users_.Agency field.
	''' </summary>
	Public Function GetAgencyValue() As ColumnValue
		Return Me.GetValue(TableUtils.AgencyColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Users_.Agency field.
	''' </summary>
	Public Function GetAgencyFieldValue() As String
		Return CType(Me.GetValue(TableUtils.AgencyColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Users_.Agency field.
	''' </summary>
	Public Sub SetAgencyFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.AgencyColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Users_.Agency field.
	''' </summary>
	Public Sub SetAgencyFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.AgencyColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Users_.Enity field.
	''' </summary>
	Public Function GetEnityValue() As ColumnValue
		Return Me.GetValue(TableUtils.EnityColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Users_.Enity field.
	''' </summary>
	Public Function GetEnityFieldValue() As String
		Return CType(Me.GetValue(TableUtils.EnityColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Users_.Enity field.
	''' </summary>
	Public Sub SetEnityFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.EnityColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Users_.Enity field.
	''' </summary>
	Public Sub SetEnityFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.EnityColumn)
	End Sub



#End Region

#Region "Convenience methods to get field names"

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Users_.User_ID field.
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
	''' This is a convenience property that provides direct access to the value of the record's Users_.User_Name field.
	''' </summary>
	Public Property User_Name() As String
		Get 
			Return CType(Me.GetValue(TableUtils.User_NameColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.User_NameColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property User_NameSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.User_NameColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property User_NameDefault() As String
        Get
            Return TableUtils.User_NameColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Users_.Password field.
	''' </summary>
	Public Property Password() As String
		Get 
			Return CType(Me.GetValue(TableUtils.PasswordColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.PasswordColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property PasswordSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.PasswordColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property PasswordDefault() As String
        Get
            Return TableUtils.PasswordColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Users_.Email field.
	''' </summary>
	Public Property Email() As String
		Get 
			Return CType(Me.GetValue(TableUtils.EmailColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.EmailColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property EmailSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.EmailColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property EmailDefault() As String
        Get
            Return TableUtils.EmailColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Users_.IsActive field.
	''' </summary>
	Public Property IsActive() As Boolean
		Get 
			Return CType(Me.GetValue(TableUtils.IsActiveColumn).ToBoolean(), Boolean)
		End Get
		Set (ByVal val As Boolean) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.IsActiveColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property IsActiveSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.IsActiveColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property IsActiveDefault() As String
        Get
            Return TableUtils.IsActiveColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Users_.Agency field.
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
	''' This is a convenience property that provides direct access to the value of the record's Users_.Enity field.
	''' </summary>
	Public Property Enity() As String
		Get 
			Return CType(Me.GetValue(TableUtils.EnityColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.EnityColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property EnitySpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.EnityColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property EnityDefault() As String
        Get
            Return TableUtils.EnityColumn.DefaultValue
        End Get
    End Property



#End Region

End Class
End Namespace
