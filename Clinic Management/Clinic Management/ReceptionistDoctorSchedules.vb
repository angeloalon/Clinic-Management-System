Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports Ferrando.UI.WinForms.Controles

Public Class ReceptionistDoctorSchedules

    ' ------------------------------------------------------------------
    '  Data model
    ' ------------------------------------------------------------------
    Private Enum SlotKind
        Appointment
        Available
        Blocked
    End Enum

    Private Class DoctorInfo
        Public Property Name As String
        Public Property Role As String
    End Class

    Private Class ScheduleSlot
        Public Property DoctorIndex As Integer
        Public Property SlotDate As Date
        Public Property Time As TimeSpan
        Public Property Kind As SlotKind
        Public Property PatientName As String
    End Class

    Private ReadOnly _doctors As New List(Of DoctorInfo)()
    Private pnlDoctorPicker As Panel
    Private lblDoctorLabel As Label
    Private btnPrevDoc As FButton
    Private btnDoctorDropdown As FButton
    Private btnNextDoc As FButton
    Private cmsDoctorPicker As ContextMenuStrip
    Private cardDocBadge As FCard
    Private lblDocRoom As Label

    Private Shared Function GetCurrentWeekMonday() As Date
        Dim today = DateTime.Today
        Dim diff = (7 + (CInt(today.DayOfWeek) - CInt(DayOfWeek.Monday))) Mod 7
        Return today.AddDays(-diff).Date
    End Function

    Private ReadOnly _slots As New List(Of ScheduleSlot)
    Private ReadOnly _seedWeek As New Date(2026, 9, 21)       ' sample data lives in this week (Mon)
    Private _weekStart As Date = GetCurrentWeekMonday()        ' week currently shown (Monday)
    Private Const DayCount As Integer = 5                      ' Mon..Fri
    Private _selected As Integer = 0
    Private ReadOnly _dayCards As New List(Of FCard)
    Private _calendarView As ClinicCalendarView

    Private ReadOnly _btnPrevWeek As New Button()
    Private ReadOnly _btnNextWeek As New Button()

    Private Const SlotStep As Integer = 38
    Private Const SlotHeight As Integer = 28

    ' ------------------------------------------------------------------
    '  Setup
    ' ------------------------------------------------------------------
    Public Sub New()
        InitializeComponent()
        SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        DoubleBuffered = True
    End Sub

    Private Sub ReceptionistDoctorSchedules_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Visible Then
            ResetToCurrentWeek()
        End If
    End Sub

    Public Sub ResetToCurrentWeek()
        _weekStart = GetCurrentWeekMonday()
        If _calendarView IsNot Nothing Then
            _calendarView.WeekMonday = _weekStart
        End If
        RenderWeek()
    End Sub

    Private Sub ReceptionistDoctorSchedules_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblLegendAppt.Visible = False
        lblLegendAvail.Visible = False
        If btnAddAvailability IsNot Nothing Then
            btnAddAvailability.Visible = False
            btnAddAvailability.Enabled = False
        End If

        LoadDoctors()
        BuildDoctorPicker()
        CreateWeekNav()
        SyncSlotsFromClinicData()

        _calendarView = New ClinicCalendarView With {
            .Location = New Point(28, 126),
            .Size = New Size(ClientSize.Width - 56, ClientSize.Height - 138),
            .Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right,
            .WeekMonday = _weekStart
        }
        AddHandler _calendarView.EventClicked, Sub(appt)
            Using dlg As New CalendarEventDetailsDialog(appt, allowConsultation:=False)
                dlg.ShowDialog(Me)
            End Using
        End Sub
        AddHandler _calendarView.AvailabilitySlotClicked, Sub(slot)
            Dim docName = If(_selected >= 0 AndAlso _selected < _doctors.Count, _doctors(_selected).Name, "Doctor")
            Using dlg As New AvailabilitySlotDetailsDialog(slot, docName, allowEdit:=False)
                dlg.ShowDialog(Me)
            End Using
        End Sub
        Controls.Add(_calendarView)
        _calendarView.BringToFront()

        RenderWeek()

        AddHandler ClinicData.DataChanged, Sub()
                                               LoadDoctors()
                                               BuildDoctorPicker()
                                               SyncSlotsFromClinicData()
                                               RenderWeek()
                                           End Sub
    End Sub

    Private Sub LoadDoctors()
        _doctors.Clear()
        Dim staffDocs = StaffStore.Doctors
        For Each d In staffDocs
            If Not String.Equals(d.Status, "Suspended", StringComparison.OrdinalIgnoreCase) Then
                _doctors.Add(New DoctorInfo With {
                    .Name = d.Name,
                    .Role = If(String.IsNullOrEmpty(d.Role) OrElse d.Role = "Doctor", "General Physician", d.Role)
                })
            End If
        Next
        If _doctors.Count = 0 Then
            _doctors.Add(New DoctorInfo With {.Name = "Dr. Elena Cruz", .Role = "General Physician"})
            _doctors.Add(New DoctorInfo With {.Name = "Dr. Marco Lim", .Role = "General Physician"})
        End If
        If _selected >= _doctors.Count Then _selected = 0
    End Sub

    Private Sub BuildDoctorPicker()
        If pnlDoctorPicker Is Nothing Then
            pnlDoctorPicker = New Panel With {
                .Location = New Point(28, 86),
                .Size = New Size(ClientSize.Width - 56, 34),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right,
                .BackColor = Color.Transparent
            }
            Controls.Add(pnlDoctorPicker)
            pnlDoctorPicker.BringToFront()
            If cardDoctor1 IsNot Nothing Then cardDoctor1.Visible = False
            If cardDoctor2 IsNot Nothing Then cardDoctor2.Visible = False

            lblDoctorLabel = New Label With {
                .Text = "Doctor:",
                .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(22, 51, 65),
                .Location = New Point(0, 7),
                .AutoSize = True,
                .BackColor = Color.Transparent
            }
            pnlDoctorPicker.Controls.Add(lblDoctorLabel)

            btnPrevDoc = New FButton With {
                .Text = "‹",
                .Location = New Point(56, 1),
                .Size = New Size(30, 32),
                .Cursor = Cursors.Hand,
                .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
            }
            UIThemeHelper.ApplySecondary(btnPrevDoc)
            AddHandler btnPrevDoc.Click, Sub()
                If _doctors.Count = 0 Then Return
                Dim nextIdx = (_selected - 1 + _doctors.Count) Mod _doctors.Count
                SelectDoctor(nextIdx)
            End Sub
            pnlDoctorPicker.Controls.Add(btnPrevDoc)

            btnDoctorDropdown = New FButton With {
                .Location = New Point(90, 1),
                .Size = New Size(240, 32),
                .Cursor = Cursors.Hand,
                .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
                .TextAlign = ContentAlignment.MiddleLeft,
                .Padding = New Padding(12, 0, 10, 0),
                .BackColor = Color.White,
                .ForeColor = Color.FromArgb(22, 51, 65),
                .BorderColor = Color.FromArgb(210, 222, 228),
                .BorderRadius = 8,
                .BorderSize = 1,
                .MouseEnterBackColor = Color.FromArgb(248, 250, 252),
                .MouseEnterBorderColor = Color.FromArgb(29, 124, 107),
                .MouseEnterForeColor = Color.FromArgb(29, 124, 107),
                .MouseLeaveBackColor = Color.White,
                .MouseLeaveBorderColor = Color.FromArgb(210, 222, 228),
                .MouseLeaveForeColor = Color.FromArgb(22, 51, 65)
            }
            AddHandler btnDoctorDropdown.Click, Sub() ShowDoctorMenu()
            pnlDoctorPicker.Controls.Add(btnDoctorDropdown)

            btnNextDoc = New FButton With {
                .Text = "›",
                .Location = New Point(334, 1),
                .Size = New Size(30, 32),
                .Cursor = Cursors.Hand,
                .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
            }
            UIThemeHelper.ApplySecondary(btnNextDoc)
            AddHandler btnNextDoc.Click, Sub()
                If _doctors.Count = 0 Then Return
                Dim nextIdx = (_selected + 1) Mod _doctors.Count
                SelectDoctor(nextIdx)
            End Sub
            pnlDoctorPicker.Controls.Add(btnNextDoc)

            cardDocBadge = New FCard With {
                .Location = New Point(372, 1),
                .Size = New Size(180, 32),
                .BorderRadius = 8,
                .BorderSize = 0,
                .EnableShadow = False,
                .BackColor = Color.FromArgb(230, 245, 235),
                .Cursor = Cursors.Default
            }

            lblDocRoom = New Label With {
                .Location = New Point(12, 7),
                .AutoSize = True,
                .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(29, 124, 107),
                .BackColor = Color.Transparent
            }
            cardDocBadge.Controls.Add(lblDocRoom)
            pnlDoctorPicker.Controls.Add(cardDocBadge)
        End If

        UpdateDoctorSelectorUi()
    End Sub

    Private Sub ShowDoctorMenu()
        If cmsDoctorPicker Is Nothing Then
            cmsDoctorPicker = New ContextMenuStrip With {
                .RenderMode = ToolStripRenderMode.System,
                .Font = New Font("Segoe UI", 9.0F)
            }
        End If
        cmsDoctorPicker.Items.Clear()
        For i As Integer = 0 To _doctors.Count - 1
            Dim idx = i
            Dim doc = _doctors(i)
            Dim itemText = $"{doc.Name} ({doc.Role})"
            Dim item = cmsDoctorPicker.Items.Add(itemText)
            item.Font = If(i = _selected, New Font("Segoe UI", 9.0F, FontStyle.Bold), New Font("Segoe UI", 9.0F, FontStyle.Regular))
            AddHandler item.Click, Sub() SelectDoctor(idx)
        Next
        cmsDoctorPicker.Show(btnDoctorDropdown, New Point(0, btnDoctorDropdown.Height))
    End Sub

    Private Sub UpdateDoctorSelectorUi()
        If _doctors.Count = 0 Then
            If btnDoctorDropdown IsNot Nothing Then btnDoctorDropdown.Text = "No doctors available"
            If lblDocRoom IsNot Nothing Then lblDocRoom.Text = ""
            Return
        End If

        If _selected < 0 OrElse _selected >= _doctors.Count Then _selected = 0
        Dim doc = _doctors(_selected)

        If btnDoctorDropdown IsNot Nothing Then
            btnDoctorDropdown.Text = $"{doc.Name}   ▾"
        End If

        If lblDocRoom IsNot Nothing Then
            lblDocRoom.Text = $"🩺 {doc.Role}"
        End If
    End Sub

    Private Sub AddSlot(doctor As Integer, dayOffset As Integer, hour As Integer, minute As Integer,
                        kind As SlotKind, Optional patient As String = "")
        _slots.Add(New ScheduleSlot With {
            .DoctorIndex = doctor,
            .SlotDate = _seedWeek.AddDays(dayOffset),
            .Time = New TimeSpan(hour, minute, 0),
            .Kind = kind,
            .PatientName = patient
        })
    End Sub

    Private Sub SyncSlotsFromClinicData()
        _slots.Clear()
        For Each cs In ClinicData.Slots
            Dim dOffset As Integer = cs.Day - 22
            If dOffset >= 0 AndAlso dOffset < DayCount Then
                Dim slotK As SlotKind
                Select Case cs.Kind
                    Case "Available"
                        slotK = SlotKind.Available
                    Case "Blocked"
                        slotK = SlotKind.Blocked
                    Case Else
                        slotK = SlotKind.Appointment
                End Select
                _slots.Add(New ScheduleSlot With {
                    .DoctorIndex = cs.DoctorIndex,
                    .SlotDate = _seedWeek.AddDays(dOffset),
                    .Time = TimeSpan.FromMinutes(cs.Minutes),
                    .Kind = slotK,
                    .PatientName = cs.PatientName
                })
            End If
        Next

        ' Also map real appointments from ClinicData to the respective doctor's schedule slots
        For Each a In ClinicData.Appointments
            Dim apptDate As DateTime
            Dim hasDate As Boolean = False
            If Not String.IsNullOrEmpty(a.AppointmentDate) AndAlso DateTime.TryParse(a.AppointmentDate, apptDate) Then
                hasDate = True
            ElseIf a.Day >= 22 AndAlso a.Day <= 26 Then
                apptDate = _seedWeek.AddDays(a.Day - 22)
                hasDate = True
            End If

            If hasDate Then
                Dim dOffset As Integer = CInt((apptDate.Date - _weekStart.Date).TotalDays)
                If dOffset >= 0 AndAlso dOffset < DayCount Then
                    Dim matchedIdx As Integer = -1
                    For i As Integer = 0 To _doctors.Count - 1
                        Dim doc = _doctors(i)
                        If String.Equals(doc.Name, a.DoctorName, StringComparison.OrdinalIgnoreCase) OrElse
                           (Not String.IsNullOrEmpty(a.DoctorName) AndAlso doc.Name.ToLower().Contains(a.DoctorName.ToLower().Replace("dr. ", "").Trim())) Then
                            matchedIdx = i
                            Exit For
                        End If
                    Next
                    If matchedIdx >= 0 Then
                        _slots.Add(New ScheduleSlot With {
                            .DoctorIndex = matchedIdx,
                            .SlotDate = apptDate.Date,
                            .Time = TimeSpan.FromMinutes(a.Minutes),
                            .Kind = SlotKind.Appointment,
                            .PatientName = a.PatientName
                        })
                    End If
                End If
            End If
        Next
    End Sub

    ' ------------------------------------------------------------------
    '  Week navigation
    ' ------------------------------------------------------------------
    Private Sub CreateWeekNav()
        SetupNavButton(_btnPrevWeek, ChrW(&H2039).ToString(), New Point(582, 22))
        SetupNavButton(_btnNextWeek, ChrW(&H203A).ToString(), New Point(622, 22))
        AddHandler _btnPrevWeek.Click, Sub() ShiftWeek(-7)
        AddHandler _btnNextWeek.Click, Sub() ShiftWeek(7)
        Controls.Add(_btnPrevWeek)
        Controls.Add(_btnNextWeek)

        Dim tt As New ToolTip()
        tt.SetToolTip(_btnPrevWeek, "Previous week")
        tt.SetToolTip(_btnNextWeek, "Next week")
    End Sub

    Private Sub SetupNavButton(btn As Button, text As String, location As Point)
        btn.Text = text
        btn.Location = location
        btn.Size = New Size(34, 34)
        btn.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderColor = Color.FromArgb(232, 237, 240)
        btn.BackColor = Color.White
        btn.ForeColor = Color.FromArgb(30, 45, 55)
        btn.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btn.Cursor = Cursors.Hand
        btn.UseVisualStyleBackColor = False
    End Sub

    Private Sub ShiftWeek(days As Integer)
        _weekStart = _weekStart.AddDays(days)
        RenderWeek()
    End Sub

    ' Number of days since the most recent Tuesday (Tue=0 ... Sat=4, Sun=5, Mon=6)
    Private Shared Function DaysSinceTuesday(d As Date) As Integer
        Return (CInt(d.DayOfWeek) - CInt(DayOfWeek.Tuesday) + 7) Mod 7
    End Function

    Private Sub UpdateSubtitle()
        Dim ci As CultureInfo = CultureInfo.InvariantCulture
        Dim weekFirst As Date = _weekStart
        Dim weekLast As Date = _weekStart.AddDays(DayCount - 1)
        Dim rangeText As String

        If weekFirst.Year <> weekLast.Year Then
            rangeText = weekFirst.ToString("MMMM d, yyyy", ci) & ChrW(&H2013) & weekLast.ToString("MMMM d, yyyy", ci)
        ElseIf weekFirst.Month <> weekLast.Month Then
            rangeText = weekFirst.ToString("MMMM d", ci) & ChrW(&H2013) & weekLast.ToString("MMMM d, yyyy", ci)
        Else
            rangeText = weekFirst.ToString("MMMM d", ci) & ChrW(&H2013) & weekLast.ToString("d, yyyy", ci)
        End If

        lblSubtitle.Text = "View clinic availability for " & rangeText
    End Sub

    ' ------------------------------------------------------------------
    '  Doctor picker
    ' ------------------------------------------------------------------
    Private Sub SelectDoctor(index As Integer)
        If index < 0 OrElse index >= _doctors.Count Then Return
        If index = _selected Then Return
        _selected = index
        UpdateDoctorSelectorUi()
        RenderWeek()
    End Sub

    ' ------------------------------------------------------------------
    '  Week view
    ' ------------------------------------------------------------------
    Private Sub RenderWeek()
        UpdateSubtitle()

        If _selected >= 0 AndAlso _selected < _doctors.Count Then
            Dim docName = _doctors(_selected).Name
            Dim docAppts = ClinicData.Appointments.Where(Function(a) _
                String.IsNullOrEmpty(a.DoctorName) OrElse
                a.DoctorName.Equals(docName, StringComparison.OrdinalIgnoreCase) OrElse
                (docName.Contains("Cruz") AndAlso a.DoctorName.Contains("Cruz")) OrElse
                (docName.Contains("Lim") AndAlso a.DoctorName.Contains("Lim"))).ToList()
            Dim docSlots = ClinicData.GetSlotsForDoctor(docName, _weekStart)

            If _calendarView IsNot Nothing Then
                _calendarView.WeekMonday = _weekStart
                _calendarView.SetAppointments(docAppts)
                _calendarView.SetSlots(docSlots)
            End If
        End If
    End Sub

    ' ------------------------------------------------------------------
    '  Add availability (Disabled in Receptionist View-Only Mode)
    ' ------------------------------------------------------------------
    Private Sub btnAddAvailability_Click(sender As Object, e As EventArgs) Handles btnAddAvailability.Click
        ' Receptionist cannot edit or add availability - panel is strictly view-only
    End Sub

    Private Sub ShowAddAvailabilityDialog(Optional preDate As Date? = Nothing, Optional preMinutes As Integer? = Nothing)
        Dim savedDay As Date = If(preDate.HasValue, preDate.Value, _weekStart)

        Using dlg As New Form With {
            .Text = "Add availability",
            .FormBorderStyle = FormBorderStyle.FixedDialog,
            .StartPosition = FormStartPosition.CenterParent,
            .MaximizeBox = False,
            .MinimizeBox = False,
            .ShowInTaskbar = False,
            .BackColor = Color.White,
            .Font = New Font("Segoe UI", 9.0F),
            .ClientSize = New Size(292, 456)
        }
            Dim lblDoctor As New Label With {.Text = "Doctor", .AutoSize = True, .Location = New Point(20, 14)}
            Dim cboDoctor As New ComboBox With {
                .DropDownStyle = ComboBoxStyle.DropDownList,
                .Location = New Point(20, 34),
                .Width = 252
            }
            For Each d In _doctors
                cboDoctor.Items.Add(d.Name)
            Next
            If _doctors.Count > 0 Then
                cboDoctor.SelectedIndex = Math.Max(0, Math.Min(_selected, _doctors.Count - 1))
            End If

            Dim lblDate As New Label With {.Text = "Date (Monday – Friday)", .AutoSize = True, .Location = New Point(20, 72), .ForeColor = Color.FromArgb(45, 60, 70)}
            Dim cal As New MonthCalendar With {
                .Location = New Point(20, 92),
                .MaxSelectionCount = 1
            }
            cal.SetDate(savedDay)

            Dim lblTime As New Label With {.Text = "Time", .AutoSize = True, .Location = New Point(20, 268)}
            Dim dtp As New DateTimePicker With {
                .Format = DateTimePickerFormat.Custom,
                .CustomFormat = "h:mm tt",
                .ShowUpDown = True,
                .Location = New Point(20, 288),
                .Width = 120,
                .Value = If(preMinutes.HasValue, Date.Today.AddMinutes(preMinutes.Value), Date.Today.AddHours(9))
            }

            Dim lblStatus As New Label With {.Text = "Status", .AutoSize = True, .Location = New Point(20, 326)}
            Dim rbAvail As New RadioButton With {
                .Text = "Available",
                .Checked = True,
                .AutoSize = True,
                .ForeColor = Color.FromArgb(40, 135, 75),
                .Location = New Point(20, 348)
            }
            Dim rbBlocked As New RadioButton With {
                .Text = "Unavailable",
                .AutoSize = True,
                .ForeColor = Color.FromArgb(205, 80, 75),
                .Location = New Point(130, 348)
            }

            Dim btnSave As New Button With {
                .Text = "Save",
                .Size = New Size(120, 34),
                .Location = New Point(20, 404),
                .FlatStyle = FlatStyle.Flat,
                .BackColor = Color.FromArgb(29, 124, 107),
                .ForeColor = Color.White,
                .Cursor = Cursors.Hand
            }
            btnSave.FlatAppearance.BorderSize = 0

            Dim btnCancel As New Button With {
                .Text = "Cancel",
                .Size = New Size(120, 34),
                .Location = New Point(152, 404),
                .FlatStyle = FlatStyle.Flat,
                .BackColor = Color.FromArgb(244, 247, 249),
                .ForeColor = Color.FromArgb(30, 45, 55),
                .Cursor = Cursors.Hand,
                .DialogResult = DialogResult.Cancel
            }
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(232, 237, 240)

            AddHandler btnSave.Click,
                Sub()
                    Dim docIdx As Integer = cboDoctor.SelectedIndex
                    Dim docName = _doctors(docIdx).Name
                    Dim day As Date = cal.SelectionStart.Date
                    Dim t As New TimeSpan(dtp.Value.Hour, dtp.Value.Minute, 0)

                    Dim kindStr As String = If(rbAvail.Checked, "Available", "Blocked")
                    Dim dayNum As Integer = day.Day
                    Dim totalMin As Integer = CInt(t.TotalMinutes)
                    Dim endMin As Integer = totalMin + 60

                    Dim conflicts = ClinicData.GetConflictingAppointments(docName, day, totalMin, endMin, False)
                    If conflicts.Count > 0 Then
                        Dim conflictMsg = "Cannot set availability / block for this time window because there is already an appointment scheduled:" & Environment.NewLine & Environment.NewLine
                        For Each c In conflicts.Take(5)
                            conflictMsg &= $"• {c.PatientName} ({c.VisitType}) at {ClinicData.FormatTime(c.Minutes)} [{c.Status}]" & Environment.NewLine
                        Next
                        If conflicts.Count > 5 Then
                            conflictMsg &= $"... and {conflicts.Count - 5} more appointment(s)." & Environment.NewLine
                        End If
                        conflictMsg &= Environment.NewLine & "Please choose a different time slot or manage the existing appointment first."

                        MessageBox.Show(dlg, conflictMsg, "Appointment Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If

                    ' 1. Save to SQLite doctor_availability table
                    SqliteAvailabilityRepository.AddAvailability(New AvailabilityItem With {
                        .DoctorName = docName,
                        .DoctorRole = _doctors(docIdx).Role,
                        .AvailableDate = day.ToString("yyyy-MM-dd"),
                        .StartMinutes = totalMin,
                        .EndMinutes = totalMin + 60,
                        .Status = kindStr,
                        .IsRecurring = False,
                        .DayOfWeek = CInt(day.DayOfWeek)
                    })

                    ' 2. Save individual 30-min intervals to schedule_slots
                    ClinicData.AddSlot(New SlotItem With {
                        .DoctorIndex = docIdx,
                        .DoctorName = docName,
                        .SlotDate = day.ToString("yyyy-MM-dd"),
                        .Day = dayNum,
                        .Minutes = totalMin,
                        .DurationMinutes = 30,
                        .Kind = kindStr,
                        .PatientName = ""
                    })
                    ClinicData.AddSlot(New SlotItem With {
                        .DoctorIndex = docIdx,
                        .DoctorName = docName,
                        .SlotDate = day.ToString("yyyy-MM-dd"),
                        .Day = dayNum,
                        .Minutes = totalMin + 30,
                        .DurationMinutes = 30,
                        .Kind = kindStr,
                        .PatientName = ""
                    })

                    AuditStore.Log(docName, "Receptionist", "Doctor availability updated", $"{day:MMM dd} at {ClinicData.FormatTime(totalMin)} ({kindStr})", "Success")

                    savedDay = day
                    dlg.DialogResult = DialogResult.OK
                End Sub

            dlg.Controls.AddRange(New Control() {lblDoctor, cboDoctor, lblDate, cal, lblTime, dtp,
                                                 lblStatus, rbAvail, rbBlocked, btnSave, btnCancel})
            dlg.CancelButton = btnCancel

            If dlg.ShowDialog(Me) = DialogResult.OK Then
                _selected = cboDoctor.SelectedIndex
                Dim dDiff = (7 + (CInt(savedDay.DayOfWeek) - CInt(DayOfWeek.Monday))) Mod 7
                _weekStart = savedDay.AddDays(-dDiff).Date
                UpdateDoctorSelectorUi()
                ClinicData.NotifyDataChanged()
                RenderWeek()
            End If
        End Using
    End Sub

End Class

' ----------------------------------------------------------------------
'  Small rounded label used for each time slot
' ----------------------------------------------------------------------
Friend Class SlotLabel
    Inherits Control

    Public Property FillColor As Color = Color.FromArgb(245, 248, 249)

    Public Sub New()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or
                 ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw, True)
        Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        e.Graphics.Clear(If(Parent IsNot Nothing, Parent.BackColor, Color.White))
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Using path As GraphicsPath = RoundRect(New Rectangle(0, 0, Width - 1, Height - 1), 6)
            Using b As New SolidBrush(FillColor)
                e.Graphics.FillPath(b, path)
            End Using
        End Using

        TextRenderer.DrawText(e.Graphics, Text, Font,
                              New Rectangle(10, 0, Width - 14, Height), ForeColor,
                              TextFormatFlags.VerticalCenter Or TextFormatFlags.Left Or
                              TextFormatFlags.EndEllipsis Or TextFormatFlags.NoPadding)
    End Sub

    Private Shared Function RoundRect(r As Rectangle, radius As Integer) As GraphicsPath
        Dim d As Integer = radius * 2
        Dim p As New GraphicsPath()
        p.AddArc(r.X, r.Y, d, d, 180, 90)
        p.AddArc(r.Right - d, r.Y, d, d, 270, 90)
        p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90)
        p.AddArc(r.X, r.Bottom - d, d, d, 90, 90)
        p.CloseFigure()
        Return p
    End Function
End Class