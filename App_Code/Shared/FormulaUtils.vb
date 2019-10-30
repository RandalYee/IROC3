Option Strict On
Imports Microsoft.VisualBasic
Imports System.IO
Imports BaseClasses
Imports BaseClasses.Data
Imports BaseClasses.Utils
Imports IROC2.UI
Imports IROC2.Data

Namespace IROC2

    ''' <summary>
    ''' The FormulaUtils class contains a set of functions that are available
    ''' in the Formula editor.  You can specify any of these functions after
    ''' the = sign.
    ''' For example, you can say:
    '''     = IsEven(32)
    ''' These functions throw an exception on an error.  The formula evaluator
    ''' catches this exception and returns the error string to the user interface.
    '''
    ''' All of the functions operate as a Decimal.  The Decimal data type is better
    ''' then Double or Single since it provides a more accurate value as compared to
    ''' Double, and a larger value as compared to a Single.  All integers, doubles, etc.
    ''' are converted to Decimals as part of these functions.
    '''
    ''' Function names are not case sensitive. So you can use ROUND, Round, round, etc.
    '''
    ''' </summary>
    ''' <remarks></remarks>
    Public Class FormulaUtils
        Inherits BaseFormulaUtils

#Region "Table Control-level functions"

        ''' <summary>
        ''' Sum the values of the displayed controls.  The ctlName must be
        ''' a textbox, label or literal.
        ''' This function should be called as [Products]TableControl.SUM("UnitPrice"), not
        ''' as shown here. The SUM function in the BaseApplicationTableControl will call this
        ''' function to actually perform the work - so that we can keep all of the formula
        ''' functions together in one place.
        ''' </summary>
        ''' <param name="tableControl">The table control instance.</param>
        ''' <param name="ctlName">The string name of the UI control (e.g., "UnitPrice") </param>
        ''' <returns>The total of adding the value contained in each of the fields.</returns>
        Public Overloads Shared Function Sum(ByVal tableControl As BaseApplicationTableControl, ByVal ctlName As String) As Decimal
            Dim total As Decimal = 0

            For Each item As Object In GetSortedValues(tableControl, ctlName)
                total += CDec(item)
            Next

            Return total
        End Function

        ''' <summary>
        ''' Sum the values of the displayed controls.  The ctlName must be
        ''' a textbox, label or literal.
        ''' This function should be called as [Products]TableControl.TOTAL("UnitPrice"), not
        ''' as shown here. The TOTAL function in the BaseApplicationTableControl will call this
        ''' function to actually perform the work - so that we can keep all of the formula
        ''' functions together in one place.
        ''' </summary>
        ''' <param name="tableControl">The table control instance.</param>
        ''' <param name="ctlName">The string name of the UI control (e.g., "UnitPrice") </param>
        ''' <returns>The total of adding the value contained in each of the fields.</returns>
        Public Overloads Shared Function Total(ByVal tableControl As BaseApplicationTableControl, ByVal ctlName As String) As Decimal
            Dim sum As Decimal = 0

            For Each item As Object In GetSortedValues(tableControl, ctlName)
                sum += CDec(item)
            Next

            Return sum
        End Function


        ''' <summary>
        ''' Finds the maximum among the values of the displayed controls.  The ctlName must be
        ''' a textbox, label or literal.
        ''' This function should be called as [Products]TableControl.Max("UnitPrice"), not
        ''' as shown here. The MAX function in the BaseApplicationTableControl will call this
        ''' function to actually perform the work - so that we can keep all of the formula
        ''' functions together in one place.
        ''' </summary>
        ''' <param name="tableControl">The table control instance.</param>
        ''' <param name="ctlName">The string name of the UI control (e.g., "UnitPrice") </param>
        ''' <returns>The maximum among the values contained in each of the fields.</returns>
        Public Overloads Shared Function Max(ByVal tableControl As BaseApplicationTableControl, ByVal ctlName As String) As Decimal
            Dim maxDecimal As Decimal = Decimal.MinValue

            For Each item As Object In GetSortedValues(tableControl, ctlName)
                maxDecimal = Math.Max(maxDecimal, CDec(item))
            Next

            Return maxDecimal
        End Function

        ''' <summary>
        ''' Finds the minimum among the values of the displayed controls.  The ctlName must be
        ''' a textbox, label or literal.
        ''' This function should be called as [Products]TableControl.Min("UnitPrice"), not
        ''' as shown here. The MIN function in the BaseApplicationTableControl will call this
        ''' function to actually perform the work - so that we can keep all of the formula
        ''' functions together in one place.
        ''' </summary>
        ''' <param name="tableControl">The table control instance.</param>
        ''' <param name="ctlName">The string name of the UI control (e.g., "UnitPrice") </param>
        ''' <returns>The minimum among the values contained in each of the fields.</returns>
        Public Overloads Shared Function Min(ByVal tableControl As BaseApplicationTableControl, ByVal ctlName As String) As Decimal
            Dim minDecimal As Decimal = Decimal.MaxValue

            For Each item As Object In GetSortedValues(tableControl, ctlName)
                minDecimal = Math.Min(minDecimal, CDec(item))
            Next

            Return minDecimal
        End Function

        ''' <summary>
        ''' Count the number of rows in this table control.
        ''' This function should be called as [Products]TableControl.COUNT(), not
        ''' as shown here. The COUNT function in the BaseApplicationTableControl will call this
        ''' function to actually perform the work - so that we can keep all of the formula
        ''' functions together in one place.
        ''' </summary>
        ''' <param name="tableControl">The table control instance.</param>
        ''' <param name="ctlName">The string name of the UI control (e.g., "UnitPrice") </param>
        ''' <returns>The count of the number of rows.</returns>
        Public Overloads Shared Function Count(ByVal tableControl As BaseApplicationTableControl, ByVal ctlName As String) As Integer
            Try
                Return tableControl.GetBaseRecordControls().Length()
            Catch ex As Exception
                ' If there is an error getting the length, we simply fall through and return 0.
            End Try

            Return 0
        End Function

        ''' <summary>
        ''' Count the number of rows in this table control that actually contain 
        ''' a decimal value (as opposed to be NULL or invalid value)
        ''' This function should be called as [Products]TableControl.COUNTA("UnitPrice"), not
        ''' as shown here. The COUNTA function in the BaseApplicationTableControl will call this
        ''' function to actually perform the work - so that we can keep all of the formula
        ''' functions together in one place.
        ''' </summary>
        ''' <param name="tableControl">The table control instance.</param>
        ''' <param name="ctlName">The string name of the UI control (e.g., "UnitPrice") </param>
        ''' <returns>The count of the number of rows.</returns>
        Public Shared Function CountA(ByVal tableControl As BaseApplicationTableControl, ByVal ctlName As String) As Integer
            Dim recCtl As BaseApplicationRecordControl
            Dim totalRows As Integer = 0

            ' Get all of the record controls within this table control.
            For Each recCtl In tableControl.GetBaseRecordControls()
                Dim ctl As Control
                ' The control itself may be embedded in sub-panels, so we need to use
                ' FindControlRecursively starting from the recCtl.
                ctl = MiscUtils.FindControlRecursively(recCtl, ctlName)
                If Not (IsNothing(ctl)) Then
                    ' Add the row if this contains a valid number.
                    Dim val As String = Nothing
                    ' Get the value from the textbox, label or literal
                    If TypeOf ctl Is System.Web.UI.WebControls.TextBox Then
                        val = CType(ctl, TextBox).Text
                    ElseIf TypeOf ctl Is System.Web.UI.WebControls.Label Then
                        val = CType(ctl, Label).Text
                    ElseIf TypeOf ctl Is System.Web.UI.WebControls.Literal Then
                        val = CType(ctl, Literal).Text
                    End If
                    Try
                        If Not (IsNothing(val)) AndAlso val.Trim.Length > 0 Then
                            totalRows += 1
                        End If
                    Catch ex As Exception
                        ' Ignore exception - since this is only returning the 
                        ' rows that contain a valid value.  Other rows with a
                        ' NULL value or an invalid value will not be counted.
                    End Try
                End If
            Next

            Return totalRows
        End Function

        ''' <summary>
        ''' Calulates the Mean (Average) of the values of the displayed controls.  The ctlName must be
        ''' a textbox, label or literal.
        ''' We could have implemented this as a call to SUM()/COUNT(), but decided to do it this way
        ''' for efficiency.
        ''' This function should be called as [Products]TableControl.MEAN("UnitPrice"), not
        ''' as shown here. The MEAN function in the BaseApplicationTableControl will call this
        ''' function to actually perform the work - so that we can keep all of the formula
        ''' functions together in one place.
        ''' </summary>
        ''' <param name="tableControl">The table control instance.</param>
        ''' <param name="ctlName">The string name of the UI control (e.g., "UnitPrice") </param>
        ''' <returns>The total of adding the value contained in each of the fields.</returns>
        Public Shared Function Mean(ByVal tableControl As BaseApplicationTableControl, ByVal ctlName As String) As Decimal
            Dim recCtl As BaseApplicationRecordControl
            Dim total As Decimal = 0
            Dim numRows As Integer = 0

            ' Get all of the record controls within this table control.
            For Each recCtl In tableControl.GetBaseRecordControls()
                Dim ctl As Control
                ' The control itself may be embedded in sub-panels, so we need to use
                ' FindControlRecursively starting from the recCtl.
                ctl = MiscUtils.FindControlRecursively(recCtl, ctlName)
                If Not (IsNothing(ctl)) Then
                    Dim val As String = Nothing
                    ' Get the value from the textbox, label or literal
                    If TypeOf ctl Is System.Web.UI.WebControls.TextBox Then
                        val = CType(ctl, TextBox).Text
                    ElseIf TypeOf ctl Is System.Web.UI.WebControls.Label Then
                        val = CType(ctl, Label).Text
                    ElseIf TypeOf ctl Is System.Web.UI.WebControls.Literal Then
                        val = CType(ctl, Literal).Text
                    End If

                    Try
                        ' If the value is not a valid number, ignore it.
                        total += ParseDecimal(val)
                    Catch ex As Exception
                        ' Ignore exception.
                    End Try

                    ' Mean is calculated based on the number of rows, NOT on
                    ' the number of non-NULL values.  So in this way, it is based on
                    ' COUNT and not on COUNTA.
                    numRows += 1
                End If
            Next

            Return (total / numRows)
        End Function

        ''' <summary>
        ''' Calulates the Average of the values of the displayed controls.  The ctlName must be
        ''' a textbox, label or literal.
        ''' We could have implemented this as a call to SUM()/COUNT(), but decided to do it this way
        ''' for efficiency.
        ''' This function should be called as [Products]TableControl.AVERAGE("UnitPrice"), not
        ''' as shown here. The AVERAGE function in the BaseApplicationTableControl will call this
        ''' function to actually perform the work - so that we can keep all of the formula
        ''' functions together in one place.
        ''' </summary>
        ''' <param name="tableControl">The table control instance.</param>
        ''' <param name="ctlName">The string name of the UI control (e.g., "UnitPrice") </param>
        ''' <returns>The total of adding the value contained in each of the fields.</returns>
        Public Overloads Shared Function Average(ByVal tableControl As BaseApplicationTableControl, ByVal ctlName As String) As Decimal
            Return Mean(tableControl, ctlName)
        End Function

        ''' <summary>
        ''' Return the Mode of this control.
        ''' This function should be called as [Products]TableControl.MODE("UnitPrice"), not
        ''' as shown here. The MODE function in the BaseApplicationRecordControl will call this
        ''' function to actually perform the work - so that we can keep all of the formula
        ''' functions together in one place.
        ''' Say there are 5 rows and they contain 57, 57, 12, 57, 98.
        ''' The Mode is 57 as it is the number which repeats the maximum number of times.
        ''' </summary>
        ''' <param name="tableControl">The table control instance.</param>
        ''' <param name="ctlName">The string name of the UI control (e.g., "UnitPrice") </param>
        ''' <returns>The row number of the recordControl passed in.  0 if this is not a correct row number. </returns>
        Public Shared Function Mode(ByVal tableControl As BaseApplicationTableControl, ByVal ctlName As String) As Decimal
            Dim rankedArray As ArrayList = GetSortedValues(tableControl, ctlName)

            Dim num As Decimal = 0
            Dim modeVal As Decimal = 0

            Dim count As Integer = 0
            Dim max As Integer = 0

            ' Because this is a sorted array, we can 
            For Each item As Object In rankedArray
                If num <> CDec(item) Then
                    num = CDec(item)
                    count = 1
                Else
                    count += 1
                End If

                If count > max Then
                    max = count
                    modeVal = num
                End If
            Next

            Return modeVal
        End Function

        ''' <summary>
        ''' Return the Median of this control.
        ''' This function should be called as [Products]TableControl.MEDIAN("UnitPrice"), not
        ''' as shown here. The MEDIAN function in the BaseApplicationRecordControl will call this
        ''' function to actually perform the work - so that we can keep all of the formula
        ''' functions together in one place.
        ''' Say there are 5 rows and they contain 57, 32, 12, 19, 98.
        ''' The order is 12, 19, 32, 57, 98 - so the Median is 32.
        ''' If the number of numbers is even, the Median is the average of the two middle numbers.
        ''' Say there are 6 rows and they contain 57, 32, 12, 19, 98, 121
        ''' The order is 12, 19, 32, 57, 98, 121 - so the two numbers in the mid are 32 and 57.
        ''' So the median is (32 + 57) / 2 = 89/2 = 44.5
        ''' </summary>
        ''' <param name="tableControl">The table control instance.</param>
        ''' <param name="ctlName">The string name of the UI control (e.g., "UnitPrice") </param>
        ''' <returns>The row number of the recordControl passed in.  0 if this is not a correct row number. </returns>
        Public Shared Function Median(ByVal tableControl As BaseApplicationTableControl, ByVal ctlName As String) As Decimal
            Dim rankedArray As ArrayList = GetSortedValues(tableControl, ctlName)

            ' If there are 0 elements, then there is no median.
            If rankedArray.Count = 0 Then Return 0

            Dim halfPoint As Integer = CInt(Math.Floor(rankedArray.Count / 2))
            Dim medianValue As Decimal = 0
            If rankedArray.Count Mod 2 = 0 Then
                medianValue = (CDec(rankedArray.Item(halfPoint - 1)) + CDec(rankedArray(halfPoint))) / 2
            Else
                ' Odd numbered items.  So 
                medianValue = CDec(rankedArray.Item(halfPoint))
            End If

            Return medianValue
        End Function

        ''' <summary>
        ''' Return the Range of this control.
        ''' This function should be called as [Products]TableControl.RANGE("UnitPrice"), not
        ''' as shown here. The RANGE function in the BaseApplicationRecordControl will call this
        ''' function to actually perform the work - so that we can keep all of the formula
        ''' functions together in one place.
        ''' Say there are 5 rows and they contain 57, 32, 12, 19, 98.
        ''' The lowest is 12, highest is 98, so the range is 98-12 = 86
        ''' </summary>
        ''' <param name="tableControl">The table control instance.</param>
        ''' <param name="ctlName">The string name of the UI control (e.g., "UnitPrice") </param>
        ''' <returns>The row number of the recordControl passed in.  0 if this is not a correct row number. </returns>
        Public Shared Function Range(ByVal tableControl As BaseApplicationTableControl, ByVal ctlName As String) As Decimal
            Dim rankedArray As ArrayList = GetSortedValues(tableControl, ctlName)

            ' If there are 0 or 1 elements, then there is no range.
            If rankedArray.Count <= 1 Then Return 0

            ' Take the difference between the largest and the smallest.
            Return CDec(rankedArray.Item(rankedArray.Count - 1)) - CDec(rankedArray.Item(0))
        End Function

#End Region

#Region "Record Control-level functions"

        ''' <summary>
        ''' designed to be used on Quick Selector, repeater row
        ''' </summary>
        ''' <param name="datasource"></param>
        ''' <returns>text to display on quick selector</returns>
        ''' <remarks></remarks>
        Public Shared Function GetQuickSelectorDisplayText(ByVal datasource As BaseClasses.Data.BaseRecord) As String
            If URL("Formula") <> "" Then
                Return BaseFormulaUtils.EvaluateFormula(URL("Formula"), datasource)
            End If
            If URL("DFKA") <> "" Then
                Dim col As BaseColumn = datasource.TableAccess.TableDefinition.ColumnList.GetByAnyName(URL("DFKA"))
                Return datasource.GetValue(col).ToString()
            End If
            If URL("IndexField") <> "" Then
                Dim col As BaseColumn = datasource.TableAccess.TableDefinition.ColumnList.GetByAnyName(URL("IndexField"))
                Return datasource.GetValue(URL("IndexField")).ToString()
            End If
            Return ""
        End Function

        ''' <summary>
        ''' Return the row number of this record control.
        ''' This function should be called as [Products]TableControlRow.ROWNUM(), not
        ''' as shown here. The ROWNUM function in the BaseApplicationRecordControl will call this
        ''' function to actually perform the work - so that we can keep all of the formula
        ''' functions together in one place.
        ''' </summary>
        ''' <param name="tableControl">The table control instance.</param>
        ''' <param name="recordControl">The record control whose row number is being determined.  Row numbers are 1-based.</param>
        ''' <returns>The row number of the recordControl passed in.  0 if this is not a correct row number. </returns>
        Public Shared Function RowNum(ByVal tableControl As BaseApplicationTableControl, ByVal recordControl As BaseApplicationRecordControl) As Integer
            Dim recCtl As BaseApplicationRecordControl
            Dim rowNumber As Integer = 1

            ' Get all of the record controls within this table control.
            For Each recCtl In tableControl.GetBaseRecordControls()
                If Object.ReferenceEquals(recCtl, recordControl) Then
                    ' We found the row.
                    Return rowNumber
                End If
                rowNumber += 1
            Next

            Return 0
        End Function

        ''' <summary>
        ''' Return the Rank of this control.
        ''' This function should be called as [Products]TableControlRow.RANK("UnitPrice"), not
        ''' as shown here. The RANK function in the BaseApplicationRecordControl will call this
        ''' function to actually perform the work - so that we can keep all of the formula
        ''' functions together in one place.
        ''' Say there are 5 rows and they contain 57, 32, 12, 19, 98.
        ''' Their respecitive ranks will be 4, 3, 1, 2, 5
        ''' </summary>
        ''' <param name="tableControl">The table control instance.</param>
        ''' <param name="recordControl">The record control whose tank is being determined.  Rank numbers are 1-based.</param>
        ''' <param name="ctlName">The string name of the UI control (e.g., "UnitPrice") </param>
        ''' <returns>The row number of the recordControl passed in.  0 if this is not a correct row number. </returns>
        Public Shared Function Rank(ByVal tableControl As BaseApplicationTableControl, ByVal recordControl As BaseApplicationRecordControl, ByVal ctlName As String) As Integer
            Dim recCtl As BaseApplicationRecordControl
            Dim rankedArray As ArrayList = New ArrayList()
            Dim lookFor As Decimal = 0

            ' Get all of the record controls within this table control.
            For Each recCtl In tableControl.GetBaseRecordControls()
                Dim ctl As Control
                ' The control itself may be embedded in sub-panels, so we need to use
                ' FindControlRecursively starting from the recCtl.
                ctl = MiscUtils.FindControlRecursively(recCtl, ctlName)
                If Not (IsNothing(ctl)) Then
                    Dim textVal As String = Nothing
                    Dim val As Decimal = 0

                    ' Get the value from the textbox, label or literal
                    If TypeOf ctl Is System.Web.UI.WebControls.TextBox Then
                        textVal = CType(ctl, TextBox).Text
                    ElseIf TypeOf ctl Is System.Web.UI.WebControls.Label Then
                        textVal = CType(ctl, Label).Text
                    ElseIf TypeOf ctl Is System.Web.UI.WebControls.Literal Then
                        textVal = CType(ctl, Literal).Text
                    End If

                    Try
                        ' If the value is not a valid number, ignore it.
                        val = ParseDecimal(textVal)
                        rankedArray.Add(val)
                        ' Save the value that we need to look for to determine the rank
                        If Object.ReferenceEquals(recCtl, recordControl) Then
                            lookFor = val
                        End If
                    Catch ex As Exception
                        ' Ignore exception.
                    End Try
                End If
            Next

            ' Sort the array now.
            rankedArray.Sort()

            ' Rank is always 1 based in our case.  So we need to add one to the
            ' location returned by IndexOf
            Return rankedArray.IndexOf(lookFor) + 1
        End Function

        ''' <summary>
        ''' Return the running total of the control.
        ''' This function should be called as [Products]TableControlRow.RUNNINGTOTAL("UnitPrice"), not
        ''' as shown here. The RUNNINGTOTAL function in the BaseApplicationRecordControl will call this
        ''' function to actually perform the work - so that we can keep all of the formula
        ''' functions together in one place.
        ''' Say there are 5 rows and they contain 57, 32, 12, 19, 98.
        ''' Their respecitive running totals will be 57, 89, 101, 120, 218
        ''' </summary>
        ''' <param name="tableControl">The table control instance.</param>
        ''' <param name="recordControl">The record control whose running total is being determined.</param>
        ''' <param name="ctlName">The string name of the UI control (e.g., "UnitPrice") </param>
        ''' <returns>The running total of the recordControl passed in.</returns>
        Public Shared Function RunningTotal(ByVal tableControl As BaseApplicationTableControl, ByVal recordControl As BaseApplicationRecordControl, ByVal ctlName As String) As Decimal
            Dim recCtl As BaseApplicationRecordControl
            Dim lookFor As Decimal = 0
            Dim total As Decimal = 0
            ' Get all of the record controls within this table control.
            For Each recCtl In tableControl.GetBaseRecordControls()
                Dim ctl As Control

                ' The control itself may be embedded in sub-panels, so we need to use
                ' FindControlRecursively starting from the recCtl.
                ctl = MiscUtils.FindControlRecursively(recCtl, ctlName)
                If Not (IsNothing(ctl)) Then
                    Dim textVal As String = Nothing
                    Dim val As Decimal = 0

                    ' Get the value from the textbox, label or literal
                    If TypeOf ctl Is System.Web.UI.WebControls.TextBox Then
                        textVal = CType(ctl, TextBox).Text
                    ElseIf TypeOf ctl Is System.Web.UI.WebControls.Label Then
                        textVal = CType(ctl, Label).Text
                    ElseIf TypeOf ctl Is System.Web.UI.WebControls.Literal Then
                        textVal = CType(ctl, Literal).Text
                    End If

                    Try
                        ' If the value is not a valid number, ignore it.
                        val = ParseDecimal(textVal)
                        total = val + total
                        ' If the row till which we are finding the running total, return the total till that row
                        If Object.ReferenceEquals(recCtl, recordControl) Then
                            Return total
                        End If
                    Catch ex As Exception
                        ' Ignore exception.
                    End Try
                End If
            Next
            Return total
        End Function


#End Region

#Region "Private"


        ''' <summary>
        ''' GetSortedValues is a private function that returns the list of sorted values of
        ''' the given control name.  This is used by Rank, Median, Average, Mode, etc.
        ''' </summary>
        ''' <param name="tableControl">The table control instance.</param>
        ''' <param name="ctlName">The string name of the UI control (e.g., "UnitPrice") </param>
        ''' <returns>A sorted array of values for the given control. </returns>
        Private Shared Function GetSortedValues(ByVal tableControl As BaseApplicationTableControl, ByVal ctlName As String) As ArrayList
            Dim recCtl As BaseApplicationRecordControl
            Dim rankedArray As ArrayList = New ArrayList()

            ' Get all of the record controls within this table control.
            For Each recCtl In tableControl.GetBaseRecordControls()
                Dim ctl As Control
                ' The control itself may be embedded in sub-panels, so we need to use
                ' FindControlRecursively starting from the recCtl.
                ctl = MiscUtils.FindControlRecursively(recCtl, ctlName)
                If Not (IsNothing(ctl)) AndAlso ctl.Visible Then
                    Dim textVal As String = Nothing
                    Dim val As Decimal = 0

                    ' Get the value from the textbox, label or literal
                    If TypeOf ctl Is System.Web.UI.WebControls.TextBox Then
                        textVal = CType(ctl, TextBox).Text
                    ElseIf TypeOf ctl Is System.Web.UI.WebControls.Label Then
                        textVal = CType(ctl, Label).Text
                    ElseIf TypeOf ctl Is System.Web.UI.WebControls.Literal Then
                        textVal = CType(ctl, Literal).Text
                    End If

                    Try
                        ' If the value is not a valid number, ignore it.
                        val = ParseDecimal(textVal)
                        rankedArray.Add(val)
                    Catch ex As Exception
                        ' Ignore exception.
                    End Try
                End If
            Next

            ' Sort the array now.
            rankedArray.Sort()

            Return rankedArray
        End Function

#End Region


    End Class

End Namespace