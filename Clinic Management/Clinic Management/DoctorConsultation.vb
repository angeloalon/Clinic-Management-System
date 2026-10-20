Imports Ferrando.UI.WinForms.Controles

Public Class DoctorConsultation

    Private sidebarHandler As SidebarHandler
    Private _item As AppointmentItem

    ' ---- responsive layout state ----
    Private _captured As Boolean
    Private _pillMargin As Integer
    Private ReadOnly _base As New Dictionary(Of Control, Rectangle)
    Private ReadOnly _baseParent As New Dictionary(Of Control, Size)

    ''' <summary>The appointment being consulted, or Nothing when none is loaded.</summary>
    Public ReadOnly Property CurrentAppointment As AppointmentItem
        Get
            Return _item
        End Get
    End Property

    ' ------------------------------------------------------------------ responsive helpers

    Private Function PillRight() As Integer
        If _captured AndAlso cardPending.Parent IsNot Nothing Then
            Return cardPending.Parent.ClientSize.Width - _pillMargin
        End If
        Return 803
    End Function

    Private Sub CaptureLayout()
        If _captured Then Return
        _pillMargin = cardPending.Parent.ClientSize.Width - 803
        RecordChildren(Me)
        Me.MinimumSize = New Size(Me.Width * 3 \ 4, Me.Height * 3 \ 4)
        _captured = True
    End Sub

    Private Sub RecordChildren(parent As Control)
        For Each c As Control In parent.Controls
            _base(c) = c.Bounds
            _baseParent(c) = parent.ClientSize
            If c.HasChildren Then RecordChildren(c)
        Next
    End Sub

    Private Sub ScaleChildControls(parent As Control)
        Dim pw As Integer = parent.ClientSize.Width
        Dim ph As Integer = parent.ClientSize.Height

        ' Detect a sidebar-like sibling (left edge, narrow, nearly full height)
        Dim sideW As Integer = 0
        For Each c As Control In parent.Controls
            If Not _base.ContainsKey(c) Then Continue For
            Dim b = _base(c)
            Dim bp = _baseParent(c)
            If b.X = 0 AndAlso b.Width > 0 AndAlso b.Width < 300 AndAlso
               b.Height >= bp.Height * 0.8 AndAlso bp.Width > b.Width * 2 Then
                sideW = Math.Max(sideW, b.Width)
            End If
        Next

        For Each c As Control In parent.Controls
            If c Is cardPending Then Continue For          ' positioned manually
            If Not _base.ContainsKey(c) Then Continue For

            If c.Dock = DockStyle.None Then
                Dim b = _base(c)
                Dim bp = _baseParent(c)
                Dim isSidebar As Boolean = (sideW > 0 AndAlso b.X = 0 AndAlso b.Width = sideW AndAlso b.Height >= bp.Height * 0.8)

                If isSidebar Then
                    c.SetBounds(0, 0, b.Width, ph)
                Else
                    Dim rx As Double = (pw - sideW) / Math.Max(1, bp.Width - sideW)
                    Dim ry As Double = ph / Math.Max(1, bp.Height)
                    Dim nx As Integer = sideW + CInt((b.X - sideW) * rx)
                    Dim ny As Integer = CInt(b.Y * ry)

                    Dim keepSize As Boolean = TypeOf c Is Label OrElse TypeOf c Is Button OrElse
                                              TypeOf c Is Ferrando.UI.WinForms.Controles.FButton
                    If keepSize Then
                        c.SetBounds(nx, ny, b.Width, b.Height)
                    Else
                        c.SetBounds(nx, ny, Math.Max(20, CInt(b.Width * rx)), Math.Max(20, CInt(b.Height * ry)))
                    End If
                End If
            End If

            ' Always recurse, even into docked panels
            If c.HasChildren Then ScaleChildControls(c)
        Next
    End Sub

    Public Function HasUnsavedChanges() As Boolean
        Return txtSymptoms.Modified OrElse txtDiagnosis.Modified OrElse txtMedication.Modified OrElse txtAdvice.Modified OrElse
               txtSymptoms.Focused OrElse txtDiagnosis.Focused OrElse txtMedication.Focused OrElse txtAdvice.Focused
    End Function

    Public Sub RefreshIfClean()
        If Not HasUnsavedChanges() AndAlso _item IsNot Nothing Then
            Dim allAppts = ClinicData.Appointments
            Dim updatedAppt = allAppts.FirstOrDefault(Function(a) a.Id = _item.Id OrElse (Not String.IsNullOrEmpty(a.AppointmentId) AndAlso a.AppointmentId = _item.AppointmentId))
            If updatedAppt IsNot Nothing Then
                _item = updatedAppt
                ApplyVitals(_item.Bp, _item.Pulse, _item.Temperature, _item.Spo2)
            End If
        End If
    End Sub

    Private Sub PositionDynamicLabels()
        If _item Is Nothing Then Return
        lblPatientAllergy.Left = lblPatientAgeSex.Right + 16
        lblPatientReason.Left = lblPatientAllergy.Right + 16
    End Sub

    Private Sub DoctorConsultation_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Not _captured OrElse Me.WindowState = FormWindowState.Minimized Then Return
        Me.SuspendLayout()
        ScaleChildControls(Me)
        cardPending.Left = PillRight() - cardPending.Width
        PositionDynamicLabels()
        Me.ResumeLayout(True)
    End Sub

    Public Sub New()
        InitializeComponent()
        LoadAppointment(ClinicData.NextPending())
    End Sub

    Public Sub New(item As AppointmentItem)
        InitializeComponent()
        LoadAppointment(item)
    End Sub

    Private Sub DoctorConsultation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CaptureLayout()
        sidebarHandler = New SidebarHandler(btnDashboard, btnPatients, btnAppointment,
                                            btnDoctor, btnConsultation, btnReports)
        sidebarHandler.SetActive(btnConsultation)

        Dim tt As New ToolTip()
        tt.SetToolTip(btnSaveComplete, "Save & Complete consultation (Ctrl+Enter)")
        tt.SetToolTip(btnSaveDraft, "Save draft consultation notes")
        tt.SetToolTip(btnPrintRx, "Open Prescription sheet")
        tt.SetToolTip(btnPrintLab, "Open Laboratory requisition sheet")
        If btnViewFullChart IsNot Nothing Then tt.SetToolTip(btnViewFullChart, "Open complete longitudinal patient record")
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = (Keys.Control Or Keys.Enter) Then
            If btnSaveComplete IsNot Nothing AndAlso btnSaveComplete.Enabled AndAlso btnSaveComplete.Visible Then
                btnSaveComplete.PerformClick()
                Return True
            End If
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    ''' <summary>Fills the workspace with an appointment (or the empty state when Nothing).</summary>
    Public Sub LoadAppointment(a As AppointmentItem)
        _item = a
        Dim hasPatient As Boolean = (a IsNot Nothing)

        If hasPatient Then
            lblPatientName.Text = a.PatientName & " • " & a.PatientId
            lblPatientAgeSex.Text = a.Age & " years • " & a.Sex
            lblPatientReason.Text = "Reason: " & a.Reason

            txtSymptoms.Text = a.Symptoms
            txtDiagnosis.Text = a.Diagnosis
            txtMedication.Text = a.Medication
            txtAdvice.Text = a.Advice

            ApplyVitals(a.Bp, a.Pulse, a.Temperature, a.Spo2)

            ' Load patient medical history & allergies from repository
            Dim p = PatientRepository.GetById(a.PatientId)
            If p IsNot Nothing Then
                lblConditionsValue.Text = p.KnownConditions
                If p.HasAllergies Then
                    cardAllergyAlert.BackColor = ClinicData.Hx("#FDECEC")
                    cardAllergyAlert.BorderColor = ClinicData.Hx("#F4CCCA")
                    lblAllergyText.ForeColor = ClinicData.Hx("#CD504B")
                    lblAllergyText.Text = "⚠️ " & p.DrugAllergies
                    lblPatientAllergy.Text = "Allergy: " & p.DrugAllergies
                    lblPatientAllergy.ForeColor = ClinicData.Hx("#CD504B")
                Else
                    cardAllergyAlert.BackColor = ClinicData.Hx("#E6F5EB")
                    cardAllergyAlert.BorderColor = ClinicData.Hx("#C9E7D3")
                    lblAllergyText.ForeColor = ClinicData.Hx("#28874B")
                    lblAllergyText.Text = "✓ No known drug allergies"
                    lblPatientAllergy.Text = "No known drug allergies"
                    lblPatientAllergy.ForeColor = ClinicData.Hx("#738791")
                End If

                If p.Visits.Count > 0 Then
                    lblLastVisitValue.Text = p.Visits(0).Diagnosis & " (" & p.Visits(0).VisitDate & ")"
                Else
                    lblLastVisitValue.Text = "First clinic visit on record"
                End If
            Else
                lblConditionsValue.Text = "Not specified"
                cardAllergyAlert.BackColor = ClinicData.Hx("#F4F7F9")
                cardAllergyAlert.BorderColor = ClinicData.Hx("#DCE4E8")
                lblAllergyText.ForeColor = ClinicData.Hx("#738791")
                lblAllergyText.Text = "No patient chart found"
                lblPatientAllergy.Text = "Allergies unrecorded"
                lblPatientAllergy.ForeColor = ClinicData.Hx("#738791")
                lblLastVisitValue.Text = "No previous visits on record"
            End If

            ' Dynamically position sub-labels to prevent text collisions
            lblPatientAllergy.Left = lblPatientAgeSex.Right + 16
            lblPatientReason.Left = lblPatientAllergy.Right + 16
        Else
            Dim nextPending = ClinicData.NextPending()
            lblPatientName.Text = "No patient selected"
            If nextPending IsNot Nothing Then
                lblPatientAgeSex.Text = $"👉 Click here to start next waiting patient ({nextPending.PatientName}), or select from Appointments."
                lblPatientAgeSex.ForeColor = ClinicData.Hx("#238978")
                lblPatientAgeSex.Cursor = Cursors.Hand
            Else
                lblPatientAgeSex.Text = "No patients currently waiting in queue. New check-ins will appear here."
                lblPatientAgeSex.ForeColor = ClinicData.Hx("#738791")
                lblPatientAgeSex.Cursor = Cursors.Default
            End If
            lblPatientAllergy.Text = ""
            lblPatientReason.Text = ""

            txtSymptoms.Text = ""
            txtDiagnosis.Text = ""
            txtMedication.Text = ""
            txtAdvice.Text = ""

            lblVitalBp.Text = "BP —"
            lblVitalPulse.Text = "Pulse —"
            lblVitalTemp.Text = "Temperature —"
            lblVitalSpo2.Text = "SpO₂ —"

            lblConditionsValue.Text = "—"
            lblAllergyText.Text = "—"
            lblLastVisitValue.Text = "—"
        End If

        Dim isDone As Boolean = hasPatient AndAlso a.Status = "Completed"
        Dim editable As Boolean = hasPatient AndAlso Not isDone

        txtSymptoms.ReadOnly = Not editable
        txtDiagnosis.ReadOnly = Not editable
        txtMedication.ReadOnly = Not editable
        txtAdvice.ReadOnly = Not editable
        btnSaveComplete.Enabled = editable
        btnSaveDraft.Enabled = editable

        If btnEditVitals IsNot Nothing Then
            btnEditVitals.Enabled = editable
            Dim hasAnyVitals = hasPatient AndAlso (Not String.IsNullOrWhiteSpace(a.Bp) OrElse Not String.IsNullOrWhiteSpace(a.Pulse) OrElse Not String.IsNullOrWhiteSpace(a.Temperature) OrElse Not String.IsNullOrWhiteSpace(a.Spo2))
            btnEditVitals.Text = If(hasAnyVitals, "✎ Edit", "✎ Record")
        End If

        If Not hasPatient Then
            SetPill("No patient", "#EEF2F4", "#4B5F69")
        ElseIf isDone Then
            SetPill("Completed", "#E6F5EB", "#28874B")
        ElseIf a.IsDraft Then
            SetPill("Draft", "#EEF2F4", "#4B5F69")
        Else
            SetPill("Pending", "#FEF3E2", "#D97706")
        End If
    End Sub

    Private Sub btnEditVitals_Click(sender As Object, e As EventArgs) Handles btnEditVitals.Click
        If _item Is Nothing Then
            MessageBox.Show("Please select a patient before recording vitals.", "Consultation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim activeDoc = If(CurrentUser.IsAuthenticated, CurrentUser.FullName, If(String.IsNullOrEmpty(_item.DoctorName), "Dr. Elena Cruz", _item.DoctorName))
        Using dlg As New DoctorRecordVitalsDialog(_item, activeDoc)
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                ApplyVitals(_item.Bp, _item.Pulse, _item.Temperature, _item.Spo2)
                Dim hasAnyVitals = Not String.IsNullOrWhiteSpace(_item.Bp) OrElse Not String.IsNullOrWhiteSpace(_item.Pulse) OrElse Not String.IsNullOrWhiteSpace(_item.Temperature) OrElse Not String.IsNullOrWhiteSpace(_item.Spo2)
                btnEditVitals.Text = If(hasAnyVitals, "✎ Edit", "✎ Record")
            End If
        End Using
    End Sub

    Private Sub ApplyVitals(bp As String, pulse As String, temp As String, spo2 As String)
        ' 1. Blood Pressure Check
        If String.IsNullOrWhiteSpace(bp) OrElse bp.Trim() = "—" Then
            lblVitalBp.Text = "BP —"
            lblVitalBp.ForeColor = ClinicData.Hx("#738791")
        Else
            lblVitalBp.Text = "BP " & bp
            Dim bpParts = bp.Split("/"c)
            If bpParts.Length = 2 Then
                Dim sys, dia As Integer
                If Integer.TryParse(bpParts(0).Trim(), sys) AndAlso Integer.TryParse(bpParts(1).Trim(), dia) Then
                    If sys >= 140 OrElse dia >= 90 Then
                        lblVitalBp.Text = "BP " & bp & " mmHg ⚠ (Stage 2 HTN)"
                        lblVitalBp.ForeColor = ClinicData.Hx("#CD504B")
                    ElseIf sys >= 130 OrElse dia >= 85 Then
                        lblVitalBp.Text = "BP " & bp & " mmHg ⚠ (Stage 1 HTN)"
                        lblVitalBp.ForeColor = ClinicData.Hx("#D97706")
                    Else
                        lblVitalBp.Text = "BP " & bp & " mmHg"
                        lblVitalBp.ForeColor = ClinicData.Hx("#2D3C46")
                    End If
                End If
            Else
                lblVitalBp.ForeColor = ClinicData.Hx("#2D3C46")
            End If
        End If

        ' 2. Pulse Rate Check
        If String.IsNullOrWhiteSpace(pulse) OrElse pulse.Trim() = "—" Then
            lblVitalPulse.Text = "Pulse —"
            lblVitalPulse.ForeColor = ClinicData.Hx("#738791")
        Else
            lblVitalPulse.Text = "Pulse " & pulse
            Dim pulseNum As Integer
            Dim cleanPulse = System.Text.RegularExpressions.Regex.Match(pulse, "\d+").Value
            If Integer.TryParse(cleanPulse, pulseNum) Then
                If pulseNum > 100 Then
                    lblVitalPulse.Text = "Pulse " & pulse & " ⚠ (Tachycardia)"
                    lblVitalPulse.ForeColor = ClinicData.Hx("#D97706")
                ElseIf pulseNum < 60 AndAlso pulseNum > 0 Then
                    lblVitalPulse.Text = "Pulse " & pulse & " ⚠ (Bradycardia)"
                    lblVitalPulse.ForeColor = ClinicData.Hx("#D97706")
                Else
                    lblVitalPulse.ForeColor = ClinicData.Hx("#2D3C46")
                End If
            Else
                lblVitalPulse.ForeColor = ClinicData.Hx("#2D3C46")
            End If
        End If

        ' 3. Body Temperature Check
        If String.IsNullOrWhiteSpace(temp) OrElse temp.Trim() = "—" Then
            lblVitalTemp.Text = "Temperature —"
            lblVitalTemp.ForeColor = ClinicData.Hx("#738791")
        Else
            lblVitalTemp.Text = "Temp " & temp
            Dim tempNum As Double
            Dim cleanTemp = System.Text.RegularExpressions.Regex.Match(temp, "\d+(\.\d+)?").Value
            If Double.TryParse(cleanTemp, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, tempNum) Then
                If tempNum >= 38.0 Then
                    lblVitalTemp.Text = "Temp " & temp & " ⚠ (Fever)"
                    lblVitalTemp.ForeColor = ClinicData.Hx("#CD504B")
                ElseIf tempNum >= 37.5 Then
                    lblVitalTemp.Text = "Temp " & temp & " ⚠ (Elevated)"
                    lblVitalTemp.ForeColor = ClinicData.Hx("#D97706")
                Else
                    lblVitalTemp.ForeColor = ClinicData.Hx("#2D3C46")
                End If
            Else
                lblVitalTemp.ForeColor = ClinicData.Hx("#2D3C46")
            End If
        End If

        ' 4. SpO2 Oxygen Saturation Check
        If String.IsNullOrWhiteSpace(spo2) OrElse spo2.Trim() = "—" Then
            lblVitalSpo2.Text = "SpO₂ —"
            lblVitalSpo2.ForeColor = ClinicData.Hx("#738791")
        Else
            lblVitalSpo2.Text = "SpO₂ " & spo2
            Dim spo2Num As Integer
            Dim cleanSpo2 = System.Text.RegularExpressions.Regex.Match(spo2, "\d+").Value
            If Integer.TryParse(cleanSpo2, spo2Num) Then
                If spo2Num < 95 AndAlso spo2Num > 0 Then
                    lblVitalSpo2.Text = "SpO₂ " & spo2 & " ⚠ (Low O₂)"
                    lblVitalSpo2.ForeColor = ClinicData.Hx("#CD504B")
                Else
                    lblVitalSpo2.ForeColor = ClinicData.Hx("#2D3C46")
                End If
            Else
                lblVitalSpo2.ForeColor = ClinicData.Hx("#2D3C46")
            End If
        End If

        If btnEditVitals IsNot Nothing Then
            Dim hasAny = Not String.IsNullOrWhiteSpace(bp) OrElse Not String.IsNullOrWhiteSpace(pulse) OrElse Not String.IsNullOrWhiteSpace(temp) OrElse Not String.IsNullOrWhiteSpace(spo2)
            btnEditVitals.Text = If(hasAny, "✎ Edit", "✎ Record")
        End If
    End Sub

    Private Sub SetPill(text As String, backHex As String, foreHex As String)
        Dim bg As Color = ClinicData.Hx(backHex)
        Dim w As Integer = Math.Max(70, TextRenderer.MeasureText(text, lblPending.Font).Width + 28)

        cardPending.BackColor = bg
        cardPending.BorderColor = bg
        cardPending.BorderHoverColor = bg
        cardPending.HoverTintColor = bg
        cardPending.Width = w
        cardPending.Left = 803 - w            ' keep the pill right-aligned

        lblPending.BackColor = bg
        lblPending.ForeColor = ClinicData.Hx(foreHex)
        lblPending.Width = w
        lblPending.Text = text

        cardPending.Invalidate()
    End Sub

    Private Sub CaptureFields()
        _item.Symptoms = txtSymptoms.Text.Trim()
        _item.Diagnosis = txtDiagnosis.Text.Trim()
        _item.Medication = txtMedication.Text.Trim()
        _item.Advice = txtAdvice.Text.Trim()
    End Sub

    Private Sub btnBackToDirectory_Click(sender As Object, e As EventArgs) Handles btnBackToDirectory.Click
        If DoctorShell.Current IsNot Nothing Then
            DoctorShell.Current.NavigateTo(DoctorTab.Consultation)
        End If
    End Sub

    Private Sub btnSaveDraft_Click(sender As Object, e As EventArgs) Handles btnSaveDraft.Click
        If _item Is Nothing Then Return

        CaptureFields()
        _item.IsDraft = True
        SqliteAppointmentRepository.UpdateAppointment(_item)
        ClinicData.NotifyDataChanged()
        SetPill("Draft", "#EEF2F4", "#4B5F69")

        MessageBox.Show("Draft consultation saved.", "Consultation", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnSaveComplete_Click(sender As Object, e As EventArgs) Handles btnSaveComplete.Click
        If _item Is Nothing Then Return

        If txtSymptoms.Text.Trim() = "" OrElse txtDiagnosis.Text.Trim() = "" Then
            MessageBox.Show("Please fill in the symptoms/findings and the diagnosis before completing the consultation.",
                            "Consultation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        CaptureFields()
        _item.IsDraft = False
        _item.Status = "Completed"
        SqliteAppointmentRepository.UpdateAppointment(_item)

        ' Sync newly completed consultation into the patient's longitudinal chart in SQLite
        Dim docName = If(CurrentUser.IsAuthenticated, CurrentUser.FullName, If(String.IsNullOrEmpty(_item.DoctorName), "Dr. Elena Cruz", _item.DoctorName))
        Dim visitDateStr As String = DateTime.Now.ToString("MMM dd, yyyy")
        SqlitePatientRepository.AddVisit(_item.PatientId, New VisitItem(visitDateStr, _item.VisitType, _item.Diagnosis, docName, "Completed"))
        AuditStore.Log(docName, "Doctor", "Consultation completed", $"Patient {_item.PatientName} ({_item.PatientId}) consultation recorded", "Success")

        ClinicData.NotifyDataChanged()

        LoadAppointment(_item)          ' locks the form and shows the Completed pill

        ' Offer Follow-up appointment scheduling with customizable clinical intervals
        PromptScheduleFollowUp(_item.PatientName, _item.Day, txtDiagnosis.Text)

        Dim docShort = If(String.IsNullOrEmpty(docName), "", docName.Replace("Dr.", "").Trim())
        Dim docFilter = Function(dName As String) As Boolean
                            If String.IsNullOrWhiteSpace(dName) Then Return False
                            If dName.Equals(docName, StringComparison.OrdinalIgnoreCase) Then Return True
                            If Not String.IsNullOrEmpty(docShort) AndAlso dName.IndexOf(docShort, StringComparison.OrdinalIgnoreCase) >= 0 Then Return True
                            If docName.IndexOf("Cruz", StringComparison.OrdinalIgnoreCase) >= 0 AndAlso dName.IndexOf("Cruz", StringComparison.OrdinalIgnoreCase) >= 0 Then Return True
                            If docName.IndexOf("Lim", StringComparison.OrdinalIgnoreCase) >= 0 AndAlso dName.IndexOf("Lim", StringComparison.OrdinalIgnoreCase) >= 0 Then Return True
                            Return False
                        End Function

        Dim nextPending = ClinicData.Appointments.FirstOrDefault(Function(a) a.MatchesDate(DateTime.Today) AndAlso a.Status = "Pending" AndAlso docFilter(a.DoctorName))
        If nextPending Is Nothing AndAlso (Not CurrentUser.IsAuthenticated OrElse docName.IndexOf("Cruz", StringComparison.OrdinalIgnoreCase) >= 0) Then
            nextPending = ClinicData.Appointments.FirstOrDefault(Function(a) a.Status = "Pending" AndAlso docFilter(a.DoctorName))
        End If
        If nextPending IsNot Nothing Then
            Dim askNext = MessageBox.Show(
                $"Next waiting patient: {nextPending.PatientName} ({nextPending.VisitType})" & vbCrLf & vbCrLf &
                "Would you like to start the consultation for the next waiting patient now?",
                "Next Patient in Queue", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If askNext = DialogResult.Yes Then
                LoadAppointment(nextPending)
                Return
            End If
        Else
            MessageBox.Show("All scheduled patient consultations for today have been completed!",
                            "Consultations Completed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        ' Clear the completed session and return to Consultation Directory
        LoadAppointment(Nothing)
        If DoctorShell.Current IsNot Nothing Then
            DoctorShell.Current.NavigateTo(DoctorTab.Consultation)
        End If
    End Sub

    Private Sub btnPrintRx_Click(sender As Object, e As EventArgs) Handles btnPrintRx.Click
        If _item Is Nothing Then
            MessageBox.Show("Please select an active patient appointment before generating a prescription.",
                            "Print Prescription", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim allergies As String = ""
        Dim pat = PatientRepository.GetById(_item.PatientId)
        If pat IsNot Nothing AndAlso pat.HasAllergies Then
            allergies = pat.DrugAllergies
        End If

        Dim dlg As New DoctorPrescriptionDialog(_item.PatientName, _item.PatientId,
                                          _item.Age & " years • " & _item.Sex,
                                          txtMedication.Text.Trim(),
                                          txtAdvice.Text.Trim(),
                                          allergies)
        dlg.ShowDialog(Me)
    End Sub

    Private Sub btnPrintLab_Click(sender As Object, e As EventArgs) Handles btnPrintLab.Click
        If _item Is Nothing Then
            MessageBox.Show("Please select an active patient appointment before generating a laboratory request.",
                            "Laboratory Request", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim cond As String = If(lblConditionsValue IsNot Nothing, lblConditionsValue.Text, "")
        Dim dlg As New DoctorLaboratoryDialog(_item.PatientName, _item.PatientId,
                                        _item.Age & " years • " & _item.Sex,
                                        txtDiagnosis.Text.Trim(),
                                        cond)
        dlg.ShowDialog(Me)
    End Sub

    Private Sub btnViewFullChart_Click(sender As Object, e As EventArgs) Handles btnViewFullChart.Click
        If _item Is Nothing Then Return
        If DoctorShell.Current IsNot Nothing Then
            DoctorShell.Current.OpenPatient(_item.PatientId, DoctorTab.Consultation)
        Else
            Dim f As New DoctorPatientInformation(_item.PatientId)
            f.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub lblPatientAgeSex_Click(sender As Object, e As EventArgs) Handles lblPatientAgeSex.Click
        If _item Is Nothing Then
            Dim nextPending = ClinicData.NextPending()
            If nextPending IsNot Nothing Then
                LoadAppointment(nextPending)
            End If
        End If
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
        If DoctorShell.Current IsNot Nothing Then
            DoctorShell.Current.NavigateTo(DoctorTab.Schedule)
        Else
            Dim f As New DoctorSchedule()
            f.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub btnConsultation_Click(sender As Object, e As EventArgs) Handles btnConsultation.Click
        If DoctorShell.Current IsNot Nothing Then DoctorShell.Current.NavigateTo(DoctorTab.Consultation)
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

    Private Sub DoctorConsultation_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If DoctorShell.Current Is Nothing Then
            Application.Exit()
        End If
    End Sub

    Private Function PromptScheduleFollowUp(patientName As String, currentDay As Integer, diagnosis As String) As Boolean
        Using f As New Form()
            f.Text = "Schedule Clinical Follow-Up"
            f.Size = New Size(400, 270)
            f.StartPosition = FormStartPosition.CenterParent
            f.FormBorderStyle = FormBorderStyle.FixedDialog
            f.MaximizeBox = False
            f.MinimizeBox = False
            f.BackColor = Color.FromArgb(244, 247, 249)

            Dim lblPrompt As New Label With {
                .Text = $"Select follow-up schedule for {patientName}:",
                .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(22, 51, 65),
                .Location = New Point(20, 16),
                .Size = New Size(350, 24)
            }

            Dim lblInterval As New Label With {
                .Text = "Follow-up interval:",
                .Font = New Font("Segoe UI", 8.5F, FontStyle.Regular),
                .ForeColor = Color.FromArgb(115, 138, 148),
                .Location = New Point(20, 48),
                .AutoSize = True
            }

            Dim cboInterval As New ComboBox With {
                .DropDownStyle = ComboBoxStyle.DropDownList,
                .Location = New Point(20, 68),
                .Size = New Size(345, 25),
                .Font = New Font("Segoe UI", 9.0F)
            }
            cboInterval.Items.AddRange(New Object() {
                "In 3 Days (Day " & Math.Min(31, currentDay + 3) & ")",
                "In 1 Week / 7 Days (Day " & Math.Min(31, currentDay + 7) & ")",
                "In 2 Weeks / 14 Days (Day " & Math.Min(31, currentDay + 14) & ")",
                "In 1 Month / 30 Days (Day " & Math.Min(31, currentDay + 30) & ")"
            })
            cboInterval.SelectedIndex = 1 ' Default to 1 week

            Dim lblTime As New Label With {
                .Text = "Preferred time slot:",
                .Font = New Font("Segoe UI", 8.5F, FontStyle.Regular),
                .ForeColor = Color.FromArgb(115, 138, 148),
                .Location = New Point(20, 104),
                .AutoSize = True
            }

            Dim cboTime As New ComboBox With {
                .DropDownStyle = ComboBoxStyle.DropDownList,
                .Location = New Point(20, 124),
                .Size = New Size(345, 25),
                .Font = New Font("Segoe UI", 9.0F)
            }
            cboTime.Items.AddRange(New Object() {"9:00 AM (Morning session)", "10:00 AM (Morning session)", "2:00 PM (Afternoon session)", "3:30 PM (Afternoon session)"})
            cboTime.SelectedIndex = 1 ' 10:00 AM

            Dim btnBook As New Ferrando.UI.WinForms.Controles.FButton With {
                .Text = "Book Follow-Up",
                .Location = New Point(225, 175),
                .Size = New Size(140, 34),
                .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
                .Cursor = Cursors.Hand
            }
            UIThemeHelper.ApplyPrimary(btnBook)

            Dim btnSkip As New Ferrando.UI.WinForms.Controles.FButton With {
                .Text = "No Follow-Up",
                .Location = New Point(105, 175),
                .Size = New Size(110, 34),
                .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
                .Cursor = Cursors.Hand
            }
            UIThemeHelper.ApplySecondary(btnSkip)

            AddHandler btnBook.Click, Sub()
                                         Dim intervalDays = 7
                                         Select Case cboInterval.SelectedIndex
                                             Case 0 : intervalDays = 3
                                             Case 1 : intervalDays = 7
                                             Case 2 : intervalDays = 14
                                             Case 3 : intervalDays = 30
                                         End Select
                                         Dim targetDay As Integer = Math.Min(31, currentDay + intervalDays)

                                         Dim mins As Integer = 600
                                         Select Case cboTime.SelectedIndex
                                             Case 0 : mins = 540 ' 9:00 AM
                                             Case 1 : mins = 600 ' 10:00 AM
                                             Case 2 : mins = 840 ' 2:00 PM
                                             Case 3 : mins = 930 ' 3:30 PM
                                         End Select

                                         Dim timeLabel = cboTime.SelectedItem.ToString().Split("("c)(0).Trim()
                                         ClinicData.AddAppointment(New AppointmentItem With {
                                             .Day = targetDay,
                                             .Minutes = mins,
                                             .PatientId = _item.PatientId,
                                             .PatientName = _item.PatientName,
                                             .Age = _item.Age,
                                             .Sex = _item.Sex,
                                             .DoctorName = If(CurrentUser.IsAuthenticated, CurrentUser.FullName, If(String.IsNullOrEmpty(_item.DoctorName), "Dr. Elena Cruz", _item.DoctorName)),
                                             .DoctorRole = "General Physician",
                                             .VisitType = "Follow-up",
                                             .Status = "Confirmed",
                                             .Reason = "Follow-up evaluation",
                                             .Note = "Follow-up for " & If(String.IsNullOrWhiteSpace(diagnosis), "previous consultation", diagnosis.Trim())
                                         })
                                         Dim auditDoc = If(CurrentUser.IsAuthenticated, CurrentUser.FullName, If(String.IsNullOrEmpty(_item.DoctorName), "Dr. Elena Cruz", _item.DoctorName))
                                         AuditStore.Log(auditDoc, "Doctor", "Follow-up scheduled", $"Follow-up booked for {_item.PatientName} on Day {targetDay} at {timeLabel}", "Success")
                                         MessageBox.Show($"Follow-up appointment booked for {_item.PatientName} on Day {targetDay} at {timeLabel}.",
                                                         "Follow-Up Scheduled", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                         f.DialogResult = DialogResult.OK
                                         f.Close()
                                     End Sub

            AddHandler btnSkip.Click, Sub()
                                         f.DialogResult = DialogResult.Cancel
                                         f.Close()
                                     End Sub

            f.Controls.AddRange(New Control() {lblPrompt, lblInterval, cboInterval, lblTime, cboTime, btnSkip, btnBook})
            f.AcceptButton = btnBook
            Return f.ShowDialog(Me) = DialogResult.OK
        End Using
    End Function

End Class

' Compatibility alias
Public Class Consultation
    Inherits DoctorConsultation

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(item As AppointmentItem)
        MyBase.New(item)
    End Sub
End Class