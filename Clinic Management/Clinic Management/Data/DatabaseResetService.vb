Imports System.IO
Imports Microsoft.Data.Sqlite

Public Class ResetReport
    Public Property DatabasePath As String = ""
    Public Property BackupPath As String = ""
    Public Property Timestamp As DateTime = DateTime.Now
    Public Property AdminAccountPreserved As Boolean = False
    Public Property AdminId As Long = 0
    Public Property AdminEmail As String = ""
    Public Property AdminName As String = ""
    Public Property AdminRole As String = ""
    Public Property InitialRowCounts As New Dictionary(Of String, Long)(StringComparer.OrdinalIgnoreCase)
    Public Property ClearedRowCounts As New Dictionary(Of String, Long)(StringComparer.OrdinalIgnoreCase)
    Public Property PreservedTables As New List(Of String)()
    Public Property ClearedTables As New List(Of String)()
    Public Property IntegrityCheck As String = ""
    Public Property ForeignKeyCheckPassed As Boolean = False
End Class

Public Class AdminAccountSnapshot
    Public Property Id As Long
    Public Property Email As String
    Public Property Name As String
    Public Property Role As String
    Public Property Status As String
    Public Property PasswordHash As String
    Public Property PasswordSalt As String
    Public Property Clinic As String
    Public Property InviteCode As String
    Public Property FailedAttempts As Integer
    Public Property LockedUntil As String
    Public Property LastActive As String
    Public Property IsArchived As Integer
    Public Property ArchivedAt As String
    Public Property CreatedAt As String
End Class

