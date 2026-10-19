<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DoctorPrescriptionDialog
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
        pnlSheet = New Panel()
        lblClinicTitle = New Label()
        lblClinicSub = New Label()
        lblDoctorName = New Label()
        lblDoctorCreds = New Label()
        divHeader = New Panel()
        lblPatientName = New Label()
        lblPatientAgeSex = New Label()
        lblDate = New Label()
        divPatient = New Panel()
        pnlAllergyBanner = New Panel()
        lblAllergyBanner = New Label()
        lblRxSymbol = New Label()
        txtMedicationDisplay = New TextBox()
        lblSigHeader = New Label()
        txtAdviceDisplay = New TextBox()
        divFooter = New Panel()
        lblSignatureLine = New Label()
        lblSignDoctor = New Label()
        lblSignLic = New Label()
        btnPrint = New Ferrando.UI.WinForms.Controles.FButton()
        btnClose = New Ferrando.UI.WinForms.Controles.FButton()
        pnlSheet.SuspendLayout()
        pnlAllergyBanner.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlSheet
        ' 
        pnlSheet.BackColor = Color.White
        pnlSheet.BorderStyle = BorderStyle.FixedSingle
        pnlSheet.Controls.Add(lblClinicTitle)
        pnlSheet.Controls.Add(lblClinicSub)
        pnlSheet.Controls.Add(lblDoctorName)
        pnlSheet.Controls.Add(lblDoctorCreds)
        pnlSheet.Controls.Add(divHeader)
        pnlSheet.Controls.Add(lblPatientName)
        pnlSheet.Controls.Add(lblPatientAgeSex)
        pnlSheet.Controls.Add(lblDate)
        pnlSheet.Controls.Add(divPatient)
        pnlSheet.Controls.Add(pnlAllergyBanner)
        pnlSheet.Controls.Add(lblRxSymbol)
        pnlSheet.Controls.Add(txtMedicationDisplay)
        pnlSheet.Controls.Add(lblSigHeader)
        pnlSheet.Controls.Add(txtAdviceDisplay)
        pnlSheet.Controls.Add(divFooter)
        pnlSheet.Controls.Add(lblSignatureLine)
        pnlSheet.Controls.Add(lblSignDoctor)
        pnlSheet.Controls.Add(lblSignLic)
        pnlSheet.Location = New Point(20, 20)
        pnlSheet.Name = "pnlSheet"
        pnlSheet.Size = New Size(480, 560)
        pnlSheet.TabIndex = 0
        ' 
        ' lblClinicTitle
        ' 
        lblClinicTitle.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblClinicTitle.ForeColor = Color.FromArgb(CByte(22), CByte(51), CByte(65))
        lblClinicTitle.Location = New Point(10, 16)
        lblClinicTitle.Name = "lblClinicTitle"
        lblClinicTitle.Size = New Size(458, 20)
        lblClinicTitle.Text = "UNIVERSITY OF CALOOCAN CITY"
        lblClinicTitle.TextAlign = ContentAlignment.TopCenter
        lblClinicTitle.TabIndex = 0
        ' 
        ' lblClinicSub
        ' 
        lblClinicSub.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblClinicSub.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblClinicSub.Location = New Point(10, 36)
        lblClinicSub.Name = "lblClinicSub"
        lblClinicSub.Size = New Size(458, 16)
        lblClinicSub.Text = "UCC HEALTH CLINIC • UNIVERSITY HEALTH SERVICES"
        lblClinicSub.TextAlign = ContentAlignment.TopCenter
        lblClinicSub.TabIndex = 1
        ' 
        ' lblDoctorName
        ' 
        lblDoctorName.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDoctorName.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        lblDoctorName.Location = New Point(10, 56)
        lblDoctorName.Name = "lblDoctorName"
        lblDoctorName.Size = New Size(458, 18)
        lblDoctorName.Text = "Dr. Elena Cruz, MD"
        lblDoctorName.TextAlign = ContentAlignment.TopCenter
        lblDoctorName.TabIndex = 2
        ' 
        ' lblDoctorCreds
        ' 
        lblDoctorCreds.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDoctorCreds.ForeColor = Color.FromArgb(CByte(140), CByte(155), CByte(165))
        lblDoctorCreds.Location = New Point(10, 74)
        lblDoctorCreds.Name = "lblDoctorCreds"
        lblDoctorCreds.Size = New Size(458, 14)
        lblDoctorCreds.Text = "General Physician • PRC Lic. No. 0104829 • PTR No. 8392014"
        lblDoctorCreds.TextAlign = ContentAlignment.TopCenter
        lblDoctorCreds.TabIndex = 3
        ' 
        ' divHeader
        ' 
        divHeader.BackColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        divHeader.Location = New Point(20, 94)
        divHeader.Name = "divHeader"
        divHeader.Size = New Size(438, 2)
        divHeader.TabIndex = 4
        ' 
        ' lblPatientName
        ' 
        lblPatientName.AutoSize = True
        lblPatientName.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPatientName.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblPatientName.Location = New Point(20, 106)
        lblPatientName.Name = "lblPatientName"
        lblPatientName.Size = New Size(160, 15)
        lblPatientName.Text = "Patient: Maria Santos (PT-1048)"
        lblPatientName.TabIndex = 5
        ' 
        ' lblPatientAgeSex
        ' 
        lblPatientAgeSex.AutoSize = True
        lblPatientAgeSex.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPatientAgeSex.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblPatientAgeSex.Location = New Point(20, 126)
        lblPatientAgeSex.Name = "lblPatientAgeSex"
        lblPatientAgeSex.Size = New Size(130, 15)
        lblPatientAgeSex.Text = "Age: 34 • Sex: Female"
        lblPatientAgeSex.TabIndex = 6
        ' 
        ' lblDate
        ' 
        lblDate.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDate.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblDate.Location = New Point(260, 106)
        lblDate.Name = "lblDate"
        lblDate.Size = New Size(198, 15)
        lblDate.Text = "Date: Oct 02, 2026"
        lblDate.TextAlign = ContentAlignment.TopRight
        lblDate.TabIndex = 7
        ' 
        ' divPatient
        ' 
        divPatient.BackColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        divPatient.Location = New Point(20, 146)
        divPatient.Name = "divPatient"
        divPatient.Size = New Size(438, 1)
        divPatient.TabIndex = 8
        ' 
        ' pnlAllergyBanner
        ' 
        pnlAllergyBanner.BackColor = Color.FromArgb(CByte(254), CByte(242), CByte(242))
        pnlAllergyBanner.BorderStyle = BorderStyle.FixedSingle
        pnlAllergyBanner.Controls.Add(lblAllergyBanner)
        pnlAllergyBanner.Location = New Point(20, 153)
        pnlAllergyBanner.Name = "pnlAllergyBanner"
        pnlAllergyBanner.Size = New Size(438, 26)
        pnlAllergyBanner.TabIndex = 9
        ' 
        ' lblAllergyBanner
        ' 
        lblAllergyBanner.Dock = DockStyle.Fill
        lblAllergyBanner.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblAllergyBanner.ForeColor = Color.FromArgb(CByte(185), CByte(28), CByte(28))
        lblAllergyBanner.Location = New Point(0, 0)
        lblAllergyBanner.Name = "lblAllergyBanner"
        lblAllergyBanner.Size = New Size(436, 24)
        lblAllergyBanner.Text = "⚠ KNOWN ALLERGIES: PENICILLIN"
        lblAllergyBanner.TextAlign = ContentAlignment.MiddleCenter
        lblAllergyBanner.TabIndex = 0
        ' 
        ' lblRxSymbol
        ' 
        lblRxSymbol.AutoSize = True
        lblRxSymbol.Font = New Font("Georgia", 24.0F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        lblRxSymbol.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        lblRxSymbol.Location = New Point(20, 184)
        lblRxSymbol.Name = "lblRxSymbol"
        lblRxSymbol.Size = New Size(49, 38)
        lblRxSymbol.Text = "℞"
        lblRxSymbol.TabIndex = 10
        ' 
        ' txtMedicationDisplay
        ' 
        txtMedicationDisplay.BackColor = Color.White
        txtMedicationDisplay.BorderStyle = BorderStyle.None
        txtMedicationDisplay.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtMedicationDisplay.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        txtMedicationDisplay.Location = New Point(32, 224)
        txtMedicationDisplay.Multiline = True
        txtMedicationDisplay.Name = "txtMedicationDisplay"
        txtMedicationDisplay.ReadOnly = True
        txtMedicationDisplay.ScrollBars = ScrollBars.Vertical
        txtMedicationDisplay.Size = New Size(420, 108)
        txtMedicationDisplay.TabIndex = 11
        txtMedicationDisplay.Text = "Salbutamol 100mcg / actuation inhaler" & vbCrLf & "Sig: Inhale 2 puffs every 4-6 hours as needed for wheezing."
        ' 
        ' lblSigHeader
        ' 
        lblSigHeader.AutoSize = True
        lblSigHeader.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSigHeader.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblSigHeader.Location = New Point(32, 338)
        lblSigHeader.Name = "lblSigHeader"
        lblSigHeader.Size = New Size(150, 12)
        lblSigHeader.Text = "SPECIAL INSTRUCTIONS / ADVICE"
        lblSigHeader.TabIndex = 12
        ' 
        ' txtAdviceDisplay
        ' 
        txtAdviceDisplay.BackColor = Color.White
        txtAdviceDisplay.BorderStyle = BorderStyle.None
        txtAdviceDisplay.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtAdviceDisplay.ForeColor = Color.FromArgb(CByte(55), CByte(70), CByte(80))
        txtAdviceDisplay.Location = New Point(32, 354)
        txtAdviceDisplay.Multiline = True
        txtAdviceDisplay.Name = "txtAdviceDisplay"
        txtAdviceDisplay.ReadOnly = True
        txtAdviceDisplay.Size = New Size(420, 68)
        txtAdviceDisplay.TabIndex = 13
        txtAdviceDisplay.Text = "Rinse mouth thoroughly with water after inhalation. Keep inhaler at room temperature."
        ' 
        ' divFooter
        ' 
        divFooter.BackColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        divFooter.Location = New Point(20, 428)
        divFooter.Name = "divFooter"
        divFooter.Size = New Size(438, 1)
        divFooter.TabIndex = 13
        ' 
        ' lblSignatureLine
        ' 
        lblSignatureLine.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSignatureLine.ForeColor = Color.FromArgb(CByte(140), CByte(155), CByte(165))
        lblSignatureLine.Location = New Point(240, 480)
        lblSignatureLine.Name = "lblSignatureLine"
        lblSignatureLine.Size = New Size(218, 15)
        lblSignatureLine.Text = "_______________________________"
        lblSignatureLine.TextAlign = ContentAlignment.TopCenter
        lblSignatureLine.TabIndex = 14
        ' 
        ' lblSignDoctor
        ' 
        lblSignDoctor.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSignDoctor.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblSignDoctor.Location = New Point(240, 498)
        lblSignDoctor.Name = "lblSignDoctor"
        lblSignDoctor.Size = New Size(218, 16)
        lblSignDoctor.Text = "Dr. Elena Cruz, MD"
        lblSignDoctor.TextAlign = ContentAlignment.TopCenter
        lblSignDoctor.TabIndex = 15
        ' 
        ' lblSignLic
        ' 
        lblSignLic.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSignLic.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblSignLic.Location = New Point(240, 516)
        lblSignLic.Name = "lblSignLic"
        lblSignLic.Size = New Size(218, 14)
        lblSignLic.Text = "Lic. No. 0104829"
        lblSignLic.TextAlign = ContentAlignment.TopCenter
        lblSignLic.TabIndex = 16
        ' 
        ' btnPrint
        ' 
        btnPrint.BackColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnPrint.BorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnPrint.BorderRadius = 8
        btnPrint.BorderSize = 0
        btnPrint.Cursor = Cursors.Hand
        btnPrint.FlatAppearance.BorderSize = 0
        btnPrint.FlatStyle = FlatStyle.Flat
        btnPrint.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnPrint.ForeColor = Color.White
        btnPrint.Location = New Point(260, 595)
        btnPrint.MouseEnterBackColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        btnPrint.MouseEnterBorderColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        btnPrint.MouseEnterBorderSize = 0
        btnPrint.MouseEnterFont = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnPrint.MouseEnterForeColor = Color.White
        btnPrint.MouseLeaveBackColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnPrint.MouseLeaveBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnPrint.MouseLeaveBorderSize = 0
        btnPrint.MouseLeaveFont = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnPrint.MouseLeaveForeColor = Color.White
        btnPrint.Name = "btnPrint"
        btnPrint.Size = New Size(140, 36)
        btnPrint.Text = "🖨️ Print Slip"
        btnPrint.UseVisualStyleBackColor = False
        btnPrint.TabIndex = 1
        ' 
        ' btnClose
        ' 
        btnClose.BackColor = Color.White
        btnClose.BorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnClose.BorderRadius = 8
        btnClose.BorderSize = 1
        btnClose.Cursor = Cursors.Hand
        btnClose.FlatAppearance.BorderSize = 0
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnClose.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        btnClose.Location = New Point(410, 595)
        btnClose.MouseEnterBackColor = Color.FromArgb(CByte(245), CByte(249), CByte(251))
        btnClose.MouseEnterBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnClose.MouseEnterBorderSize = 1
        btnClose.MouseEnterFont = New Font("Segoe UI", 9.0F)
        btnClose.MouseEnterForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnClose.MouseLeaveBackColor = Color.White
        btnClose.MouseLeaveBorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnClose.MouseLeaveBorderSize = 1
        btnClose.MouseLeaveFont = New Font("Segoe UI", 9.0F)
        btnClose.MouseLeaveForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(90, 36)
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = False
        btnClose.TabIndex = 2
        ' 
        ' PrescriptionDialog
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(244), CByte(247), CByte(249))
        ClientSize = New Size(520, 645)
        Controls.Add(btnClose)
        Controls.Add(btnPrint)
        Controls.Add(pnlSheet)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "DoctorPrescriptionDialog"
        StartPosition = FormStartPosition.CenterParent
        Text = "Medical Prescription (Rx) — Dr. Elena Cruz"
        pnlSheet.ResumeLayout(False)
        pnlSheet.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlSheet As Panel
    Friend WithEvents lblClinicTitle As Label
    Friend WithEvents lblClinicSub As Label
    Friend WithEvents lblDoctorName As Label
    Friend WithEvents lblDoctorCreds As Label
    Friend WithEvents divHeader As Panel
    Friend WithEvents lblPatientName As Label
    Friend WithEvents lblPatientAgeSex As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents divPatient As Panel
    Friend WithEvents pnlAllergyBanner As Panel
    Friend WithEvents lblAllergyBanner As Label
    Friend WithEvents lblRxSymbol As Label
    Friend WithEvents txtMedicationDisplay As TextBox
    Friend WithEvents lblSigHeader As Label
    Friend WithEvents txtAdviceDisplay As TextBox
    Friend WithEvents divFooter As Panel
    Friend WithEvents lblSignatureLine As Label
    Friend WithEvents lblSignDoctor As Label
    Friend WithEvents lblSignLic As Label
    Friend WithEvents btnPrint As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnClose As Ferrando.UI.WinForms.Controles.FButton

End Class
