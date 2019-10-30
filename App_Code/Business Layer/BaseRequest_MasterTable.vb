' This class is "generated" and will be overwritten.
' Your customizations should be made in Request_MasterRecord.vb

Imports System.Data.SqlTypes
Imports System.Data
Imports BaseClasses
Imports BaseClasses.Data
Imports BaseClasses.Data.SqlProvider
Imports IROC2.Data

Namespace IROC2.Business

''' <summary>
''' The generated superclass for the <see cref="Request_MasterTable"></see> class.
''' Provides access to the schema information and record data of a database table or view named DatabaseIROC%dbo.Request_Master.
''' </summary>
''' <remarks>
''' The connection details (name, location, etc.) of the database and table (or view) accessed by this class 
''' are resolved at runtime based on the connection string in the application's Web.Config file.
''' <para>
''' This class is not intended to be instantiated directly.  To obtain an instance of this class, use 
''' <see cref="Request_MasterTable.Instance">Request_MasterTable.Instance</see>.
''' </para>
''' </remarks>
''' <seealso cref="Request_MasterTable"></seealso>

<Serializable()> Public Class BaseRequest_MasterTable
    Inherits PrimaryKeyTable
    

    Private ReadOnly TableDefinitionString As String = Request_MasterDefinition.GetXMLString()







    Protected Sub New()
        MyBase.New()
        Me.Initialize()
    End Sub

    Protected Overridable Sub Initialize()
        Dim def As New XmlTableDefinition(TableDefinitionString)
        Me.TableDefinition = New TableDefinition()
        Me.TableDefinition.TableClassName = System.Reflection.Assembly.CreateQualifiedName("App_Code", "IROC2.Business.Request_MasterTable")
        def.InitializeTableDefinition(Me.TableDefinition)
        Me.ConnectionName = def.GetConnectionName()
        Me.RecordClassName = System.Reflection.Assembly.CreateQualifiedName("App_Code", "IROC2.Business.Request_MasterRecord")
        Me.ApplicationName = "App_Code"
        Me.DataAdapter = New Request_MasterSqlTable()
        Directcast(Me.DataAdapter, Request_MasterSqlTable).ConnectionName = Me.ConnectionName
        
        Me.TableDefinition.AdapterMetaData = Me.DataAdapter.AdapterMetaData
        Request_IdColumn.CodeName = "Request_Id"
        IROC_IdColumn.CodeName = "IROC_Id"
        PriorityColumn.CodeName = "Priority"
        Req_Site_NameColumn.CodeName = "Req_Site_Name"
        Req_AddressColumn.CodeName = "Req_Address"
        Req_CityColumn.CodeName = "Req_City"
        Req_IslandColumn.CodeName = "Req_Island"
        Req_StateColumn.CodeName = "Req_State"
        Req_ZipColumn.CodeName = "Req_Zip"
        Req_DtColumn.CodeName = "Req_Dt"
        Req_Target_DtColumn.CodeName = "Req_Target_Dt"
        Req_Completed_DtColumn.CodeName = "Req_Completed_Dt"
        Req_StatusColumn.CodeName = "Req_Status"
        Req_Funding_SrcColumn.CodeName = "Req_Funding_Src"
        Req_EnityColumn.CodeName = "Req_Enity"
        Req_CommentsColumn.CodeName = "Req_Comments"
        Req_Quote_RespnseColumn.CodeName = "Req_Quote_Respnse"
        Req_Quote_ApprovedColumn.CodeName = "Req_Quote_Approved"
        ICS_SOW_NeededColumn.CodeName = "ICS_SOW_Needed"
        ICS_SOW_UploadedColumn.CodeName = "ICS_SOW_Uploaded"
        ICS_CATV_CommentsColumn.CodeName = "ICS_CATV_Comments"
        Cat_Cost_FreeColumn.CodeName = "Cat_Cost_Free"
        Cat_Franchise_Order_NumberColumn.CodeName = "Cat_Franchise_Order_Number"
        County_UploadColumn.CodeName = "County_Upload"
        Cat_OTWC_CommentsColumn.CodeName = "Cat_OTWC_Comments"
        OTW_QuoteColumn.CodeName = "OTW_Quote"
        OTW_More_Info_FlagColumn.CodeName = "OTW_More_Info_Flag"
        OTW_More_Info_CommentsColumn.CodeName = "OTW_More_Info_Comments"
        OTW_Permit_StatusColumn.CodeName = "OTW_Permit_Status"
        OTW_Premise_Fiber_Work_ReqdColumn.CodeName = "OTW_Premise_Fiber_Work_Reqd"
        OTW_On_NetColumn.CodeName = "OTW_On_Net"
        OTW_Scheduled_Deploy_DtColumn.CodeName = "OTW_Scheduled_Deploy_Dt"
        OTW_Projected_Deploy_DtColumn.CodeName = "OTW_Projected_Deploy_Dt"
        OTW_Deployment_Start_DtColumn.CodeName = "OTW_Deployment_Start_Dt"
        OTW_Construction_StatusColumn.CodeName = "OTW_Construction_Status"
        OTW_Island_completedColumn.CodeName = "OTW_Island_completed"
        OTW_Completed_DtColumn.CodeName = "OTW_Completed_Dt"
        Pending_AgencyColumn.CodeName = "Pending_Agency"
        Pending_Action_DtColumn.CodeName = "Pending_Action_Dt"
        Pending_Action_NeededColumn.CodeName = "Pending_Action_Needed"
        Pending_Interval_Days_1stColumn.CodeName = "Pending_Interval_Days_1st"
        Pending_Interval_Days_2ndColumn.CodeName = "Pending_Interval_Days_2nd"
        Pending_Nterval_Days_MaxColumn.CodeName = "Pending_Nterval_Days_Max"
        Pending_Interval_Days_CancelColumn.CodeName = "Pending_Interval_Days_Cancel"
        Pending_Interval_Days_Auto_CancelColumn.CodeName = "Pending_Interval_Days_Auto_Cancel"
        Req_PO_NoColumn.CodeName = "Req_PO_No"
        Req_PO_DtColumn.CodeName = "Req_PO_Dt"
        Req_PO_AmtColumn.CodeName = "Req_PO_Amt"
        Req_Invoice_PaidColumn.CodeName = "Req_Invoice_Paid"
        Req_Pymt_Check_NoColumn.CodeName = "Req_Pymt_Check_No"
        Req_Pymt_DtColumn.CodeName = "Req_Pymt_Dt"
        Req_Pymt_AmtColumn.CodeName = "Req_Pymt_Amt"
        OTW_Invoice_NoColumn.CodeName = "OTW_Invoice_No"
        OTW_Invoice_DtColumn.CodeName = "OTW_Invoice_Dt"
        OTW_Invoice_AmtColumn.CodeName = "OTW_Invoice_Amt"
        Reg_TypeColumn.CodeName = "Reg_Type"
        Req_Contact_EmailColumn.CodeName = "Req_Contact_Email"
        Req_Enity2Column.CodeName = "Req_Enity2"
        Req_Funding_Src2Column.CodeName = "Req_Funding_Src2"
        Pending_Agency_ReturnColumn.CodeName = "Pending_Agency_Return"
        Pending_Prev_Action_NeededColumn.CodeName = "Pending_Prev_Action_Needed"
        Pending_Prev_StatusColumn.CodeName = "Pending_Prev_Status"
        Prov_NameColumn.CodeName = "Prov_Name"
        Cat_Franchise_Order_Number2Column.CodeName = "Cat_Franchise_Order_Number2"
        OTW_On_Net_DtColumn.CodeName = "OTW_On_Net_Dt"
        Req_Contact_Email2Column.CodeName = "Req_Contact_Email2"
        
    End Sub

#Region "Overriden methods"

    
#End Region

#Region "Properties for columns"

    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Request_Id column object.
    ''' </summary>
    Public ReadOnly Property Request_IdColumn() As BaseClasses.Data.NumberColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(0), BaseClasses.Data.NumberColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Request_Id column object.
    ''' </summary>
    Public Shared ReadOnly Property Request_Id() As BaseClasses.Data.NumberColumn
        Get
            Return Request_MasterTable.Instance.Request_IdColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.IROC_Id column object.
    ''' </summary>
    Public ReadOnly Property IROC_IdColumn() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(1), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.IROC_Id column object.
    ''' </summary>
    Public Shared ReadOnly Property IROC_Id() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.IROC_IdColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Priority column object.
    ''' </summary>
    Public ReadOnly Property PriorityColumn() As BaseClasses.Data.NumberColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(2), BaseClasses.Data.NumberColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Priority column object.
    ''' </summary>
    Public Shared ReadOnly Property Priority() As BaseClasses.Data.NumberColumn
        Get
            Return Request_MasterTable.Instance.PriorityColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Site_Name column object.
    ''' </summary>
    Public ReadOnly Property Req_Site_NameColumn() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(3), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Site_Name column object.
    ''' </summary>
    Public Shared ReadOnly Property Req_Site_Name() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.Req_Site_NameColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Address column object.
    ''' </summary>
    Public ReadOnly Property Req_AddressColumn() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(4), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Address column object.
    ''' </summary>
    Public Shared ReadOnly Property Req_Address() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.Req_AddressColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_City column object.
    ''' </summary>
    Public ReadOnly Property Req_CityColumn() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(5), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_City column object.
    ''' </summary>
    Public Shared ReadOnly Property Req_City() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.Req_CityColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Island column object.
    ''' </summary>
    Public ReadOnly Property Req_IslandColumn() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(6), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Island column object.
    ''' </summary>
    Public Shared ReadOnly Property Req_Island() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.Req_IslandColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_State column object.
    ''' </summary>
    Public ReadOnly Property Req_StateColumn() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(7), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_State column object.
    ''' </summary>
    Public Shared ReadOnly Property Req_State() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.Req_StateColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Zip column object.
    ''' </summary>
    Public ReadOnly Property Req_ZipColumn() As BaseClasses.Data.UsaZipCodeColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(8), BaseClasses.Data.UsaZipCodeColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Zip column object.
    ''' </summary>
    Public Shared ReadOnly Property Req_Zip() As BaseClasses.Data.UsaZipCodeColumn
        Get
            Return Request_MasterTable.Instance.Req_ZipColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Dt column object.
    ''' </summary>
    Public ReadOnly Property Req_DtColumn() As BaseClasses.Data.DateColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(9), BaseClasses.Data.DateColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Dt column object.
    ''' </summary>
    Public Shared ReadOnly Property Req_Dt() As BaseClasses.Data.DateColumn
        Get
            Return Request_MasterTable.Instance.Req_DtColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Target_Dt column object.
    ''' </summary>
    Public ReadOnly Property Req_Target_DtColumn() As BaseClasses.Data.DateColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(10), BaseClasses.Data.DateColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Target_Dt column object.
    ''' </summary>
    Public Shared ReadOnly Property Req_Target_Dt() As BaseClasses.Data.DateColumn
        Get
            Return Request_MasterTable.Instance.Req_Target_DtColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Completed_Dt column object.
    ''' </summary>
    Public ReadOnly Property Req_Completed_DtColumn() As BaseClasses.Data.DateColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(11), BaseClasses.Data.DateColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Completed_Dt column object.
    ''' </summary>
    Public Shared ReadOnly Property Req_Completed_Dt() As BaseClasses.Data.DateColumn
        Get
            Return Request_MasterTable.Instance.Req_Completed_DtColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Status column object.
    ''' </summary>
    Public ReadOnly Property Req_StatusColumn() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(12), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Status column object.
    ''' </summary>
    Public Shared ReadOnly Property Req_Status() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.Req_StatusColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Funding_Src column object.
    ''' </summary>
    Public ReadOnly Property Req_Funding_SrcColumn() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(13), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Funding_Src column object.
    ''' </summary>
    Public Shared ReadOnly Property Req_Funding_Src() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.Req_Funding_SrcColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Enity column object.
    ''' </summary>
    Public ReadOnly Property Req_EnityColumn() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(14), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Enity column object.
    ''' </summary>
    Public Shared ReadOnly Property Req_Enity() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.Req_EnityColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Comments column object.
    ''' </summary>
    Public ReadOnly Property Req_CommentsColumn() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(15), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Comments column object.
    ''' </summary>
    Public Shared ReadOnly Property Req_Comments() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.Req_CommentsColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Quote_Respnse column object.
    ''' </summary>
    Public ReadOnly Property Req_Quote_RespnseColumn() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(16), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Quote_Respnse column object.
    ''' </summary>
    Public Shared ReadOnly Property Req_Quote_Respnse() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.Req_Quote_RespnseColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Quote_Approved column object.
    ''' </summary>
    Public ReadOnly Property Req_Quote_ApprovedColumn() As BaseClasses.Data.DateColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(17), BaseClasses.Data.DateColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Quote_Approved column object.
    ''' </summary>
    Public Shared ReadOnly Property Req_Quote_Approved() As BaseClasses.Data.DateColumn
        Get
            Return Request_MasterTable.Instance.Req_Quote_ApprovedColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.ICS_SOW_Needed column object.
    ''' </summary>
    Public ReadOnly Property ICS_SOW_NeededColumn() As BaseClasses.Data.BooleanColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(18), BaseClasses.Data.BooleanColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.ICS_SOW_Needed column object.
    ''' </summary>
    Public Shared ReadOnly Property ICS_SOW_Needed() As BaseClasses.Data.BooleanColumn
        Get
            Return Request_MasterTable.Instance.ICS_SOW_NeededColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.ICS_SOW_Uploaded column object.
    ''' </summary>
    Public ReadOnly Property ICS_SOW_UploadedColumn() As BaseClasses.Data.BooleanColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(19), BaseClasses.Data.BooleanColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.ICS_SOW_Uploaded column object.
    ''' </summary>
    Public Shared ReadOnly Property ICS_SOW_Uploaded() As BaseClasses.Data.BooleanColumn
        Get
            Return Request_MasterTable.Instance.ICS_SOW_UploadedColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.ICS_CATV_Comments column object.
    ''' </summary>
    Public ReadOnly Property ICS_CATV_CommentsColumn() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(20), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.ICS_CATV_Comments column object.
    ''' </summary>
    Public Shared ReadOnly Property ICS_CATV_Comments() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.ICS_CATV_CommentsColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Cat_Cost_Free column object.
    ''' </summary>
    Public ReadOnly Property Cat_Cost_FreeColumn() As BaseClasses.Data.BooleanColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(21), BaseClasses.Data.BooleanColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Cat_Cost_Free column object.
    ''' </summary>
    Public Shared ReadOnly Property Cat_Cost_Free() As BaseClasses.Data.BooleanColumn
        Get
            Return Request_MasterTable.Instance.Cat_Cost_FreeColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Cat_Franchise_Order_Number column object.
    ''' </summary>
    Public ReadOnly Property Cat_Franchise_Order_NumberColumn() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(22), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Cat_Franchise_Order_Number column object.
    ''' </summary>
    Public Shared ReadOnly Property Cat_Franchise_Order_Number() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.Cat_Franchise_Order_NumberColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.County_Upload column object.
    ''' </summary>
    Public ReadOnly Property County_UploadColumn() As BaseClasses.Data.BooleanColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(23), BaseClasses.Data.BooleanColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.County_Upload column object.
    ''' </summary>
    Public Shared ReadOnly Property County_Upload() As BaseClasses.Data.BooleanColumn
        Get
            Return Request_MasterTable.Instance.County_UploadColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Cat_OTWC_Comments column object.
    ''' </summary>
    Public ReadOnly Property Cat_OTWC_CommentsColumn() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(24), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Cat_OTWC_Comments column object.
    ''' </summary>
    Public Shared ReadOnly Property Cat_OTWC_Comments() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.Cat_OTWC_CommentsColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_Quote column object.
    ''' </summary>
    Public ReadOnly Property OTW_QuoteColumn() As BaseClasses.Data.NumberColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(25), BaseClasses.Data.NumberColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_Quote column object.
    ''' </summary>
    Public Shared ReadOnly Property OTW_Quote() As BaseClasses.Data.NumberColumn
        Get
            Return Request_MasterTable.Instance.OTW_QuoteColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_More_Info_Flag column object.
    ''' </summary>
    Public ReadOnly Property OTW_More_Info_FlagColumn() As BaseClasses.Data.BooleanColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(26), BaseClasses.Data.BooleanColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_More_Info_Flag column object.
    ''' </summary>
    Public Shared ReadOnly Property OTW_More_Info_Flag() As BaseClasses.Data.BooleanColumn
        Get
            Return Request_MasterTable.Instance.OTW_More_Info_FlagColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_More_Info_Comments column object.
    ''' </summary>
    Public ReadOnly Property OTW_More_Info_CommentsColumn() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(27), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_More_Info_Comments column object.
    ''' </summary>
    Public Shared ReadOnly Property OTW_More_Info_Comments() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.OTW_More_Info_CommentsColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_Permit_Status column object.
    ''' </summary>
    Public ReadOnly Property OTW_Permit_StatusColumn() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(28), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_Permit_Status column object.
    ''' </summary>
    Public Shared ReadOnly Property OTW_Permit_Status() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.OTW_Permit_StatusColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_Premise Fiber Work Reqd column object.
    ''' </summary>
    Public ReadOnly Property OTW_Premise_Fiber_Work_ReqdColumn() As BaseClasses.Data.BooleanColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(29), BaseClasses.Data.BooleanColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_Premise Fiber Work Reqd column object.
    ''' </summary>
    Public Shared ReadOnly Property OTW_Premise_Fiber_Work_Reqd() As BaseClasses.Data.BooleanColumn
        Get
            Return Request_MasterTable.Instance.OTW_Premise_Fiber_Work_ReqdColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_On-Net column object.
    ''' </summary>
    Public ReadOnly Property OTW_On_NetColumn() As BaseClasses.Data.BooleanColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(30), BaseClasses.Data.BooleanColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_On-Net column object.
    ''' </summary>
    Public Shared ReadOnly Property OTW_On_Net() As BaseClasses.Data.BooleanColumn
        Get
            Return Request_MasterTable.Instance.OTW_On_NetColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_Scheduled_Deploy_Dt column object.
    ''' </summary>
    Public ReadOnly Property OTW_Scheduled_Deploy_DtColumn() As BaseClasses.Data.DateColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(31), BaseClasses.Data.DateColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_Scheduled_Deploy_Dt column object.
    ''' </summary>
    Public Shared ReadOnly Property OTW_Scheduled_Deploy_Dt() As BaseClasses.Data.DateColumn
        Get
            Return Request_MasterTable.Instance.OTW_Scheduled_Deploy_DtColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_Projected_Deploy_Dt column object.
    ''' </summary>
    Public ReadOnly Property OTW_Projected_Deploy_DtColumn() As BaseClasses.Data.DateColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(32), BaseClasses.Data.DateColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_Projected_Deploy_Dt column object.
    ''' </summary>
    Public Shared ReadOnly Property OTW_Projected_Deploy_Dt() As BaseClasses.Data.DateColumn
        Get
            Return Request_MasterTable.Instance.OTW_Projected_Deploy_DtColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_Deployment_Start_Dt column object.
    ''' </summary>
    Public ReadOnly Property OTW_Deployment_Start_DtColumn() As BaseClasses.Data.DateColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(33), BaseClasses.Data.DateColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_Deployment_Start_Dt column object.
    ''' </summary>
    Public Shared ReadOnly Property OTW_Deployment_Start_Dt() As BaseClasses.Data.DateColumn
        Get
            Return Request_MasterTable.Instance.OTW_Deployment_Start_DtColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_Construction_Status column object.
    ''' </summary>
    Public ReadOnly Property OTW_Construction_StatusColumn() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(34), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_Construction_Status column object.
    ''' </summary>
    Public Shared ReadOnly Property OTW_Construction_Status() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.OTW_Construction_StatusColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_Island completed column object.
    ''' </summary>
    Public ReadOnly Property OTW_Island_completedColumn() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(35), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_Island completed column object.
    ''' </summary>
    Public Shared ReadOnly Property OTW_Island_completed() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.OTW_Island_completedColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_Completed_Dt column object.
    ''' </summary>
    Public ReadOnly Property OTW_Completed_DtColumn() As BaseClasses.Data.DateColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(36), BaseClasses.Data.DateColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_Completed_Dt column object.
    ''' </summary>
    Public Shared ReadOnly Property OTW_Completed_Dt() As BaseClasses.Data.DateColumn
        Get
            Return Request_MasterTable.Instance.OTW_Completed_DtColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Pending_Agency column object.
    ''' </summary>
    Public ReadOnly Property Pending_AgencyColumn() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(37), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Pending_Agency column object.
    ''' </summary>
    Public Shared ReadOnly Property Pending_Agency() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.Pending_AgencyColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Pending Action_Dt column object.
    ''' </summary>
    Public ReadOnly Property Pending_Action_DtColumn() As BaseClasses.Data.DateColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(38), BaseClasses.Data.DateColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Pending Action_Dt column object.
    ''' </summary>
    Public Shared ReadOnly Property Pending_Action_Dt() As BaseClasses.Data.DateColumn
        Get
            Return Request_MasterTable.Instance.Pending_Action_DtColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Pending_Action_Needed column object.
    ''' </summary>
    Public ReadOnly Property Pending_Action_NeededColumn() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(39), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Pending_Action_Needed column object.
    ''' </summary>
    Public Shared ReadOnly Property Pending_Action_Needed() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.Pending_Action_NeededColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Pending_Interval_Days_1st column object.
    ''' </summary>
    Public ReadOnly Property Pending_Interval_Days_1stColumn() As BaseClasses.Data.NumberColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(40), BaseClasses.Data.NumberColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Pending_Interval_Days_1st column object.
    ''' </summary>
    Public Shared ReadOnly Property Pending_Interval_Days_1st() As BaseClasses.Data.NumberColumn
        Get
            Return Request_MasterTable.Instance.Pending_Interval_Days_1stColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Pending_Interval_Days_2nd column object.
    ''' </summary>
    Public ReadOnly Property Pending_Interval_Days_2ndColumn() As BaseClasses.Data.NumberColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(41), BaseClasses.Data.NumberColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Pending_Interval_Days_2nd column object.
    ''' </summary>
    Public Shared ReadOnly Property Pending_Interval_Days_2nd() As BaseClasses.Data.NumberColumn
        Get
            Return Request_MasterTable.Instance.Pending_Interval_Days_2ndColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Pending_Nterval_Days_Max column object.
    ''' </summary>
    Public ReadOnly Property Pending_Nterval_Days_MaxColumn() As BaseClasses.Data.NumberColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(42), BaseClasses.Data.NumberColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Pending_Nterval_Days_Max column object.
    ''' </summary>
    Public Shared ReadOnly Property Pending_Nterval_Days_Max() As BaseClasses.Data.NumberColumn
        Get
            Return Request_MasterTable.Instance.Pending_Nterval_Days_MaxColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Pending_Interval_Days_Cancel column object.
    ''' </summary>
    Public ReadOnly Property Pending_Interval_Days_CancelColumn() As BaseClasses.Data.NumberColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(43), BaseClasses.Data.NumberColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Pending_Interval_Days_Cancel column object.
    ''' </summary>
    Public Shared ReadOnly Property Pending_Interval_Days_Cancel() As BaseClasses.Data.NumberColumn
        Get
            Return Request_MasterTable.Instance.Pending_Interval_Days_CancelColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Pending_Interval_Days_Auto_Cancel column object.
    ''' </summary>
    Public ReadOnly Property Pending_Interval_Days_Auto_CancelColumn() As BaseClasses.Data.NumberColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(44), BaseClasses.Data.NumberColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Pending_Interval_Days_Auto_Cancel column object.
    ''' </summary>
    Public Shared ReadOnly Property Pending_Interval_Days_Auto_Cancel() As BaseClasses.Data.NumberColumn
        Get
            Return Request_MasterTable.Instance.Pending_Interval_Days_Auto_CancelColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_PO_No column object.
    ''' </summary>
    Public ReadOnly Property Req_PO_NoColumn() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(45), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_PO_No column object.
    ''' </summary>
    Public Shared ReadOnly Property Req_PO_No() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.Req_PO_NoColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_PO_Dt column object.
    ''' </summary>
    Public ReadOnly Property Req_PO_DtColumn() As BaseClasses.Data.DateColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(46), BaseClasses.Data.DateColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_PO_Dt column object.
    ''' </summary>
    Public Shared ReadOnly Property Req_PO_Dt() As BaseClasses.Data.DateColumn
        Get
            Return Request_MasterTable.Instance.Req_PO_DtColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_PO_Amt column object.
    ''' </summary>
    Public ReadOnly Property Req_PO_AmtColumn() As BaseClasses.Data.CurrencyColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(47), BaseClasses.Data.CurrencyColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_PO_Amt column object.
    ''' </summary>
    Public Shared ReadOnly Property Req_PO_Amt() As BaseClasses.Data.CurrencyColumn
        Get
            Return Request_MasterTable.Instance.Req_PO_AmtColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Invoice_Paid column object.
    ''' </summary>
    Public ReadOnly Property Req_Invoice_PaidColumn() As BaseClasses.Data.BooleanColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(48), BaseClasses.Data.BooleanColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Invoice_Paid column object.
    ''' </summary>
    Public Shared ReadOnly Property Req_Invoice_Paid() As BaseClasses.Data.BooleanColumn
        Get
            Return Request_MasterTable.Instance.Req_Invoice_PaidColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Pymt_Check_No column object.
    ''' </summary>
    Public ReadOnly Property Req_Pymt_Check_NoColumn() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(49), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Pymt_Check_No column object.
    ''' </summary>
    Public Shared ReadOnly Property Req_Pymt_Check_No() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.Req_Pymt_Check_NoColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Pymt_Dt column object.
    ''' </summary>
    Public ReadOnly Property Req_Pymt_DtColumn() As BaseClasses.Data.DateColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(50), BaseClasses.Data.DateColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Pymt_Dt column object.
    ''' </summary>
    Public Shared ReadOnly Property Req_Pymt_Dt() As BaseClasses.Data.DateColumn
        Get
            Return Request_MasterTable.Instance.Req_Pymt_DtColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Pymt_Amt column object.
    ''' </summary>
    Public ReadOnly Property Req_Pymt_AmtColumn() As BaseClasses.Data.CurrencyColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(51), BaseClasses.Data.CurrencyColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Pymt_Amt column object.
    ''' </summary>
    Public Shared ReadOnly Property Req_Pymt_Amt() As BaseClasses.Data.CurrencyColumn
        Get
            Return Request_MasterTable.Instance.Req_Pymt_AmtColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_Invoice_No column object.
    ''' </summary>
    Public ReadOnly Property OTW_Invoice_NoColumn() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(52), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_Invoice_No column object.
    ''' </summary>
    Public Shared ReadOnly Property OTW_Invoice_No() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.OTW_Invoice_NoColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_Invoice_Dt column object.
    ''' </summary>
    Public ReadOnly Property OTW_Invoice_DtColumn() As BaseClasses.Data.DateColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(53), BaseClasses.Data.DateColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_Invoice_Dt column object.
    ''' </summary>
    Public Shared ReadOnly Property OTW_Invoice_Dt() As BaseClasses.Data.DateColumn
        Get
            Return Request_MasterTable.Instance.OTW_Invoice_DtColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_Invoice_Amt column object.
    ''' </summary>
    Public ReadOnly Property OTW_Invoice_AmtColumn() As BaseClasses.Data.CurrencyColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(54), BaseClasses.Data.CurrencyColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_Invoice_Amt column object.
    ''' </summary>
    Public Shared ReadOnly Property OTW_Invoice_Amt() As BaseClasses.Data.CurrencyColumn
        Get
            Return Request_MasterTable.Instance.OTW_Invoice_AmtColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Reg_Type column object.
    ''' </summary>
    Public ReadOnly Property Reg_TypeColumn() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(55), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Reg_Type column object.
    ''' </summary>
    Public Shared ReadOnly Property Reg_Type() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.Reg_TypeColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Contact_Email column object.
    ''' </summary>
    Public ReadOnly Property Req_Contact_EmailColumn() As BaseClasses.Data.EmailColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(56), BaseClasses.Data.EmailColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Contact_Email column object.
    ''' </summary>
    Public Shared ReadOnly Property Req_Contact_Email() As BaseClasses.Data.EmailColumn
        Get
            Return Request_MasterTable.Instance.Req_Contact_EmailColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Enity2 column object.
    ''' </summary>
    Public ReadOnly Property Req_Enity2Column() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(57), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Enity2 column object.
    ''' </summary>
    Public Shared ReadOnly Property Req_Enity2() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.Req_Enity2Column
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Funding_Src2 column object.
    ''' </summary>
    Public ReadOnly Property Req_Funding_Src2Column() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(58), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Funding_Src2 column object.
    ''' </summary>
    Public Shared ReadOnly Property Req_Funding_Src2() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.Req_Funding_Src2Column
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Pending_Agency_Return column object.
    ''' </summary>
    Public ReadOnly Property Pending_Agency_ReturnColumn() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(59), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Pending_Agency_Return column object.
    ''' </summary>
    Public Shared ReadOnly Property Pending_Agency_Return() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.Pending_Agency_ReturnColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Pending_Prev_Action_Needed column object.
    ''' </summary>
    Public ReadOnly Property Pending_Prev_Action_NeededColumn() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(60), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Pending_Prev_Action_Needed column object.
    ''' </summary>
    Public Shared ReadOnly Property Pending_Prev_Action_Needed() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.Pending_Prev_Action_NeededColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Pending_Prev_Status column object.
    ''' </summary>
    Public ReadOnly Property Pending_Prev_StatusColumn() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(61), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Pending_Prev_Status column object.
    ''' </summary>
    Public Shared ReadOnly Property Pending_Prev_Status() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.Pending_Prev_StatusColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Prov_Name column object.
    ''' </summary>
    Public ReadOnly Property Prov_NameColumn() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(62), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Prov_Name column object.
    ''' </summary>
    Public Shared ReadOnly Property Prov_Name() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.Prov_NameColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Cat_Franchise_Order_Number2 column object.
    ''' </summary>
    Public ReadOnly Property Cat_Franchise_Order_Number2Column() As BaseClasses.Data.StringColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(63), BaseClasses.Data.StringColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Cat_Franchise_Order_Number2 column object.
    ''' </summary>
    Public Shared ReadOnly Property Cat_Franchise_Order_Number2() As BaseClasses.Data.StringColumn
        Get
            Return Request_MasterTable.Instance.Cat_Franchise_Order_Number2Column
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_On_Net_Dt column object.
    ''' </summary>
    Public ReadOnly Property OTW_On_Net_DtColumn() As BaseClasses.Data.DateColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(64), BaseClasses.Data.DateColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.OTW_On_Net_Dt column object.
    ''' </summary>
    Public Shared ReadOnly Property OTW_On_Net_Dt() As BaseClasses.Data.DateColumn
        Get
            Return Request_MasterTable.Instance.OTW_On_Net_DtColumn
        End Get
    End Property
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Contact_Email2 column object.
    ''' </summary>
    Public ReadOnly Property Req_Contact_Email2Column() As BaseClasses.Data.EmailColumn
        Get
            Return CType(Me.TableDefinition.ColumnList(65), BaseClasses.Data.EmailColumn)
        End Get
    End Property


    
    ''' <summary>
    ''' This is a convenience property that provides direct access to the table's Request_Master_.Req_Contact_Email2 column object.
    ''' </summary>
    Public Shared ReadOnly Property Req_Contact_Email2() As BaseClasses.Data.EmailColumn
        Get
            Return Request_MasterTable.Instance.Req_Contact_Email2Column
        End Get
    End Property


#End Region


#Region "Shared helper methods"

    ''' <summary>
    ''' This is a shared function that can be used to get an array of Request_MasterRecord records using a where clause.
    ''' </summary>
    Public Shared Function GetRecords(ByVal where As String) As Request_MasterRecord()

        Return GetRecords(where, Nothing, BaseTable.MIN_PAGE_NUMBER, BaseTable.MAX_BATCH_SIZE)
    End Function
    
    ''' <summary>
    ''' This is a shared function that can be used to get an array of Request_MasterRecord records using a where clause.
    ''' </summary>
    Public Shared Function GetRecords(ByVal join As BaseFilter, ByVal where As String) As Request_MasterRecord()

        Return GetRecords(join, where, Nothing, BaseTable.MIN_PAGE_NUMBER, BaseTable.MAX_BATCH_SIZE)
    End Function

    ''' <summary>
    ''' This is a shared function that can be used to get an array of Request_MasterRecord records using a where and order by clause.
    ''' </summary>
    Public Shared Function GetRecords( _
     ByVal where As String, _
     ByVal orderBy As OrderBy) As Request_MasterRecord()

        Return GetRecords(where, orderBy, BaseTable.MIN_PAGE_NUMBER, BaseTable.MAX_BATCH_SIZE)
    End Function

    ''' <summary>
    ''' This is a shared function that can be used to get an array of Request_MasterRecord records using a where and order by clause.
    ''' </summary>
    Public Shared Function GetRecords( _
     ByVal join As BaseFilter, _
     ByVal where As String, _
     ByVal orderBy As OrderBy) As Request_MasterRecord()

        Return GetRecords(join, where, orderBy, BaseTable.MIN_PAGE_NUMBER, BaseTable.MAX_BATCH_SIZE)
    End Function
    
    ''' <summary>
    ''' This is a shared function that can be used to get an array of Request_MasterRecord records using a where and order by clause clause with pagination.
    ''' </summary>
    Public Shared Function GetRecords( _
     ByVal where As String, _
     ByVal orderBy As OrderBy, _
     ByVal pageIndex As Integer, _
     ByVal pageSize As Integer) As Request_MasterRecord()
        
        Dim whereFilter As SqlFilter =  Nothing
        If Not where Is Nothing AndAlso where.trim() <> "" Then
            whereFilter =  New SqlFilter(where)
        End If
        Dim join As BaseClasses.Data.BaseFilter = Nothing 
        Dim recList As ArrayList =  Request_MasterTable.Instance.GetRecordList(join, whereFilter, Nothing, orderBy, pageIndex, pageSize)
 
        Return CType(recList.ToArray(GetType(IROC2.Business.Request_MasterRecord)), Request_MasterRecord())
    End Function

    ''' <summary>
    ''' This is a shared function that can be used to get an array of Request_MasterRecord records using a where and order by clause clause with pagination.
    ''' </summary>
    Public Shared Function GetRecords( _
     ByVal join As BaseFilter, _
     ByVal where As String, _
     ByVal orderBy As OrderBy, _
     ByVal pageIndex As Integer, _
     ByVal pageSize As Integer) As Request_MasterRecord()
        
        Dim whereFilter As SqlFilter =  Nothing
        If Not where Is Nothing AndAlso where.trim() <> "" Then
            whereFilter =  New SqlFilter(where)
        End If
         
        Dim recList As ArrayList =  Request_MasterTable.Instance.GetRecordList(join, whereFilter, Nothing, orderBy, pageIndex, pageSize)
 
        Return CType(recList.ToArray(GetType(IROC2.Business.Request_MasterRecord)), Request_MasterRecord())
    End Function

    Public Shared Function GetRecords( _
     ByVal where As WhereClause, _
     ByVal orderBy As OrderBy, _
     ByVal pageIndex As Integer, _
     ByVal pageSize As Integer) As Request_MasterRecord()
        Dim join As BaseClasses.Data.BaseFilter = Nothing
        Dim recList As ArrayList = Request_MasterTable.Instance.GetRecordList(join, where.GetFilter(), Nothing, orderBy, pageIndex, pageSize)

        Return CType(recList.ToArray(GetType(IROC2.Business.Request_MasterRecord)), Request_MasterRecord())
    End Function

    Public Shared Function GetRecords( _
     ByVal join As BaseFilter, _
     ByVal where As WhereClause, _
     ByVal orderBy As OrderBy, _
     ByVal pageIndex As Integer, _
     ByVal pageSize As Integer) As Request_MasterRecord()

        Dim recList As ArrayList = Request_MasterTable.Instance.GetRecordList(join, where.GetFilter(), Nothing, orderBy, pageIndex, pageSize)

        Return CType(recList.ToArray(GetType(IROC2.Business.Request_MasterRecord)), Request_MasterRecord())
    End Function

    Public Shared Function GetRecords( _
     ByVal where As WhereClause, _
     ByVal orderBy As OrderBy, _
     ByVal pageIndex As Integer, _
     ByVal pageSize As Integer, _
     ByRef totalRecords As Integer) As Request_MasterRecord()
        Dim join As BaseClasses.Data.BaseFilter = Nothing
        Dim recList As ArrayList = Request_MasterTable.Instance.GetRecordList(join, where.GetFilter(), Nothing, orderBy, pageIndex, pageSize, totalRecords)

        Return CType(recList.ToArray(GetType(IROC2.Business.Request_MasterRecord)), Request_MasterRecord())
    End Function

    Public Shared Function GetRecords( _
     ByVal join As BaseFilter, _
     ByVal where As WhereClause, _
     ByVal orderBy As OrderBy, _
     ByVal pageIndex As Integer, _
     ByVal pageSize As Integer, _
     ByRef totalRecords As Integer) As Request_MasterRecord()

        Dim recList As ArrayList = Request_MasterTable.Instance.GetRecordList(join, where.GetFilter(), Nothing, orderBy, pageIndex, pageSize, totalRecords)

        Return CType(recList.ToArray(GetType(IROC2.Business.Request_MasterRecord)), Request_MasterRecord())
    End Function
    
    ''' <summary>
    ''' This is a shared function that can be used to get total number of records that will be returned using the where clause.
    ''' </summary>
    Public Shared Function GetRecordCount(ByVal where As String) As Integer

        Dim whereFilter As SqlFilter = Nothing
        If Not where Is Nothing AndAlso where.Trim() <> "" Then
            whereFilter = New SqlFilter(where)
        End If

        Return CInt(Request_MasterTable.Instance.GetRecordListCount(Nothing, whereFilter, Nothing, Nothing))
    End Function

