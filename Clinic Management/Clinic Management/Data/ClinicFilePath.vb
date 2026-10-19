Imports System.IO

''' <summary>
''' Centralized database path helper for UCC Health Clinic.
''' 
''' ═══════════════════════════════════════════════════════════════════════════════════
''' HOW TO CONFIGURE FOR TWO LAPTOPS:
''' ═══════════════════════════════════════════════════════════════════════════════════
''' LAPTOP 1 (Host PC - stores the database):
'''    Leave DatabasePath = "" (empty string) and do not create clinic_path.txt.
'''    The system will automatically find and use the local Data\clinic.db file.
'''    Share the Data folder in Windows:
'''      Right-click Data folder > Properties > Sharing > Advanced Sharing > Share as "data"
'''      Permissions: Everyone -> Full Control (Read/Write).
''' 
''' LAPTOP 2 (Client PC - receptionist or second room):
'''    OPTION A (No recompile needed):
'''      Create a text file named "clinic_path.txt" in the application folder (next to the .exe)
'''      and put the network path inside, e.g.:
'''        \\192.168.1.15\data\clinic.db
''' 
'''    OPTION B (In code):
'''      Public Shared DatabasePath As String = "\\192.168.1.15\data\clinic.db"
'''      (or via Tailscale: "\\100.85.12.34\data\clinic.db")
''' ═══════════════════════════════════════════════════════════════════════════════════
''' </summary>
Public Class ClinicFilePath

    ''' <summary>
    ''' Set your custom database path here in code.
    ''' For Laptop 2, enter: "\\<IP_ADDRESS_OF_LAPTOP_1>\data\clinic.db"
    ''' Leave empty ("") to automatically check clinic_path.txt or use local Data\clinic.db.
    ''' </summary>
    Public Shared DatabasePath As String = ""

    ''' <summary>
    ''' Resolves the active database file path.
    ''' Priority:
    ''' 1. DatabasePath variable in code (if non-empty).
    ''' 2. "clinic_path.txt" file in the app directory or project root (if exists).
    ''' 3. Default local Data\clinic.db.
    ''' </summary>
    Public Shared Function GetDatabasePath() As String
        ' 1. Check in-code override
        If Not String.IsNullOrWhiteSpace(DatabasePath) Then
            Return DatabasePath.Trim()
        End If

        ' 2. Check for clinic_path.txt override file
        Dim fileOverride = TryReadClinicPathFile()
        If Not String.IsNullOrWhiteSpace(fileOverride) Then
            Return fileOverride.Trim()
        End If

        ' 3. Default local database
        Return ResolveDefaultLocalPath()
    End Function

    ''' <summary>
    ''' Checks if the active database path is a remote network UNC share (starts with \\ or //).
    ''' </summary>
    Public Shared Function IsNetworkPath() As Boolean
        Dim p = GetDatabasePath()
        Return Not String.IsNullOrWhiteSpace(p) AndAlso (p.StartsWith("\\") OrElse p.StartsWith("//"))
    End Function

    ''' <summary>
    ''' Searches for clinic_path.txt in the application directory or parent directories.
    ''' </summary>
    Private Shared Function TryReadClinicPathFile() As String
        Try
            Dim baseDir As String = AppDomain.CurrentDomain.BaseDirectory
            Dim currentDir As New DirectoryInfo(baseDir)

            ' Search app execution dir and parent directories up to 4 levels
            Dim levels As Integer = 0
            While currentDir IsNot Nothing AndAlso levels < 5
                Dim txtFile = Path.Combine(currentDir.FullName, "clinic_path.txt")
                If File.Exists(txtFile) Then
                    Dim lines = File.ReadAllLines(txtFile)
                    For Each line In lines
                        Dim trimmed = line.Trim()
                        If Not String.IsNullOrWhiteSpace(trimmed) AndAlso Not trimmed.StartsWith("#") Then
                            Return trimmed
                        End If
                    Next
                End If
                currentDir = currentDir.Parent
                levels += 1
            End While
        Catch
            ' Ignore file read errors; fallback to default
        End Try
        Return Nothing
    End Function

    ''' <summary>
    ''' Automatically finds Data\clinic.db by looking in the project directory
    ''' or the current application execution directory.
    ''' </summary>
    Private Shared Function ResolveDefaultLocalPath() As String
        Dim baseDir As String = AppDomain.CurrentDomain.BaseDirectory
        Dim currentDir As New DirectoryInfo(baseDir)

        ' 1. Ascend directory tree looking for project source folder containing .vbproj
        While currentDir IsNot Nothing
            Dim projFiles = currentDir.GetFiles("*.vbproj")
            If projFiles.Length > 0 Then
                Dim dataDir = Path.Combine(currentDir.FullName, "Data")
                If Not Directory.Exists(dataDir) Then Directory.CreateDirectory(dataDir)
                Return Path.Combine(dataDir, "clinic.db")
            End If
            currentDir = currentDir.Parent
        End While

        ' 2. Fallback to application execution folder /Data/clinic.db
        Dim localDataDir = Path.Combine(baseDir, "Data")
        If Not Directory.Exists(localDataDir) Then Directory.CreateDirectory(localDataDir)
        Return Path.Combine(localDataDir, "clinic.db")
    End Function

    ''' <summary>
    ''' Tests whether the configured database file can be reached and opened.
    ''' </summary>
    Public Shared Function TestConnection(ByRef latencyMs As Long, ByRef tableCount As Integer, ByRef errorMessage As String) As Boolean
        Return DatabaseService.TestDatabaseConnection(GetDatabasePath(), latencyMs, tableCount, errorMessage)
    End Function

End Class
