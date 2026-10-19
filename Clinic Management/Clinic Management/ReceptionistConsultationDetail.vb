Imports System.Globalization
Imports System.Linq
Imports Ferrando.UI.WinForms.Controles

' ----------------------------------------------------------------------
'  The consultation form shown when a patient row is clicked
'  Complies with Data Privacy Act of 2012 (RA 10173) by shielding clinical
'  info (symptoms, diagnosis, medications, vitals) from receptionist views.
' ----------------------------------------------------------------------
Public Class ReceptionistConsultationDetail

    Public Event BackRequested()

    Private cardAdminDetails As FCard
    Private cardPrivacyNotice As FCard
    Private lblShieldTitle As Label
    Private lblShieldMsg As Label
    Private btnRequestAccess As FButton
    Private lblAdminDoctor As Label
    Private lblAdminVisitType As Label
    Private lblAdminStatus As Label
    Private lblAdminRxIssued As Label

    Private _currentInfo As ConsultationInfo

    Public Sub New()
        InitializeComponent()
        SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        DoubleBuffered = True

        ' Make assessment and prescription plan read-only labels for clinical view
        Dim readOnlyFill As Color = Color.FromArgb(248, 250, 252)
        For Each tb As TextBox In New TextBox() {txtSymptoms, txtDiagnosis, txtMedication, txtAdvice}
            tb.ReadOnly = True
            tb.BackColor = readOnlyFill
            tb.TabStop = False
            tb.BorderStyle = BorderStyle.None
            If tb.Parent IsNot Nothing Then
                tb.Parent.BackColor = readOnlyFill
            End If
        Next

        UIThemeHelper.ApplySecondary(btnBack)
        SetupAdminCards()

        AddHandler ClinicData.DataChanged, Sub()
            If Me.Visible AndAlso _currentInfo IsNot Nothing Then
                RefreshAccessState()
            End If
        End Sub
    End Sub

    Private Sub SetupAdminCards()
        ' Setup Data Privacy Notice Card
        cardPrivacyNotice = New FCard With {
            .Location = New Point(28, 176),
            .Size = New Size(cardPatient.Width, 80),
            .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right,
            .BackColor = Color.FromArgb(254, 249, 237),
            .BorderColor = Color.FromArgb(245, 215, 145),
            .BorderHoverColor = Color.FromArgb(245, 215, 145),
            .BorderRadius = 10,
            .BorderSize = 1,
            .EnableShadow = False,
            .Visible = False
        }

        lblShieldTitle = New Label With {
            .Text = "🛡 Data Privacy Notice (RA 10173 - Philippine Data Privacy Act of 2012)",
            .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(146, 92, 10),
            .Location = New Point(16, 12),
            .AutoSize = True,
            .BackColor = Color.Transparent
        }

        lblShieldMsg = New Label With {
            .Text = "Clinical notes (symptoms, diagnostic findings, prescriptions, and vital signs) are strictly confidential medical records. Receptionist staff are granted access exclusively to administrative visit logs.",
            .Font = New Font("Segoe UI", 8.25F, FontStyle.Regular),
            .ForeColor = Color.FromArgb(115, 80, 25),
            .Location = New Point(16, 36),
            .Size = New Size(cardPrivacyNotice.Width - 230, 36),
            .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right,
            .BackColor = Color.Transparent
        }

        btnRequestAccess = New FButton With {
            .Text = "Request Record Access",
            .Size = New Size(185, 36),
            .Location = New Point(cardPrivacyNotice.Width - 200, 20),
            .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
            .Cursor = Cursors.Hand,
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        }
        UIThemeHelper.ApplyPrimary(btnRequestAccess)
        AddHandler btnRequestAccess.Click, AddressOf BtnRequestAccess_Click

        cardPrivacyNotice.Controls.AddRange(New Control() {lblShieldTitle, lblShieldMsg, btnRequestAccess})
        Controls.Add(cardPrivacyNotice)
        cardPrivacyNotice.BringToFront()

        ' Setup Administrative Consultation Record Card
        cardAdminDetails = New FCard With {
            .Location = New Point(28, 268),
            .Size = New Size(cardPatient.Width, 230),
            .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right,
            .BackColor = Color.White,
            .BorderColor = Color.FromArgb(232, 237, 240),
            .BorderHoverColor = Color.FromArgb(232, 237, 240),
            .BorderRadius = 12,
            .BorderSize = 1,
            .EnableShadow = True,
            .ShadowDepth = 4,
            .Visible = False
        }

        Dim lblAdminHdr As New Label With {
            .Text = "Administrative Visit Information",
            .Font = New Font("Segoe UI", 11.0F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(30, 45, 55),
            .Location = New Point(20, 16),
            .AutoSize = True,
            .BackColor = Color.Transparent
        }

        Dim MakeFieldHdr = Function(txt As String, x As Integer, y As Integer) As Label
                               Return New Label With {
                                   .Text = txt,
                                   .Font = New Font("Segoe UI", 7.5F, FontStyle.Bold),
                                   .ForeColor = Color.FromArgb(115, 135, 145),
                                   .Location = New Point(x, y),
                                   .AutoSize = True,
                                   .BackColor = Color.Transparent
                               }
                           End Function

        cardAdminDetails.Controls.Add(lblAdminHdr)
        cardAdminDetails.Controls.Add(MakeFieldHdr("ATTENDING PHYSICIAN", 20, 52))
        lblAdminDoctor = New Label With {
            .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(22, 51, 65),
            .Location = New Point(20, 72),
            .AutoSize = True,
            .BackColor = Color.Transparent
        }
        cardAdminDetails.Controls.Add(lblAdminDoctor)

        cardAdminDetails.Controls.Add(MakeFieldHdr("VISIT TYPE & CATEGORY", 20, 108))
        lblAdminVisitType = New Label With {
            .Font = New Font("Segoe UI", 9.0F, FontStyle.Regular),
            .ForeColor = Color.FromArgb(30, 45, 55),
            .Location = New Point(20, 126),
            .AutoSize = True,
            .BackColor = Color.Transparent
        }
        cardAdminDetails.Controls.Add(lblAdminVisitType)

        cardAdminDetails.Controls.Add(MakeFieldHdr("APPOINTMENT STATUS", 320, 52))
        lblAdminStatus = New Label With {
            .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(40, 135, 75),
            .Location = New Point(320, 72),
            .AutoSize = True,
            .BackColor = Color.Transparent
        }
        cardAdminDetails.Controls.Add(lblAdminStatus)

        cardAdminDetails.Controls.Add(MakeFieldHdr("PRESCRIPTION ISSUED", 320, 108))
        lblAdminRxIssued = New Label With {
            .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(35, 137, 120),
            .Location = New Point(320, 126),
            .AutoSize = True,
            .BackColor = Color.Transparent
        }
        cardAdminDetails.Controls.Add(lblAdminRxIssued)

        Controls.Add(cardAdminDetails)
        cardAdminDetails.BringToFront()
    End Sub

    Public Sub LoadPatient(info As ConsultationInfo)
        _currentInfo = info
        Dim dot As String = " " & ChrW(&H2022) & " "

        ' Fix default 12:00 AM midnight artifact: show time only if non-zero
        Dim timeText As String = ""
        If info.VisitDate.TimeOfDay <> TimeSpan.Zero Then
            timeText = " at " & info.VisitDate.ToString("h:mm tt", CultureInfo.InvariantCulture)
        End If

        lblSubtitle.Text = "Appointment " & info.AppointmentId & dot &
                           info.VisitDate.ToString("MMM dd, yyyy", CultureInfo.InvariantCulture) & timeText

        Dim normName = ValidationHelper.NormalizeProperCase(info.Name)
        lblPatientName.Text = normName & dot & info.PatientId
        lblPatientMeta.Text = info.Age & " years" & dot & info.Sex & "        " &
                              info.Allergies & "        Reason: " & info.Reason

        RefreshAccessState()
    End Sub

    Public Sub RefreshAccessState()
        If _currentInfo Is Nothing Then Return

        Dim isReceptionist = (CurrentUser.Role = "Receptionist" OrElse Not (CurrentUser.Role = "Doctor" OrElse CurrentUser.Role = "Admin"))
        Dim userId = If(CurrentUser.IsAuthenticated, CurrentUser.UserId, 0)
        Dim hasApproved = SqliteConsultationAccessRepository.HasApprovedAccess(_currentInfo.AppointmentId, _currentInfo.PatientId, userId)

        If Not isReceptionist Then
            ' Doctor or authorized medical staff view
            cardPrivacyNotice.Visible = False
            cardAdminDetails.Visible = False

            cardAssessment.Visible = True
            cardAssessment.Location = New Point(28, 176)
            cardPrescription.Visible = True
            cardPrescription.Location = New Point(28, 352)
            cardVitals.Visible = True
            cardVitals.Location = New Point(586, 176)

            txtSymptoms.Text = _currentInfo.Symptoms
            txtDiagnosis.Text = _currentInfo.Diagnosis
            txtMedication.Text = _currentInfo.Medication
            txtAdvice.Text = _currentInfo.Advice

            lblBP.Text = "BP " & _currentInfo.BP
            lblPulse.Text = "Pulse " & _currentInfo.Pulse
            lblTemp.Text = "Temperature " & _currentInfo.Temperature
            lblSpO2.Text = "SpO" & ChrW(&H2082) & " " & _currentInfo.SpO2
            Return
        End If

        If hasApproved Then
            ' Receptionist with approved access
            cardPrivacyNotice.Visible = True
            cardPrivacyNotice.Location = New Point(28, 176)
            cardPrivacyNotice.Size = New Size(cardPatient.Width, 48)
            cardPrivacyNotice.BackColor = Color.FromArgb(230, 245, 235)
            cardPrivacyNotice.BorderColor = Color.FromArgb(180, 225, 195)
            cardPrivacyNotice.BorderHoverColor = Color.FromArgb(180, 225, 195)

            lblShieldTitle.Text = $"✓ Clinical Record Access Approved by {_currentInfo.DoctorName} (Active)"
            lblShieldTitle.ForeColor = Color.FromArgb(29, 124, 107)
            lblShieldTitle.Location = New Point(16, 14)
            lblShieldMsg.Visible = False
            btnRequestAccess.Visible = False

            cardAdminDetails.Visible = False

            cardAssessment.Visible = True
            cardAssessment.Location = New Point(28, 236)
            cardPrescription.Visible = True
            cardPrescription.Location = New Point(28, 412)
            cardVitals.Visible = True
            cardVitals.Location = New Point(586, 236)

            txtSymptoms.Text = _currentInfo.Symptoms
            txtDiagnosis.Text = _currentInfo.Diagnosis
            txtMedication.Text = _currentInfo.Medication
            txtAdvice.Text = _currentInfo.Advice

            lblBP.Text = "BP " & _currentInfo.BP
            lblPulse.Text = "Pulse " & _currentInfo.Pulse
            lblTemp.Text = "Temperature " & _currentInfo.Temperature
            lblSpO2.Text = "SpO" & ChrW(&H2082) & " " & _currentInfo.SpO2
        Else
            ' Receptionist without active approval
            cardAssessment.Visible = False
            cardPrescription.Visible = False
            cardVitals.Visible = False

            cardPrivacyNotice.Visible = True
            cardPrivacyNotice.Location = New Point(28, 176)
            cardPrivacyNotice.Size = New Size(cardPatient.Width, 80)
            lblShieldTitle.Location = New Point(16, 12)
            lblShieldMsg.Visible = True
            btnRequestAccess.Visible = True

            cardAdminDetails.Visible = True
            cardAdminDetails.Location = New Point(28, 268)

            lblAdminDoctor.Text = _currentInfo.DoctorName
            lblAdminVisitType.Text = _currentInfo.VisitType & " (Purpose: " & _currentInfo.Reason & ")"
            lblAdminStatus.Text = _currentInfo.Status
            lblAdminRxIssued.Text = If(_currentInfo.PrescriptionIssued, "✓ Yes (Prescription generated)", "✗ No")
            lblAdminRxIssued.ForeColor = If(_currentInfo.PrescriptionIssued, Color.FromArgb(35, 137, 120), Color.FromArgb(120, 135, 145))

            ' Query latest request to show appropriate status banner
            Dim latestReq = SqliteConsultationAccessRepository.GetLatestRequest(_currentInfo.AppointmentId, _currentInfo.PatientId, userId)
            If latestReq IsNot Nothing AndAlso latestReq.Status = "Pending" Then
                cardPrivacyNotice.BackColor = Color.FromArgb(254, 248, 232)
                cardPrivacyNotice.BorderColor = Color.FromArgb(245, 215, 145)
                cardPrivacyNotice.BorderHoverColor = Color.FromArgb(245, 215, 145)

                lblShieldTitle.Text = "⏳ Clinical Access Request Pending — Waiting for Doctor Review"
                lblShieldTitle.ForeColor = Color.FromArgb(160, 100, 15)
                lblShieldMsg.Text = $"Your access request was sent to {_currentInfo.DoctorName} at {latestReq.RequestedAt}. Notes will unlock once approved."
                lblShieldMsg.ForeColor = Color.FromArgb(130, 85, 20)

                btnRequestAccess.Text = "⏳ Request Pending"
                btnRequestAccess.Enabled = False
                btnRequestAccess.BackColor = Color.FromArgb(245, 247, 249)
                btnRequestAccess.ForeColor = Color.FromArgb(130, 150, 160)
                btnRequestAccess.BorderColor = Color.FromArgb(220, 228, 232)
            ElseIf latestReq IsNot Nothing AndAlso latestReq.Status = "Declined" Then
                cardPrivacyNotice.BackColor = Color.FromArgb(254, 242, 242)
                cardPrivacyNotice.BorderColor = Color.FromArgb(245, 200, 200)
                cardPrivacyNotice.BorderHoverColor = Color.FromArgb(245, 200, 200)

                lblShieldTitle.Text = $"✕ Access Request Declined by {_currentInfo.DoctorName}"
                lblShieldTitle.ForeColor = Color.FromArgb(185, 45, 45)
                Dim noteMsg = If(String.IsNullOrWhiteSpace(latestReq.DecisionNote), "Access not permitted.", latestReq.DecisionNote)
                lblShieldMsg.Text = $"The doctor declined the request ({noteMsg}). You may submit a new request with updated justification."
                lblShieldMsg.ForeColor = Color.FromArgb(150, 40, 40)

                btnRequestAccess.Text = "Re-request Access"
                btnRequestAccess.Enabled = True
                UIThemeHelper.ApplyPrimary(btnRequestAccess)
            Else
                ' Default initial state
                cardPrivacyNotice.BackColor = Color.FromArgb(254, 249, 237)
                cardPrivacyNotice.BorderColor = Color.FromArgb(245, 215, 145)
                cardPrivacyNotice.BorderHoverColor = Color.FromArgb(245, 215, 145)

                lblShieldTitle.Text = "🛡 Data Privacy Notice (RA 10173 - Philippine Data Privacy Act of 2012)"
                lblShieldTitle.ForeColor = Color.FromArgb(146, 92, 10)
                lblShieldMsg.Text = "Clinical notes (symptoms, diagnostic findings, prescriptions, and vital signs) are strictly confidential medical records. Receptionist staff are granted access exclusively to administrative visit logs."
                lblShieldMsg.ForeColor = Color.FromArgb(115, 80, 25)

                btnRequestAccess.Text = "Request Record Access"
                btnRequestAccess.Enabled = True
                UIThemeHelper.ApplyPrimary(btnRequestAccess)
            End If
        End If
    End Sub

    Private Sub BtnRequestAccess_Click(sender As Object, e As EventArgs)
        If _currentInfo Is Nothing Then Return
        Using dlg As New ConsultationAccessRequestDialog(_currentInfo.AppointmentId, _currentInfo.PatientId, _currentInfo.Name, _currentInfo.DoctorName)
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                RefreshAccessState()
            End If
        End Using
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        RaiseEvent BackRequested()
    End Sub

End Class

' ----------------------------------------------------------------------
'  Data for one consultation (replaces raw patient view with consultation entity)
' ----------------------------------------------------------------------
Public Class ConsultationInfo
    Public Property AppointmentId As String
    Public Property VisitDate As Date
    Public Property Name As String
    Public Property PatientId As String
    Public Property Age As Integer
    Public Property Sex As String
    Public Property Allergies As String
    Public Property Reason As String
    Public Property Symptoms As String
    Public Property Diagnosis As String
    Public Property Medication As String
    Public Property Advice As String
    Public Property BP As String
    Public Property Pulse As String
    Public Property Temperature As String
    Public Property SpO2 As String
    Public Property DoctorName As String
    Public Property VisitType As String
    Public Property Status As String
    Public Property PrescriptionIssued As Boolean

    Public Shared Function ForPatient(patientId As String) As ConsultationInfo
        Dim p = PatientRepository.GetById(patientId)
        Dim appt = ClinicData.Appointments.LastOrDefault(Function(a) (a.PatientId.Equals(patientId, StringComparison.OrdinalIgnoreCase) OrElse a.PatientName.Equals(patientId, StringComparison.OrdinalIgnoreCase)) AndAlso a.Status = "Completed")
        If appt Is Nothing Then
            appt = ClinicData.Appointments.LastOrDefault(Function(a) a.PatientId.Equals(patientId, StringComparison.OrdinalIgnoreCase) OrElse a.PatientName.Equals(patientId, StringComparison.OrdinalIgnoreCase))
        End If

        Dim latestVisit As VisitItem = Nothing
        If p IsNot Nothing AndAlso p.Visits IsNot Nothing AndAlso p.Visits.Count > 0 Then
            latestVisit = p.Visits(0)
        End If

        Dim vDate As Date = Date.Today
        If latestVisit IsNot Nothing Then
            Date.TryParse(latestVisit.VisitDate, vDate)
        ElseIf appt IsNot Nothing Then
            vDate = New Date(2026, 9, Math.Min(Math.Max(appt.Day, 1), 30)).AddMinutes(appt.Minutes)
        End If

        Dim allergiesStr As String = "No known drug allergies"
        If p IsNot Nothing AndAlso p.HasAllergies AndAlso Not String.IsNullOrWhiteSpace(p.DrugAllergies) Then
            allergiesStr = p.DrugAllergies & " allergy"
        End If

        Dim hasRx = (appt IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(appt.Medication) AndAlso Not appt.Medication.Equals("None prescribed", StringComparison.OrdinalIgnoreCase)) OrElse
                    (latestVisit IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(latestVisit.Diagnosis))

        Dim info As New ConsultationInfo With {
            .AppointmentId = If(appt IsNot Nothing AndAlso Not String.IsNullOrEmpty(appt.AppointmentId), appt.AppointmentId, "AP-" & Math.Abs(patientId.GetHashCode() Mod 8999 + 1000).ToString()),
            .VisitDate = vDate,
            .Name = If(p IsNot Nothing, p.Name, If(appt IsNot Nothing, appt.PatientName, "Patient")),
            .PatientId = If(p IsNot Nothing, p.PatientId, patientId),
            .Age = If(p IsNot Nothing, p.Age, If(appt IsNot Nothing, appt.Age, 30)),
            .Sex = If(p IsNot Nothing, p.Gender, If(appt IsNot Nothing, appt.Sex, "Unknown")),
            .Allergies = allergiesStr,
            .Reason = If(appt IsNot Nothing AndAlso Not String.IsNullOrEmpty(appt.Reason), appt.Reason, If(latestVisit IsNot Nothing, latestVisit.VisitType, "Follow-up")),
            .DoctorName = If(appt IsNot Nothing AndAlso Not String.IsNullOrEmpty(appt.DoctorName), appt.DoctorName, If(latestVisit IsNot Nothing AndAlso Not String.IsNullOrEmpty(latestVisit.Doctor), latestVisit.Doctor, "Dr. Elena Cruz")),
            .VisitType = If(appt IsNot Nothing AndAlso Not String.IsNullOrEmpty(appt.VisitType), appt.VisitType, If(latestVisit IsNot Nothing, latestVisit.VisitType, "General Consultation")),
            .Status = If(appt IsNot Nothing AndAlso Not String.IsNullOrEmpty(appt.Status), appt.Status, "Completed"),
            .PrescriptionIssued = hasRx,
            .Symptoms = If(appt IsNot Nothing AndAlso Not String.IsNullOrEmpty(appt.Symptoms), appt.Symptoms, "Patient attended scheduled consultation; vitals stable."),
            .Diagnosis = If(appt IsNot Nothing AndAlso Not String.IsNullOrEmpty(appt.Diagnosis), appt.Diagnosis, If(latestVisit IsNot Nothing, latestVisit.Diagnosis, "Routine clinical evaluation")),
            .Medication = If(appt IsNot Nothing AndAlso Not String.IsNullOrEmpty(appt.Medication), appt.Medication, "None prescribed"),
            .Advice = If(appt IsNot Nothing AndAlso Not String.IsNullOrEmpty(appt.Advice), appt.Advice, "Follow routine wellness and hydration instructions."),
            .BP = If(appt IsNot Nothing AndAlso Not String.IsNullOrEmpty(appt.Bp), appt.Bp & " mmHg", "120/80 mmHg"),
            .Pulse = If(appt IsNot Nothing AndAlso Not String.IsNullOrEmpty(appt.Pulse), appt.Pulse, "72 bpm"),
            .Temperature = If(appt IsNot Nothing AndAlso Not String.IsNullOrEmpty(appt.Temperature), appt.Temperature, "36.6 °C"),
            .SpO2 = If(appt IsNot Nothing AndAlso Not String.IsNullOrEmpty(appt.Spo2), appt.Spo2, "98%")
        }

        Return info
    End Function

    Public Shared Function ForAppointment(appointmentId As String, Optional patientId As String = "") As ConsultationInfo
        Dim appt As AppointmentItem = Nothing
        If Not String.IsNullOrEmpty(appointmentId) Then
            appt = ClinicData.Appointments.FirstOrDefault(Function(a)
                                                              If Not String.IsNullOrEmpty(a.AppointmentId) AndAlso a.AppointmentId.Equals(appointmentId, StringComparison.OrdinalIgnoreCase) Then Return True
                                                              If ("AP-" & a.Id).Equals(appointmentId, StringComparison.OrdinalIgnoreCase) Then Return True
                                                              Return False
                                                          End Function)
        End If

        If appt Is Nothing Then
            Return ForPatient(patientId)
        End If

        Dim p = PatientRepository.GetById(appt.PatientId)

        Dim vDate As Date
        If Not String.IsNullOrEmpty(appt.AppointmentDate) AndAlso DateTime.TryParse(appt.AppointmentDate, vDate) Then
            vDate = vDate.Date.AddMinutes(appt.Minutes)
        Else
            vDate = New Date(2026, 9, Math.Min(Math.Max(appt.Day, 1), 30)).AddMinutes(appt.Minutes)
        End If

        Dim allergiesStr As String = "No known drug allergies"
        If p IsNot Nothing AndAlso p.HasAllergies AndAlso Not String.IsNullOrWhiteSpace(p.DrugAllergies) Then
            allergiesStr = p.DrugAllergies & " allergy"
        End If

        Dim hasRx = Not String.IsNullOrWhiteSpace(appt.Medication) AndAlso Not appt.Medication.Equals("None prescribed", StringComparison.OrdinalIgnoreCase)

        Dim effectiveDoc = If(Not String.IsNullOrWhiteSpace(appt.DoctorName), appt.DoctorName.Trim(), "Dr. Elena Cruz")
        If Not effectiveDoc.StartsWith("Dr.", StringComparison.OrdinalIgnoreCase) Then
            effectiveDoc = "Dr. " & effectiveDoc
        End If

        Dim info As New ConsultationInfo With {
            .AppointmentId = If(Not String.IsNullOrEmpty(appt.AppointmentId), appt.AppointmentId, appointmentId),
            .VisitDate = vDate,
            .Name = If(p IsNot Nothing, p.Name, If(Not String.IsNullOrEmpty(appt.PatientName), appt.PatientName, "Patient")),
            .PatientId = If(p IsNot Nothing, p.PatientId, appt.PatientId),
            .Age = If(p IsNot Nothing, p.Age, If(appt.Age > 0, appt.Age, 30)),
            .Sex = If(p IsNot Nothing, p.Gender, If(Not String.IsNullOrEmpty(appt.Sex), appt.Sex, "Unknown")),
            .Allergies = allergiesStr,
            .Reason = If(Not String.IsNullOrEmpty(appt.Reason), appt.Reason, "Routine Consultation"),
            .DoctorName = effectiveDoc,
            .VisitType = If(Not String.IsNullOrEmpty(appt.VisitType), appt.VisitType, "General Consultation"),
            .Status = If(Not String.IsNullOrEmpty(appt.Status), appt.Status, "Completed"),
            .PrescriptionIssued = hasRx,
            .Symptoms = If(Not String.IsNullOrEmpty(appt.Symptoms), appt.Symptoms, "Patient attended scheduled consultation; vitals stable."),
            .Diagnosis = If(Not String.IsNullOrEmpty(appt.Diagnosis), appt.Diagnosis, "Routine clinical evaluation"),
            .Medication = If(Not String.IsNullOrEmpty(appt.Medication), appt.Medication, "None prescribed"),
            .Advice = If(Not String.IsNullOrEmpty(appt.Advice), appt.Advice, "Follow routine wellness and hydration instructions."),
            .BP = If(Not String.IsNullOrEmpty(appt.Bp), If(appt.Bp.Contains("mmHg"), appt.Bp, appt.Bp & " mmHg"), "120/80 mmHg"),
            .Pulse = If(Not String.IsNullOrEmpty(appt.Pulse), If(appt.Pulse.Contains("bpm"), appt.Pulse, appt.Pulse & " bpm"), "72 bpm"),
            .Temperature = If(Not String.IsNullOrEmpty(appt.Temperature), If(appt.Temperature.Contains("°C"), appt.Temperature, appt.Temperature & " °C"), "36.6 °C"),
            .SpO2 = If(Not String.IsNullOrEmpty(appt.Spo2), If(appt.Spo2.Contains("%"), appt.Spo2, appt.Spo2 & "%"), "98%")
        }

        Return info
    End Function
End Class
