Imports System.Linq
Imports Ferrando.UI.WinForms.Controles

Public Class DoctorDashboard
    Private sidebarHandler As SidebarHandler
    Private btnAccessRequestsBadge As FButton
    Private lblEmptyAppts As Label

    Private Sub DoctorDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sidebarHandler = New SidebarHandler(btnDashboard, btnPatients, btnAppointment,
                                            btnDoctor, btnConsultation, btnReports)

        sidebarHandler.SetActive(btnDashboard)   ' start on Dashboard

        ' Set interactive cursors
        lblRow1Patient.Cursor = Cursors.Hand
        lblRow2Patient.Cursor = Cursors.Hand
        lblRow3Patient.Cursor = Cursors.Hand
        btnBadgeCompleted.Cursor = Cursors.Hand
        btnBadgePending1.Cursor = Cursors.Hand
        btnBadgePending2.Cursor = Cursors.Hand
        lblRecent1.Cursor = Cursors.Hand
        lblRecent2.Cursor = Cursors.Hand
        lblRecent3.Cursor = Cursors.Hand

        ' Top-right access requests badge
        btnAccessRequestsBadge = New FButton With {
            .Location = New Point(mainScreen.Width - 235, 20),
            .Size = New Size(215, 34),
            .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
            .Cursor = Cursors.Hand,
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        }
        AddHandler btnAccessRequestsBadge.Click, Sub()
            Using dlg As New ConsultationAccessReviewDialog()
                dlg.ShowDialog(Me)
                RefreshDashboard()
            End Using
        End Sub
        mainScreen.Controls.Add(btnAccessRequestsBadge)
        btnAccessRequestsBadge.BringToFront()

        cardQuickActions.Height = 96
        cardRecentPatients.Location = New Point(562, 318)

        sideBar.Dock = DockStyle.Left
        mainScreen.Dock = DockStyle.Fill
        cardApptsList.Anchor = AnchorStyles.Top Or AnchorStyles.Left
        ApplyResponsiveLayout()

        ' Subscribe to reactive updates from Receptionist check-in / booking
        AddHandler ClinicData.DataChanged, AddressOf RefreshDashboard

        If CurrentUser.IsAuthenticated Then
            lblGreeting.Text = $"Good day, {CurrentUser.FullName}"
            txtName.Text = CurrentUser.FullName
            txtRole.Text = CurrentUser.RoleDisplay
        End If

        RefreshDashboard()
    End Sub

    ' Re-lays out the dashboard whenever the main area (or sidebar) changes size, e.g. on maximize
    Private Sub ApplyResponsiveLayout() Handles mainScreen.Resize, sideBar.Resize
        If mainScreen.ClientSize.Width < 300 Then Return   ' minimized / not ready

        Const margin As Integer = 28
        Const gap As Integer = 14

        ' Sidebar: keep the user card pinned to the bottom
        namePlaceHolder.Top = Math.Max(sideBar.Height - namePlaceHolder.Height - 24, btnReports.Bottom + 10)

        ' KPI cards: 4 equal columns
        Dim avail As Integer = mainScreen.ClientSize.Width - margin * 2
        Dim kpiW As Integer = (avail - gap * 3) \ 4
        Dim kpis = {cardTodayAppts, cardWaitingNow, cardCompleted, cardCancelled}
        For i As Integer = 0 To 3
            kpis(i).SetBounds(margin + i * (kpiW + gap), 86, kpiW, 104)
        Next

        ' Lower section: appointments list (left) + quick actions / recent patients (right)
        Dim rightW As Integer = Math.Max(240, CInt(avail * 0.3))
        Dim leftW As Integer = avail - rightW - gap
        Dim rightX As Integer = margin + leftW + gap

        cardApptsList.SetBounds(margin, 206, leftW, 260)
        cardQuickActions.SetBounds(rightX, 206, rightW, 126)
        cardRecentPatients.SetBounds(rightX, 344, rightW, 132)
        btnOpenConsultation.Width = cardQuickActions.Width - 32

        ' Appointment rows: columns scale with the card width
        Dim w As Integer = cardApptsList.Width
        Dim types = {lblRow1Type, lblRow2Type, lblRow3Type}
        Dim patients = {lblRow1Patient, lblRow2Patient, lblRow3Patient}
        Dim docs = {lblRow1Doctor, lblRow2Doctor, lblRow3Doctor}
        Dim badges = {btnBadgeCompleted, btnBadgePending1, btnBadgePending2}

        For i As Integer = 0 To 2
            patients(i).Left = CInt(w * 0.24)
            types(i).Left = CInt(w * 0.43)
            docs(i).Left = CInt(w * 0.62)
            badges(i).Left = w - 20 - badges(i).Width
        Next

        lineDivider1.Width = w - 40
        lineDivider2.Width = w - 40
    End Sub

    Private Sub DoctorDashboard_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then
            RefreshDashboard()
        End If
    End Sub

    Public Sub RefreshDashboard()
        Dim currentDoc = If(CurrentUser.IsAuthenticated, CurrentUser.FullName, "Dr. Elena Cruz")
        Dim docShort = If(String.IsNullOrEmpty(currentDoc), "", currentDoc.Replace("Dr.", "").Trim())

        Dim docFilter = Function(dName As String) As Boolean
                            If String.IsNullOrWhiteSpace(dName) Then Return False
                            If dName.Equals(currentDoc, StringComparison.OrdinalIgnoreCase) Then Return True
                            If Not String.IsNullOrEmpty(docShort) AndAlso dName.IndexOf(docShort, StringComparison.OrdinalIgnoreCase) >= 0 Then Return True
                            If currentDoc.IndexOf("Cruz", StringComparison.OrdinalIgnoreCase) >= 0 AndAlso dName.IndexOf("Cruz", StringComparison.OrdinalIgnoreCase) >= 0 Then Return True
                            If currentDoc.IndexOf("Lim", StringComparison.OrdinalIgnoreCase) >= 0 AndAlso dName.IndexOf("Lim", StringComparison.OrdinalIgnoreCase) >= 0 Then Return True
                            Return False
                        End Function

        Dim todayAppts = ClinicData.Appointments.Where(Function(a) a.MatchesDate(DateTime.Today) AndAlso docFilter(a.DoctorName)).OrderBy(Function(a) a.Minutes).ToList()

        Dim totalCount = todayAppts.Count
        Dim completedCount = todayAppts.Where(Function(a) a.Status = "Completed").Count()
        Dim pendingCount = todayAppts.Where(Function(a) a.Status = "Pending").Count()
        Dim cancelledCount = todayAppts.Where(Function(a) a.Status = "Cancelled").Count()

        ' Subtitle date
        lblSubtitle.Text = $"{DateTime.Today:dddd, MMMM d} • Clinic operations at a glance"

        ' Update KPI cards
        lblCard1Value.Text = totalCount.ToString()
        lblCard1Sub.Text = $"{completedCount} done • {pendingCount} waiting"

        lblCard2Value.Text = pendingCount.ToString()
        lblCard2Sub.Text = If(pendingCount = 1, "1 in waiting room", $"{pendingCount} in waiting room")

        lblCard3Value.Text = completedCount.ToString()
        lblCard3Sub.Text = If(totalCount > 0, $"{CInt(Math.Round(completedCount * 100.0 / totalCount))}% of total", "0% of total")

        lblCard4Value.Text = cancelledCount.ToString()
        lblCard4Sub.Text = If(cancelledCount = 1, "1 cancellation", $"{cancelledCount} cancellations")

        ' Update schedule list rows (hides rows that have no appointment)
        BindDashboardRows(todayAppts)

        ' Quick actions: Update open consultation button state
        Dim nextPending = todayAppts.FirstOrDefault(Function(a) a.Status = "Pending")
        If nextPending IsNot Nothing Then
            btnOpenConsultation.Text = "Open consultation"
            btnOpenConsultation.Enabled = True
            btnOpenConsultation.Tag = nextPending
            btnOpenConsultation.BackColor = Color.White
            btnOpenConsultation.ForeColor = ClinicData.Hx("#1B3644")
            btnOpenConsultation.BorderColor = ClinicData.Hx("#D2DEE4")
        Else
            btnOpenConsultation.Text = "No open consultations"
            btnOpenConsultation.Enabled = False
            btnOpenConsultation.Tag = Nothing
            btnOpenConsultation.BackColor = ClinicData.Hx("#F3F6F8")
            btnOpenConsultation.ForeColor = ClinicData.Hx("#8FA3AF")
            btnOpenConsultation.BorderColor = ClinicData.Hx("#E2E8EC")
        End If

        ' Populate recent patients card dynamically from database
        Dim docPatients = PatientRepository.GetPatientsForDoctor(currentDoc)
        Dim recentLabels = {lblRecent1, lblRecent2, lblRecent3}
        For i As Integer = 0 To 2
            If i < docPatients.Count Then
                Dim pat = docPatients(i)
                recentLabels(i).Text = $"{pat.Name}   {pat.PatientId}"
                recentLabels(i).Tag = pat.PatientId
                recentLabels(i).Visible = True
                recentLabels(i).Cursor = Cursors.Hand
                recentLabels(i).ForeColor = Color.FromArgb(45, 60, 70)
            ElseIf i = 0 AndAlso docPatients.Count = 0 Then
                recentLabels(i).Text = "No recent patients"
                recentLabels(i).Tag = Nothing
                recentLabels(i).Visible = True
                recentLabels(i).Cursor = Cursors.Default
                recentLabels(i).ForeColor = Color.FromArgb(140, 155, 165)
            Else
                recentLabels(i).Visible = False
                recentLabels(i).Tag = Nothing
            End If
        Next

        ' Update consultation record access request notification
        Dim docName = If(CurrentUser.IsAuthenticated, CurrentUser.FullName, "")
        Dim pendingReqCount = SqliteConsultationAccessRepository.GetPendingCountForDoctor(docName)

        If btnAccessRequestsBadge IsNot Nothing Then
            If pendingReqCount > 0 Then
                btnAccessRequestsBadge.Text = $"🔔 {pendingReqCount} Record Request" & If(pendingReqCount > 1, "s", "") & " Pending"
                btnAccessRequestsBadge.BackColor = Color.FromArgb(254, 243, 226)
                btnAccessRequestsBadge.ForeColor = Color.FromArgb(180, 83, 9)
                btnAccessRequestsBadge.BorderColor = Color.FromArgb(245, 158, 11)
                btnAccessRequestsBadge.BorderSize = 1
                btnAccessRequestsBadge.BorderRadius = 8
                btnAccessRequestsBadge.MouseLeaveBackColor = Color.FromArgb(254, 243, 226)
                btnAccessRequestsBadge.MouseLeaveForeColor = Color.FromArgb(180, 83, 9)
                btnAccessRequestsBadge.MouseLeaveBorderColor = Color.FromArgb(245, 158, 11)
                btnAccessRequestsBadge.MouseLeaveBorderSize = 1
                btnAccessRequestsBadge.MouseEnterBackColor = Color.FromArgb(254, 235, 200)
                btnAccessRequestsBadge.MouseEnterForeColor = Color.FromArgb(146, 64, 14)
                btnAccessRequestsBadge.MouseEnterBorderColor = Color.FromArgb(217, 119, 6)
                btnAccessRequestsBadge.MouseEnterBorderSize = 1
            Else
                btnAccessRequestsBadge.Text = "Review Record Requests"
                UIThemeHelper.ApplySecondary(btnAccessRequestsBadge)
            End If
            btnAccessRequestsBadge.Invalidate()
        End If
    End Sub

    Private Sub BindDashboardRows(appts As List(Of AppointmentItem))
        Dim times = {lblRow1Time, lblRow2Time, lblRow3Time}
        Dim patients = {lblRow1Patient, lblRow2Patient, lblRow3Patient}
        Dim types = {lblRow1Type, lblRow2Type, lblRow3Type}
        Dim docs = {lblRow1Doctor, lblRow2Doctor, lblRow3Doctor}
        Dim badges = {btnBadgeCompleted, btnBadgePending1, btnBadgePending2}

        If lblEmptyAppts Is Nothing Then
            lblEmptyAppts = New Label With {
                .Text = "No appointments scheduled for today.",
                .Font = New Font("Segoe UI", 9.5F, FontStyle.Regular),
                .ForeColor = Color.FromArgb(140, 155, 165),
                .TextAlign = ContentAlignment.MiddleCenter,
                .Size = New Size(cardApptsList.Width - 32, 60),
                .Location = New Point(16, 90),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right,
                .Visible = False
            }
            cardApptsList.Controls.Add(lblEmptyAppts)
        End If
        lblEmptyAppts.Visible = (appts.Count = 0)

        For i As Integer = 0 To 2
            Dim hasData As Boolean = i < appts.Count
            Dim parts As Control() = {times(i), patients(i), types(i), docs(i), badges(i)}
            For Each c In parts
                c.Visible = hasData
            Next
            If hasData Then
                BindDashboardRow(appts(i), times(i), patients(i), types(i), docs(i), badges(i))
            End If
        Next

        lineDivider1.Visible = appts.Count > 1
        lineDivider2.Visible = appts.Count > 2
    End Sub

    Private Sub BindDashboardRow(appt As AppointmentItem, timeLbl As Label, patientLbl As Label, typeLbl As Label, docLbl As Label, badgeBtn As FButton)
        timeLbl.Text = ClinicData.FormatTime(appt.Minutes)
        patientLbl.Text = appt.PatientName
        patientLbl.Tag = appt
        typeLbl.Text = appt.VisitType
        docLbl.Text = If(Not String.IsNullOrEmpty(appt.DoctorName), appt.DoctorName, "Dr. Cruz")

        badgeBtn.Tag = appt
        badgeBtn.Text = appt.Status

        Dim bg, fg As Color
        If appt.Status = "Completed" Then
            bg = ClinicData.Hx("#E6F5EB")
            fg = ClinicData.Hx("#28874B")
        ElseIf appt.Status = "Pending" Then
            bg = ClinicData.Hx("#FEF3E2")
            fg = ClinicData.Hx("#D97706")
        Else
            bg = ClinicData.Hx("#EEF2F4")
            fg = ClinicData.Hx("#4B5F69")
        End If

        badgeBtn.BackColor = bg
        badgeBtn.ForeColor = fg
        badgeBtn.BorderColor = bg
        badgeBtn.MouseEnterBackColor = bg
        badgeBtn.MouseEnterForeColor = fg
        badgeBtn.MouseLeaveBackColor = bg
        badgeBtn.MouseLeaveForeColor = fg
    End Sub

    ' ------------------------------------------------------------------ quick actions

    Private Sub btnScheduleAppt_Click(sender As Object, e As EventArgs) Handles btnScheduleAppt.Click
        If DoctorShell.Current IsNot Nothing Then
            DoctorShell.Current.NavigateTo(DoctorTab.Appointments)
        Else
            Dim f As New DoctorAppointment()
            f.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub btnOpenConsultation_Click(sender As Object, e As EventArgs) Handles btnOpenConsultation.Click
        Dim appt = TryCast(btnOpenConsultation.Tag, AppointmentItem)
        If appt Is Nothing Then
            appt = ClinicData.NextPending()
        End If

        If appt IsNot Nothing Then
            If DoctorShell.Current IsNot Nothing Then
                DoctorShell.Current.OpenConsultation(appt)
            Else
                Dim f As New DoctorConsultation(appt)
                f.Show()
                Me.Hide()
            End If
        Else
            MessageBox.Show("There are no pending consultations to open.", "Consultation", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub RowItem_Click(sender As Object, e As EventArgs) Handles lblRow1Patient.Click, btnBadgeCompleted.Click,
                                                                        lblRow2Patient.Click, btnBadgePending1.Click,
                                                                        lblRow3Patient.Click, btnBadgePending2.Click
        Dim appt = TryCast(DirectCast(sender, Control).Tag, AppointmentItem)
        If appt Is Nothing Then Return

        If appt.Status = "Pending" Then
            If DoctorShell.Current IsNot Nothing Then
                DoctorShell.Current.OpenConsultation(appt)
            Else
                Dim f As New DoctorConsultation(appt)
                f.Show()
                Me.Hide()
            End If
        Else
            If DoctorShell.Current IsNot Nothing Then
                DoctorShell.Current.OpenPatient(appt.PatientId)
            Else
                Dim f As New DoctorPatientInformation(appt.PatientId)
                f.Show()
                Me.Hide()
            End If
        End If
    End Sub

    Private Sub RecentPatient_Click(sender As Object, e As EventArgs) Handles lblRecent1.Click, lblRecent2.Click, lblRecent3.Click
        Dim patId = TryCast(DirectCast(sender, Control).Tag, String)
        If String.IsNullOrWhiteSpace(patId) Then Return

        If DoctorShell.Current IsNot Nothing Then
            DoctorShell.Current.OpenPatient(patId)
        Else
            Dim f As New DoctorPatientInformation(patId)
            f.Show()
            Me.Hide()
        End If
    End Sub

    ' ------------------------------------------------------------------ sidebar navigation

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        If DoctorShell.Current IsNot Nothing Then DoctorShell.Current.NavigateTo(DoctorTab.Dashboard)
    End Sub

    Private Sub btnPatients_Click(sender As Object, e As EventArgs) Handles btnPatients.Click
        If DoctorShell.Current IsNot Nothing Then
            DoctorShell.Current.NavigateTo(DoctorTab.Patients)
        Else
            Dim f As New DoctorPatients()
            f.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub btnAppointment_Click(sender As Object, e As EventArgs) Handles btnAppointment.Click
        If DoctorShell.Current IsNot Nothing Then
            DoctorShell.Current.NavigateTo(DoctorTab.Appointments)
        Else
            Dim f As New DoctorAppointment()
            f.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub btnDoctor_Click(sender As Object, e As EventArgs) Handles btnDoctor.Click
        If DoctorShell.Current IsNot Nothing Then
            DoctorShell.Current.NavigateTo(DoctorTab.Schedule)
        Else
            Dim f As New DoctorSchedule()
            f.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub btnConsultation_Click(sender As Object, e As EventArgs) Handles btnConsultation.Click
        If DoctorShell.Current IsNot Nothing Then
            DoctorShell.Current.NavigateTo(DoctorTab.Consultation)
        Else
            Dim f As New DoctorConsultation()
            f.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        If DoctorShell.Current IsNot Nothing Then
            DoctorShell.Current.NavigateTo(DoctorTab.Reports)
        Else
            Dim f As New DoctorReports()
            f.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub DoctorDashboard_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If DoctorShell.Current Is Nothing Then
            Application.Exit()
        End If
    End Sub

End Class