''' <summary>
    ''' This is a shared function that can be used to get total number of records that will be returned using the where clause.
    ''' </summary>
    Public Shared Function GetRecordCount(ByVal join As BaseFilter, ByVal where As String) As Integer

        Dim whereFilter As SqlFilter = Nothing
        If Not where Is Nothing AndAlso where.Trim() <> "" Then
            whereFilter = New SqlFilter(where)
        End If

        Return CInt(Request_MasterTable.Instance.GetRecordListCount(join, whereFilter, Nothing, Nothing))
    End Function

    Public Shared Function GetRecordCount(ByVal where As WhereClause) As Integer
        Return CInt(Request_MasterTable.Instance.GetRecordListCount(Nothing, where.GetFilter(), Nothing, Nothing))
    End Function
    
      Public Shared Function GetRecordCount(ByVal join As BaseFilter, ByVal where As WhereClause) As Integer
        Return CInt(Request_MasterTable.Instance.GetRecordListCount(join, where.GetFilter(), Nothing, Nothing))
    End Function

    ''' <summary>
    ''' This is a shared function that can be used to get a Request_MasterRecord record using a where clause.
    ''' </summary>
    Public Shared Function GetRecord(ByVal where As String) As Request_MasterRecord
        Dim orderBy As OrderBy = Nothing
        Return GetRecord(where, orderBy)
    End Function

    ''' <summary>
    ''' This is a shared function that can be used to get a Request_MasterRecord record using a where clause.
    ''' </summary>
    Public Shared Function GetRecord(ByVal join As BaseFilter, ByVal where As String) As Request_MasterRecord
        Dim orderBy As OrderBy = Nothing
        Return GetRecord(join, where, orderBy)
    End Function

    ''' <summary>
    ''' This is a shared function that can be used to get a Request_MasterRecord record using a where and order by clause.
    ''' </summary>
    Public Shared Function GetRecord( _
     ByVal where As String, _
     ByVal orderBy As OrderBy) As Request_MasterRecord

        Dim whereFilter As SqlFilter = Nothing
        If Not where Is Nothing AndAlso where.Trim() <> "" Then
            whereFilter = New SqlFilter(where)
        End If
        Dim join As BaseClasses.Data.BaseFilter = Nothing
        Dim recList As ArrayList = Request_MasterTable.Instance.GetRecordList(join, whereFilter, Nothing, orderBy, BaseTable.MIN_PAGE_NUMBER, BaseTable.MIN_BATCH_SIZE)

        Dim rec As Request_MasterRecord = Nothing
        If recList.Count > 0 Then
            rec = CType(recList(0), Request_MasterRecord)
        End If

        Return rec
    End Function

    ''' <summary>
    ''' This is a shared function that can be used to get a Request_MasterRecord record using a where and order by clause.
    ''' </summary>
    Public Shared Function GetRecord( _
     ByVal join As BaseFilter, _
     ByVal where As String, _
     ByVal orderBy As OrderBy) As Request_MasterRecord

        Dim whereFilter As SqlFilter = Nothing
        If Not where Is Nothing AndAlso where.Trim() <> "" Then
            whereFilter = New SqlFilter(where)
        End If

        Dim recList As ArrayList = Request_MasterTable.Instance.GetRecordList(join, whereFilter, Nothing, orderBy, BaseTable.MIN_PAGE_NUMBER, BaseTable.MIN_BATCH_SIZE)

        Dim rec As Request_MasterRecord = Nothing
        If recList.Count > 0 Then
            rec = CType(recList(0), Request_MasterRecord)
        End If

        Return rec
    End Function


    Public Shared Function GetValues( _
        ByVal col As BaseColumn, _
         ByVal where As WhereClause, _
         ByVal orderBy As OrderBy, _
         ByVal maxItems As Integer) As String()

        ' Create the filter list.
        Dim retCol As SqlBuilderColumnSelection = New SqlBuilderColumnSelection(False, True)
        retCol.AddColumn(col)

        Return Request_MasterTable.Instance.GetColumnValues(retCol, Nothing, where.GetFilter(), Nothing, orderBy, BaseTable.MIN_PAGE_NUMBER, maxItems)

    End Function

    Public Shared Function GetValues( _
         ByVal col As BaseColumn, _
         ByVal join As BaseFilter, _
         ByVal where As WhereClause, _
         ByVal orderBy As OrderBy, _
         ByVal maxItems As Integer) As String()

        ' Create the filter list.
        Dim retCol As SqlBuilderColumnSelection = New SqlBuilderColumnSelection(False, True)
        retCol.AddColumn(col)

        Return Request_MasterTable.Instance.GetColumnValues(retCol, join, where.GetFilter(), Nothing, orderBy, BaseTable.MIN_PAGE_NUMBER, maxItems)

    End Function


    ''' <summary>
    ''' This is a shared function that can be used to get a DataTable to bound with a data bound control using a where clause.
    ''' </summary>
    Public Shared Function GetDataTable(ByVal where As String) As System.Data.DataTable

        Dim recs() As Request_MasterRecord = GetRecords(where)
        Return Request_MasterTable.Instance.CreateDataTable(recs, Nothing)
    End Function
    
    ''' <summary>
    ''' This is a shared function that can be used to get a DataTable to bound with a data bound control using a where clause.
    ''' </summary>
    Public Shared Function GetDataTable(ByVal join As BaseFilter, ByVal where As String) As System.Data.DataTable

        Dim recs() As Request_MasterRecord = GetRecords(join, where)
        Return Request_MasterTable.Instance.CreateDataTable(recs, Nothing)
    End Function
    

    ''' <summary>
    ''' This is a shared function that can be used to get a DataTable to bound with a data bound control using a where and order by clause.
    ''' </summary>
    Public Shared Function GetDataTable(ByVal where As String, ByVal orderBy As OrderBy) As System.Data.DataTable

        Dim recs() As Request_MasterRecord = GetRecords(where, orderBy)
        Return Request_MasterTable.Instance.CreateDataTable(recs, Nothing)
    End Function

    ''' <summary>
    ''' This is a shared function that can be used to get a DataTable to bound with a data bound control using a where and order by clause.
    ''' </summary>
    Public Shared Function GetDataTable(ByVal join As BaseFilter, ByVal where As String, ByVal orderBy As OrderBy) As System.Data.DataTable

        Dim recs() As Request_MasterRecord = GetRecords(join, where, orderBy)
        Return Request_MasterTable.Instance.CreateDataTable(recs, Nothing)
    End Function


    ''' <summary>
    ''' This is a shared function that can be used to get a DataTable to bound with a data bound control using a where and order by clause with pagination.
    ''' </summary>
    Public Shared Function GetDataTable( _
     ByVal where As String, _
     ByVal orderBy As OrderBy, _
     ByVal pageIndex As Integer, _
     ByVal pageSize As Integer) As System.Data.DataTable

        Dim recs() As Request_MasterRecord = GetRecords(where, orderBy, pageIndex, pageSize)
        Return Request_MasterTable.Instance.CreateDataTable(recs, Nothing)
    End Function

    ''' <summary>
    ''' This is a shared function that can be used to get a DataTable to bound with a data bound control using a where and order by clause with pagination.
    ''' </summary>
    Public Shared Function GetDataTable( _
     ByVal join As BaseFilter, _    
     ByVal where As String, _
     ByVal orderBy As OrderBy, _
     ByVal pageIndex As Integer, _
     ByVal pageSize As Integer) As System.Data.DataTable

        Dim recs() As Request_MasterRecord = GetRecords(join, where, orderBy, pageIndex, pageSize)
        Return Request_MasterTable.Instance.CreateDataTable(recs, Nothing)
    End Function


    ''' <summary>
    ''' This is a shared function that can be used to delete records using a where clause.
    ''' </summary>
    Public Shared Sub DeleteRecords(ByVal where As String)
        If where = Nothing OrElse where.Trim() = "" Then
            Return
        End If

        Dim whereFilter As SqlFilter = New SqlFilter(where)
        Request_MasterTable.Instance.DeleteRecordList(whereFilter)
    End Sub

    ''' <summary>
    ''' This is a shared function that can be used to export records using a where clause.
    ''' </summary>
    Public Shared Function Export(ByVal where As String) As String
        Dim whereFilter As SqlFilter = Nothing
        If Not where Is Nothing AndAlso where.Trim() <> "" Then
            whereFilter = New SqlFilter(where)
        End If

        Return Request_MasterTable.Instance.ExportRecordData(whereFilter)
    End Function

    Public Shared Function Export(ByVal where As WhereClause) As String
        Dim whereFilter As BaseFilter = Nothing
        If Not where Is Nothing Then
            whereFilter = where.GetFilter()
        End If

        Return Request_MasterTable.Instance.ExportRecordData(whereFilter)
    End Function

    Public Shared Function GetSum( _
        ByVal col As BaseColumn, _
        ByVal where As WhereClause, _
        ByVal orderBy As OrderBy, _
        ByVal pageIndex As Integer, _
        ByVal pageSize As Integer) _
        As String

        Dim colSel As SqlBuilderColumnSelection = New SqlBuilderColumnSelection(False, False)
        colSel.AddColumn(col, SqlBuilderColumnOperation.OperationType.Sum)

        Return Request_MasterTable.Instance.GetColumnStatistics(colSel, Nothing, where.GetFilter(), Nothing, orderBy, pageIndex, pageSize)

    End Function

    Public Shared Function GetSum( _
        ByVal col As BaseColumn, _
        ByVal join As BaseFilter, _        
        ByVal where As WhereClause, _
        ByVal orderBy As OrderBy, _
        ByVal pageIndex As Integer, _
        ByVal pageSize As Integer) _
        As String

        Dim colSel As SqlBuilderColumnSelection = New SqlBuilderColumnSelection(False, False)
        colSel.AddColumn(col, SqlBuilderColumnOperation.OperationType.Sum)

        Return Request_MasterTable.Instance.GetColumnStatistics(colSel, join, where.GetFilter(), Nothing, orderBy, pageIndex, pageSize)

    End Function

    
    Public Shared Function GetCount( _
        ByVal col As BaseColumn, _
        ByVal where As WhereClause, _
        ByVal orderBy As OrderBy, _
        ByVal pageIndex As Integer, _
        ByVal pageSize As Integer) _
        As String

        Dim colSel As SqlBuilderColumnSelection = New SqlBuilderColumnSelection(False, False)
        colSel.AddColumn(col, SqlBuilderColumnOperation.OperationType.Count)

        Return Request_MasterTable.Instance.GetColumnStatistics(colSel, Nothing, where.GetFilter(), Nothing, orderBy, pageIndex, pageSize)

    End Function
    
    Public Shared Function GetCount( _
        ByVal col As BaseColumn, _
        ByVal join As BaseFilter, _         
        ByVal where As WhereClause, _
        ByVal orderBy As OrderBy, _
        ByVal pageIndex As Integer, _
        ByVal pageSize As Integer) _
        As String

        Dim colSel As SqlBuilderColumnSelection = New SqlBuilderColumnSelection(False, False)
        colSel.AddColumn(col, SqlBuilderColumnOperation.OperationType.Count)

        Return Request_MasterTable.Instance.GetColumnStatistics(colSel, join, where.GetFilter(), Nothing, orderBy, pageIndex, pageSize)

    End Function    

    ''' <summary>
    '''  This method returns the columns in the table.
    ''' </summary>
    Public Shared Function GetColumns() As BaseColumn()
        Return Request_MasterTable.Instance.TableDefinition.Columns
    End Function

    ''' <summary>
    '''  This method returns the columnlist in the table.
    ''' </summary>  
    Public Shared Function GetColumnList() As ColumnList
        Return Request_MasterTable.Instance.TableDefinition.ColumnList
    End Function


    ''' <summary>
    ''' This method creates a new record and returns it to be edited.
    ''' </summary>
    Public Shared Function CreateNewRecord() As IRecord
        Return Request_MasterTable.Instance.CreateRecord()
    End Function

    ''' <summary>
    ''' This method creates a new record and returns it to be edited.
    ''' </summary>
    ''' <param name="tempId">ID of the new record.</param>  
    Public Shared Function CreateNewRecord(ByVal tempId As String) As IRecord
        Return Request_MasterTable.Instance.CreateRecord(tempId)
    End Function

    ''' <summary>
    ''' This method checks if column is editable.
    ''' </summary>
    ''' <param name="columnName">Name of the column to check.</param>
    Public Shared Function isReadOnlyColumn(ByVal columnName As String) As Boolean
        Dim column As BaseColumn = GetColumn(columnName)
        If (Not IsNothing(column)) Then
            Return column.IsValuesReadOnly
        Else
            Return True
        End If
    End Function

    ''' <summary>
    ''' This method gets the specified column.
    ''' </summary>
    ''' <param name="uniqueColumnName">Unique name of the column to fetch.</param>
    Public Shared Function GetColumn(ByVal uniqueColumnName As String) As BaseColumn
        Dim column As BaseColumn = Request_MasterTable.Instance.TableDefinition.ColumnList.GetByUniqueName(uniqueColumnName)
        Return column
    End Function     


    ''' <summary>
    ''' This method gets the specified column.
    ''' </summary>
    ''' <param name="name">name of the column to fetch.</param>
    Public Shared Function GetColumnByName(ByVal name As String) As BaseColumn
        Dim column As BaseColumn = Request_MasterTable.Instance.TableDefinition.ColumnList.GetByInternalName(name)
        Return column
    End Function       
        

    ' Convenience method for getting a record using a string-based record identifier
    Public Shared Function GetRecord(ByVal id As String, ByVal bMutable As Boolean) As Request_MasterRecord
        Return CType(Request_MasterTable.Instance.GetRecordData(id, bMutable), Request_MasterRecord)
    End Function

    ' Convenience method for getting a record using a KeyValue record identifier
    Public Shared Function GetRecord(ByVal id As KeyValue, ByVal bMutable As Boolean) As Request_MasterRecord
        Return CType(Request_MasterTable.Instance.GetRecordData(id, bMutable), Request_MasterRecord)
    End Function

    ' Convenience method for creating a record
    Public Overloads Function NewRecord( _
        ByVal IROC_IdValue As String, _
        ByVal PriorityValue As String, _
        ByVal Req_Site_NameValue As String, _
        ByVal Req_AddressValue As String, _
        ByVal Req_CityValue As String, _
        ByVal Req_IslandValue As String, _
        ByVal Req_StateValue As String, _
        ByVal Req_ZipValue As String, _
        ByVal Req_DtValue As String, _
        ByVal Req_Target_DtValue As String, _
        ByVal Req_Completed_DtValue As String, _
        ByVal Req_StatusValue As String, _
        ByVal Req_Funding_SrcValue As String, _
        ByVal Req_EnityValue As String, _
        ByVal Req_CommentsValue As String, _
        ByVal Req_Quote_RespnseValue As String, _
        ByVal Req_Quote_ApprovedValue As String, _
        ByVal ICS_SOW_NeededValue As String, _
        ByVal ICS_SOW_UploadedValue As String, _
        ByVal ICS_CATV_CommentsValue As String, _
        ByVal Cat_Cost_FreeValue As String, _
        ByVal Cat_Franchise_Order_NumberValue As String, _
        ByVal County_UploadValue As String, _
        ByVal Cat_OTWC_CommentsValue As String, _
        ByVal OTW_QuoteValue As String, _
        ByVal OTW_More_Info_FlagValue As String, _
        ByVal OTW_More_Info_CommentsValue As String, _
        ByVal OTW_Permit_StatusValue As String, _
        ByVal OTW_Premise_Fiber_Work_ReqdValue As String, _
        ByVal OTW_On_NetValue As String, _
        ByVal OTW_Scheduled_Deploy_DtValue As String, _
        ByVal OTW_Projected_Deploy_DtValue As String, _
        ByVal OTW_Deployment_Start_DtValue As String, _
        ByVal OTW_Construction_StatusValue As String, _
        ByVal OTW_Island_completedValue As String, _
        ByVal OTW_Completed_DtValue As String, _
        ByVal Pending_AgencyValue As String, _
        ByVal Pending_Action_DtValue As String, _
        ByVal Pending_Action_NeededValue As String, _
        ByVal Pending_Interval_Days_1stValue As String, _
        ByVal Pending_Interval_Days_2ndValue As String, _
        ByVal Pending_Nterval_Days_MaxValue As String, _
        ByVal Pending_Interval_Days_CancelValue As String, _
        ByVal Pending_Interval_Days_Auto_CancelValue As String, _
        ByVal Req_PO_NoValue As String, _
        ByVal Req_PO_DtValue As String, _
        ByVal Req_PO_AmtValue As String, _
        ByVal Req_Invoice_PaidValue As String, _
        ByVal Req_Pymt_Check_NoValue As String, _
        ByVal Req_Pymt_DtValue As String, _
        ByVal Req_Pymt_AmtValue As String, _
        ByVal OTW_Invoice_NoValue As String, _
        ByVal OTW_Invoice_DtValue As String, _
        ByVal OTW_Invoice_AmtValue As String, _
        ByVal Reg_TypeValue As String, _
        ByVal Req_Contact_EmailValue As String, _
        ByVal Req_Enity2Value As String, _
        ByVal Req_Funding_Src2Value As String, _
        ByVal Pending_Agency_ReturnValue As String, _
        ByVal Pending_Prev_Action_NeededValue As String, _
        ByVal Pending_Prev_StatusValue As String, _
        ByVal Prov_NameValue As String, _
        ByVal Cat_Franchise_Order_Number2Value As String, _
        ByVal OTW_On_Net_DtValue As String, _
        ByVal Req_Contact_Email2Value As String _
    ) As KeyValue
        Dim rec As IPrimaryKeyRecord = CType(Me.CreateRecord(), IPrimaryKeyRecord)
                rec.SetString(IROC_IdValue, IROC_IdColumn)
        rec.SetString(PriorityValue, PriorityColumn)
        rec.SetString(Req_Site_NameValue, Req_Site_NameColumn)
        rec.SetString(Req_AddressValue, Req_AddressColumn)
        rec.SetString(Req_CityValue, Req_CityColumn)
        rec.SetString(Req_IslandValue, Req_IslandColumn)
        rec.SetString(Req_StateValue, Req_StateColumn)
        rec.SetString(Req_ZipValue, Req_ZipColumn)
        rec.SetString(Req_DtValue, Req_DtColumn)
        rec.SetString(Req_Target_DtValue, Req_Target_DtColumn)
        rec.SetString(Req_Completed_DtValue, Req_Completed_DtColumn)
        rec.SetString(Req_StatusValue, Req_StatusColumn)
        rec.SetString(Req_Funding_SrcValue, Req_Funding_SrcColumn)
        rec.SetString(Req_EnityValue, Req_EnityColumn)
        rec.SetString(Req_CommentsValue, Req_CommentsColumn)
        rec.SetString(Req_Quote_RespnseValue, Req_Quote_RespnseColumn)
        rec.SetString(Req_Quote_ApprovedValue, Req_Quote_ApprovedColumn)
        rec.SetString(ICS_SOW_NeededValue, ICS_SOW_NeededColumn)
        rec.SetString(ICS_SOW_UploadedValue, ICS_SOW_UploadedColumn)
        rec.SetString(ICS_CATV_CommentsValue, ICS_CATV_CommentsColumn)
        rec.SetString(Cat_Cost_FreeValue, Cat_Cost_FreeColumn)
        rec.SetString(Cat_Franchise_Order_NumberValue, Cat_Franchise_Order_NumberColumn)
        rec.SetString(County_UploadValue, County_UploadColumn)
        rec.SetString(Cat_OTWC_CommentsValue, Cat_OTWC_CommentsColumn)
        rec.SetString(OTW_QuoteValue, OTW_QuoteColumn)
        rec.SetString(OTW_More_Info_FlagValue, OTW_More_Info_FlagColumn)
        rec.SetString(OTW_More_Info_CommentsValue, OTW_More_Info_CommentsColumn)
        rec.SetString(OTW_Permit_StatusValue, OTW_Permit_StatusColumn)
        rec.SetString(OTW_Premise_Fiber_Work_ReqdValue, OTW_Premise_Fiber_Work_ReqdColumn)
        rec.SetString(OTW_On_NetValue, OTW_On_NetColumn)
        rec.SetString(OTW_Scheduled_Deploy_DtValue, OTW_Scheduled_Deploy_DtColumn)
        rec.SetString(OTW_Projected_Deploy_DtValue, OTW_Projected_Deploy_DtColumn)
        rec.SetString(OTW_Deployment_Start_DtValue, OTW_Deployment_Start_DtColumn)
        rec.SetString(OTW_Construction_StatusValue, OTW_Construction_StatusColumn)
        rec.SetString(OTW_Island_completedValue, OTW_Island_completedColumn)
        rec.SetString(OTW_Completed_DtValue, OTW_Completed_DtColumn)
        rec.SetString(Pending_AgencyValue, Pending_AgencyColumn)
        rec.SetString(Pending_Action_DtValue, Pending_Action_DtColumn)
        rec.SetString(Pending_Action_NeededValue, Pending_Action_NeededColumn)
        rec.SetString(Pending_Interval_Days_1stValue, Pending_Interval_Days_1stColumn)
        rec.SetString(Pending_Interval_Days_2ndValue, Pending_Interval_Days_2ndColumn)
        rec.SetString(Pending_Nterval_Days_MaxValue, Pending_Nterval_Days_MaxColumn)
        rec.SetString(Pending_Interval_Days_CancelValue, Pending_Interval_Days_CancelColumn)
        rec.SetString(Pending_Interval_Days_Auto_CancelValue, Pending_Interval_Days_Auto_CancelColumn)
        rec.SetString(Req_PO_NoValue, Req_PO_NoColumn)
        rec.SetString(Req_PO_DtValue, Req_PO_DtColumn)
        rec.SetString(Req_PO_AmtValue, Req_PO_AmtColumn)
        rec.SetString(Req_Invoice_PaidValue, Req_Invoice_PaidColumn)
        rec.SetString(Req_Pymt_Check_NoValue, Req_Pymt_Check_NoColumn)
        rec.SetString(Req_Pymt_DtValue, Req_Pymt_DtColumn)
        rec.SetString(Req_Pymt_AmtValue, Req_Pymt_AmtColumn)
        rec.SetString(OTW_Invoice_NoValue, OTW_Invoice_NoColumn)
        rec.SetString(OTW_Invoice_DtValue, OTW_Invoice_DtColumn)
        rec.SetString(OTW_Invoice_AmtValue, OTW_Invoice_AmtColumn)
        rec.SetString(Reg_TypeValue, Reg_TypeColumn)
        rec.SetString(Req_Contact_EmailValue, Req_Contact_EmailColumn)
        rec.SetString(Req_Enity2Value, Req_Enity2Column)
        rec.SetString(Req_Funding_Src2Value, Req_Funding_Src2Column)
        rec.SetString(Pending_Agency_ReturnValue, Pending_Agency_ReturnColumn)
        rec.SetString(Pending_Prev_Action_NeededValue, Pending_Prev_Action_NeededColumn)
        rec.SetString(Pending_Prev_StatusValue, Pending_Prev_StatusColumn)
        rec.SetString(Prov_NameValue, Prov_NameColumn)
        rec.SetString(Cat_Franchise_Order_Number2Value, Cat_Franchise_Order_Number2Column)
        rec.SetString(OTW_On_Net_DtValue, OTW_On_Net_DtColumn)
        rec.SetString(Req_Contact_Email2Value, Req_Contact_Email2Column)


        rec.Create() 'update the DB so any DB-initialized fields (like autoincrement IDs) can be initialized

        Dim key As KeyValue = rec.GetID()
        Return key
    End Function

    ''' <summary>
    '''  This method deletes a specified record
    ''' </summary>
    ''' <param name="kv">Keyvalue of the record to be deleted.</param>
    Public Shared Sub DeleteRecord(ByVal kv As KeyValue)
        Request_MasterTable.Instance.DeleteOneRecord(kv)
    End Sub

    ''' <summary>
    ''' This method checks if record exist in the database using the keyvalue provided.
    ''' </summary>
    ''' <param name="kv">Key value of the record.</param>
    Public Shared Function DoesRecordExist(ByVal kv As KeyValue) As Boolean
        Dim recordExist As Boolean = True
        Try
            Request_MasterTable.GetRecord(kv, False)
        Catch ex As Exception
            recordExist = False
        End Try
        Return recordExist
    End Function
    
    ''' <summary>
    '''  This method returns all the primary columns in the table.
    ''' </summary>
    Public Shared Function GetPrimaryKeyColumns() As ColumnList
        If (Not IsNothing(Request_MasterTable.Instance.TableDefinition.PrimaryKey)) Then
            Return Request_MasterTable.Instance.TableDefinition.PrimaryKey.Columns
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' This method takes a key and returns a keyvalue.
    ''' </summary>
    ''' <param name="key">key could be array of primary key values in case of composite primary key or a string containing single primary key value in case of non-composite primary key.</param>
    Public Shared Function GetKeyValue(ByVal key As Object) As KeyValue
        Dim kv As KeyValue = Nothing

        If (Not (IsNothing(Request_MasterTable.Instance.TableDefinition.PrimaryKey))) Then

            Dim isCompositePrimaryKey As Boolean = False
            isCompositePrimaryKey = Request_MasterTable.Instance.TableDefinition.PrimaryKey.IsCompositeKey

            If ((isCompositePrimaryKey) AndAlso (key.GetType.IsArray())) Then

                ' If the key is composite, then construct a key value.
                kv = New KeyValue
                Dim fullKeyString As String = ""
                Dim keyArray As Array = CType(key, Array)
                If (Not IsNothing(keyArray)) Then
                    Dim length As Integer = keyArray.Length
                    Dim pkColumns As ColumnList = Request_MasterTable.Instance.TableDefinition.PrimaryKey.Columns
                    Dim pkColumn As BaseColumn
                    Dim index As Integer = 0
                    For Each pkColumn In pkColumns
                        Dim keyString As String = CType(keyArray.GetValue(index), String)
                        If (Request_MasterTable.Instance.TableDefinition.TableType = BaseClasses.Data.TableDefinition.TableTypes.Virtual) Then
                            kv.AddElement(pkColumn.UniqueName, keyString)
                        Else
                            kv.AddElement(pkColumn.InternalName, keyString)
                        End If
                        index = index + 1
                    Next pkColumn
                End If

            Else
                ' If the key is not composite, then get the key value.
                kv = Request_MasterTable.Instance.TableDefinition.PrimaryKey.ParseValue(CType(key, String))
            End If
        End If
        Return kv
    End Function    


	 ''' <summary>
     ''' This method takes a record and a Column and returns an evaluated value of DFKA formula.
     ''' </summary>
	Public Shared Function GetDFKA(ByVal rec As BaseRecord, ByVal col As BaseColumn) As String
	    Dim fkColumn As ForeignKey = Request_MasterTable.Instance.TableDefinition.GetExpandableNonCompositeForeignKey(col)
	    If fkColumn Is Nothing Then
 			Return Nothing
		End If
        Dim _DFKA As String = fkColumn.PrimaryKeyDisplayColumns
        If (_DFKA.Trim().StartsWith("=")) Then
            ' if the formula is in the format of "= <Primary table>.<Field name>, then pull out the data from the rec object instead of doing formula evaluation 
            Dim tableCodeName As String = fkColumn.PrimaryKeyTableDefinition.TableCodeName
            Dim column As String = _DFKA.Trim("="c).Trim()
            If column.StartsWith(tableCodeName & ".", StringComparison.InvariantCultureIgnoreCase) Then
                column = column.Substring(tableCodeName.Length + 1)
            End If

            For Each c As BaseColumn In fkColumn.PrimaryKeyTableDefinition.Columns
                If column = c.CodeName Then
                    Return rec.Format(c)
                End If
            Next        
			Dim tableName As String = fkColumn.PrimaryKeyTableDefinition.TableCodeName
			Return EvaluateFormula(_DFKA, rec, Nothing, tableName)
		Else
            Return Nothing
        End If
    End Function

	''' <summary>
    ''' This method takes a keyValue and a Column and returns an evaluated value of DFKA formula.
    ''' </summary>
	Public Shared Function GetDFKA(ByVal keyValue As String, ByVal col As BaseColumn, ByVal formatPattern as String) As String
	    If keyValue Is Nothing Then
 			Return Nothing
		End If
	    Dim fkColumn As ForeignKey = Request_MasterTable.Instance.TableDefinition.GetExpandableNonCompositeForeignKey(col)
	    If fkColumn Is Nothing Then
 			Return Nothing
		End If
        Dim _DFKA As String = fkColumn.PrimaryKeyDisplayColumns
        If (_DFKA.Trim().StartsWith("=")) Then
			Dim tableName As String = fkColumn.PrimaryKeyTableDefinition.TableCodeName
			Dim t As PrimaryKeyTable = CType(DatabaseObjects.GetTableObject(tableName), PrimaryKeyTable)
			Dim rec As BaseRecord = Nothing
			If Not t Is Nothing Then
				Try
					rec = CType(t.GetRecordData(keyValue, False), BaseRecord)
				Catch 
					rec = Nothing
				End Try
			End If
			If rec Is Nothing Then
				Return ""
			End If
			
            ' if the formula is in the format of "= <Primary table>.<Field name>, then pull out the data from the rec object instead of doing formula evaluation 
            Dim tableCodeName As String = fkColumn.PrimaryKeyTableDefinition.TableCodeName
            Dim column As String = _DFKA.Trim("="c).Trim()
            If column.StartsWith(tableCodeName & ".", StringComparison.InvariantCultureIgnoreCase) Then
                column = column.Substring(tableCodeName.Length + 1)
            End If

            For Each c As BaseColumn In fkColumn.PrimaryKeyTableDefinition.Columns
                If column = c.CodeName Then
                    Return rec.Format(c)
                End If
            Next			
			Return EvaluateFormula(_DFKA, rec, Nothing, tableName)
		Else
            Return Nothing
        End If
    End Function

	''' <summary>
    ''' Evaluates the formula
    ''' </summary>
	Public Shared Function EvaluateFormula(ByVal formula As String, Optional ByVal dataSourceForEvaluate As BaseClasses.Data.BaseRecord = Nothing, Optional ByVal format As String = Nothing, Optional ByVal name As String = "") As String
		Dim e As BaseFormulaEvaluator = New BaseFormulaEvaluator()
		If Not dataSourceForEvaluate Is Nothing Then
			e.Evaluator.Variables.Add(name, dataSourceForEvaluate)
        end if
        e.DataSource = dataSourceForEvaluate

        Dim resultObj As Object = e.Evaluate(formula)
        If resultObj Is Nothing Then
	        Return ""
        End If
        If Not String.IsNullOrEmpty(format) Then
            Return BaseFormulaUtils.Format(resultObj, format)
        Else
            Return resultObj.ToString()
        End If
    End Function


#End Region 

End Class
End Namespace
