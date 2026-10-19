Imports System.Windows.Forms

Public Class SessionManager
    Implements IMessageFilter

    Private Shared _instance As SessionManager
    Private Shared _lastActivity As DateTime = DateTime.Now
    Private Shared _timer As System.Windows.Forms.Timer
    Private Shared _timeoutMinutes As Integer = 15

    Public Shared Property TimeoutMinutes As Integer
        Get
            Return _timeoutMinutes
        End Get
        Set(value As Integer)
            _timeoutMinutes = Math.Max(1, value)
        End Set
    End Property

    Public Shared Sub Initialize()
        If _instance IsNot Nothing Then Return
        _instance = New SessionManager()
        Application.AddMessageFilter(_instance)

        _timer = New System.Windows.Forms.Timer()
        _timer.Interval = 10000 ' Poll every 10 seconds
        AddHandler _timer.Tick, AddressOf OnCheckInactivity
        _timer.Start()
        _lastActivity = DateTime.Now
    End Sub

    Public Shared Sub ResetActivity()
        _lastActivity = DateTime.Now
    End Sub

    Public Function PreFilterMessage(ByRef m As Message) As Boolean Implements IMessageFilter.PreFilterMessage
        Const WM_KEYDOWN As Integer = &H100
        Const WM_KEYUP As Integer = &H101
        Const WM_MOUSEMOVE As Integer = &H200
        Const WM_LBUTTONDOWN As Integer = &H201
        Const WM_RBUTTONDOWN As Integer = &H204
        Const WM_MBUTTONDOWN As Integer = &H207

        Select Case m.Msg
            Case WM_KEYDOWN, WM_KEYUP, WM_LBUTTONDOWN, WM_RBUTTONDOWN, WM_MBUTTONDOWN
                _lastActivity = DateTime.Now
            Case WM_MOUSEMOVE
                If (DateTime.Now - _lastActivity).TotalSeconds > 2 Then
                    _lastActivity = DateTime.Now
                End If
        End Select
        Return False
    End Function

    Private Shared Sub OnCheckInactivity(sender As Object, e As EventArgs)
        If Not CurrentUser.IsAuthenticated Then
            _lastActivity = DateTime.Now
            Return
        End If

        If (DateTime.Now - _lastActivity).TotalMinutes >= _timeoutMinutes Then
            _timer.Stop()
            Dim user = CurrentUser.FullName
            Dim role = CurrentUser.Role
            AuditStore.Log(user, role, "Auto-logout", $"Session timed out after {_timeoutMinutes} minutes of inactivity", "Success")
            CurrentUser.SignOut()

            MessageBox.Show($"Your session has expired after {_timeoutMinutes} minutes of inactivity.{Environment.NewLine}You have been logged out for security.",
                            "Session Expired", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim formsToClose = Application.OpenForms.Cast(Of Form)().Where(Function(f) Not (TypeOf f Is LoginForm)).ToList()
            Dim login = Application.OpenForms.OfType(Of LoginForm)().FirstOrDefault()

            For Each f In formsToClose
                f.Hide()
                f.Close()
            Next

            If login IsNot Nothing Then
                login.ResetForm()
                login.Show()
            Else
                Dim newLogin As New LoginForm()
                newLogin.Show()
            End If

            _lastActivity = DateTime.Now
            _timer.Start()
        End If
    End Sub

End Class
