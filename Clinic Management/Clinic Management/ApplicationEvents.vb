Imports System.IO
Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.

    ' **NEW** ApplyApplicationDefaults: Raised when the application queries default values to be set for the application.

    ' Example:
    ' Private Sub MyApplication_ApplyApplicationDefaults(sender As Object, e As ApplyApplicationDefaultsEventArgs) Handles Me.ApplyApplicationDefaults
    '
    '   ' Setting the application-wide default Font:
    '   e.Font = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular)
    '
    '   ' Setting the HighDpiMode for the Application:
    '   e.HighDpiMode = HighDpiMode.PerMonitorV2
    '
    '   ' If a splash dialog is used, this sets the minimum display time:
    '   e.MinimumSplashScreenDisplayTime = 4000
    ' End Sub

    Partial Friend Class MyApplication

        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            DatabaseInitializer.Initialize()

            If e.CommandLine.Contains("--reset-db") Then
                Dim report As ResetReport = Nothing
                Dim errMsg As String = ""
                Dim success = DatabaseResetService.ExecuteReset(report, errMsg)

                Dim sb As New System.Text.StringBuilder()
                sb.AppendLine("=== APPLICATION DATA RESET RESULT ===")
                sb.AppendLine($"Success: {success}")
                If Not success Then
                    sb.AppendLine($"Error: {errMsg}")
                Else
                    sb.AppendLine($"Database: {report.DatabasePath}")
                    sb.AppendLine($"Backup File: {report.BackupPath}")
                    sb.AppendLine($"Admin Account Preserved: {report.AdminAccountPreserved}")
                    sb.AppendLine($"Admin ID: {report.AdminId}")
                    sb.AppendLine($"Admin Email: {report.AdminEmail}")
                    sb.AppendLine($"Admin Name: {report.AdminName}")
                    sb.AppendLine($"Admin Role: {report.AdminRole}")
                    sb.AppendLine($"Integrity Check: {report.IntegrityCheck}")
                    sb.AppendLine($"FK Check Passed: {report.ForeignKeyCheckPassed}")
                    sb.AppendLine("--- Pre-Reset Table Counts ---")
                    For Each kvp In report.InitialRowCounts
                        sb.AppendLine($"  {kvp.Key}: {kvp.Value} rows")
                    Next
                    sb.AppendLine("--- Post-Reset Table Counts ---")
                    For Each kvp In report.ClearedRowCounts
                        sb.AppendLine($"  {kvp.Key}: {kvp.Value} rows")
                    Next
                End If

                Dim outPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db_reset_result.txt")
                File.WriteAllText(outPath, sb.ToString())
                Console.WriteLine(sb.ToString())
                e.Cancel = True
                Return
            End If

            If e.CommandLine.Contains("--dump-db") Then
                Dim sb As New System.Text.StringBuilder()
                Using conn = DatabaseService.CreateOpenConnection()
                    sb.AppendLine("=== DATABASE PATH ===")
                    sb.AppendLine(ClinicFilePath.GetDatabasePath())
                    sb.AppendLine("=== TABLES & ROW COUNTS ===")
                    Dim tables As New List(Of String)()
                    Using cmd = conn.CreateCommand()
                        cmd.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name NOT LIKE 'sqlite_%' ORDER BY name;"
                        Using r = cmd.ExecuteReader()
                            While r.Read()
                                tables.Add(r.GetString(0))
                            End While
                        End Using
                    End Using
                    For Each tbl In tables
                        Using cmdCount = conn.CreateCommand()
                            cmdCount.CommandText = $"SELECT COUNT(*) FROM [{tbl}];"
                            Dim c = Convert.ToInt64(cmdCount.ExecuteScalar())
                            sb.AppendLine($"{tbl}: {c} rows")
                        End Using
                    Next
                    sb.AppendLine("=== STAFF ACCOUNTS ===")
                    Using cmdStaff = conn.CreateCommand()
                        cmdStaff.CommandText = "SELECT id, email, name, role, status, invite_code, failed_attempts, locked_until, last_active, is_archived, archived_at, created_at, length(password_hash), length(password_salt) FROM staff_accounts;"
                        Using r = cmdStaff.ExecuteReader()
                            While r.Read()
                                sb.AppendLine($"ID={r(0)} | Email={r(1)} | Name={r(2)} | Role={r(3)} | Status={r(4)} | Code={r(5)} | Failed={r(6)} | Locked={r(7)} | LastActive={r(8)} | Archived={r(9)} | HashLen={r(12)} | SaltLen={r(13)}")
                            End While
                        End Using
                    End Using
                End Using
                Dim outPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db_dump_result.txt")
                File.WriteAllText(outPath, sb.ToString())
                Console.WriteLine(sb.ToString())
                e.Cancel = True
            End If
        End Sub

    End Class
End Namespace
