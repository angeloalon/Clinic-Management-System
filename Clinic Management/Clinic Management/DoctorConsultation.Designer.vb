<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DoctorConsultation
    Inherits System.Windows.Forms.Form

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        sideBar = New Panel()
        namePlaceHolder = New Ferrando.UI.WinForms.Controles.FCard()
        txtRole = New Label()
        txtName = New Label()
        FCard1 = New Ferrando.UI.WinForms.Controles.FCard()
        Label3 = New Label()
        btnReports = New Ferrando.UI.WinForms.Controles.FButton()
        btnConsultation = New Ferrando.UI.WinForms.Controles.FButton()
        Label2 = New Label()
        btnDoctor = New Ferrando.UI.WinForms.Controles.FButton()
        Label1 = New Label()
        btnAppointment = New Ferrando.UI.WinForms.Controles.FButton()
        btnPatients = New Ferrando.UI.WinForms.Controles.FButton()
        btnDashboard = New Ferrando.UI.WinForms.Controles.FButton()
        mainScreen = New Panel()
        lblTitle = New Label()
        cardPending = New Ferrando.UI.WinForms.Controles.FCard()
        lblPending = New Label()
        cardPatient = New Ferrando.UI.WinForms.Controles.FCard()
        lblPatientName = New Label()
        lblPatientAgeSex = New Label()
        lblPatientAllergy = New Label()
        lblPatientReason = New Label()
        cardAssessment = New Ferrando.UI.WinForms.Controles.FCard()
        lblAssessmentTitle = New Label()
        lblSymptoms = New Label()
        cardSymptomsBox = New Ferrando.UI.WinForms.Controles.FCard()
        txtSymptoms = New TextBox()
        lblDiagnosis = New Label()
        cardDiagnosisBox = New Ferrando.UI.WinForms.Controles.FCard()
        txtDiagnosis = New TextBox()
        cardPrescription = New Ferrando.UI.WinForms.Controles.FCard()
        lblPrescriptionTitle = New Label()
        lblMedication = New Label()
        cardMedicationBox = New Ferrando.UI.WinForms.Controles.FCard()
        txtMedication = New TextBox()
        lblAdvice = New Label()
        cardAdviceBox = New Ferrando.UI.WinForms.Controles.FCard()
        txtAdvice = New TextBox()
        cardVitals = New Ferrando.UI.WinForms.Controles.FCard()
        lblVitalsTitle = New Label()
        lblVitalBp = New Label()
        lblVitalPulse = New Label()
        lblVitalTemp = New Label()
        lblVitalSpo2 = New Label()
        btnEditVitals = New Ferrando.UI.WinForms.Controles.FButton()
        cardMedicalHistory = New Ferrando.UI.WinForms.Controles.FCard()
        lblMedHistoryTitle = New Label()
        lblConditionsLabel = New Label()
        lblConditionsValue = New Label()
        lblAllergiesLabel = New Label()
        cardAllergyAlert = New Ferrando.UI.WinForms.Controles.FCard()
        lblAllergyText = New Label()
        lblLastVisitLabel = New Label()
        lblLastVisitValue = New Label()
        btnViewFullChart = New Ferrando.UI.WinForms.Controles.FButton()
        btnPrintRx = New Ferrando.UI.WinForms.Controles.FButton()
        btnPrintRxTop = New Ferrando.UI.WinForms.Controles.FButton()
        btnPrintLab = New Ferrando.UI.WinForms.Controles.FButton()
        btnPrintLabTop = New Ferrando.UI.WinForms.Controles.FButton()
        cardComplete = New Ferrando.UI.WinForms.Controles.FCard()
        lblCompleteTitle = New Label()
        btnSaveComplete = New Ferrando.UI.WinForms.Controles.FButton()
        btnSaveDraft = New Ferrando.UI.WinForms.Controles.FButton()
        btnBackToDirectory = New Ferrando.UI.WinForms.Controles.FButton()
        sideBar.SuspendLayout()
        namePlaceHolder.SuspendLayout()
        FCard1.SuspendLayout()
        mainScreen.SuspendLayout()
        cardPending.SuspendLayout()
        cardPatient.SuspendLayout()
        cardAssessment.SuspendLayout()
        cardSymptomsBox.SuspendLayout()
        cardDiagnosisBox.SuspendLayout()
        cardPrescription.SuspendLayout()
        cardMedicationBox.SuspendLayout()
        cardAdviceBox.SuspendLayout()
        cardVitals.SuspendLayout()
        cardMedicalHistory.SuspendLayout()
        cardAllergyAlert.SuspendLayout()
        cardComplete.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.BackColor = Color.FromArgb(CByte(244), CByte(247), CByte(249))
        lblTitle.Font = New Font("Segoe UI", 18.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.FromArgb(CByte(22), CByte(51), CByte(65))
        lblTitle.Location = New Point(28, 18)
        lblTitle.Text = "Consultation workspace"
        lblTitle.Name = "lblTitle"
        lblTitle.TabIndex = 0
        ' 
        ' cardPending
        ' 
        cardPending.Controls.Add(lblPending)
        cardPending.BackColor = Color.FromArgb(CByte(254), CByte(243), CByte(226))
        cardPending.BorderColor = Color.FromArgb(CByte(254), CByte(243), CByte(226))
        cardPending.BorderHoverColor = Color.FromArgb(CByte(254), CByte(243), CByte(226))
        cardPending.BorderRadius = 10
        cardPending.BorderSize = 0
        cardPending.EnableShadow = False
        cardPending.HoverTintColor = Color.FromArgb(CByte(254), CByte(243), CByte(226))
        cardPending.Location = New Point(733, 26)
        cardPending.ShadowDepth = 2
        cardPending.Size = New Size(70, 22)
        cardPending.Name = "cardPending"
        cardPending.TabIndex = 1
        ' 
        ' lblPending
        ' 
        lblPending.AutoSize = False
        lblPending.BackColor = Color.FromArgb(CByte(254), CByte(243), CByte(226))
        lblPending.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPending.ForeColor = Color.FromArgb(CByte(217), CByte(119), CByte(6))
        lblPending.Location = New Point(0, 0)
        lblPending.Size = New Size(70, 22)
        lblPending.TextAlign = ContentAlignment.MiddleCenter
        lblPending.Text = "Pending"
        lblPending.Name = "lblPending"
        lblPending.TabIndex = 2
        ' 
        ' cardPatient
        ' 
        cardPatient.Controls.Add(lblPatientName)
        cardPatient.Controls.Add(lblPatientAgeSex)
        cardPatient.Controls.Add(lblPatientAllergy)
        cardPatient.Controls.Add(lblPatientReason)
        cardPatient.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardPatient.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardPatient.BorderHoverColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardPatient.BorderRadius = 12
        cardPatient.BorderSize = 1
        cardPatient.EnableShadow = True
        cardPatient.HoverTintColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardPatient.Location = New Point(28, 79)
        cardPatient.ShadowDepth = 4
        cardPatient.Size = New Size(775, 67)
        cardPatient.Name = "cardPatient"
        cardPatient.TabIndex = 3
        ' 
        ' lblPatientName
        ' 
        lblPatientName.AutoSize = True
        lblPatientName.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblPatientName.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPatientName.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblPatientName.Location = New Point(16, 13)
        lblPatientName.Text = "Joshua Reyes • PT-1051"
        lblPatientName.Name = "lblPatientName"
        lblPatientName.TabIndex = 4
        ' 
        ' lblPatientAgeSex
        ' 
        lblPatientAgeSex.AutoSize = True
        lblPatientAgeSex.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblPatientAgeSex.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPatientAgeSex.ForeColor = Color.FromArgb(CByte(115), CByte(138), CByte(148))
        lblPatientAgeSex.Location = New Point(16, 40)
        lblPatientAgeSex.Text = "27 years • Male"
        lblPatientAgeSex.Name = "lblPatientAgeSex"
        lblPatientAgeSex.TabIndex = 5
        ' 
        ' lblPatientAllergy
        ' 
        lblPatientAllergy.AutoSize = True
        lblPatientAllergy.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblPatientAllergy.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPatientAllergy.ForeColor = Color.FromArgb(CByte(115), CByte(138), CByte(148))
        lblPatientAllergy.Location = New Point(110, 40)
        lblPatientAllergy.Text = "No known drug allergies"
        lblPatientAllergy.Name = "lblPatientAllergy"
        lblPatientAllergy.TabIndex = 6
        ' 
        ' lblPatientReason
        ' 
        lblPatientReason.AutoSize = True
        lblPatientReason.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblPatientReason.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPatientReason.ForeColor = Color.FromArgb(CByte(115), CByte(138), CByte(148))
        lblPatientReason.Location = New Point(244, 40)
        lblPatientReason.Text = "Reason: persistent cough"
        lblPatientReason.Name = "lblPatientReason"
        lblPatientReason.TabIndex = 7
        ' 
        ' cardAssessment
        ' 
        cardAssessment.Controls.Add(lblAssessmentTitle)
        cardAssessment.Controls.Add(lblSymptoms)
        cardAssessment.Controls.Add(cardSymptomsBox)
        cardAssessment.Controls.Add(lblDiagnosis)
        cardAssessment.Controls.Add(cardDiagnosisBox)
        cardAssessment.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardAssessment.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardAssessment.BorderHoverColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardAssessment.BorderRadius = 12
        cardAssessment.BorderSize = 1
        cardAssessment.EnableShadow = True
        cardAssessment.HoverTintColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardAssessment.Location = New Point(28, 169)
        cardAssessment.ShadowDepth = 4
        cardAssessment.Size = New Size(546, 154)
        cardAssessment.Name = "cardAssessment"
        cardAssessment.TabIndex = 8
        ' 
        ' lblAssessmentTitle
        ' 
        lblAssessmentTitle.AutoSize = True
        lblAssessmentTitle.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblAssessmentTitle.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblAssessmentTitle.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblAssessmentTitle.Location = New Point(16, 12)
        lblAssessmentTitle.Text = "Assessment"
        lblAssessmentTitle.Name = "lblAssessmentTitle"
        lblAssessmentTitle.TabIndex = 9
        ' 
        ' lblSymptoms
        ' 
        lblSymptoms.AutoSize = True
        lblSymptoms.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblSymptoms.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSymptoms.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblSymptoms.Location = New Point(16, 38)
        lblSymptoms.Text = "SUBJECTIVE (S) — SYMPTOMS & FINDINGS"
        lblSymptoms.Name = "lblSymptoms"
        lblSymptoms.TabIndex = 10
        ' 
        ' cardSymptomsBox
        ' 
        cardSymptomsBox.Controls.Add(txtSymptoms)
        cardSymptomsBox.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardSymptomsBox.BorderColor = Color.FromArgb(CByte(220), CByte(228), CByte(232))
        cardSymptomsBox.BorderHoverColor = Color.FromArgb(CByte(220), CByte(228), CByte(232))
        cardSymptomsBox.BorderRadius = 8
        cardSymptomsBox.BorderSize = 1
        cardSymptomsBox.EnableShadow = False
        cardSymptomsBox.HoverTintColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardSymptomsBox.Location = New Point(16, 54)
        cardSymptomsBox.ShadowDepth = 2
        cardSymptomsBox.Size = New Size(514, 28)
        cardSymptomsBox.Name = "cardSymptomsBox"
        cardSymptomsBox.TabIndex = 11
        ' 
        ' txtSymptoms
        ' 
        txtSymptoms.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        txtSymptoms.BorderStyle = BorderStyle.None
        txtSymptoms.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSymptoms.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        txtSymptoms.Location = New Point(10, 6)
        txtSymptoms.Size = New Size(494, 16)
        txtSymptoms.Text = "Dry cough for 8 days; afebrile; lungs clear; mild throat irritation."
        txtSymptoms.Name = "txtSymptoms"
        txtSymptoms.TabIndex = 12
        ' 
        ' lblDiagnosis
        ' 
        lblDiagnosis.AutoSize = True
        lblDiagnosis.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblDiagnosis.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDiagnosis.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblDiagnosis.Location = New Point(16, 92)
        lblDiagnosis.Text = "ASSESSMENT (A) — CLINICAL DIAGNOSIS"
        lblDiagnosis.Name = "lblDiagnosis"
        lblDiagnosis.TabIndex = 13
        ' 
        ' cardDiagnosisBox
        ' 
        cardDiagnosisBox.Controls.Add(txtDiagnosis)
        cardDiagnosisBox.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardDiagnosisBox.BorderColor = Color.FromArgb(CByte(220), CByte(228), CByte(232))
        cardDiagnosisBox.BorderHoverColor = Color.FromArgb(CByte(220), CByte(228), CByte(232))
        cardDiagnosisBox.BorderRadius = 8
        cardDiagnosisBox.BorderSize = 1
        cardDiagnosisBox.EnableShadow = False
        cardDiagnosisBox.HoverTintColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardDiagnosisBox.Location = New Point(16, 108)
        cardDiagnosisBox.ShadowDepth = 2
        cardDiagnosisBox.Size = New Size(514, 28)
        cardDiagnosisBox.Name = "cardDiagnosisBox"
        cardDiagnosisBox.TabIndex = 14
        ' 
        ' txtDiagnosis
        ' 
        txtDiagnosis.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        txtDiagnosis.BorderStyle = BorderStyle.None
        txtDiagnosis.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtDiagnosis.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        txtDiagnosis.Location = New Point(10, 6)
        txtDiagnosis.Size = New Size(494, 16)
        txtDiagnosis.Text = "Acute upper respiratory infection (J06.9)"
        txtDiagnosis.Name = "txtDiagnosis"
        txtDiagnosis.TabIndex = 15
        ' 
        ' cardPrescription
        ' 
        cardPrescription.Controls.Add(lblPrescriptionTitle)
        cardPrescription.Controls.Add(lblMedication)
        cardPrescription.Controls.Add(cardMedicationBox)
        cardPrescription.Controls.Add(lblAdvice)
        cardPrescription.Controls.Add(cardAdviceBox)
        cardPrescription.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardPrescription.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardPrescription.BorderHoverColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardPrescription.BorderRadius = 12
        cardPrescription.BorderSize = 1
        cardPrescription.EnableShadow = True
        cardPrescription.HoverTintColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardPrescription.Location = New Point(28, 337)
        cardPrescription.ShadowDepth = 4
        cardPrescription.Size = New Size(546, 154)
        cardPrescription.Name = "cardPrescription"
        cardPrescription.TabIndex = 16
        ' 
        ' lblPrescriptionTitle
        ' 
        lblPrescriptionTitle.AutoSize = True
        lblPrescriptionTitle.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblPrescriptionTitle.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPrescriptionTitle.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblPrescriptionTitle.Location = New Point(16, 12)
        lblPrescriptionTitle.Text = "Prescription and plan"
        lblPrescriptionTitle.Name = "lblPrescriptionTitle"
        lblPrescriptionTitle.TabIndex = 17
        ' 
        ' btnPrintRxTop
        ' 
        btnPrintRxTop.BackColor = Color.White
        btnPrintRxTop.BorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnPrintRxTop.BorderRadius = 6
        btnPrintRxTop.BorderSize = 1
        btnPrintRxTop.Cursor = Cursors.Hand
        btnPrintRxTop.FlatAppearance.BorderSize = 0
        btnPrintRxTop.FlatStyle = FlatStyle.Flat
        btnPrintRxTop.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnPrintRxTop.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnPrintRxTop.Location = New Point(264, 10)
        btnPrintRxTop.MouseEnterBackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnPrintRxTop.MouseEnterBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnPrintRxTop.MouseEnterBorderSize = 1
        btnPrintRxTop.MouseEnterFont = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        btnPrintRxTop.MouseEnterForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnPrintRxTop.MouseLeaveBackColor = Color.White
        btnPrintRxTop.MouseLeaveBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnPrintRxTop.MouseLeaveBorderSize = 1
        btnPrintRxTop.MouseLeaveFont = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        btnPrintRxTop.MouseLeaveForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnPrintRxTop.Size = New Size(126, 26)
        btnPrintRxTop.Text = "🖨️ Print Rx Slip"
        btnPrintRxTop.UseVisualStyleBackColor = False
        btnPrintRxTop.Name = "btnPrintRxTop"
        btnPrintRxTop.TabIndex = 24
        ' 
        ' btnPrintLabTop
        ' 
        btnPrintLabTop.BackColor = Color.White
        btnPrintLabTop.BorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnPrintLabTop.BorderRadius = 6
        btnPrintLabTop.BorderSize = 1
        btnPrintLabTop.Cursor = Cursors.Hand
        btnPrintLabTop.FlatAppearance.BorderSize = 0
        btnPrintLabTop.FlatStyle = FlatStyle.Flat
        btnPrintLabTop.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnPrintLabTop.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnPrintLabTop.Location = New Point(398, 10)
        btnPrintLabTop.MouseEnterBackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnPrintLabTop.MouseEnterBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnPrintLabTop.MouseEnterBorderSize = 1
        btnPrintLabTop.MouseEnterFont = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        btnPrintLabTop.MouseEnterForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnPrintLabTop.MouseLeaveBackColor = Color.White
        btnPrintLabTop.MouseLeaveBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnPrintLabTop.MouseLeaveBorderSize = 1
        btnPrintLabTop.MouseLeaveFont = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        btnPrintLabTop.MouseLeaveForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnPrintLabTop.Size = New Size(132, 26)
        btnPrintLabTop.Text = "🧪 Order Labs"
        btnPrintLabTop.UseVisualStyleBackColor = False
        btnPrintLabTop.Name = "btnPrintLabTop"
        btnPrintLabTop.TabIndex = 25
        btnPrintRxTop.TabIndex = 24
        ' 
        ' lblMedication
        ' 
        lblMedication.AutoSize = True
        lblMedication.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblMedication.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblMedication.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblMedication.Location = New Point(16, 38)
        lblMedication.Text = "PLAN (P) — MEDICATION & PRESCRIPTION"
        lblMedication.Name = "lblMedication"
        lblMedication.TabIndex = 18
        ' 
        ' cardMedicationBox
        ' 
        cardMedicationBox.Controls.Add(txtMedication)
        cardMedicationBox.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardMedicationBox.BorderColor = Color.FromArgb(CByte(220), CByte(228), CByte(232))
        cardMedicationBox.BorderHoverColor = Color.FromArgb(CByte(220), CByte(228), CByte(232))
        cardMedicationBox.BorderRadius = 8
        cardMedicationBox.BorderSize = 1
        cardMedicationBox.EnableShadow = False
        cardMedicationBox.HoverTintColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardMedicationBox.Location = New Point(16, 54)
        cardMedicationBox.ShadowDepth = 2
        cardMedicationBox.Size = New Size(514, 28)
        cardMedicationBox.Name = "cardMedicationBox"
        cardMedicationBox.TabIndex = 19
        ' 
        ' txtMedication
        ' 
        txtMedication.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        txtMedication.BorderStyle = BorderStyle.None
        txtMedication.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtMedication.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        txtMedication.Location = New Point(10, 6)
        txtMedication.Size = New Size(494, 16)
        txtMedication.Text = "Cetirizine 10 mg tablet — once daily for 5 days"
        txtMedication.Name = "txtMedication"
        txtMedication.TabIndex = 20
        ' 
        ' lblAdvice
        ' 
        lblAdvice.AutoSize = True
        lblAdvice.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblAdvice.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblAdvice.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblAdvice.Location = New Point(16, 92)
        lblAdvice.Text = "PLAN (P) — ADVICE & SPECIAL INSTRUCTIONS"
        lblAdvice.Name = "lblAdvice"
        lblAdvice.TabIndex = 21
        ' 
        ' cardAdviceBox
        ' 
        cardAdviceBox.Controls.Add(txtAdvice)
        cardAdviceBox.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardAdviceBox.BorderColor = Color.FromArgb(CByte(220), CByte(228), CByte(232))
        cardAdviceBox.BorderHoverColor = Color.FromArgb(CByte(220), CByte(228), CByte(232))
        cardAdviceBox.BorderRadius = 8
        cardAdviceBox.BorderSize = 1
        cardAdviceBox.EnableShadow = False
        cardAdviceBox.HoverTintColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardAdviceBox.Location = New Point(16, 108)
        cardAdviceBox.ShadowDepth = 2
        cardAdviceBox.Size = New Size(514, 28)
        cardAdviceBox.Name = "cardAdviceBox"
        cardAdviceBox.TabIndex = 22
        ' 
        ' txtAdvice
        ' 
        txtAdvice.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        txtAdvice.BorderStyle = BorderStyle.None
        txtAdvice.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtAdvice.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        txtAdvice.Location = New Point(10, 6)
        txtAdvice.Size = New Size(494, 16)
        txtAdvice.Text = "Hydration, rest, return if fever or breathing difficulty develops."
        txtAdvice.Name = "txtAdvice"
        txtAdvice.TabIndex = 23
        ' 
        ' cardVitals
        ' 
        cardVitals.Controls.Add(lblVitalsTitle)
        cardVitals.Controls.Add(btnEditVitals)
        cardVitals.Controls.Add(lblVitalBp)
        cardVitals.Controls.Add(lblVitalPulse)
        cardVitals.Controls.Add(lblVitalTemp)
        cardVitals.Controls.Add(lblVitalSpo2)
        cardVitals.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardVitals.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardVitals.BorderHoverColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardVitals.BorderRadius = 12
        cardVitals.BorderSize = 1
        cardVitals.EnableShadow = True
        cardVitals.HoverTintColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardVitals.Location = New Point(586, 169)
        cardVitals.ShadowDepth = 4
        cardVitals.Size = New Size(217, 122)
        cardVitals.Name = "cardVitals"
        cardVitals.TabIndex = 24
        ' 
        ' lblVitalsTitle
        ' 
        lblVitalsTitle.AutoSize = True
        lblVitalsTitle.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblVitalsTitle.Font = New Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblVitalsTitle.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblVitalsTitle.Location = New Point(12, 12)
        lblVitalsTitle.Text = "OBJECTIVE (O) — VITALS"
        lblVitalsTitle.Name = "lblVitalsTitle"
        lblVitalsTitle.TabIndex = 25
        ' 
        ' btnEditVitals
        ' 
        btnEditVitals.BackColor = Color.FromArgb(CByte(244), CByte(247), CByte(249))
        btnEditVitals.BorderColor = Color.FromArgb(CByte(220), CByte(228), CByte(232))
        btnEditVitals.BorderRadius = 6
        btnEditVitals.BorderSize = 1
        btnEditVitals.Cursor = Cursors.Hand
        btnEditVitals.FlatAppearance.BorderSize = 0
        btnEditVitals.FlatStyle = FlatStyle.Flat
        btnEditVitals.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnEditVitals.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnEditVitals.Location = New Point(155, 8)
        btnEditVitals.MouseEnterBackColor = Color.FromArgb(CByte(230), CByte(245), CByte(240))
        btnEditVitals.MouseEnterBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnEditVitals.MouseEnterBorderSize = 1
        btnEditVitals.MouseEnterFont = New Font("Segoe UI", 7.5F, FontStyle.Bold)
        btnEditVitals.MouseEnterForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnEditVitals.MouseLeaveBackColor = Color.FromArgb(CByte(244), CByte(247), CByte(249))
        btnEditVitals.MouseLeaveBorderColor = Color.FromArgb(CByte(220), CByte(228), CByte(232))
        btnEditVitals.MouseLeaveBorderSize = 1
        btnEditVitals.MouseLeaveFont = New Font("Segoe UI", 7.5F, FontStyle.Bold)
        btnEditVitals.MouseLeaveForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnEditVitals.Size = New Size(50, 22)
        btnEditVitals.Text = "✎ Edit"
        btnEditVitals.UseVisualStyleBackColor = False
        btnEditVitals.Name = "btnEditVitals"
        btnEditVitals.TabIndex = 26
        ' 
        ' lblVitalBp
        ' 
        lblVitalBp.AutoSize = True
        lblVitalBp.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblVitalBp.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblVitalBp.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        lblVitalBp.Location = New Point(16, 38)
        lblVitalBp.Text = "BP 118/76 mmHg"
        lblVitalBp.Name = "lblVitalBp"
        lblVitalBp.TabIndex = 26
        ' 
        ' lblVitalPulse
        ' 
        lblVitalPulse.AutoSize = True
        lblVitalPulse.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblVitalPulse.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblVitalPulse.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        lblVitalPulse.Location = New Point(16, 55)
        lblVitalPulse.Text = "Pulse 74 bpm"
        lblVitalPulse.Name = "lblVitalPulse"
        lblVitalPulse.TabIndex = 27
        ' 
        ' lblVitalTemp
        ' 
        lblVitalTemp.AutoSize = True
        lblVitalTemp.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblVitalTemp.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblVitalTemp.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        lblVitalTemp.Location = New Point(16, 72)
        lblVitalTemp.Text = "Temperature 36.7°C"
        lblVitalTemp.Name = "lblVitalTemp"
        lblVitalTemp.TabIndex = 28
        ' 
        ' lblVitalSpo2
        ' 
        lblVitalSpo2.AutoSize = True
        lblVitalSpo2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblVitalSpo2.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblVitalSpo2.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        lblVitalSpo2.Location = New Point(16, 89)
        lblVitalSpo2.Text = "SpO₂ 98%"
        lblVitalSpo2.Name = "lblVitalSpo2"
        lblVitalSpo2.TabIndex = 29        ' 
        ' cardMedicalHistory
        ' 
        cardMedicalHistory.Controls.Add(lblMedHistoryTitle)
        cardMedicalHistory.Controls.Add(lblConditionsLabel)
        cardMedicalHistory.Controls.Add(lblConditionsValue)
        cardMedicalHistory.Controls.Add(lblAllergiesLabel)
        cardMedicalHistory.Controls.Add(cardAllergyAlert)
        cardMedicalHistory.Controls.Add(lblLastVisitLabel)
        cardMedicalHistory.Controls.Add(lblLastVisitValue)
        cardMedicalHistory.Controls.Add(btnViewFullChart)
        cardMedicalHistory.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardMedicalHistory.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardMedicalHistory.BorderHoverColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardMedicalHistory.BorderRadius = 12
        cardMedicalHistory.BorderSize = 1
        cardMedicalHistory.EnableShadow = True
        cardMedicalHistory.HoverTintColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardMedicalHistory.Location = New Point(586, 301)
        cardMedicalHistory.ShadowDepth = 4
        cardMedicalHistory.Size = New Size(217, 212)
        cardMedicalHistory.Name = "cardMedicalHistory"
        cardMedicalHistory.TabIndex = 30
        ' 
        ' lblMedHistoryTitle
        ' 
        lblMedHistoryTitle.AutoSize = True
        lblMedHistoryTitle.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblMedHistoryTitle.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblMedHistoryTitle.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblMedHistoryTitle.Location = New Point(14, 10)
        lblMedHistoryTitle.Text = "Medical History & Alerts"
        lblMedHistoryTitle.Name = "lblMedHistoryTitle"
        lblMedHistoryTitle.TabIndex = 31
        ' 
        ' lblConditionsLabel
        ' 
        lblConditionsLabel.AutoSize = True
        lblConditionsLabel.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblConditionsLabel.Font = New Font("Segoe UI", 7.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblConditionsLabel.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblConditionsLabel.Location = New Point(14, 32)
        lblConditionsLabel.Text = "KNOWN CONDITIONS"
        lblConditionsLabel.Name = "lblConditionsLabel"
        lblConditionsLabel.TabIndex = 32
        ' 
        ' lblConditionsValue
        ' 
        lblConditionsValue.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblConditionsValue.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblConditionsValue.ForeColor = Color.FromArgb(CByte(55), CByte(70), CByte(80))
        lblConditionsValue.Location = New Point(14, 46)
        lblConditionsValue.Size = New Size(188, 28)
        lblConditionsValue.Text = "Mild asthma • Seasonal allergies"
        lblConditionsValue.Name = "lblConditionsValue"
        lblConditionsValue.TabIndex = 33
        ' 
        ' lblAllergiesLabel
        ' 
        lblAllergiesLabel.AutoSize = True
        lblAllergiesLabel.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblAllergiesLabel.Font = New Font("Segoe UI", 7.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblAllergiesLabel.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblAllergiesLabel.Location = New Point(14, 76)
        lblAllergiesLabel.Text = "DRUG ALLERGIES"
        lblAllergiesLabel.Name = "lblAllergiesLabel"
        lblAllergiesLabel.TabIndex = 34
        ' 
        ' cardAllergyAlert
        ' 
        cardAllergyAlert.Controls.Add(lblAllergyText)
        cardAllergyAlert.BackColor = Color.FromArgb(CByte(253), CByte(236), CByte(236))
        cardAllergyAlert.BorderColor = Color.FromArgb(CByte(244), CByte(204), CByte(202))
        cardAllergyAlert.BorderHoverColor = Color.FromArgb(CByte(244), CByte(204), CByte(202))
        cardAllergyAlert.BorderRadius = 6
        cardAllergyAlert.BorderSize = 1
        cardAllergyAlert.EnableShadow = False
        cardAllergyAlert.HoverTintColor = Color.FromArgb(CByte(253), CByte(236), CByte(236))
        cardAllergyAlert.Location = New Point(14, 90)
        cardAllergyAlert.ShadowDepth = 2
        cardAllergyAlert.Size = New Size(188, 24)
        cardAllergyAlert.Name = "cardAllergyAlert"
        cardAllergyAlert.TabIndex = 35
        ' 
        ' lblAllergyText
        ' 
        lblAllergyText.AutoSize = True
        lblAllergyText.BackColor = Color.FromArgb(CByte(253), CByte(236), CByte(236))
        lblAllergyText.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblAllergyText.ForeColor = Color.FromArgb(CByte(205), CByte(80), CByte(75))
        lblAllergyText.Location = New Point(6, 4)
        lblAllergyText.Text = "⚠️ Penicillin"
        lblAllergyText.Name = "lblAllergyText"
        lblAllergyText.TabIndex = 36
        ' 
        ' lblLastVisitLabel
        ' 
        lblLastVisitLabel.AutoSize = True
        lblLastVisitLabel.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblLastVisitLabel.Font = New Font("Segoe UI", 7.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblLastVisitLabel.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblLastVisitLabel.Location = New Point(14, 118)
        lblLastVisitLabel.Text = "LAST VISIT DIAGNOSIS"
        lblLastVisitLabel.Name = "lblLastVisitLabel"
        lblLastVisitLabel.TabIndex = 37
        ' 
        ' lblLastVisitValue
        ' 
        lblLastVisitValue.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblLastVisitValue.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblLastVisitValue.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblLastVisitValue.Location = New Point(14, 132)
        lblLastVisitValue.Size = New Size(188, 28)
        lblLastVisitValue.Text = "Asthma controlled (Sep 22)"
        lblLastVisitValue.Name = "lblLastVisitValue"
        lblLastVisitValue.TabIndex = 38
        ' 
        ' btnViewFullChart
        ' 
        btnViewFullChart.BackColor = Color.FromArgb(CByte(244), CByte(247), CByte(249))
        btnViewFullChart.BorderColor = Color.FromArgb(CByte(220), CByte(228), CByte(232))
        btnViewFullChart.BorderRadius = 6
        btnViewFullChart.BorderSize = 1
        btnViewFullChart.Cursor = Cursors.Hand
        btnViewFullChart.FlatAppearance.BorderSize = 0
        btnViewFullChart.FlatStyle = FlatStyle.Flat
        btnViewFullChart.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnViewFullChart.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnViewFullChart.Location = New Point(14, 172)
        btnViewFullChart.MouseEnterBackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnViewFullChart.MouseEnterBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnViewFullChart.MouseEnterBorderSize = 1
        btnViewFullChart.MouseEnterFont = New Font("Segoe UI", 7.5F, FontStyle.Bold)
        btnViewFullChart.MouseEnterForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnViewFullChart.MouseLeaveBackColor = Color.FromArgb(CByte(244), CByte(247), CByte(249))
        btnViewFullChart.MouseLeaveBorderColor = Color.FromArgb(CByte(220), CByte(228), CByte(232))
        btnViewFullChart.MouseLeaveBorderSize = 1
        btnViewFullChart.MouseLeaveFont = New Font("Segoe UI", 7.5F, FontStyle.Bold)
        btnViewFullChart.MouseLeaveForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnViewFullChart.Size = New Size(188, 26)
        btnViewFullChart.Text = "Open full chart →"
        btnViewFullChart.UseVisualStyleBackColor = False
        btnViewFullChart.Name = "btnViewFullChart"
        btnViewFullChart.TabIndex = 39
        ' 
        ' cardComplete
        ' 
        cardComplete.Controls.Add(lblCompleteTitle)
        cardComplete.Controls.Add(btnSaveComplete)
        cardComplete.Controls.Add(btnSaveDraft)
        cardComplete.Controls.Add(btnPrintRx)
        cardComplete.Controls.Add(btnPrintLab)
        cardComplete.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardComplete.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardComplete.BorderHoverColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardComplete.BorderRadius = 12
        cardComplete.BorderSize = 1
        cardComplete.EnableShadow = True
        cardComplete.HoverTintColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardComplete.Location = New Point(586, 521)
        cardComplete.ShadowDepth = 4
        cardComplete.Size = New Size(217, 162)
        cardComplete.Name = "cardComplete"
        cardComplete.TabIndex = 40
        ' 
        ' lblCompleteTitle
        ' 
        lblCompleteTitle.AutoSize = True
        lblCompleteTitle.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblCompleteTitle.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCompleteTitle.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblCompleteTitle.Location = New Point(16, 12)
        lblCompleteTitle.Text = "Complete consultation"
        lblCompleteTitle.Name = "lblCompleteTitle"
        lblCompleteTitle.TabIndex = 31
        ' 
        ' btnSaveComplete
        ' 
        btnSaveComplete.BackColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnSaveComplete.BorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnSaveComplete.BorderRadius = 8
        btnSaveComplete.BorderSize = 0
        btnSaveComplete.Cursor = Cursors.Hand
        btnSaveComplete.FlatAppearance.BorderSize = 0
        btnSaveComplete.FlatStyle = FlatStyle.Flat
        btnSaveComplete.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSaveComplete.ForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnSaveComplete.Location = New Point(14, 38)
        btnSaveComplete.MouseEnterBackColor = Color.FromArgb(CByte(23), CByte(105), CByte(90))
        btnSaveComplete.MouseEnterBorderColor = Color.FromArgb(CByte(23), CByte(105), CByte(90))
        btnSaveComplete.MouseEnterBorderSize = 0
        btnSaveComplete.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSaveComplete.MouseEnterForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnSaveComplete.MouseLeaveBackColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnSaveComplete.MouseLeaveBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnSaveComplete.MouseLeaveBorderSize = 0
        btnSaveComplete.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSaveComplete.MouseLeaveForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnSaveComplete.Size = New Size(188, 30)
        btnSaveComplete.Text = "Save and mark completed"
        btnSaveComplete.UseVisualStyleBackColor = False
        btnSaveComplete.Name = "btnSaveComplete"
        btnSaveComplete.TabIndex = 32
        ' 
        ' btnSaveDraft
        ' 
        btnSaveDraft.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        btnSaveDraft.BorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnSaveDraft.BorderRadius = 8
        btnSaveDraft.BorderSize = 1
        btnSaveDraft.Cursor = Cursors.Hand
        btnSaveDraft.FlatAppearance.BorderSize = 0
        btnSaveDraft.FlatStyle = FlatStyle.Flat
        btnSaveDraft.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSaveDraft.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnSaveDraft.Location = New Point(14, 74)
        btnSaveDraft.MouseEnterBackColor = Color.FromArgb(CByte(245), CByte(249), CByte(251))
        btnSaveDraft.MouseEnterBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnSaveDraft.MouseEnterBorderSize = 1
        btnSaveDraft.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSaveDraft.MouseEnterForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnSaveDraft.MouseLeaveBackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        btnSaveDraft.MouseLeaveBorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnSaveDraft.MouseLeaveBorderSize = 1
        btnSaveDraft.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSaveDraft.MouseLeaveForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnSaveDraft.Size = New Size(188, 28)
        btnSaveDraft.Text = "Save draft"
        btnSaveDraft.UseVisualStyleBackColor = False
        btnSaveDraft.Name = "btnSaveDraft"
        btnSaveDraft.TabIndex = 33
        ' 
        ' btnPrintRx
        ' 
        btnPrintRx.BackColor = Color.White
        btnPrintRx.BorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnPrintRx.BorderRadius = 8
        btnPrintRx.BorderSize = 1
        btnPrintRx.Cursor = Cursors.Hand
        btnPrintRx.FlatAppearance.BorderSize = 0
        btnPrintRx.FlatStyle = FlatStyle.Flat
        btnPrintRx.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnPrintRx.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnPrintRx.Location = New Point(14, 110)
        btnPrintRx.MouseEnterBackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnPrintRx.MouseEnterBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnPrintRx.MouseEnterBorderSize = 1
        btnPrintRx.MouseEnterFont = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        btnPrintRx.MouseEnterForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnPrintRx.MouseLeaveBackColor = Color.White
        btnPrintRx.MouseLeaveBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnPrintRx.MouseLeaveBorderSize = 1
        btnPrintRx.MouseLeaveFont = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        btnPrintRx.MouseLeaveForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnPrintRx.Size = New Size(92, 34)
        btnPrintRx.Text = "🖨️ Rx Slip"
        btnPrintRx.UseVisualStyleBackColor = False
        btnPrintRx.Name = "btnPrintRx"
        btnPrintRx.TabIndex = 44
        ' 
        ' btnPrintLab
        ' 
        btnPrintLab.BackColor = Color.White
        btnPrintLab.BorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnPrintLab.BorderRadius = 8
        btnPrintLab.BorderSize = 1
        btnPrintLab.Cursor = Cursors.Hand
        btnPrintLab.FlatAppearance.BorderSize = 0
        btnPrintLab.FlatStyle = FlatStyle.Flat
        btnPrintLab.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnPrintLab.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnPrintLab.Location = New Point(110, 110)
        btnPrintLab.MouseEnterBackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnPrintLab.MouseEnterBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnPrintLab.MouseEnterBorderSize = 1
        btnPrintLab.MouseEnterFont = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        btnPrintLab.MouseEnterForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnPrintLab.MouseLeaveBackColor = Color.White
        btnPrintLab.MouseLeaveBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnPrintLab.MouseLeaveBorderSize = 1
        btnPrintLab.MouseLeaveFont = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        btnPrintLab.MouseLeaveForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnPrintLab.Size = New Size(92, 34)
        btnPrintLab.Text = "🧪 Order Labs"
        btnPrintLab.UseVisualStyleBackColor = False
        btnPrintLab.Name = "btnPrintLab"
        btnPrintLab.TabIndex = 45
        ' 
        ' sideBar
        ' 
        sideBar.BackColor = Color.FromArgb(CByte(17), CByte(54), CByte(70))
        sideBar.Controls.Add(namePlaceHolder)
        sideBar.Controls.Add(FCard1)
        sideBar.Controls.Add(btnReports)
        sideBar.Controls.Add(btnConsultation)
        sideBar.Controls.Add(Label2)
        sideBar.Controls.Add(btnDoctor)
        sideBar.Controls.Add(Label1)
        sideBar.Controls.Add(btnAppointment)
        sideBar.Controls.Add(btnPatients)
        sideBar.Controls.Add(btnDashboard)
        sideBar.Location = New Point(0, 0)
        sideBar.Name = "sideBar"
        sideBar.Size = New Size(178, 736)
        sideBar.TabIndex = 0
        ' 
        ' namePlaceHolder
        ' 
        namePlaceHolder.BackColor = Color.FromArgb(CByte(29), CByte(64), CByte(79))
        namePlaceHolder.BorderColor = Color.FromArgb(CByte(29), CByte(64), CByte(79))
        namePlaceHolder.BorderHoverColor = Color.FromArgb(CByte(29), CByte(64), CByte(79))
        namePlaceHolder.BorderRadius = 12
        namePlaceHolder.BorderSize = 1
        namePlaceHolder.Controls.Add(txtRole)
        namePlaceHolder.Controls.Add(txtName)
        namePlaceHolder.EnableShadow = True
        namePlaceHolder.HoverTintColor = Color.FromArgb(CByte(29), CByte(64), CByte(79))
        namePlaceHolder.Location = New Point(3, 423)
        namePlaceHolder.Name = "namePlaceHolder"
        namePlaceHolder.Padding = New Padding(15)
        namePlaceHolder.ShadowDepth = 8
        namePlaceHolder.Size = New Size(162, 64)
        namePlaceHolder.TabIndex = 11
        namePlaceHolder.Text = "FCard2"
        ' 
        ' txtRole
        ' 
        txtRole.AutoSize = True
        txtRole.Font = New Font("Noto Sans Georgian", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtRole.ForeColor = Color.FromArgb(CByte(200), CByte(215), CByte(225))
        txtRole.Location = New Point(18, 35)
        txtRole.Name = "txtRole"
        txtRole.Size = New Size(100, 17)
        txtRole.TabIndex = 1
        txtRole.Text = "General Physician"
        ' 
        ' txtName
        ' 
        txtName.AutoSize = True
        txtName.Font = New Font("Noto Sans Georgian Bold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtName.ForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        txtName.Location = New Point(16, 14)
        txtName.Name = "txtName"
        txtName.Size = New Size(118, 20)
        txtName.TabIndex = 0
        txtName.Text = "Dr. Elena Cruz"
        ' 
        ' FCard1
        ' 
        FCard1.BackColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        FCard1.BackgroundImageLayout = ImageLayout.None
        FCard1.BorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        FCard1.BorderHoverColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        FCard1.BorderRadius = 12
        FCard1.BorderSize = 1
        FCard1.Controls.Add(Label3)
        FCard1.EnableShadow = True
        FCard1.HoverTintColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        FCard1.Location = New Point(-1, 16)
        FCard1.Name = "FCard1"
        FCard1.Padding = New Padding(15)
        FCard1.ShadowDepth = 8
        FCard1.Size = New Size(52, 50)
        FCard1.TabIndex = 1
        FCard1.Text = "+"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Noto Sans Georgian Bold", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        Label3.Location = New Point(17, 14)
        Label3.Name = "Label3"
        Label3.Size = New Size(19, 22)
        Label3.TabIndex = 1
        Label3.Text = "+"
        Label3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnReports
        ' 
        btnReports.BackColor = Color.FromArgb(CByte(17), CByte(54), CByte(70))
        btnReports.BorderColor = Color.Black
        btnReports.BorderRadius = 10
        btnReports.BorderSize = 0
        btnReports.FlatAppearance.BorderSize = 0
        btnReports.FlatStyle = FlatStyle.Flat
        btnReports.Font = New Font("Noto Sans Georgian", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnReports.ForeColor = Color.FromArgb(CByte(182), CByte(204), CByte(210))
        btnReports.Location = New Point(3, 373)
        btnReports.MouseEnterBackColor = Color.FromArgb(CByte(39), CByte(73), CByte(87))
        btnReports.MouseEnterBorderColor = Color.FromArgb(CByte(39), CByte(73), CByte(87))
        btnReports.MouseEnterBorderSize = 0
        btnReports.MouseEnterFont = New Font("Noto Sans Georgian", 11.9999981F)
        btnReports.MouseEnterForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnReports.MouseLeaveBackColor = Color.FromArgb(CByte(17), CByte(54), CByte(70))
        btnReports.MouseLeaveBorderColor = Color.Black
        btnReports.MouseLeaveBorderSize = 0
        btnReports.MouseLeaveFont = New Font("Noto Sans Georgian", 11.9999981F)
        btnReports.MouseLeaveForeColor = Color.FromArgb(CByte(182), CByte(204), CByte(210))
        btnReports.Name = "btnReports"
        btnReports.Size = New Size(171, 35)
        btnReports.TabIndex = 6
        btnReports.Text = "Reports"
        btnReports.UseVisualStyleBackColor = False
        ' 
        ' btnConsultation
        ' 
        btnConsultation.BackColor = Color.FromArgb(CByte(17), CByte(54), CByte(70))
        btnConsultation.BorderColor = Color.Black
        btnConsultation.BorderRadius = 10
        btnConsultation.BorderSize = 0
        btnConsultation.FlatAppearance.BorderSize = 0
        btnConsultation.FlatStyle = FlatStyle.Flat
        btnConsultation.Font = New Font("Noto Sans Georgian", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnConsultation.ForeColor = Color.FromArgb(CByte(182), CByte(204), CByte(210))
        btnConsultation.Location = New Point(3, 320)
        btnConsultation.MouseEnterBackColor = Color.FromArgb(CByte(39), CByte(73), CByte(87))
        btnConsultation.MouseEnterBorderColor = Color.FromArgb(CByte(39), CByte(73), CByte(87))
        btnConsultation.MouseEnterBorderSize = 0
        btnConsultation.MouseEnterFont = New Font("Noto Sans Georgian", 11.9999981F)
        btnConsultation.MouseEnterForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnConsultation.MouseLeaveBackColor = Color.FromArgb(CByte(17), CByte(54), CByte(70))
        btnConsultation.MouseLeaveBorderColor = Color.Black
        btnConsultation.MouseLeaveBorderSize = 0
        btnConsultation.MouseLeaveFont = New Font("Noto Sans Georgian", 11.9999981F)
        btnConsultation.MouseLeaveForeColor = Color.FromArgb(CByte(182), CByte(204), CByte(210))
        btnConsultation.Name = "btnConsultation"
        btnConsultation.Size = New Size(171, 35)
        btnConsultation.TabIndex = 5
        btnConsultation.Text = "Consultation"
        btnConsultation.UseVisualStyleBackColor = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = SystemColors.ControlLightLight
        Label2.Location = New Point(49, 42)
        Label2.Name = "Label2"
        Label2.Size = New Size(90, 13)
        Label2.TabIndex = 10
        Label2.Text = " UCC Health Clinic"
        ' 
        ' btnDoctor
        ' 
        btnDoctor.BackColor = Color.FromArgb(CByte(17), CByte(54), CByte(70))
        btnDoctor.BorderColor = Color.Black
        btnDoctor.BorderRadius = 10
        btnDoctor.BorderSize = 0
        btnDoctor.FlatAppearance.BorderSize = 0
        btnDoctor.FlatStyle = FlatStyle.Flat
        btnDoctor.Font = New Font("Noto Sans Georgian", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDoctor.ForeColor = Color.FromArgb(CByte(182), CByte(204), CByte(210))
        btnDoctor.Location = New Point(3, 261)
        btnDoctor.MouseEnterBackColor = Color.FromArgb(CByte(39), CByte(73), CByte(87))
        btnDoctor.MouseEnterBorderColor = Color.FromArgb(CByte(39), CByte(73), CByte(87))
        btnDoctor.MouseEnterBorderSize = 0
        btnDoctor.MouseEnterFont = New Font("Noto Sans Georgian", 11.9999981F)
        btnDoctor.MouseEnterForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnDoctor.MouseLeaveBackColor = Color.FromArgb(CByte(17), CByte(54), CByte(70))
        btnDoctor.MouseLeaveBorderColor = Color.Black
        btnDoctor.MouseLeaveBorderSize = 0
        btnDoctor.MouseLeaveFont = New Font("Noto Sans Georgian", 11.9999981F)
        btnDoctor.MouseLeaveForeColor = Color.FromArgb(CByte(182), CByte(204), CByte(210))
        btnDoctor.Name = "btnDoctor"
        btnDoctor.Size = New Size(171, 35)
        btnDoctor.TabIndex = 4
        btnDoctor.Text = "My Schedule"
        btnDoctor.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.ControlLightLight
        Label1.Location = New Point(49, 25)
        Label1.Name = "Label1"
        Label1.Size = New Size(127, 17)
        Label1.TabIndex = 3
        Label1.Text = "Clinic Management"
        ' 
        ' btnAppointment
        ' 
        btnAppointment.BackColor = Color.FromArgb(CByte(17), CByte(54), CByte(70))
        btnAppointment.BorderColor = Color.Black
        btnAppointment.BorderRadius = 10
        btnAppointment.BorderSize = 0
        btnAppointment.FlatAppearance.BorderSize = 0
        btnAppointment.FlatStyle = FlatStyle.Flat
        btnAppointment.Font = New Font("Noto Sans Georgian", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnAppointment.ForeColor = Color.FromArgb(CByte(182), CByte(204), CByte(210))
        btnAppointment.Location = New Point(3, 214)
        btnAppointment.MouseEnterBackColor = Color.FromArgb(CByte(39), CByte(73), CByte(87))
        btnAppointment.MouseEnterBorderColor = Color.FromArgb(CByte(39), CByte(73), CByte(87))
        btnAppointment.MouseEnterBorderSize = 0
        btnAppointment.MouseEnterFont = New Font("Noto Sans Georgian", 11.9999981F)
        btnAppointment.MouseEnterForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnAppointment.MouseLeaveBackColor = Color.FromArgb(CByte(17), CByte(54), CByte(70))
        btnAppointment.MouseLeaveBorderColor = Color.Black
        btnAppointment.MouseLeaveBorderSize = 0
        btnAppointment.MouseLeaveFont = New Font("Noto Sans Georgian", 11.9999981F)
        btnAppointment.MouseLeaveForeColor = Color.FromArgb(CByte(182), CByte(204), CByte(210))
        btnAppointment.Name = "btnAppointment"
        btnAppointment.Size = New Size(171, 35)
        btnAppointment.TabIndex = 3
        btnAppointment.Text = "Appointment"
        btnAppointment.UseVisualStyleBackColor = False
        ' 
        ' btnPatients
        ' 
        btnPatients.BackColor = Color.FromArgb(CByte(17), CByte(54), CByte(70))
        btnPatients.BorderColor = Color.Black
        btnPatients.BorderRadius = 10
        btnPatients.BorderSize = 0
        btnPatients.FlatAppearance.BorderSize = 0
        btnPatients.FlatStyle = FlatStyle.Flat
        btnPatients.Font = New Font("Noto Sans Georgian", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnPatients.ForeColor = Color.FromArgb(CByte(182), CByte(204), CByte(210))
        btnPatients.Location = New Point(3, 161)
        btnPatients.MouseEnterBackColor = Color.FromArgb(CByte(39), CByte(73), CByte(87))
        btnPatients.MouseEnterBorderColor = Color.FromArgb(CByte(39), CByte(73), CByte(87))
        btnPatients.MouseEnterBorderSize = 0
        btnPatients.MouseEnterFont = New Font("Noto Sans Georgian", 11.9999981F)
        btnPatients.MouseEnterForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnPatients.MouseLeaveBackColor = Color.FromArgb(CByte(17), CByte(54), CByte(70))
        btnPatients.MouseLeaveBorderColor = Color.Black
        btnPatients.MouseLeaveBorderSize = 0
        btnPatients.MouseLeaveFont = New Font("Noto Sans Georgian", 11.9999981F)
        btnPatients.MouseLeaveForeColor = Color.FromArgb(CByte(182), CByte(204), CByte(210))
        btnPatients.Name = "btnPatients"
        btnPatients.Size = New Size(171, 35)
        btnPatients.TabIndex = 2
        btnPatients.Text = "Patients"
        btnPatients.UseVisualStyleBackColor = False
        ' 
        ' btnDashboard
        ' 
        btnDashboard.BackColor = Color.FromArgb(CByte(17), CByte(54), CByte(70))
        btnDashboard.BorderColor = Color.Black
        btnDashboard.BorderRadius = 10
        btnDashboard.BorderSize = 0
        btnDashboard.FlatAppearance.BorderSize = 0
        btnDashboard.FlatStyle = FlatStyle.Flat
        btnDashboard.Font = New Font("Noto Sans Georgian", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDashboard.ForeColor = Color.FromArgb(CByte(182), CByte(204), CByte(210))
        btnDashboard.Location = New Point(3, 108)
        btnDashboard.MouseEnterBackColor = Color.FromArgb(CByte(39), CByte(73), CByte(87))
        btnDashboard.MouseEnterBorderColor = Color.FromArgb(CByte(39), CByte(73), CByte(87))
        btnDashboard.MouseEnterBorderSize = 0
        btnDashboard.MouseEnterFont = New Font("Noto Sans Georgian", 11.9999981F)
        btnDashboard.MouseEnterForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnDashboard.MouseLeaveBackColor = Color.FromArgb(CByte(17), CByte(54), CByte(70))
        btnDashboard.MouseLeaveBorderColor = Color.Black
        btnDashboard.MouseLeaveBorderSize = 0
        btnDashboard.MouseLeaveFont = New Font("Noto Sans Georgian", 11.9999981F)
        btnDashboard.MouseLeaveForeColor = Color.FromArgb(CByte(182), CByte(204), CByte(210))
        btnDashboard.Name = "btnDashboard"
        btnDashboard.Size = New Size(171, 35)
        btnDashboard.TabIndex = 1
        btnDashboard.Text = "Dashboard"
        btnDashboard.UseVisualStyleBackColor = False

        ' 
        ' btnBackToDirectory
        ' 
        btnBackToDirectory.BackColor = Color.White
        btnBackToDirectory.BorderColor = Color.FromArgb(CByte(220), CByte(230), CByte(235))
        btnBackToDirectory.BorderRadius = 6
        btnBackToDirectory.BorderSize = 1
        btnBackToDirectory.FlatAppearance.BorderSize = 0
        btnBackToDirectory.FlatStyle = FlatStyle.Flat
        btnBackToDirectory.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnBackToDirectory.ForeColor = Color.FromArgb(CByte(80), CByte(100), CByte(115))
        btnBackToDirectory.Location = New Point(570, 22)
        btnBackToDirectory.MouseEnterBackColor = Color.FromArgb(CByte(245), CByte(249), CByte(251))
        btnBackToDirectory.MouseEnterBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnBackToDirectory.MouseEnterBorderSize = 1
        btnBackToDirectory.MouseEnterFont = New Font("Segoe UI", 8.25F, FontStyle.Regular)
        btnBackToDirectory.MouseEnterForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnBackToDirectory.MouseLeaveBackColor = Color.White
        btnBackToDirectory.MouseLeaveBorderColor = Color.FromArgb(CByte(220), CByte(230), CByte(235))
        btnBackToDirectory.MouseLeaveBorderSize = 1
        btnBackToDirectory.MouseLeaveFont = New Font("Segoe UI", 8.25F, FontStyle.Regular)
        btnBackToDirectory.MouseLeaveForeColor = Color.FromArgb(CByte(80), CByte(100), CByte(115))
        btnBackToDirectory.Name = "btnBackToDirectory"
        btnBackToDirectory.Size = New Size(148, 28)
        btnBackToDirectory.TabIndex = 60
        btnBackToDirectory.Text = "← Back to Directory"
        btnBackToDirectory.UseVisualStyleBackColor = False
        ' 
        ' mainScreen
        ' 
        mainScreen.BackColor = Color.FromArgb(CByte(244), CByte(247), CByte(249))
        mainScreen.Controls.Add(btnBackToDirectory)
        mainScreen.Controls.Add(lblTitle)
        mainScreen.Controls.Add(cardPending)
        mainScreen.Controls.Add(cardPatient)
        mainScreen.Controls.Add(cardAssessment)
        mainScreen.Controls.Add(cardPrescription)
        mainScreen.Controls.Add(cardVitals)
        mainScreen.Controls.Add(cardComplete)
        mainScreen.Controls.Add(cardMedicalHistory)
        mainScreen.Location = New Point(176, 0)
        mainScreen.Name = "mainScreen"
        mainScreen.Size = New Size(832, 730)
        mainScreen.TabIndex = 1
        ' 
        ' Consultation
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1008, 729)
        Controls.Add(mainScreen)
        Controls.Add(sideBar)
        Name = "DoctorConsultation"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Clinic Management - Doctor Consultation"
        cardComplete.ResumeLayout(False)
        cardComplete.PerformLayout()
        cardAllergyAlert.ResumeLayout(False)
        cardAllergyAlert.PerformLayout()
        cardMedicalHistory.ResumeLayout(False)
        cardMedicalHistory.PerformLayout()
        cardVitals.ResumeLayout(False)
        cardVitals.PerformLayout()
        cardAdviceBox.ResumeLayout(False)
        cardAdviceBox.PerformLayout()
        cardMedicationBox.ResumeLayout(False)
        cardMedicationBox.PerformLayout()
        cardPrescription.ResumeLayout(False)
        cardPrescription.PerformLayout()
        cardDiagnosisBox.ResumeLayout(False)
        cardDiagnosisBox.PerformLayout()
        cardSymptomsBox.ResumeLayout(False)
        cardSymptomsBox.PerformLayout()
        cardAssessment.ResumeLayout(False)
        cardAssessment.PerformLayout()
        cardPatient.ResumeLayout(False)
        cardPatient.PerformLayout()
        cardPending.ResumeLayout(False)
        cardPending.PerformLayout()
        sideBar.ResumeLayout(False)
        sideBar.PerformLayout()
        namePlaceHolder.ResumeLayout(False)
        namePlaceHolder.PerformLayout()
        FCard1.ResumeLayout(False)
        FCard1.PerformLayout()
        mainScreen.ResumeLayout(False)
        mainScreen.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents cardPending As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblPending As Label
    Friend WithEvents cardPatient As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblPatientName As Label
    Friend WithEvents lblPatientAgeSex As Label
    Friend WithEvents lblPatientAllergy As Label
    Friend WithEvents lblPatientReason As Label
    Friend WithEvents cardAssessment As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblAssessmentTitle As Label
    Friend WithEvents lblSymptoms As Label
    Friend WithEvents cardSymptomsBox As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents txtSymptoms As TextBox
    Friend WithEvents lblDiagnosis As Label
    Friend WithEvents cardDiagnosisBox As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents txtDiagnosis As TextBox
    Friend WithEvents cardPrescription As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblPrescriptionTitle As Label
    Friend WithEvents lblMedication As Label
    Friend WithEvents cardMedicationBox As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents txtMedication As TextBox
    Friend WithEvents lblAdvice As Label
    Friend WithEvents cardAdviceBox As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents txtAdvice As TextBox
    Friend WithEvents cardVitals As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblVitalsTitle As Label
    Friend WithEvents lblVitalBp As Label
    Friend WithEvents lblVitalPulse As Label
    Friend WithEvents lblVitalTemp As Label
    Friend WithEvents lblVitalSpo2 As Label
    Friend WithEvents btnEditVitals As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents cardComplete As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblCompleteTitle As Label
    Friend WithEvents btnSaveComplete As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnSaveDraft As Ferrando.UI.WinForms.Controles.FButton

    Friend WithEvents sideBar As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents mainScreen As Panel
    Friend WithEvents btnDashboard As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnReports As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnConsultation As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnDoctor As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnAppointment As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnPatients As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents FCard1 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents Label3 As Label
    Friend WithEvents namePlaceHolder As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents txtName As Label
    Friend WithEvents txtRole As Label

    Friend WithEvents cardMedicalHistory As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblMedHistoryTitle As Label
    Friend WithEvents lblConditionsLabel As Label
    Friend WithEvents lblConditionsValue As Label
    Friend WithEvents lblAllergiesLabel As Label
    Friend WithEvents cardAllergyAlert As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblAllergyText As Label
    Friend WithEvents lblLastVisitLabel As Label
    Friend WithEvents lblLastVisitValue As Label
    Friend WithEvents btnViewFullChart As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnPrintRx As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnPrintRxTop As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnPrintLab As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnPrintLabTop As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnBackToDirectory As Ferrando.UI.WinForms.Controles.FButton

End Class
