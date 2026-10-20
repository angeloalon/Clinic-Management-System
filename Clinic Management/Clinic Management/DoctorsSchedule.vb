Imports System.Linq
Imports Ferrando.UI.WinForms.Controles

Public Class DoctorsSchedule

    Private sidebarHandler As SidebarHandler
    Private Const MaxSlots As Integer = 6

    ' Cards Tue..Sat  ->  day of month 22..26
    Private ReadOnly _dayDates As Integer() = {22, 23, 24, 25, 26}
    Private ReadOnly _dayNames As String() = {"Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"}

    Private ReadOnly _times As New List(Of Integer)()      ' minutes, 8:00 AM .. 5:00 PM every 30 min
    Private _dtpDay As DateTimePicker
    Private _cboStart As ComboBox
    Private _cboEnd As ComboBox
    Private _statusAvailable As Boolean = True

    ' Dynamic Week Navigation
    Private _currentWeekMonday As DateTime
    Private btnPrevWeek As FButton
    Private btnToday As FButton
    Private btnNextWeek As FButton
    Private lblWeekRange As Label

    Public Sub New()
        InitializeComponent()

        ' Initialize week to current week's Monday
        Dim today = DateTime.Today
        Dim diff = (7 + (CInt(today.DayOfWeek) - CInt(DayOfWeek.Monday))) Mod 7
        _currentWeekMonday = today.AddDays(-diff).Date

        SetupWeekNavigation()
        SetupAddPanel()
        SetupCalendarView()
        WireSlots()
        RenderSlots()
    End Sub

    Private _calendarView As ClinicCalendarView

    Private Sub SetupCalendarView()
        If _calendarView IsNot Nothing Then Return

        ' Hide legacy fixed 5-day cards
        For d As Integer = 1 To 5
            Dim c = Ctl(Of Control)("cardDay" & d)
            If c IsNot Nothing Then c.Visible = False
        Next

        _calendarView = New ClinicCalendarView With {
            .Location = New Point(28, 86),
            .Size = New Size(mainScreen.ClientSize.Width - 56, mainScreen.ClientSize.Height - 96),
            .Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right,
            .WeekMonday = _currentWeekMonday
        }

        AddHandler _calendarView.EventClicked, Sub(appt)
            Using dlg As New CalendarEventDetailsDialog(appt, allowConsultation:=True)
                dlg.ShowDialog(Me)
            End Using
        End Sub

        AddHandler _calendarView.SlotClicked, Sub(clickedDate, startMins)
            OpenAddAvailabilityDialog(clickedDate, startMins)
        End Sub

        AddHandler _calendarView.AvailabilitySlotClicked, Sub(slot)
            Dim currentDoc = If(CurrentUser.IsAuthenticated, CurrentUser.FullName, "Dr. Elena Cruz")
            Using dlg As New AvailabilitySlotDetailsDialog(slot, currentDoc)
                If dlg.ShowDialog(Me) = DialogResult.OK Then
                    ClinicData.NotifyDataChanged()
                    RenderSlots()
                End If
            End Using
        End Sub

        mainScreen.Controls.Add(_calendarView)
        _calendarView.BringToFront()
        If cardAddAvail IsNot Nothing Then cardAddAvail.Visible = False
    End Sub

    Private Sub SetupWeekNavigation()
        If btnPrevWeek IsNot Nothing Then Return

        Dim fNav As New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnPrevWeek = New FButton With {
            .Text = "‹",
            .Size = New Size(26, 26),
            .Location = New Point(210, 22),
            .Font = fNav,
            .BorderRadius = 4,
            .BorderSize = 0,
            .Cursor = Cursors.Hand
        }
        UIThemeHelper.ApplySecondary(btnPrevWeek)
        AddHandler btnPrevWeek.Click, Sub()
            _currentWeekMonday = _currentWeekMonday.AddDays(-7)
            RenderSlots()
        End Sub
        mainScreen.Controls.Add(btnPrevWeek)

        btnToday = New FButton With {
            .Text = "Today",
            .Size = New Size(50, 26),
            .Location = New Point(btnPrevWeek.Right + 4, 22),
            .Font = New Font("Segoe UI", 7.5F, FontStyle.Bold),
            .BorderRadius = 4,
            .BorderSize = 0,
            .Cursor = Cursors.Hand
        }
        UIThemeHelper.ApplySecondary(btnToday)
        AddHandler btnToday.Click, Sub()
            Dim t = DateTime.Today
            Dim d = (7 + (CInt(t.DayOfWeek) - CInt(DayOfWeek.Monday))) Mod 7
            _currentWeekMonday = t.AddDays(-d).Date
            RenderSlots()
        End Sub
        mainScreen.Controls.Add(btnToday)

        btnNextWeek = New FButton With {
            .Text = "›",
            .Size = New Size(26, 26),
            .Location = New Point(btnToday.Right + 4, 22),
            .Font = fNav,
            .BorderRadius = 4,
            .BorderSize = 0,
            .Cursor = Cursors.Hand
        }
        UIThemeHelper.ApplySecondary(btnNextWeek)
        AddHandler btnNextWeek.Click, Sub()
            _currentWeekMonday = _currentWeekMonday.AddDays(7)
            RenderSlots()
        End Sub
        mainScreen.Controls.Add(btnNextWeek)

        lblWeekRange = New Label With {
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(30, 45, 55),
            .Location = New Point(btnNextWeek.Right + 8, 26),
            .AutoSize = True
        }
        mainScreen.Controls.Add(lblWeekRange)

        Dim tt As New ToolTip()
        tt.SetToolTip(btnPrevWeek, "Previous week")
        tt.SetToolTip(btnToday, "Go to current week")
        tt.SetToolTip(btnNextWeek, "Next week")
        If btnAddAvailability IsNot Nothing Then
            tt.SetToolTip(btnAddAvailability, "Add a new availability block for this week")
        End If
    End Sub

    Private Function Ctl(Of T As Control)(name As String) As T
        Dim found As Control() = Controls.Find(name, True)
        If found.Length = 0 Then Return Nothing
        Return DirectCast(found(0), T)
    End Function

    ' ------------------------------------------------------------------ slots

    Private Sub WireSlots()
        For d As Integer = 1 To 5
            For n As Integer = 1 To MaxSlots
                Dim suffix As String = d & "_" & n
                For Each c As Control In New Control() {Ctl(Of FCard)("cardSlot" & suffix),
                                                        Ctl(Of Label)("lblSlotTime" & suffix),
                                                        Ctl(Of Label)("lblSlotText" & suffix),
                                                        Ctl(Of Label)("lblSlotIcon" & suffix)}
                    AddHandler c.Click, AddressOf Slot_Click
                Next
            Next
        Next
    End Sub

    Public Sub RenderSlots()
        If lblWeekRange IsNot Nothing Then
            lblWeekRange.Text = $"{_currentWeekMonday:MMM dd} – {_currentWeekMonday.AddDays(4):MMM dd, yyyy}"
        End If
        If lblSubtitle IsNot Nothing Then
            lblSubtitle.Text = $"Manage your availability for {_currentWeekMonday:MMMM dd} – {_currentWeekMonday.AddDays(4):dd, yyyy}."
        End If

        Dim currentDoc = If(CurrentUser.IsAuthenticated, CurrentUser.FullName, "Dr. Elena Cruz")
        Dim docShort = If(String.IsNullOrEmpty(currentDoc), "", currentDoc.Replace("Dr.", "").Trim())

        Dim docFilter = Function(docName As String) As Boolean
                            If String.IsNullOrWhiteSpace(docName) Then Return False
                            If docName.Equals(currentDoc, StringComparison.OrdinalIgnoreCase) Then Return True
                            If Not String.IsNullOrEmpty(docShort) AndAlso docName.IndexOf(docShort, StringComparison.OrdinalIgnoreCase) >= 0 Then Return True
                            If currentDoc.IndexOf("Cruz", StringComparison.OrdinalIgnoreCase) >= 0 AndAlso docName.IndexOf("Cruz", StringComparison.OrdinalIgnoreCase) >= 0 Then Return True
                            If currentDoc.IndexOf("Lim", StringComparison.OrdinalIgnoreCase) >= 0 AndAlso docName.IndexOf("Lim", StringComparison.OrdinalIgnoreCase) >= 0 Then Return True
                            Return False
                        End Function

        Dim docSlots = ClinicData.GetSlotsForDoctor(currentDoc, _currentWeekMonday)

        If _calendarView IsNot Nothing Then
            _calendarView.WeekMonday = _currentWeekMonday
            Dim docAppts = ClinicData.Appointments.Where(Function(a) docFilter(a.DoctorName)).ToList()
            _calendarView.SetAppointments(docAppts)
            _calendarView.SetSlots(docSlots)
            Return
        End If

        For d As Integer = 1 To 5
            Dim dayDate = _currentWeekMonday.AddDays(d - 1)
            Dim lblDay = Ctl(Of Label)("lblDay" & d)
            If lblDay IsNot Nothing Then
                lblDay.Text = dayDate.ToString("ddd dd")
            End If

            ' 1. Booked appointments for the logged-in doctor on this specific day
            Dim appts = ClinicData.Appointments.Where(Function(a) a.MatchesDate(dayDate) AndAlso docFilter(a.DoctorName)).ToList()

            Dim list As New List(Of SlotItem)()
            For Each a In appts
                list.Add(New SlotItem With {
                    .Day = dayDate.Day,
                    .Minutes = a.Minutes,
                    .Kind = "Appointment",
                    .PatientName = $"{a.PatientName} • {a.VisitType}"
                })
            Next

            ' 2. User-defined availability slots for this doctor on this day
            Dim availSlots = docSlots.Where(Function(s) s.Day = dayDate.Day OrElse s.MatchesDate(dayDate)).ToList()
            For Each av In availSlots
                If Not list.Any(Function(x) x.Minutes = av.Minutes) Then
                    list.Add(av)
                End If
            Next

            list = list.OrderBy(Function(s) s.Minutes).ToList()

            For n As Integer = 1 To MaxSlots
                If n <= list.Count Then
                    BindSlot(d, n, list(n - 1))
                Else
                    Dim emptySlot = Ctl(Of FCard)("cardSlot" & d & "_" & n)
                    If emptySlot IsNot Nothing Then emptySlot.Visible = False
                End If
            Next
        Next
    End Sub

    Private Sub BindSlot(d As Integer, n As Integer, s As SlotItem)
        Dim suffix As String = d & "_" & n
        Dim card As FCard = Ctl(Of FCard)("cardSlot" & suffix)
        Dim lblT As Label = Ctl(Of Label)("lblSlotTime" & suffix)
        Dim lblX As Label = Ctl(Of Label)("lblSlotText" & suffix)
        Dim lblI As Label = Ctl(Of Label)("lblSlotIcon" & suffix)

        If card Is Nothing OrElse lblT Is Nothing OrElse lblX Is Nothing OrElse lblI Is Nothing Then Return

        Dim bg, bd, tc, nc As Color
        Dim icon As String
        Dim text As String

        Select Case s.Kind
            Case "Available"
                bg = ClinicData.Hx("#E6F5EB") : bd = ClinicData.Hx("#C9E7D3")
                tc = ClinicData.Hx("#28874B") : nc = tc : icon = "↔" : text = "Available"
            Case "Blocked"
                bg = ClinicData.Hx("#FDECEC") : bd = ClinicData.Hx("#F4CCCA")
                tc = ClinicData.Hx("#CD504B") : nc = tc : icon = "↔" : text = "Blocked"
            Case Else   ' Appointment (read-only)
                bg = ClinicData.Hx("#F3F6F8") : bd = ClinicData.Hx("#E8EDF0")
                tc = ClinicData.Hx("#738A94") : nc = ClinicData.Hx("#232D37") : icon = "•" : text = s.PatientName
        End Select

        card.BackColor = bg
        card.BorderColor = bd
        card.BorderHoverColor = bd
        card.HoverTintColor = bg

        lblT.Text = ClinicData.FormatTime(s.Minutes, False)
        lblT.BackColor = bg : lblT.ForeColor = tc
        lblX.Text = text
        lblX.BackColor = bg : lblX.ForeColor = nc
        lblI.Text = icon
        lblI.BackColor = bg
        lblI.ForeColor = If(s.Kind = "Appointment", ClinicData.Hx("#8C9BA5"), tc)

        Dim cur As Cursor = If(s.Kind = "Appointment", Cursors.Default, Cursors.Hand)
        For Each c As Control In New Control() {card, lblT, lblX, lblI}
            c.Cursor = cur
            c.Tag = s
        Next

        card.Visible = True
        card.Invalidate()
    End Sub

    ''' <summary>Clicking an Available/Blocked slot flips it. Appointments are read-only.</summary>
    Private Sub Slot_Click(sender As Object, e As EventArgs)
        Dim s As SlotItem = TryCast(DirectCast(sender, Control).Tag, SlotItem)
        If s Is Nothing OrElse s.Kind = "Appointment" Then Return

        s.Kind = If(s.Kind = "Available", "Blocked", "Available")
        ClinicData.NotifyDataChanged()
        RenderSlots()
    End Sub

    ' ------------------------------------------------------------------ add availability panel

    Private Sub SetupAddPanel()
        For t As Integer = 8 * 60 To 17 * 60 Step 30
            _times.Add(t)
        Next

        lblDayValue.Visible = False
        lblDayArrow.Visible = False
        _dtpDay = New DateTimePicker() With {
            .Format = DateTimePickerFormat.Custom,
            .CustomFormat = "ddd, MMM dd, yyyy",
            .MinDate = DateTime.Today,
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Regular),
            .Location = New Point(4, 4),
            .Width = cardDayBox.Width - 8
        }
        cardDayBox.Controls.Add(_dtpDay)

        _cboStart = MakeCombo(cardStartBox, lblStartValue, lblStartArrow)
        _cboEnd = MakeCombo(cardEndBox, lblEndValue, lblEndArrow)

        For Each t As Integer In _times
            Dim label As String = ClinicData.FormatTime(t)
            _cboStart.Items.Add(label)
            _cboEnd.Items.Add(label)
        Next

        UIThemeHelper.ApplyPrimary(btnSave)
        UIThemeHelper.ApplySecondary(btnCancel)
        UIThemeHelper.ApplyPrimary(btnAddAvailability)

        ResetForm()

        lblAddClose.Cursor = Cursors.Hand
    End Sub

    ' Replaces the static "value + arrow" labels with a real drop-down.
    Private Function MakeCombo(box As FCard, valueLbl As Label, arrowLbl As Label) As ComboBox
        valueLbl.Visible = False
        arrowLbl.Visible = False

        Dim cb As New ComboBox()
        cb.DropDownStyle = ComboBoxStyle.DropDownList
        cb.FlatStyle = FlatStyle.Flat
        cb.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point)
        cb.BackColor = Color.White
        cb.ForeColor = ClinicData.Hx("#1E2D37")
        cb.Location = New Point(4, 3)
        cb.Width = box.Width - 8
        box.Controls.Add(cb)
        Return cb
    End Function

    Private Sub ResetForm()
        If _dtpDay IsNot Nothing AndAlso DateTime.Today >= _dtpDay.MinDate Then
            _dtpDay.Value = DateTime.Today
        End If
        _cboStart.SelectedIndex = _times.IndexOf(16 * 60)   ' 4:00 PM
        _cboEnd.SelectedIndex = _times.IndexOf(17 * 60)     ' 5:00 PM
        chkRepeatWeekly.Checked = False
        SetStatus(True)
    End Sub

    Private Sub SetStatus(isAvailable As Boolean)
        _statusAvailable = isAvailable

        StyleToggle(btnStatusAvailable,
                    If(isAvailable, ClinicData.Hx("#E6F5EB"), ClinicData.Hx("#F3F6F8")),
                    ClinicData.Hx("#28874B"), isAvailable)
        StyleToggle(btnStatusBlocked,
                    If(isAvailable, ClinicData.Hx("#F3F6F8"), ClinicData.Hx("#FDECEC")),
                    ClinicData.Hx("#CD504B"), Not isAvailable)
    End Sub

    Private Shared Sub StyleToggle(btn As FButton, back As Color, fore As Color, selected As Boolean)
        Dim fnt As New Font("Segoe UI", 8.0F, If(selected, FontStyle.Bold, FontStyle.Regular), GraphicsUnit.Point)
        btn.BackColor = back
        btn.ForeColor = fore
        btn.Font = fnt
        btn.MouseEnterBackColor = back
        btn.MouseEnterForeColor = fore
        btn.MouseEnterFont = fnt
        btn.MouseLeaveBackColor = back
        btn.MouseLeaveForeColor = fore
        btn.MouseLeaveFont = fnt
    End Sub

    Private Sub btnStatusAvailable_Click(sender As Object, e As EventArgs) Handles btnStatusAvailable.Click
        SetStatus(True)
    End Sub

    Private Sub btnStatusBlocked_Click(sender As Object, e As EventArgs) Handles btnStatusBlocked.Click
        SetStatus(False)
    End Sub

    Private Sub btnAddAvailability_Click(sender As Object, e As EventArgs) Handles btnAddAvailability.Click
        OpenAddAvailabilityDialog()
    End Sub

    Public Sub OpenAddAvailabilityDialog(Optional preDate As DateTime? = Nothing, Optional preStartMins As Integer? = Nothing)
        Dim currentDoc = If(CurrentUser.IsAuthenticated, CurrentUser.FullName, "Dr. Elena Cruz")
        Dim docRole = If(CurrentUser.IsAuthenticated, If(CurrentUser.Role = "Doctor", "General Physician", CurrentUser.Role), "General Physician")
        Dim initialDate = If(preDate.HasValue, preDate.Value, _currentWeekMonday)
        Dim initialMins = If(preStartMins.HasValue, preStartMins.Value, 9 * 60)

        Using dlg As New DoctorAddAvailabilityDialog(currentDoc, docRole, initialDate, initialMins)
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                Dim targetDate = dlg.SelectedDate
                Dim dDiff = (7 + (CInt(targetDate.DayOfWeek) - CInt(DayOfWeek.Monday))) Mod 7
                _currentWeekMonday = targetDate.AddDays(-dDiff).Date

                ClinicData.NotifyDataChanged()
                RenderSlots()

                Dim dayName As String = targetDate.ToString("dddd")
                MessageBox.Show($"Availability / schedule updated for {dayName}, {targetDate:MMM dd, yyyy}.",
                                "Schedule Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
    End Sub

    Private Sub lblAddClose_Click(sender As Object, e As EventArgs) Handles lblAddClose.Click
        If cardAddAvail IsNot Nothing Then cardAddAvail.Visible = False
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ResetForm()
        If cardAddAvail IsNot Nothing Then cardAddAvail.Visible = False
    End Sub

    ''' <summary>Adds availability window and saves to doctor_availability table.</summary>
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim selectedDate = _dtpDay.Value.Date
        Dim dayNum As Integer = selectedDate.Day
        Dim startMin As Integer = _times(_cboStart.SelectedIndex)
        Dim endMin As Integer = _times(_cboEnd.SelectedIndex)

        If endMin <= startMin Then
            MessageBox.Show("The end time must be after the start time.", "Add availability",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim starts As New List(Of Integer)()
        Dim t As Integer = startMin
        Do While t + 60 <= endMin
            starts.Add(t)
            t += 60
        Loop
        If starts.Count = 0 Then starts.Add(startMin)

        Dim existing As List(Of SlotItem) = ClinicData.Slots.Where(Function(s) s.Day = dayNum).ToList()

        Dim kind As String = If(_statusAvailable, "Available", "Blocked")
        Dim docName = If(CurrentUser.IsAuthenticated, CurrentUser.FullName, "Dr. Elena Cruz")
        Dim isRecurring As Boolean = chkRepeatWeekly.Checked

        Dim conflicts = ClinicData.GetConflictingAppointments(docName, selectedDate, startMin, endMin, isRecurring)
        If conflicts.Count > 0 Then
            Dim conflictMsg = "Cannot set availability / block for this time window because there is already an appointment scheduled:" & Environment.NewLine & Environment.NewLine
            For Each c In conflicts.Take(5)
                conflictMsg &= $"• {c.PatientName} ({c.VisitType}) at {ClinicData.FormatTime(c.Minutes)} [{c.Status}]" & Environment.NewLine
            Next
            If conflicts.Count > 5 Then
                conflictMsg &= $"... and {conflicts.Count - 5} more appointment(s)." & Environment.NewLine
            End If
            conflictMsg &= Environment.NewLine & "Please choose a different time slot or manage the existing appointment first."

            MessageBox.Show(conflictMsg, "Appointment Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 1. Save to doctor_availability table
        SqliteAvailabilityRepository.AddAvailability(New AvailabilityItem With {
            .DoctorName = docName,
            .DoctorRole = "General Physician",
            .AvailableDate = selectedDate.ToString("yyyy-MM-dd"),
            .StartMinutes = startMin,
            .EndMinutes = endMin,
            .Status = kind,
            .IsRecurring = chkRepeatWeekly.Checked,
            .DayOfWeek = CInt(selectedDate.DayOfWeek)
        })

        ' 2. Replace individual 30-min intervals in schedule_slots
        Dim curr = startMin
        Do While curr + 30 <= endMin
            ClinicData.DeleteSlot(docName, selectedDate.ToString("yyyy-MM-dd"), curr)
            ClinicData.AddSlot(New SlotItem With {
                .Day = dayNum,
                .Minutes = curr,
                .DurationMinutes = 30,
                .Kind = kind,
                .DoctorName = docName,
                .SlotDate = selectedDate.ToString("yyyy-MM-dd")
            })
            curr += 30
        Loop

        AuditStore.Log(docName, "Doctor", "Availability updated", $"{selectedDate:MMM dd}: {ClinicData.FormatTime(startMin)} – {ClinicData.FormatTime(endMin)} ({kind})", "Success")

        ' 3. Navigate calendar to the week of the saved date so it is immediately visible
        Dim dDiff = (7 + (CInt(selectedDate.DayOfWeek) - CInt(DayOfWeek.Monday))) Mod 7
        _currentWeekMonday = selectedDate.AddDays(-dDiff).Date

        ClinicData.NotifyDataChanged()
        RenderSlots()
        cardAddAvail.Visible = False

        Dim dayName As String = selectedDate.ToString("dddd")
        isRecurring = chkRepeatWeekly.Checked
        ResetForm()

        If isRecurring Then
            MessageBox.Show($"Recurring weekly availability set for {docName} on every {dayName}.{Environment.NewLine}Clinic scheduling will automatically reserve these hours.",
                            "Recurring Schedule Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show($"Availability updated for {dayName}, {selectedDate:MMM dd, yyyy}.",
                            "Schedule Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub DoctorsSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If CurrentUser.IsAuthenticated Then
            lblAddFor.Text = "For " & CurrentUser.FullName
            txtName.Text = CurrentUser.FullName
            txtRole.Text = If(CurrentUser.Role = "Doctor", "General Physician", CurrentUser.Role)
        End If

        sidebarHandler = New SidebarHandler(btnDashboard, btnPatients, btnAppointment,
                                            btnDoctor, btnConsultation, btnReports)
        sidebarHandler.SetActive(btnDoctor)
        AddHandler ClinicData.DataChanged, AddressOf RenderSlots
    End Sub

    ' ------------------------------------------------------------------ sidebar navigation

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        If DoctorShell.Current IsNot Nothing Then
            DoctorShell.Current.NavigateTo(DoctorTab.Dashboard)
        Else
            Dim f As New DoctorDashboard()
            f.Show()
            Me.Hide()
        End If
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
        If DoctorShell.Current IsNot Nothing Then DoctorShell.Current.NavigateTo(DoctorTab.Schedule)
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

    Private Sub DoctorsSchedule_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If DoctorShell.Current Is Nothing Then
            Application.Exit()
        End If
    End Sub

End Class

' Compatibility alias
Public Class DoctorSchedule
    Inherits DoctorsSchedule
End Class