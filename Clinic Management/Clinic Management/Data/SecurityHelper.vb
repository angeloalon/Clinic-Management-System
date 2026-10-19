Imports System.Security.Cryptography

Public Class SecurityHelper

    Private Const SaltSize As Integer = 16
    Private Const HashSize As Integer = 32
    Private Const Iterations As Integer = 100000

    ''' <summary>
    ''' Generates a cryptographically strong random salt encoded as Base64.
    ''' </summary>
    Public Shared Function GenerateSalt() As String
        Dim saltBytes(SaltSize - 1) As Byte
        Using rng = RandomNumberGenerator.Create()
            rng.GetBytes(saltBytes)
        End Using
        Return Convert.ToBase64String(saltBytes)
    End Function

    ''' <summary>
    ''' Hashes a password using PBKDF2 (HMAC-SHA256) and a specified salt.
    ''' </summary>
    Public Shared Function HashPassword(password As String, saltBase64 As String) As String
        Dim saltBytes = Convert.FromBase64String(saltBase64)
        Using pbkdf2 As New Rfc2898DeriveBytes(password, saltBytes, Iterations, HashAlgorithmName.SHA256)
            Dim hashBytes = pbkdf2.GetBytes(HashSize)
            Return Convert.ToBase64String(hashBytes)
        End Using
    End Function

    ''' <summary>
    ''' Verifies a plaintext password against the stored PBKDF2 hash and salt using constant-time comparison.
    ''' </summary>
    Public Shared Function VerifyPassword(password As String, storedHashBase64 As String, storedSaltBase64 As String) As Boolean
        If String.IsNullOrEmpty(password) OrElse String.IsNullOrEmpty(storedHashBase64) OrElse String.IsNullOrEmpty(storedSaltBase64) Then
            Return False
        End If

        Try
            Dim computedHash = HashPassword(password, storedSaltBase64)
            Return CryptographicOperations.FixedTimeEquals(
                Convert.FromBase64String(computedHash),
                Convert.FromBase64String(storedHashBase64)
            )
        Catch
            Return False
        End Try
    End Function

End Class
