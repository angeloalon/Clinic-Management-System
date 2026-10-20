Imports System.Globalization
Imports System.Linq
Imports Ferrando.UI.WinForms.Controles

Public Class ReceptionistDashboard
    Implements IMessageFilter

    ' ---- Sidebar colors / fonts (from DESIGN_SYSTEM.md)
    Private ReadOnly NavDefaultBack As Color = Color.FromArgb(17, 54, 70)
    Private ReadOnly NavActiveBack As Color = Color.FromArgb(39, 73, 87)
    Private ReadOnly NavDefaultFore As Color = Color.FromArgb(182, 204, 210)
    Private ReadOnly NavActiveFore As Color = Color.FromArgb(255, 254, 255)
    Private ReadOnly NavDefaultFont As New Font("Noto Sans Georgian", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
    Private ReadOnly NavActiveFont As New Font("Noto Sans Georgian Bold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))

    ' ---- Dashboard colors
    Private ReadOnly ColTeal As Color = Color.FromArgb(35, 137, 120)
    Private ReadOnly ColDanger As Color = Color.FromArgb(205, 80, 75)
    Private ReadOnly ColTitle As Color = Color.FromArgb(22, 51, 65)
    Private ReadOnly ColBody As Color = Color.FromArgb(35, 45, 55)
    Private ReadOnly ColFeed As Color = Color.FromArgb(45, 60, 70)
    Private ReadOnly ColRowHover As Color = Color.FromArgb(248, 250, 252)

    ' Bullet built at runtime so the source stays plain ASCII
    Private Shared ReadOnly Bullet As String = ChrW(&H2022).ToString()

    ' Appointments shown per page. More than this -> next page (pager at the top-right of the card).
    Private Const RowsPerPage As Integer = 5
    ' Height of one schedule row
    Private Const ScheduleRowHeight As Integer = 44
    Private Const BaseRegisteredCount As Integer = 1248   ' TODO: replace with SELECT COUNT(*) FROM patients

    Private navButtons() As FButton

    ' Designer placeholder row controls (hidden at runtime; the rows are now built dynamically)
    Private rowTimes() As Label
    Private rowPatients() As Label
    Private rowTypes() As Label
    Private rowDoctors() As Label
    Private rowStatus() As FButton
    Private rowDividers() As Panel
    Private recentLabels() As Label

    ' Styles copied from the designer row 1 so the new rows look identical
    Private _fTime As Font
    Private _fPatient As Font
    Private _fType As Font
    Private _fDoctor As Font
    Private _fStatus As Font
    Private _cTime As Color
    Private _cPatient As Color
    Private _cType As Color
    Private _cDoctor As Color
    Private _cDivider As Color

    Private patientsPanel As ReceptionistPatients
    Private registerPanel As ReceptionistRegisterPatient
    Private patientInfoPanel As ReceptionistPatientInformation
    Private doctorSchedulesPanel As ReceptionistDoctorSchedules
    Private clinicReportsPanel As ReceptionistClinicReports
    Private consultationListPanel As ReceptionistConsultation
    Private consultationDetailPanel As ReceptionistConsultationDetail
    Private appointmentPanel As ReceptionistAppointment

    ' In-memory patient list (stands in for the database until it is connected)
    Private patientStore As List(Of PatientRecord)
    Private newlyRegistered As Integer = 0
    Private _currentScheduleList As New List(Of DashboardAppointment)

    ' ---- Schedule pagination / scrolling
    Private _schedulePage As Integer = 0
    Private _scheduleCard As Control
    Private _rowsPanel As ScrollPanel
    Private _binding As Boolean = False
    Private btnPrevPage As Button
    Private btnNextPage As Button
    Private lblPageInfo As Label
    Private _dashScroll As ScrollableControl

    ''' <summary>Panel that holds the schedule rows and scrolls when they do not fit.</summary>
    Private Class ScrollPanel
        Inherits Panel
        Public Sub New()
            SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            TabStop = False
        End Sub
    End Class

    ' =====================================================================
    '  Startup
    ' =====================================================================
    Private Sub ReceptionistDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Make sure the window fits above the taskbar so the Log out button is visible
        FitWindowToScreen()

        If CurrentUser.IsAuthenticated Then
            txtName.Text = CurrentUser.FullName
            txtRole.Text = CurrentUser.RoleDisplay
        End If

        navButtons = {btnDashboard, btnPatients, btnAppointment, btnDoctor, btnConsultation, btnReports}

        rowTimes = {lblRow1Time, lblRow2Time, lblRow3Time, lblRow4Time}
        rowPatients = {lblRow1Patient, lblRow2Patient, lblRow3Patient, lblRow4Patient}
        rowTypes = {lblRow1Type, lblRow2Type, lblRow3Type, lblRow4Type}
        rowDoctors = {lblRow1Doctor, lblRow2Doctor, lblRow3Doctor, lblRow4Doctor}
        rowStatus = {btnRow1Status, btnRow2Status, btnRow3Status, btnRow4Status}
        rowDividers = {pnlRow1Divider, pnlRow2Divider, pnlRow3Divider, pnlRow4Divider}
        recentLabels = {lblRecent1, lblRecent2, lblRecent3}

        ' Copy the designer look of row 1, then hide the designer rows (rows are built in code now)
        _fTime = lblRow1Time.Font
        _fPatient = lblRow1Patient.Font
        _fType = lblRow1Type.Font
        _fDoctor = lblRow1Doctor.Font
        _fStatus = btnRow1Status.Font
        _cTime = lblRow1Time.ForeColor
        _cPatient = lblRow1Patient.ForeColor
        _cType = lblRow1Type.ForeColor
        _cDoctor = lblRow1Doctor.ForeColor
        _cDivider = pnlRow1Divider.BackColor

        For i As Integer = 0 To rowTimes.Length - 1
            rowTimes(i).Visible = False
            rowPatients(i).Visible = False
            rowTypes(i).Visible = False
            rowDoctors(i).Visible = False
            rowStatus(i).Visible = False
            rowDividers(i).Visible = False
        Next

        ' Clickable recent patients
        For Each lbl As Label In recentLabels
            lbl.Cursor = Cursors.Hand
            AddHandler lbl.Click, AddressOf PatientLabel_Click
            AddHandler lbl.MouseEnter, AddressOf PatientLabel_MouseEnter
            AddHandler lbl.MouseLeave, AddressOf PatientLabel_MouseLeave
        Next

        ' 1. Patients page (UserControl)
        patientsPanel = New ReceptionistPatients() With {.Dock = DockStyle.Fill, .Visible = False}
        mainScreen.Controls.Add(patientsPanel)
        AddHandler patientsPanel.PatientSelected, AddressOf OnPatientOpened
        AddHandler patientsPanel.RegisterPatientRequested, AddressOf OnRegisterPatient

        ' 2. Register patient page (UserControl)
        registerPanel = New ReceptionistRegisterPatient() With {.Dock = DockStyle.Fill, .Visible = False}
        mainScreen.Controls.Add(registerPanel)
        AddHandler registerPanel.CancelRequested, AddressOf OnRegisterCancelled
        AddHandler registerPanel.PatientRegistered, AddressOf OnPatientRegistered

        ' 3. Patient information page (UserControl)
        patientInfoPanel = New ReceptionistPatientInformation() With {.Dock = DockStyle.Fill, .Visible = False}
        mainScreen.Controls.Add(patientInfoPanel)
        AddHandler patientInfoPanel.BackRequested, AddressOf OnPatientInfoBack
        AddHandler patientInfoPanel.ScheduleAppointmentRequested, AddressOf OnPatientInfoSchedule

        ' 4. Doctor schedules page (Embedded Form)
        doctorSchedulesPanel = New ReceptionistDoctorSchedules() With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None,
            .Dock = DockStyle.Fill,
            .Visible = False
        }
        mainScreen.Controls.Add(doctorSchedulesPanel)

        ' 5. Clinic reports page (Embedded Form)
        clinicReportsPanel = New ReceptionistClinicReports() With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None,
            .Dock = DockStyle.Fill,
            .Visible = False
        }
        mainScreen.Controls.Add(clinicReportsPanel)

        ' 6. Consultation master list (Embedded Form)
        consultationListPanel = New ReceptionistConsultation() With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None,
            .Dock = DockStyle.Fill,
            .Visible = False
        }
        mainScreen.Controls.Add(consultationListPanel)
        AddHandler consultationListPanel.PatientSelected, AddressOf OnConsultationPatientSelected

        ' 7. Consultation detail page (Embedded Form)
        consultationDetailPanel = New ReceptionistConsultationDetail() With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None,
            .Dock = DockStyle.Fill,
            .Visible = False
        }
        mainScreen.Controls.Add(consultationDetailPanel)
        AddHandler consultationDetailPanel.BackRequested, AddressOf OnConsultationDetailBack

        ' 8. Appointments page (ReceptionistAppointment UserControl)
        appointmentPanel = New ReceptionistAppointment() With {
            .Dock = DockStyle.Fill,
            .Visible = False
        }
        mainScreen.Controls.Add(appointmentPanel)
        AddHandler appointmentPanel.PatientSelected, AddressOf OnPatientOpened

        ' Schedule rows panel + pager
        BuildSchedulePager()

        ' The dashboard page scrolls when the window is too small to show everything
        _dashScroll = TryCast(pnlDashboard, ScrollableControl)
        If _dashScroll IsNot Nothing Then _dashScroll.AutoScroll = True

        ' Mouse wheel routing (schedule list / dashboard page)
        Application.AddMessageFilter(Me)

        ' Keep the Log out button in view whenever the sidebar changes size
        AddHandler sideBar.SizeChanged, Sub() LayoutSidebarBottom()

        ShowDashboard()
        LayoutSidebarBottom()
    End Sub

    Private Sub ReceptionistDashboard_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ' Load runs before the window reaches its final size / DPI scaling, so repeat once it is shown
        FitWindowToScreen()
        LayoutSidebarBottom()
        BindScheduleRows()
    End Sub

    Private Sub ReceptionistDashboard_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        LayoutSidebarBottom()
    End Sub

    ''' <summary>
    ''' Shrinks the window to the screen's working area (the screen minus the taskbar) and centers it.
    ''' A window taller than the working area is what pushes the Log out button behind the taskbar.
    ''' </summary>
    Private Sub FitWindowToScreen()
        If Me.WindowState <> FormWindowState.Normal Then Return

        Dim wa As Rectangle = Screen.FromControl(Me).WorkingArea
        If Me.Height > wa.Height Then Me.Height = wa.Height
        If Me.Width > wa.Width Then Me.Width = wa.Width
        Me.Location = New Point(wa.Left + (wa.Width - Me.Width) \ 2,
                                wa.Top + (wa.Height - Me.Height) \ 2)
    End Sub

    Private Sub LayoutSidebarBottom()
        If sideBar Is Nothing OrElse btnLogout Is Nothing OrElse namePlaceHolder Is Nothing Then Return

        ' Space the sidebar can really use (never taller than the window's client area)
        Dim available As Integer = Me.ClientSize.Height - sideBar.Top
        If available <= 0 Then Return

        If sideBar.Dock = DockStyle.None AndAlso sideBar.Height <> available Then
            sideBar.Height = available
        End If

        Dim visibleHeight As Integer = Math.Min(sideBar.ClientSize.Height, available)

        btnLogout.Top = visibleHeight - btnLogout.Height - 16
        namePlaceHolder.Top = btnLogout.Top - namePlaceHolder.Height - 8
        btnLogout.Left = Math.Max(0, (sideBar.ClientSize.Width - btnLogout.Width) \ 2)
        namePlaceHolder.Left = Math.Max(0, (sideBar.ClientSize.Width - namePlaceHolder.Width) \ 2)

        btnLogout.BringToFront()
        namePlaceHolder.BringToFront()
    End Sub

    ' =====================================================================
    '  Mouse wheel routing
    '  - Over the schedule list: scrolls the list when it overflows
    '  - Anywhere else on the dashboard: scrolls the dashboard page
    ' =====================================================================
    Public Function PreFilterMessage(ByRef m As Message) As Boolean Implements IMessageFilter.PreFilterMessage
        Const WM_MOUSEWHEEL As Integer = &H20A
        If m.Msg <> WM_MOUSEWHEEL Then Return False
        If Form.ActiveForm IsNot Me Then Return False
        If pnlDashboard Is Nothing OrElse Not pnlDashboard.Visible Then Return False

        Dim hi As Integer = CInt((m.WParam.ToInt64() >> 16) And &HFFFF)
        If hi > 32767 Then hi -= 65536
        If hi = 0 Then Return False
        Dim dir As Integer = Math.Sign(hi)   ' +1 = wheel up, -1 = wheel down

        Dim sp As Point = Cursor.Position

        ' 1) Schedule list
        If _rowsPanel IsNot Nothing AndAlso _rowsPanel.Visible Then
            Dim rowsRect As Rectangle = _rowsPanel.RectangleToScreen(_rowsPanel.ClientRectangle)
            If rowsRect.Contains(sp) AndAlso _rowsPanel.DisplayRectangle.Height > _rowsPanel.ClientSize.Height Then
                Dim offset As Integer = -_rowsPanel.AutoScrollPosition.Y - dir * ScheduleRowHeight
                _rowsPanel.AutoScrollPosition = New Point(0, Math.Max(0, offset))
                Return True
            End If
        End If

        ' 2) Dashboard page
        If _dashScroll IsNot Nothing Then
            Dim dashRect As Rectangle = _dashScroll.RectangleToScreen(_dashScroll.ClientRectangle)
            If dashRect.Contains(sp) AndAlso _dashScroll.DisplayRectangle.Height > _dashScroll.ClientSize.Height Then
                Dim offset As Integer = -_dashScroll.AutoScrollPosition.Y - dir * 60
                _dashScroll.AutoScrollPosition = New Point(-_dashScroll.AutoScrollPosition.X, Math.Max(0, offset))
                Return True
            End If
        End If

        Return False
    End Function

    ' =====================================================================
    '  Sidebar clicks
    ' =====================================================================
    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        ShowDashboard()
    End Sub

    Private Sub btnPatients_Click(sender As Object, e As EventArgs) Handles btnPatients.Click
        ShowPatientsPage()
    End Sub

    Private Sub btnAppointment_Click(sender As Object, e As EventArgs) Handles btnAppointment.Click
        appointmentPanel.RefreshData()
        ShowPage(appointmentPanel, btnAppointment)
    End Sub

    Private Sub btnDoctor_Click(sender As Object, e As EventArgs) Handles btnDoctor.Click
        doctorSchedulesPanel.Show()
        ShowPage(doctorSchedulesPanel, btnDoctor)
    End Sub

    Private Sub btnConsultation_Click(sender As Object, e As EventArgs) Handles btnConsultation.Click
        consultationListPanel.RefreshRows()
        consultationListPanel.Show()
        ShowPage(consultationListPanel, btnConsultation)
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        clinicReportsPanel.Show()
        ShowPage(clinicReportsPanel, btnReports)
    End Sub

    ' =====================================================================
    '  Dashboard buttons -> other pages
    ' =====================================================================
    Private Sub btnNewAppointment_Click(sender As Object, e As EventArgs) Handles btnNewAppointment.Click
        btnAppointment.PerformClick()
    End Sub

    Private Sub btnScheduleAppt_Click(sender As Object, e As EventArgs) Handles btnScheduleAppt.Click
        btnAppointment.PerformClick()
    End Sub

    Private Sub btnRegisterPatient_Click(sender As Object, e As EventArgs) Handles btnRegisterPatient.Click
        ' Quick action goes straight to the registration form
        OnRegisterPatient(sender, e)
    End Sub

    Private Sub btnOpenConsultation_Click(sender As Object, e As EventArgs) Handles btnOpenConsultation.Click
        btnConsultation.PerformClick()
    End Sub

    ' =====================================================================
    '  Page switching
    ' =====================================================================
    Public Sub RefreshDashboardView()
        If pnlDashboard IsNot Nothing AndAlso pnlDashboard.Visible Then
            LoadDashboard(GetTodayAppointments(), GetRecentPatients(), 11)
            BindScheduleRows()
        End If
    End Sub

    Public Sub RefreshPatientsView()
        If patientsPanel IsNot Nothing Then
            Dim pList = GetPatients()
            patientsPanel.LoadPatients(pList, pList.Count, preservePage:=True)
        End If
    End Sub

    Public Sub RefreshForSync(domains As SyncDomain)
        If (domains And (SyncDomain.Appointments Or SyncDomain.Patients)) <> 0 Then
            RefreshDashboardView()
        End If
        If (domains And SyncDomain.Patients) <> 0 Then
            RefreshPatientsView()
        End If
        If (domains And (SyncDomain.Patients Or SyncDomain.Appointments Or SyncDomain.Consultations)) <> 0 Then
            If patientInfoPanel IsNot Nothing AndAlso patientInfoPanel.Visible Then
                patientInfoPanel.RefreshCurrentPatient()
            End If
        End If
        If (domains And SyncDomain.Appointments) <> 0 Then
            If appointmentPanel IsNot Nothing Then
                appointmentPanel.RefreshData()
            End If
        End If
        If (domains And (SyncDomain.Schedules Or SyncDomain.Appointments Or SyncDomain.Staff)) <> 0 Then
            If doctorSchedulesPanel IsNot Nothing Then
                doctorSchedulesPanel.RefreshSchedule()
            End If
        End If
        If (domains And (SyncDomain.Appointments Or SyncDomain.Consultations)) <> 0 Then
            If consultationListPanel IsNot Nothing Then
                consultationListPanel.RefreshRows()
            End If
        End If
        If (domains And (SyncDomain.Consultations Or SyncDomain.Appointments)) <> 0 Then
            If consultationDetailPanel IsNot Nothing AndAlso consultationDetailPanel.Visible Then
                consultationDetailPanel.RefreshAccessState()
            End If
        End If
        If (domains And (SyncDomain.Appointments Or SyncDomain.Consultations Or SyncDomain.Patients)) <> 0 Then
            If clinicReportsPanel IsNot Nothing Then
                clinicReportsPanel.RefreshReportData()
            End If
        End If
    End Sub

    Private Sub ShowDashboard()
        LoadDashboard(GetTodayAppointments(), GetRecentPatients(), 11)   ' reload so KPIs are fresh
        ShowPage(pnlDashboard, btnDashboard)
    End Sub

    Private Sub ShowPatientsPage()
        Dim pList = GetPatients()
        patientsPanel.LoadPatients(pList, pList.Count)   ' reload so the list is fresh
        ShowPage(patientsPanel, btnPatients)
    End Sub

    ''' <summary>Only one child of mainScreen is visible at a time.</summary>
    Private Sub ShowPage(page As Control, activeButton As FButton)
        mainScreen.SuspendLayout()
        For Each c As Control In mainScreen.Controls
            c.Visible = ReferenceEquals(c, page)
        Next
        mainScreen.ResumeLayout()
        SetActiveNav(activeButton)
    End Sub

    ''' <summary>Temporary page until the real panel exists (reuses Label5).</summary>
    Private Sub ShowPlaceholder(title As String, activeButton As FButton)
        Label5.Text = $"{title} page goes here"
        Label5.Location = New Point((mainScreen.Width - Label5.Width) \ 2, (mainScreen.Height - Label5.Height) \ 2)
        ShowPage(Label5, activeButton)
    End Sub

    ''' <summary>Sets the Mouse* props too, so hover/leave never resets the wrong colors.</summary>
    Private Sub SetActiveNav(active As FButton)
        For Each b As FButton In navButtons
            Dim isActive = ReferenceEquals(b, active)
            Dim back = If(isActive, NavActiveBack, NavDefaultBack)
            Dim fore = If(isActive, NavActiveFore, NavDefaultFore)
            Dim f = If(isActive, NavActiveFont, NavDefaultFont)

            b.BackColor = back
            b.ForeColor = fore
            b.Font = f

            b.MouseLeaveBackColor = back
            b.MouseLeaveForeColor = fore
            b.MouseLeaveFont = f

            b.MouseEnterBackColor = NavActiveBack
            b.MouseEnterForeColor = NavActiveFore
            b.MouseEnterFont = f
        Next
    End Sub

    ' =====================================================================
    '  Dashboard data binding
    ' =====================================================================
    Private Sub LoadDashboard(appointments As IEnumerable(Of DashboardAppointment),
                              recentPatients As IEnumerable(Of RecentPatient),
                              avgWaitMinutes As Integer)

        ' ---- Header
        Dim h = Date.Now.Hour
        Dim greet = If(h < 12, "Good morning", If(h < 18, "Good afternoon", "Good evening"))
        lblGreeting.Text = $"{greet}, {GetGreetingName()}"
        lblSubtitle.Text = Date.Now.ToString("dddd, MMMM d", CultureInfo.CurrentCulture) & " " & Bullet & " Clinic operations at a glance"

        Dim list = appointments.OrderBy(Function(a) a.AppointmentTime).ToList()
        _currentScheduleList = list

        ' ---- KPIs (always calculated from the full list, not just the visible page)
        Dim total = list.Count
        Dim completed = list.Where(Function(a) HasStatus(a, "Completed")).Count()
        Dim cancelled = list.Where(Function(a) HasStatus(a, "Cancelled")).Count()
        Dim waiting = list.Where(Function(a) HasStatus(a, "Pending")).Count()
        Dim rescheduled = list.Where(Function(a) a.IsRescheduled).Count()
        Dim remaining = total - completed - cancelled
        Dim pct = If(total = 0, 0, CInt(Math.Round(completed * 100.0 / total)))

        lblCard1Value.Text = total.ToString()
        lblCard1Context.Text = $"{remaining} remaining"

        lblCard2Value.Text = waiting.ToString()
        lblCard2Context.Text = If(waiting > 0 AndAlso avgWaitMinutes > 0, $"Avg. {avgWaitMinutes} min", "No one waiting")

        lblCard3Value.Text = completed.ToString()
        lblCard3Context.Text = $"{pct}% of today"

        lblCard4Value.Text = cancelled.ToString()
        lblCard4Value.ForeColor = If(cancelled > 0, ColDanger, ColTitle)
        lblCard4Context.Text = $"{rescheduled} rescheduled"

        ' ---- Schedule rows (current page only)
        BindScheduleRows()

        ' ---- Recent patients
        Dim recents = recentPatients.Take(recentLabels.Length).ToList()
        For i As Integer = 0 To recentLabels.Length - 1
            If i < recents.Count Then
                recentLabels(i).Text = $"{ValidationHelper.NormalizeProperCase(recents(i).PatientName)} {Bullet} {recents(i).PatientId}"
                recentLabels(i).Tag = recents(i).PatientId
                recentLabels(i).Visible = True
            Else
                recentLabels(i).Visible = False
            End If
        Next
    End Sub

    ' =====================================================================
    '  Schedule rows, pagination + scrolling
    ' =====================================================================
    Private Function SchedulePageCount() As Integer
        Return Math.Max(1, CInt(Math.Ceiling(_currentScheduleList.Count / CDbl(RowsPerPage))))
    End Function

    ''' <summary>Clears and rebuilds the rows for the current page.</summary>
    Private Sub BindScheduleRows()
        If _rowsPanel Is Nothing OrElse _binding Then Return
        _binding = True
        Try
            Dim total As Integer = _currentScheduleList.Count
            Dim pageCount As Integer = SchedulePageCount()

            If _schedulePage > pageCount - 1 Then _schedulePage = pageCount - 1
            If _schedulePage < 0 Then _schedulePage = 0

            _rowsPanel.SuspendLayout()
            For i As Integer = _rowsPanel.Controls.Count - 1 To 0 Step -1
                Dim c = _rowsPanel.Controls(i)
                _rowsPanel.Controls.RemoveAt(i)
                c.Dispose()
            Next

            lblEmpty.Visible = (total = 0)
            _rowsPanel.Visible = (total > 0)

            Dim startIndex As Integer = _schedulePage * RowsPerPage
            Dim count As Integer = Math.Min(RowsPerPage, Math.Max(0, total - startIndex))

            ' Leave room for the scrollbar only when the rows do not fit
            Dim needsScroll As Boolean = count * ScheduleRowHeight > _rowsPanel.ClientSize.Height
            Dim rowW As Integer = _rowsPanel.ClientSize.Width - If(needsScroll, SystemInformation.VerticalScrollBarWidth, 0)

            For i As Integer = 0 To count - 1
                Dim row = CreateScheduleRow(_currentScheduleList(startIndex + i), i * ScheduleRowHeight, rowW, i < count - 1)
                _rowsPanel.Controls.Add(row)
            Next

            _rowsPanel.AutoScrollPosition = New Point(0, 0)
            _rowsPanel.ResumeLayout(True)
            UpdatePager(pageCount)
        Finally
            _binding = False
        End Try
    End Sub

    Private Function CreateScheduleRow(item As DashboardAppointment, y As Integer, w As Integer, showDivider As Boolean) As Panel
        Dim row As New Panel With {
            .Location = New Point(0, y),
            .Size = New Size(w, ScheduleRowHeight),
            .BackColor = Color.White,
            .Cursor = Cursors.Hand
        }

        ' Status pill is pinned to the right edge; the doctor column ends before it so nothing overlaps
        Dim pillText As String = StatusText(item.Status)
        Dim pillW As Integer = Math.Max(92, TextRenderer.MeasureText(pillText, _fStatus).Width + 28)
        Dim pillH As Integer = 24
        Dim pillX As Integer = w - 4 - pillW

        Const timeX As Integer = 4
        Const patientX As Integer = 82
        Const typeX As Integer = 216
        Const doctorX As Integer = 304

        Dim lblTime = MakeRowLabel(ClinicDataTimeText(item), _fTime, _cTime, timeX, 74, True)
        Dim lblPatient = MakeRowLabel(ValidationHelper.NormalizeProperCase(item.PatientName), _fPatient, _cPatient, patientX, typeX - patientX - 4, False)
        Dim lblType = MakeRowLabel(item.VisitType, _fType, _cType, typeX, doctorX - typeX - 4, False)
        Dim lblDoctor = MakeRowLabel(item.DoctorName, _fDoctor, _cDoctor, doctorX, Math.Max(40, pillX - doctorX - 8), False)

        row.Controls.AddRange(New Control() {lblTime, lblPatient, lblType, lblDoctor})

        ' Status pill / Check in button
        Dim pill As FButton = CreateStatusPill(item.Status, pillText, pillW, pillH)
        pill.Location = New Point(pillX, (ScheduleRowHeight - pillH) \ 2)
        row.Controls.Add(pill)

        ' Divider
        If showDivider Then
            row.Controls.Add(New Panel With {
                .Dock = DockStyle.Bottom,
                .Height = 1,
                .BackColor = _cDivider
            })
        End If

        ' Clicking the row opens the patient
        Dim open As EventHandler = Sub(s, e)
                                       If Not String.IsNullOrEmpty(item.PatientId) Then OnPatientOpened(item.PatientId)
                                   End Sub
        AddHandler row.Click, open
        For Each lbl As Label In {lblTime, lblPatient, lblType, lblDoctor}
            AddHandler lbl.Click, open
        Next

        ' Pill: Confirmed -> check in, anything else -> open patient
        If String.Equals(item.Status, "Confirmed", StringComparison.OrdinalIgnoreCase) Then
            AddHandler pill.Click, Sub(s, e) CheckInAppointment(item)
        Else
            pill.Cursor = Cursors.Default
            AddHandler pill.Click, open
        End If

        WireRowHover(row)
        Return row
    End Function

    Private Function ClinicDataTimeText(item As DashboardAppointment) As String
        Return item.AppointmentTime.ToString("h:mm tt", CultureInfo.InvariantCulture)
    End Function

    Private Function MakeRowLabel(text As String, f As Font, c As Color, x As Integer, w As Integer, isTime As Boolean) As Label
        Return New Label With {
            .Text = text,
            .Font = f,
            .ForeColor = c,
            .BackColor = Color.Transparent,
            .AutoSize = False,
            .AutoEllipsis = True,
            .Location = New Point(x, 0),
            .Size = New Size(Math.Max(10, w), ScheduleRowHeight),
            .TextAlign = ContentAlignment.MiddleLeft,
            .Cursor = Cursors.Hand
        }
    End Function

    Private Sub WireRowHover(row As Panel)
        Dim enter As EventHandler = Sub(s, e) row.BackColor = ColRowHover
        Dim leave As EventHandler = Sub(s, e)
                                        If Not row.RectangleToScreen(row.ClientRectangle).Contains(Cursor.Position) Then
                                            row.BackColor = Color.White
                                        End If
                                    End Sub
        AddHandler row.MouseEnter, enter
        AddHandler row.MouseLeave, leave
        For Each child As Control In row.Controls
            AddHandler child.MouseEnter, enter
            AddHandler child.MouseLeave, leave
        Next
    End Sub

    Private Shared Function StatusText(status As String) As String
        If String.Equals(status, "Confirmed", StringComparison.OrdinalIgnoreCase) Then
            Return ChrW(&H2713) & " Check in"
        End If
        Return If(status, "")
    End Function

    ''' <summary>Builds a fully sized status pill so its text is never clipped.</summary>
    Private Function CreateStatusPill(status As String, text As String, w As Integer, h As Integer) As FButton
        Dim back As Color
        Dim fore As Color
        Dim hoverBack As Color
        Dim isCheckIn As Boolean = False

        Select Case If(status, "").Trim().ToLowerInvariant()
            Case "confirmed"
                isCheckIn = True
                back = Color.FromArgb(23, 105, 90) : fore = Color.White
                hoverBack = Color.FromArgb(18, 85, 72)
            Case "completed"
                back = Color.FromArgb(230, 245, 235) : fore = Color.FromArgb(40, 135, 75)
                hoverBack = back
            Case "pending"
                back = Color.FromArgb(254, 243, 226) : fore = Color.FromArgb(217, 119, 6)
                hoverBack = back
            Case "cancelled"
                back = Color.FromArgb(253, 236, 235) : fore = Color.FromArgb(205, 80, 75)
                hoverBack = back
            Case Else
                back = Color.FromArgb(243, 246, 248) : fore = Color.FromArgb(120, 140, 150)
                hoverBack = back
        End Select

        Dim btn As New FButton With {
            .Text = text,
            .Size = New Size(w, h),
            .Font = _fStatus,
            .MouseEnterFont = _fStatus,
            .MouseLeaveFont = _fStatus,
            .BorderRadius = h \ 2,
            .BorderSize = 0,
            .TextAlign = ContentAlignment.MiddleCenter,
            .Padding = New Padding(0),
            .Cursor = If(isCheckIn, Cursors.Hand, Cursors.Default)
        }
        btn.BackColor = back
        btn.ForeColor = fore
        btn.BorderColor = back
        btn.MouseEnterBackColor = hoverBack
        btn.MouseEnterForeColor = fore
        btn.MouseLeaveBackColor = back
        btn.MouseLeaveForeColor = fore
        btn.MouseEnterBorderColor = hoverBack
        btn.MouseLeaveBorderColor = back
        Return btn
    End Function

    ''' <summary>Marks a confirmed appointment as arrived (moves it to the waiting queue).</summary>
    Private Sub CheckInAppointment(appt As DashboardAppointment)
        Dim clinicAppt = ClinicData.Appointments.FirstOrDefault(Function(a) a.PatientId = appt.PatientId AndAlso a.Status = "Confirmed")
        If clinicAppt Is Nothing Then Return

        clinicAppt.Status = "Pending"
        clinicAppt.Note = "Checked in at reception (" & DateTime.Now.ToString("h:mm tt") & ")"
        ClinicData.UpdateAppointment(clinicAppt)
        AuditStore.Log(CurrentUser.FullName, CurrentUser.Role, "Patient Check-in", $"{appt.PatientName} arrived and checked in", "Success")
        MessageBox.Show($"{appt.PatientName} has been checked in and added to the waiting queue.", "Check-in Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ShowDashboard()
    End Sub

    Private Sub UpdatePager(pageCount As Integer)
        If lblPageInfo Is Nothing Then Return
        lblPageInfo.Text = $"{_schedulePage + 1} / {pageCount}"
        btnPrevPage.Enabled = _schedulePage > 0
        btnNextPage.Enabled = _schedulePage < pageCount - 1
        Dim showPager As Boolean = pageCount > 1
        btnPrevPage.Visible = showPager
        btnNextPage.Visible = showPager
        lblPageInfo.Visible = showPager
    End Sub

    Private Sub ChangeSchedulePage(delta As Integer)
        Dim newPage As Integer = Math.Max(0, Math.Min(SchedulePageCount() - 1, _schedulePage + delta))
        If newPage <> _schedulePage Then
            _schedulePage = newPage
            BindScheduleRows()
        End If
    End Sub

    ''' <summary>
    ''' Creates the scrollable rows panel inside the "Today's appointments" card and adds a
    ''' &lt; 1 / 2 &gt; pager to the top-right of that card. The card grows to fit a full page.
    ''' </summary>
    Private Sub BuildSchedulePager()
        _scheduleCard = rowDividers(0).Parent
        If _scheduleCard Is Nothing Then Return

        Const btnH As Integer = 26
        Const btnW As Integer = 28

        Dim titleLbl = _scheduleCard.Controls.OfType(Of Label)().
            FirstOrDefault(Function(l) l.Text IsNot Nothing AndAlso l.Text.StartsWith("Today", StringComparison.OrdinalIgnoreCase))

        Dim rowsTop As Integer = If(titleLbl IsNot Nothing,
                                    titleLbl.Bottom + 10,
                                    Math.Max(40, rowTimes(0).Top - 14))

        ' Make the card tall enough for a full page of rows
        Dim needed As Integer = rowsTop + RowsPerPage * ScheduleRowHeight + 14
        If _scheduleCard.Height < needed Then _scheduleCard.Height = needed

        _rowsPanel = New ScrollPanel With {
            .Location = New Point(12, rowsTop),
            .Size = New Size(_scheduleCard.ClientSize.Width - 24, _scheduleCard.ClientSize.Height - rowsTop - 12),
            .AutoScroll = True,
            .BackColor = Color.White,
            .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom
        }
        _scheduleCard.Controls.Add(_rowsPanel)
        lblEmpty.BringToFront()
        AddHandler _rowsPanel.SizeChanged, Sub() BindScheduleRows()

        ' ---- Pager
        Dim topY As Integer = If(titleLbl IsNot Nothing,
                                 titleLbl.Top + (titleLbl.Height - btnH) \ 2,
                                 6)
        Dim rightEdge As Integer = _scheduleCard.ClientSize.Width - 16

        btnPrevPage = CreatePagerButton("<")
        btnNextPage = CreatePagerButton(">")

        lblPageInfo = New Label() With {
            .AutoSize = False,
            .TextAlign = ContentAlignment.MiddleCenter,
            .Size = New Size(60, btnH),
            .Font = New Font("Segoe UI", 9.0F, FontStyle.Regular),
            .ForeColor = ColFeed,
            .BackColor = Color.Transparent,
            .Text = "1 / 1",
            .Anchor = AnchorStyles.Top Or AnchorStyles.Right
        }

        btnNextPage.Location = New Point(rightEdge - btnW, topY)
        lblPageInfo.Location = New Point(btnNextPage.Left - lblPageInfo.Width, topY)
        btnPrevPage.Location = New Point(lblPageInfo.Left - btnW, topY)

        _scheduleCard.Controls.Add(btnPrevPage)
        _scheduleCard.Controls.Add(lblPageInfo)
        _scheduleCard.Controls.Add(btnNextPage)
        btnPrevPage.BringToFront()
        lblPageInfo.BringToFront()
        btnNextPage.BringToFront()

        AddHandler btnPrevPage.Click, Sub() ChangeSchedulePage(-1)
        AddHandler btnNextPage.Click, Sub() ChangeSchedulePage(1)
    End Sub

    Private Function CreatePagerButton(text As String) As Button
        Dim b As New Button() With {
            .Text = text,
            .Size = New Size(28, 26),
            .FlatStyle = FlatStyle.Flat,
            .Cursor = Cursors.Hand,
            .BackColor = Color.White,
            .ForeColor = ColTitle,
            .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold),
            .TextAlign = ContentAlignment.MiddleCenter,
            .Padding = New Padding(0),
            .TabStop = False,
            .UseVisualStyleBackColor = False,
            .Anchor = AnchorStyles.Top Or AnchorStyles.Right
        }
        b.FlatAppearance.BorderColor = Color.FromArgb(205, 215, 220)
        b.FlatAppearance.MouseOverBackColor = Color.FromArgb(230, 245, 241)
        b.FlatAppearance.MouseDownBackColor = Color.FromArgb(214, 238, 232)
        Return b
    End Function

    Private Shared Function HasStatus(a As DashboardAppointment, status As String) As Boolean
        Return String.Equals(a.Status, status, StringComparison.OrdinalIgnoreCase)
    End Function

    Private Function GetGreetingName() As String
        If CurrentUser.IsAuthenticated Then
            Return CurrentUser.FullName
        End If
        ' Fallback
        Dim parts = txtName.Text.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
        Return If(parts.Length >= 2, parts(0) & " " & parts(1), txtName.Text)
    End Function

    ' =====================================================================
    '  Clickable patient names
    ' =====================================================================
    Private Sub PatientLabel_Click(sender As Object, e As EventArgs)
        Dim lbl = DirectCast(sender, Label)
        If lbl.Tag IsNot Nothing Then OnPatientOpened(CStr(lbl.Tag))
    End Sub

    Private Sub PatientLabel_MouseEnter(sender As Object, e As EventArgs)
        DirectCast(sender, Label).ForeColor = ColTeal
    End Sub

    Private Sub PatientLabel_MouseLeave(sender As Object, e As EventArgs)
        Dim lbl = DirectCast(sender, Label)
        lbl.ForeColor = If(recentLabels.Contains(lbl), ColFeed, ColBody)
    End Sub

    ' ---- Opens the patient information page
    Private Sub OnPatientOpened(patientId As String)
        Dim rec As PatientRecord = GetPatients().FirstOrDefault(Function(p) String.Equals(p.PatientId, patientId, StringComparison.OrdinalIgnoreCase))
        If rec IsNot Nothing Then
            patientInfoPanel.LoadPatient(rec)
        Else
            patientInfoPanel.LoadPatient(patientId)
        End If
        ShowPage(patientInfoPanel, btnPatients)   ' keeps "Patients" highlighted in the sidebar
    End Sub

    ' ---- Events raised by the patient information page
    Private Sub OnPatientInfoBack()
        ShowPatientsPage()
    End Sub

    Private Sub OnPatientInfoSchedule(patientId As String)
        appointmentPanel.FocusPatient(patientId)
        appointmentPanel.RefreshData()
        ShowPage(appointmentPanel, btnAppointment)
    End Sub

    ' ---- Consultation navigation handlers
    Private Sub OnConsultationPatientSelected(patientId As String, appointmentId As String)
        Dim info = ConsultationInfo.ForAppointment(appointmentId, patientId)
        consultationDetailPanel.LoadPatient(info)
        consultationDetailPanel.Show()
        ShowPage(consultationDetailPanel, btnConsultation)
    End Sub

    Private Sub OnConsultationDetailBack()
        consultationListPanel.Show()
        ShowPage(consultationListPanel, btnConsultation)
    End Sub

    ' =====================================================================
    '  Register patient
    ' =====================================================================
    ''' <summary>Opens the registration form (from the Patients page or the dashboard quick action).</summary>
    Private Sub OnRegisterPatient(sender As Object, e As EventArgs)
        registerPanel.ResetForm()
        registerPanel.SetNextPatientId(GetNextPatientId())
        ShowPage(registerPanel, btnPatients)   ' keeps "Patients" highlighted in the sidebar
    End Sub

    Private Sub OnRegisterCancelled()
        ShowPatientsPage()
    End Sub

    Private Sub OnPatientRegistered(patient As NewPatientRecord)
        ' Add to shared clinic repository
        Dim fullAddr = String.Join(", ", New String() {patient.Street, patient.Barangay, patient.City, patient.Province}.Where(Function(s) Not String.IsNullOrWhiteSpace(s)))
        PatientRepository.AddPatient(New PatientItem With {
            .PatientId = patient.PatientId,
            .Name = patient.FullName,
            .Age = patient.Age,
            .Gender = patient.Sex,
            .BirthDate = "Born " & patient.DateOfBirth.ToString("MMMM dd, yyyy"),
            .Contact = patient.Phone,
            .Email = patient.Email,
            .Address = fullAddr,
            .KnownConditions = If(patient.MedicalConditions, ""),
            .DrugAllergies = If(patient.DrugAllergies, ""),
            .HasAllergies = Not String.IsNullOrWhiteSpace(patient.DrugAllergies) AndAlso Not patient.DrugAllergies.Equals("None", StringComparison.OrdinalIgnoreCase),
            .RecordUpdated = "Just registered",
            .LastVisitDisplay = "New patient"
        })
        AuditStore.Log("Ana Reyes", "Receptionist", "Patient registered", $"{patient.FullName} registered as {patient.PatientId}", "Success")

        GetPatients().Insert(0, New PatientRecord With {
            .PatientId = patient.PatientId,
            .FullName = patient.FullName,
            .Age = patient.Age,
            .Sex = patient.Sex,
            .Contact = patient.Phone,
            .LastVisit = Nothing
        })
        newlyRegistered += 1

        Dim askBook = MessageBox.Show(
            $"{patient.FullName} was successfully registered as {patient.PatientId}." & vbCrLf & vbCrLf &
            "Would you like to book an appointment for this patient now?",
            "Patient Registered", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If askBook = DialogResult.Yes Then
            appointmentPanel.RefreshData()
            ShowPage(appointmentPanel, btnAppointment)
            Dim dlg As New ReceptionistBookAppointmentDialog(patient.PatientId)
            dlg.ShowDialog(Me)
            appointmentPanel.RefreshData()
        Else
            ShowPatientsPage()
        End If
    End Sub

    ''' <summary>Next ID = highest existing PT-number + 1. Replace with a database query later.</summary>
    Private Function GetNextPatientId() As String
        Dim maxNumber As Integer = 0
        For Each p As PatientRecord In GetPatients()
            If p.PatientId Is Nothing Then Continue For
            Dim digits As String = New String(p.PatientId.Where(Function(ch) Char.IsDigit(ch)).ToArray())
            Dim n As Integer
            If Integer.TryParse(digits, n) AndAlso n > maxNumber Then maxNumber = n
        Next
        Return "PT-" & (maxNumber + 1).ToString(CultureInfo.InvariantCulture)
    End Function

    ' =====================================================================
    '  Data (replace the sample functions with your database queries)
    ' =====================================================================
    Private Function GetTodayAppointments() As List(Of DashboardAppointment)
        Dim d = Date.Today
        Dim appts = ClinicData.Appointments.Where(Function(a) a.MatchesDate(d)).ToList()
        Return appts.Select(Function(a) New DashboardAppointment With {
            .AppointmentTime = d.AddMinutes(a.Minutes),
            .PatientId = a.PatientId,
            .PatientName = a.PatientName,
            .VisitType = a.VisitType,
            .DoctorName = If(String.IsNullOrEmpty(a.DoctorName), "Dr. Elena Cruz", a.DoctorName),
            .Status = a.Status,
            .IsRescheduled = (a.Status = "Cancelled" AndAlso a.Note IsNot Nothing AndAlso a.Note.ToLower().Contains("rescheduled"))
        }).ToList()
    End Function

    ''' <summary>Returns the live patient directory loaded directly from PatientRepository.</summary>
    Private Function GetPatients() As List(Of PatientRecord)
        Return PatientRepository.GetAll().Select(Function(p) New PatientRecord With {
            .PatientId = p.PatientId,
            .FullName = p.Name,
            .Age = p.Age,
            .Sex = p.Gender,
            .Contact = p.Contact,
            .LastVisit = If(p.LastVisitDate <> Date.MinValue, CType(p.LastVisitDate, Date?), Nothing)
        }).ToList()
    End Function

    Private Function GetRecentPatients() As List(Of RecentPatient)
        Return GetPatients().Take(3).Select(Function(p) New RecentPatient With {
            .PatientId = p.PatientId,
            .PatientName = p.FullName
        }).ToList()
    End Function

    Private _isLoggingOut As Boolean = False

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim res = MessageBox.Show("Are you sure you want to log out of the Receptionist portal?", "Confirm Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If res = DialogResult.Yes Then
            AuditStore.Log(CurrentUser.FullName, CurrentUser.Role, "Sign-out", "Receptionist logged out", "Success")
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

    Private Sub ReceptionistDashboard_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.RemoveMessageFilter(Me)
        If Not _isLoggingOut Then
            Application.Exit()
        End If
    End Sub

End Class

''' <summary>One row in today's schedule.</summary>
Public Class DashboardAppointment
    Public Property AppointmentTime As DateTime
    Public Property PatientId As String
    Public Property PatientName As String
    Public Property VisitType As String
    Public Property DoctorName As String
    ''' <summary>Completed | Pending | Confirmed | Cancelled</summary>
    Public Property Status As String
    Public Property IsRescheduled As Boolean
End Class

Public Class RecentPatient
    Public Property PatientId As String
    Public Property PatientName As String
End Class