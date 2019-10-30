' This is a "safe" class, meaning that it is created once 
' and never overwritten. Any custom code you add to this class 
' will be preserved when you regenerate your application.
'
' Typical customizations that may be done in this class include
'  - overriding base class methods

Imports BaseClasses.Data
Imports BaseClasses.Data.SqlProvider

Namespace IROC2.Data

	''' <summary>
	''' Used by the <see cref="CommentsTable"></see> class to access and/or modify the database.
	''' </summary>
	''' <remarks>
	''' This class is not intended to be instantiated directly.  To obtain an instance of this class, 
	''' use the methods of the <see cref="CommentsTable"></see> class.
	''' </remarks>
	''' <seealso cref="CommentsTable"></seealso>

	Public Class CommentsSqlTable
		Inherits BaseCommentsSqlTable

		'The functions below may be overridden in order to implement your own
		'logic for creating, updating, deleting, and getting individual records,
		'or for running queries that return lists of records.  

		' Creates a new record. 
		' Before calling this method, column values should be set using SetColumn(). 
		'Public Overloads Overrides Function CreateRecord() As KeyValue
		'End Function

		' Updates a record in the database.
		' Before calling this method, column values should be set using SetColumn(). 
		'Protected Overrides Sub UpdateRecord()
		'End Sub

		' Deletes a record defined by a primary key value.
		'Public Overloads Overrides Sub DeleteRecord(ByVal key As KeyValue)
		'End Sub

		' Gets a record from the database.
		'Protected Overloads Overrides Sub GetRecord()
		'End Sub
	End Class
End Namespace
