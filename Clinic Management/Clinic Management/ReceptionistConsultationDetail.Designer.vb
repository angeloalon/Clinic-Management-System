<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReceptionistConsultationDetail
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblTitle = New Label()
        lblSubtitle = New Label()
        btnBack = New Ferrando.UI.WinForms.Controles.FButton()
        lblPatientName = New Label()
        lblPatientMeta = New Label()
        cardPatient = New Ferrando.UI.WinForms.Controles.FCard()
        lblAssessmentTitle = New Label()
        lblSymptomsHdr = New Label()
        txtSymptoms = New TextBox()
        cardSymptoms = New Ferrando.UI.WinForms.Controles.FCard()
        lblDiagnosisHdr = New Label()
        txtDiagnosis = New TextBox()
        cardDiagnosis = New Ferrando.UI.WinForms.Controles.FCard()
        cardAssessment = New Ferrando.UI.WinForms.Controles.FCard()
        lblPrescriptionTitle = New Label()
        lblMedicationHdr = New Label()
        txtMedication = New TextBox()
        cardMedication = New Ferrando.UI.WinForms.Controles.FCard()
        lblAdviceHdr = New Label()
        txtAdvice = New TextBox()
        cardAdvice = New Ferrando.UI.WinForms.Controles.FCard()
        cardPrescription = New Ferrando.UI.WinForms.Controles.FCard()
        lblVitalsTitle = New Label()
        lblBP = New Label()
        lblPulse = New Label()
        lblTemp = New Label()
        lblSpO2 = New Label()
        cardVitals = New Ferrando.UI.WinForms.Controles.FCard()
        cardPatient.SuspendLayout()
        cardSymptoms.SuspendLayout()
        cardDiagnosis.SuspendLayout()
        cardAssessment.SuspendLayout()
        cardMedication.SuspendLayout()
        cardAdvice.SuspendLayout()
        cardPrescription.SuspendLayout()
        cardVitals.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.BackColor = Color.Transparent
        lblTitle.Font = New Font("Segoe UI", 18.0F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblTitle.ForeColor = Color.FromArgb(22, 51, 65)
        lblTitle.Location = New Point(26, 20)
        lblTitle.Name = "lblTitle"
        lblTitle.TabIndex = 0
        lblTitle.Text = "Consultation record"
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.AutoSize = True
        lblSubtitle.BackColor = Color.Transparent
        lblSubtitle.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblSubtitle.ForeColor = Color.FromArgb(115, 138, 148)
        lblSubtitle.Location = New Point(28, 58)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "Appointment"
        ' 
        ' btnBack
        ' 
        btnBack.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnBack.BackColor = Color.White
        btnBack.BorderColor = Color.FromArgb(220, 230, 235)
        btnBack.BorderRadius = 8
        btnBack.BorderSize = 1
        btnBack.Cursor = Cursors.Hand
        btnBack.FlatAppearance.BorderSize = 0
        btnBack.FlatStyle = FlatStyle.Flat
        btnBack.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0)
        btnBack.ForeColor = Color.FromArgb(30, 45, 55)
        btnBack.Location = New Point(630, 24)
        btnBack.MouseEnterBackColor = Color.FromArgb(245, 249, 251)
        btnBack.MouseEnterBorderColor = Color.FromArgb(35, 137, 120)
        btnBack.MouseEnterBorderSize = 1
        btnBack.MouseEnterFont = New Font("Segoe UI", 8.25F)
        btnBack.MouseEnterForeColor = Color.FromArgb(35, 137, 120)
        btnBack.MouseLeaveBackColor = Color.White
        btnBack.MouseLeaveBorderColor = Color.FromArgb(220, 230, 235)
        btnBack.MouseLeaveBorderSize = 1
        btnBack.MouseLeaveFont = New Font("Segoe UI", 8.25F)
        btnBack.MouseLeaveForeColor = Color.FromArgb(30, 45, 55)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(172, 32)
        btnBack.TabIndex = 2
        btnBack.Text = "< Back to consultations"
        btnBack.UseVisualStyleBackColor = False
        ' 
        ' lblPatientName
        ' 
        lblPatientName.AutoSize = True
        lblPatientName.BackColor = Color.White
        lblPatientName.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0)
        lblPatientName.ForeColor = Color.FromArgb(30, 45, 55)
        lblPatientName.Location = New Point(18, 14)
        lblPatientName.Name = "lblPatientName"
        lblPatientName.TabIndex = 0
        lblPatientName.Text = "Patient"
        ' 
        ' lblPatientMeta
        ' 
        lblPatientMeta.AutoSize = True
        lblPatientMeta.BackColor = Color.White
        lblPatientMeta.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblPatientMeta.ForeColor = Color.FromArgb(115, 135, 145)
        lblPatientMeta.Location = New Point(18, 40)
        lblPatientMeta.Name = "lblPatientMeta"
        lblPatientMeta.TabIndex = 1
        lblPatientMeta.Text = "meta"
        ' 
        ' cardPatient
        ' 
        cardPatient.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        cardPatient.BackColor = Color.White
        cardPatient.BorderColor = Color.FromArgb(232, 237, 240)
        cardPatient.BorderHoverColor = Color.FromArgb(232, 237, 240)
        cardPatient.BorderRadius = 12
        cardPatient.EnableShadow = True
        cardPatient.ShadowDepth = 4
        cardPatient.BorderSize = 1
        cardPatient.Controls.Add(lblPatientMeta)
        cardPatient.Controls.Add(lblPatientName)
        cardPatient.HoverTintColor = Color.White
        cardPatient.Location = New Point(28, 92)
        cardPatient.Name = "cardPatient"
        cardPatient.Padding = New Padding(0)
        cardPatient.Size = New Size(774, 68)
        cardPatient.TabIndex = 3
        ' 
        ' lblAssessmentTitle
        ' 
        lblAssessmentTitle.AutoSize = True
        lblAssessmentTitle.BackColor = Color.White
        lblAssessmentTitle.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0)
        lblAssessmentTitle.ForeColor = Color.FromArgb(30, 45, 55)
        lblAssessmentTitle.Location = New Point(16, 16)
        lblAssessmentTitle.Name = "lblAssessmentTitle"
        lblAssessmentTitle.TabIndex = 0
        lblAssessmentTitle.Text = "Assessment"
        ' 
        ' lblSymptomsHdr
        ' 
        lblSymptomsHdr.AutoSize = True
        lblSymptomsHdr.BackColor = Color.White
        lblSymptomsHdr.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, 0)
        lblSymptomsHdr.ForeColor = Color.FromArgb(115, 135, 145)
        lblSymptomsHdr.Location = New Point(16, 46)
        lblSymptomsHdr.Name = "lblSymptomsHdr"
        lblSymptomsHdr.TabIndex = 1
        lblSymptomsHdr.Text = "SYMPTOMS AND FINDINGS"
        ' 
        ' txtSymptoms
        ' 
        txtSymptoms.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtSymptoms.BackColor = Color.White
        txtSymptoms.BorderStyle = BorderStyle.None
        txtSymptoms.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, 0)
        txtSymptoms.ForeColor = Color.FromArgb(30, 45, 55)
        txtSymptoms.Location = New Point(12, 6)
        txtSymptoms.Name = "txtSymptoms"
        txtSymptoms.Size = New Size(498, 16)
        txtSymptoms.TabIndex = 0
        ' 
        ' cardSymptoms
        ' 
        cardSymptoms.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        cardSymptoms.BackColor = Color.White
        cardSymptoms.BorderColor = Color.FromArgb(220, 228, 232)
        cardSymptoms.BorderHoverColor = Color.FromArgb(35, 137, 120)
        cardSymptoms.BorderRadius = 8
        cardSymptoms.EnableShadow = False
        cardSymptoms.ShadowDepth = 2
        cardSymptoms.BorderSize = 1
        cardSymptoms.Controls.Add(txtSymptoms)
        cardSymptoms.HoverTintColor = Color.White
        cardSymptoms.Location = New Point(16, 62)
        cardSymptoms.Name = "cardSymptoms"
        cardSymptoms.Padding = New Padding(0)
        cardSymptoms.Size = New Size(510, 30)
        cardSymptoms.TabIndex = 2
        ' 
        ' lblDiagnosisHdr
        ' 
        lblDiagnosisHdr.AutoSize = True
        lblDiagnosisHdr.BackColor = Color.White
        lblDiagnosisHdr.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, 0)
        lblDiagnosisHdr.ForeColor = Color.FromArgb(115, 135, 145)
        lblDiagnosisHdr.Location = New Point(16, 102)
        lblDiagnosisHdr.Name = "lblDiagnosisHdr"
        lblDiagnosisHdr.TabIndex = 3
        lblDiagnosisHdr.Text = "DIAGNOSIS"
        ' 
        ' txtDiagnosis
        ' 
        txtDiagnosis.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtDiagnosis.BackColor = Color.White
        txtDiagnosis.BorderStyle = BorderStyle.None
        txtDiagnosis.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, 0)
        txtDiagnosis.ForeColor = Color.FromArgb(30, 45, 55)
        txtDiagnosis.Location = New Point(12, 6)
        txtDiagnosis.Name = "txtDiagnosis"
        txtDiagnosis.Size = New Size(498, 16)
        txtDiagnosis.TabIndex = 0
        ' 
        ' cardDiagnosis
        ' 
        cardDiagnosis.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        cardDiagnosis.BackColor = Color.White
        cardDiagnosis.BorderColor = Color.FromArgb(220, 228, 232)
        cardDiagnosis.BorderHoverColor = Color.FromArgb(35, 137, 120)
        cardDiagnosis.BorderRadius = 8
        cardDiagnosis.EnableShadow = False
        cardDiagnosis.ShadowDepth = 2
        cardDiagnosis.BorderSize = 1
        cardDiagnosis.Controls.Add(txtDiagnosis)
        cardDiagnosis.HoverTintColor = Color.White
        cardDiagnosis.Location = New Point(16, 118)
        cardDiagnosis.Name = "cardDiagnosis"
        cardDiagnosis.Padding = New Padding(0)
        cardDiagnosis.Size = New Size(510, 30)
        cardDiagnosis.TabIndex = 4
        ' 
        ' cardAssessment
        ' 
        cardAssessment.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        cardAssessment.BackColor = Color.White
        cardAssessment.BorderColor = Color.FromArgb(232, 237, 240)
        cardAssessment.BorderHoverColor = Color.FromArgb(232, 237, 240)
        cardAssessment.BorderRadius = 12
        cardAssessment.EnableShadow = True
        cardAssessment.ShadowDepth = 4
        cardAssessment.BorderSize = 1
        cardAssessment.Controls.Add(cardDiagnosis)
        cardAssessment.Controls.Add(lblDiagnosisHdr)
        cardAssessment.Controls.Add(cardSymptoms)
        cardAssessment.Controls.Add(lblSymptomsHdr)
        cardAssessment.Controls.Add(lblAssessmentTitle)
        cardAssessment.HoverTintColor = Color.White
        cardAssessment.Location = New Point(28, 176)
        cardAssessment.Name = "cardAssessment"
        cardAssessment.Padding = New Padding(0)
        cardAssessment.Size = New Size(542, 164)
        cardAssessment.TabIndex = 4
        ' 
        ' lblPrescriptionTitle
        ' 
        lblPrescriptionTitle.AutoSize = True
        lblPrescriptionTitle.BackColor = Color.White
        lblPrescriptionTitle.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0)
        lblPrescriptionTitle.ForeColor = Color.FromArgb(30, 45, 55)
        lblPrescriptionTitle.Location = New Point(16, 16)
        lblPrescriptionTitle.Name = "lblPrescriptionTitle"
        lblPrescriptionTitle.TabIndex = 0
        lblPrescriptionTitle.Text = "Prescription and plan"
        ' 
        ' lblMedicationHdr
        ' 
        lblMedicationHdr.AutoSize = True
        lblMedicationHdr.BackColor = Color.White
        lblMedicationHdr.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, 0)
        lblMedicationHdr.ForeColor = Color.FromArgb(115, 135, 145)
        lblMedicationHdr.Location = New Point(16, 46)
        lblMedicationHdr.Name = "lblMedicationHdr"
        lblMedicationHdr.TabIndex = 1
        lblMedicationHdr.Text = "MEDICATION"
        ' 
        ' txtMedication
        ' 
        txtMedication.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtMedication.BackColor = Color.White
        txtMedication.BorderStyle = BorderStyle.None
        txtMedication.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, 0)
        txtMedication.ForeColor = Color.FromArgb(30, 45, 55)
        txtMedication.Location = New Point(12, 6)
        txtMedication.Name = "txtMedication"
        txtMedication.Size = New Size(498, 16)
        txtMedication.TabIndex = 0
        ' 
        ' cardMedication
        ' 
        cardMedication.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        cardMedication.BackColor = Color.White
        cardMedication.BorderColor = Color.FromArgb(220, 228, 232)
        cardMedication.BorderHoverColor = Color.FromArgb(35, 137, 120)
        cardMedication.BorderRadius = 8
        cardMedication.EnableShadow = False
        cardMedication.ShadowDepth = 2
        cardMedication.BorderSize = 1
        cardMedication.Controls.Add(txtMedication)
        cardMedication.HoverTintColor = Color.White
        cardMedication.Location = New Point(16, 62)
        cardMedication.Name = "cardMedication"
        cardMedication.Padding = New Padding(0)
        cardMedication.Size = New Size(510, 30)
        cardMedication.TabIndex = 2
        ' 
        ' lblAdviceHdr
        ' 
        lblAdviceHdr.AutoSize = True
        lblAdviceHdr.BackColor = Color.White
        lblAdviceHdr.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, 0)
        lblAdviceHdr.ForeColor = Color.FromArgb(115, 135, 145)
        lblAdviceHdr.Location = New Point(16, 102)
        lblAdviceHdr.Name = "lblAdviceHdr"
        lblAdviceHdr.TabIndex = 3
        lblAdviceHdr.Text = "ADVICE"
        ' 
        ' txtAdvice
        ' 
        txtAdvice.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtAdvice.BackColor = Color.White
        txtAdvice.BorderStyle = BorderStyle.None
        txtAdvice.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, 0)
        txtAdvice.ForeColor = Color.FromArgb(30, 45, 55)
        txtAdvice.Location = New Point(12, 6)
        txtAdvice.Name = "txtAdvice"
        txtAdvice.Size = New Size(498, 16)
        txtAdvice.TabIndex = 0
        ' 
        ' cardAdvice
        ' 
        cardAdvice.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        cardAdvice.BackColor = Color.White
        cardAdvice.BorderColor = Color.FromArgb(220, 228, 232)
        cardAdvice.BorderHoverColor = Color.FromArgb(35, 137, 120)
        cardAdvice.BorderRadius = 8
        cardAdvice.EnableShadow = False
        cardAdvice.ShadowDepth = 2
        cardAdvice.BorderSize = 1
        cardAdvice.Controls.Add(txtAdvice)
        cardAdvice.HoverTintColor = Color.White
        cardAdvice.Location = New Point(16, 118)
        cardAdvice.Name = "cardAdvice"
        cardAdvice.Padding = New Padding(0)
        cardAdvice.Size = New Size(510, 30)
        cardAdvice.TabIndex = 4
        ' 
        ' cardPrescription
        ' 
        cardPrescription.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        cardPrescription.BackColor = Color.White
        cardPrescription.BorderColor = Color.FromArgb(232, 237, 240)
        cardPrescription.BorderHoverColor = Color.FromArgb(232, 237, 240)
        cardPrescription.BorderRadius = 12
        cardPrescription.EnableShadow = True
        cardPrescription.ShadowDepth = 4
        cardPrescription.BorderSize = 1
        cardPrescription.Controls.Add(cardAdvice)
        cardPrescription.Controls.Add(lblAdviceHdr)
        cardPrescription.Controls.Add(cardMedication)
        cardPrescription.Controls.Add(lblMedicationHdr)
        cardPrescription.Controls.Add(lblPrescriptionTitle)
        cardPrescription.HoverTintColor = Color.White
        cardPrescription.Location = New Point(28, 356)
        cardPrescription.Name = "cardPrescription"
        cardPrescription.Padding = New Padding(0)
        cardPrescription.Size = New Size(542, 164)
        cardPrescription.TabIndex = 5
        ' 
        ' lblVitalsTitle
        ' 
        lblVitalsTitle.AutoSize = True
        lblVitalsTitle.BackColor = Color.White
        lblVitalsTitle.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0)
        lblVitalsTitle.ForeColor = Color.FromArgb(30, 45, 55)
        lblVitalsTitle.Location = New Point(16, 16)
        lblVitalsTitle.Name = "lblVitalsTitle"
        lblVitalsTitle.TabIndex = 0
        lblVitalsTitle.Text = "Vitals"
        ' 
        ' lblBP
        ' 
        lblBP.AutoSize = True
        lblBP.BackColor = Color.White
        lblBP.Font = New Font("Segoe UI", 8.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblBP.ForeColor = Color.FromArgb(35, 45, 55)
        lblBP.Location = New Point(16, 48)
        lblBP.Name = "lblBP"
        lblBP.TabIndex = 1
        lblBP.Text = "BP"
        ' 
        ' lblPulse
        ' 
        lblPulse.AutoSize = True
        lblPulse.BackColor = Color.White
        lblPulse.Font = New Font("Segoe UI", 8.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblPulse.ForeColor = Color.FromArgb(35, 45, 55)
        lblPulse.Location = New Point(16, 75)
        lblPulse.Name = "lblPulse"
        lblPulse.TabIndex = 2
        lblPulse.Text = "Pulse"
        ' 
        ' lblTemp
        ' 
        lblTemp.AutoSize = True
        lblTemp.BackColor = Color.White
        lblTemp.Font = New Font("Segoe UI", 8.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblTemp.ForeColor = Color.FromArgb(35, 45, 55)
        lblTemp.Location = New Point(16, 102)
        lblTemp.Name = "lblTemp"
        lblTemp.TabIndex = 3
        lblTemp.Text = "Temperature"
        ' 
        ' lblSpO2
        ' 
        lblSpO2.AutoSize = True
        lblSpO2.BackColor = Color.White
        lblSpO2.Font = New Font("Segoe UI", 8.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblSpO2.ForeColor = Color.FromArgb(35, 45, 55)
        lblSpO2.Location = New Point(16, 129)
        lblSpO2.Name = "lblSpO2"
        lblSpO2.TabIndex = 4
        lblSpO2.Text = "SpO2"
        ' 
        ' cardVitals
        ' 
        cardVitals.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        cardVitals.BackColor = Color.White
        cardVitals.BorderColor = Color.FromArgb(232, 237, 240)
        cardVitals.BorderHoverColor = Color.FromArgb(232, 237, 240)
        cardVitals.BorderRadius = 12
        cardVitals.EnableShadow = True
        cardVitals.ShadowDepth = 4
        cardVitals.BorderSize = 1
        cardVitals.Controls.Add(lblSpO2)
        cardVitals.Controls.Add(lblTemp)
        cardVitals.Controls.Add(lblPulse)
        cardVitals.Controls.Add(lblBP)
        cardVitals.Controls.Add(lblVitalsTitle)
        cardVitals.HoverTintColor = Color.White
        cardVitals.Location = New Point(586, 176)
        cardVitals.Name = "cardVitals"
        cardVitals.Padding = New Padding(0)
        cardVitals.Size = New Size(216, 164)
        cardVitals.TabIndex = 6
        ' 
        ' ConsultationDetail
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(244, 247, 249)
        ClientSize = New Size(830, 729)
        FormBorderStyle = FormBorderStyle.None
        Controls.Add(cardVitals)
        Controls.Add(cardPrescription)
        Controls.Add(cardAssessment)
        Controls.Add(cardPatient)
        Controls.Add(btnBack)
        Controls.Add(lblSubtitle)
        Controls.Add(lblTitle)
        Name = "ReceptionistConsultationDetail"
        Text = "ReceptionistConsultationDetail"
        cardPatient.ResumeLayout(False)
        cardPatient.PerformLayout()
        cardSymptoms.ResumeLayout(False)
        cardSymptoms.PerformLayout()
        cardDiagnosis.ResumeLayout(False)
        cardDiagnosis.PerformLayout()
        cardAssessment.ResumeLayout(False)
        cardAssessment.PerformLayout()
        cardMedication.ResumeLayout(False)
        cardMedication.PerformLayout()
        cardAdvice.ResumeLayout(False)
        cardAdvice.PerformLayout()
        cardPrescription.ResumeLayout(False)
        cardPrescription.PerformLayout()
        cardVitals.ResumeLayout(False)
        cardVitals.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents btnBack As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents lblPatientName As Label
    Friend WithEvents lblPatientMeta As Label
    Friend WithEvents cardPatient As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblAssessmentTitle As Label
    Friend WithEvents lblSymptomsHdr As Label
    Friend WithEvents txtSymptoms As TextBox
    Friend WithEvents cardSymptoms As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblDiagnosisHdr As Label
    Friend WithEvents txtDiagnosis As TextBox
    Friend WithEvents cardDiagnosis As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents cardAssessment As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblPrescriptionTitle As Label
    Friend WithEvents lblMedicationHdr As Label
    Friend WithEvents txtMedication As TextBox
    Friend WithEvents cardMedication As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblAdviceHdr As Label
    Friend WithEvents txtAdvice As TextBox
    Friend WithEvents cardAdvice As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents cardPrescription As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblVitalsTitle As Label
    Friend WithEvents lblBP As Label
    Friend WithEvents lblPulse As Label
    Friend WithEvents lblTemp As Label
    Friend WithEvents lblSpO2 As Label
    Friend WithEvents cardVitals As Ferrando.UI.WinForms.Controles.FCard

End Class

