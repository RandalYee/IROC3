Imports IROC2.Data

Namespace IROC2.UI


    Public Class SignInConstants
        Public Const UserName As String = "SIS_UserName"
        Public Const Password As String = "SIS_Password"
        Public Const OriginalUserName As String = "SIS_OriginalUserName"
        Public Const OriginalPassword As String = "SIS_OriginalPassword"
        Public Const OriginalRememberUser As String = "SIS_OriginalRememberUser"
        Public Const OriginalRememberPassword As String = "SIS_OriginalRememberPassword"
        Public Const IsUNToRemember As String = "SIS_IsUNToRemember"
        Public Const IsPassToRemember As String = "SIS_IsPassToRemember"
        Public Const IsCancelled As String = "SIS_IsCancelled"
        Public Const IsAutoLogin As String = "SIS_IsAutoLogin"
        Public Const LoginPassword As String = "SIS_LoginPassword"
    End Class
    Public Class SignInState
        Private Session As System.Web.SessionState.HttpSessionState
        Public Property UserName() As String
            Get
                Dim s As String = CType(Me.Session.Item(SignInConstants.UserName), String)
                If (s Is Nothing) Then
                    Return ""
                End If
                Return s
            End Get
            Set(ByVal value As String)
                Me.Session.Item(SignInConstants.UserName) = value
            End Set
        End Property
        Public Property Password() As String
            Get
                Dim CheckCrypto As Crypto = New Crypto(Crypto.Providers.DES)
                Dim key As String = BaseClasses.Configuration.ApplicationSettings.Current.CookieEncryptionKey
                Dim s As String = CType(Me.Session.Item(SignInConstants.Password), String)
                If (s Is Nothing OrElse s.Trim = "") Then
                    Return ""
                End If
                Return CheckCrypto.Decrypt(s, key, System.Text.Encoding.Unicode, False)
            End Get
            Set(ByVal value As String)
                Dim CheckCrypto As Crypto = New Crypto(Crypto.Providers.DES)
                Dim key As String = BaseClasses.Configuration.ApplicationSettings.Current.CookieEncryptionKey
                Me.Session.Item(SignInConstants.Password) = CheckCrypto.Encrypt(value, key, System.Text.Encoding.Unicode, False)
            End Set
        End Property
        Public Property LoginPassword() As String
            Get
                Dim CheckCrypto As Crypto = New Crypto(Crypto.Providers.DES)
                Dim key As String = BaseClasses.Configuration.ApplicationSettings.Current.CookieEncryptionKey
                Dim s As String = CType(Me.Session.Item(SignInConstants.LoginPassword), String)
                If (s Is Nothing OrElse s.Trim = "") Then
                    Return ""
                End If
                Return CheckCrypto.Decrypt(s, key, System.Text.Encoding.Unicode, False)
            End Get
            Set(ByVal value As String)
                Dim CheckCrypto As Crypto = New Crypto(Crypto.Providers.DES)
                Dim key As String = BaseClasses.Configuration.ApplicationSettings.Current.CookieEncryptionKey
                Me.Session.Item(SignInConstants.LoginPassword) = CheckCrypto.Encrypt(value, key, System.Text.Encoding.Unicode, False)
            End Set
        End Property
        Public Property OriginalUserName() As String
            Get
                Dim s As String = CType(Me.Session.Item(SignInConstants.OriginalUserName), String)
                If (s Is Nothing) Then
                    Return ""
                End If
                Return s
            End Get
            Set(ByVal value As String)
                Me.Session.Item(SignInConstants.OriginalUserName) = value
            End Set
        End Property
        Public Property OriginalPassword() As String
            Get
                Dim s As String = CType(Me.Session.Item(SignInConstants.OriginalPassword), String)
                If (s Is Nothing) Then
                    Return ""
                End If
                Return s
            End Get
            Set(ByVal value As String)
                Me.Session.Item(SignInConstants.OriginalPassword) = value
            End Set
        End Property
        Public Property OriginalRememberUser() As String
            Get
                Dim s As String = CType(Me.Session.Item(SignInConstants.OriginalRememberUser), String)
                If (s Is Nothing) Then
                    Return ""
                End If
                Return s
            End Get
            Set(ByVal value As String)
                Me.Session.Item(SignInConstants.OriginalRememberUser) = value
            End Set
        End Property
        Public Property OriginalRememberPassword() As String
            Get
                Dim s As String = CType(Me.Session.Item(SignInConstants.OriginalRememberPassword), String)
                If (s Is Nothing) Then
                    Return ""
                End If
                Return s
            End Get
            Set(ByVal value As String)
                Me.Session.Item(SignInConstants.OriginalRememberPassword) = value
            End Set
        End Property
        Public Property IsUNToRemember() As Boolean
            Get
                Dim s As String = CType(Me.Session.Item(SignInConstants.IsUNToRemember), String)
                If (s Is Nothing) Then
                    Return False
                End If
                Return Boolean.Parse(s)
            End Get
            Set(ByVal value As Boolean)
                Me.Session.Item(SignInConstants.IsUNToRemember) = value.ToString
            End Set
        End Property
        Public Property IsPassToRemember() As Boolean
            Get
                Dim s As String = CType(Me.Session.Item(SignInConstants.IsPassToRemember), String)
                If (s Is Nothing) Then
                    Return False
                End If
                Return Boolean.Parse(s)
            End Get
            Set(ByVal value As Boolean)
                Me.Session.Item(SignInConstants.IsPassToRemember) = value.ToString
            End Set
        End Property
        Public Property IsCancelled() As Boolean
            Get
                Dim s As String = CType(Me.Session.Item(SignInConstants.IsCancelled), String)
                If (s Is Nothing) Then
                    Return False
                End If
                Return Boolean.Parse(s)
            End Get
            Set(ByVal value As Boolean)
                Me.Session.Item(SignInConstants.IsCancelled) = value.ToString
            End Set
        End Property
        Public Property IsAutoLogin() As Boolean
            Get
                Dim s As String = CType(Me.Session.Item(SignInConstants.IsAutoLogin), String)
                If (s Is Nothing) Then
                    Return True
                End If
                Return Boolean.Parse(s)
            End Get
            Set(ByVal value As Boolean)
                Me.Session.Item(SignInConstants.IsAutoLogin) = value.ToString
            End Set
        End Property
        Public Sub New()
            Me.Session = HttpContext.Current.Session
        End Sub
    End Class
End Namespace
