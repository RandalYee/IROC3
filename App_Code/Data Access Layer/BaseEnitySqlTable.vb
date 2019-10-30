' This class is "generated" and will be overwritten.
' Your customizations should be made in EnitySqlTable.vb 

Imports BaseClasses.Data
Imports BaseClasses
Imports BaseClasses.Data.SqlProvider


Namespace IROC2.Data

''' <summary>
''' The generated superclass for the <see cref="EnitySqlTable"></see> class.
''' </summary>
''' <remarks>
''' This class is not intended to be instantiated directly.  To obtain an instance of this class, 
''' use the methods of the <see cref="EnityTable"></see> class.
''' </remarks>
''' <seealso cref="EnityTable"></seealso>
''' <seealso cref="EnitySqlTable"></seealso>

Public Class BaseEnitySqlTable
	Inherits DynamicSQLServerAdapter
	
	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(ByVal connectionName As String)
		MyBase.New(connectionName)
	End Sub
End Class
End Namespace
