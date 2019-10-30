Imports BaseClasses
Imports BaseClasses.Utils
Imports BaseClasses.Data

Namespace IROC2
    Partial Public Class ExportFieldValue
        Inherits IROC2.UI.BaseApplicationPage

#Region " Generated Code for Web Form Designer "
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
#End Region

        Private Const ASSEMBLY_NAME As String = "IROC2.Business"

        Public Sub New()
            MyBase.New()
        End Sub

        Public ReadOnly Property FieldId() As String
            Get
                Return Me.Decrypt(Me.Request.Params.Item("Field"))
            End Get
        End Property

        Public ReadOnly Property FileName() As String
            Get
                Dim fn As String = Me.Request.Params.Item("FileName")
                Try
                    ' Try to decrypt
                    Return Me.Decrypt(fn)
                Catch
                    ' For backward compatibility we support unencrypted version as well
                    Return fn
                End Try
            End Get
        End Property
        
        Public ReadOnly Property RecordId() As String
            Get
                Return Me.Decrypt(Me.Request.Params.Item("Record"))
            End Get
        End Property

        Public ReadOnly Property TableId() As String
            Get
                Dim tableName As String = Me.Request.Params.Item("Table")
                If String.IsNullOrEmpty(tableName) Then Return ""
                tableName = Me.Decrypt(tableName)
                Return tableName
            End Get
        End Property

        Public ReadOnly Property Offset() As Integer
            Get
                If Not IsNothing(Me.Request.Params.Item("Offset")) Then
                    Return CInt(Me.Request.Params.Item("Offset"))
                Else
                    Return 0
                End If
            End Get
        End Property
        Public ReadOnly Property ImageHeight() As Integer
	    Get
		If Not IsNothing(Me.Request.Params.Item("ImageHeight")) Then
			Return CInt(Me.Request.Params.Item("ImageHeight"))
		Else
		    Return 0
		End If
	    End Get
	End Property
	    Public ReadOnly Property ImageWidth() As Integer
	    Get
		If Not IsNothing(Me.Request.Params.Item("ImageWidth")) Then
			Return CInt(Me.Request.Params.Item("ImageWidth"))
		 Else
		    Return 0
		End If
	    End Get
        End Property
        Public ReadOnly Property ImagePercentSize() As Double
            Get
                If Not IsNothing(Me.Request.Params.Item("ImagePercentSize")) Then
                    Return CDbl(Me.Request.Params.Item("ImagePercentSize"))
                Else
                    Return 0.0
                End If
            End Get
        End Property
        ' Handler for the Load event.
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Validate the URL params
            If ((Len(BaseClasses.Utils.GetUrlParam(Me, "Table", True)) < 1) OrElse _
                (Len(BaseClasses.Utils.GetUrlParam(Me, "Record", True)) < 1) OrElse _
                (Len(BaseClasses.Utils.GetUrlParam(Me, "Field", True)) < 1) _
            ) Then
                Return
            End If
            Me.DataBind() 'Always call DataBind, even on PostBacks.
            Me.ExportData() 'Then export the data
        End Sub

        Protected Sub ExportData()
            If String.IsNullOrEmpty(Me.TableId) Then
                Return
            End If
            Try
                Dim t As PrimaryKeyTable = DirectCast(DatabaseObjects.GetTableObject(Me.TableId), PrimaryKeyTable)
                Dim rec As IRecord = t.GetRecordData(Me.RecordId, False)
                If (Me.ImagePercentSize <> 100.0 AndAlso Not (Me.ImagePercentSize = 0.0)) OrElse Not (Me.ImageHeight = 0 OrElse Me.ImageWidth = 0) Then
                    ' To display image with shrinking according to user specified height/width or ImagePercentSize
                    Dim fieldData As ColumnValue = MiscUtils.GetData(rec, _
                                             t.TableDefinition.ColumnList.GetByAnyName(Me.FieldId) _
                                           )
                    Dim binaryData() As Byte = MiscUtils.GetBinaryData(t.TableDefinition.ColumnList.GetByAnyName(Me.FieldId), _
                                                              fieldData)
                    If binaryData Is Nothing OrElse binaryData.Length = 0 Then
                        RegisterJScriptAlert(Me, "No Content", "Field " & Me.FieldId & " does not contain any binary data.", False, True)
                        Return
                    End If
                    Dim thumbNailSizeImage() As Byte = GetThumbNailSizeImage(binaryData)
                    Dim filName As String = MiscUtils.GetFileNameWithExtension(t.TableDefinition.ColumnList.GetByAnyName(Me.FieldId), _
                                          binaryData, _
                                        Nothing)
                    MiscUtils.SendToWriteResponse(Me.Response, _
                                       thumbNailSizeImage, _
                                      filName, _
                                      t.TableDefinition.ColumnList.GetByAnyName(Me.FieldId), _
                                         fieldData, _
                                       Me.Offset)
                Else
                    'Calling ExportFieldData method without image shrinking.
                    If Not MiscUtils.ExportFieldData( _
                        Me.Response, _
                        rec, _
                        t.TableDefinition.ColumnList.GetByAnyName(Me.FieldId), _
                        FileName, _
                        Me.Offset) Then
                        RegisterJScriptAlert(Me, "No Content", "Field " & Me.FieldId & " does not contain any binary data.", False, True)
                    End If
                End If

            Catch ex As Exception
            End Try
        End Sub
        Protected Function GetThumbNailSizeImage(ByVal binaryData() As Byte) As Byte()
            Dim ThumbNailBinaryData() As Byte = Nothing
            Try
                Dim TempMemStream As New System.IO.MemoryStream(binaryData)
                Dim ImageObj As System.Drawing.Image
                Dim ThumbSizeImageObj As System.Drawing.Image
                ImageObj = System.Drawing.Image.FromStream(TempMemStream)
                Dim temHeight As Integer
                Dim temWidth As Integer
                temHeight = ImageObj.Height
                temWidth = ImageObj.Width
                Dim TempFileStream As New System.IO.MemoryStream
                'If Imagesize is less than 20*20 then return the original image
                If (temWidth < 20 And temHeight < 20) Then
                    Dim ImageBinaryData() As Byte
                    Try
                        ' load as raw format so that the image can have transparency is retained.
                        ImageObj.Save(TempFileStream, ImageObj.RawFormat)
                    Catch ex As Exception
                        ' if exception happens which can be for .ico, then load as jpeg but transparency cannot be retained.
                        ImageObj.Save(TempFileStream, System.Drawing.Imaging.ImageFormat.Jpeg)
                    End Try

                    ImageBinaryData = New Byte(CType(TempFileStream.Length, Integer)) {}
                    ImageBinaryData = TempFileStream.ToArray()
                    Return ImageBinaryData
                End If
                Dim ImagePercentSize As Double = Me.ImagePercentSize
                ' If the ImagePercentSize is 0.2 then the actual percent calculation will result in generating
                ' temHeight and temWidth as Zero. When the height and width is zero, GetThumbnailImage() 
                ' will generate image of arbitrary size. Hence the image will not display as predicted, 
                ' ie, with size 0.2%. For this purpose, to maintain consistant image size, when ImagePercentSize 
                ' is less than 1, it is taken as actual percentage for eg. when ImagePercentSize is 0.2, it is considered as 20%
                ' and image will displayed with 20% of original size.
                If (Me.ImagePercentSize <= 1) Then
                    ImagePercentSize = Me.ImagePercentSize * 100
                End If
                'Actual percentage calculation. as ImagePercentSize value provided by client is a number not a percent
                ImagePercentSize = ImagePercentSize / 100
                temHeight = CInt(ImagePercentSize * temHeight)
                temWidth = CInt(ImagePercentSize * temWidth)
                'Create thumbnail size of the original Image ImageObj
                If (Me.ImagePercentSize = 0.0) Then
                    ThumbSizeImageObj = ImageObj.GetThumbnailImage(Me.ImageWidth, Me.ImageHeight, Nothing, IntPtr.Zero)
                Else
                    ThumbSizeImageObj = ImageObj.GetThumbnailImage(temWidth, temHeight, Nothing, IntPtr.Zero)
                End If
                Try
                    ' load as raw format so that the image can have transparency is retained.
                    ThumbSizeImageObj.Save(TempFileStream, ImageObj.RawFormat)
                Catch ex As Exception
                    ' if exception happens which can be for .ico, then load as jpeg but transparency cannot be retained.
                    ThumbSizeImageObj.Save(TempFileStream, System.Drawing.Imaging.ImageFormat.Jpeg)
                End Try

                ThumbNailBinaryData = New Byte(CType(TempFileStream.Length, Integer)) {}
                ThumbNailBinaryData = TempFileStream.ToArray()
            Catch ex As Exception
            End Try
            Return ThumbNailBinaryData
        End Function
        'Since this is a "utility" page, do not log requests for it in the Session's Navigation History
        Protected Overrides Sub UpdateSessionNavigationHistory()
            'Do Nothing
        End Sub

    End Class
End Namespace



