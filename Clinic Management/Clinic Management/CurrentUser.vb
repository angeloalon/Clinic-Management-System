Public Class CurrentUser

    Public Shared Property UserId As Integer = 0
    Public Shared Property FullName As String = ""
    Public Shared Property Email As String = ""
    Public Shared Property Role As String = ""
    Public Shared Property Clinic As String = "UCC Health Clinic"
    Public Shared Property IsAuthenticated As Boolean = False

    ''' <summary>
    ''' Stores user session details upon successful authentication.
    ''' </summary>
    Public Shared Sub SignIn(name As String, emailAddress As String, userRole As String, Optional clinicName As String = "UCC Health Clinic")
        FullName = If(String.IsNullOrWhiteSpace(name), emailAddress, name)
        Email = emailAddress
        Role = userRole
        Clinic = If(String.IsNullOrWhiteSpace(clinicName), "UCC Health Clinic", clinicName)
        IsAuthenticated = True
    End Sub

    ''' <summary>
    ''' Clears the active session upon logout.
    ''' </summary>
    Public Shared Sub SignOut()
        UserId = 0
        FullName = ""
        Email = ""
        Role = ""
        Clinic = ""
        IsAuthenticated = False
    End Sub

    ''' <summary>
    ''' Returns formatted role text for UI display.
    ''' </summary>
    Public Shared ReadOnly Property RoleDisplay As String
        Get
            Select Case Role
                Case "Administrator", "Admin"
                    Return "Administrator"
                Case "Doctor"
                    Return "Doctor"
                Case "Receptionist"
                    Return "Receptionist"
                Case Else
                    Return Role
            End Select
        End Get
    End Property

End Class
