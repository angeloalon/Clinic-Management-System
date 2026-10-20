Imports System.IO
Imports System.Threading
Imports Microsoft.Data.Sqlite

''' <summary>
''' Bitmask flags for domain-specific sync changes.
''' Allows targeted refreshes so unchanged domains never reload.
''' </summary>
<Flags>
Public Enum SyncDomain
    None = 0
    Patients = 1
    Appointments = 2
    Consultations = 4
    Prescriptions = 8
    Schedules = 16
    Staff = 32
    Settings = 64
    Audit = 128
    All = 255
End Enum

''' <summary>
''' Centralized background synchronization service for UCC Health Clinic Management System.
''' Polls the shared SQLite database every 1.5 seconds (1500 ms).
''' Detects domain-level changes and triggers targeted UI refreshes across open screens
''' for Administrator, Doctor, and Receptionist roles while preserving filters and unsaved input.
''' </summary>
Public Class DataSyncService

    Public Const PollingIntervalMs As Integer = 1500

    ' Centralized timer instance - guarantees no duplicate timers
    Private Shared _timer As Timer = Nothing
    Private Shared _isPolling As Integer = 0
    Private Shared ReadOnly _serviceLock As New Object()

    ' Cached version numbers
    Private Shared _lastGlobalVersion As Long = -1
    Private Shared _lastPatientsVersion As Long = -1
    Private Shared _lastAppointmentsVersion As Long = -1
    Private Shared _lastConsultationsVersion As Long = -1
    Private Shared _lastPrescriptionsVersion As Long = -1
    Private Shared _lastSchedulesVersion As Long = -1
    Private Shared _lastStaffVersion As Long = -1
    Private Shared _lastSettingsVersion As Long = -1
    Private Shared _lastAuditVersion As Long = -1

    ' Status & Diagnostics
    Public Shared Property IsActive As Boolean = False
    Public Shared Property IsConnected As Boolean = True
    Public Shared Property LastSyncTime As DateTime = DateTime.MinValue
    Public Shared Property LastError As String = ""
    Public Shared Property ConsecutiveErrors As Integer = 0

    ' Events for decoupled components
    Public Shared Event SyncChanged(domains As SyncDomain)
    Public Shared Event SyncStatusChanged(isConnected As Boolean, message As String)

    ''' <summary>
    ''' Starts the centralized background polling service (1500 ms interval).
    ''' Safe to call multiple times; duplicate starts are ignored.
    ''' </summary>
    Public Shared Sub Start()
        SyncLock _serviceLock
            If _timer IsNot Nothing Then Return

            ' Ensure database schema and triggers are ready
            DatabaseInitializer.Initialize()

            ' Seed initial versions from the database
            ReadInitialVersions()

            IsActive = True
            _timer = New Timer(AddressOf OnTimerTick, Nothing, PollingIntervalMs, PollingIntervalMs)
        End SyncLock
    End Sub

    ''' <summary>
    ''' Stops and disposes the background synchronization timer.
    ''' </summary>
    Public Shared Sub [Stop]()
        SyncLock _serviceLock
            If _timer IsNot Nothing Then
                _timer.Dispose()
                _timer = Nothing
            End If
            IsActive = False
        End SyncLock
    End Sub

    ''' <summary>
    ''' Timer callback executed every 1500 ms.
    ''' Employs an atomic re-entrancy lock to guarantee overlapping ticks do not occur.
    ''' </summary>
    Private Shared Sub OnTimerTick(state As Object)
        ' Prevent overlapping polls if a network query takes longer than 1500 ms
        If Interlocked.CompareExchange(_isPolling, 1, 0) <> 0 Then Return

        Try
            PollDatabase()
        Catch ex As Exception
            ' Global safety net to prevent timer thread crashes
            ConsecutiveErrors += 1
            LastError = ex.Message
        Finally
            Interlocked.Exchange(_isPolling, 0)
        End Try
    End Sub

    ''' <summary>
    ''' Queries the single-row _sync_version table in SQLite to check for changes.
    ''' Handles SQLite locking (busy) and network share disconnections safely.
    ''' </summary>
    Private Shared Sub PollDatabase()
        Dim changedDomains As SyncDomain = SyncDomain.None

        Try
            Using conn = DatabaseService.CreateOpenConnection()
                Using cmd = conn.CreateCommand()
                    cmd.CommandText = "
                        SELECT global_version, patients_version, appointments_version, consultations_version,
                               prescriptions_version, schedules_version, staff_version, settings_version, audit_version
                        FROM _sync_version
                        WHERE id = 1
                        LIMIT 1;
                    "
                    cmd.CommandTimeout = 5

                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim gVer = reader.GetInt64(0)
                            Dim patVer = reader.GetInt64(1)
                            Dim apptVer = reader.GetInt64(2)
                            Dim consVer = reader.GetInt64(3)
                            Dim rxVer = reader.GetInt64(4)
                            Dim schedVer = reader.GetInt64(5)
                            Dim staffVer = reader.GetInt64(6)
                            Dim setVer = reader.GetInt64(7)
                            Dim audVer = reader.GetInt64(8)

                            ' If global_version has changed, determine which specific domains changed
                            If _lastGlobalVersion <> -1 AndAlso gVer <> _lastGlobalVersion Then
                                If patVer <> _lastPatientsVersion Then changedDomains = changedDomains Or SyncDomain.Patients
                                If apptVer <> _lastAppointmentsVersion Then changedDomains = changedDomains Or SyncDomain.Appointments
                                If consVer <> _lastConsultationsVersion Then changedDomains = changedDomains Or SyncDomain.Consultations
                                If rxVer <> _lastPrescriptionsVersion Then changedDomains = changedDomains Or SyncDomain.Prescriptions
                                If schedVer <> _lastSchedulesVersion Then changedDomains = changedDomains Or SyncDomain.Schedules
                                If staffVer <> _lastStaffVersion Then changedDomains = changedDomains Or SyncDomain.Staff
                                If setVer <> _lastSettingsVersion Then changedDomains = changedDomains Or SyncDomain.Settings
                                If audVer <> _lastAuditVersion Then changedDomains = changedDomains Or SyncDomain.Audit
                            End If

                            ' Update cached versions
                            _lastGlobalVersion = gVer
                            _lastPatientsVersion = patVer
                            _lastAppointmentsVersion = apptVer
                            _lastConsultationsVersion = consVer
                            _lastPrescriptionsVersion = rxVer
                            _lastSchedulesVersion = schedVer
                            _lastStaffVersion = staffVer
                            _lastSettingsVersion = setVer
                            _lastAuditVersion = audVer
                        End If
                    End Using
                End Using
            End Using

            ' If we got here, connection is healthy
            Dim wasDisconnected = Not IsConnected
            IsConnected = True
            LastError = ""
            ConsecutiveErrors = 0
            LastSyncTime = DateTime.Now

            If wasDisconnected Then
                RaiseEvent SyncStatusChanged(True, "Connected")
            End If

            ' If any domain changed, dispatch targeted UI updates
            If changedDomains <> SyncDomain.None Then
                DispatchToUI(changedDomains)
            End If

        Catch sqliteEx As SqliteException
            ConsecutiveErrors += 1
            LastError = $"SQLite Busy/Lock ({sqliteEx.SqliteErrorCode}): {sqliteEx.Message}"
            ' If busy, do not mark as disconnected since it's just lock contention
            If sqliteEx.SqliteErrorCode <> 5 AndAlso sqliteEx.SqliteErrorCode <> 6 Then
                IsConnected = False
                RaiseEvent SyncStatusChanged(False, LastError)
            End If

        Catch ioEx As IOException
            ConsecutiveErrors += 1
            IsConnected = False
            LastError = $"Network I/O Error: {ioEx.Message}"
            RaiseEvent SyncStatusChanged(False, LastError)

        Catch ex As Exception
            ConsecutiveErrors += 1
            LastError = ex.Message
        End Try
    End Sub

    ''' <summary>
    ''' Reads the initial baseline versions so the first poll does not cause a spurious full refresh.
    ''' </summary>
    Private Shared Sub ReadInitialVersions()
        Try
            Using conn = DatabaseService.CreateOpenConnection()
                Using cmd = conn.CreateCommand()
                    cmd.CommandText = "
                        SELECT global_version, patients_version, appointments_version, consultations_version,
                               prescriptions_version, schedules_version, staff_version, settings_version, audit_version
                        FROM _sync_version
                        WHERE id = 1
                        LIMIT 1;
                    "
                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            _lastGlobalVersion = reader.GetInt64(0)
                            _lastPatientsVersion = reader.GetInt64(1)
                            _lastAppointmentsVersion = reader.GetInt64(2)
                            _lastConsultationsVersion = reader.GetInt64(3)
                            _lastPrescriptionsVersion = reader.GetInt64(4)
                            _lastSchedulesVersion = reader.GetInt64(5)
                            _lastStaffVersion = reader.GetInt64(6)
                            _lastSettingsVersion = reader.GetInt64(7)
                            _lastAuditVersion = reader.GetInt64(8)
                        End If
                    End Using
                End Using
            End Using
            IsConnected = True
            LastError = ""
            LastSyncTime = DateTime.Now
        Catch ex As Exception
            LastError = ex.Message
        End Try
    End Sub

    ''' <summary>
    ''' Dispatches targeted UI refreshes to the Windows Forms message loop.
    ''' </summary>
    Private Shared Sub DispatchToUI(domains As SyncDomain)
        Dim targetForm As Form = Nothing

        For Each f As Form In Application.OpenForms
            If f.IsHandleCreated AndAlso Not f.IsDisposed Then
                targetForm = f
                Exit For
            End If
        Next

        If targetForm IsNot Nothing Then
            targetForm.BeginInvoke(Sub()
                                       ExecuteTargetedRefreshes(domains)
                                   End Sub)
        End If
    End Sub

    ''' <summary>
    ''' Executes the targeted UI refreshes on the UI thread for currently open forms.
    ''' </summary>
    Private Shared Sub ExecuteTargetedRefreshes(domains As SyncDomain)
        Try
            ' 1. Refresh Administrator screens
            For Each adminShell In Application.OpenForms.OfType(Of AdminFormSidebar)().ToList()
                If adminShell.IsHandleCreated AndAlso Not adminShell.IsDisposed Then
                    adminShell.RefreshForSync(domains)
                End If
            Next

            ' 2. Refresh Doctor screens
            For Each docShell In Application.OpenForms.OfType(Of DoctorShell)().ToList()
                If docShell.IsHandleCreated AndAlso Not docShell.IsDisposed Then
                    docShell.RefreshForSync(domains)
                End If
            Next

            ' 3. Refresh Receptionist screens
            For Each recepShell In Application.OpenForms.OfType(Of ReceptionistDashboard)().ToList()
                If recepShell.IsHandleCreated AndAlso Not recepShell.IsDisposed Then
                    recepShell.RefreshForSync(domains)
                End If
            Next

            ' 4. Raise decoupled event
            RaiseEvent SyncChanged(domains)

            ' 5. Also notify legacy ClinicData.DataChanged if appointments, schedules, or consultations changed
            If (domains And (SyncDomain.Appointments Or SyncDomain.Schedules Or SyncDomain.Consultations)) <> 0 Then
                ClinicData.NotifyDataChanged()
            End If

        Catch ex As Exception
            ' Protect UI thread against unexpected refresh errors
            System.Diagnostics.Debug.WriteLine($"[DataSyncService] Refresh error: {ex.Message}")
        End Try
    End Sub

    ''' <summary>
    ''' Manually increments the sync version for a domain in the shared database.
    ''' Database triggers handle this automatically on SQL statements, but this helper
    ''' can be called directly by code when custom synchronization is needed.
    ''' </summary>
    Public Shared Sub BumpDomainVersion(domain As SyncDomain)
        Try
            Dim colName As String = ""
            Select Case domain
                Case SyncDomain.Patients : colName = "patients_version"
                Case SyncDomain.Appointments : colName = "appointments_version"
                Case SyncDomain.Consultations : colName = "consultations_version"
                Case SyncDomain.Prescriptions : colName = "prescriptions_version"
                Case SyncDomain.Schedules : colName = "schedules_version"
                Case SyncDomain.Staff : colName = "staff_version"
                Case SyncDomain.Settings : colName = "settings_version"
                Case SyncDomain.Audit : colName = "audit_version"
            End Select

            If Not String.IsNullOrEmpty(colName) Then
                Using conn = DatabaseService.CreateOpenConnection()
                    Using cmd = conn.CreateCommand()
                        cmd.CommandText = $"UPDATE _sync_version SET global_version = global_version + 1, {colName} = {colName} + 1, updated_at = datetime('now', 'localtime') WHERE id = 1;"
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"[DataSyncService] BumpDomainVersion error: {ex.Message}")
        End Try
    End Sub

End Class
