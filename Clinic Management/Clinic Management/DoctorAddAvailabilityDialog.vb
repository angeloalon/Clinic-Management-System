Imports System.Drawing
Imports System.Windows.Forms
Imports Ferrando.UI.WinForms.Controles

Public Class DoctorAddAvailabilityDialog
    Inherits Form

    Private ReadOnly _doctorName As String
    Private ReadOnly _doctorRole As String
    Private ReadOnly _initialDate As DateTime
    Private ReadOnly _initialMinutes As Integer

    Public Property SelectedDate As DateTime

    Private _dtpDate As DateTimePicker
    Private _cboStart As ComboBox
    Private _cboEnd As ComboBox
    Private _btnAvail As FButton
    Private _btnBlocked As FButton
    Private _chkRepeat As CheckBox
    Private _isAvailable As Boolean = True

    Private ReadOnly _times As New List(Of Integer)()

    Public Sub New(doctorName As String, Optional doctorRole As String = "General Physician", Optional initialDate As DateTime? = Nothing, Optional initialMinutes As Integer? = Nothing)
        _doctorName = If(Not String.IsNullOrEmpty(doctorName), doctorName, "Dr. Elena Cruz")
        _doctorRole = If(Not String.IsNullOrEmpty(doctorRole), doctorRole, "General Physician")
        _initialDate = If(initialDate.HasValue, initialDate.Value.Date, DateTime.Today)
        _initialMinutes = If(initialMinutes.HasValue, initialMinutes.Value, 9 * 60)
        SelectedDate = _initialDate

        ' Pre-populate times: 8:00 AM to 6:00 PM every 30 mins
        For t As Integer = 8 * 60 To 18 * 60 Step 30
            _times.Add(t)
        Next

        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.Text = "Add availability"
        Me.Size = New Size(260, 320)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.ShowInTaskbar = False
        Me.BackColor = Color.FromArgb(244, 247, 249)
        Me.Font = New Font("Segoe UI", 9.0F)

        Dim card As New FCard With {
            .Location = New Point(12, 10),
            .Size = New Size(222, 264),
            .BackColor = Color.White,
            .BorderColor = Color.FromArgb(232, 237, 240),
            .BorderRadius = 12,
            .BorderSize = 1,
            .EnableShadow = True,
            .ShadowDepth = 4,
            .HoverTintColor = Color.White
        }

        ' Header: Title & Close
        Dim lblTitle As New Label With {
            .Text = "Add availability",
            .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(30, 45, 55),
            .Location = New Point(16, 12),
            .AutoSize = True
        }
        card.Controls.Add(lblTitle)

        Dim lblClose As New Label With {
            .Text = "×",
            .Font = New Font("Segoe UI", 10.5F, FontStyle.Regular),
            .ForeColor = Color.FromArgb(140, 155, 165),
            .Location = New Point(194, 10),
            .Size = New Size(16, 16),
            .Cursor = Cursors.Hand
        }
        AddHandler lblClose.MouseEnter, Sub() lblClose.ForeColor = Color.FromArgb(30, 45, 55)
        AddHandler lblClose.MouseLeave, Sub() lblClose.ForeColor = Color.FromArgb(140, 155, 165)
        AddHandler lblClose.Click, Sub()
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End Sub
        card.Controls.Add(lblClose)

        ' Doctor Subtitle
        Dim lblFor As New Label With {
            .Text = $"For {_doctorName}",
            .Font = New Font("Segoe UI", 7.5F, FontStyle.Regular),
            .ForeColor = Color.FromArgb(140, 155, 165),
            .Location = New Point(16, 30),
            .AutoSize = True
        }
        card.Controls.Add(lblFor)

        ' Day Label
        Dim lblDay As New Label With {
            .Text = "Day",
            .Font = New Font("Segoe UI", 7.5F, FontStyle.Regular),
            .ForeColor = Color.FromArgb(115, 135, 145),
            .Location = New Point(16, 48),
            .AutoSize = True
        }
        card.Controls.Add(lblDay)

        ' Day Picker Box
        Dim cardDayBox As New FCard With {
            .Location = New Point(16, 63),
            .Size = New Size(186, 28),
            .BackColor = Color.White,
            .BorderColor = Color.FromArgb(220, 228, 232),
            .BorderHoverColor = Color.FromArgb(35, 137, 120),
            .BorderRadius = 8,
            .BorderSize = 1,
            .EnableShadow = False
        }

        _dtpDate = New DateTimePicker With {
            .Format = DateTimePickerFormat.Custom,
            .CustomFormat = "ddd, MMM dd, yyyy",
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Regular),
            .Location = New Point(4, 4),
            .Width = cardDayBox.Width - 8,
            .Value = _initialDate
        }
        cardDayBox.Controls.Add(_dtpDate)
        card.Controls.Add(cardDayBox)

        ' Start Time Label
        Dim lblStart As New Label With {
            .Text = "Start time",
            .Font = New Font("Segoe UI", 7.5F, FontStyle.Regular),
            .ForeColor = Color.FromArgb(115, 135, 145),
            .Location = New Point(16, 98),
            .AutoSize = True
        }
        card.Controls.Add(lblStart)

        ' End Time Label
        Dim lblEnd As New Label With {
            .Text = "End time",
            .Font = New Font("Segoe UI", 7.5F, FontStyle.Regular),
            .ForeColor = Color.FromArgb(115, 135, 145),
            .Location = New Point(114, 98),
            .AutoSize = True
        }
        card.Controls.Add(lblEnd)

        ' Start Box & Combo
        Dim cardStartBox As New FCard With {
            .Location = New Point(16, 115),
            .Size = New Size(88, 28),
            .BackColor = Color.White,
            .BorderColor = Color.FromArgb(220, 228, 232),
            .BorderHoverColor = Color.FromArgb(35, 137, 120),
            .BorderRadius = 8,
            .BorderSize = 1,
            .EnableShadow = False
        }
        _cboStart = New ComboBox With {
            .DropDownStyle = ComboBoxStyle.DropDownList,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI", 8.0F, FontStyle.Regular),
            .BackColor = Color.White,
            .ForeColor = Color.FromArgb(30, 45, 55),
            .Location = New Point(4, 3),
            .Width = cardStartBox.Width - 8
        }
        cardStartBox.Controls.Add(_cboStart)
        card.Controls.Add(cardStartBox)

        ' End Box & Combo
        Dim cardEndBox As New FCard With {
            .Location = New Point(114, 115),
            .Size = New Size(88, 28),
            .BackColor = Color.White,
            .BorderColor = Color.FromArgb(220, 228, 232),
            .BorderHoverColor = Color.FromArgb(35, 137, 120),
            .BorderRadius = 8,
            .BorderSize = 1,
            .EnableShadow = False
        }
        _cboEnd = New ComboBox With {
            .DropDownStyle = ComboBoxStyle.DropDownList,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI", 8.0F, FontStyle.Regular),
            .BackColor = Color.White,
            .ForeColor = Color.FromArgb(30, 45, 55),
            .Location = New Point(4, 3),
            .Width = cardEndBox.Width - 8
        }
        cardEndBox.Controls.Add(_cboEnd)
        card.Controls.Add(cardEndBox)

        For Each t In _times
            Dim label = ClinicData.FormatTime(t)
            _cboStart.Items.Add(label)
            _cboEnd.Items.Add(label)
        Next

        Dim startIdx = _times.IndexOf(_initialMinutes)
        If startIdx < 0 Then startIdx = _times.IndexOf(9 * 60)
        If startIdx < 0 Then startIdx = 0
        _cboStart.SelectedIndex = startIdx

        Dim endIdx = _times.IndexOf(_initialMinutes + 60)
        If endIdx < 0 OrElse endIdx <= startIdx Then endIdx = Math.Min(_times.Count - 1, startIdx + 2)
        _cboEnd.SelectedIndex = endIdx

        ' Status Label
        Dim lblStatus As New Label With {
            .Text = "Status",
            .Font = New Font("Segoe UI", 7.5F, FontStyle.Regular),
            .ForeColor = Color.FromArgb(115, 135, 145),
            .Location = New Point(16, 150),
            .AutoSize = True
        }
        card.Controls.Add(lblStatus)

        ' Status Track Panel
        Dim cardStatusTrack As New FCard With {
            .Location = New Point(16, 166),
            .Size = New Size(186, 28),
            .BackColor = Color.FromArgb(243, 246, 248),
            .BorderColor = Color.FromArgb(235, 240, 243),
            .BorderRadius = 8,
            .BorderSize = 1,
            .EnableShadow = False
        }

        _btnAvail = New FButton With {
            .Text = "Available",
            .Size = New Size(90, 24),
            .Location = New Point(2, 2),
            .BorderRadius = 6,
            .BorderSize = 0,
            .Cursor = Cursors.Hand,
            .FlatStyle = FlatStyle.Flat
        }
        AddHandler _btnAvail.Click, Sub() SetStatus(True)
        AddHandler _btnAvail.MouseEnter, Sub()
            _btnAvail.BackColor = _btnAvail.MouseEnterBackColor
            _btnAvail.ForeColor = _btnAvail.MouseEnterForeColor
            _btnAvail.Invalidate()
        End Sub
        AddHandler _btnAvail.MouseLeave, Sub()
            _btnAvail.BackColor = _btnAvail.MouseLeaveBackColor
            _btnAvail.ForeColor = _btnAvail.MouseLeaveForeColor
            _btnAvail.Invalidate()
        End Sub
        cardStatusTrack.Controls.Add(_btnAvail)

        _btnBlocked = New FButton With {
            .Text = "Blocked",
            .Size = New Size(90, 24),
            .Location = New Point(94, 2),
            .BorderRadius = 6,
            .BorderSize = 0,
            .Cursor = Cursors.Hand,
            .FlatStyle = FlatStyle.Flat
        }
        AddHandler _btnBlocked.Click, Sub() SetStatus(False)
        AddHandler _btnBlocked.MouseEnter, Sub()
            _btnBlocked.BackColor = _btnBlocked.MouseEnterBackColor
            _btnBlocked.ForeColor = _btnBlocked.MouseEnterForeColor
            _btnBlocked.Invalidate()
        End Sub
        AddHandler _btnBlocked.MouseLeave, Sub()
            _btnBlocked.BackColor = _btnBlocked.MouseLeaveBackColor
            _btnBlocked.ForeColor = _btnBlocked.MouseLeaveForeColor
            _btnBlocked.Invalidate()
        End Sub
        cardStatusTrack.Controls.Add(_btnBlocked)
        card.Controls.Add(cardStatusTrack)
        SetStatus(True)

        ' Repeat Checkbox
        _chkRepeat = New CheckBox With {
            .Text = "Repeat weekly on this day",
            .Font = New Font("Segoe UI", 7.75F, FontStyle.Regular),
            .ForeColor = Color.FromArgb(80, 100, 115),
            .Location = New Point(16, 198),
            .Size = New Size(186, 20),
            .Cursor = Cursors.Hand,
            .BackColor = Color.White
        }
        card.Controls.Add(_chkRepeat)

        ' Cancel Button
        Dim btnCancel As New FButton With {
            .Text = "Cancel",
            .Size = New Size(64, 28),
            .Location = New Point(16, 222),
            .BackColor = Color.White,
            .BorderColor = Color.FromArgb(210, 222, 228),
            .BorderRadius = 8,
            .BorderSize = 1,
            .Cursor = Cursors.Hand,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(30, 45, 55),
            .MouseEnterBackColor = Color.FromArgb(245, 249, 251),
            .MouseEnterBorderColor = Color.FromArgb(35, 137, 120),
            .MouseEnterBorderSize = 1,
            .MouseEnterForeColor = Color.FromArgb(35, 137, 120),
            .MouseLeaveBackColor = Color.White,
            .MouseLeaveBorderColor = Color.FromArgb(210, 222, 228),
            .MouseLeaveBorderSize = 1,
            .MouseLeaveForeColor = Color.FromArgb(30, 45, 55)
        }
        AddHandler btnCancel.MouseEnter, Sub()
            btnCancel.BackColor = btnCancel.MouseEnterBackColor
            btnCancel.BorderColor = btnCancel.MouseEnterBorderColor
            btnCancel.ForeColor = btnCancel.MouseEnterForeColor
            btnCancel.Invalidate()
        End Sub
        AddHandler btnCancel.MouseLeave, Sub()
            btnCancel.BackColor = btnCancel.MouseLeaveBackColor
            btnCancel.BorderColor = btnCancel.MouseLeaveBorderColor
            btnCancel.ForeColor = btnCancel.MouseLeaveForeColor
            btnCancel.Invalidate()
        End Sub
        AddHandler btnCancel.Click, Sub()
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End Sub
        card.Controls.Add(btnCancel)

        ' Save Button
        Dim btnSave As New FButton With {
            .Text = "Save availability",
            .Size = New Size(116, 28),
            .Location = New Point(86, 222),
            .BackColor = Color.FromArgb(35, 137, 120),
            .BorderColor = Color.FromArgb(35, 137, 120),
            .BorderRadius = 8,
            .BorderSize = 0,
            .Cursor = Cursors.Hand,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(255, 254, 255),
            .MouseEnterBackColor = Color.FromArgb(23, 105, 90),
            .MouseEnterBorderColor = Color.FromArgb(23, 105, 90),
            .MouseEnterBorderSize = 0,
            .MouseEnterForeColor = Color.FromArgb(255, 254, 255),
            .MouseLeaveBackColor = Color.FromArgb(35, 137, 120),
            .MouseLeaveBorderColor = Color.FromArgb(35, 137, 120),
            .MouseLeaveBorderSize = 0,
            .MouseLeaveForeColor = Color.FromArgb(255, 254, 255)
        }
        AddHandler btnSave.MouseEnter, Sub()
            btnSave.BackColor = btnSave.MouseEnterBackColor
            btnSave.ForeColor = btnSave.MouseEnterForeColor
            btnSave.Invalidate()
        End Sub
        AddHandler btnSave.MouseLeave, Sub()
            btnSave.BackColor = btnSave.MouseLeaveBackColor
            btnSave.ForeColor = btnSave.MouseLeaveForeColor
            btnSave.Invalidate()
        End Sub
        AddHandler btnSave.Click, AddressOf BtnSave_Click
        card.Controls.Add(btnSave)

        Me.Controls.Add(card)
    End Sub

    Private Sub SetStatus(isAvailable As Boolean)
        _isAvailable = isAvailable
        Dim fntBold As New Font("Segoe UI", 8.0F, FontStyle.Bold)
        Dim fntReg As New Font("Segoe UI", 8.0F, FontStyle.Regular)

        If isAvailable Then
            ' Available selected
            _btnAvail.BackColor = Color.FromArgb(230, 245, 235)
            _btnAvail.ForeColor = Color.FromArgb(40, 135, 75)
            _btnAvail.Font = fntBold
            _btnAvail.MouseEnterBackColor = Color.FromArgb(220, 240, 227)
            _btnAvail.MouseEnterForeColor = Color.FromArgb(40, 135, 75)
            _btnAvail.MouseLeaveBackColor = Color.FromArgb(230, 245, 235)
            _btnAvail.MouseLeaveForeColor = Color.FromArgb(40, 135, 75)

            ' Blocked unselected
            _btnBlocked.BackColor = Color.FromArgb(243, 246, 248)
            _btnBlocked.ForeColor = Color.FromArgb(205, 80, 75)
            _btnBlocked.Font = fntReg
            _btnBlocked.MouseEnterBackColor = Color.FromArgb(253, 236, 236)
            _btnBlocked.MouseEnterForeColor = Color.FromArgb(205, 80, 75)
            _btnBlocked.MouseLeaveBackColor = Color.FromArgb(243, 246, 248)
            _btnBlocked.MouseLeaveForeColor = Color.FromArgb(205, 80, 75)
        Else
            ' Available unselected
            _btnAvail.BackColor = Color.FromArgb(243, 246, 248)
            _btnAvail.ForeColor = Color.FromArgb(40, 135, 75)
            _btnAvail.Font = fntReg
            _btnAvail.MouseEnterBackColor = Color.FromArgb(220, 240, 227)
            _btnAvail.MouseEnterForeColor = Color.FromArgb(40, 135, 75)
            _btnAvail.MouseLeaveBackColor = Color.FromArgb(243, 246, 248)
            _btnAvail.MouseLeaveForeColor = Color.FromArgb(40, 135, 75)

            ' Blocked selected
            _btnBlocked.BackColor = Color.FromArgb(253, 236, 236)
            _btnBlocked.ForeColor = Color.FromArgb(205, 80, 75)
            _btnBlocked.Font = fntBold
            _btnBlocked.MouseEnterBackColor = Color.FromArgb(250, 218, 218)
            _btnBlocked.MouseEnterForeColor = Color.FromArgb(205, 80, 75)
            _btnBlocked.MouseLeaveBackColor = Color.FromArgb(253, 236, 236)
            _btnBlocked.MouseLeaveForeColor = Color.FromArgb(205, 80, 75)
        End If

        _btnAvail.Invalidate()
        _btnBlocked.Invalidate()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs)
        Dim startMin = _times(_cboStart.SelectedIndex)
        Dim endMin = _times(_cboEnd.SelectedIndex)

        If endMin <= startMin Then
            MessageBox.Show("The end time must be after the start time.", "Add availability", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedDate = _dtpDate.Value.Date
        Dim kind = If(_isAvailable, "Available", "Blocked")
        Dim isRec = _chkRepeat.Checked
        Dim dow = CInt(selectedDate.DayOfWeek)
        Dim dateStr = selectedDate.ToString("yyyy-MM-dd")

        ' 1. Check for conflicting appointments in this time window
        Dim conflicting = ClinicData.GetConflictingAppointments(_doctorName, selectedDate, startMin, endMin, isRec)
        If conflicting.Count > 0 Then
            Dim conflictMsg = $"There is already an appointment scheduled at that time:{Environment.NewLine}{Environment.NewLine}"
            For Each c In conflicting
                Dim apptTime = ClinicData.FormatTime(c.Minutes)
                Dim patName = If(String.IsNullOrEmpty(c.PatientName), "Scheduled Patient", c.PatientName)
                Dim vType = If(String.IsNullOrEmpty(c.VisitType), "Consultation", c.VisitType)
                conflictMsg &= $"• {patName} ({vType}) at {apptTime} [{c.Status}]{Environment.NewLine}"
            Next
            conflictMsg &= $"{Environment.NewLine}Cannot add availability or block this time slot while an active appointment exists.{Environment.NewLine}Please choose a different time or reschedule the appointment first."

            MessageBox.Show(conflictMsg, "Existing Appointment Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 2. Save to SQLite via Repository
        SqliteAvailabilityRepository.AddAvailability(New AvailabilityItem With {
            .DoctorName = _doctorName,
            .DoctorRole = _doctorRole,
            .AvailableDate = dateStr,
            .StartMinutes = startMin,
            .EndMinutes = endMin,
            .Status = kind,
            .IsRecurring = isRec,
            .DayOfWeek = dow
        })

        AuditStore.Log(_doctorName, "Doctor", "Availability updated", $"{selectedDate:MMM dd}: {ClinicData.FormatTime(startMin)} – {ClinicData.FormatTime(endMin)} ({kind})", "Success")

        Me.SelectedDate = selectedDate
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

End Class
