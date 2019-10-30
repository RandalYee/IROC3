' This class is "generated" and will be overwritten.
' Your customizations should be made in ContactsRecord.vb

Imports System.Data.SqlTypes
Imports BaseClasses
Imports BaseClasses.Data
Imports BaseClasses.Data.SqlProvider

Namespace IROC2.Business

''' <summary>
''' The generated superclass for the <see cref="ContactsRecord"></see> class.
''' </summary>
''' <remarks>
''' This class is not intended to be instantiated directly.  To obtain an instance of this class, 
''' use the methods of the <see cref="ContactsTable"></see> class.
''' </remarks>
''' <seealso cref="ContactsTable"></seealso>
''' <seealso cref="ContactsRecord"></seealso>

<Serializable()> Public Class BaseContactsRecord
	Inherits PrimaryKeyRecord
	

	Public Shared Shadows ReadOnly TableUtils As ContactsTable = ContactsTable.Instance

	' Constructors
 
	Protected Sub New()
		MyBase.New(TableUtils)
	End Sub

	Protected Sub New(ByVal record As PrimaryKeyRecord)
		MyBase.New(record, TableUtils)
	End Sub
	
	'Evaluates Initialize when->Inserting record formulas specified at the data access layer
    Public Overridable Sub ContactsRecord_InsertingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.InsertingRecord
        'Apply Initialize->Inserting record formula only if validation is successful.
        	        Dim ContactsRec As ContactsRecord = CType(sender,ContactsRecord)
        Validate_Inserting()
        If Not ContactsRec Is Nothing AndAlso Not ContactsRec.IsReadOnly Then
                End If
    End Sub

	'Evaluates Initialize when->Updating record formulas specified at the data access layer
    Public Overridable Sub ContactsRecord_UpdatingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.UpdatingRecord
        'Apply Initialize->Updating record formula only if validation is successful.
        	        Dim ContactsRec As ContactsRecord = CType(sender,ContactsRecord)
        Validate_Updating()
        If Not ContactsRec Is Nothing AndAlso Not ContactsRec.IsReadOnly Then
                End If
    End Sub
    
    'Evaluates Initialize when->Reading record formulas specified at the data access layer
    Public Overridable Sub ContactsRecord_ReadRecord(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReadRecord
        'Apply Initialize->Reading record formula only if validation is successful.
        	        Dim ContactsRec As ContactsRecord = CType(sender,ContactsRecord)
        If Not ContactsRec Is Nothing AndAlso Not ContactsRec.IsReadOnly Then
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
	''' This is a convenience method that provides direct access to the value of the record's Contacts_.Contact_Id field.
	''' </summary>
	Public Function GetContact_IdValue() As ColumnValue
		Return Me.GetValue(TableUtils.Contact_IdColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Contacts_.Contact_Id field.
	''' </summary>
	Public Function GetContact_IdFieldValue() As Int32
		Return CType(Me.GetValue(TableUtils.Contact_IdColumn).ToInt32(), Int32)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Contacts_.Request_Id field.
	''' </summary>
	Public Function GetRequest_IdValue() As ColumnValue
		Return Me.GetValue(TableUtils.Request_IdColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Contacts_.Request_Id field.
	''' </summary>
	Public Function GetRequest_IdFieldValue() As Int32
		Return CType(Me.GetValue(TableUtils.Request_IdColumn).ToInt32(), Int32)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Contacts_.Request_Id field.
	''' </summary>
	Public Sub SetRequest_IdFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Request_IdColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Contacts_.Request_Id field.
	''' </summary>
	Public Sub SetRequest_IdFieldValue(ByVal val As String)
		Me.SetString(val, TableUtils.Request_IdColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Contacts_.Request_Id field.
	''' </summary>
	Public Sub SetRequest_IdFieldValue(ByVal val As Double)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Request_IdColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Contacts_.Request_Id field.
	''' </summary>
	Public Sub SetRequest_IdFieldValue(ByVal val As Decimal)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Request_IdColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Contacts_.Request_Id field.
	''' </summary>
	Public Sub SetRequest_IdFieldValue(ByVal val As Int64)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Request_IdColumn)
	End Sub
	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Contacts_.Type field.
	''' </summary>
	Public Function GetType0Value() As ColumnValue
		Return Me.GetValue(TableUtils.Type0Column)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Contacts_.Type field.
	''' </summary>
	Public Function GetType0FieldValue() As String
		Return CType(Me.GetValue(TableUtils.Type0Column).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Contacts_.Type field.
	''' </summary>
	Public Sub SetType0FieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Type0Column)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Contacts_.Type field.
	''' </summary>
	Public Sub SetType0FieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Type0Column)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Contacts_.Agency field.
	''' </summary>
	Public Function GetAgencyValue() As ColumnValue
		Return Me.GetValue(TableUtils.AgencyColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Contacts_.Agency field.
	''' </summary>
	Public Function GetAgencyFieldValue() As String
		Return CType(Me.GetValue(TableUtils.AgencyColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Contacts_.Agency field.
	''' </summary>
	Public Sub SetAgencyFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.AgencyColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Contacts_.Agency field.
	''' </summary>
	Public Sub SetAgencyFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.AgencyColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Contacts_.Title field.
	''' </summary>
	Public Function GetTitleValue() As ColumnValue
		Return Me.GetValue(TableUtils.TitleColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Contacts_.Title field.
	''' </summary>
	Public Function GetTitleFieldValue() As String
		Return CType(Me.GetValue(TableUtils.TitleColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Contacts_.Title field.
	''' </summary>
	Public Sub SetTitleFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.TitleColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Contacts_.Title field.
	''' </summary>
	Public Sub SetTitleFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.TitleColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Contacts_.Name field.
	''' </summary>
	Public Function GetNameValue() As ColumnValue
		Return Me.GetValue(TableUtils.NameColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Contacts_.Name field.
	''' </summary>
	Public Function GetNameFieldValue() As String
		Return CType(Me.GetValue(TableUtils.NameColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Contacts_.Name field.
	''' </summary>
	Public Sub SetNameFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.NameColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Contacts_.Name field.
	''' </summary>
	Public Sub SetNameFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.NameColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Contacts_.Email field.
	''' </summary>
	Public Function GetEmailValue() As ColumnValue
		Return Me.GetValue(TableUtils.EmailColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Contacts_.Email field.
	''' </summary>
	Public Function GetEmailFieldValue() As String
		Return CType(Me.GetValue(TableUtils.EmailColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Contacts_.Email field.
	''' </summary>
	Public Sub SetEmailFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.EmailColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Contacts_.Email field.
	''' </summary>
	Public Sub SetEmailFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.EmailColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Contacts_.Address field.
	''' </summary>
	Public Function GetAddressValue() As ColumnValue
		Return Me.GetValue(TableUtils.AddressColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Contacts_.Address field.
	''' </summary>
	Public Function GetAddressFieldValue() As String
		Return CType(Me.GetValue(TableUtils.AddressColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Contacts_.Address field.
	''' </summary>
	Public Sub SetAddressFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.AddressColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Contacts_.Address field.
	''' </summary>
	Public Sub SetAddressFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.AddressColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Contacts_.City field.
	''' </summary>
	Public Function GetCityValue() As ColumnValue
		Return Me.GetValue(TableUtils.CityColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Contacts_.City field.
	''' </summary>
	Public Function GetCityFieldValue() As String
		Return CType(Me.GetValue(TableUtils.CityColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Contacts_.City field.
	''' </summary>
	Public Sub SetCityFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.CityColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Contacts_.City field.
	''' </summary>
	Public Sub SetCityFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.CityColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Contacts_.Zip field.
	''' </summary>
	Public Function GetZipValue() As ColumnValue
		Return Me.GetValue(TableUtils.ZipColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Contacts_.Zip field.
	''' </summary>
	Public Function GetZipFieldValue() As String
		Return CType(Me.GetValue(TableUtils.ZipColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Contacts_.Zip field.
	''' </summary>
	Public Sub SetZipFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.ZipColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Contacts_.Zip field.
	''' </summary>
	Public Sub SetZipFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.ZipColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Contacts_.Work Phone field.
	''' </summary>
	Public Function GetWork_PhoneValue() As ColumnValue
		Return Me.GetValue(TableUtils.Work_PhoneColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Contacts_.Work Phone field.
	''' </summary>
	Public Function GetWork_PhoneFieldValue() As String
		Return CType(Me.GetValue(TableUtils.Work_PhoneColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Contacts_.Work Phone field.
	''' </summary>
	Public Sub SetWork_PhoneFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.Work_PhoneColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Contacts_.Work Phone field.
	''' </summary>
	Public Sub SetWork_PhoneFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.Work_PhoneColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Contacts_.Mobile field.
	''' </summary>
	Public Function GetMobileValue() As ColumnValue
		Return Me.GetValue(TableUtils.MobileColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Contacts_.Mobile field.
	''' </summary>
	Public Function GetMobileFieldValue() As String
		Return CType(Me.GetValue(TableUtils.MobileColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Contacts_.Mobile field.
	''' </summary>
	Public Sub SetMobileFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.MobileColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Contacts_.Mobile field.
	''' </summary>
	Public Sub SetMobileFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.MobileColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Contacts_.Comments field.
	''' </summary>
	Public Function GetCommentsValue() As ColumnValue
		Return Me.GetValue(TableUtils.CommentsColumn)
	End Function

	''' <summary>
	''' This is a convenience method that provides direct access to the value of the record's Contacts_.Comments field.
	''' </summary>
	Public Function GetCommentsFieldValue() As String
		Return CType(Me.GetValue(TableUtils.CommentsColumn).ToString(), String)
	End Function

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Contacts_.Comments field.
	''' </summary>
	Public Sub SetCommentsFieldValue(ByVal val As ColumnValue)
		Me.SetValue(val, TableUtils.CommentsColumn)
	End Sub

	''' <summary>
	''' This is a convenience method that allows direct modification of the value of the record's Contacts_.Comments field.
	''' </summary>
	Public Sub SetCommentsFieldValue(ByVal val As String)
		Dim colValue As ColumnValue = New ColumnValue(val)
		Me.SetValue(colValue, TableUtils.CommentsColumn)
	End Sub



#End Region

#Region "Convenience methods to get field names"

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Contacts_.Contact_Id field.
	''' </summary>
	Public Property Contact_Id() As Int32
		Get 
			Return CType(Me.GetValue(TableUtils.Contact_IdColumn).ToInt32(), Int32)
		End Get
		Set (ByVal val As Int32) 
			Dim colValue As ColumnValue = New ColumnValue(val)
			Me.SetValue(colValue, TableUtils.Contact_IdColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Contact_IdSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Contact_IdColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Contact_IdDefault() As String
        Get
            Return TableUtils.Contact_IdColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Contacts_.Request_Id field.
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
	''' This is a convenience property that provides direct access to the value of the record's Contacts_.Type field.
	''' </summary>
	Public Property Type0() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Type0Column).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Type0Column)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Type0Specified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Type0Column)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Type0Default() As String
        Get
            Return TableUtils.Type0Column.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Contacts_.Agency field.
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
	''' This is a convenience property that provides direct access to the value of the record's Contacts_.Title field.
	''' </summary>
	Public Property Title() As String
		Get 
			Return CType(Me.GetValue(TableUtils.TitleColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.TitleColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property TitleSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.TitleColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property TitleDefault() As String
        Get
            Return TableUtils.TitleColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Contacts_.Name field.
	''' </summary>
	Public Property Name() As String
		Get 
			Return CType(Me.GetValue(TableUtils.NameColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.NameColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property NameSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.NameColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property NameDefault() As String
        Get
            Return TableUtils.NameColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Contacts_.Email field.
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
	''' This is a convenience property that provides direct access to the value of the record's Contacts_.Address field.
	''' </summary>
	Public Property Address() As String
		Get 
			Return CType(Me.GetValue(TableUtils.AddressColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.AddressColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property AddressSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.AddressColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property AddressDefault() As String
        Get
            Return TableUtils.AddressColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Contacts_.City field.
	''' </summary>
	Public Property City() As String
		Get 
			Return CType(Me.GetValue(TableUtils.CityColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.CityColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property CitySpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.CityColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property CityDefault() As String
        Get
            Return TableUtils.CityColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Contacts_.Zip field.
	''' </summary>
	Public Property Zip() As String
		Get 
			Return CType(Me.GetValue(TableUtils.ZipColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.ZipColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property ZipSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.ZipColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property ZipDefault() As String
        Get
            Return TableUtils.ZipColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Contacts_.Work Phone field.
	''' </summary>
	Public Property Work_Phone() As String
		Get 
			Return CType(Me.GetValue(TableUtils.Work_PhoneColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.Work_PhoneColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property Work_PhoneSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.Work_PhoneColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property Work_PhoneDefault() As String
        Get
            Return TableUtils.Work_PhoneColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Contacts_.Mobile field.
	''' </summary>
	Public Property Mobile() As String
		Get 
			Return CType(Me.GetValue(TableUtils.MobileColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.MobileColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property MobileSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.MobileColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property MobileDefault() As String
        Get
            Return TableUtils.MobileColumn.DefaultValue
        End Get
    End Property

	''' <summary>
	''' This is a convenience property that provides direct access to the value of the record's Contacts_.Comments field.
	''' </summary>
	Public Property Comments() As String
		Get 
			Return CType(Me.GetValue(TableUtils.CommentsColumn).ToString(), String)
		End Get
		Set (ByVal Value As String) 
			Me.SetString(value, TableUtils.CommentsColumn)
		End Set
	End Property


	''' <summary>
	''' This is a convenience method that can be used to determine that the column is set.
	''' </summary>
	Public ReadOnly Property CommentsSpecified() As Boolean
        Get
            Dim val As ColumnValue = Me.GetValue(TableUtils.CommentsColumn)
            If val Is Nothing OrElse val.IsNull Then
                Return False
            End If
            Return True
        End Get
    End Property

	''' <summary>
	''' This is a convenience method that can be used to get the default value of a column.
	''' </summary>
    Public ReadOnly Property CommentsDefault() As String
        Get
            Return TableUtils.CommentsColumn.DefaultValue
        End Get
    End Property



#End Region

End Class
End Namespace
