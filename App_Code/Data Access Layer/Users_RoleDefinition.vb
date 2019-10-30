Namespace IROC2.Business
''' <summary>
''' Contains embedded schema and configuration data that is used by the 
''' <see cref="Users_RoleTable">IROC2.Users_RoleTable</see> class
''' to initialize the class's TableDefinition.
''' </summary>
''' <seealso cref="Users_RoleTable"></seealso>

Public Class Users_RoleDefinition

#Region "Definition (XML) for Users_RoleDefinition table"
	'Next 94 lines contain Table Definition (XML) for table "Users_RoleDefinition"
	Private Shared _DefinitionString As String = ""
#End Region
	
	''' <summary>
	''' Gets the embedded schema and configuration data for the  
	''' <see cref="Users_RoleTable"></see>
	''' class's TableDefinition.
	''' </summary>
	''' <remarks>This function is only called once at runtime.</remarks>
	''' <returns>An XML string.</returns>
	Public Shared Function GetXMLString() As String
		If _DefinitionString = "" Then
			         Dim tbf As System.Text.StringBuilder = New System.Text.StringBuilder()
         tbf.Append("<XMLDefinition Generator=""Iron Speed Designer"" Version=""10.2"" Type=""USER"">")
         tbf.Append(  "<ColumnDefinition>")
         tbf.Append(    "<Column InternalName=""0"" Priority=""1"" ColumnNum=""0"">")
         tbf.Append(      "<columnName>User_ID</columnName>")
         tbf.Append(      "<columnUIName>User</columnUIName>")
         tbf.Append(      "<columnType>Number</columnType>")
         tbf.Append(      "<columnDBType>int</columnDBType>")
         tbf.Append(      "<columnLengthSet>10.0</columnLengthSet>")
         tbf.Append(      "<columnDefault></columnDefault>")
         tbf.Append(      "<columnDBDefault></columnDBDefault>")
         tbf.Append(      "<columnIndex>Y</columnIndex>")
         tbf.Append(      "<columnUnique>Y</columnUnique>")
         tbf.Append(      "<columnFunction>notrim</columnFunction>")
         tbf.Append(      "<columnDBFormat></columnDBFormat>")
         tbf.Append(      "<columnPK>Y</columnPK>")
         tbf.Append(      "<columnPermanent>N</columnPermanent>")
         tbf.Append(      "<columnComputed>N</columnComputed>")
         tbf.Append(      "<columnIdentity>N</columnIdentity>")
         tbf.Append(      "<columnReadOnly>N</columnReadOnly>")
         tbf.Append(      "<columnRequired>Y</columnRequired>")
         tbf.Append(      "<columnNotNull>Y</columnNotNull>")
         tbf.Append(      "<columnCaseSensitive>N</columnCaseSensitive>")
         tbf.Append(      "<columnCollation></columnCollation>")
         tbf.Append(      "<columnFullText>N</columnFullText>")
         tbf.Append(      "<columnVisibleWidth>%ISD_DEFAULT%</columnVisibleWidth>")
         tbf.Append(      "<columnTableAliasName></columnTableAliasName>")
         tbf.Append(      "<applyLabelText>Y</applyLabelText>")
         tbf.Append(      "<foreignKey>")
         tbf.Append(        "<columnFKName>FK_Users_Role_Users</columnFKName>")
         tbf.Append(        "<columnFKTable>IROC2.Business.UsersTable, App_Code</columnFKTable>")
         tbf.Append(        "<columnFKOwner>dbo</columnFKOwner>")
         tbf.Append(        "<columnFKColumn>User_ID</columnFKColumn>")
         tbf.Append(        "<columnFKColumnDisplay>User_Name</columnFKColumnDisplay>")
         tbf.Append(        "<foreignKeyType>Explicit</foreignKeyType>")
         tbf.Append(      "</foreignKey>")
         tbf.Append(      "<applyDFKA>Y</applyDFKA>")
         tbf.Append(    "</Column>")
         tbf.Append(    "<Column InternalName=""1"" Priority=""2"" ColumnNum=""1"">")
         tbf.Append(      "<columnName>Role_ID</columnName>")
         tbf.Append(      "<columnUIName>Role</columnUIName>")
         tbf.Append(      "<columnType>Number</columnType>")
         tbf.Append(      "<columnDBType>int</columnDBType>")
         tbf.Append(      "<columnLengthSet>10.0</columnLengthSet>")
         tbf.Append(      "<columnDefault></columnDefault>")
         tbf.Append(      "<columnDBDefault></columnDBDefault>")
         tbf.Append(      "<columnIndex>Y</columnIndex>")
         tbf.Append(      "<columnUnique>Y</columnUnique>")
         tbf.Append(      "<columnFunction>notrim</columnFunction>")
         tbf.Append(      "<columnDBFormat></columnDBFormat>")
         tbf.Append(      "<columnPK>Y</columnPK>")
         tbf.Append(      "<columnPermanent>N</columnPermanent>")
         tbf.Append(      "<columnComputed>N</columnComputed>")
         tbf.Append(      "<columnIdentity>N</columnIdentity>")
         tbf.Append(      "<columnReadOnly>N</columnReadOnly>")
         tbf.Append(      "<columnRequired>Y</columnRequired>")
         tbf.Append(      "<columnNotNull>Y</columnNotNull>")
         tbf.Append(      "<columnCaseSensitive>N</columnCaseSensitive>")
         tbf.Append(      "<columnCollation></columnCollation>")
         tbf.Append(      "<columnFullText>N</columnFullText>")
         tbf.Append(      "<columnVisibleWidth>%ISD_DEFAULT%</columnVisibleWidth>")
         tbf.Append(      "<columnTableAliasName></columnTableAliasName>")
         tbf.Append(      "<applyLabelText>Y</applyLabelText>")
         tbf.Append(      "<foreignKey>")
         tbf.Append(        "<columnFKName>FK_Users_Role_Role</columnFKName>")
         tbf.Append(        "<columnFKTable>IROC2.Business.RoleTable, App_Code</columnFKTable>")
         tbf.Append(        "<columnFKOwner>dbo</columnFKOwner>")
         tbf.Append(        "<columnFKColumn>Role_ID</columnFKColumn>")
         tbf.Append(        "<columnFKColumnDisplay>Role_Name</columnFKColumnDisplay>")
         tbf.Append(        "<foreignKeyType>Explicit</foreignKeyType>")
         tbf.Append(      "</foreignKey>")
         tbf.Append(      "<applyDFKA>Y</applyDFKA>")
         tbf.Append(    "</Column>")
         tbf.Append(  "</ColumnDefinition>")
         tbf.Append(  "<TableName>Users_Role</TableName>")
         tbf.Append(  "<Version></Version>")
         tbf.Append(  "<Owner>dbo</Owner>")
         tbf.Append(  "<TableAliasName>Users_Role_</TableAliasName>")
         tbf.Append(  "<ConnectionName>DatabaseIROC</ConnectionName>")
         tbf.Append(  "<PagingMethod>RowNum</PagingMethod>")
         tbf.Append(  "<canCreateRecords Source=""Database"">Y</canCreateRecords>")
         tbf.Append(  "<canEditRecords Source=""Database"">Y</canEditRecords>")
         tbf.Append(  "<canDeleteRecords Source=""Database"">Y</canDeleteRecords>")
         tbf.Append(  "<canViewRecords Source=""Database"">Y</canViewRecords>")
         tbf.Append(  "<ConcurrencyMethod>BinaryChecksum</ConcurrencyMethod>")
         tbf.Append(  "<AppShortName>IROC2</AppShortName>")
         tbf.Append(  "<FolderName>Users_Role</FolderName>")
         tbf.Append(  "<MenuName>Users Role</MenuName>")
         tbf.Append(  "<QSPath>../Users_Role/Users-Role-QuickSelector.aspx</QSPath>")
         tbf.Append(  "<TableCodeName>Users_Role</TableCodeName>")
         tbf.Append(  "<TableStoredProcPrefix>pIROC2Users_Role</TableStoredProcPrefix>")
         tbf.Append(  "<IsRoleTable>Y</IsRoleTable>")
         tbf.Append(  "<RoleRoleID>Role_ID</RoleRoleID>")
         tbf.Append(  "<RoleUserID>User_ID</RoleUserID>")
         tbf.Append("</XMLDefinition>")
         _DefinitionString = tbf.ToString()

		End	If	
		Return _DefinitionString		
	End Function

End Class
End Namespace
