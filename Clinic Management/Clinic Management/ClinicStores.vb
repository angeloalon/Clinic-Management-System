Public Class AuditEntry
    Public Property Time As DateTime
    Public Property UserName As String
    Public Property Role As String
    Public Property Action As String
    Public Property Details As String
    Public Property Result As String
End Class

Public Class ClinicProfile
    Public Shared Property ClinicName As String
        Get
            Return SqliteClinicSettingsRepository.GetSettings().ClinicName
        End Get
        Set(value As String)
            Dim s = SqliteClinicSettingsRepository.GetSettings()
            SqliteClinicSettingsRepository.SaveSettings(value, s.ClinicType, s.Address, s.Contact, s.Email, s.ApptMinutes)
        End Set
    End Property

    Public Shared Property ClinicType As String
        Get
            Return SqliteClinicSettingsRepository.GetSettings().ClinicType
        End Get
        Set(value As String)
            Dim s = SqliteClinicSettingsRepository.GetSettings()
            SqliteClinicSettingsRepository.SaveSettings(s.ClinicName, value, s.Address, s.Contact, s.Email, s.ApptMinutes)
        End Set
    End Property

    Public Shared Property Address As String
        Get
            Return SqliteClinicSettingsRepository.GetSettings().Address
        End Get
        Set(value As String)
            Dim s = SqliteClinicSettingsRepository.GetSettings()
            SqliteClinicSettingsRepository.SaveSettings(s.ClinicName, s.ClinicType, value, s.Contact, s.Email, s.ApptMinutes)
        End Set
    End Property

    Public Shared Property Contact As String
        Get
            Return SqliteClinicSettingsRepository.GetSettings().Contact
        End Get
        Set(value As String)
            Dim s = SqliteClinicSettingsRepository.GetSettings()
            SqliteClinicSettingsRepository.SaveSettings(s.ClinicName, s.ClinicType, s.Address, value, s.Email, s.ApptMinutes)
        End Set
    End Property

    Public Shared Property Email As String
        Get
            Return SqliteClinicSettingsRepository.GetSettings().Email
        End Get
        Set(value As String)
            Dim s = SqliteClinicSettingsRepository.GetSettings()
            SqliteClinicSettingsRepository.SaveSettings(s.ClinicName, s.ClinicType, s.Address, s.Contact, value, s.ApptMinutes)
        End Set
    End Property

    Public Shared Property ApptMinutes As Integer
        Get
            Return SqliteClinicSettingsRepository.GetSettings().ApptMinutes
        End Get
        Set(value As Integer)
            Dim s = SqliteClinicSettingsRepository.GetSettings()
            SqliteClinicSettingsRepository.SaveSettings(s.ClinicName, s.ClinicType, s.Address, s.Contact, s.Email, value)
        End Set
    End Property
End Class

Public Class AuditStore
    Public Shared ReadOnly Property Entries As List(Of AuditEntry)
        Get
            Return SqliteAuditRepository.GetAll()
        End Get
    End Property

    ''' <summary>Call this from any screen to record an action to SQLite database.</summary>
    Public Shared Sub Log(user As String, role As String, action As String, details As String, result As String)
        SqliteAuditRepository.Log(user, role, action, details, result)
    End Sub
End Class

Public Class StaffAccount
    Public Property Name As String
    Public Property Email As String
    Public Property Role As String
    Public Property Status As String
    Public Property LastActive As String
    Public Property Clinic As String = "UCC Health Clinic"
    Public Property InviteCode As String = ""
    Public Property Password As String = ""
    Public Property IsArchived As Boolean = False
    Public Property ArchivedAt As String = ""
End Class

Public Class StaffStore
    Public Shared ReadOnly Property Accounts As List(Of StaffAccount)
        Get
            Return SqliteStaffRepository.GetAll()
        End Get
    End Property

    Public Shared ReadOnly Property ArchivedAccounts As List(Of StaffAccount)
        Get
            Return SqliteStaffRepository.GetArchivedAccounts()
        End Get
    End Property

    Public Shared ReadOnly Property ArchivedCount As Integer
        Get
            Return SqliteStaffRepository.GetArchivedCount()
        End Get
    End Property

    Public Shared ReadOnly Property Doctors As List(Of StaffAccount)
        Get
            Return SqliteStaffRepository.GetDoctorAccounts()
        End Get
    End Property

    Public Shared Function FindByEmail(email As String) As StaffAccount
        Return SqliteStaffRepository.FindByEmail(email)
    End Function

    Public Shared Sub AddAccount(name As String, email As String, role As String, status As String, Optional clinic As String = "UCC Health Clinic", Optional inviteCode As String = "")
        SqliteStaffRepository.AddAccount(name, email, role, status, clinic, inviteCode)
    End Sub

    Public Shared Sub ArchiveAccount(email As String)
        SqliteStaffRepository.ArchiveAccount(email)
    End Sub

    Public Shared Sub RestoreAccount(email As String)
        SqliteStaffRepository.RestoreAccount(email)
    End Sub
End Class