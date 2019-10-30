' This class is "generated" and will be overwritten.
' Your customizations should be made in Users_RoleSqlTable.vb 

Imports BaseClasses.Data
Imports BaseClasses
Imports BaseClasses.Data.SqlProvider


Namespace IROC2.Data

''' <summary>
''' The generated superclass for the <see cref="Users_RoleSqlTable"></see> class.
''' </summary>
''' <remarks>
''' This class is not intended to be instantiated directly.  To obtain an instance of this class, 
''' use the methods of the <see cref="Users_RoleTable"></see> class.
''' </remarks>
''' <seealso cref="Users_RoleTable"></seealso>
''' <seealso cref="Users_RoleSqlTable"></seealso>

Public Class BaseUsers_RoleSqlTable
	Inherits DynamicSQLServerAdapter
	
	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(ByVal connectionName As String)
		MyBase.New(connectionName)
	End Sub
End Class
End Namespace
