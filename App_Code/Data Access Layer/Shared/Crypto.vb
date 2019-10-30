Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Imports System.Web
Imports BaseClasses.Resources

'SymmCrypto is a wrapper of System.Security.Cryptography.SymmetricAlgorithm classes
'and simplifies the interface. It supports customized SymmetricAlgorithm as well.
'Original Code from Frank Fang
'Revised by Jerome Howard to remove Bad Data errors, create seperate CryptoIV and
'use the maximum legal keysize for each encryption algorithm

Namespace IROC2.Data

    Public Class Crypto
        '256 Bit IV Key that is truncated when a smaller keys are required
        Private bytIV() As Byte = _
{78, 90, 23, 7, 54, 109, 34, 231, 90, 66, 109, 185, 228, 143, 89, 77, 190, 89, 103, 148, 54, 4, 98, 67, 243, 162, 68, 201, 73, 59, 184, 52}
        'Supported .Net intrinsic SymmetricAlgorithm classes.
        Public Enum Providers
            DES
            RC2
            Rijndael
        End Enum

        Private _CryptoService As SymmetricAlgorithm

        Public Sub New()
            ' Use the default provider of DES.
            Me.New(Crypto.Providers.DES)
        End Sub

        'Constructor for using an intrinsic .Net SymmetricAlgorithm class.
        Public Sub New(ByVal NetSelected As Providers)
            Select Case NetSelected
                Case Providers.DES
                    _CryptoService = New DESCryptoServiceProvider
                Case Providers.RC2
                    _CryptoService = New RC2CryptoServiceProvider
                Case Providers.Rijndael
                    _CryptoService = New RijndaelManaged
            End Select
        End Sub

        'Constructor for using a customized SymmetricAlgorithm class.
        Public Sub New(ByVal ServiceProvider As SymmetricAlgorithm)
            _CryptoService = ServiceProvider
        End Sub

        'Depending on the legal key size limitations of a specific CryptoService provider
        'and length of the private key provided, padding the secret key with a character
        'or triming it to meet the legal size of the algorithm.
        Private Function GetLegalKey(ByVal Key As String) As Byte()
            'key sizes are in bits
            Dim sTemp As String
            Dim dValue As Integer
            If (_CryptoService.LegalKeySizes.Length > 0) Then
                Dim maxSize As Integer = _CryptoService.LegalKeySizes(0).MaxSize
                dValue = CInt(maxSize / 8)
                If Key.Length * 8 > maxSize Then
                    sTemp = Key.Substring(0, dValue)
                Else
                    Dim moreSize As Integer = _CryptoService.LegalKeySizes(0).MinSize
                    Do While (Key.Length * 8 > moreSize)
                        moreSize += _CryptoService.LegalKeySizes(0).SkipSize
                    Loop
                    sTemp = Key.PadRight(dValue, "X".Chars(0))
                End If
            Else
                sTemp = Key
            End If

            'Ensure that the IV Block size is also correct for the specific CryptoService provider
            If (_CryptoService.LegalBlockSizes.Length > 0) Then
                Dim maxSize As Integer = _CryptoService.LegalBlockSizes(0).MaxSize
                dValue = CInt(maxSize / 8)
                ReDim Preserve bytIV(sTemp.Length - 1)
                If sTemp.Length * 8 > maxSize Then
                    ReDim Preserve bytIV(dValue - 1)
                End If
            End If
            'convert the secret key to byte array
            Return ASCIIEncoding.ASCII.GetBytes(sTemp)
        End Function

        Public Overridable Function Encrypt(ByVal Source As String, Optional ByVal includeSession As Boolean = True) As String
            If (Source Is Nothing) Then
                Return ""
            End If
            Dim s As String = ""
            Try
                If includeSession Then
                    s = Me.Encrypt(Source, Me.GetCryptoKey(), False)
                    s = System.Web.HttpUtility.UrlEncode(s)
                Else
                    s = Me.Encrypt(Source, Me.GetCryptoKeyWithoutSessionVariable(), False)
                End If
            Catch ex As Exception
                ' In case of error, just return the source itself without encryption.
                s = Source
            End Try
            Return s
        End Function

        Public Function Encrypt(ByVal Source As String, ByVal Key As String, Optional ByVal Encoded As Boolean = True) As String
            Return Me.Encrypt(Source, Key, System.Text.Encoding.ASCII, Encoded)
        End Function

        Public Function Encrypt(ByVal Source As String, ByVal Key As String, ByVal Encoding As System.Text.Encoding, Optional ByVal Encoded As Boolean = True) As String
            If Source Is Nothing OrElse Source.Trim.Length = 0 Then
                Return Source
            End If


            If Encoded Then
                Source = System.Web.HttpUtility.UrlEncode(Source)
            End If
            Dim bytIn As Byte()


            If Encoding.EncodingName = System.Text.Encoding.ASCII.EncodingName Then
                bytIn = System.Text.ASCIIEncoding.GetEncoding(System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ANSICodePage).GetBytes(Source)
            ElseIf Encoding.EncodingName = System.Text.Encoding.Unicode.EncodingName Then
                bytIn = System.Text.UnicodeEncoding.GetEncoding(System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ANSICodePage).GetBytes(Source)
            Else
                bytIn = System.Text.ASCIIEncoding.GetEncoding(System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ANSICodePage).GetBytes(Source)
            End If
            '= System.Text.ASCIIEncoding.ASCII.GetBytes(Source)
            Dim ms As MemoryStream = New MemoryStream

            'set the keys
            _CryptoService.Key = GetLegalKey(Key)
            _CryptoService.IV = bytIV

            'create an Encryptor from the Provider Service instance
            Dim encrypto As ICryptoTransform = _CryptoService.CreateEncryptor()

            'create Crypto Stream that transforms a stream using the encryption
            Dim cs As CryptoStream = New CryptoStream(ms, encrypto, CryptoStreamMode.Write)

            'write out encrypted content into MemoryStream
            cs.Write(bytIn, 0, bytIn.Length)
            cs.FlushFinalBlock()
            cs.Close()
            Dim bytOut() As Byte = ms.ToArray()
            ms.Close()

            Return Convert.ToBase64String(bytOut) 'convert into Base64 so that the result can be used in xml
        End Function

        Public Overridable Function GetDecryptedURLParameter(ByVal name As String, ByVal request As System.Web.HttpRequest) As String
            If request(name) <> "" Then
                Try
                    Return Me.Decrypt(request(name), Me.GetCryptoKey(), False)

                Catch ex As Exception
                    Return request(name)
                End Try
            End If
            Return ""
        End Function


        Public Function Decrypt(ByVal Source As String) As String

            Dim s As String = ""
            Try
                ' First try decrypting as is.
                s = Me.Decrypt(Source, Me.GetCryptoKey(), False)
                s = System.Web.HttpUtility.UrlDecode(s)
            Catch
                Try
                    ' If the first try of decrypting does not work, then
                    ' URL decode it and try again.  This is to ensure that if
                    ' the encrypted key is passed through the URL, it needs to
                    ' be decoded first.
                    Source = System.Web.HttpUtility.UrlDecode(Source)
                    s = Me.Decrypt(Source, Me.GetCryptoKey(), False)
                Catch
                    Throw New System.UriFormatException(RU.GetErrMsg(RU.ErrRes.GetRecords))


                End Try
            End Try

            If (Source IsNot Nothing AndAlso Source.Trim() <> "") AndAlso (s Is Nothing OrElse s.Trim() = "") Then
                s = Me.Decrypt(Source, False)
            End If


            If (Source IsNot Nothing AndAlso Source.Trim() <> "") AndAlso (s Is Nothing OrElse s.Trim() = "") Then
                Throw New System.UriFormatException(RU.GetErrMsg(RU.ErrRes.GetRecords))
            End If

            Return s
        End Function

        Public Function Decrypt(ByVal Source As String, ByVal includeSession As Boolean) As String

            Dim s As String = ""
            Try
                ' First try decrypting as is.
                If includeSession Then
                    s = Me.Decrypt(Source, Me.GetCryptoKey(), False)
                Else
                    s = Me.Decrypt(Source, Me.GetCryptoKeyWithoutSessionVariable(), False)
                End If
                s = System.Web.HttpUtility.UrlDecode(s)
            Catch
                Try
                    ' If the first try of decrypting does not work, then
                    ' URL decode it and try again.  This is to ensure that if
                    ' the encrypted key is passed through the URL, it needs to
                    ' be decoded first.
                    Source = System.Web.HttpUtility.UrlDecode(Source)
                    If includeSession Then
                        s = Me.Decrypt(Source, Me.GetCryptoKey(), False)
                    Else
                        s = Me.Decrypt(Source, Me.GetCryptoKeyWithoutSessionVariable(), False)
                    End If
                Catch
                    Throw New System.UriFormatException(RU.GetErrMsg(RU.ErrRes.GetRecords))
                End Try
            End Try

            If (Source IsNot Nothing AndAlso Source.Trim() <> "") AndAlso (s Is Nothing OrElse s.Trim() = "") Then
                Throw New System.UriFormatException(RU.GetErrMsg(RU.ErrRes.GetRecords))
            End If

            Return s
        End Function

        Public Function Decrypt(ByVal Source As String, ByVal Key As String, Optional ByVal Encoded As Boolean = True) As String
            Return Me.Decrypt(Source, Key, System.Text.Encoding.ASCII, Encoded)
        End Function

        Public Function Decrypt(ByVal Source As String, ByVal Key As String, ByVal Encoding As System.Text.Encoding, Optional ByVal Encoded As Boolean = True) As String
            If Source Is Nothing OrElse Source.Trim.Length = 0 Then
                Return Source
            End If

            'convert from Base64 to binary
            Dim bytIn As Byte()
            Dim ms As MemoryStream
            Try
                bytIn = System.Convert.FromBase64String(Source)
                ms = New MemoryStream(bytIn)
            Catch ex As Exception
                bytIn = System.Convert.FromBase64String(Source.Replace(" ", "+"))
                ms = New MemoryStream(bytIn)
            End Try

            Dim bytKey() As Byte = GetLegalKey(Key)
            Dim bytTemp(bytIn.Length) As Byte

            'set the private key
            _CryptoService.Key = bytKey
            _CryptoService.IV = bytIV

            'create a Decryptor from the Provider Service instance
            Dim encrypto As ICryptoTransform = _CryptoService.CreateDecryptor()

            'create Crypto Stream that transforms a stream using the decryption
            Dim cs As CryptoStream = New CryptoStream(ms, encrypto, CryptoStreamMode.Read)
            Dim output As String = ""
            Try
                'read out the result from the Crypto Stream
                Dim sr As StreamReader
                If Encoding.EncodingName = System.Text.Encoding.ASCII.EncodingName Then
                    sr = New StreamReader(cs, System.Text.ASCIIEncoding.GetEncoding(System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ANSICodePage))
                ElseIf Encoding.EncodingName = System.Text.Encoding.Unicode.EncodingName Then
                    sr = New StreamReader(cs, System.Text.UnicodeEncoding.GetEncoding(System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ANSICodePage))
                Else
                    sr = New StreamReader(cs, System.Text.ASCIIEncoding.GetEncoding(System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ANSICodePage))
                End If
                output = sr.ReadToEnd
                sr.Close()
                ms.Close()
                cs.Close()
            Catch ex As Exception
                bytIn = System.Convert.FromBase64String(Source.Replace(" ", "+"))
                ms = New MemoryStream(bytIn)
                bytKey = GetLegalKey(Key)

                'set the private key
                _CryptoService.Key = bytKey
                _CryptoService.IV = bytIV
                encrypto = _CryptoService.CreateDecryptor()

                Try
                    'create Crypto Stream that transforms a stream using the decryption
                    cs = New CryptoStream(ms, encrypto, CryptoStreamMode.Read)
                    Dim sr As StreamReader
                    If Encoding.EncodingName = System.Text.Encoding.ASCII.EncodingName Then
                        sr = New StreamReader(cs, System.Text.ASCIIEncoding.GetEncoding(System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ANSICodePage))
                    ElseIf Encoding.EncodingName = System.Text.Encoding.Unicode.EncodingName Then
                        sr = New StreamReader(cs, System.Text.UnicodeEncoding.GetEncoding(System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ANSICodePage))
                    Else
                        sr = New StreamReader(cs, System.Text.ASCIIEncoding.GetEncoding(System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ANSICodePage))
                    End If
                    output = sr.ReadToEnd
                    sr.Close()
                    ms.Close()
                    cs.Close()
                Catch
                End Try

            End Try
            If Encoded Then
                output = System.Web.HttpUtility.UrlDecode(output)
            End If
            Return output
        End Function

        ' The URLEncryptionKey is specified in the web.config.  The rightmost six characters of the current
        ' Session Id are concatenated with the URLEncryptionKey to provide added protection.  You can change
        ' this to anything you like by changing this function for the application.
        ' This function is private and not overridable because each page cannot have its own key - it must
        ' be common across the entire application.
        Private Function GetCryptoKey() As String
            Return Left(System.Web.HttpContext.Current.Session.SessionID, 6) & BaseClasses.Configuration.ApplicationSettings.Current.URLEncryptionKey & Right(System.Web.HttpContext.Current.Session.SessionID, 6)
        End Function

        Private Function GetCryptoKeyWithoutSessionVariable() As String
            Return Left("ffx4ypamvvcs4knwbxxehl45", 6) & BaseClasses.Configuration.ApplicationSettings.Current.URLEncryptionKey & Right("ffx4ypamvvcs4knwbxxehl45", 6)
        End Function


    End Class

End Namespace