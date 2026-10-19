Imports Microsoft.Data.Sqlite

Public Class SqliteStaffRepository

    Public Shared Function GetAll() As List(Of StaffAccount)
        DatabaseInitializer.Initialize()
        Dim list As New List(Of StaffAccount)()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    SELECT name, email, role, status, last_active, clinic, invite_code, is_archived, archived_at
                    FROM staff_accounts
                    WHERE COALESCE(is_archived, 0) = 0
                    ORDER BY id ASC;
                "
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        list.Add(New StaffAccount With {
                            .Name = reader.GetString(0),
                            .Email = reader.GetString(1),
                            .Role = reader.GetString(2),
                            .Status = reader.GetString(3),
                            .LastActive = If(reader.IsDBNull(4), "—", reader.GetString(4)),
                            .Clinic = If(reader.IsDBNull(5), "UCC Health Clinic", reader.GetString(5)),
                            .InviteCode = If(reader.IsDBNull(6), "", reader.GetString(6)),
                            .IsArchived = If(reader.IsDBNull(7), False, reader.GetInt32(7) <> 0),
                            .ArchivedAt = If(reader.IsDBNull(8), "", reader.GetString(8))
                        })
                    End While
                End Using
            End Using
        End Using

        Return list
    End Function

    ''' <summary>
    ''' Retrieves all archived/deleted staff accounts.
    ''' </summary>
    Public Shared Function GetArchivedAccounts() As List(Of StaffAccount)
        DatabaseInitializer.Initialize()
        Dim list As New List(Of StaffAccount)()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    SELECT name, email, role, status, last_active, clinic, invite_code, is_archived, archived_at
                    FROM staff_accounts
                    WHERE COALESCE(is_archived, 0) = 1
                    ORDER BY COALESCE(archived_at, '') DESC, name ASC;
                "
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        list.Add(New StaffAccount With {
                            .Name = reader.GetString(0),
                            .Email = reader.GetString(1),
                            .Role = reader.GetString(2),
                            .Status = reader.GetString(3),
                            .LastActive = If(reader.IsDBNull(4), "—", reader.GetString(4)),
                            .Clinic = If(reader.IsDBNull(5), "UCC Health Clinic", reader.GetString(5)),
                            .InviteCode = If(reader.IsDBNull(6), "", reader.GetString(6)),
                            .IsArchived = If(reader.IsDBNull(7), False, reader.GetInt32(7) <> 0),
                            .ArchivedAt = If(reader.IsDBNull(8), "", reader.GetString(8))
                        })
                    End While
                End Using
            End Using
        End Using

        Return list
    End Function

    ''' <summary>
    ''' Returns the count of currently archived accounts.
    ''' </summary>
    Public Shared Function GetArchivedCount() As Integer
        DatabaseInitializer.Initialize()
        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "SELECT COUNT(*) FROM staff_accounts WHERE COALESCE(is_archived, 0) = 1;"
                Dim res = cmd.ExecuteScalar()
                If res IsNot Nothing AndAlso Not DBNull.Value.Equals(res) Then
                    Return Convert.ToInt32(res)
                End If
            End Using
        End Using
        Return 0
    End Function

    ''' <summary>
    ''' Moves an active account to the archive (soft delete).
    ''' </summary>
    Public Shared Sub ArchiveAccount(email As String)
        If String.IsNullOrWhiteSpace(email) Then Return
        DatabaseInitializer.Initialize()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    UPDATE staff_accounts
                    SET is_archived = 1,
                        archived_at = datetime('now', 'localtime')
                    WHERE email = @email COLLATE NOCASE;
                "
                cmd.Parameters.AddWithValue("@email", email.Trim())
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Brings back an archived account to active status.
    ''' </summary>
    Public Shared Sub RestoreAccount(email As String)
        If String.IsNullOrWhiteSpace(email) Then Return
        DatabaseInitializer.Initialize()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    UPDATE staff_accounts
                    SET is_archived = 0,
                        archived_at = NULL
                    WHERE email = @email COLLATE NOCASE;
                "
                cmd.Parameters.AddWithValue("@email", email.Trim())
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Retrieves all registered doctor accounts who are not suspended or archived.
    ''' </summary>
    Public Shared Function GetDoctorAccounts() As List(Of StaffAccount)
        DatabaseInitializer.Initialize()
        Dim list As New List(Of StaffAccount)()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    SELECT name, email, role, status, last_active, clinic, invite_code
                    FROM staff_accounts
                    WHERE role = 'Doctor' AND status <> 'Suspended' AND COALESCE(is_archived, 0) = 0
                    ORDER BY id ASC;
                "
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        list.Add(New StaffAccount With {
                            .Name = reader.GetString(0),
                            .Email = reader.GetString(1),
                            .Role = reader.GetString(2),
                            .Status = reader.GetString(3),
                            .LastActive = If(reader.IsDBNull(4), "—", reader.GetString(4)),
                            .Clinic = If(reader.IsDBNull(5), "UCC Health Clinic", reader.GetString(5)),
                            .InviteCode = If(reader.IsDBNull(6), "", reader.GetString(6))
                        })
                    End While
                End Using
            End Using
        End Using

        Return list
    End Function

    Public Shared Function FindByEmail(email As String) As StaffAccount
        If String.IsNullOrWhiteSpace(email) Then Return Nothing
        DatabaseInitializer.Initialize()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    SELECT name, email, role, status, last_active, clinic, invite_code, is_archived, archived_at
                    FROM staff_accounts
                    WHERE email = @email COLLATE NOCASE
                    LIMIT 1;
                "
                cmd.Parameters.AddWithValue("@email", email.Trim())
                Using reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Return New StaffAccount With {
                            .Name = reader.GetString(0),
                            .Email = reader.GetString(1),
                            .Role = reader.GetString(2),
                            .Status = reader.GetString(3),
                            .LastActive = If(reader.IsDBNull(4), "—", reader.GetString(4)),
                            .Clinic = If(reader.IsDBNull(5), "UCC Health Clinic", reader.GetString(5)),
                            .InviteCode = If(reader.IsDBNull(6), "", reader.GetString(6)),
                            .IsArchived = If(reader.IsDBNull(7), False, reader.GetInt32(7) <> 0),
                            .ArchivedAt = If(reader.IsDBNull(8), "", reader.GetString(8))
                        }
                    End If
                End Using
            End Using
        End Using

        Return Nothing
    End Function

    Public Shared Sub AddAccount(name As String, email As String, role As String, status As String,
                                 Optional clinic As String = "UCC Health Clinic",
                                 Optional inviteCode As String = "",
                                 Optional initialPassword As String = "password123")
        DatabaseInitializer.Initialize()
        Dim salt = SecurityHelper.GenerateSalt()
        Dim hash = SecurityHelper.HashPassword(If(String.IsNullOrEmpty(initialPassword), "password123", initialPassword), salt)

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    INSERT INTO staff_accounts (name, email, role, status, clinic, invite_code, password_hash, password_salt, last_active)
                    VALUES (@name, @email, @role, @status, @clinic, @inviteCode, @hash, @salt, 'Just now');
                "
                DatabaseService.AddParam(cmd, "@name", If(name, ""))
                DatabaseService.AddParam(cmd, "@email", If(email, ""))
                DatabaseService.AddParam(cmd, "@role", If(role, ""))
                DatabaseService.AddParam(cmd, "@status", If(status, "Active"))
                DatabaseService.AddParam(cmd, "@clinic", If(clinic, "UCC Health Clinic"))
                DatabaseService.AddParam(cmd, "@inviteCode", If(inviteCode, ""))
                DatabaseService.AddParam(cmd, "@hash", hash)
                DatabaseService.AddParam(cmd, "@salt", salt)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Shared Sub UpdateAccount(email As String, role As String, status As String, clinic As String)
        If String.IsNullOrWhiteSpace(email) Then Return
        DatabaseInitializer.Initialize()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    UPDATE staff_accounts
                    SET role = @role,
                        status = @status,
                        clinic = @clinic
                    WHERE email = @email COLLATE NOCASE;
                "
                DatabaseService.AddParam(cmd, "@role", If(role, ""))
                DatabaseService.AddParam(cmd, "@status", If(status, "Active"))
                DatabaseService.AddParam(cmd, "@clinic", If(clinic, "UCC Health Clinic"))
                DatabaseService.AddParam(cmd, "@email", email.Trim())
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Shared Function VerifyPassword(email As String, plainPassword As String) As Boolean
        If String.IsNullOrWhiteSpace(email) OrElse String.IsNullOrWhiteSpace(plainPassword) Then
            Return False
        End If
        DatabaseInitializer.Initialize()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    SELECT password_hash, password_salt
                    FROM staff_accounts
                    WHERE email = @email COLLATE NOCASE
                    LIMIT 1;
                "
                cmd.Parameters.AddWithValue("@email", email.Trim())
                Using reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        If reader.IsDBNull(0) OrElse reader.IsDBNull(1) Then
                            Return False
                        End If
                        Dim storedHash = reader.GetString(0)
                        Dim storedSalt = reader.GetString(1)
                        Return SecurityHelper.VerifyPassword(plainPassword, storedHash, storedSalt)
                    End If
                End Using
            End Using
        End Using

        Return False
    End Function

    Public Shared Sub SetPassword(email As String, newPassword As String)
        If String.IsNullOrWhiteSpace(email) OrElse String.IsNullOrWhiteSpace(newPassword) Then Return
        DatabaseInitializer.Initialize()

        Dim salt = SecurityHelper.GenerateSalt()
        Dim hash = SecurityHelper.HashPassword(newPassword, salt)

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    UPDATE staff_accounts
                    SET password_hash = @hash,
                        password_salt = @salt,
                        failed_attempts = 0,
                        locked_until = NULL,
                        status = 'Active'
                    WHERE email = @email COLLATE NOCASE;
                "
                cmd.Parameters.AddWithValue("@hash", hash)
                cmd.Parameters.AddWithValue("@salt", salt)
                cmd.Parameters.AddWithValue("@email", email.Trim())
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Shared Sub UpdateLastActive(email As String)
        If String.IsNullOrWhiteSpace(email) Then Return
        DatabaseInitializer.Initialize()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    UPDATE staff_accounts
                    SET last_active = 'Today, ' || strftime('%H:%M', 'now', 'localtime')
                    WHERE email = @email COLLATE NOCASE;
                "
                cmd.Parameters.AddWithValue("@email", email.Trim())
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Shared Function GetLockoutStatus(email As String) As (IsLocked As Boolean, LockedUntil As Nullable(Of DateTime), FailedAttempts As Integer)
        If String.IsNullOrWhiteSpace(email) Then Return (False, Nothing, 0)
        DatabaseInitializer.Initialize()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    SELECT failed_attempts, locked_until
                    FROM staff_accounts
                    WHERE email = @email COLLATE NOCASE
                    LIMIT 1;
                "
                cmd.Parameters.AddWithValue("@email", email.Trim())
                Using reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim failedAttempts = If(reader.IsDBNull(0), 0, reader.GetInt32(0))
                        Dim lockedUntil As Nullable(Of DateTime) = Nothing
                        If Not reader.IsDBNull(1) Then
                            Dim dt As DateTime
                            If DateTime.TryParse(reader.GetString(1), dt) Then
                                lockedUntil = dt
                            End If
                        End If

                        If lockedUntil.HasValue AndAlso DateTime.Now >= lockedUntil.Value Then
                            ' Lockout expired
                            ResetFailedAttempts(email)
                            Return (False, Nothing, 0)
                        End If

                        Return (lockedUntil.HasValue AndAlso DateTime.Now < lockedUntil.Value, lockedUntil, failedAttempts)
                    End If
                End Using
            End Using
        End Using

        Return (False, Nothing, 0)
    End Function

    Public Shared Function RecordFailedAttempt(email As String, maxAttempts As Integer) As (Locked As Boolean, Remaining As Integer, LockedUntil As Nullable(Of DateTime))
        If String.IsNullOrWhiteSpace(email) Then Return (False, maxAttempts, Nothing)
        DatabaseInitializer.Initialize()

        Using conn = DatabaseService.CreateOpenConnection()
            Dim currentAttempts As Integer = 0
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "SELECT failed_attempts FROM staff_accounts WHERE email = @email COLLATE NOCASE;"
                cmd.Parameters.AddWithValue("@email", email.Trim())
                Dim res = cmd.ExecuteScalar()
                If res IsNot Nothing AndAlso Not DBNull.Value.Equals(res) Then
                    currentAttempts = Convert.ToInt32(res)
                End If
            End Using

            currentAttempts += 1
            Dim lockedUntil As Nullable(Of DateTime) = Nothing
            Dim isLocked As Boolean = False

            If currentAttempts >= maxAttempts Then
                isLocked = True
                lockedUntil = DateTime.Now.AddMinutes(15)
            End If

            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    UPDATE staff_accounts
                    SET failed_attempts = @attempts,
                        locked_until = @locked
                    WHERE email = @email COLLATE NOCASE;
                "
                cmd.Parameters.AddWithValue("@attempts", currentAttempts)
                cmd.Parameters.AddWithValue("@locked", If(lockedUntil.HasValue, lockedUntil.Value.ToString("yyyy-MM-dd HH:mm:ss"), DBNull.Value))
                cmd.Parameters.AddWithValue("@email", email.Trim())
                cmd.ExecuteNonQuery()
            End Using

            Return (isLocked, Math.Max(0, maxAttempts - currentAttempts), lockedUntil)
        End Using
    End Function

    Public Shared Sub ResetFailedAttempts(email As String)
        If String.IsNullOrWhiteSpace(email) Then Return
        DatabaseInitializer.Initialize()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    UPDATE staff_accounts
                    SET failed_attempts = 0,
                        locked_until = NULL
                    WHERE email = @email COLLATE NOCASE;
                "
                cmd.Parameters.AddWithValue("@email", email.Trim())
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Class