Public Class DatabaseResetService

    Public Shared Function CreateBackup(targetDbPath As String, ByRef backupPath As String, ByRef errorMessage As String) As Boolean
        Try
            If Not File.Exists(targetDbPath) Then
                errorMessage = $"Target database file does not exist: {targetDbPath}"
                Return False
            End If

            Dim dir = Path.GetDirectoryName(targetDbPath)
            Dim backupFileName = $"clinic_backup_{DateTime.Now:yyyyMMdd_HHmmss}.db"
            backupPath = Path.Combine(dir, backupFileName)

            ' Ensure all SQLite connection pools are flushed before copying
            SqliteConnection.ClearAllPools()

            File.Copy(targetDbPath, backupPath, overwrite:=True)

            ' Verify backup
            Dim fiOrig As New FileInfo(targetDbPath)
            Dim fiBackup As New FileInfo(backupPath)

            If Not fiBackup.Exists OrElse fiBackup.Length = 0 Then
                errorMessage = "Backup verification failed: created backup file is missing or 0 bytes."
                Return False
            End If

            If fiOrig.Length <> fiBackup.Length Then
                errorMessage = $"Backup verification failed: size mismatch (Original: {fiOrig.Length} bytes, Backup: {fiBackup.Length} bytes)."
                Return False
            End If

            Return True
        Catch ex As Exception
            errorMessage = $"Exception during database backup: {ex.Message}"
            Return False
        End Try
    End Function

    Public Shared Function ExecuteReset(ByRef report As ResetReport, ByRef errorMessage As String) As Boolean
        report = New ResetReport()
        Dim targetDb = ClinicFilePath.GetDatabasePath()
        report.DatabasePath = targetDb

        ' 1. Create verified backup
        Dim backupFile As String = ""
        If Not CreateBackup(targetDb, backupFile, errorMessage) Then
            Return False
        End If
        report.BackupPath = backupFile

        Try
            SqliteConnection.ClearAllPools()

            Using conn = DatabaseService.CreateOpenConnection()
                ' Ensure tables exist
                DatabaseInitializer.Initialize()

                ' 2. Inspect Administrator Account
                Dim adminSnapshot As AdminAccountSnapshot = Nothing
                Using cmdAdmin = conn.CreateCommand()
                    cmdAdmin.CommandText = "
                        SELECT id, email, name, role, status, password_hash, password_salt, clinic,
                               invite_code, failed_attempts, locked_until, last_active, is_archived,
                               archived_at, created_at
                        FROM staff_accounts
                        WHERE role = 'Administrator';
                    "
                    Using r = cmdAdmin.ExecuteReader()
                        Dim adminCount As Integer = 0
                        While r.Read()
                            adminCount += 1
                            adminSnapshot = New AdminAccountSnapshot With {
                                .Id = r.GetInt64(0),
                                .Email = r.GetString(1),
                                .Name = r.GetString(2),
                                .Role = r.GetString(3),
                                .Status = r.GetString(4),
                                .PasswordHash = If(r.IsDBNull(5), "", r.GetString(5)),
                                .PasswordSalt = If(r.IsDBNull(6), "", r.GetString(6)),
                                .Clinic = If(r.IsDBNull(7), "", r.GetString(7)),
                                .InviteCode = If(r.IsDBNull(8), "", r.GetString(8)),
                                .FailedAttempts = If(r.IsDBNull(9), 0, r.GetInt32(9)),
                                .LockedUntil = If(r.IsDBNull(10), "", r.GetString(10)),
                                .LastActive = If(r.IsDBNull(11), "", r.GetString(11)),
                                .IsArchived = If(r.IsDBNull(12), 0, r.GetInt32(12)),
                                .ArchivedAt = If(r.IsDBNull(13), "", r.GetString(13)),
                                .CreatedAt = If(r.IsDBNull(14), "", r.GetString(14))
                            }
                        End While

                        If adminCount = 0 Then
                            errorMessage = "CRITICAL: No Administrator account found in the database. Aborting reset to prevent system lockout."
                            Return False
                        ElseIf adminCount > 1 Then
                            errorMessage = $"CRITICAL: Multiple Administrator accounts found ({adminCount}). Aborting reset due to ambiguous administrator identity."
                            Return False
                        End If
                    End Using
                End Using

                report.AdminId = adminSnapshot.Id
                report.AdminEmail = adminSnapshot.Email
                report.AdminName = adminSnapshot.Name
                report.AdminRole = adminSnapshot.Role

                ' 3. Capture Pre-Reset Counts
                Dim allTables As New List(Of String)()
                Using cmdTables = conn.CreateCommand()
                    cmdTables.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name NOT LIKE 'sqlite_%' ORDER BY name;"
                    Using r = cmdTables.ExecuteReader()
                        While r.Read()
                            allTables.Add(r.GetString(0))
                        End While
                    End Using
                End Using

                For Each tbl In allTables
                    Using cmdCount = conn.CreateCommand()
                        cmdCount.CommandText = $"SELECT COUNT(*) FROM [{tbl}];"
                        report.InitialRowCounts(tbl) = Convert.ToInt64(cmdCount.ExecuteScalar())
                    End Using
                Next

                ' 4. Execute Deletion Inside Transaction
                Using tx = conn.BeginTransaction()
                    ' Ensure prescription_access_requests table exists
                    Using cmdCreateRx = conn.CreateCommand()
                        cmdCreateRx.Transaction = tx
                        cmdCreateRx.CommandText = "
                            CREATE TABLE IF NOT EXISTS prescription_access_requests (
                                id INTEGER PRIMARY KEY AUTOINCREMENT,
                                prescription_id INTEGER NOT NULL,
                                patient_id TEXT NOT NULL,
                                requested_by_user_id INTEGER NOT NULL DEFAULT 0,
                                doctor_id INTEGER NOT NULL DEFAULT 0,
                                reason TEXT NOT NULL,
                                status TEXT NOT NULL DEFAULT 'Pending' CHECK(status IN ('Pending', 'Approved', 'Denied', 'Expired', 'Revoked', 'Used')),
                                requested_at TEXT NOT NULL DEFAULT (datetime('now', 'localtime')),
                                decided_at TEXT NULL,
                                decision_note TEXT NULL,
                                access_type TEXT NULL DEFAULT 'time_limited',
                                expires_at TEXT NULL,
                                revoked_at TEXT NULL,
                                allow_print INTEGER NOT NULL DEFAULT 0
                            );
                        "
                        cmdCreateRx.ExecuteNonQuery()
                    End Using

                    ' Delete dependent records in child-to-parent order
                    Dim deleteCommands As String() = {
                        "DELETE FROM lab_requests;",
                        "DELETE FROM prescriptions;",
                        "DELETE FROM prescription_access_requests;",
                        "DELETE FROM consultation_access_requests;",
                        "DELETE FROM consultations;",
                        "DELETE FROM appointments;",
                        "DELETE FROM doctor_availability;",
                        "DELETE FROM schedule_slots;",
                        "DELETE FROM patients;",
                        "DELETE FROM audit_logs;",
                        "DELETE FROM clinic_settings;",
                        "DELETE FROM psgc_geographic;"
                    }

                    For Each dSql In deleteCommands
                        Using dCmd = conn.CreateCommand()
                            dCmd.Transaction = tx
                            dCmd.CommandText = dSql
                            dCmd.ExecuteNonQuery()
                        End Using
                    Next

                    ' Delete all non-Administrator staff accounts, preserving Administrator account untouched
                    Using cmdDelStaff = conn.CreateCommand()
                        cmdDelStaff.Transaction = tx
                        cmdDelStaff.CommandText = "
                            DELETE FROM staff_accounts
                            WHERE role <> 'Administrator'
                              AND LOWER(email) <> LOWER(@adminEmail)
                              AND id <> @adminId;
                        "
                        cmdDelStaff.Parameters.AddWithValue("@adminEmail", adminSnapshot.Email)
                        cmdDelStaff.Parameters.AddWithValue("@adminId", adminSnapshot.Id)
                        cmdDelStaff.ExecuteNonQuery()
                    End Using

                    tx.Commit()
                End Using

                ' 5. Verify Post-Reset State & Administrator Invariance
                Using cmdVerifyAdmin = conn.CreateCommand()
                    cmdVerifyAdmin.CommandText = "
                        SELECT id, email, name, role, status, password_hash, password_salt, clinic,
                               invite_code, failed_attempts, locked_until, last_active, is_archived,
                               archived_at, created_at
                        FROM staff_accounts;
                    "
                    Using r = cmdVerifyAdmin.ExecuteReader()
                        Dim postCount As Integer = 0
                        While r.Read()
                            postCount += 1
                            Dim postAdmin = New AdminAccountSnapshot With {
                                .Id = r.GetInt64(0),
                                .Email = r.GetString(1),
                                .Name = r.GetString(2),
                                .Role = r.GetString(3),
                                .Status = r.GetString(4),
                                .PasswordHash = If(r.IsDBNull(5), "", r.GetString(5)),
                                .PasswordSalt = If(r.IsDBNull(6), "", r.GetString(6)),
                                .Clinic = If(r.IsDBNull(7), "", r.GetString(7)),
                                .InviteCode = If(r.IsDBNull(8), "", r.GetString(8)),
                                .FailedAttempts = If(r.IsDBNull(9), 0, r.GetInt32(9)),
                                .LockedUntil = If(r.IsDBNull(10), "", r.GetString(10)),
                                .LastActive = If(r.IsDBNull(11), "", r.GetString(11)),
                                .IsArchived = If(r.IsDBNull(12), 0, r.GetInt32(12)),
                                .ArchivedAt = If(r.IsDBNull(13), "", r.GetString(13)),
                                .CreatedAt = If(r.IsDBNull(14), "", r.GetString(14))
                            }

                            If postAdmin.Id <> adminSnapshot.Id OrElse
                               Not postAdmin.Email.Equals(adminSnapshot.Email, StringComparison.OrdinalIgnoreCase) OrElse
                               postAdmin.Name <> adminSnapshot.Name OrElse
                               postAdmin.Role <> adminSnapshot.Role OrElse
                               postAdmin.PasswordHash <> adminSnapshot.PasswordHash OrElse
                               postAdmin.PasswordSalt <> adminSnapshot.PasswordSalt OrElse
                               postAdmin.Status <> adminSnapshot.Status OrElse
                               postAdmin.InviteCode <> adminSnapshot.InviteCode OrElse
                               postAdmin.FailedAttempts <> adminSnapshot.FailedAttempts OrElse
                               postAdmin.LockedUntil <> adminSnapshot.LockedUntil OrElse
                               postAdmin.IsArchived <> adminSnapshot.IsArchived Then

                                errorMessage = "CRITICAL INTEGRITY FAILURE: Administrator account fields were altered during reset!"
                                Return False
                            End If
                        End While

                        If postCount <> 1 Then
                            errorMessage = $"CRITICAL: staff_accounts table contains {postCount} accounts after reset (expected exactly 1 Administrator)."
                            Return False
                        End If
                    End Using
                End Using

                report.AdminAccountPreserved = True

                ' Verify cleared tables
                allTables.Clear()
                Using cmdTables = conn.CreateCommand()
                    cmdTables.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name NOT LIKE 'sqlite_%' ORDER BY name;"
                    Using r = cmdTables.ExecuteReader()
                        While r.Read()
                            allTables.Add(r.GetString(0))
                        End While
                    End Using
                End Using

                For Each tbl In allTables
                    Using cmdCount = conn.CreateCommand()
                        cmdCount.CommandText = $"SELECT COUNT(*) FROM [{tbl}];"
                        Dim c = Convert.ToInt64(cmdCount.ExecuteScalar())
                        report.ClearedRowCounts(tbl) = c
                        If tbl.Equals("staff_accounts", StringComparison.OrdinalIgnoreCase) Then
                            report.PreservedTables.Add(tbl)
                        ElseIf c = 0 Then
                            report.ClearedTables.Add(tbl)
                        Else
                            errorMessage = $"Table [{tbl}] still contains {c} rows after reset operation."
                            Return False
                        End If
                    End Using
                Next

                ' Check foreign keys
                Using cmdFk = conn.CreateCommand()
                    cmdFk.CommandText = "PRAGMA foreign_key_check;"
                    Dim fkIssues As New List(Of String)()
                    Using r = cmdFk.ExecuteReader()
                        While r.Read()
                            fkIssues.Add($"Table {r(0)}, Row {r(1)}, Target {r(2)}, FK {r(3)}")
                        End While
                    End Using
                    If fkIssues.Count > 0 Then
                        errorMessage = $"Foreign key check failed with violations: {String.Join("; ", fkIssues)}"
                        Return False
                    End If
                    report.ForeignKeyCheckPassed = True
                End Using

                ' Check integrity
                Using cmdIntegrity = conn.CreateCommand()
                    cmdIntegrity.CommandText = "PRAGMA integrity_check;"
                    Dim result = Convert.ToString(cmdIntegrity.ExecuteScalar())
                    report.IntegrityCheck = result
                    If Not String.Equals(result, "ok", StringComparison.OrdinalIgnoreCase) Then
                        errorMessage = $"Integrity check failed: {result}"
                        Return False
                    End If
                End Using

                ' Reclaim space
                Using cmdVacuum = conn.CreateCommand()
                    cmdVacuum.CommandText = "VACUUM;"
                    cmdVacuum.ExecuteNonQuery()
                End Using
            End Using

            ' If a secondary database file exists in output directory or project root, sync it
            SyncSecondaryDatabaseCopies(targetDb)

            ' Refresh static cached facade stores
            ClinicData.NotifyDataChanged()

            Return True
        Catch ex As Exception
            errorMessage = $"Exception during database reset execution: {ex.Message}"
            Return False
        End Try
    End Function

    Private Shared Sub SyncSecondaryDatabaseCopies(activePath As String)
        Try
            Dim baseDir = AppDomain.CurrentDomain.BaseDirectory
            Dim candidates = {
                Path.Combine(baseDir, "Data", "clinic.db"),
                Path.Combine(baseDir, "clinic.db")
            }

            SqliteConnection.ClearAllPools()

            For Each cand In candidates
                If File.Exists(cand) AndAlso Not cand.Equals(activePath, StringComparison.OrdinalIgnoreCase) Then
                    File.Copy(activePath, cand, overwrite:=True)
                End If
            Next
        Catch
            ' Best-effort sync
        End Try
    End Sub

End Class
