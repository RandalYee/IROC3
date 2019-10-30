Imports System.IO
Imports System.Collections
Imports BaseClasses
Imports BaseClasses.Data
Imports BaseClasses.Utils
Imports BaseClasses.Configuration
Imports System.Text
Imports System.Web
Imports System.Net
Imports System.Xml.XPath
Imports System.Xml



Namespace IROC2.Data
    ''' <summary>
    ''' The FormulaUtils class contains a set of functions that are available
    ''' in the Formula editor. You can specify any of these functions after
    ''' the = sign.
    ''' For example, you can say:
    ''' = IsEven(32)
    ''' These functions throw an exception on an error. The formula evaluator
    ''' catches this exception and returns the error string to the user interface.
    '''
    ''' All of the functions operate as a Decimal. The Decimal data type is better
    ''' then Double or Single since it provides a more accurate value as compared to
    ''' Double, and a larger value as compared to a Single. All integers, doubles, etc.
    ''' are converted to Decimals as part of these functions.
    '''
    ''' Function names are not case sensitive. So you can use ROUND, Round, round, etc.
    '''
    ''' </summary>
    ''' <remarks></remarks>
    Public Class BaseFormulaUtils
#Region "DataSource Lookup Functions"
        Public Shared Function Lookup(ByVal dataSourceName As DataSource, ByVal rowNumber As Object, ByVal id As Object, ByVal idColumn As Object, ByVal valueColumn As Object) As Object
            Return dataSourceName.Lookup(rowNumber, id, idColumn, valueColumn)

        End Function

        Public Shared Function Lookup(ByVal dataSourceName As DataSource, ByVal id As Object, ByVal format As String) As String
            Dim val As Object = dataSourceName.Lookup(Nothing, id, Nothing, Nothing)
            If val Is Nothing Then
                val = ""
            End If
            Return BaseFormulaUtils.Format(val, format)

        End Function

        Public Shared Function Lookup(ByVal dataSourceName As DataSource, ByVal id As Object) As String
            Dim val As Object = dataSourceName.Lookup(Nothing, id, Nothing, Nothing)
            If val Is Nothing Then
                val = ""
            End If
            Return BaseFormulaUtils.Format(val, "")

        End Function

#End Region

