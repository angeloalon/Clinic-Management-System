Imports System.IO
Imports Microsoft.Data.Sqlite

Public Class DatabaseService

    Private Shared _connectionString As String = Nothing
    Private Shared ReadOnly _lockObj As New Object()

    ''' <summary>
    ''' Resolves the persistent SQLite database file path using ClinicFilePath.
    ''' </summary>
    Public Shared ReadOnly Property DatabasePath As String
        Get
            Return ClinicFilePath.GetDatabasePath()
        End Get
    End Property

    ''' <summary>
    ''' Reloads database configuration, resets cached connection strings and initialization status.
    ''' </summary>
    Public Shared Sub ReloadConnection()
        SyncLock _lockObj
            _connectionString = Nothing
            DatabaseInitializer.ResetInitialization()
        End SyncLock
    End Sub

    ''' <summary>
    ''' Checks if the database path is a remote network UNC share (e.g. \\192.168.x.x\data\clinic.db).
    ''' </summary>
    Public Shared Function IsNetworkPath(Optional path As String = Nothing) As Boolean
        If Not String.IsNullOrWhiteSpace(path) Then
            Return path.StartsWith("\\") OrElse path.StartsWith("//")
        End If
        Return ClinicFilePath.IsNetworkPath()
    End Function

    ''' <summary>
    ''' Connection string configured for high performance and concurrency in desktop WinForms.
    ''' </summary>
    Public Shared ReadOnly Property ConnectionString As String
        Get
            If _connectionString Is Nothing Then
                _connectionString = $"Data Source={DatabasePath};Mode=ReadWriteCreate;Cache=Shared;"
            End If
            Return _connectionString
        End Get
    End Property

    ''' <summary>
    ''' Opens a new SqliteConnection with mandatory enterprise PRAGMAs configured:
    ''' - foreign_keys = ON (Enforces referential integrity)
    ''' - journal_mode = WAL (Local) or DELETE (Network / Tailscale SMB share)
    ''' - synchronous = NORMAL (Optimized write durability)
    ''' - busy_timeout = 5000 (Local) or 10000 (Network concurrency)
    ''' </summary>
    Public Shared Function CreateOpenConnection() As SqliteConnection
        Dim conn As New SqliteConnection(ConnectionString)
        conn.Open()

        Dim isNetwork = IsNetworkPath(DatabasePath)
        Using cmd = conn.CreateCommand()
            cmd.CommandText = "PRAGMA foreign_keys = ON;"
            cmd.ExecuteNonQuery()

            ' Use DELETE journal mode universally so clinic.db never locks into WAL mode,
            ' ensuring full compatibility across Windows network shares (SMB / Tailscale)
            cmd.CommandText = "PRAGMA journal_mode = DELETE;"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "PRAGMA busy_timeout = 10000;"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "PRAGMA synchronous = NORMAL;"
            cmd.ExecuteNonQuery()
        End Using

        Return conn
    End Function

    ''' <summary>
    ''' Tests connection to a given database file path, verifying table presence and measuring round-trip latency.
    ''' </summary>
    Public Shared Function TestDatabaseConnection(path As String, ByRef latencyMs As Long, ByRef tableCount As Integer, ByRef errMessage As String) As Boolean
        latencyMs = 0
        tableCount = 0
        errMessage = ""

        If String.IsNullOrWhiteSpace(path) Then
            errMessage = "Database path cannot be empty."
            Return False
        End If

        Dim sw = Diagnostics.Stopwatch.StartNew()
        Try
            Dim testConnStr = $"Data Source={path.Trim()};Mode=ReadOnly;Cache=Shared;"
            Using conn As New SqliteConnection(testConnStr)
                conn.Open()
                Using cmd = conn.CreateCommand()
                    cmd.CommandText = "SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name NOT LIKE 'sqlite_%';"
                    cmd.CommandTimeout = 10
                    Dim result = cmd.ExecuteScalar()
                    tableCount = Convert.ToInt32(result)
                End Using
            End Using
            sw.Stop()
            latencyMs = sw.ElapsedMilliseconds
            Return True
        Catch ex As Exception
            sw.Stop()
            errMessage = ex.Message
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Executes a non-query command with parameterized inputs.
    ''' </summary>
    Public Shared Function ExecuteNonQuery(sql As String, ParamArray parameters As SqliteParameter()) As Integer
        Using conn = CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = sql
                If parameters IsNot Nothing Then
                    For Each p In parameters
                        cmd.Parameters.Add(p)
                    Next
                End If
                Return cmd.ExecuteNonQuery()
            End Using
        End Using
    End Function

    ''' <summary>
    ''' Executes a scalar command with parameterized inputs.
    ''' </summary>
    Public Shared Function ExecuteScalar(sql As String, ParamArray parameters As SqliteParameter()) As Object
        Using conn = CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = sql
                If parameters IsNot Nothing Then
                    For Each p In parameters
                        cmd.Parameters.Add(p)
                    Next
                End If
                Return cmd.ExecuteScalar()
            End Using
        End Using
    End Function

    ''' <summary>
    ''' Safely adds a parameter to a SQLite command, converting Nothing to DBNull.Value to prevent 'Value must be set' errors.
    ''' </summary>
    Public Shared Sub AddParam(cmd As SqliteCommand, paramName As String, value As Object)
        If value Is Nothing Then
            cmd.Parameters.AddWithValue(paramName, DBNull.Value)
        Else
            cmd.Parameters.AddWithValue(paramName, value)
        End If
    End Sub

End Class
