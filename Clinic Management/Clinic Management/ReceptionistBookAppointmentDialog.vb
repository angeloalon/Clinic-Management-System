Imports System.Drawing
Imports System.Windows.Forms
Imports Ferrando.UI.WinForms.Controles

Public Class ReceptionistBookAppointmentDialog
    Inherits Form

    Private cboPatient As ComboBox
    Private cboDoctor As ComboBox
    Private dtpBookingDate As DateTimePicker
    Private cboTime As ComboBox
    Private cboVisitType As ComboBox
    Private txtReason As TextBox
    Private btnSave As FButton
    Private btnCancel As FButton
    Private errProvider As ErrorProvider

    Private _editingAppointment As AppointmentItem = Nothing
    Public Property BookedDate As DateTime? = Nothing

    Public Sub New()
        InitializeComponentCustom(Nothing, Nothing)
    End Sub

    Public Sub New(preselectedDate As DateTime)
        InitializeComponentCustom(Nothing, preselectedDate)
    End Sub

    Public Sub New(preselectedPatientId As String)
        InitializeComponentCustom(preselectedPatientId, Nothing)
    End Sub

    Public Sub New(appointmentToReschedule As AppointmentItem)
        _editingAppointment = appointmentToReschedule
        InitializeComponentCustom(If(appointmentToReschedule IsNot Nothing, appointmentToReschedule.PatientId, Nothing), Nothing)
        If _editingAppointment IsNot Nothing Then
            Me.Text = "Reschedule Appointment"
            Dim docIdx = cboDoctor.FindStringExact(_editingAppointment.DoctorName)
            If docIdx >= 0 Then cboDoctor.SelectedIndex = docIdx
            Dim vIdx = cboVisitType.FindStringExact(_editingAppointment.VisitType)
            If vIdx >= 0 Then cboVisitType.SelectedIndex = vIdx
            txtReason.Text = _editingAppointment.Reason
            cboPatient.Enabled = False
            btnSave.Text = "Confirm Reschedule"

            Dim apptDate As DateTime
            If Not String.IsNullOrEmpty(_editingAppointment.AppointmentDate) AndAlso DateTime.TryParse(_editingAppointment.AppointmentDate, apptDate) Then
                If apptDate >= dtpBookingDate.MinDate Then dtpBookingDate.Value = apptDate
            End If
            RefreshTimeSlots()
        End If
    End Sub

    Private Sub InitializeComponentCustom(preselectedPatientId As String, Optional initialDate As DateTime? = Nothing)
        errProvider = New ErrorProvider(Me) With {.BlinkStyle = ErrorBlinkStyle.NeverBlink}

        Me.Text = "Book New Appointment"
        Me.Size = New Size(540, 590)
        Me.MinimumSize = New Size(520, 560)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.BackColor = Color.FromArgb(244, 247, 249)
        Me.Font = New Font("Segoe UI", 9.0F)

        Dim pnlHeader As New Panel With {
            .Dock = DockStyle.Top,
            .Height = 70,
            .BackColor = Color.White
        }
        Dim lblTitle As New Label With {
            .Text = "Book New Appointment",
            .Font = New Font("Segoe UI", 13.0F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(22, 51, 65),
            .Location = New Point(20, 14),
            .AutoSize = True
        }
        Dim lblSub As New Label With {
            .Text = "Schedule an appointment slot for a registered patient • UCC Health Clinic",
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Regular),
            .ForeColor = Color.FromArgb(115, 138, 148),
            .Location = New Point(22, 40),
            .AutoSize = True
        }
        pnlHeader.Controls.AddRange(New Control() {lblTitle, lblSub})
        Me.Controls.Add(pnlHeader)

        Dim y As Integer = 86

        ' 1. Patient
        AddFormLabel("PATIENT", 24, y)
        cboPatient = New ComboBox With {
            .Location = New Point(24, y + 18),
            .Size = New Size(476, 26),
            .DropDownStyle = ComboBoxStyle.DropDownList
        }
        Dim patients = PatientRepository.GetAll()
        Dim selectedIdx As Integer = 0
        For i As Integer = 0 To patients.Count - 1
            Dim p = patients(i)
            cboPatient.Items.Add($"{p.Name} • {p.PatientId}")
            If Not String.IsNullOrEmpty(preselectedPatientId) AndAlso p.PatientId.Equals(preselectedPatientId, StringComparison.OrdinalIgnoreCase) Then
                selectedIdx = i
            End If
        Next
        If cboPatient.Items.Count > 0 Then cboPatient.SelectedIndex = selectedIdx
        Me.Controls.Add(cboPatient)
        y += 56

        ' 2. Doctor & Day
        AddFormLabel("DOCTOR", 24, y)
        cboDoctor = New ComboBox With {
            .Location = New Point(24, y + 18),
            .Size = New Size(230, 26),
            .DropDownStyle = ComboBoxStyle.DropDownList
        }
        Dim allDoctors As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        For Each d In StaffStore.Doctors
            If String.Equals(d.Status, "Active", StringComparison.OrdinalIgnoreCase) Then
                allDoctors.Add(d.Name)
            End If
        Next
        For Each dName In SqliteAvailabilityRepository.GetAvailableDoctors()
            allDoctors.Add(dName)
        Next
        If allDoctors.Count = 0 Then
            allDoctors.Add("Dr. Elena Cruz")
            allDoctors.Add("Dr. Marco Lim")
        End If
        cboDoctor.Items.AddRange(allDoctors.OrderBy(Function(n) n).Cast(Of Object)().ToArray())
        cboDoctor.SelectedIndex = 0
        AddHandler cboDoctor.SelectedIndexChanged, Sub(s, e) RefreshTimeSlots()
        Me.Controls.Add(cboDoctor)

        AddFormLabel("BOOKING DATE", 270, y)
        dtpBookingDate = New DateTimePicker With {
            .Location = New Point(270, y + 18),
            .Size = New Size(230, 26),
            .Format = DateTimePickerFormat.Custom,
            .CustomFormat = "ddd, MMM dd, yyyy",
            .MinDate = DateTime.Today
        }
        If initialDate.HasValue AndAlso initialDate.Value.Date >= DateTime.Today Then
            dtpBookingDate.Value = initialDate.Value.Date
        End If
        AddHandler dtpBookingDate.ValueChanged, AddressOf DtpBookingDate_ValueChanged
        Me.Controls.Add(dtpBookingDate)
        y += 56

        ' 3. Time & Visit Type
        AddFormLabel("TIME SLOT", 24, y)
        cboTime = New ComboBox With {
            .Location = New Point(24, y + 18),
            .Size = New Size(230, 26),
            .DropDownStyle = ComboBoxStyle.DropDownList
        }
        Me.Controls.Add(cboTime)

        AddFormLabel("VISIT TYPE", 270, y)
        cboVisitType = New ComboBox With {
            .Location = New Point(270, y + 18),
            .Size = New Size(230, 26),
            .DropDownStyle = ComboBoxStyle.DropDownList
        }
        cboVisitType.Items.AddRange(New Object() {"Consultation", "Follow-up", "Check-up"})
        cboVisitType.SelectedIndex = 0
        Me.Controls.Add(cboVisitType)
        y += 56

        ' 4. Reason
        AddFormLabel("REASON FOR VISIT", 24, y)
        txtReason = New TextBox With {
            .Location = New Point(24, y + 18),
            .Size = New Size(476, 50),
            .Multiline = True,
            .Text = "Routine medical consultation"
        }
        Me.Controls.Add(txtReason)
        y += 84

        ' 5. Action Buttons (Responsive container anchored to Bottom-Right)
        Dim pnlButtons As New Panel With {
            .Location = New Point(24, y + 10),
            .Size = New Size(476, 44),
            .Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        }

        Dim btnFont As New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnCancel = New FButton With {
            .Text = "Cancel",
            .Size = New Size(100, 36),
            .Location = New Point(200, 4),
            .Font = btnFont,
            .Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        }
        UIThemeHelper.ApplySecondary(btnCancel)
        AddHandler btnCancel.Click, Sub() Me.DialogResult = DialogResult.Cancel

        btnSave = New FButton With {
            .Text = "Confirm Booking",
            .Size = New Size(160, 36),
            .Location = New Point(310, 4),
            .Font = btnFont,
            .Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        }
        UIThemeHelper.ApplyPrimary(btnSave)
        AddHandler btnSave.Click, AddressOf BtnSave_Click

        pnlButtons.Controls.AddRange(New Control() {btnCancel, btnSave})
        Me.Controls.Add(pnlButtons)

        ' Populate initial time slots
        RefreshTimeSlots()
    End Sub

    Private Sub DtpBookingDate_ValueChanged(sender As Object, e As EventArgs)
        ' Check for Sunday clinic closure
        If dtpBookingDate.Value.DayOfWeek = DayOfWeek.Sunday Then
            errProvider.SetError(dtpBookingDate, "The clinic is closed on Sundays.")
            ' Skip to next open day (Monday)
            dtpBookingDate.Value = dtpBookingDate.Value.AddDays(1)
            MessageBox.Show("The clinic is closed on Sundays. The booking day has been set to Monday.", "Clinic Closed on Sundays", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        Else
            errProvider.SetError(dtpBookingDate, "")
        End If

        RefreshTimeSlots()
    End Sub

    Private Sub RefreshTimeSlots()
        If cboDoctor.SelectedItem Is Nothing Then Return
        Dim docName = cboDoctor.SelectedItem.ToString()
        Dim dateStr = dtpBookingDate.Value.ToString("yyyy-MM-dd")

        Dim openSlots = SqliteAvailabilityRepository.GetAvailableTimeSlots(docName, dateStr)
        cboTime.Items.Clear()
        For Each minVal In openSlots
            cboTime.Items.Add(ClinicData.FormatTime(minVal))
        Next

        If cboTime.Items.Count > 0 Then
            cboTime.SelectedIndex = 0
            errProvider.SetError(cboTime, "")
        Else
            cboTime.Items.Add("No slots available")
            cboTime.SelectedIndex = 0
            errProvider.SetError(cboTime, "Doctor has no available unbooked slots on this date.")
        End If
    End Sub

    Private Sub AddFormLabel(text As String, x As Integer, y As Integer)
        Dim lbl As New Label With {
            .Text = text,
            .Location = New Point(x, y),
            .Font = New Font("Segoe UI", 7.5F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(115, 135, 145),
            .AutoSize = True
        }
        Me.Controls.Add(lbl)
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs)
        If cboPatient.SelectedIndex < 0 Then
            MessageBox.Show("Please select a patient.", "Book Appointment", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If cboTime.SelectedItem Is Nothing OrElse cboTime.SelectedItem.ToString() = "No slots available" Then
            MessageBox.Show("Please choose a date and doctor with available appointment slots.", "No Slots Available", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim patients = PatientRepository.GetAll()
        Dim p = patients(cboPatient.SelectedIndex)

        Dim bookingDate = dtpBookingDate.Value.Date
        Dim dayVal As Integer = bookingDate.Day
        Dim apptDateStr = bookingDate.ToString("yyyy-MM-dd")

        ' Parse Minutes from Time string
        Dim timeStr = cboTime.SelectedItem.ToString()
        Dim minutesVal As Integer = 540
        Dim dt As DateTime
        If DateTime.TryParse(timeStr, dt) Then
            minutesVal = dt.Hour * 60 + dt.Minute
        End If

        Dim activeUser = If(CurrentUser.IsAuthenticated, CurrentUser.FullName, "Ms. Diana Dina")
        Dim activeRole = If(CurrentUser.IsAuthenticated, CurrentUser.Role, "Receptionist")

        ' Double-booking verification: Check if patient already has an active appointment on the selected date
        Dim existingAppts = ClinicData.Appointments.Where(Function(a) a.PatientId = p.PatientId AndAlso a.MatchesDate(bookingDate) AndAlso a.Status <> "Cancelled").ToList()
        If _editingAppointment IsNot Nothing Then
            existingAppts = existingAppts.Where(Function(a) Not (a.Minutes = _editingAppointment.Minutes AndAlso a.MatchesDate(bookingDate))).ToList()
        End If

        If existingAppts.Count > 0 Then
            Dim conflict = existingAppts.First()
            Dim warningMsg = $"Warning: Patient {p.Name} ({p.PatientId}) already has an appointment booked on {bookingDate:MMM dd, yyyy} at {ClinicData.FormatTime(conflict.Minutes)} with {conflict.DoctorName} (Status: {conflict.Status})." & vbCrLf & vbCrLf &
                             "Double-booking the same patient on the same day may cause scheduling conflicts. Do you wish to proceed and schedule anyway?"
            Dim res = MessageBox.Show(warningMsg, "Potential Double-Booking Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If res <> DialogResult.Yes Then
                Return
            End If
        End If

        If _editingAppointment IsNot Nothing Then
            Dim oldDay = _editingAppointment.Day
            Dim oldMins = _editingAppointment.Minutes
            Dim newDoctor = cboDoctor.SelectedItem.ToString()
            Dim newVisitType = cboVisitType.SelectedItem.ToString()
            Dim newReason = txtReason.Text.Trim()
            Dim newNote = $"Rescheduled to {bookingDate:MMM dd, yyyy} at {timeStr}"

            _editingAppointment.Day = dayVal
            _editingAppointment.Minutes = minutesVal
            _editingAppointment.DoctorName = newDoctor
            _editingAppointment.VisitType = newVisitType
            _editingAppointment.Reason = newReason
            _editingAppointment.Note = newNote
            _editingAppointment.Status = "Confirmed"
            _editingAppointment.IsRescheduled = True
            _editingAppointment.AppointmentDate = apptDateStr
            BookedDate = bookingDate

            ClinicData.RescheduleAppointment(_editingAppointment.PatientId, oldDay, oldMins, dayVal, minutesVal, newDoctor, newNote, apptDateStr)
            AuditStore.Log(activeUser, activeRole, "Appointment rescheduled", $"Appointment for {_editingAppointment.PatientName} moved to {bookingDate:MMM dd} at {timeStr}", "Success")

            MessageBox.Show($"Appointment successfully rescheduled for {_editingAppointment.PatientName} with {newDoctor} on {bookingDate:MMM dd, yyyy} at {timeStr}.",
                            "Appointment Rescheduled", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.DialogResult = DialogResult.OK
            Me.Close()
            Return
        End If

        Dim newAppt As New AppointmentItem With {
            .Day = dayVal,
            .AppointmentDate = apptDateStr,
            .Minutes = minutesVal,
            .PatientId = p.PatientId,
            .PatientName = p.Name,
            .Age = p.Age,
            .Sex = p.Gender,
            .DoctorName = cboDoctor.SelectedItem.ToString(),
            .DoctorRole = "General Physician",
            .RoomNumber = ReceptionistAppointment.GetDoctorRoom(cboDoctor.SelectedItem.ToString()),
            .VisitType = cboVisitType.SelectedItem.ToString(),
            .Status = "Confirmed",
            .Reason = txtReason.Text.Trim(),
            .Note = "Booked via Receptionist Appointment Center",
            .Bp = "",
            .Pulse = "",
            .Temperature = "",
            .Spo2 = "",
            .IsDraft = False
        }

        BookedDate = bookingDate
        ClinicData.AddAppointment(newAppt)
        AuditStore.Log(activeUser, activeRole, "Appointment booked", $"Appointment booked for {p.Name} with {newAppt.DoctorName} on {bookingDate:MMM dd} at {timeStr}", "Success")

        MessageBox.Show($"Appointment successfully scheduled for {p.Name} with {newAppt.DoctorName} on {bookingDate:MMM dd, yyyy} at {timeStr}.",
                        "Appointment Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

End Class
