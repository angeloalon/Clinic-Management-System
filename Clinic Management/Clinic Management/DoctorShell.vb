Imports System.Linq
Imports Ferrando.UI.WinForms.Controles

Public Enum DoctorTab
    Dashboard
    Patients
    Appointments
    Schedule
    Consultation
    ConsultationWorkspace
    Reports
    PatientDetails
End Enum

Public Class DoctorShell

    Public Shared Property Current As DoctorShell

    Private sidebarHandler As SidebarHandler
    Private _currentTab As DoctorTab = DoctorTab.Dashboard
    Private _returnTabAfterPatientDetails As DoctorTab = DoctorTab.Patients

    ' Cached view instances for instant swapping without flicker
    Private _dashboardView As DoctorDashboard
    Private _patientsView As DoctorPatients
    Private _appointmentView As DoctorAppointment
    Private _scheduleView As DoctorsSchedule
    Private _consultationDirectoryView As DoctorConsultationDirectory
    Private _consultationView As DoctorConsultation
    Private _reportsView As DoctorReports
    Private _patientInfoView As DoctorPatientInformation

    Public Sub New()
        InitializeComponent()
        Current = Me
    End Sub

    Private Sub DoctorShell_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Fit the window inside the screen's usable area (excludes the taskbar)
        Dim wa As Rectangle = Screen.FromControl(Me).WorkingArea
        If Me.Height > wa.Height Then Me.Height = wa.Height
        If Me.Width > wa.Width Then Me.Width = wa.Width
        Me.Location = New Point(wa.Left + (wa.Width - Me.Width) \ 2,
                            wa.Top + (wa.Height - Me.Height) \ 2)

        If CurrentUser.IsAuthenticated Then
            txtName.Text = CurrentUser.FullName
            txtRole.Text = CurrentUser.RoleDisplay
        End If

        sidebarHandler = New SidebarHandler(btnDashboard, btnPatients, btnAppointment,
                                        btnDoctor, btnConsultation, btnReports)

        sideBar.Dock = DockStyle.Left
        btnLogout.Anchor = AnchorStyles.Bottom
        namePlaceHolder.Anchor = AnchorStyles.Bottom
        btnLogout.BringToFront()
        namePlaceHolder.BringToFront()

        LayoutSidebarBottom()
        NavigateTo(DoctorTab.Dashboard)
    End Sub

    ' Load fires before the form reaches its final size / DPI scaling,
    ' so lay out the bottom controls again once the window is actually shown.
    Private Sub DoctorShell_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        LayoutSidebarBottom()
    End Sub

    Private Sub DoctorShell_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        LayoutSidebarBottom()
    End Sub

    Private Sub sideBar_SizeChanged(sender As Object, e As EventArgs) Handles sideBar.SizeChanged
        LayoutSidebarBottom()
    End Sub

    Private Sub LayoutSidebarBottom()
        If sideBar Is Nothing OrElse btnLogout Is Nothing OrElse namePlaceHolder Is Nothing Then Return

        ' Use the smaller of the sidebar's height and the space actually visible in the form,
        ' so the bottom controls never sit below the window edge.
        Dim visibleHeight As Integer = Math.Min(sideBar.ClientSize.Height,
                                                Me.ClientSize.Height - sideBar.Top)

        btnLogout.Top = visibleHeight - btnLogout.Height - 16
        namePlaceHolder.Top = btnLogout.Top - namePlaceHolder.Height - 8
        btnLogout.Left = Math.Max(0, (sideBar.ClientSize.Width - btnLogout.Width) \ 2)
        namePlaceHolder.Left = Math.Max(0, (sideBar.ClientSize.Width - namePlaceHolder.Width) \ 2)

        btnLogout.BringToFront()
        namePlaceHolder.BringToFront()
    End Sub

    ' =========================================================================
    ' Public Navigation Hub
    ' =========================================================================

    Public Sub NavigateTo(tab As DoctorTab)
        _currentTab = tab

        Select Case tab
            Case DoctorTab.Dashboard
                If _dashboardView Is Nothing OrElse _dashboardView.IsDisposed Then
                    _dashboardView = New DoctorDashboard()
                End If
                ShowView(_dashboardView, btnDashboard)

            Case DoctorTab.Patients
                If _patientsView Is Nothing OrElse _patientsView.IsDisposed Then
                    _patientsView = New DoctorPatients()
                End If
                ShowView(_patientsView, btnPatients)

            Case DoctorTab.Appointments
                If _appointmentView Is Nothing OrElse _appointmentView.IsDisposed Then
                    _appointmentView = New DoctorAppointment()
                End If
                ShowView(_appointmentView, btnAppointment)

            Case DoctorTab.Schedule
                If _scheduleView Is Nothing OrElse _scheduleView.IsDisposed Then
                    _scheduleView = New DoctorsSchedule()
                End If
                ShowView(_scheduleView, btnDoctor)

            Case DoctorTab.Consultation
                If _consultationDirectoryView Is Nothing OrElse _consultationDirectoryView.IsDisposed Then
                    _consultationDirectoryView = New DoctorConsultationDirectory()
                End If
                ShowView(_consultationDirectoryView, btnConsultation)

            Case DoctorTab.ConsultationWorkspace
                If _consultationView Is Nothing OrElse _consultationView.IsDisposed Then
                    _consultationView = New DoctorConsultation()
                End If
                ShowView(_consultationView, btnConsultation)

            Case DoctorTab.Reports
                If _reportsView Is Nothing OrElse _reportsView.IsDisposed Then
                    _reportsView = New DoctorReports()
                End If
                ShowView(_reportsView, btnReports)
        End Select
    End Sub

    ''' <summary>Navigates directly to an individual patient's medical chart.</summary>
    Public Sub OpenPatient(patientId As String, Optional returnTo As DoctorTab = DoctorTab.Patients)
        _returnTabAfterPatientDetails = returnTo
        _currentTab = DoctorTab.PatientDetails
        If _patientInfoView Is Nothing OrElse _patientInfoView.IsDisposed Then
            _patientInfoView = New DoctorPatientInformation(patientId)
        Else
            _patientInfoView.LoadPatientData(patientId)
        End If
        _patientInfoView.ConfigureBackButton(returnTo)
        ShowView(_patientInfoView, If(returnTo = DoctorTab.Consultation, btnConsultation, btnPatients))
    End Sub

    ''' <summary>Returns from patient details back to the initiating tab (Consultation or Patients).</summary>
    Public Sub ReturnFromPatientDetails()
        NavigateTo(_returnTabAfterPatientDetails)
    End Sub

    ''' <summary>Navigates directly to a consultation session for a specific patient in the workspace.</summary>
    Public Sub OpenConsultation(Optional item As AppointmentItem = Nothing)
        _currentTab = DoctorTab.ConsultationWorkspace
        If _consultationView Is Nothing OrElse _consultationView.IsDisposed Then
            If item IsNot Nothing Then
                _consultationView = New DoctorConsultation(item)
            Else
                _consultationView = New DoctorConsultation()
            End If
        Else
            If item IsNot Nothing Then
                _consultationView.LoadAppointment(item)
            ElseIf _consultationView.CurrentAppointment Is Nothing OrElse _consultationView.CurrentAppointment.Status = "Completed" Then
                _consultationView.LoadAppointment(ClinicData.NextPending())
            End If
        End If
        ShowView(_consultationView, btnConsultation)
    End Sub

    ' =========================================================================
    ' Shell View Swapper (Zero-Flicker Host)
    ' =========================================================================

    Private Sub ShowView(view As Form, activeSidebarBtn As FButton)
        pnlContentHost.SuspendLayout()

        ' Remove previous view from host (keep cached instance alive)
        pnlContentHost.Controls.Clear()

        ' Configure child Form to act as an embedded borderless view
        view.TopLevel = False
        view.FormBorderStyle = FormBorderStyle.None

        ' Hide child's redundant inner sidebar
        Dim innerSidebar = view.Controls.Find("sideBar", True).FirstOrDefault()
        If innerSidebar IsNot Nothing Then
            innerSidebar.Visible = False
        End If

        ' Position child's mainScreen canvas at (0, 0) and allow it to fill client viewport
        Dim mainCanvas = view.Controls.Find("mainScreen", True).FirstOrDefault()
        If mainCanvas IsNot Nothing Then
            mainCanvas.Location = New Point(0, 0)
            mainCanvas.Dock = DockStyle.Fill
        End If

        view.Size = pnlContentHost.ClientSize
        view.Location = New Point(0, 0)
        view.Dock = DockStyle.Fill

        pnlContentHost.Controls.Add(view)
        view.Show()
        view.BringToFront()

        ' Refresh dynamic child views
        If TypeOf view Is DoctorDashboard Then
            DirectCast(view, DoctorDashboard).RefreshDashboard()
        ElseIf TypeOf view Is DoctorAppointment Then
            DirectCast(view, DoctorAppointment).RefreshData()
        ElseIf TypeOf view Is DoctorConsultationDirectory Then
            DirectCast(view, DoctorConsultationDirectory).RefreshRows()
        End If

        pnlContentHost.ResumeLayout()

        ' Update sidebar button state
        If activeSidebarBtn IsNot Nothing Then
            sidebarHandler.SetActive(activeSidebarBtn)
        End If
    End Sub

    ' =========================================================================
    ' Sidebar Click Handlers
    ' =========================================================================

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        NavigateTo(DoctorTab.Dashboard)
    End Sub

    Private Sub btnPatients_Click(sender As Object, e As EventArgs) Handles btnPatients.Click
        NavigateTo(DoctorTab.Patients)
    End Sub

    Private Sub btnAppointment_Click(sender As Object, e As EventArgs) Handles btnAppointment.Click
        NavigateTo(DoctorTab.Appointments)
    End Sub

    Private Sub btnDoctor_Click(sender As Object, e As EventArgs) Handles btnDoctor.Click
        NavigateTo(DoctorTab.Schedule)
    End Sub

    Private Sub btnConsultation_Click(sender As Object, e As EventArgs) Handles btnConsultation.Click
        NavigateTo(DoctorTab.Consultation)
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        NavigateTo(DoctorTab.Reports)
    End Sub

    Private _isLoggingOut As Boolean = False

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim res = MessageBox.Show("Are you sure you want to log out of the Doctor portal?", "Confirm Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If res = DialogResult.Yes Then
            AuditStore.Log(CurrentUser.FullName, CurrentUser.Role, "Sign-out", "Doctor logged out", "Success")
            CurrentUser.SignOut()
            _isLoggingOut = True
            Dim login = Application.OpenForms.OfType(Of LoginForm)().FirstOrDefault()
            If login IsNot Nothing Then
                login.ResetForm()
                login.Show()
            Else
                Dim newLogin As New LoginForm()
                newLogin.Show()
            End If
            Me.Close()
        End If
    End Sub

    Private Sub DoctorShell_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Not _isLoggingOut Then
            Application.Exit()
        End If
    End Sub

End Class