#Region "Information Functions"

        ''' <summary>
        ''' Check if the number is Even or not. 
        ''' The number can be specified as an integer (e.g., 37), a decimal 
        ''' value (e.g., 37.48), as a string with an optional currency symbol and 
        ''' separators ("1,234.56", "$1,234.56"), or as the value of a 
        ''' variable (e.g, UnitPrice).
        ''' </summary>
        ''' <param name="val">Number to be checked</param>
        ''' <returns>True if the input is even, False otherwise.</returns>
        Public Shared Function IsEven(ByVal val As Object) As Boolean
            Dim valDecimal As Decimal = 0
            Try
                valDecimal = StringUtils.ParseDecimal(val)
                Return (valDecimal Mod 2 = 0)
            Catch ex As Exception
                Throw New Exception("ISEVEN(" & GetStr(val) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Check if the input is odd or not
        ''' The number can be specified as an integer (e.g., 37), a decimal 
        ''' value (e.g., 37.48), as a string with an optional currency symbol and 
        ''' separators ("1,234.56", "$1,234.56"), or as the value of a 
        ''' variable (e.g, UnitPrice).
        ''' </summary>
        ''' <param name="val">Number to be checked</param>
        ''' <returns>True if the input is odd, False otherwise.</returns>
        Public Shared Function IsOdd(ByVal val As Object) As Boolean
            Dim valDecimal As Decimal = 0
            Try
                valDecimal = StringUtils.ParseDecimal(val)
                Return (valDecimal Mod 2 <> 0)
            Catch ex As Exception
                Throw New Exception("ISODD(" & GetStr(val) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Check if the input is a number or not
        ''' The number can be specified as an integer (e.g., 37), a decimal 
        ''' value (e.g., 37.48), as a string with an optional currency symbol and 
        ''' separators ("1,234.56", "$1,234.56"), or as the value of a 
        ''' variable (e.g, UnitPrice).
        ''' </summary>
        ''' <param name="val">Number to be checked</param>
        ''' <returns>True if the input is a number, False otherwise.</returns>
        Public Shared Function IsNumber(ByVal val As Object) As Boolean
            Dim valDecimal As Decimal = 0
            Try
                valDecimal = StringUtils.ParseDecimal(val)
                ' If we are successfully parsing the number, then return True
                Return True
                ' Ignore exception, just fall through and return false
            Catch
            End Try
            Return False
        End Function

        ''' <summary>
        ''' Check if the input is logical or not
        ''' The value can be specified as a decimal value (e.g., 37.48), 
        ''' as a string (“True”), as a Boolean (e.g., True), as an expression (e.g., 1+1=2), 
        ''' or as the value of a variable (e.g, UnitPrice).
        ''' </summary>
        ''' <param name="val">Value to be checked</param>
        ''' <returns>True if the input is a boolean, False otherwise.</returns>
        Public Shared Function IsLogical(ByVal val As Object) As Boolean
            Dim valBoolean As Boolean = False
            Try
                valBoolean = Convert.ToBoolean(val)
                ' If we are able to successfully convert the value, then return True
                Return True
                ' Ignore exception, just fall through and return false
            Catch
            End Try
            Return False
        End Function

        ''' <summary>
        ''' Check if the input is null or not
        ''' The value can be specified as a decimal value (e.g., 37.48), as a string (“True”),
        ''' as an expression (e.g., 1+1=2), or as the value of a variable (e.g, UnitPrice).
        ''' </summary>
        ''' <param name="val">Value to be checked</param>
        ''' <returns>True if the input is null</returns>
        Public Shared Function IsNull(ByVal val As Object) As Boolean
            ' If val is nothing, then return True
            If val Is Nothing Then
                Return True
            Else
                Return False
            End If
        End Function

        ''' <summary>
        ''' Check if the value entered is blank or not. A NULL value is considered blank too.
        ''' The value can be specified as a decimal value (e.g., 37.48), as a string (“  ”), 
        ''' as an expression (e.g., 1+1=2), or as the value of a variable (e.g, ShippedDate).
        ''' </summary>
        ''' <param name="val">Value to be checked</param>
        ''' <returns>True if the input is blank</returns>
        Public Shared Function IsBlank(ByVal val As Object) As Boolean
            If val Is Nothing Then
                Return True
            End If

            If Object.ReferenceEquals(val.[GetType](), GetType(String)) AndAlso DirectCast(val, String).Trim().Length = 0 Then
                Return True
            End If

            Return False
        End Function

        ''' <summary>
        ''' Check if the value entered is a text or not
        ''' The value can be specified as a decimal value (e.g., 37.48), as a string (“  ”), 
        ''' as an expression (e.g., 1+1=2), or as the value of a variable (e.g, ShippedDate).
        ''' </summary>
        ''' <param name="val">Value to be checked</param>
        ''' <returns>True if the input is text</returns>
        Public Shared Function IsText(ByVal val As Object) As Boolean
            If val Is Nothing Then
                Return False
            End If

            If Object.ReferenceEquals(val.[GetType](), GetType(String)) Then
                Return True
            End If

            Return False
        End Function

#End Region

#Region "Mathematical Functions"

        ''' <summary>
        ''' Calculate the absolute value of the argument passed
        ''' The number can be specified as an integer (e.g., 37), a decimal 
        ''' value (e.g., 37.48), as a string with an optional currency symbol and 
        ''' separators ("1,234.56", "$1,234.56"), or as the value of a 
        ''' variable (e.g, UnitPrice).
        ''' </summary>
        ''' <param name="val">The input whose absolute value is to be found.</param>
        ''' <returns>The absolute value of the number.</returns>
        Public Shared Function Abs(ByVal val As Object) As Decimal
            Try
                Return Math.Abs(StringUtils.ParseDecimal(val))
            Catch ex As Exception
                Throw New Exception("ABS(" & GetStr(val) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Calculate the ceiling value of the argument passed
        ''' The number can be specified as an integer (e.g., 37), a decimal 
        ''' value (e.g., 37.48), as a string with an optional currency symbol and 
        ''' separators ("1,234.56", "$1,234.56"), or as the value of a 
        ''' variable (e.g, UnitPrice).
        ''' </summary>
        ''' <param name="val">The input whose ceiling value is to be calculated.</param>
        ''' <returns>The ceiling value of the number.</returns>
        Public Shared Function Ceiling(ByVal val As Object) As Decimal
            Try
                Return Math.Ceiling(StringUtils.ParseDecimal(val))
            Catch ex As Exception
                Throw New Exception("CEILING(" & GetStr(val) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Calculates the exponential value of the input
        ''' The number can be specified as an integer (e.g., 37), a decimal 
        ''' value (e.g., 37.48), as a string with an optional currency symbol and 
        ''' separators ("1,234.56", "$1,234.56"), or as the value of a 
        ''' variable (e.g, UnitPrice).
        ''' </summary>
        ''' <param name="val">The input whose exponential value is to be calculated</param>
        ''' <returns>
        ''' The exponential value of the input
        ''' </returns>
        Public Shared Function Exp(ByVal val As Object) As Decimal
            Dim valDouble As [Double] = 0
            Try
                valDouble = Convert.ToDouble(StringUtils.ParseDecimal(val))
                Return Convert.ToDecimal(Math.Exp(valDouble))
            Catch ex As Exception
                Throw New Exception("EXP(" & GetStr(val) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Calculates the floor value of the input
        ''' The number can be specified as an integer (e.g., 37), a decimal 
        ''' value (e.g., 37.48), as a string with an optional currency symbol and 
        ''' separators ("1,234.56", "$1,234.56"), or as the value of a 
        ''' variable (e.g, UnitPrice).
        ''' </summary>
        ''' <param name="val">The input whose floor value is to be calculated</param>
        ''' <returns>
        ''' The floor value of the input
        ''' </returns>
        Public Shared Function Floor(ByVal val As Object) As Decimal
            Try
                Return Math.Floor(StringUtils.ParseDecimal(val))
            Catch ex As Exception
                Throw New Exception("FLOOR(" & GetStr(val) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Calculates the mod value of the division 
        ''' The number can be specified as an integer (e.g., 37), a decimal 
        ''' value (e.g., 37.48), as a string with an optional currency symbol and 
        ''' separators ("1,234.56", "$1,234.56"), or as the value of a 
        ''' variable (e.g, UnitPrice).
        ''' </summary>
        ''' <param name="dividend">The dividend</param>
        ''' <param name="divisor">The divisor</param>
        ''' <returns>
        ''' The mod value of the division.
        ''' </returns>
        Public Shared Function Modulus(ByVal dividend As Object, ByVal divisor As Object) As Decimal
            Dim dividendDecimal As Decimal = 0
            Dim divisorDecimal As Decimal = 0
            Try
                dividendDecimal = StringUtils.ParseDecimal(dividend)
                divisorDecimal = StringUtils.ParseDecimal(divisor)
                Return dividendDecimal Mod divisorDecimal
            Catch ex As Exception
                Throw New Exception("MODULUS(" & GetStr(dividendDecimal) & ", " & GetStr(divisorDecimal) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Calculate the value of a variable raised to the power of the other.
        ''' The number can be specified as an integer (e.g., 37), a decimal 
        ''' value (e.g., 37.48), as a string with an optional currency symbol and 
        ''' separators ("1,234.56", "$1,234.56"), or as the value of a 
        ''' variable (e.g, UnitPrice).
        ''' </summary>
        ''' <param name="val1">The base</param>
        ''' <param name="val2">The power</param>
        ''' <returns>
        ''' The val1 raised to the power of val2
        ''' </returns>
        Public Shared Function Power(ByVal val1 As Object, ByVal val2 As Object) As Decimal
            Dim val1Double As [Double] = 0
            Dim val2Double As [Double] = 0
            Try
                val1Double = Convert.ToDouble(StringUtils.ParseDecimal(val1))
                val2Double = Convert.ToDouble(StringUtils.ParseDecimal(val2))
                Return Convert.ToDecimal(Math.Pow(val1Double, val2Double))
            Catch ex As Exception
                Throw New Exception("POWER(" & GetStr(val1) & ", " & GetStr(val2) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Return the value of PI as a Decimal.
        ''' </summary>
        Public Shared Function Pi() As Decimal
            Return Convert.ToDecimal(Math.PI)
        End Function

        ''' <summary>
        ''' Calculate the quotient of the division 
        ''' The number(s) can be specified as an integer (e.g., 37), a decimal 
        ''' value (e.g., 37.48), as a string with an optional currency symbol and 
        ''' separators ("1,234.56", "$1,234.56"), or as the value of a 
        ''' variable (e.g, UnitPrice).
        ''' </summary>
        ''' <param name="dividend">The dividend of the division</param>
        ''' <param name="divisor">The divisor of the division</param>
        ''' <returns>
        ''' The quotient of the division.
        ''' </returns>
        Public Shared Function Quotient(ByVal dividend As Object, ByVal divisor As Object) As Decimal
            Try
                Return Convert.ToDecimal(Math.Ceiling(StringUtils.ParseDecimal(dividend) / StringUtils.ParseDecimal(divisor)))
            Catch ex As Exception
                Throw New Exception("QUOTIENT(" & GetStr(dividend) & ", " & GetStr(divisor) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Round value up to the specified number of decimal places
        ''' The number(s) can be specified as an integer (e.g., 37), a decimal 
        ''' value (e.g., 37.48), as a string with an optional currency symbol and 
        ''' separators ("1,234.56", "$1,234.56"), or as the value of a 
        ''' variable (e.g, UnitPrice).
        ''' </summary>
        ''' <param name="number">Number to be rounded</param>
        ''' <param name="numberOfDigits">Number of decimals to be rounded upto</param>
        ''' <returns>The rounded up value.</returns>
        Public Shared Function Round(ByVal number As Object, ByVal numberOfDigits As Object) As Decimal
            Try
                Return Math.Round(StringUtils.ParseDecimal(number), CInt(numberOfDigits))
            Catch ex As Exception
                Throw New Exception("ROUND(" & GetStr(number) & ", " & GetStr(numberOfDigits) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Calculate the square root value of the input
        ''' The number(s) can be specified as an integer (e.g., 37), a decimal 
        ''' value (e.g., 37.48), as a string with an optional currency symbol and 
        ''' separators ("1,234.56", "$1,234.56"), or as the value of a 
        ''' variable (e.g, UnitPrice).
        ''' </summary>
        ''' <param name="val">The argument whose square root is to be calculated</param>
        ''' <returns>The square root.</returns>
        Public Shared Function Sqrt(ByVal val As Object) As Decimal
            Dim valDouble As [Double] = 0
            Try
                valDouble = Convert.ToDouble(StringUtils.ParseDecimal(val))
                Return Convert.ToDecimal(Math.Sqrt(valDouble))
            Catch ex As Exception
                Throw New Exception("SQRT(" & GetStr(val) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Calculate the truncated value of the input
        ''' The number(s) can be specified as an integer (e.g., 37), a decimal 
        ''' value (e.g., 37.48), as a string with an optional currency symbol and 
        ''' separators ("1,234.56", "$1,234.56"), or as the value of a 
        ''' variable (e.g, UnitPrice).
        ''' </summary>
        ''' <param name="val">The argument whose truncated value is to be calculated</param>
        ''' <returns>The truncated value.</returns>
        Public Shared Function Trunc(ByVal val As Object) As Decimal
            Try
                Return Convert.ToDecimal(Math.Truncate(StringUtils.ParseDecimal(val)))
            Catch ex As Exception
                Throw New Exception("TRUNC(" & GetStr(val) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Calculate the logarithmic value to the specified base
        ''' The number(s) can be specified as an integer (e.g., 37), a decimal 
        ''' value (e.g., 37.48), as a string with an optional currency symbol and 
        ''' separators ("1,234.56", "$1,234.56"), or as the value of a 
        ''' variable (e.g, UnitPrice).
        ''' </summary>
        ''' <param name="val1">The argument whose log value is to be calculated</param>
        ''' <param name="val2">The value which would act as a base</param>
        ''' <returns>The log value</returns>
        Public Shared Function Log(ByVal val1 As Object, ByVal val2 As Object) As Decimal
            Dim val1Double As [Double] = 0
            Dim val2Double As [Double] = 0
            Try
                val1Double = Convert.ToDouble(StringUtils.ParseDecimal(val1))
                val2Double = Convert.ToDouble(StringUtils.ParseDecimal(val2))
                Return Convert.ToDecimal(Math.Log(val1Double, val2Double))
            Catch ex As Exception
                Throw New Exception("LOG(" & GetStr(val1) & ", " & GetStr(val2) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Calculate the logarithmic value to the base 10
        ''' The number(s) can be specified as an integer (e.g., 37), a decimal 
        ''' value (e.g., 37.48), as a string with an optional currency symbol and 
        ''' separators ("1,234.56", "$1,234.56"), or as the value of a 
        ''' variable (e.g, UnitPrice).
        ''' </summary>
        ''' <param name="val">The argument whose log value is to be calculated</param>
        ''' <returns>The log value.</returns>
        Public Shared Function Log(ByVal val As Object) As Decimal
            Dim valDouble As [Double] = 0
            Try
                valDouble = Convert.ToDouble(StringUtils.ParseDecimal(val))
                Return Convert.ToDecimal(Math.Log10(valDouble))
            Catch ex As Exception
                Throw New Exception("LOG(" & GetStr(val) & "): " & ex.Message)
            End Try
        End Function

#End Region

#Region "Boolean Functions"

        ''' <summary>
        ''' Calculate the AND value of the input array
        ''' The value(s) can be specified as a decimal value (e.g., 37.48), 
        ''' as a string (“True”), as a Boolean (e.g., True), as an expression (e.g., 1+1=2), 
        ''' or as the value of a variable (e.g, UnitPrice).
        ''' </summary>
        ''' <param name="args">The array of booleans whose AND value is to be calculated</param>
        ''' <returns>The and value.</returns>
        Public Shared Function And1(ByVal ParamArray args As Object()) As Boolean
            Dim andValue As Boolean = True
            ' Iterate the loop to get the individual values from the group of parameters
            For Each booleanValue As Object In args
                If booleanValue IsNot Nothing Then
                    Try
                        andValue = andValue AndAlso Convert.ToBoolean(booleanValue.ToString())
                        If andValue = False Then
                            Return andValue
                        End If
                        'if a value is non-boolean, we will ignore this value.
                    Catch
                    End Try
                End If
            Next
            Return andValue
        End Function

        ''' <summary>
        ''' Calculate the OR value of the input array
        ''' The value(s) can be specified as a decimal value (e.g., 37.48), 
        ''' as a string (“True”), as a Boolean (e.g., True), as an expression (e.g., 1+1=2), 
        ''' or as the value of a variable (e.g, UnitPrice).
        ''' </summary>
        ''' <param name="args">The array of booleans whose OR value is to be calculated</param>
        ''' <returns>The or value.</returns>
        Public Shared Function Or1(ByVal ParamArray args As Object()) As Boolean
            Dim orValue As Boolean = False
            ' Iterate the loop to get the individual values from the group of parameters
            For Each booleanValue As Object In args
                If booleanValue IsNot Nothing Then
                    Try
                        orValue = orValue OrElse Convert.ToBoolean(booleanValue)
                        If orValue = True Then
                            Return orValue
                        End If
                        'if a value is non-boolean, we will ignore this value.
                    Catch
                    End Try
                End If
            Next
            Return orValue
        End Function

        ''' <summary>
        ''' Calculate the NOT value of the specified boolean value
        ''' The value(s) can be specified as a decimal value (e.g., 37.48), 
        ''' as a string (“True”), as a Boolean (e.g., True), as an expression (e.g., 1+1=2), 
        ''' or as the value of a variable (e.g, UnitPrice).
        ''' </summary>
        ''' <param name="value">The boolean value whose NOT is to be determined</param>
        ''' <returns>The not value.</returns>
        Public Shared Function Not1(ByVal value As Object) As Boolean
            Try
                Return Not Convert.ToBoolean(value)
            Catch ex As Exception
                Throw New Exception("NOT1(" & GetStr(value) & "): " & ex.Message)
            End Try
        End Function
#End Region

#Region "String Functions"

        ''' <summary>
        ''' Return a character for the corresponding ascii value
        ''' </summary>
        ''' <param name="val">Ascii Value</param>
        ''' <returns>Charcter for the corresponding ascii value</returns>
        Public Shared Function Character(ByVal val As Object) As Char
            Try
                Return Convert.ToChar(val)
            Catch ex As Exception
                Throw New Exception("CHARACTER(" & GetStr(val) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Check if two strings are exactly same or not
        ''' </summary>
        ''' <param name="val1">1st String</param>
        ''' <param name="val2">2nd String</param>
        ''' <returns>True if the two strings are exactly same else returns false</returns>
        Public Shared Function Exact(ByVal val1 As Object, ByVal val2 As Object) As Boolean
            Try
                val1 = GetStr(val1)
                val2 = GetStr(val2)
                If val1.Equals(val2) Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw New Exception("EXACT(" & GetStr(val1) & ", " & GetStr(val2) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Finds the index of the occurrence of the 1st string in the 2nd string specified
        ''' </summary>
        ''' <param name="val1">String to be searched</param>
        ''' <param name="val2">String to be searched in</param>
        ''' <returns>The index of the occurrence of the 1st string in the 2nd string and -1 if the string not found</returns>
        Public Shared Function Find(ByVal val1 As Object, ByVal val2 As Object) As Integer
            Dim val1String As String = String.Empty
            Dim val2String As String = String.Empty
            Try
                If val1 IsNot Nothing Then
                    val1String = val1.ToString()
                End If
                If val2 IsNot Nothing Then
                    val2String = val2.ToString()
                End If

                Return val2String.IndexOf(val1String, 0)
            Catch ex As Exception
                Throw New Exception("FIND(" & GetStr(val1) & ", " & GetStr(val2) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Find the index of the occurrence of the 1st string in the 2nd string,
        ''' the search starts after a specified start position
        ''' </summary>
        ''' <param name="val1">String to be searched</param>
        ''' <param name="val2">String to be searched in</param>
        ''' <param name="index">The position after which the search should start</param>
        ''' <returns>The index of the occurrence of the 1st string in the 2nd string and -1 if the string is not found</returns>
        Public Shared Function Find(ByVal val1 As Object, ByVal val2 As Object, ByVal index As Integer) As Integer
            Dim val1String As String = String.Empty
            Dim val2String As String = String.Empty
            Try
                If val1 IsNot Nothing Then
                    val1String = val1.ToString()
                End If
                If val2 IsNot Nothing Then
                    val2String = val2.ToString()
                End If

                Return val2String.IndexOf(val1String, index)
            Catch ex As Exception
                Throw New Exception("FIND(" & GetStr(val1) & ", " & GetStr(val2) & ", " & index & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Returns the string from left till the index mentioned
        ''' </summary>
        ''' <param name="str">String to be operated upon</param>
        ''' <param name="length">The length of string to be returned</param>
        ''' <returns>The string of specified length from the start</returns>
        Public Shared Function Left(ByVal str As Object, ByVal length As Integer) As String
            Dim inputString As String = String.Empty
            Try
                If str IsNot Nothing Then
                    inputString = str.ToString()
                End If

                Return inputString.Substring(0, length)
            Catch ex As Exception
                Throw New Exception("LEFT(" & GetStr(str) & ", " & length & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Returns the string from right till the index mentioned
        ''' </summary>
        ''' <param name="str">String to be operated upon</param>
        ''' <param name="length">The length of string to be returned</param>
        ''' <returns>The string of specified length from the end</returns>
        Public Shared Function Right(ByVal str As Object, ByVal length As Integer) As String
            Dim inputString As String = String.Empty
            Try
                If str IsNot Nothing Then
                    inputString = str.ToString()
                End If

                Return inputString.Substring(inputString.Length - length, length)
            Catch ex As Exception
                Throw New Exception("RIGHT(" & GetStr(str) & ", " & length & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Returns the left most character of the string
        ''' </summary>
        ''' <param name="str">String to be operated upon</param>
        ''' <returns>The first character of string</returns>
        Public Shared Function Left(ByVal str As Object) As String
            Dim inputString As String = String.Empty
            Try
                If str IsNot Nothing Then
                    inputString = str.ToString()
                End If
                Return inputString.Substring(0, 1)
            Catch ex As Exception
                Throw New Exception("LEFT(" & GetStr(str) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Returns the right most character of the string
        ''' </summary>
        ''' <param name="str">String to be operated upon</param>
        ''' <returns>The last character of a string</returns>
        Public Shared Function Right(ByVal str As Object) As String
            Dim inputString As String = String.Empty
            Try
                If str IsNot Nothing Then
                    inputString = str.ToString()
                End If
                Return inputString.Substring(inputString.Length - 1, 1)
            Catch ex As Exception
                Throw New Exception("RIGHT(" & GetStr(str) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Returns the length of the string
        ''' </summary>
        ''' <param name="str">String to be operated upon</param>
        ''' <returns>The length of the string</returns>
        Public Shared Function Len(ByVal str As Object) As Integer
            Dim inputString As String = String.Empty
            Try
                If str IsNot Nothing Then
                    inputString = str.ToString()
                End If
                Return inputString.Length
            Catch ex As Exception
                Throw New Exception("LEN(" & GetStr(str) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Converts the string to lower case 
        ''' </summary>
        ''' <param name="str">String to be operated upon</param>
        ''' <returns>The string which is lower case</returns>
        Public Shared Function Lower(ByVal str As Object) As String
            Dim inputString As String = String.Empty
            Try
                If str IsNot Nothing Then
                    inputString = str.ToString()
                End If
                Return inputString.ToLower()
            Catch ex As Exception
                Throw New Exception("LOWER(" & GetStr(str) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Converts the string to upper case
        ''' </summary>
        ''' <param name="str">String to be operated upon</param>
        ''' <returns>The string which is upper case</returns>
        Public Shared Function Upper(ByVal str As Object) As String
            Dim inputString As String = String.Empty
            Try
                If str IsNot Nothing Then
                    inputString = str.ToString()
                End If
                Return inputString.ToUpper()
            Catch ex As Exception
                Throw New Exception("UPPER(" & GetStr(str) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Retrieves the substring from the specified index and of specified length
        ''' </summary>
        ''' <param name="str">String to be operated upon</param>
        ''' <param name="startIndex">The start index of retrieval</param>
        ''' <param name="length">Length of the string to be retrieved</param>
        ''' <returns>The substring</returns>
        Public Shared Function Mid(ByVal str As Object, ByVal startIndex As Integer, ByVal length As Integer) As String
            Dim inputString As String = String.Empty
            Try
                If str IsNot Nothing Then
                    inputString = str.ToString()
                End If
                Return inputString.Substring(startIndex, length)
            Catch ex As Exception
                Throw New Exception("MID(" & GetStr(str) & ", " & startIndex & ", " & length & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Retrieves the substring from the specified index and of specified length
        ''' </summary>
        ''' <param name="str">String to be operated upon</param>
        ''' <param name="startIndex">The start index of retrieval</param>
        ''' <param name="length">Length of the string to be retrieved</param>
        ''' <returns>The substring</returns>
        Public Shared Function Substring(ByVal str As Object, ByVal startIndex As Integer, ByVal length As Integer) As String
            Dim inputString As String = String.Empty
            Try
                If str IsNot Nothing Then
                    inputString = str.ToString()
                End If
                Return inputString.Substring(startIndex, length)
            Catch ex As Exception
                Throw New Exception("SUBSTRING(" & GetStr(str) & ", " & startIndex & ", " & length & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Retrieves the substring from the specified index till the end of the string
        ''' </summary>
        ''' <param name="str">String to be operated upon</param>
        ''' <param name="startIndex">The start index of retrieval</param>
        ''' <returns>The substring</returns>
        Public Shared Function Substring(ByVal str As Object, ByVal startIndex As Integer) As String
            Dim inputString As String = String.Empty
            Try
                If str IsNot Nothing Then
                    inputString = str.ToString()
                End If
                ' As we are using a 1 based indexing we are using .Length 
                ' which returns the exact length
                Return inputString.Substring(startIndex, inputString.Length - startIndex)
            Catch ex As Exception
                Throw New Exception("SUBSTRING(" & GetStr(str) & ", " & startIndex & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Retrieves the substring from the specified index till the end of the string
        ''' </summary>
        ''' <param name="str">String to be operated upon</param>
        ''' <returns>The Capitalized string</returns>
        Public Shared Function Capitalize(ByVal str As Object) As String
            Dim inputString As String = String.Empty
            Try
                If str IsNot Nothing Then
                    inputString = str.ToString()
                End If
                ' As we are using a 1 based indexing we are using .Length 
                ' which returns the exact length
                Return inputString.Substring(0, 1).ToUpper() & inputString.Substring(1, inputString.Length - 1)
            Catch ex As Exception
                Throw New Exception("CAPITALIZE(" & GetStr(str) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Replaces the specified part of a string with a new string
        ''' </summary>
        ''' <param name="oldString">String to be operated upon</param>
        ''' <param name="startIndex">The start index of the part to be replaced</param>
        ''' <param name="length">The length of the part be replaced</param>
        ''' <param name="newString">The new string which replaces the old string.</param>
        ''' <returns>The string which is upper case</returns>
        Public Shared Function Replace(ByVal oldString As Object, ByVal startIndex As Integer, ByVal length As Integer, ByVal newString As Object) As String
            Dim inputString As String = String.Empty
            Try
                If oldString IsNot Nothing Then
                    inputString = oldString.ToString()
                End If
                ' We are using a 1 based indexing in this function
                Return inputString.Substring(0, startIndex) & newString.ToString() & inputString.Substring(startIndex + length)
            Catch ex As Exception
                Throw New Exception("REPLACE(" & GetStr(oldString) & ", " & startIndex & ", " & length & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Repeats the text specified number of times the specified part of a string with a new string
        ''' </summary>
        ''' <param name="text">Text to be operated</param>
        ''' <param name="numberOfTimes">The number of times text is to be repeated</param>
        ''' <returns>The string with repeatetive text in it</returns>
        Public Shared Function Rept(ByVal text As Object, ByVal numberOfTimes As Integer) As String
            Dim textStr As String = String.Empty
            Dim finalString As String = String.Empty
            Dim i As Integer = 0
            ' We are using a 1 based indexing in this function
            If text IsNot Nothing Then
                textStr = text.ToString()
            End If
            Try
                For i = 0 To numberOfTimes - 1
                    finalString = finalString & textStr
                Next
                Return finalString
            Catch ex As Exception
                Throw New Exception("REPT(" & GetStr(text) & ", " & numberOfTimes & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Concatenates the arguments in the array
        ''' </summary>
        ''' <param name="args">Array of arguments</param>
        ''' <returns>Concatenated string</returns>
        Public Shared Function Concatenate(ByVal ParamArray args As Object()) As String
            Dim finalString As String = String.Empty
            ' We are using a 1 based indexing in this function
            Try
                For Each str As Object In args
                    If str IsNot Nothing Then
                        finalString = finalString & str.ToString()
                    End If
                Next
                Return finalString
            Catch ex As Exception
                Throw New Exception("CONCATENATE(" & GetStr(args) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Trims the leading and trailing spaces
        ''' </summary>
        ''' <param name="str">String to be operated upon</param>
        ''' <returns>Trimmed string</returns>
        Public Shared Function Trim(ByVal str As Object) As String
            Try
                Dim finalString As String = String.Empty
                If str IsNot Nothing Then
                    finalString = str.ToString().Trim()
                End If
                Return finalString
            Catch ex As Exception
                Throw New Exception("TRIM(" & GetStr(str) & "): " & ex.Message)
            End Try
        End Function
#End Region

#Region "DateTime Functions"

        ''' <summary>
        ''' Retrieves the hours from the date
        ''' </summary>
        ''' <param name="valDate">The date to be operated upon</param>
        ''' <returns>The hour part of the date and if date is empty string then returns now's hours</returns>
        Public Shared Function Hour(ByVal valDate As Object) As Decimal
            Dim finalDate As New DateTime()
            Try
                If Not DateTime.TryParse(valDate.ToString(), finalDate) Then
                    Return DateTime.Now.Hour
                End If
                Return finalDate.Hour
            Catch ex As Exception
                Throw New Exception("HOUR(" & GetStr(valDate) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Retrieves the minutes from the date
        ''' </summary>
        ''' <param name="valDate">The date to be operated upon</param>
        ''' <returns>The minutes part of the date and if date is empty string then returns now's minute</returns>
        Public Shared Function Minute(ByVal valDate As Object) As Decimal
            Dim finalDate As New DateTime()
            Try
                If Not DateTime.TryParse(valDate.ToString(), finalDate) Then
                    Return DateTime.Now.Minute
                End If
                Return finalDate.Minute
            Catch ex As Exception
                Throw New Exception("MINUTE(" & GetStr(valDate) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Retrieves the years from the date
        ''' </summary>
        ''' <param name="valDate">The date to be operated upon</param>
        ''' <returns>The years part of the date and if date is empty string then returns today's year</returns>
        Public Shared Function Year(ByVal valDate As Object) As Decimal
            Dim finalDate As New DateTime()
            Try
                If Not DateTime.TryParse(valDate.ToString(), finalDate) Then
                    Return DateTime.Now.Year
                End If
                Return finalDate.Year
            Catch ex As Exception
                Throw New Exception("MINUTE(" & GetStr(valDate) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Retrieves the month from the date
        ''' </summary>
        ''' <param name="valDate">The date to be operated upon</param>
        ''' <returns>The month part of the date and if date is empty string then returns this month</returns>
        Public Shared Function Month(ByVal valDate As Object) As Decimal
            Dim finalDate As New DateTime()
            Try
                If Not DateTime.TryParse(valDate.ToString(), finalDate) Then
                    Return DateTime.Now.Month
                End If
                Return finalDate.Month
            Catch ex As Exception
                Throw New Exception("MONTH(" & GetStr(valDate) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Retrieves the day from the date
        ''' </summary>
        ''' <param name="valDate">The date to be operated upon</param>
        ''' <returns>The day of the date and if date is empty string then returns today's day</returns>
        Public Shared Function Day(ByVal valDate As Object) As Decimal
            Dim finalDate As New DateTime()
            Try
                If Not DateTime.TryParse(valDate.ToString(), finalDate) Then
                    Return DateTime.Now.Day
                End If
                Return finalDate.Day
            Catch ex As Exception
                Throw New Exception("Day(" & GetStr(valDate) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Retrieves the seconds from the date
        ''' </summary>
        ''' <param name="valDate">The date to be operated upon</param>
        ''' <returns>The seconds part of the date and if date is empty string then returns seconds now</returns>
        Public Shared Function Second(ByVal valDate As Object) As Decimal
            Dim finalDate As New DateTime()
            Try
                If Not DateTime.TryParse(valDate.ToString(), finalDate) Then
                    Return DateTime.Now.Second
                End If
                Return finalDate.Second
            Catch ex As Exception
                Throw New Exception("SECOND(" & GetStr(valDate) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Returns a datevalue specifying the hours minutes and seconds
        ''' </summary>
        ''' <param name="valHour">The hour to be operated upon</param>
        ''' <param name="valMinute">The minute to be operated upon</param>
        ''' <param name="valSecond">The second to be operated upon</param>
        ''' <returns>The seconds part of the date and if date is empty string then returns seconds now</returns>
        Public Shared Function Time1(ByVal valHour As Object, ByVal valMinute As Object, ByVal valSecond As Object) As DateTime

            Dim finalDate As DateTime
            finalDate = DateTime.Today

            Try
                finalDate = finalDate.AddHours(Convert.ToInt32(valHour))
                finalDate = finalDate.AddMinutes(Convert.ToInt32(valMinute))
                finalDate = finalDate.AddSeconds(Convert.ToInt32(valSecond))

                Return finalDate
            Catch ex As Exception
                Throw New Exception("TIME1(" & GetStr(valHour) & ", " & GetStr(valMinute) & ", " & GetStr(valSecond) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Returns today's date
        ''' </summary>
        ''' <returns>Today's date</returns>
        Public Shared Function Now() As DateTime
            Return DateTime.Now
        End Function

        ''' <summary>
        ''' Returns today's date
        ''' </summary>
        ''' <returns>Today's date</returns>
        Public Shared Function Today() As DateTime
            Return DateTime.Today
        End Function

        ''' <summary>
        ''' Retrieves yesterday's date
        ''' </summary>
        ''' <returns>Yesterday's date</returns>
        Public Shared Function Yesterday() As DateTime
            Return DateTime.Today.AddDays(-1)
        End Function

        ''' <summary>
        ''' Retrieve the date of start of the week
        ''' </summary>
        ''' <param name="valDate">The date to be operated upon</param>
        ''' <returns>The start date of the week</returns>
        Public Shared Function StartOfWeek(ByVal valDate As Object) As DateTime
            Dim inputDate As DateTime = DateTime.Today
            If Not DateTime.TryParse(valDate.ToString(), inputDate) Then
                inputDate = DateTime.Today
            End If
            inputDate = inputDate.AddDays(0 - Convert.ToDouble(inputDate.DayOfWeek))
            Return New DateTime(inputDate.Year, inputDate.Month, inputDate.Day, 0, 0, 0)
        End Function

        ''' <summary>
        ''' Retrieve the date of end of the week
        ''' </summary>
        ''' <param name="valDate">The date to be operated upon</param>
        ''' <returns>The end date of the week</returns>
        Public Shared Function EndOfWeek(ByVal valDate As Object) As DateTime
            Dim inputDate As DateTime = DateTime.Today
            If Not DateTime.TryParse(valDate.ToString(), inputDate) Then
                inputDate = DateTime.Today
            End If
            inputDate = inputDate.AddDays(6 - Convert.ToDouble(inputDate.DayOfWeek))
            Return New DateTime(inputDate.Year, inputDate.Month, inputDate.Day, 23, 59, 59)
        End Function

        ''' <summary>
        ''' Retrieve the start date of the current week
        ''' </summary>
        ''' <returns>The start date of the current week</returns>
        Public Shared Function StartOfCurrentWeek() As DateTime
            Dim inputDate As DateTime = DateTime.Today
            inputDate = inputDate.AddDays(0 - Convert.ToDouble(inputDate.DayOfWeek))
            Return New DateTime(inputDate.Year, inputDate.Month, inputDate.Day, 0, 0, 0)
        End Function

        ''' <summary>
        ''' Retrieve the end date of the current week
        ''' </summary>
        ''' <returns>The end date of the current week</returns>
        Public Shared Function EndOfCurrentWeek() As DateTime
            Dim inputDate As DateTime = DateTime.Today
            inputDate = inputDate.AddDays(6 - Convert.ToDouble(inputDate.DayOfWeek))
            Return New DateTime(inputDate.Year, inputDate.Month, inputDate.Day, 23, 59, 59)
        End Function

        ''' <summary>
        ''' Retrieve the start date of the previous week
        ''' </summary>
        ''' <returns>The start date of the previous week</returns>
        Public Shared Function StartOfLastWeek() As DateTime
            Dim inputDate As DateTime = DateTime.Today
            inputDate = inputDate.AddDays(-7 - Convert.ToDouble(inputDate.DayOfWeek))
            Return New DateTime(inputDate.Year, inputDate.Month, inputDate.Day, 0, 0, 0)
        End Function

        ''' <summary>
        ''' Retrieve the end date of the previous week
        ''' </summary>
        ''' <returns>The end date of the previous week</returns>
        Public Shared Function EndOfLastWeek() As DateTime
            Dim inputDate As DateTime = DateTime.Today
            inputDate = inputDate.AddDays(-1 - Convert.ToDouble(inputDate.DayOfWeek))
            Return New DateTime(inputDate.Year, inputDate.Month, inputDate.Day, 23, 59, 59)
        End Function

        ''' <summary>
        ''' Retrieve the start date of the month for the date passed
        ''' </summary>
        ''' <param name="valDate">The date whose start date of month is to be found</param>
        ''' <returns>The start date of the month</returns>
        Public Shared Function StartOfMonth(ByVal valDate As Object) As DateTime
            Dim inputDate As DateTime = DateTime.Today
            If Not DateTime.TryParse(valDate.ToString(), inputDate) Then
                inputDate = DateTime.Today
            End If
            Dim startDate As New DateTime(inputDate.Year, inputDate.Month, 1)
            Return startDate
        End Function

        ''' <summary>
        ''' Retrieve the end date of the month for the date passed
        ''' </summary>
        ''' <param name="valDate">The date whose end date of month is to be found</param>
        ''' <returns>The end date of the month</returns>
        Public Shared Function EndOfMonth(ByVal valDate As Object) As DateTime
            Dim inputDate As DateTime = DateTime.Today
            If Not DateTime.TryParse(valDate.ToString(), inputDate) Then
                inputDate = DateTime.Today
            End If
            Dim endDate As DateTime = inputDate.AddMonths(1)
            endDate = New DateTime(endDate.Year, endDate.Month, 1, 23, 59, 59).AddDays(-1)
            Return endDate
        End Function

        ''' <summary>
        ''' Retrieve the start date of the current month
        ''' </summary>
        ''' <returns>The start date of the current month</returns>
        Public Shared Function StartOfCurrentMonth() As DateTime
            Dim startDate As New DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)
            Return startDate
        End Function

        ''' <summary>
        ''' Retrieve the end date of the current month
        ''' </summary>
        ''' <returns>The end date of the current month</returns>
        Public Shared Function EndOfCurrentMonth() As DateTime
            Dim endDate As DateTime = DateTime.Today.AddMonths(1)
            endDate = New DateTime(endDate.Year, endDate.Month, 1, 23, 59, 59).AddDays(-1)
            Return endDate
        End Function

        ''' <summary>
        ''' Retrieve the start date of the last month
        ''' </summary>
        ''' <returns>The start date of the last month</returns>
        Public Shared Function StartOfLastMonth() As DateTime
            Dim prevMonthDate As DateTime = DateTime.Today.AddMonths(-1)
            Return New DateTime(prevMonthDate.Year, prevMonthDate.Month, 1)
        End Function

        ''' <summary>
        ''' Retrieve the end date of the last month
        ''' </summary>
        ''' <returns>The end date of the last month</returns>
        Public Shared Function EndOfLastMonth() As DateTime
            Dim endDate As DateTime = DateTime.Today
            endDate = New DateTime(DateTime.Today.Year, DateTime.Today.Month, 1, 23, 59, 59)
            endDate = endDate.AddDays(-1)
            Return endDate
        End Function

        ''' <summary>
        ''' Retrieve the start date of the quarter for the date passed
        ''' </summary>
        ''' <param name="valDate">The date whose start date of quarter is to be found</param>
        ''' <returns>The end date of the quarter</returns>
        Public Shared Function StartOfQuarter(ByVal valDate As Object) As DateTime
            Dim inputDate As DateTime = DateTime.Today
            If Not DateTime.TryParse(valDate.ToString(), inputDate) Then
                inputDate = DateTime.Today
            End If
            Dim quarter As Integer = (inputDate.Month - 1) \ 3 + 1
            Dim startQuarterDate As New DateTime(inputDate.Year, 3 * quarter - 2, 1)
            Return startQuarterDate
        End Function

        ''' <summary>
        ''' Retrieve the end date of the quarter for the date passed
        ''' </summary>
        ''' <param name="valDate">The date whose end date of quarter is to be found</param>
        ''' <returns>The end date of the quarter</returns>
        Public Shared Function EndOfQuarter(ByVal valDate As Object) As DateTime
            Dim inputDate As DateTime = DateTime.Today
            If Not DateTime.TryParse(valDate.ToString(), inputDate) Then
                inputDate = DateTime.Today
            End If
            Dim quarter As Integer = (inputDate.Month - 1) \ 3 + 1
            Dim quarterLastDate As DateTime = New DateTime(inputDate.Year, 3 * quarter, 1, 23, 59, 59).AddMonths(1).AddDays(-1)
            Return quarterLastDate
        End Function

        ''' <summary>
        ''' Retrieve the start date of the current quarter
        ''' </summary>
        ''' <returns>The start date of the current quarter</returns>
        Public Shared Function StartOfCurrentQuarter() As DateTime
            Dim dateToday As DateTime = DateTime.Today
            Dim currQuarter As Integer = (DateTime.Today.Month - 1) \ 3 + 1
            Dim dtFirstDay As New DateTime(DateTime.Today.Year, 3 * currQuarter - 2, 1)
            Return dtFirstDay
        End Function

        ''' <summary>
        ''' Retrieve the end date of the current quarter
        ''' </summary>
        ''' <returns>The end date of the current quarter</returns>
        Public Shared Function EndOfCurrentQuarter() As DateTime
            Dim dateToday As DateTime = DateTime.Today
            Dim currQuarter As Integer = (DateTime.Today.Month - 1) \ 3 + 1
            Dim quarterLastDate As DateTime = New DateTime(DateTime.Today.Year, 3 * currQuarter, 1, 23, 59, 59).AddMonths(1).AddDays(-1)
            Return quarterLastDate
        End Function

        ''' <summary>
        ''' Retrieve the start date of the last quarter
        ''' </summary>
        ''' <returns>The start date of the last quarter</returns>
        Public Shared Function StartOfLastQuarter() As DateTime
            Dim currQuarter As Integer = (DateTime.Today.Month - 1) \ 3 + 1
            Dim lastQuarterStartDate As DateTime = New DateTime(DateTime.Today.Year, 3 * currQuarter - 2, 1).AddMonths(-3)
            Return lastQuarterStartDate
        End Function

        ''' <summary>
        ''' Retrieve the end date of the last quarter
        ''' </summary>
        ''' <returns>The end date of the last quarter</returns>
        Public Shared Function EndOfLastQuarter() As DateTime
            Dim currQuarter As Integer = (DateTime.Today.Month - 1) \ 3 + 1
            Dim lastQuarterEndDate As DateTime = New DateTime(DateTime.Today.Year, 3 * currQuarter - 2, 1, 23, 59, 59).AddDays(-1)
            Return lastQuarterEndDate
        End Function

        ''' <summary>
        ''' Retrieve the start date of the year for the date passed
        ''' </summary>
        ''' <param name="valDate">The date whose start date of year is to be found</param>
        ''' <returns>The start date of the year</returns>
        Public Shared Function StartOfYear(ByVal valDate As Object) As DateTime
            Dim inputDate As DateTime = DateTime.Today
            If Not DateTime.TryParse(valDate.ToString(), inputDate) Then
                inputDate = DateTime.Today
            End If
            Dim dtFirstDate As New DateTime(inputDate.Year, 1, 1)
            Return dtFirstDate
        End Function

        ''' <summary>
        ''' Retrieve the end date of the year for the date passed
        ''' </summary>
        ''' <returns>The end date of the year</returns>
        Public Shared Function EndOfYear(ByVal valDate As Object) As DateTime
            Dim inputDate As DateTime = DateTime.Today
            If Not DateTime.TryParse(valDate.ToString(), inputDate) Then
                inputDate = DateTime.Today
            End If
            Dim dtLastDate As New DateTime(inputDate.Year, 12, 31, 23, 59, 59)
            Return dtLastDate
        End Function

        ''' <summary>
        ''' Retrieve the start date of the current year
        ''' </summary>
        ''' <returns>The start date of the current year</returns>
        Public Shared Function StartOfCurrentYear() As DateTime
            Dim dtFirstDay As New DateTime(DateTime.Today.Year, 1, 1)
            Return dtFirstDay
        End Function

        ''' <summary>
        ''' Retrieve the end date of the current year
        ''' </summary>
        ''' <returns>The end date of the current year</returns>
        Public Shared Function EndOfCurrentYear() As DateTime
            Dim dtLastDay As New DateTime(DateTime.Today.Year, 12, 31, 23, 59, 59)
            Return dtLastDay
        End Function

        ''' <summary>
        ''' Retrieve the start date of the last year
        ''' </summary>
        ''' <returns>The start date of the last year</returns>
        Public Shared Function StartOfLastYear() As DateTime
            Dim dtFirstDay As New DateTime(DateTime.Today.Year - 1, 1, 1)
            Return dtFirstDay
        End Function

        ''' <summary>
        ''' Retrieve the end date of the last year
        ''' </summary>
        ''' <returns>The end date of the last year</returns>
        Public Shared Function EndOfLastYear() As DateTime
            Dim dtFirstDay As New DateTime(DateTime.Today.Year - 1, 12, 31, 23, 59, 59)
            Return dtFirstDay
        End Function

#End Region

#Region "Format Functions"

        ''' <summary>
        ''' Formats the arguments according to the format string
        ''' </summary>
        ''' <param name="val">The value to be formatted</param>
        ''' <param name="formatString">The format string needed to specify the format type</param>
        ''' <returns>The formatted string</returns>
        Public Shared Function Format(ByVal val As Object, ByVal formatString As String) As String
            Dim valDecimal As Decimal = 0
            Dim valDate As DateTime = DateTime.Today
            If val Is Nothing Then
                Return String.Empty
            End If

            Try

                Try
                    valDecimal = StringUtils.ParseDecimal(val)
                    Return valDecimal.ToString(formatString)
                    ' Ignore
                Catch
                End Try

                If DateTime.TryParse(val.ToString(), valDate) Then
                    Return valDate.ToString(formatString)
                End If

                Return StringUtils.ParseDecimal(val).ToString(formatString)
            Catch
                Return val.ToString()
            End Try
        End Function
#End Region

#Region "Parse Functions"
        ''' <summary>
        ''' Converts the object to its Decimal equivalent.
        ''' </summary>
        ''' <param name="val">The value to be converted</param>
        ''' <returns>The converted value</returns>
        Public Shared Function ParseDecimal(ByVal val As Object) As Decimal
            Dim valDecimal As Decimal = 0
            Try
                valDecimal = StringUtils.ParseDecimal(val)
                Return valDecimal
            Catch ex As Exception
                Throw New Exception("PARSEDECIMAL(" & GetStr(val) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Converts the object to its integer equivalent.
        ''' </summary>
        ''' <param name="val">The value to be converted</param>
        ''' <returns>The converted value</returns>
        Public Shared Function ParseInteger(ByVal val As Object) As Integer
            Dim valDecimal As Integer = 0
            Try
                valDecimal = CInt(StringUtils.ParseDecimal(val))
                Return valDecimal
            Catch ex As Exception
                Throw New Exception("PARSEINTEGER(" & GetStr(val) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Converts the object to its date equivalent.
        ''' </summary>
        ''' <param name="val">The value to be converted</param>
        ''' <returns>The converted value.</returns>
        Public Shared Function ParseDate(ByVal val As Object) As DateTime
            Dim valDate As DateTime = DateTime.Today
            Try
                valDate = DateTime.Parse(val.ToString())
                Return valDate
            Catch ex As Exception
                Throw New Exception("PARSEDATE(" & GetStr(val) & "): " & ex.Message)
            End Try
        End Function
#End Region

#Region "Geolocation Functions"

#Region "Browser Location"

        ''' <summary>
        ''' Gets the current browser location
        ''' </summary>
        ''' <returns>Returns an XML string that is of the user’s location</returns>
        Public Shared Function GetBrowserLocation() As String
            Dim unit As String = GetDistanceUnit()

            Return GetBrowserLocation(unit)
        End Function

        ''' <summary>
        ''' Clears the browser location from session memory
        ''' </summary>
        Public Shared Function ClearBrowserLocation() As String
            Dim value As String = ""

            If System.Web.HttpContext.Current.Request.HttpMethod.ToUpperInvariant = "POST" Then
                Return ""
            End If

            System.Web.HttpContext.Current.Session(session_var_geo_location) = value

            System.Web.HttpContext.Current.Session(session_var_geo_clear_browser_location) = "True"

            Return value
        End Function

        ''' <summary>
        ''' Gets the default location from session variable
        ''' </summary>
        ''' <returns>Returns an XML string that is of the user’s location</returns>
        Public Shared Function GetDefaultLocation() As String
            Dim sessionVar As String = Session(session_var_geo_default_location)

            If sessionVar Is Nothing OrElse sessionVar = "" Then
                sessionVar = BuildLocation(BaseClasses.Configuration.ApplicationSettings.Current.DefaultLatitude, BaseClasses.Configuration.ApplicationSettings.Current.DefaultLongitude)

                System.Web.HttpContext.Current.Session(session_var_geo_default_location) = sessionVar
            End If

            Return sessionVar
        End Function

        ''' <summary>
        ''' Sets the default location in session variable
        ''' </summary>
        ''' <param name="location"> String containing the location in any of 3 formats: an XML location string , a latitude and longitude separated by a semicolon, or a street address.</param>
        Public Shared Function SetDefaultLocation(ByVal location As Object) As String
            Dim locationStr As String = ""

            Try
                locationStr = GetStr(location)

                System.Web.HttpContext.Current.Session(session_var_geo_default_location) = locationStr

                Return locationStr
            Catch ex As Exception
                Throw New Exception("SetDefaultLocation(" & Convert.ToString(location) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Gets the browser location from a hidden field "isd_geo_location". This field is present on a master page.
        ''' </summary>
        ''' <returns>Returns an XML string with location</returns>
        Public Shared Function GetBrowserLocationForHiddenField() As String
            Dim value As String = GetBrowserLocation("meters")

            System.Web.HttpContext.Current.Session(session_var_geo_location) = value

            System.Web.HttpContext.Current.Session(session_var_geo_clear_browser_location) = "False"

            Return value
        End Function

#End Region

#Region "Map Display"

        ''' <summary>
        ''' Provides a string of HTML for adding a hyperlink that gets a Google directions popup. Clicking on the map image will popup a window with Google maps.
        ''' </summary>
        ''' <param name="startLocation"> String containing the location in any of 3 formats: an XML location string , a latitude and longitude separated by a semicolon, or a street address</param>
        ''' <param name="endLocation"> String containing the location in any of 3 formats: an XML location string , a latitude and longitude separated by a semicolon, or a street address</param>
        ''' <returns>Returns a string of HTML</returns>
        Public Shared Function GoogleDirections(ByVal startLocation As Object, ByVal endLocation As Object) As String
            Return GoogleDirections(startLocation, endLocation, -1, -1, "")
        End Function

        ''' <summary>
        ''' Provides a string of HTML for adding a generated interactive map to a web page. The interactive map can be zoomed, etc., but clicking on it does not popup anything.
        ''' </summary>
        ''' <param name="location"> String containing the location in any of 3 formats: an XML location string , a latitude and longitude separated by a semicolon, or a street address</param>
        ''' <returns>Returns a string of HTML for adding a generated interactive map to a web page.</returns>
        Public Shared Function GoogleInteractiveMap(ByVal location As Object) As String
            Return CreateMap("interactive", location, -1, -1, -1, -1, GeoProviderType.Provider_Google, "", "")
        End Function

        ''' <summary>
        ''' Provides a string of HTML for adding a generated interactive map to a web page. 
        ''' </summary>
        ''' <param name="location"> String containing the location in any of 3 formats: an XML location string , a latitude and longitude separated by a semicolon, or a street address</param>
        ''' <returns>Returns a string of HTML for adding a generated map to a web page</returns>
        Public Shared Function GoogleMap(ByVal location As Object) As String
            Return CreateMap("staticimagewithpopup", location, -1, -1, -1, -1, GeoProviderType.Provider_Google, "", "")
        End Function

        ''' <summary>
        ''' Provides a string of HTML for adding a generated interactive map to a web page. 
        ''' </summary>
        ''' <param name="latitude"> A latitude value</param>
        ''' <param name="longitude"> A longitude value </param>
        ''' <returns>Returns a string of HTML for adding a generated map to a web page</returns>
        Public Shared Function GoogleMap(ByVal latitude As Object, ByVal longitude As Object) As String
            Dim latlng As String = latitude.ToString() & ";" & longitude.ToString()
            Return GoogleMap(CType(latlng, Object))
        End Function

        ''' <summary>
        ''' Provides a string of HTML for adding a hyperlink that gets a Google directions popup. Inside the hyperlink is an image that is a static map of the endLocation.
        ''' </summary>
        ''' <param name="startLocation"> String containing the location in any of 3 formats: an XML location string , a latitude and longitude separated by a semicolon, or a street address.</param>
        ''' <param name="endLocation"> String containing the location in any of 3 formats: an XML location string , a latitude and longitude separated by a semicolon, or a street address.</param>
        ''' <returns>Returns a string of HTML for adding a hyperlink that gets a Google directions popup</returns>
        Public Shared Function GoogleMapWithDirections(ByVal startLocation As Object, ByVal endLocation As Object) As String
            Return GoogleMapWithDirections(startLocation, endLocation, -1, -1, -1, -1, "", "")
        End Function

#End Region

#Region "Advanced Map Display"

        ''' <summary>
        ''' Provides a string of HTML for adding a hyperlink that gets a Google directions popup. Clicking on the map image will popup a window with Google maps.
        ''' </summary>
        ''' <param name="startLocation"> String containing the location in any of 3 formats: an XML location string , a latitude and longitude separated by a semicolon, or a street address.</param>
        ''' <param name="endLocation"> String containing the location in any of 3 formats: an XML location string , a latitude and longitude separated by a semicolon, or a street address.</param>
        ''' <param name="popupWidth"> Width of a popup window.</param>
        ''' <param name="popupHeight"> Height of a popup window.</param>
        ''' <param name="googleDirectionsParameters"> These are additional direction parameters. Values can be separated using ampersand character. Please check the following url for additional parameters https://developers.google.com/maps/documentation/staticmaps/</param>
        ''' <returns>Returns a string of HTML for adding a hyperlink that gets a Google directions popup. Clicking on the map image will popup a window with Google maps.</returns>
        Public Shared Function GoogleDirections(ByVal startLocation As Object, ByVal endLocation As Object, ByVal popupWidth As Object, ByVal popupHeight As Object, _
  ByVal googleDirectionsParameters As Object) As String
            Return CreateDirections(startLocation, endLocation, popupWidth, popupHeight, googleDirectionsParameters, "")
        End Function

        ''' <summary>
        ''' Provides a string of HTML for adding a generated interactive map to a web page.
        ''' </summary>
        ''' <param name="location"> String containing the location in any of 3 formats: an XML location string , a latitude and longitude separated by a semicolon, or a street address.</param>
        ''' <param name="width"> Integer width of map image or iframe. -1 will use the default value.</param>
        ''' <param name="height"> Integer height of map image or iframe. -1 will use the default value.</param>
        ''' <param name="googleMapParameters"> These are additional direction parameters. Values can be separated using ampersand character. Please check the following url for additional parameters https://developers.google.com/maps/documentation/staticmaps/</param>
        ''' <param name="googlePopupMapParameters"> These are additional direction parameters. Values can be separated using ampersand character. Please check the following url for additional parameters https://developers.google.com/maps/documentation/staticmaps/</param>
        ''' <returns> Returns a string of HTML for adding a generated interactive map to a web page.</returns>
        Public Shared Function GoogleMap(ByVal location As Object, _
                                         ByVal width As Object, _
                                         ByVal height As Object, _
                                         ByVal googleMapParameters As Object, _
                                         ByVal googlePopupMapParameters As Object) As String
            Return CreateMap("staticimagewithpopup", location, width, height, -1, -1, GeoProviderType.Provider_Google, googleMapParameters, googlePopupMapParameters)
        End Function

        ''' <summary>
        ''' Provides a URL for adding a generated map to a web page.
        ''' </summary>
        ''' <param name="location"> String containing the location in any of 3 formats: an XML location string , a latitude and longitude separated by a semicolon, or a street address.</param>
        ''' <param name="width"> Integer width of map image or iframe. -1 will use the default value.</param>
        ''' <param name="height"> Integer height of map image or iframe. -1 will use the default value.</param>
        ''' <param name="googleMapParameters"> These are additional direction parameters. Values can be separated using ampersand character. Please check the following url for additional parameters https://developers.google.com/maps/documentation/staticmaps/</param>
        ''' <returns> Returns a URL for adding a generated map to a web page.</returns>
        Public Shared Function GoogleMapURL(ByVal location As Object, _
                                            ByVal width As Object, _
                                            ByVal height As Object, _
                                            ByVal googleMapParameters As Object) As String
            Return CreateMap("staticimageurl", location, width, height, -1, -1, GeoProviderType.Provider_Google, googleMapParameters, "")
        End Function


        ''' <summary>
        ''' Provides a string of HTML for adding a generated interactive map to a web page. The interactive map can be zoomed, etc., but clicking on it does not popup anything.
        ''' </summary>
        ''' <param name="location"> String containing the location in any of 3 formats: an XML location string , a latitude and longitude separated by a semicolon, or a street address.</param>
        ''' <param name="width"> Integer width of map image or iframe. -1 will use the default value.</param>
        ''' <param name="height"> Integer height of map image or iframe. -1 will use the default value.</param>
        ''' <param name="googleMapParameters"> These are additional direction parameters. Values can be separated using ampersand character. Please check the following url for additional parameters https://developers.google.com/maps/documentation/staticmaps/</param>
        ''' <returns> Returns a string of HTML for adding a generated interactive map to a web page. </returns>
        Public Shared Function GoogleInteractiveMap(ByVal location As Object, ByVal width As Object, ByVal height As Object, ByVal googleMapParameters As Object) As String
            Return CreateMap("interactive", location, width, height, -1, -1, GeoProviderType.Provider_Google, googleMapParameters, "")
        End Function

        ''' <summary>
        ''' Provides a string of HTML for adding a generated interactive map to a web page. The interactive map can be zoomed, etc., but clicking on it does not popup anything.
        ''' </summary>
        ''' <param name="location"> String containing the location in any of 3 formats: an XML location string , a latitude and longitude separated by a semicolon, or a street address.</param>
        ''' <param name="width"> Integer width of map image or iframe. -1 will use the default value.</param>
        ''' <param name="height"> Integer height of map image or iframe. -1 will use the default value.</param>
        ''' <param name="googleMapParameters"> These are additional direction parameters. Values can be separated using ampersand character. Please check the following url for additional parameters https://developers.google.com/maps/documentation/staticmaps/</param>
        ''' <returns> Returns a string of HTML for adding a generated interactive map to a web page. </returns>
        Public Shared Function GoogleInteractiveMapURL(ByVal location As Object, ByVal width As Object, ByVal height As Object, ByVal googleMapParameters As Object) As String
            Return CreateMap("interactiveurl", location, width, height, -1, -1, GeoProviderType.Provider_Google, googleMapParameters, "")
        End Function

        ''' <summary>
        ''' Provides HTML string for adding a popup map to a web page.
        ''' </summary>
        ''' <param name="location"> String containing the location in any of 3 formats: an XML location string , a latitude and longitude separated by a semicolon, or a street address.</param>
        ''' <param name="width"> Integer width of map image or iframe. -1 will use the default value.</param>
        ''' <param name="height"> Integer height of map image or iframe. -1 will use the default value.</param>
        ''' <param name="popupWidth"> Width of a popup window.</param>
        ''' <param name="popupHeight"> Height of a popup window.</param>
        ''' <param name="googleMapParameters"> These are additional direction parameters. Values can be separated using ampersand character. Please check the following url for additional parameters https://developers.google.com/maps/documentation/staticmaps/</param>
        ''' <param name="googlePopupMapParameters"> These are additional direction parameters. Values can be separated using ampersand character. Please check the following url for additional parameters https://developers.google.com/maps/documentation/staticmaps/</param>
        ''' <returns>Returns HTML string for adding a popup map to a web page.</returns>
        Public Shared Function GooglePopupMapURL(ByVal location As Object, _
                                                 ByVal width As Object, _
                                                 ByVal height As Object, _
                                                 ByVal popupWidth As Object, _
                                                 ByVal popupHeight As Object, _
                                                 ByVal googleMapParameters As Object, _
                                                 ByVal googlePopupMapParameters As Object) As String
            Return CreateMap("popupurl", location, width, height, popupWidth, popupHeight, GeoProviderType.Provider_Google, googleMapParameters, googlePopupMapParameters)
        End Function

        ''' <summary>
        ''' Provides HTML string for adding a popup map including directions to a web page.
        ''' </summary>
        ''' <param name="startLocation"> String containing the location in any of 3 formats: an XML location string , a latitude and longitude separated by a semicolon, or a street address.</param>
        ''' <param name="endLocation"> String containing the location in any of 3 formats: an XML location string , a latitude and longitude separated by a semicolon, or a street address.</param>
        ''' <param name="width"> Integer width of map image or iframe. -1 will use the default value.</param>
        ''' <param name="height"> Integer height of map image or iframe. -1 will use the default value.</param>
        ''' <param name="popupWidth"> Width of a popup window.</param>
        ''' <param name="popupHeight"> Height of a popup window.</param>
        ''' <param name="googleMapParameters"> These are additional direction parameters. Values can be separated using ampersand character. Please check the following url for additional parameters https://developers.google.com/maps/documentation/staticmaps/</param>
        ''' <param name="googleDirectionsParameters"> These are additional direction parameters. Values can be separated using ampersand character. Please check the following url for additional parameters https://developers.google.com/maps/documentation/staticmaps/</param>
        ''' <returns>Returns HTML string for adding a popup map including directions to a web page.</returns>
        Public Shared Function GoogleMapWithDirections(ByVal startLocation As Object, _
                                                       ByVal endLocation As Object, _
                                                       ByVal width As Object, _
                                                       ByVal height As Object, _
                                                       ByVal popupWidth As Object, _
                                                       ByVal popupHeight As Object, _
                                                       ByVal googleMapParameters As Object, _
                                                       ByVal googleDirectionsParameters As Object) As String
            Dim mapHTML As String = CreateMap("staticimage", endLocation, width, height, popupWidth, popupHeight, GeoProviderType.Provider_Google, googleMapParameters, "")

            Return CreateDirections(startLocation, endLocation, popupWidth, popupHeight, googleDirectionsParameters, mapHTML)
        End Function


#End Region

#Region "Distance"

        ''' <summary>
        ''' Provides the decimal distance between two geographic points.
        ''' </summary>
        ''' <param name="startLocation"> String containing the location in any of 3 formats: an XML location string , a latitude and longitude separated by a semicolon, or a street address.</param>
        ''' <param name="endLocation"> String containing the location in any of 3 formats: an XML location string , a latitude and longitude separated by a semicolon, or a street address.</param>
        ''' <returns>Returns the decimal distance between two geographic points.</returns>
        Public Shared Function DistanceBetween(ByVal startLocation As Object, ByVal endLocation As Object) As Decimal
            Dim startLocationStr As String = ""
            Dim endLocationStr As String = ""

            Try
                startLocationStr = GetStr(startLocation)
                endLocationStr = GetStr(endLocation)

                startLocationStr = BuildLocation(startLocationStr)
                endLocationStr = BuildLocation(endLocationStr)

                Dim latitude1 As Decimal = LocationToLatitude(startLocationStr)

                If IsInvalidOrdinate(latitude1) Then
                    Return latitude1
                End If

                Dim longitude1 As Decimal = LocationToLongitude(startLocationStr)

                If IsInvalidOrdinate(longitude1) Then
                    Return longitude1
                End If

                Dim latitude2 As Decimal = LocationToLatitude(endLocationStr)

                If IsInvalidOrdinate(latitude2) Then
                    Return latitude2
                End If

                Dim longitude2 As Decimal = LocationToLongitude(endLocationStr)

                If IsInvalidOrdinate(longitude2) Then
                    Return longitude2
                End If

                FixUpLatitude(latitude1)
                FixUpLatitude(latitude2)

                FixUpLongitude(longitude1)
                FixUpLongitude(longitude2)

                Dim earthRadius As Double = GetEarthRadius()

                Dim degreesToRadians As Decimal = Pi() / 180D
                Dim radianToDegrees As Decimal = 180 / Pi()

                Dim doubleLat1 As Double = Convert.ToDouble(latitude1) * Convert.ToDouble(degreesToRadians)
                Dim doubleLon1 As Double = Convert.ToDouble(longitude1) * Convert.ToDouble(degreesToRadians)
                Dim doubleLat2 As Double = Convert.ToDouble(latitude2) * Convert.ToDouble(degreesToRadians)
                Dim doubleLon2 As Double = Convert.ToDouble(longitude2) * Convert.ToDouble(degreesToRadians)

                Dim distance As Double = Math.Sqrt(Math.Pow((doubleLon2 - doubleLon1) * Math.Cos((doubleLat1 + doubleLat2) / 2), 2) + Math.Pow(doubleLat2 - doubleLat1, 2)) * earthRadius

                Return Convert.ToDecimal(distance)

                ' Dim distance As Double = Math.Sqrt(Math.Pow(dLat, 2) + Math.Pow(dLon, 2)) * earthRadius

                'Dim dLat As Double = (doubleLat2 - doubleLat1)
                'Dim dLon As Double = (doubleLon2 - doubleLon1)

                ' uses haversine formula to calculate distance
                'Dim a As Double = Math.Pow(Math.Sin(dLat / 2.0), 2.0) + (Math.Cos(doubleLat1) * Math.Cos(doubleLat2)) * Math.Pow(Math.Sin(dLon / 2.0), 2.0)
                'Dim c As Double = 2.0 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1.0 - a))
                'Dim d As Double = earthRadius * c

                'Return Convert.ToDecimal(d)
            Catch ex As Exception
                Throw New Exception("DistanceBetween(" & Convert.ToString(startLocation) & ", " & Convert.ToString(endLocation) & "): " & ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Provides the decimal latitude or longitude of the edges of a 2-dimensional square that circumscribes a circle of a given radius from a given origin (altitude, speed, and bearing are ignored). This is useful for quickly approximating whether a group of points are within a distance of an origin. If direction parameter is set to south or north then a decimal latitude is returned. If the direction parameter is set to east or west then a decimal longitude is returned.
        ''' </summary>
        ''' <param name="location"> String containing the location in any of 3 formats: an XML location string , a latitude and longitude separated by a semicolon, or a street address.</param>
        ''' <param name="radius"> Decimal distance from the origin. </param>
        ''' <param name="direction"> String direction (north, south, east, west) of the edge of the bounding box to be returned. </param>
        ''' <returns>Returns the decimal latitude or longitude of the edges of a 2-dimensional square.</returns>
        Public Shared Function BoundingBoxEdge(ByVal location As Object, ByVal radius As Object, ByVal direction As Object) As Decimal
            Dim locationStr As String = ""
            Dim radiusDecimal As Decimal = 0D
            Dim directionStr As String = ""

            Try
                locationStr = GetStr(location)
                radiusDecimal = StringUtils.ParseDecimal(radius)
                directionStr = GetStr(direction)

                locationStr = BuildLocation(locationStr)

                If radiusDecimal < 0D Then
                    radiusDecimal = 0D
                End If

                Dim unit As String = GetDistanceUnit()
                Dim lowerDirection As String = directionStr.ToLowerInvariant()
                Dim earthRadius As Double = GetEarthRadius()
                Dim latitude As Decimal = LocationToLatitude(locationStr)
                Dim longitude As Decimal = LocationToLongitude(locationStr)

                FixUpLatitude(latitude)
                FixUpLongitude(longitude)

                Dim changeInLatitude As Double = (Convert.ToDouble(radiusDecimal) / earthRadius) * radiansToDegrees
                Dim radiusOfCircleAtLatitude As Double = earthRadius * Math.Cos(Convert.ToDouble(latitude) * degreesToRadians)
                Dim changeInLongitude As Double = (Convert.ToDouble(radiusDecimal) / radiusOfCircleAtLatitude) * radiansToDegrees

                Dim result As Double = 0.0

                If lowerDirection.StartsWith("north") Then
                    result = Convert.ToDouble(latitude) + changeInLatitude
                    If result > 90.0 Then
                        result = 90.0
                    End If
                ElseIf lowerDirection.StartsWith("south") Then
                    result = Convert.ToDouble(latitude) - changeInLatitude
                    If result < -90.0 Then
                        result = -90.0
                    End If
                ElseIf lowerDirection.StartsWith("east") Then
                    result = Convert.ToDouble(longitude) + changeInLongitude
                    If result > 180.0 Then
                        result = 180.0
                    End If
                ElseIf lowerDirection.StartsWith("west") Then
                    result = Convert.ToDouble(longitude) - changeInLongitude
                    If result < -180.0 Then
                        result = -180.0
                    End If
                Else
                    Throw New Exception("BoundingBoxEdge has invalid direction parameter")
                End If

                Return Convert.ToDecimal(result)
            Catch ex As Exception
                Throw New Exception("BoundingBoxEdge(" & Convert.ToString(location) & ", " & Convert.ToString(radius) & ", " & Convert.ToString(direction) & "): " & ex.Message)
            End Try
        End Function


        ''' <summary>
        ''' Provides a boolean based on whether two geographic points are within a given radius.
        ''' </summary>
        ''' <param name="startLocation"> String containing the location in any of 3 formats: an XML location string , a latitude and longitude separated by a semicolon, or a street address.</param>
        ''' <param name="endLocation"> String containing the location in any of 3 formats: an XML location string , a latitude and longitude separated by a semicolon, or a street address.</param>
        ''' <param name="radius"> Decimal distance from the origin. </param>
        ''' <returns>Returns a boolean based on whether two geographic points are within a given radius.</returns>
        Public Shared Function IsWithinRadius(ByVal startLocation As Object, ByVal endLocation As Object, ByVal radius As Object) As Boolean
            Dim startLocationStr As String = ""
            Dim endLocationStr As String = ""
            Dim radiusDecimal As Decimal = 0D

            Try
                startLocationStr = GetStr(startLocation)
                endLocationStr = GetStr(endLocation)
                radiusDecimal = StringUtils.ParseDecimal(radius)

                If radiusDecimal < 0D Then
                    Throw New Exception("Negative radius in IsWithinRadius(" & startLocation.ToString & ", " & endLocation.ToString & ", " & radius.ToString & "): ")
                End If

                startLocationStr = BuildLocation(startLocationStr)
                endLocationStr = BuildLocation(endLocationStr)

                Dim dist As Decimal = DistanceBetween(startLocationStr, endLocationStr)

                If dist < 0D Then
                    Return False
                End If

                Return (dist <= radiusDecimal)
            Catch ex As Exception
                Throw New Exception("IsWithinRadius(" & Convert.ToString(startLocation) & ", " & Convert.ToString(endLocation) & ", " & Convert.ToString(radius) & "): " & ex.Message)
            End Try

        End Function
#End Region

#Region "Conversion"

        ''' <summary>
        ''' Provides a boolean based on whether location string contains a specified address component
        ''' </summary>
        ''' <param name="location"> String containing the location in any of 3 formats: an XML location string , a latitude and longitude separated by a semicolon, or a street address.</param>
        ''' <param name="componentToCheck"> String specifying the component to check like latitude, longitude or address within xml string. </param>
        ''' <returns>Returns a boolean based on whether location string contains a specified address component.</returns>
        Public Shared Function IsInLocation(ByVal location As Object, ByVal componentToCheck As Object) As Boolean
            Dim locationStr As String = ""
            Dim componentToCheckStr As String = ""

            Try
                locationStr = GetStr(location)
                componentToCheckStr = GetStr(componentToCheck)

                locationStr = BuildLocation(locationStr)

                Dim returnValue As String = ""
                Dim componentLower As String = componentToCheckStr.ToLowerInvariant()
                Dim xDoc As New XmlDocument()

                If locationStr.Trim().Length > 0 Then
                    xDoc.LoadXml(locationStr)

                    Dim name As XmlNodeList = xDoc.GetElementsByTagName(componentLower)

                    If name IsNot Nothing AndAlso name.Count > 0 Then
                        Return True
                    End If
                End If

                Return False
            Catch ex As Exception
                Throw New Exception("IsInLocation(" & Convert.ToString(location) & ", " & Convert.ToString(componentToCheck) & "): " & ex.Message)
            End Try

        End Function

        ''' <summary>
        ''' Provides the address component as a string. Reverse geocodes as necessary.
        ''' </summary>
        ''' <param name="location"> String containing the location in any of 3 formats: an XML location string , a latitude and longitude separated by a semicolon, or a street address.</param>
        ''' <returns>Returns the address component as a string.</returns>
        Public Shared Function LocationToAddress(ByVal location As Object) As String
            Return LocationToOther(location, "address")
        End Function


        ''' <summary>
        ''' Provides the latitude component as a string. 
        ''' </summary>
        ''' <param name="location"> String containing the location in any of 3 formats: an XML location string , a latitude and longitude separated by a semicolon, or a street address.</param>
        ''' <returns>Returns the latitude component as a string.</returns>
        Public Shared Function LocationToLatitude(ByVal location As Object) As Decimal
            Return LocationToOtherNumber(location, "latitude")
        End Function

        ''' <summary>
        ''' Provides the longitude component as a string. 
        ''' </summary>
        ''' <param name="location"> String containing the location in any of 3 formats: an XML location string , a latitude and longitude separated by a semicolon, or a street address.</param>
        ''' <returns>Returns the longitude component as a string.</returns>
        Public Shared Function LocationToLongitude(ByVal location As Object) As Decimal
            Return LocationToOtherNumber(location, "longitude")
        End Function

        ''' <summary>
        ''' Provides a specified address component as a string. 
        ''' </summary>
        ''' <param name="location"> String containing the location in any of 3 formats: an XML location string , a latitude and longitude separated by a semicolon, or a street address.</param>
        ''' <param name="componentToExtract"> String specifying the component to check like latitude, longitude or address within xml string. </param>
        ''' <returns>Returns a specified address component as a string.</returns>
        Public Shared Function LocationToOther(ByVal location As Object, ByVal componentToExtract As Object) As String
            Dim locationStr As String = ""
            Dim componentToExtractStr As String = ""

            Try
                locationStr = GetStr(location)
                componentToExtractStr = GetStr(componentToExtract)

                locationStr = BuildLocation(locationStr)

                Dim returnValue As String = ""
                Dim componentLower As String = componentToExtractStr.ToLowerInvariant()
                Dim xDoc As New XmlDocument()

                If locationStr.Trim().Length > 0 Then
                    xDoc.LoadXml(locationStr)

                    Dim name As XmlNodeList = xDoc.GetElementsByTagName(componentLower)

                    If name IsNot Nothing AndAlso name.Count > 0 Then
                        Dim itm As XmlNode = name.Item(0)

                        returnValue = HttpUtility.UrlDecode(itm.InnerXml)
                    ElseIf componentLower = "latitude" OrElse componentLower = "longitude" OrElse componentLower = "address" Then
                        If (IsInLocation(locationStr, "latitude") AndAlso IsInLocation(locationStr, "longitude")) OrElse IsInLocation(locationStr, "address") Then
                            ' Geocode to add missing component
                            locationStr = GoogleGeocode(locationStr)
                            xDoc.LoadXml(locationStr)

                            name = xDoc.GetElementsByTagName(componentLower)

                            If name IsNot Nothing AndAlso name.Count > 0 Then
                                Dim itm As XmlNode = name.Item(0)

                                returnValue = HttpUtility.UrlDecode(itm.InnerXml)
                            Else
                                Return LocationToOther(locationStr, "error")
                            End If
                        End If
                    End If
                End If

                Return returnValue
            Catch ex As Exception
                Throw New Exception("LocationToOther(" & Convert.ToString(location) & ", " & Convert.ToString(componentToExtract) & "): " & ex.Message)
            End Try

        End Function


        Public Shared Function LocationToOtherNumber(ByVal location As Object, ByVal componentToExtract As Object) As Decimal
            Dim locationStr As String = ""
            Dim componentToExtractStr As String = ""

            Try
                locationStr = GetStr(location)
                componentToExtractStr = GetStr(componentToExtract)

                locationStr = BuildLocation(locationStr)

                Dim returnValue As Decimal = BaseClasses.Web.UI.BasePage.GEO_LOCATION_INVALID_ORDINATE
                Dim componentLower As String = componentToExtractStr.ToLowerInvariant()
                Dim value As String = LocationToOther(locationStr, componentToExtractStr)

                If componentLower.StartsWith("unit") Then
                    Dim kindOfUnit As GeoUnitType = GetUnitType(value)

                    Select Case kindOfUnit
                        Case GeoUnitType.Unit_NauticalMiles
                            returnValue = 1D
                            Exit Select
                        Case GeoUnitType.Unit_Miles
                            returnValue = 2D
                            Exit Select
                        Case GeoUnitType.Unit_Yards
                            returnValue = 3D
                            Exit Select
                        Case GeoUnitType.Unit_Feet
                            returnValue = 4D
                            Exit Select
                        Case GeoUnitType.Unit_Kilometers
                            returnValue = 10D
                            Exit Select
                        Case GeoUnitType.Unit_Meters
                            returnValue = 11D
                            Exit Select
                    End Select
                Else
                    Try
                        If value.Trim() = "" OrElse value.StartsWith("LOCATION_ERROR_") Then
                            returnValue = BaseClasses.Web.UI.BasePage.GEO_LOCATION_CANNOT_GEOCODE
                        Else
                            returnValue = StringUtils.ParseDecimal(value.Trim())
                        End If
                    Catch
                    End Try
                End If

                Return returnValue
            Catch ex As Exception
                Throw New Exception("LocationToOtherNumber(" & Convert.ToString(location) & ", " & Convert.ToString(componentToExtract) & "): " & ex.Message)
            End Try

        End Function


        ''' <summary>
        '''  Converts from degrees-minutes-seconds format into decimal degrees format. Applies to both latitude and longitude. Returns a decimal value.
        ''' </summary>
        ''' <param name="degrees"> Decimal value, should only be integer.</param>
        ''' <param name="minutes"> Decimal value, should only be integer.</param>
        ''' <param name="seconds"> Decimal value. </param>
        ''' <returns>Returns decimal degrees from degrees-minutes-seconds format.</returns>
        Public Shared Function DegreesMinSecToDecimal(ByVal degrees As Object, ByVal minutes As Object, ByVal seconds As Object) As Decimal
            Dim degreesDecimal As Decimal = 0D
            Dim minutesDecimal As Decimal = 0D
            Dim secondsDecimal As Decimal = 0D

            Try
                degreesDecimal = StringUtils.ParseDecimal(degrees)
                minutesDecimal = StringUtils.ParseDecimal(minutes)
                secondsDecimal = StringUtils.ParseDecimal(seconds)

                Dim ordinate As Decimal = degreesDecimal

                ordinate = ordinate + minutesDecimal / 60D
                ordinate = ordinate + secondsDecimal / 3600D

                Return ordinate
            Catch ex As Exception
                Throw New Exception("DegreesMinSecToDecimal(" & Convert.ToString(degrees) & ", " & Convert.ToString(minutes) & ", " & Convert.ToString(seconds) & "): " & ex.Message)
            End Try

        End Function

        ''' <summary>
        '''  Converts decimal ordinate to degrees from degrees-minutes-seconds format. Works for both longitude and latitude.
        ''' </summary>
        ''' <param name="ordinate"> Decimal value, either a latitude or longitude.</param>
        ''' <returns>Returns decimal ordinate to degrees from degrees-minutes-seconds format.</returns>
        Public Shared Function DecimalToDegrees(ByVal ordinate As Object) As Decimal
            Return DecimalToDegreesMinSec(ordinate, "degrees")
        End Function

        ''' <summary>
        '''  Converts decimal ordinate to minutes from degrees-minutes-seconds format. Works for both longitude and latitude.
        ''' </summary>
        ''' <param name="ordinate"> Decimal value, either a latitude or longitude.</param>
        ''' <returns>Returns decimal ordinate to minutes from degrees-minutes-seconds format..</returns>
        Public Shared Function DecimalToMinutes(ByVal ordinate As Object) As Decimal
            Return DecimalToDegreesMinSec(ordinate, "minutes")
        End Function

        ''' <summary>
        '''  Converts decimal ordinate to seconds from degrees-minutes-seconds format. Works for both longitude and latitude.
        ''' </summary>
        ''' <param name="ordinate"> Decimal value, either a latitude or longitude.</param>
        ''' <returns>Returns decimal ordinate to seconds from degrees-minutes-seconds format.</returns>
        Public Shared Function DecimalToSeconds(ByVal ordinate As Object) As Decimal
            Return DecimalToDegreesMinSec(ordinate, "seconds")
        End Function

        ''' <summary>
        '''  Provides a string representation of the default distance unit: (nautical miles, miles, yards, feet, kilometers, or meters). The value initially comes from web.config but is stored in session. Note that for the hidden field with the geolocation in web pages, the unit used is always meters regardless of the distance unit.
        ''' </summary>
        ''' <returns>Returns  a string representation of the default distance unit: (nautical miles, miles, yards, feet, kilometers, or meters).</returns>
        Public Shared Function GetDistanceUnit() As String
            Dim sessionVar As String = Session(session_var_geo_unit)

            If sessionVar Is Nothing OrElse sessionVar = "" Then
                sessionVar = BaseClasses.Configuration.ApplicationSettings.Current.DefaultDistanceUnit

                If sessionVar = "" Then
                    sessionVar = "kilometers"
                End If

                ' Validate unit
                Dim kindOfUnit As GeoUnitType = GetUnitType(sessionVar)

                System.Web.HttpContext.Current.Session(session_var_geo_unit) = sessionVar
            End If

            Return sessionVar
        End Function

        ''' <summary>
        '''  Sets the default distance unit in session memory.
        ''' </summary>
        ''' <param name="unit"> String containing the new default distance unit (nautical miles, miles, yards, feet, kilometers, or meters) </param>
        ''' <returns>Returns a string representation of the default distance unit: (nautical miles, miles, yards, feet, kilometers, or meters).</returns>
        Public Shared Function SetDistanceUnit(ByVal unit As Object) As String
            Dim unitStr As String = ""

            Try
                unitStr = GetStr(unit)

                ' Validate unit
                Dim kindOfUnit As GeoUnitType = GetUnitType(unitStr)

                System.Web.HttpContext.Current.Session(session_var_geo_unit) = unit

                Return unitStr
            Catch ex As Exception
                Throw New Exception("SetDistanceUnit(" & Convert.ToString(unit) & "): " & ex.Message)
            End Try

        End Function


        ''' <summary>
        '''  Performs geocoding or reverse geocoding and returns latitude, longitude, address values in xml format as a string
        ''' </summary>
        ''' <param name="location"> String as a location in xml format. </param>
        ''' <returns>Returns geocoding values as a string in xml format. </returns>
        Public Shared Function GoogleGeocode(ByVal location As Object) As String
            Dim locationStr As String = ""

            Try
                locationStr = GetStr(location)

                locationStr = BuildLocation(locationStr)

                Return Geocode(locationStr, GeoProviderType.Provider_Google)
            Catch ex As Exception
                Throw New Exception("GoogleGeocode(" & Convert.ToString(location) & "): " & ex.Message)
            End Try

        End Function

        ''' <summary>
        '''  Builds a location string.
        ''' </summary>
        ''' <param name="addressOrLatLong"> String containing address or latitude and longitude </param>
        ''' <returns> Returns xml structure for address as a string. </returns>
        Public Shared Function BuildLocation(ByVal addressOrLatLong As Object) As String
            Dim addressOrLatLongStr As String = ""

            Try
                addressOrLatLongStr = GetStr(addressOrLatLong)

                Dim location As New StringBuilder("", 300)
                Dim lowerAddressOrLatLong As String = addressOrLatLongStr.ToLowerInvariant()
                Dim lettersArray() As Char = "abcdefghijklmnopqrstuvwxyz".ToCharArray()

                If lowerAddressOrLatLong.Contains("<location>") Then
                    Return addressOrLatLongStr
                ElseIf lowerAddressOrLatLong.IndexOfAny(lettersArray) >= 0 Then
                    SetLocationTag(location, "address", addressOrLatLongStr)

                    Return location.ToString()
                Else
                    Dim pieces() As String = addressOrLatLongStr.Split(";"c)

                    If pieces.Length >= 2 Then
                        Try
                            Dim latitude As Decimal = StringUtils.ParseDecimal(pieces(0))
                            Dim longitude As Decimal = StringUtils.ParseDecimal(pieces(1))

                            SetLocationTag(location, "latitude", latitude.ToString())
                            SetLocationTag(location, "longitude", longitude.ToString())
                        Catch ex As Exception
                            Throw New Exception("Invalid lat/long for BuildLocation: " & ex.Message)
                        End Try
                    End If

                    Return location.ToString()
                End If
            Catch ex As Exception
                Throw New Exception("BuildLocation(" & Convert.ToString(addressOrLatLong) & "): " & ex.Message)
            End Try

        End Function

        ''' <summary>
        '''  Builds a location string.
        ''' </summary>
        ''' <param name="street"> String containing street </param>
        ''' <param name="city"> String containing city </param>
        ''' <param name="region"> String containing region </param>
        ''' <param name="postalCode"> String containing postalCode </param>
        ''' <param name="country"> String containing country </param>
        ''' <returns> Returns xml structure for address as a string. </returns>
        Public Shared Function BuildLocation(ByVal street As Object, ByVal city As Object, ByVal region As Object, _
  ByVal postalCode As Object, ByVal country As Object) As String
            Dim streetStr As String = ""
            Dim cityStr As String = ""
            Dim regionStr As String = ""
            Dim postalCodeStr As String = ""
            Dim countryStr As String = ""

            Try
                streetStr = GetStr(street)
                cityStr = GetStr(city)
                regionStr = GetStr(region)
                postalCodeStr = GetStr(postalCode)
                countryStr = GetStr(country)

                Dim location As New StringBuilder("", 300)
                Dim str As New StringBuilder("", 300)

                If streetStr <> "" Then
                    If str.Length > 0 Then
                        str.Append(" ")
                    End If
                    str.Append(streetStr)
                End If

                If cityStr <> "" Then
                    If str.Length > 0 Then
                        str.Append(", ")
                    End If
                    str.Append(cityStr)
                End If

                If regionStr <> "" Then
                    If str.Length > 0 Then
                        str.Append(", ")
                    End If
                    str.Append(regionStr)
                End If

                If postalCodeStr <> "" Then
                    If str.Length > 0 Then
                        str.Append(" ")
                    End If
                    str.Append(postalCodeStr)
                End If

                If countryStr <> "" Then
                    If str.Length > 0 Then
                        str.Append(", ")
                    End If
                    str.Append(countryStr)
                End If

                SetLocationTag(location, "address", str.ToString())

                Return str.ToString()
            Catch ex As Exception
                Throw New Exception("BuildLocation(" & Convert.ToString(street) & ", " & Convert.ToString(city) & ", " & Convert.ToString(region) & ", " & Convert.ToString(postalCode) & ", " & Convert.ToString(country) & "): " & ex.Message)
            End Try

        End Function

        ''' <summary>
        '''  Builds a location string.
        ''' </summary>
        ''' <param name="latitude"> String containing latitude </param>
        ''' <param name="longitude"> String containing longitude </param>
        ''' <returns> Returns xml structure for address as a string. </returns>
        Public Shared Function BuildLocation(ByVal latitude As Object, ByVal longitude As Object) As String
            Return BuildLocation(latitude, longitude, BaseClasses.Web.UI.BasePage.GEO_LOCATION_INVALID_ORDINATE, BaseClasses.Web.UI.BasePage.GEO_LOCATION_INVALID_ORDINATE, BaseClasses.Web.UI.BasePage.GEO_LOCATION_INVALID_ORDINATE, BaseClasses.Web.UI.BasePage.GEO_LOCATION_INVALID_ORDINATE, _
             BaseClasses.Web.UI.BasePage.GEO_LOCATION_INVALID_ORDINATE)
        End Function

        ''' <summary>
        '''  Builds a location string.
        ''' </summary>
        ''' <param name="latitude"> String containing latitude </param>
        ''' <param name="longitude"> String containing longitude </param>
        ''' <param name="altitude"> String containing altitude </param>
        ''' <param name="speed"> String containing speed </param>
        ''' <param name="heading"> String containing heading </param>
        ''' <param name="accuracy"> String containing accuracy </param>
        ''' <param name="altitudeAccuracy"> String containing altitudeAccuracy </param>
        ''' <returns> Returns xml structure for address as a string. </returns>
        Public Shared Function BuildLocation(ByVal latitude As Object, ByVal longitude As Object, ByVal altitude As Object, ByVal speed As Object, _
   ByVal heading As Object, ByVal accuracy As Object, _
         ByVal altitudeAccuracy As Object) As String
            Dim latitudeDecimal As Decimal = BaseClasses.Web.UI.BasePage.GEO_LOCATION_INVALID_ORDINATE
            Dim longitudeDecimal As Decimal = BaseClasses.Web.UI.BasePage.GEO_LOCATION_INVALID_ORDINATE
            Dim altitudeDecimal As Decimal = BaseClasses.Web.UI.BasePage.GEO_LOCATION_INVALID_ORDINATE
            Dim speedDecimal As Decimal = BaseClasses.Web.UI.BasePage.GEO_LOCATION_INVALID_ORDINATE
            Dim headingDecimal As Decimal = BaseClasses.Web.UI.BasePage.GEO_LOCATION_INVALID_ORDINATE
            Dim accuracyDecimal As Decimal = BaseClasses.Web.UI.BasePage.GEO_LOCATION_INVALID_ORDINATE
            Dim altitudeAccuracyDecimal As Decimal = BaseClasses.Web.UI.BasePage.GEO_LOCATION_INVALID_ORDINATE

            Try
                latitudeDecimal = StringUtils.ParseDecimal(latitude)
                longitudeDecimal = StringUtils.ParseDecimal(longitude)
                altitudeDecimal = StringUtils.ParseDecimal(altitude)
                speedDecimal = StringUtils.ParseDecimal(speed)
                headingDecimal = StringUtils.ParseDecimal(heading)
                accuracyDecimal = StringUtils.ParseDecimal(accuracy)
                altitudeAccuracyDecimal = StringUtils.ParseDecimal(altitudeAccuracy)

                Dim unit As String = GetDistanceUnit()
                Dim location As New StringBuilder("", 300)

                If Not IsInvalidOrdinate(latitudeDecimal) Then
                    SetLocationTag(location, "latitude", latitudeDecimal.ToString())
                End If

                If Not IsInvalidOrdinate(longitudeDecimal) Then
                    SetLocationTag(location, "longitude", longitudeDecimal.ToString())
                End If

                If Not IsInvalidOrdinate(altitudeDecimal) Then
                    SetLocationTag(location, "altitude", altitudeDecimal.ToString())
                End If

                If Not IsInvalidOrdinate(speedDecimal) Then
                    SetLocationTag(location, "speed", speedDecimal.ToString())
                End If

                If Not IsInvalidOrdinate(headingDecimal) Then
                    SetLocationTag(location, "heading", headingDecimal.ToString())
                End If

                If Not IsInvalidOrdinate(accuracyDecimal) Then
                    SetLocationTag(location, "accuracy", accuracyDecimal.ToString())
                End If

                If Not IsInvalidOrdinate(altitudeAccuracyDecimal) Then
                    SetLocationTag(location, "altitudeaccuracy", altitudeAccuracyDecimal.ToString())
                    If location.ToString().Length > 0 AndAlso unit <> "" Then
                        Dim kindOfUnit As GeoUnitType = GetUnitType(unit)
                        SetLocationTag(location, "unit", GetUnitString(kindOfUnit))
                    End If
                End If

                Return location.ToString()
            Catch ex As Exception
                Throw New Exception("BuildLocation(" & Convert.ToString(latitude) & ", " & Convert.ToString(longitude) & ", " & Convert.ToString(altitude) & ", " & Convert.ToString(speed) & ", " & Convert.ToString(heading) & ", " & Convert.ToString(accuracy) & ", " & Convert.ToString(altitudeAccuracy) & "): " & ex.Message)
            End Try

        End Function


#End Region

#End Region

#Region "Session, Cookie, URL and other Functions"

        ''' <summary>
        ''' Return the value of the variable from the session.
        ''' </summary>
        ''' <param name="toBeEncoded">URL to be encoded</param>
        ''' <returns>Encoded URL.</returns>
        Public Shared Function UrlEncode(ByVal toBeEncoded As String) As String
            Return System.Web.HttpUtility.UrlEncode(toBeEncoded)
        End Function

        ''' <summary>
        ''' Return the value of the variable from the session.
        ''' </summary>
        ''' <param name="var">The name of the session variable</param>
        ''' <returns>The session variable value.</returns>
        Public Shared Function Session(ByVal var As String) As String
            If var Is Nothing OrElse System.Web.HttpContext.Current.Session(var) Is Nothing Then
                Return String.Empty
            End If
            Return System.Web.HttpContext.Current.Session(var).ToString()
        End Function

        ''' <summary>
        ''' Return the value of the variable from the cookie.
        ''' </summary>
        ''' <param name="var">The name of the cookie variable</param>
        ''' <returns>The cookie variable value.</returns>
        Public Shared Function Cookie(ByVal var As String) As String
            If var Is Nothing OrElse System.Web.HttpContext.Current.Request.Cookies(var) Is Nothing Then
                Return String.Empty
            End If
            Return System.Web.HttpContext.Current.Request.Cookies(var).Value
        End Function

        ''' <summary>
        ''' Return the value of the variable from the cache.
        ''' </summary>
        ''' <param name="var">The name of the cache variable</param>
        ''' <returns>The cache variable value.</returns>
        Public Shared Function Cache(ByVal var As String) As String
            If var Is Nothing OrElse System.Web.HttpContext.Current.Cache(var) Is Nothing Then
                Return String.Empty
            End If
            Return System.Web.HttpContext.Current.Cache(var).ToString()
        End Function

        ''' <summary>
        ''' Return the value of the URL parameter passed to the current page.
        ''' </summary>
        ''' <param name="var">The name of the URL variable</param>
        ''' <returns>The URL variable value.</returns>
        Public Shared Function URL(ByVal var As String) As String
            Dim val As String = [String].Empty
            If var Is Nothing Then
                Return String.Empty
            End If

            val = System.Web.HttpContext.Current.Request.QueryString(var)

            ' It is possible that the URL value is encrypted - so try to
            ' decrypt. If we do not get an exception, then we know it was
            ' encrypted - otherwise if we get an exception, then the value was
            ' not encrypted in the first place, so return the actual value.
            Try
                val = Decrypt(val)
                ' Ignore exception and return original value
            Catch
            End Try


            If KeyValue.IsXmlKey(val) Then
                ' URL values are typically passed as XML structures to handle composite keys.
                ' If XML, then we will see if there is one element in the XML. If there is only one
                ' element, we will return that element. Otherwise we will return the full XML.
                Dim key As KeyValue = KeyValue.XmlToKey(val)
                If key.Count = 1 Then
                    val = key.ColumnValue(0)
                End If
            End If

            Return val
        End Function

        ''' <summary>
        ''' Return the value of the URL parameter passed to the current page.
        ''' If the URL is a Key Value pair, return the column value of the XML structure
        ''' </summary>
        ''' <param name="var">The name of the URL variable</param>
        ''' <returns>The URL variable value.</returns>
        Public Shared Function URL(ByVal var As String, ByVal column As String) As String
            Dim val As String = [String].Empty
            If var Is Nothing Then
                Return String.Empty
            End If

            val = System.Web.HttpContext.Current.Request.QueryString(var)

            ' It is possible that the URL value is encrypted - so try to
            ' decrypt. If we do not get an exception, then we know it was
            ' encrypted - otherwise if we get an exception, then the value was
            ' not encrypted in the first place, so return the actual value.
            Try
                val = Decrypt(val)
                ' Ignore exception and return original value
            Catch
            End Try

            If KeyValue.IsXmlKey(val) Then
                ' URL values are typically passed as XML structures to handle composite keys.
                ' If XML, then we will see if retrieve the value for the column name passed in
                ' to the function.
                Dim key As KeyValue = KeyValue.XmlToKey(val)
                val = key.ColumnValueByName(column)
            End If

            Return val
        End Function

        ''' <summary>
        ''' Return the value of the resource key. Only the application resources
        ''' are returned by this function. Resources in the BaseClasses.resx file
        ''' are not accessible through this function.
        ''' </summary>
        ''' <param name="var">The name of the resource key</param>
        ''' <returns>The resource value.</returns>
        Public Shared Function Resource(ByVal var As String) As String
            If var Is Nothing Then
                Return String.Empty
            End If
            Try
                Dim appname As String = BaseClasses.Configuration.ApplicationSettings.Current.GetAppSetting(BaseClasses.Configuration.ApplicationSettings.ConfigurationKey.ApplicationName)
                Dim resObj As Object = System.Web.HttpContext.GetGlobalResourceObject(appname, var)
                If resObj IsNot Nothing Then
                    Return resObj.ToString()
                End If
                ' If we cannot find the resource, simply return the variable that was passed-in.
            Catch
            End Try
            Return var
        End Function

        ''' <summary>
        ''' Return the encrypted value of the string passed in.
        ''' </summary>
        ''' <param name="str">The string to encrypt</param>
        ''' <returns>The encrypted value of the string.</returns>
        Public Shared Function Encrypt(ByVal str As String) As String
            If str Is Nothing Then
                Return String.Empty
            End If
            Dim CheckCrypto As New Crypto()
            Return CheckCrypto.Encrypt(str)
        End Function

        ''' <summary>
        ''' Return the decrypted value of the string passed in.
        ''' </summary>
        ''' <param name="str">The string to decrypt</param>
        ''' <returns>The decrypted value of the string.</returns>
        Public Shared Function Decrypt(ByVal str As String) As String
            If str Is Nothing Then
                Return String.Empty
            End If
            Dim CheckCrypto As New Crypto()
            Return CheckCrypto.Decrypt(str)
        End Function

        ''' <summary>
        ''' Return the encrypted value of the string passed in.
        ''' </summary>
        ''' <param name="str">The string to encrypt</param>
        ''' <returns>The encrypted value of the string.</returns>
        Public Shared Function EncryptData(ByVal str As String) As String
            If str Is Nothing Then
                Return String.Empty
            End If
            Dim CheckCrypto As New Crypto()
            Return CheckCrypto.Encrypt(str, False)
        End Function

        ''' <summary>
        ''' Return the decrypted value of the string passed in.
        ''' </summary>
        ''' <param name="str">The string to decrypt</param>
        ''' <returns>The decrypted value of the string.</returns>
        Public Shared Function DecryptData(ByVal str As String) As String
            If str Is Nothing Then
                Return String.Empty
            End If
            Dim CheckCrypto As New Crypto()
            Dim result As String = Nothing
            Try
                result = CheckCrypto.Decrypt(str, False)
            Catch
            End Try
            Try
                If result = str OrElse result Is Nothing OrElse String.IsNullOrEmpty(result) Then
                    result = CheckCrypto.Decrypt(str, True)
                End If
            Catch
                result = str
            End Try
            Return result
        End Function

        ''' <summary>
        ''' Return the currently logged in user id
        ''' </summary>
        ''' <returns>The user id of the currently logged in user.</returns>
        Public Shared Function UserId() As String
            Return BaseClasses.Utils.SecurityControls.GetCurrentUserID()
        End Function

        ''' <summary>
        ''' Return the currently logged in user ma,e
        ''' </summary>
        ''' <returns>The user name of the currently logged in user.</returns>
        Public Shared Function UserName() As String
            Return BaseClasses.Utils.SecurityControls.GetCurrentUserName()
        End Function

        ''' <summary>
        ''' Return the currently logged in user's roles. The roles are returned
        ''' as a string array, so you can do something like 
        ''' = If("Engineering" in Roles(), "Good", "Bad")
        ''' </summary>
        ''' <returns>The roles of the currently logged in user.</returns>
        Public Shared ReadOnly Property Roles() As String()
            Get
                Dim rStr As String = BaseClasses.Utils.SecurityControls.GetCurrentUserRoles()
                If (rStr Is Nothing) Then
                    Return New String(-1) {}
                End If
                Return rStr.Split(";"c)
            End Get
        End Property

        ''' <summary>
        ''' Return the value of the column from the currently logged in user's database 
        ''' record. Allows access to any fields on the user record (e.g., email address)
        ''' by simply doing something like UserRecord("EmailAddress")
        ''' NOTE: This function ONLY applies to Database Role security. Does NOT
        ''' apply to Active Directory, SharePoint, Windows Authentication or .NET Membership Roles
        ''' </summary>
        ''' <returns>The user record of the currently logged in user.</returns>
        Public Shared Function UserRecord(ByVal colName As String) As Object
            Dim rec As IUserIdentityRecord = Nothing
            rec = BaseClasses.Utils.SecurityControls.GetUserRecord("")
            If rec Is Nothing Then
                Return String.Empty
            End If

            Dim col As BaseColumn = Nothing
            col = rec.TableAccess.TableDefinition.ColumnList.GetByCodeName(colName)
            If col Is Nothing Then
                Return String.Empty
            End If

            Return rec.GetValue(col).Value
        End Function
#End Region

#Region "Database Access Functions"
        ''' <summary>
        ''' Return the value of the column from the database record specified by the key.  The
        ''' key can be either an XML KeyValue structure or just a string that is the Id of the record.
        ''' Only works for tables with a primary key or a virtual primary key.
        ''' </summary>
        ''' <returns>The value for the given field as an Object.</returns>
        Public Shared Function GetColumnValue(ByVal tableName As String, ByVal key As Decimal, ByVal fieldName As String) As Object
            Return GetColumnValue(tableName, key.ToString(), fieldName)
        End Function


        ''' <summary>
        ''' Return the value of the column from the database record specified by the key.  The
        ''' key can be either an XML KeyValue structure or just a string that is the Id of the record.
        ''' Only works for tables with a primary key or a virtual primary key.
        ''' </summary>
        ''' <returns>The value for the given field as an Object.</returns>
        Public Shared Function GetColumnValue(ByVal tableName As String, ByVal key As String, ByVal fieldName As String) As Object
            ' Find a specific value from the database for the given record.
            Dim bt As PrimaryKeyTable = Nothing
            bt = DirectCast(DatabaseObjects.GetTableObject(tableName), PrimaryKeyTable)
            If bt Is Nothing Then
                Throw New Exception("GETCOLUMNVALUE(" & tableName & ", " & key & ", " & fieldName & "): " & Resource("Err:NoRecRetrieved"))
            End If

            Dim rec As IRecord = Nothing
            Try
                ' Always start a transaction since we do not know if the calling function did.
                rec = bt.GetRecordData(key, False)
            Catch
            End Try
            If rec Is Nothing Then
                Throw New Exception("GETCOLUMNVALUE(" & tableName & ", " & key & ", " & fieldName & "): " & Resource("Err:NoRecRetrieved"))
            End If

            Dim col As BaseColumn = bt.TableDefinition.ColumnList.GetByCodeName(fieldName)
            If col Is Nothing Then
                Throw New Exception("GETCOLUMNVALUE(" & tableName & ", " & key & ", " & fieldName & "): " & Resource("Err:NoRecRetrieved"))
            End If
            col.IsApplyDisplayAs = False
            ' The value can be null.  In this case, return an empty string since
            ' that is an acceptable value.
            Dim fieldData As ColumnValue = rec.GetValue(col)
            If fieldData Is Nothing Then
                Return String.Empty
            End If

            Return fieldData.Value
        End Function

        ''' <summary>
        ''' Return an array of values from the database.  The values returned are DISTINCT values.
        ''' For example, GetColumnValues("Employees", "City") will return a list of all Cities
        ''' from the Employees table. There will be no duplicates in the list.
        ''' You can use the IN operator to compare the values.  You can also use the resulting array to display
        ''' such as String.Join(", ", GetColumnValues("Employees", "City")
        ''' to display: New York, Chicago, Los Angeles, San Francisco
        ''' </summary>
        ''' <returns>An array of values for the given field as an Object.</returns>
        Public Shared Function GetColumnValues(ByVal tableName As String, ByVal fieldName As String) As String()
            Return GetColumnValues(tableName, fieldName, String.Empty)
        End Function

        ''' <summary>
        ''' Return an array of values from the database.  The values returned are DISTINCT values.
        ''' For example, GetColumnValues("Employees", "City") will return a list of all Cities
        ''' from the Employees table. There will be no duplicates in the list.
        ''' This function adds a Where Clause.  So you can say something like "Country = 'USA'" and in this
        ''' case only cities in the US will be returned.
        ''' You can use the IN operator to compare the values.  You can also use the resulting array to display
        ''' such as String.Join(", ", GetColumnValues("Employees", "City", "Country = 'USA'")
        ''' to display: New York, Chicago, Los Angeles, San Francisco
        ''' </summary>
        ''' <returns>An array of values for the given field as an Object.</returns>
        Public Shared Function GetColumnValues(ByVal tableName As String, ByVal fieldName As String, ByVal whereStr As String) As String()
            ' Find the 
            Dim bt As PrimaryKeyTable = Nothing
            bt = DirectCast(DatabaseObjects.GetTableObject(tableName), PrimaryKeyTable)
            If bt Is Nothing Then
                Throw New Exception("GETCOLUMNVALUES(" & tableName & ", " & fieldName & ", " & whereStr & "): " & Resource("Err:NoRecRetrieved"))
            End If

            Dim col As BaseColumn = bt.TableDefinition.ColumnList.GetByCodeName(fieldName)
            If col Is Nothing Then
                Throw New Exception("GETCOLUMNVALUES(" & tableName & ", " & fieldName & ", " & whereStr & "): " & Resource("Err:NoRecRetrieved"))
            End If
            col.IsApplyDisplayAs = False
            Dim values As String() = Nothing

            Try
                ' Always start a transaction since we do not know if the calling function did.
                Dim sqlCol As New SqlBuilderColumnSelection(False, True)
                sqlCol.AddColumn(col)

                Dim wc As New WhereClause()
                If Not (whereStr Is Nothing) AndAlso whereStr.Trim().Length > 0 Then
                    wc.iAND(whereStr)
                End If
                Dim join As BaseClasses.Data.BaseFilter = Nothing
                values = bt.GetColumnValues(sqlCol, join, wc.GetFilter(), Nothing, Nothing, BaseTable.MIN_PAGE_NUMBER, _
                 BaseTable.MAX_BATCH_SIZE)
            Catch
            End Try

            ' The value can be null.  In this case, return an empty array since
            ' that is an acceptable value.
            If values Is Nothing Then
                values = New String(-1) {}
            End If


            Return values
        End Function
#End Region

#Region "Private Convenience Functions"

        Private Const degreesToRadians As Double = (Math.PI / 180.0)
        Private Const radiansToDegrees As Double = (180.0 / Math.PI)

        Private Const session_var_geo_location As String = "isd_geo_location"
        Private Const session_var_geo_default_location As String = "session_var_geo_default_location"
        Private Const session_var_geo_unit As String = "isd_geo_unit"
        Private Const session_var_geo_clear_browser_location As String = "isd_geo_clear_browser_location"

        Private Const session_var_geo_previous_address_1 As String = "isd_geo_previous_address_1"
        Private Const session_var_geo_previous_latitude_1 As String = "isd_geo_previous_latitude_1"
        Private Const session_var_geo_previous_longitude_1 As String = "isd_geo_previous_longitude_1"

        Private Const session_var_geo_previous_address_2 As String = "isd_geo_previous_address_2"
        Private Const session_var_geo_previous_latitude_2 As String = "isd_geo_previous_latitude_2"
        Private Const session_var_geo_previous_longitude_2 As String = "isd_geo_previous_longitude_2"

        Private Enum GeoUnitType
            Unit_Feet
            Unit_Yards
            Unit_Miles
            Unit_NauticalMiles
            Unit_Meters
            Unit_Kilometers
        End Enum

        Public Enum GeoProviderType
            Provider_Google
        End Enum

        Private Shared Function GetUnitType(ByVal unit As String) As GeoUnitType
            Dim unitLower As String = unit.ToLowerInvariant()

            If unitLower.StartsWith("nautical") OrElse unitLower.StartsWith("nm") Then
                Return GeoUnitType.Unit_NauticalMiles
            ElseIf unitLower.StartsWith("mi") Then
                Return GeoUnitType.Unit_Miles
            ElseIf unitLower.StartsWith("feet") OrElse unitLower.StartsWith("foot") OrElse unitLower.StartsWith("ft") Then
                Return GeoUnitType.Unit_Feet
            ElseIf unitLower.StartsWith("yard") OrElse unitLower.StartsWith("yd") Then
                Return GeoUnitType.Unit_Yards
            ElseIf unitLower.StartsWith("kilometer") OrElse unitLower.StartsWith("km") OrElse unitLower.Length = 0 Then
                Return GeoUnitType.Unit_Kilometers
            ElseIf unitLower.StartsWith("meter") OrElse unitLower.StartsWith("m") Then
                Return GeoUnitType.Unit_Meters
            Else
                Throw New Exception("GetUnit has invalid unit parameter")
            End If
        End Function


        Private Shared Function GetUnitString(ByVal unit As GeoUnitType) As String
            Select Case unit
                Case GeoUnitType.Unit_Feet
                    Return "feet"
                Case GeoUnitType.Unit_Yards
                    Return "yards"
                Case GeoUnitType.Unit_Miles
                    Return "miles"
                Case GeoUnitType.Unit_NauticalMiles
                    Return "nautical miles"
                Case GeoUnitType.Unit_Meters
                    Return "meters"
                Case GeoUnitType.Unit_Kilometers
                    Return "kilometers"
            End Select

            Return ""
        End Function


        ' Assumes that value is in meters
        Private Shared Sub ConvertToUnit(ByRef value As Decimal, ByVal unit As String)
            Const metersPerKilometer As Decimal = 1000D
            Const metersPerNauticalMile As Decimal = 1852D
            Const kilometersPerMile As Decimal = 1.609344D
            Const feetPerMile As Decimal = 5280D
            Const feetPerYard As Decimal = 3D

            If IsInvalidOrdinate(value) Then
                Return
            End If

            Select Case GetUnitType(unit)
                Case GeoUnitType.Unit_NauticalMiles
                    value = value / metersPerNauticalMile
                    Exit Select

                Case GeoUnitType.Unit_Miles
                    value = value / kilometersPerMile / metersPerKilometer
                    Exit Select

                Case GeoUnitType.Unit_Yards
                    value = value / kilometersPerMile / metersPerKilometer * feetPerMile / feetPerYard
                    Exit Select

                Case GeoUnitType.Unit_Feet
                    value = value / kilometersPerMile / metersPerKilometer * feetPerMile
                    Exit Select

                Case GeoUnitType.Unit_Kilometers
                    value = value / metersPerKilometer
                    Exit Select

                Case GeoUnitType.Unit_Meters
                    Exit Select
                Case Else

                    Throw New Exception("unit parameter is invalid")
            End Select
        End Sub


        Private Shared Function GetEarthRadius() As Double
            Dim unit As String = GetDistanceUnit()
            Dim radius As Decimal = 3959D * 1.609344D * 1000D

            ConvertToUnit(radius, unit)

            Return Convert.ToDouble(radius)
        End Function


        Private Shared Function DecimalToDegreesMinSec(ByVal ordinate As Object, ByVal component As Object) As Decimal
            Dim ordinateDecimal As Decimal = 0D
            Dim componentStr As String = ""

            Try
                ordinateDecimal = StringUtils.ParseDecimal(ordinate)
                componentStr = GetStr(component)

                Dim componentLower As String = componentStr.ToLowerInvariant()
                Dim degrees As Decimal = Math.Truncate(ordinateDecimal)
                Dim remainder As Decimal = (ordinateDecimal - degrees) * 60D
                Dim minutes As Decimal = Math.Truncate(remainder)
                Dim seconds As Decimal = (remainder - minutes) * 60D

                If componentLower.StartsWith("degree") Then
                    Return degrees
                ElseIf componentLower.StartsWith("minute") Then
                    Return minutes
                ElseIf componentLower.StartsWith("second") Then
                    Return seconds
                End If

                Throw New Exception("DecimalToDegreesMinSec has invalid component parameter")
            Catch ex As Exception
                Throw New Exception("DecimalToDegreesMinSec(" & Convert.ToString(ordinate) & ", " & Convert.ToString(component) & "): " & ex.Message)
            End Try

        End Function


        Public Shared Function IsInvalidOrdinate(ByVal ordinate As Decimal) As Boolean
            If ordinate <= BaseClasses.Web.UI.BasePage.GEO_LOCATION_ERRORS Then
                Return True
            Else
                Return False
            End If
        End Function


        Private Shared Sub FixUpLatitude(ByRef latitude As Decimal)
            If IsInvalidOrdinate(latitude) Then
                Return
            End If

            If latitude > 90D Then
                latitude = 90D
            ElseIf latitude < -90D Then
                latitude = -90D
            End If
        End Sub


        Private Shared Sub FixUpLongitude(ByRef longitude As Decimal)
            If IsInvalidOrdinate(longitude) Then
                Return
            End If

            If longitude > 180D Then
                longitude = 180D
            ElseIf longitude < -180D Then
                longitude = -180D
            End If
        End Sub


        Public Shared Function GetBrowserLocation(ByVal unit As Object) As String
            Try
                Dim unitStr As String = "kilometers"

                unitStr = GetStr(unit)

                If unitStr = "" Then
                    unitStr = "kilometers"
                End If

                If IsNothing(System.Web.HttpContext.Current.Session(session_var_geo_clear_browser_location)) OrElse _
                   (Not IsNothing(System.Web.HttpContext.Current.Session(session_var_geo_clear_browser_location)) AndAlso _
                    System.Web.HttpContext.Current.Session(session_var_geo_clear_browser_location).ToString <> "True") Then
                    BaseClasses.Web.UI.BasePage.SetGeolocation()
                End If

                Dim sessionVar As String = Session(session_var_geo_location)

                If IsNothing(sessionVar) Then
                    sessionVar = ""
                End If

                Dim address As String = ""
                Dim embeddedUnit As String = "meters"
                Dim latitude As Decimal = BaseClasses.Web.UI.BasePage.GEO_LOCATION_INVALID_ORDINATE
                Dim longitude As Decimal = BaseClasses.Web.UI.BasePage.GEO_LOCATION_INVALID_ORDINATE
                Dim hasLocation As Boolean = False
                Dim errorMsg As String = ""
                Dim donotretrievebrowserlocation As String = ""
                Dim forceLocationBuild As Boolean = False

                If IsInLocation(sessionVar, "address") Then
                    address = LocationToAddress(sessionVar)
                    hasLocation = True
                End If

                If IsInLocation(sessionVar, "latitude") AndAlso IsInLocation(sessionVar, "longitude") Then
                    latitude = LocationToLatitude(sessionVar)
                    longitude = LocationToLongitude(sessionVar)
                    hasLocation = True
                End If

                If Not hasLocation Then
                    If IsInLocation(sessionVar, "error") Then
                        errorMsg = LocationToOther(sessionVar, "error")
                    End If

                    If IsInLocation(sessionVar, "donotretrievebrowserlocation") Then
                        donotretrievebrowserlocation = LocationToOther(sessionVar, "donotretrievebrowserlocation")
                    End If

                    sessionVar = BuildLocation(GetDefaultLocation())

                    Dim locationTemp As New StringBuilder(sessionVar, 300)

                    latitude = LocationToLatitude(sessionVar)
                    longitude = LocationToLongitude(sessionVar)

                    If Not IsInvalidOrdinate(latitude) AndAlso Not IsInvalidOrdinate(longitude) Then
                        SetLocationTag(locationTemp, "latitude", LocationToLatitude(sessionVar).ToString())
                        SetLocationTag(locationTemp, "longitude", LocationToLongitude(sessionVar).ToString())
                    End If

                    sessionVar = locationTemp.ToString()

                    If errorMsg <> "" Then
                        Dim location As New StringBuilder(sessionVar, 300)

                        SetLocationTag(location, "error", errorMsg)

                        sessionVar = location.ToString()
                    End If

                    If donotretrievebrowserlocation <> "" Then
                        Dim location As New StringBuilder(sessionVar, 300)

                        SetLocationTag(location, "donotretrievebrowserlocation", donotretrievebrowserlocation)

                        sessionVar = location.ToString()
                    End If

                    forceLocationBuild = True
                End If

                If IsInLocation(sessionVar, "unit") Then
                    embeddedUnit = LocationToOther(sessionVar, "unit")
                End If

                If forceLocationBuild OrElse _
                   (GetUnitType(unitStr) <> GeoUnitType.Unit_Meters AndAlso GetUnitType(embeddedUnit) = GeoUnitType.Unit_Meters) Then
                    ' meters
                    Dim altitude As Decimal = BaseClasses.Web.UI.BasePage.GEO_LOCATION_INVALID_ORDINATE
                    Dim speed As Decimal = BaseClasses.Web.UI.BasePage.GEO_LOCATION_INVALID_ORDINATE
                    Dim heading As Decimal = BaseClasses.Web.UI.BasePage.GEO_LOCATION_INVALID_ORDINATE
                    Dim accuracy As Decimal = BaseClasses.Web.UI.BasePage.GEO_LOCATION_INVALID_ORDINATE
                    Dim altitudeAccuracy As Decimal = BaseClasses.Web.UI.BasePage.GEO_LOCATION_INVALID_ORDINATE

                    If IsInLocation(sessionVar, "latitude") Then
                        latitude = LocationToLatitude(sessionVar)
                    End If

                    If IsInLocation(sessionVar, "longitude") Then
                        longitude = LocationToLongitude(sessionVar)
                    End If

                    If IsInLocation(sessionVar, "altitude") Then
                        altitude = LocationToOtherNumber(sessionVar, "altitude")
                    End If

                    If IsInLocation(sessionVar, "speed") Then
                        speed = LocationToOtherNumber(sessionVar, "speed")
                    End If

                    If IsInLocation(sessionVar, "heading") Then
                        heading = LocationToOtherNumber(sessionVar, "heading")
                    End If

                    If IsInLocation(sessionVar, "accuracy") Then
                        accuracy = LocationToOtherNumber(sessionVar, "accuracy")
                    End If

                    If IsInLocation(sessionVar, "altitudeaccuracy") Then
                        altitudeAccuracy = LocationToOtherNumber(sessionVar, "altitudeaccuracy")
                    End If

                    If IsInLocation(sessionVar, "error") Then
                        errorMsg = LocationToOther(sessionVar, "error")
                    End If

                    If IsInLocation(sessionVar, "donotretrievebrowserlocation") Then
                        donotretrievebrowserlocation = LocationToOther(sessionVar, "donotretrievebrowserlocation")
                    End If

                    ConvertToUnit(altitude, unitStr)
                    ConvertToUnit(speed, unitStr)
                    ConvertToUnit(accuracy, unitStr)
                    ConvertToUnit(altitudeAccuracy, unitStr)

                    sessionVar = BuildLocation(latitude, longitude, altitude, speed, heading, accuracy, _
                     altitudeAccuracy)

                    Dim location As New StringBuilder(sessionVar, 300)

                    SetLocationTag(location, "unit", unitStr)

                    If address <> "" Then
                        SetLocationTag(location, "address", address)
                    End If

                    If errorMsg <> "" Then
                        SetLocationTag(location, "error", errorMsg)
                    End If

                    If Not forceLocationBuild AndAlso donotretrievebrowserlocation <> "" Then
                        SetLocationTag(location, "donotretrievebrowserlocation", donotretrievebrowserlocation)
                    End If

                    sessionVar = location.ToString()
                End If

                If Not IsInLocation(sessionVar, "unit") Then
                    Dim locationTemp As New StringBuilder(sessionVar, 300)

                    SetLocationTag(locationTemp, "unit", unitStr)

                    sessionVar = locationTemp.ToString()
                End If

                Return sessionVar
            Catch ex As Exception
                Throw New Exception("GETBROWSERLOCATION(" & Convert.ToString(unit) & "): " & ex.Message)
            End Try

            Return ""
        End Function


        Private Shared Sub SetLocationTag(ByRef location As StringBuilder, ByVal tagName As String, ByVal tagValue As String)
            Dim currentLoc As String = location.ToString().Trim()
            Dim locationEndTag As String = "</location>"
            Dim locationEndTagStart As Integer = currentLoc.IndexOf(locationEndTag)

            If locationEndTagStart >= 0 Then
                location.Remove(locationEndTagStart, location.ToString().Length - locationEndTagStart)
            Else
                ' If there are no tags, then assume its a street address
                If currentLoc.Length > 0 AndAlso Not currentLoc.Contains("<") Then
                    location = New StringBuilder("", 300)

                    location.Append("<address>" & currentLoc & "</address>" & Environment.NewLine)
                End If
                location.Append("<location>" & Environment.NewLine)
            End If

            ' First remove existing attribute
            Dim startTagStart As Integer = currentLoc.IndexOf("<" & tagName & ">")
            Dim endTagStart As Integer = currentLoc.IndexOf("</" & tagName & ">")

            If startTagStart >= 0 AndAlso endTagStart >= 0 Then
                location.Remove(startTagStart, endTagStart + ("</" & tagName & ">").Length - startTagStart)
            End If

            If tagName.ToLowerInvariant = "address" Then
                location.AppendFormat("<{0}>{1}</{2}>{3}", tagName, HttpUtility.UrlEncode(tagValue), tagName, Environment.NewLine)
            Else
                location.AppendFormat("<{0}>{1}</{2}>{3}", tagName, tagValue, tagName, Environment.NewLine)
            End If

            location.Append("</location>" & Environment.NewLine)
        End Sub


        Private Shared Sub SwapGeocodeCacheItems()
            Dim previousAddress1 As String = Session(session_var_geo_previous_address_1)
            Dim previousLatitude1 As String = Session(session_var_geo_previous_latitude_1)
            Dim previousLongitude1 As String = Session(session_var_geo_previous_longitude_1)

            Dim previousAddress2 As String = Session(session_var_geo_previous_address_2)
            Dim previousLatitude2 As String = Session(session_var_geo_previous_latitude_2)
            Dim previousLongitude2 As String = Session(session_var_geo_previous_longitude_2)

            System.Web.HttpContext.Current.Session(session_var_geo_previous_address_1) = previousAddress2
            System.Web.HttpContext.Current.Session(session_var_geo_previous_latitude_1) = previousLatitude2
            System.Web.HttpContext.Current.Session(session_var_geo_previous_longitude_1) = previousLongitude2

            System.Web.HttpContext.Current.Session(session_var_geo_previous_address_2) = previousAddress1
            System.Web.HttpContext.Current.Session(session_var_geo_previous_latitude_2) = previousLatitude1
            System.Web.HttpContext.Current.Session(session_var_geo_previous_longitude_2) = previousLongitude1
        End Sub


        Private Shared Function Geocode(ByVal location As String, ByVal provider As GeoProviderType) As String
            Dim googleClientID As String = GetGoogleClientID()
            Dim googleSignature As String = GetGoogleSignature()

            If location.Contains("<error>LOCATION_ERROR_") Then
                Return location
            End If

            Dim streetAddress As String = ""
            Dim latitude As Decimal = BaseClasses.Web.UI.BasePage.GEO_LOCATION_INVALID_ORDINATE
            Dim longitude As Decimal = BaseClasses.Web.UI.BasePage.GEO_LOCATION_INVALID_ORDINATE

            ' Check if it exists first since LocationToLatitude may call Geocode
            If IsInLocation(location, "latitude") Then
                latitude = LocationToLatitude(location)
            End If

            If IsInLocation(location, "latitude") Then
                longitude = LocationToLongitude(location)
            End If

            Dim useStreetAddress As Boolean = IsInvalidOrdinate(latitude)

            If useStreetAddress Then
                streetAddress = LocationToAddress(location)
            Else
                FixUpLatitude(latitude)
                FixUpLongitude(longitude)
            End If

            Dim previousAddress1 As String = Session(session_var_geo_previous_address_1)
            Dim previousLatitude1 As String = Session(session_var_geo_previous_latitude_1)
            Dim previousLongitude1 As String = Session(session_var_geo_previous_longitude_1)

            Dim previousAddress2 As String = Session(session_var_geo_previous_address_2)
            Dim previousLatitude2 As String = Session(session_var_geo_previous_latitude_2)
            Dim previousLongitude2 As String = Session(session_var_geo_previous_longitude_2)

            Dim url As New StringBuilder("", 300)
            Dim errorMessage As String = ""

            If useStreetAddress Then
                If streetAddress.Equals(previousAddress1) Then
                    Try

                        latitude = StringUtils.ParseDecimal(previousLatitude1)
                        longitude = StringUtils.ParseDecimal(previousLongitude1)

                        Dim locationStr As New StringBuilder(location, 300)

                        SetLocationTag(locationStr, "latitude", latitude.ToString())
                        SetLocationTag(locationStr, "longitude", longitude.ToString())
                        SetLocationTag(locationStr, "address", previousAddress1)

                        Return locationStr.ToString()
                    Catch
                    End Try
                ElseIf streetAddress.Equals(previousAddress2) Then
                    Try

                        latitude = StringUtils.ParseDecimal(previousLatitude2)
                        longitude = StringUtils.ParseDecimal(previousLongitude2)

                        Dim locationStr As New StringBuilder(location, 300)

                        SetLocationTag(locationStr, "latitude", latitude.ToString())
                        SetLocationTag(locationStr, "longitude", longitude.ToString())
                        SetLocationTag(locationStr, "address", previousAddress2)

                        SwapGeocodeCacheItems()

                        Return locationStr.ToString()
                    Catch
                    End Try
                End If

                latitude = BaseClasses.Web.UI.BasePage.GEO_LOCATION_INVALID_ORDINATE
                longitude = BaseClasses.Web.UI.BasePage.GEO_LOCATION_INVALID_ORDINATE
            Else
                If Convert.ToString(latitude).Equals(previousLatitude1) AndAlso _
                  Convert.ToString(longitude).Equals(previousLongitude1) Then
                    Dim locationStr As New StringBuilder(location, 300)

                    SetLocationTag(locationStr, "latitude", latitude.ToString())
                    SetLocationTag(locationStr, "longitude", longitude.ToString())
                    SetLocationTag(locationStr, "address", previousAddress1)

                    Return locationStr.ToString()
                ElseIf Convert.ToString(latitude).Equals(previousLatitude2) AndAlso _
                  Convert.ToString(longitude).Equals(previousLongitude2) Then
                    Dim locationStr As New StringBuilder(location, 300)

                    SetLocationTag(locationStr, "latitude", latitude.ToString())
                    SetLocationTag(locationStr, "longitude", longitude.ToString())
                    SetLocationTag(locationStr, "address", previousAddress2)

                    SwapGeocodeCacheItems()

                    Return locationStr.ToString()
                End If

                streetAddress = ""
            End If

            If streetAddress.Trim().Length = 0 AndAlso (IsInvalidOrdinate(latitude) OrElse IsInvalidOrdinate(longitude)) Then
                Return location
            End If

            Select Case provider
                Case GeoProviderType.Provider_Google
                    If useStreetAddress Then
                        url.Append("https://maps.googleapis.com/maps/api/geocode/xml")
                        url.AppendFormat("?address={0}", HttpUtility.UrlEncode(streetAddress))
                        url.Append("&sensor=false")
                    Else
                        url.Append("https://maps.googleapis.com/maps/api/geocode/xml?latlng=" & HttpUtility.UrlEncode(Convert.ToString(latitude).Replace(",", ".")) & "," & HttpUtility.UrlEncode(Convert.ToString(longitude).Replace(",", ".")) & "&sensor=false")
                    End If

                    If googleClientID <> "" Then
                        url.Append("&client=" & HttpUtility.UrlEncode(googleClientID))
                    End If

                    If googleSignature <> "" Then
                        url.Append("&signature=" & HttpUtility.UrlEncode(googleSignature))
                    End If
            End Select

            Dim response As WebResponse = Nothing

            Try
                Dim request As HttpWebRequest = DirectCast(WebRequest.Create(url.ToString()), HttpWebRequest)
                request.Method = "GET"
                response = request.GetResponse()

                If response Is Nothing Then
                    errorMessage = "LOCATION_ERROR_GEO_CODING_NO_RESPONSE"
                Else
                    Dim document As New XPathDocument(response.GetResponseStream())
                    Dim navigator As XPathNavigator = document.CreateNavigator()
                    ' get response status
                    Dim statusIterator As XPathNodeIterator = navigator.[Select]("/GeocodeResponse/status")

                    While statusIterator.MoveNext()
                        If statusIterator.Current.Value <> "OK" Then
                            errorMessage = "LOCATION_ERROR_GEO_CODING_" + statusIterator.Current.Value
                        End If
                    End While

                    ' get results
                    Dim resultIterator As XPathNodeIterator = navigator.[Select]("/GeocodeResponse/result")

                    While errorMessage = "" AndAlso resultIterator.MoveNext()
                        If useStreetAddress Then
                            Dim geometryIterator As XPathNodeIterator = resultIterator.Current.[Select]("geometry")

                            While geometryIterator.MoveNext()
                                Dim locationIterator As XPathNodeIterator = geometryIterator.Current.[Select]("location")

                                While locationIterator.MoveNext()
                                    Dim latIterator As XPathNodeIterator = locationIterator.Current.[Select]("lat")

                                    While latIterator.MoveNext()
                                        Try
                                            latitude = StringUtils.ParseDecimal(latIterator.Current.Value)
                                        Catch
                                        End Try
                                    End While

                                    Dim lngIterator As XPathNodeIterator = locationIterator.Current.[Select]("lng")

                                    While lngIterator.MoveNext()
                                        Try
                                            longitude = StringUtils.ParseDecimal(lngIterator.Current.Value)
                                        Catch
                                        End Try
                                    End While
                                End While
                            End While
                        Else
                            Dim formattedAddressIterator As XPathNodeIterator = resultIterator.Current.[Select]("formatted_address")

                            ' There can be more than one formattedAddress -- get the longest one
                            While formattedAddressIterator.MoveNext()
                                If formattedAddressIterator.Current.Value.Length > streetAddress.Length Then
                                    streetAddress = formattedAddressIterator.Current.Value
                                End If
                            End While
                        End If
                    End While
                End If
            Catch
            Finally
                If response IsNot Nothing Then
                    response.Close()
                    response = Nothing
                End If
            End Try

            Dim locationStr2 As New StringBuilder(location, 300)

            If errorMessage = "" Then
                System.Web.HttpContext.Current.Session(session_var_geo_previous_address_2) = System.Web.HttpContext.Current.Session(session_var_geo_previous_address_1)
                System.Web.HttpContext.Current.Session(session_var_geo_previous_latitude_2) = System.Web.HttpContext.Current.Session(session_var_geo_previous_latitude_1)
                System.Web.HttpContext.Current.Session(session_var_geo_previous_longitude_2) = System.Web.HttpContext.Current.Session(session_var_geo_previous_longitude_1)

                System.Web.HttpContext.Current.Session(session_var_geo_previous_address_1) = streetAddress
                System.Web.HttpContext.Current.Session(session_var_geo_previous_latitude_1) = Convert.ToString(latitude)
                System.Web.HttpContext.Current.Session(session_var_geo_previous_longitude_1) = Convert.ToString(longitude)

                SetLocationTag(locationStr2, "latitude", latitude.ToString())
                SetLocationTag(locationStr2, "longitude", longitude.ToString())
                SetLocationTag(locationStr2, "address", streetAddress)
            Else
                SetLocationTag(locationStr2, "error", errorMessage)
            End If

            Return locationStr2.ToString()
        End Function


        Public Shared Function GetGoogleKey() As String
            Dim value As String = BaseClasses.Configuration.ApplicationSettings.Current.GoogleKey

            Return value
        End Function


        Public Shared Function GetGoogleClientID() As String
            Dim value As String = BaseClasses.Configuration.ApplicationSettings.Current.GoogleClientID

            Return value
        End Function


        Public Shared Function GetGoogleSignature() As String
            Dim value As String = BaseClasses.Configuration.ApplicationSettings.Current.GoogleSignature

            Return value
        End Function



        Private Shared Function CreateDirections(ByVal startLocation As Object, ByVal endLocation As Object, ByVal popupWidth As Object, ByVal popupHeight As Object, ByVal googleDirectionsParameters As Object, ByVal HTMLInsideLink As String) As String
            Dim startLocationStr As String = ""
            Dim endLocationStr As String = ""
            Dim popupWidthInteger As Long = 0
            Dim popupHeightInteger As Long = 0
            Dim googleDirectionsParametersStr As String = ""

            Try
                startLocationStr = GetStr(startLocation)
                endLocationStr = GetStr(endLocation)
                popupWidthInteger = StringUtils.ParseInteger(popupWidth)
                popupHeightInteger = StringUtils.ParseInteger(popupHeight)
                googleDirectionsParametersStr = GetStr(googleDirectionsParameters)

                If popupWidthInteger = -1 Then
                    popupWidthInteger = 800
                End If

                If popupHeightInteger = -1 Then
                    popupHeightInteger = 800
                End If

                startLocationStr = BuildLocation(startLocationStr)
                endLocationStr = BuildLocation(endLocationStr)

                Dim googleKey As String = GetGoogleKey()
                Dim startAddress As String = ""
                Dim startLatitude As Decimal = BaseClasses.Web.UI.BasePage.GEO_LOCATION_INVALID_ORDINATE
                Dim startLongitude As Decimal = BaseClasses.Web.UI.BasePage.GEO_LOCATION_INVALID_ORDINATE
                Dim endAddress As String = ""
                Dim endLatitude As Decimal = BaseClasses.Web.UI.BasePage.GEO_LOCATION_INVALID_ORDINATE
                Dim endLongitude As Decimal = BaseClasses.Web.UI.BasePage.GEO_LOCATION_INVALID_ORDINATE

                If IsInLocation(startLocationStr, "address") Then
                    startAddress = LocationToAddress(startLocationStr)
                End If

                If IsInLocation(startLocationStr, "latitude") Then
                    startLatitude = LocationToLatitude(startLocationStr)
                End If

                If IsInLocation(startLocationStr, "longitude") Then
                    startLongitude = LocationToLongitude(startLocationStr)
                End If

                If IsInLocation(endLocationStr, "address") Then
                    endAddress = LocationToAddress(endLocationStr)
                End If

                If IsInLocation(endLocationStr, "latitude") Then
                    endLatitude = LocationToLatitude(endLocationStr)
                End If

                If IsInLocation(endLocationStr, "longitude") Then
                    endLongitude = LocationToLongitude(endLocationStr)
                End If

                Dim useStreetAddressSource As Boolean = IsInvalidOrdinate(startLatitude)
                Dim useStreetAddressDestination As Boolean = IsInvalidOrdinate(endLatitude)

                FixUpLatitude(startLatitude)
                FixUpLatitude(endLatitude)

                FixUpLongitude(startLongitude)
                FixUpLongitude(endLongitude)

                If googleDirectionsParametersStr.Length > 0 AndAlso Not googleDirectionsParametersStr.StartsWith("&") Then
                    googleDirectionsParametersStr = "&" & googleDirectionsParametersStr
                End If

                Dim lowerGoogleDirectionsParameters As String = googleDirectionsParametersStr.ToLowerInvariant()

                Dim hrefStr As New StringBuilder("", 300)

                ' Example format: https://maps.google.com/maps?saddr=2870+Zanker+Road,+San+Jose,+CA&daddr=1173+Geary+Blvd,+Lebanon,+PA+17042,+USA&hl=en&sll=40.509938,-76.380274&sspn=0.01235,0.018947&oq=2870+Zanker+&mra=ls&t=m&z=4

                hrefStr.Append("https://maps.google.com/maps?")

                If useStreetAddressSource Then
                    hrefStr.AppendFormat("saddr={0}", HttpUtility.UrlEncode(startAddress))
                Else
                    hrefStr.AppendFormat("saddr={0},{1}", HttpUtility.UrlEncode(startLatitude.ToString.Replace(",", ".")), HttpUtility.UrlEncode(startLongitude.ToString.Replace(",", ".")))
                End If

                If useStreetAddressDestination Then
                    hrefStr.AppendFormat("&daddr={0}", HttpUtility.UrlEncode(endAddress))
                Else
                    hrefStr.AppendFormat("&daddr={0},{1}", HttpUtility.UrlEncode(endLatitude.ToString.Replace(",", ".")), HttpUtility.UrlEncode(endLongitude.ToString.Replace(",", ".")))
                End If

                If googleDirectionsParametersStr <> "" Then
                    hrefStr.Append(googleDirectionsParametersStr)
                End If

                If googleKey.Length > 0 AndAlso Not lowerGoogleDirectionsParameters.Contains("&key=") Then
                    hrefStr.Append("&key=")
                    hrefStr.Append(googleKey)
                End If

                Dim str As New StringBuilder("", 300)

                str.Append("<a")
                str.AppendFormat(" href=""{0}""", hrefStr.ToString())
                str.AppendFormat(" target=""{0}""", "_blank")

                str.AppendFormat(" onclick=""var left=(screen.width/2)-({0}/2);var top=(screen.height/2)-({1}/2);window.open(this.href, '_blank'" + _
                                 ", 'scrollbars=yes,resizable=yes,width={0},height={1},top='+top+',left='+left);return false;""", popupWidthInteger, popupHeightInteger)

                str.Append(">")
                If HTMLInsideLink = "" Then
                    str.Append(HttpUtility.HtmlEncode(Resource("Txt:ShowDirections")))
                ElseIf HTMLInsideLink.ToUpperInvariant.Contains("<IMG ") Then
                    str.Append(HTMLInsideLink)
                Else
                    str.Append(HttpUtility.HtmlEncode(HTMLInsideLink))
                End If

                str.Append("</a>")

                Return str.ToString()
            Catch ex As Exception
                Throw New Exception("GOOGLEDIRECTIONS(" & Convert.ToString(startLocation) & ", " & Convert.ToString(endLocation) & "): " & ex.Message)
            End Try

        End Function


        Private Shared Function CreateMap(ByVal mapType As String, ByVal location As Object, ByVal width As Object, ByVal height As Object, ByVal popupWidth As Object, ByVal popupHeight As Object, ByVal providerType As GeoProviderType, ByVal map1Parameters As Object, _
         ByVal map2Parameters As Object) As String
            Dim locationStr As String = ""
            Dim widthInteger As Long = 0
            Dim heightInteger As Long = 0
            Dim popupWidthInteger As Long = 0
            Dim popupHeightInteger As Long = 0
            Dim map1ParametersStr As String = ""
            Dim map2ParametersStr As String = ""

            Try
                locationStr = GetStr(location)

                widthInteger = StringUtils.ParseInteger(width)
                heightInteger = StringUtils.ParseInteger(height)

                popupWidthInteger = StringUtils.ParseInteger(popupWidth)
                popupHeightInteger = StringUtils.ParseInteger(popupHeight)

                If popupWidthInteger = -1 Then
                    popupWidthInteger = 800
                End If

                If popupHeightInteger = -1 Then
                    popupHeightInteger = 800
                End If

                map1ParametersStr = GetStr(map1Parameters)
                map2ParametersStr = GetStr(map2Parameters)

                location = BuildLocation(locationStr)

                Dim title As New StringBuilder("", 300)

                If IsInLocation(locationStr, "address") Then
                    title.AppendFormat("{0}", LocationToAddress(locationStr))
                Else
                    title.AppendFormat("{0},{1}", LocationToOther(locationStr, "latitude"), LocationToOther(locationStr, "longitude"))
                End If

                If map1ParametersStr.Length > 0 AndAlso Not map1ParametersStr.StartsWith("&") Then
                    map1ParametersStr = "&" & map1ParametersStr
                End If

                Dim lowerMap1Parameters As String = map1ParametersStr.ToLowerInvariant()
                Dim lowerMap2Parameters As String = map2ParametersStr.ToLowerInvariant()

                If widthInteger < 0 Then
                    widthInteger = 600
                ElseIf widthInteger > 2048 Then
                    widthInteger = 2048
                End If

                If heightInteger < 0 Then
                    heightInteger = 300
                ElseIf heightInteger > 2048 Then
                    heightInteger = 2048
                End If

                Dim str As New StringBuilder("", 300)

                If mapType Is Nothing OrElse mapType.Length = 0 Then
                    mapType = "staticimagewithpopup"
                End If

                mapType = mapType.ToLowerInvariant()

                If mapType.Equals("interactiveurl") Then
                    Dim iframeURL As String = GetMapURL("interactive", locationStr, widthInteger, heightInteger, map1ParametersStr)

                    str.Append(iframeURL)
                ElseIf mapType.Equals("staticimageurl") Then
                    Dim imageURL As String = GetMapURL("staticimage", locationStr, widthInteger, heightInteger, map1ParametersStr)

                    str.Append(imageURL)
                ElseIf mapType.Equals("popupurl") Then
                    Dim fullURL As String = GetMapURL("popup", locationStr, widthInteger, heightInteger, map1ParametersStr)

                    str.Append(fullURL)
                ElseIf mapType.Equals("interactive") Then
                    Dim iframeUrl As String = GetMapURL("interactive", locationStr, widthInteger, heightInteger, map1ParametersStr)

                    str.Append("<iframe")
                    str.AppendFormat(" src=""{0}""", iframeUrl)
                    str.AppendFormat(" width=""{0}"" height=""{1}""", widthInteger, heightInteger)
                    str.Append("></iframe>")
                ElseIf mapType.Equals("staticimage") Then
                    Dim imageURL As String = GetMapURL("staticimage", locationStr, widthInteger, heightInteger, map1ParametersStr)

                    str.Append("<img")
                    str.AppendFormat(" src=""{0}""", imageURL)

                    If Not map1ParametersStr.toLowerInvariant.Contains("&size=") Then
                        str.AppendFormat(" width=""{0}"" height=""{1}""", widthInteger, heightInteger)
                    End If

                    str.AppendFormat(" title=""{0}""", HttpUtility.HtmlEncode(title.ToString()))
                    str.Append(" />")
                ElseIf mapType.Equals("staticimagewithpopup") Then
                    Dim imageURL As String = GetMapURL("staticimage", locationStr, widthInteger, heightInteger, map1ParametersStr)
                    Dim fullURL As String = GetMapURL("popup", locationStr, widthInteger, heightInteger, map2ParametersStr)

                    str.Append("<a")
                    str.AppendFormat(" href=""{0}""", fullURL)
                    str.AppendFormat(" target=""{0}""", "_blank")
                    str.AppendFormat(" onclick=""var left=(screen.width/2)-({0}/2);var top=(screen.height/2)-({1}/2);window.open(this.href, '_blank'" + _
                                     ", 'scrollbars=yes,resizable=yes,width={0},height={1},top='+top+',left='+left); return false;""", popupWidthInteger, popupHeightInteger)
                    str.AppendFormat(" title=""{0}""", Resource("Txt:ShowMap"))
                    str.Append(">")
                    str.Append("<img")
                    str.AppendFormat(" src=""{0}""", imageURL)

                    If Not map1ParametersStr.toLowerInvariant.Contains("&size=") Then
                        str.AppendFormat(" width=""{0}"" height=""{1}""", widthInteger, heightInteger)
                    End If

                    str.AppendFormat(" title=""{0}""", HttpUtility.HtmlEncode(title.ToString()))
                    str.Append(" />")
                    str.Append("</a>")
                ElseIf mapType.Equals("textlink") Then
                    Dim fullURL As String = GetMapURL("popup", locationStr, widthInteger, heightInteger, map1ParametersStr)

                    str.Append("<a")
                    str.AppendFormat(" href=""{0}""", fullURL)
                    str.AppendFormat(" target=""{0}""", "_blank")
                    str.AppendFormat(" onclick=""var left=(screen.width/2)-({0}/2);var top=(screen.height/2)-({1}/2);window.open(this.href, '_blank'" + _
                                     ", 'scrollbars=yes,resizable=yes,width={0},height={1},top='+top+',left='+left); return false;""", popupWidthInteger, popupHeightInteger)
                    str.AppendFormat(" title=""{0}""", Resource("Txt:ShowMap"))
                    str.Append(">")
                    str.Append(Resource("Txt:ShowMap"))
                    str.Append("</a>")
                End If

                Return str.ToString()
            Catch ex As Exception
                Throw New Exception("CREATEMAP(" & Convert.ToString(location) & ", " & Convert.ToString(width) & ", " & Convert.ToString(height) & ", " & Convert.ToString(map1Parameters) & ", " & Convert.ToString(map2Parameters) & "): " & ex.Message)
            End Try

        End Function


        Private Shared Function GetMapURL(ByVal mapType As String, ByVal location As String, ByVal width As Long, ByVal height As Long, ByVal mapParameters As String) As String
            Dim googleKey As String = GetGoogleKey()
            Dim googleClientID As String = GetGoogleClientID()
            Dim googleSignature As String = GetGoogleSignature()
            Dim address As String = ""
            Dim latitude As Decimal = BaseClasses.Web.UI.BasePage.GEO_LOCATION_INVALID_ORDINATE
            Dim longitude As Decimal = BaseClasses.Web.UI.BasePage.GEO_LOCATION_INVALID_ORDINATE
            Dim placeString As String = ""

            If IsInLocation(location, "address") Then
                address = LocationToAddress(location)

                placeString = address
            Else
                latitude = LocationToLatitude(location)
                longitude = LocationToLongitude(location)

                placeString = latitude.ToString().Replace(",", ".") & "," & longitude.ToString().Replace(",", ".")
            End If

            Dim useStreetAddress As Boolean = IsInvalidOrdinate(latitude)

            If mapParameters.Length > 0 AndAlso Not mapParameters.StartsWith("&") Then
                mapParameters = "&" & mapParameters
            End If

            Dim lowerMapParameters As String = mapParameters.ToLowerInvariant()

            If width < 0 Then
                width = 600
            ElseIf width > 2048 Then
                width = 2048
            End If

            If height < 0 Then
                height = 300
            ElseIf height > 2048 Then
                height = 2048
            End If

            Dim str As New StringBuilder("", 300)

            If mapType Is Nothing OrElse mapType.Length = 0 Then
                mapType = "interactive"
            End If

            mapType = mapType.ToLowerInvariant()

            If mapType.Equals("staticimage") Then
                str.Append("http://maps.googleapis.com/maps/api/staticmap?")

                str.AppendFormat("center={0}", HttpUtility.UrlEncode(placeString))

                If Not lowerMapParameters.Contains("&markers=") Then
                    str.AppendFormat("&markers={0}", HttpUtility.UrlEncode(placeString))
                End If

                If Not lowerMapParameters.Contains("&size=") Then
                    str.AppendFormat("&size={0}x{1}", width, height)
                End If

                If googleKey.Length > 0 AndAlso Not lowerMapParameters.Contains("&key=") Then
                    str.Append("&key=")
                    str.Append(googleKey)
                End If

                If Not lowerMapParameters.Contains("&type=") Then
                    str.Append("&type=roadmap")
                End If

                If Not lowerMapParameters.Contains("&sensor=") Then
                    str.Append("&sensor=false")
                End If
            Else
                ' formats: https://maps.google.com/maps?f=q&source=s_q&hl=en&geocode=&;q=2870+Zanker+Road,+San+Jose,+CA&aq=0&oq=2870+zanker+&sll=37.0625,-95.677068&sspn=60.246331,135.263672&
                '          t=h&ie=UTF8&hq=&hnear=2870+Zanker+Rd,+San+Jose,+California+95134&ll=37.395119,-121.927557&spn=0.034095,0.035963&z=14&iwloc=A&output=embed&t=m
                '          http://maps.googleapis.com/maps/api/staticmap?center=2870+Zanker+Rd,San+Jose,CA,USA&zoom=13&size=600x300&maptype=roadmap&markers=%7c2870+Zanker+Rd,San+Jose,CA,USA&sensor=false
                '          http://maps.googleapis.com/maps/api/staticmap?center=37.39519,-121.92724&zoom=13&size=600x300&maptype=roadmap&markers=%7c37.39519,-121.92724&sensor=false
                '          https://maps.google.com/maps?f=q&source=s_q&hl=en&geocode=&;q=2870+Zanker+Road,+San+Jose,+CA&aq=0&oq=2870+zanker+&sll=37.0625,-95.677068&sspn=60.246331,135.263672&t=h&ie=UTF8&
                '          hq=&hnear=2870+Zanker+Rd,+San+Jose,+California+95134&ll=37.395119,-121.927557&spn=0.034095,0.035963&z=14&iwloc=A&output=embed&t=m
                str.Append("https://maps.google.com/maps?")

                str.AppendFormat("q={0}", HttpUtility.UrlEncode(placeString))

                If Not useStreetAddress Then
                    str.AppendFormat("&ll={0},{1}", latitude, longitude)
                End If

                If Not lowerMapParameters.Contains("&mrt=") Then
                    str.Append("&mrt=loc")
                End If

                If mapType.Equals("interactive") Then
                    If Not lowerMapParameters.Contains("&output=") Then
                        str.Append("&output=embed")
                    End If
                End If

                If Not lowerMapParameters.Contains("&t=") Then
                    str.Append("&t=m")
                End If

                If googleClientID <> "" Then
                    str.Append("&client=" & HttpUtility.UrlEncode(googleClientID))
                End If

                If googleSignature <> "" Then
                    str.Append("&signature=" & HttpUtility.UrlEncode(googleSignature))
                End If
            End If

            If lowerMapParameters <> "" Then
                str.Append(mapParameters)
            End If

            Return str.ToString()
        End Function


        ''' <summary>
        ''' Convert an object to string
        ''' </summary>
        ''' <param name="str">The input to be converted</param>
        ''' <returns>The input to be converted.</returns>
        Private Shared Function GetStr(ByVal str As Object) As String
            If str Is Nothing Then
                Return String.Empty
            End If
            Return str.ToString()
        End Function

#End Region

#Region "Misc"



        ''' <summary>
        ''' evaluate formula along with the data source object
        ''' </summary>
        ''' <param name="formula">formula to be evaluated</param>
        ''' <param name="dataSource">data source object to be used on evaluation</param>
        ''' <returns>text to display on quick selector</returns>
        ''' <remarks></remarks>
        Public Shared Function EvaluateFormula(ByVal formula As String, ByVal dataSource As BaseRecord) As String
            Dim variables As System.Collections.Generic.IDictionary(Of String, Object) = New System.Collections.Generic.Dictionary(Of String, Object)

            Dim evaluator As New BaseFormulaEvaluator
            If dataSource IsNot Nothing Then
                evaluator.Variables.Add(dataSource.TableAccess.TableDefinition.TableCodeName, dataSource)
                evaluator.DataSource = dataSource
            End If

            Dim resultObj As Object = evaluator.Evaluate(formula)
            If resultObj Is Nothing Then
                Return ""
            End If
            Return resultObj.ToString()

        End Function
#End Region

    End Class
End Namespace
