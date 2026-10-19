Imports System.IO
Imports System.Threading

Public Class GlobalErrorHandler

    Private Shared _isInitialized As Boolean = False
    Private Shared ReadOnly _lock As New Object()

    Public Shared Sub Initialize()
        If _isInitialized Then Return
        SyncLock _lock
            If _isInitialized Then Return

            Try
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException, False)
            Catch
                ' Ignore if controls have already been created on the UI thread
            End Try

            AddHandler Application.ThreadException, AddressOf OnThreadException
            AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf OnUnhandledException

            _isInitialized = True
        End SyncLock
    End Sub

    Private Shared Sub OnThreadException(sender As Object, e As ThreadExceptionEventArgs)
        LogError(e.Exception)
        ShowFriendlyError(e.Exception)
    End Sub

    Private Shared Sub OnUnhandledException(sender As Object, e As UnhandledExceptionEventArgs)
        Dim ex = TryCast(e.ExceptionObject, Exception)
        LogError(ex)
        If e.IsTerminating Then
            MessageBox.Show("A critical system error occurred. Details have been logged to the clinic error log.",
                            "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            ShowFriendlyError(ex)
        End If
    End Sub

    Private Shared Sub ShowFriendlyError(ex As Exception)
        Dim msg As String = "An unexpected error occurred while processing your request." & Environment.NewLine & Environment.NewLine &
                            "Details have been recorded in the clinic system log." & Environment.NewLine &
                            "If the problem persists, please contact clinic technical support."

        If ex IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(ex.Message) Then
            msg &= Environment.NewLine & Environment.NewLine & $"Message: {ex.Message}"
        End If

        MessageBox.Show(msg, "Clinic Management System Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Private Shared Sub LogError(ex As Exception)
        If ex Is Nothing Then Return
        Try
            Dim logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs")
            If Not Directory.Exists(logDir) Then Directory.CreateDirectory(logDir)
            Dim logFile = Path.Combine(logDir, $"error_{DateTime.Today:yyyyMMdd}.log")
            Dim logContent = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{CurrentUser.Role}:{CurrentUser.FullName}] " &
                             $"{ex.GetType().FullName}: {ex.Message}" & Environment.NewLine &
                             ex.StackTrace & Environment.NewLine &
                             New String("-"c, 60) & Environment.NewLine
            File.AppendAllText(logFile, logContent)
        Catch
            ' Avoid secondary exceptions in error logging
        End Try
    End Sub

End Class
