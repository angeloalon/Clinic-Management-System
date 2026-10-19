<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DoctorLaboratoryDialog
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
        lblSheetTitle = New Label()
        lblPatientName = New Label()
        lblPatientAgeSex = New Label()
        lblDate = New Label()
        lblDiagnosisHeader = New Label()
        lblDiagnosisValue = New Label()
        divPatient = New Panel()
        lblGroupHematology = New Label()
        chkCBC = New CheckBox()
        chkBloodType = New CheckBox()
        chkESR = New CheckBox()
        lblGroupMicroscopy = New Label()
        chkUrinalysis = New CheckBox()
        chkFecalysis = New CheckBox()
        lblGroupChemistry = New Label()
        chkFBS = New CheckBox()
        chkHbA1c = New CheckBox()
        chkLipid = New CheckBox()
        chkCreatinine = New CheckBox()
        chkLiver = New CheckBox()
        chkUricAcid = New CheckBox()
        lblGroupImaging = New Label()
        chkCXR = New CheckBox()
        chkECG = New CheckBox()
        chkSputum = New CheckBox()
        lblInstructions = New Label()
        txtInstructions = New TextBox()
        divFooter = New Panel()
        lblSignatureLine = New Label()
        lblSignDoctor = New Label()
        lblSignLic = New Label()
        btnPrint = New Ferrando.UI.WinForms.Controles.FButton()
        btnClose = New Ferrando.UI.WinForms.Controles.FButton()
        pnlSheet.SuspendLayout()
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
        pnlSheet.Controls.Add(lblSheetTitle)
        pnlSheet.Controls.Add(lblPatientName)
        pnlSheet.Controls.Add(lblPatientAgeSex)
        pnlSheet.Controls.Add(lblDate)
        pnlSheet.Controls.Add(lblDiagnosisHeader)
        pnlSheet.Controls.Add(lblDiagnosisValue)
        pnlSheet.Controls.Add(divPatient)
        pnlSheet.Controls.Add(lblGroupHematology)
        pnlSheet.Controls.Add(chkCBC)
        pnlSheet.Controls.Add(chkBloodType)
        pnlSheet.Controls.Add(chkESR)
        pnlSheet.Controls.Add(lblGroupMicroscopy)
        pnlSheet.Controls.Add(chkUrinalysis)
        pnlSheet.Controls.Add(chkFecalysis)
        pnlSheet.Controls.Add(lblGroupChemistry)
        pnlSheet.Controls.Add(chkFBS)
        pnlSheet.Controls.Add(chkHbA1c)
        pnlSheet.Controls.Add(chkLipid)
        pnlSheet.Controls.Add(chkCreatinine)
        pnlSheet.Controls.Add(chkLiver)
        pnlSheet.Controls.Add(chkUricAcid)
        pnlSheet.Controls.Add(lblGroupImaging)
        pnlSheet.Controls.Add(chkCXR)
        pnlSheet.Controls.Add(chkECG)
        pnlSheet.Controls.Add(chkSputum)
        pnlSheet.Controls.Add(lblInstructions)
        pnlSheet.Controls.Add(txtInstructions)
        pnlSheet.Controls.Add(divFooter)
        pnlSheet.Controls.Add(lblSignatureLine)
        pnlSheet.Controls.Add(lblSignDoctor)
        pnlSheet.Controls.Add(lblSignLic)
        pnlSheet.Location = New Point(18, 16)
        pnlSheet.Name = "pnlSheet"
        pnlSheet.Size = New Size(502, 608)
        pnlSheet.TabIndex = 0
        ' 
        ' lblClinicTitle
        ' 
        lblClinicTitle.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblClinicTitle.ForeColor = Color.FromArgb(CByte(22), CByte(51), CByte(65))
        lblClinicTitle.Location = New Point(10, 12)
        lblClinicTitle.Name = "lblClinicTitle"
        lblClinicTitle.Size = New Size(480, 20)
        lblClinicTitle.Text = "UNIVERSITY OF CALOOCAN CITY"
        lblClinicTitle.TextAlign = ContentAlignment.TopCenter
        lblClinicTitle.TabIndex = 0
        ' 
        ' lblClinicSub
        ' 
        lblClinicSub.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblClinicSub.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblClinicSub.Location = New Point(10, 32)
        lblClinicSub.Name = "lblClinicSub"
        lblClinicSub.Size = New Size(480, 16)
        lblClinicSub.Text = "UCC HEALTH CLINIC • LABORATORY & DIAGNOSTIC SERVICES"
        lblClinicSub.TextAlign = ContentAlignment.TopCenter
        lblClinicSub.TabIndex = 1
        ' 
        ' lblDoctorName
        ' 
        lblDoctorName.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDoctorName.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        lblDoctorName.Location = New Point(10, 50)
        lblDoctorName.Name = "lblDoctorName"
        lblDoctorName.Size = New Size(480, 18)
        lblDoctorName.Text = "Dr. Elena Cruz, MD"
        lblDoctorName.TextAlign = ContentAlignment.TopCenter
        lblDoctorName.TabIndex = 2
        ' 
        ' lblDoctorCreds
        ' 
        lblDoctorCreds.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDoctorCreds.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblDoctorCreds.Location = New Point(10, 68)
        lblDoctorCreds.Name = "lblDoctorCreds"
        lblDoctorCreds.Size = New Size(480, 14)
        lblDoctorCreds.Text = "Internal Medicine • PRC License No. 0128492"
        lblDoctorCreds.TextAlign = ContentAlignment.TopCenter
        lblDoctorCreds.TabIndex = 3
        ' 
        ' divHeader
        ' 
        divHeader.BackColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        divHeader.Location = New Point(20, 86)
        divHeader.Name = "divHeader"
        divHeader.Size = New Size(460, 2)
        divHeader.TabIndex = 4
        ' 
        ' lblSheetTitle
        ' 
        lblSheetTitle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSheetTitle.ForeColor = Color.FromArgb(CByte(22), CByte(51), CByte(65))
        lblSheetTitle.Location = New Point(20, 94)
        lblSheetTitle.Name = "lblSheetTitle"
        lblSheetTitle.Size = New Size(460, 18)
        lblSheetTitle.Text = "LABORATORY & DIAGNOSTIC REQUEST"
        lblSheetTitle.TextAlign = ContentAlignment.MiddleCenter
        lblSheetTitle.TabIndex = 5
        ' 
        ' lblPatientName
        ' 
        lblPatientName.AutoSize = True
        lblPatientName.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPatientName.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblPatientName.Location = New Point(20, 118)
        lblPatientName.Name = "lblPatientName"
        lblPatientName.Size = New Size(180, 15)
        lblPatientName.TabIndex = 6
        lblPatientName.Text = "Patient: Maria Santos (PT-1048)"
        ' 
        ' lblPatientAgeSex
        ' 
        lblPatientAgeSex.AutoSize = True
        lblPatientAgeSex.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPatientAgeSex.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblPatientAgeSex.Location = New Point(20, 136)
        lblPatientAgeSex.Name = "lblPatientAgeSex"
        lblPatientAgeSex.Size = New Size(108, 13)
        lblPatientAgeSex.TabIndex = 7
        lblPatientAgeSex.Text = "34 years old • Female"
        ' 
        ' lblDate
        ' 
        lblDate.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDate.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblDate.Location = New Point(280, 118)
        lblDate.Name = "lblDate"
        lblDate.Size = New Size(200, 15)
        lblDate.Text = "Date: October 02, 2026"
        lblDate.TextAlign = ContentAlignment.TopRight
        lblDate.TabIndex = 8
        ' 
        ' lblDiagnosisHeader
        ' 
        lblDiagnosisHeader.AutoSize = True
        lblDiagnosisHeader.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDiagnosisHeader.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        lblDiagnosisHeader.Location = New Point(20, 154)
        lblDiagnosisHeader.Name = "lblDiagnosisHeader"
        lblDiagnosisHeader.Size = New Size(111, 13)
        lblDiagnosisHeader.TabIndex = 9
        lblDiagnosisHeader.Text = "Clinical Impression:"
        ' 
        ' lblDiagnosisValue
        ' 
        lblDiagnosisValue.AutoSize = True
        lblDiagnosisValue.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDiagnosisValue.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        lblDiagnosisValue.Location = New Point(135, 154)
        lblDiagnosisValue.Name = "lblDiagnosisValue"
        lblDiagnosisValue.Size = New Size(240, 13)
        lblDiagnosisValue.TabIndex = 10
        lblDiagnosisValue.Text = "Essential Hypertension, Type 2 Diabetes Mellitus"
        ' 
        ' divPatient
        ' 
        divPatient.BackColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        divPatient.Location = New Point(20, 172)
        divPatient.Name = "divPatient"
        divPatient.Size = New Size(460, 1)
        divPatient.TabIndex = 11
        ' 
        ' lblGroupHematology
        ' 
        lblGroupHematology.AutoSize = True
        lblGroupHematology.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblGroupHematology.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        lblGroupHematology.Location = New Point(20, 180)
        lblGroupHematology.Name = "lblGroupHematology"
        lblGroupHematology.Size = New Size(81, 13)
        lblGroupHematology.TabIndex = 12
        lblGroupHematology.Text = "HEMATOLOGY"
        ' 
        ' chkCBC
        ' 
        chkCBC.AutoSize = True
        chkCBC.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chkCBC.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        chkCBC.Location = New Point(24, 198)
        chkCBC.Name = "chkCBC"
        chkCBC.Size = New Size(195, 17)
        chkCBC.TabIndex = 13
        chkCBC.Text = "Complete Blood Count (CBC/Plt)"
        chkCBC.UseVisualStyleBackColor = True
        ' 
        ' chkBloodType
        ' 
        chkBloodType.AutoSize = True
        chkBloodType.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chkBloodType.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        chkBloodType.Location = New Point(24, 218)
        chkBloodType.Name = "chkBloodType"
        chkBloodType.Size = New Size(166, 17)
        chkBloodType.TabIndex = 14
        chkBloodType.Text = "Blood Typing (ABO and Rh)"
        chkBloodType.UseVisualStyleBackColor = True
        ' 
        ' chkESR
        ' 
        chkESR.AutoSize = True
        chkESR.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chkESR.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        chkESR.Location = New Point(24, 238)
        chkESR.Name = "chkESR"
        chkESR.Size = New Size(181, 17)
        chkESR.TabIndex = 15
        chkESR.Text = "ESR (Sedimentation Rate)"
        chkESR.UseVisualStyleBackColor = True
        ' 
        ' lblGroupMicroscopy
        ' 
        lblGroupMicroscopy.AutoSize = True
        lblGroupMicroscopy.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblGroupMicroscopy.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        lblGroupMicroscopy.Location = New Point(255, 180)
        lblGroupMicroscopy.Name = "lblGroupMicroscopy"
        lblGroupMicroscopy.Size = New Size(130, 13)
        lblGroupMicroscopy.TabIndex = 16
        lblGroupMicroscopy.Text = "CLINICAL MICROSCOPY"
        ' 
        ' chkUrinalysis
        ' 
        chkUrinalysis.AutoSize = True
        chkUrinalysis.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chkUrinalysis.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        chkUrinalysis.Location = New Point(260, 198)
        chkUrinalysis.Name = "chkUrinalysis"
        chkUrinalysis.Size = New Size(116, 17)
        chkUrinalysis.TabIndex = 17
        chkUrinalysis.Text = "Routine Urinalysis"
        chkUrinalysis.UseVisualStyleBackColor = True
        ' 
        ' chkFecalysis
        ' 
        chkFecalysis.AutoSize = True
        chkFecalysis.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chkFecalysis.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        chkFecalysis.Location = New Point(260, 218)
        chkFecalysis.Name = "chkFecalysis"
        chkFecalysis.Size = New Size(153, 17)
        chkFecalysis.TabIndex = 18
        chkFecalysis.Text = "Fecalysis / Stool Analysis"
        chkFecalysis.UseVisualStyleBackColor = True
        ' 
        ' lblGroupChemistry
        ' 
        lblGroupChemistry.AutoSize = True
        lblGroupChemistry.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblGroupChemistry.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        lblGroupChemistry.Location = New Point(20, 264)
        lblGroupChemistry.Name = "lblGroupChemistry"
        lblGroupChemistry.Size = New Size(110, 13)
        lblGroupChemistry.TabIndex = 19
        lblGroupChemistry.Text = "BLOOD CHEMISTRY"
        ' 
        ' chkFBS
        ' 
        chkFBS.AutoSize = True
        chkFBS.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chkFBS.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        chkFBS.Location = New Point(24, 282)
        chkFBS.Name = "chkFBS"
        chkFBS.Size = New Size(155, 17)
        chkFBS.TabIndex = 20
        chkFBS.Text = "Fasting Blood Sugar (FBS)"
        chkFBS.UseVisualStyleBackColor = True
        ' 
        ' chkHbA1c
        ' 
        chkHbA1c.AutoSize = True
        chkHbA1c.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chkHbA1c.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        chkHbA1c.Location = New Point(24, 302)
        chkHbA1c.Name = "chkHbA1c"
        chkHbA1c.Size = New Size(116, 17)
        chkHbA1c.TabIndex = 21
        chkHbA1c.Text = "Hemoglobin A1c"
        chkHbA1c.UseVisualStyleBackColor = True
        ' 
        ' chkLipid
        ' 
        chkLipid.AutoSize = True
        chkLipid.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chkLipid.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        chkLipid.Location = New Point(24, 322)
        chkLipid.Name = "chkLipid"
        chkLipid.Size = New Size(198, 17)
        chkLipid.TabIndex = 22
        chkLipid.Text = "Lipid Profile (Chol, HDL, LDL, Trig)"
        chkLipid.UseVisualStyleBackColor = True
        ' 
        ' chkCreatinine
        ' 
        chkCreatinine.AutoSize = True
        chkCreatinine.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chkCreatinine.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        chkCreatinine.Location = New Point(260, 282)
        chkCreatinine.Name = "chkCreatinine"
        chkCreatinine.Size = New Size(149, 17)
        chkCreatinine.TabIndex = 23
        chkCreatinine.Text = "Serum Creatinine & BUN"
        chkCreatinine.UseVisualStyleBackColor = True
        ' 
        ' chkLiver
        ' 
        chkLiver.AutoSize = True
        chkLiver.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chkLiver.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        chkLiver.Location = New Point(260, 302)
        chkLiver.Name = "chkLiver"
        chkLiver.Size = New Size(174, 17)
        chkLiver.TabIndex = 24
        chkLiver.Text = "SGPT / ALT & SGOT / AST (LFT)"
        chkLiver.UseVisualStyleBackColor = True
        ' 
        ' chkUricAcid
        ' 
        chkUricAcid.AutoSize = True
        chkUricAcid.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chkUricAcid.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        chkUricAcid.Location = New Point(260, 322)
        chkUricAcid.Name = "chkUricAcid"
        chkUricAcid.Size = New Size(143, 17)
        chkUricAcid.TabIndex = 25
        chkUricAcid.Text = "Serum Uric Acid (BUA)"
        chkUricAcid.UseVisualStyleBackColor = True
        ' 
        ' lblGroupImaging
        ' 
        lblGroupImaging.AutoSize = True
        lblGroupImaging.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblGroupImaging.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        lblGroupImaging.Location = New Point(20, 348)
        lblGroupImaging.Name = "lblGroupImaging"
        lblGroupImaging.Size = New Size(183, 13)
        lblGroupImaging.TabIndex = 26
        lblGroupImaging.Text = "IMAGING & CARDIOPULMONARY"
        ' 
        ' chkCXR
        ' 
        chkCXR.AutoSize = True
        chkCXR.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chkCXR.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        chkCXR.Location = New Point(24, 366)
        chkCXR.Name = "chkCXR"
        chkCXR.Size = New Size(149, 17)
        chkCXR.TabIndex = 27
        chkCXR.Text = "Chest X-Ray (PA / Chest)"
        chkCXR.UseVisualStyleBackColor = True
        ' 
        ' chkECG
        ' 
        chkECG.AutoSize = True
        chkECG.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chkECG.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        chkECG.Location = New Point(200, 366)
        chkECG.Name = "chkECG"
        chkECG.Size = New Size(175, 17)
        chkECG.TabIndex = 28
        chkECG.Text = "12-Lead Electrocardiogram"
        chkECG.UseVisualStyleBackColor = True
        ' 
        ' chkSputum
        ' 
        chkSputum.AutoSize = True
        chkSputum.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chkSputum.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        chkSputum.Location = New Point(386, 366)
        chkSputum.Name = "chkSputum"
        chkSputum.Size = New Size(95, 17)
        chkSputum.TabIndex = 29
        chkSputum.Text = "Sputum AFB"
        chkSputum.UseVisualStyleBackColor = True
        ' 
        ' lblInstructions
        ' 
        lblInstructions.AutoSize = True
        lblInstructions.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblInstructions.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        lblInstructions.Location = New Point(20, 396)
        lblInstructions.Name = "lblInstructions"
        lblInstructions.Size = New Size(183, 13)
        lblInstructions.TabIndex = 30
        lblInstructions.Text = "SPECIAL CLINICAL INSTRUCTIONS:"
        ' 
        ' txtInstructions
        ' 
        txtInstructions.BackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        txtInstructions.BorderStyle = BorderStyle.FixedSingle
        txtInstructions.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtInstructions.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        txtInstructions.Location = New Point(20, 414)
        txtInstructions.Multiline = True
        txtInstructions.Name = "txtInstructions"
        txtInstructions.ScrollBars = ScrollBars.Vertical
        txtInstructions.Size = New Size(460, 56)
        txtInstructions.TabIndex = 31
        txtInstructions.Text = "10 to 12 hours fasting required prior to blood draw. Bring official laboratory results to follow-up clinic visit."
        ' 
        ' divFooter
        ' 
        divFooter.BackColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        divFooter.Location = New Point(20, 482)
        divFooter.Name = "divFooter"
        divFooter.Size = New Size(460, 1)
        divFooter.TabIndex = 32
        ' 
        ' lblSignatureLine
        ' 
        lblSignatureLine.BackColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        lblSignatureLine.Location = New Point(290, 560)
        lblSignatureLine.Name = "lblSignatureLine"
        lblSignatureLine.Size = New Size(190, 1)
        lblSignatureLine.TabIndex = 33
        ' 
        ' lblSignDoctor
        ' 
        lblSignDoctor.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSignDoctor.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblSignDoctor.Location = New Point(290, 564)
        lblSignDoctor.Name = "lblSignDoctor"
        lblSignDoctor.Size = New Size(190, 16)
        lblSignDoctor.Text = "Elena Cruz, MD"
        lblSignDoctor.TextAlign = ContentAlignment.TopCenter
        lblSignDoctor.TabIndex = 34
        ' 
        ' lblSignLic
        ' 
        lblSignLic.Font = New Font("Segoe UI", 7.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSignLic.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblSignLic.Location = New Point(290, 580)
        lblSignLic.Name = "lblSignLic"
        lblSignLic.Size = New Size(190, 14)
        lblSignLic.Text = "Lic No. 0128492 • PTR No. 8941203"
        lblSignLic.TextAlign = ContentAlignment.TopCenter
        lblSignLic.TabIndex = 35
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
        btnPrint.Location = New Point(330, 636)
        btnPrint.MouseEnterBackColor = Color.FromArgb(CByte(28), CByte(115), CByte(101))
        btnPrint.MouseEnterBorderColor = Color.FromArgb(CByte(28), CByte(115), CByte(101))
        btnPrint.MouseEnterBorderSize = 0
        btnPrint.MouseEnterFont = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnPrint.MouseEnterForeColor = Color.White
        btnPrint.MouseLeaveBackColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnPrint.MouseLeaveBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnPrint.MouseLeaveBorderSize = 0
        btnPrint.MouseLeaveFont = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnPrint.MouseLeaveForeColor = Color.White
        btnPrint.Name = "btnPrint"
        btnPrint.Size = New Size(190, 34)
        btnPrint.TabIndex = 1
        btnPrint.Text = "🖨️ Print Lab Request"
        btnPrint.UseVisualStyleBackColor = False
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
        btnClose.ForeColor = Color.FromArgb(CByte(80), CByte(100), CByte(115))
        btnClose.Location = New Point(232, 636)
        btnClose.MouseEnterBackColor = Color.FromArgb(CByte(245), CByte(249), CByte(251))
        btnClose.MouseEnterBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnClose.MouseEnterBorderSize = 1
        btnClose.MouseEnterFont = New Font("Segoe UI", 9.0F, FontStyle.Regular)
        btnClose.MouseEnterForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnClose.MouseLeaveBackColor = Color.White
        btnClose.MouseLeaveBorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnClose.MouseLeaveBorderSize = 1
        btnClose.MouseLeaveFont = New Font("Segoe UI", 9.0F, FontStyle.Regular)
        btnClose.MouseLeaveForeColor = Color.FromArgb(CByte(80), CByte(100), CByte(115))
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(88, 34)
        btnClose.TabIndex = 2
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' LaboratoryDialog
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(244), CByte(247), CByte(249))
        ClientSize = New Size(540, 686)
        Controls.Add(btnClose)
        Controls.Add(btnPrint)
        Controls.Add(pnlSheet)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "DoctorLaboratoryDialog"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterParent
        Text = "Laboratory / Diagnostic Request Slip"
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
    Friend WithEvents lblSheetTitle As Label
    Friend WithEvents lblPatientName As Label
    Friend WithEvents lblPatientAgeSex As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents lblDiagnosisHeader As Label
    Friend WithEvents lblDiagnosisValue As Label
    Friend WithEvents divPatient As Panel
    Friend WithEvents lblGroupHematology As Label
    Friend WithEvents chkCBC As CheckBox
    Friend WithEvents chkBloodType As CheckBox
    Friend WithEvents chkESR As CheckBox
    Friend WithEvents lblGroupMicroscopy As Label
    Friend WithEvents chkUrinalysis As CheckBox
    Friend WithEvents chkFecalysis As CheckBox
    Friend WithEvents lblGroupChemistry As Label
    Friend WithEvents chkFBS As CheckBox
    Friend WithEvents chkHbA1c As CheckBox
    Friend WithEvents chkLipid As CheckBox
    Friend WithEvents chkCreatinine As CheckBox
    Friend WithEvents chkLiver As CheckBox
    Friend WithEvents chkUricAcid As CheckBox
    Friend WithEvents lblGroupImaging As Label
    Friend WithEvents chkCXR As CheckBox
    Friend WithEvents chkECG As CheckBox
    Friend WithEvents chkSputum As CheckBox
    Friend WithEvents lblInstructions As Label
    Friend WithEvents txtInstructions As TextBox
    Friend WithEvents divFooter As Panel
    Friend WithEvents lblSignatureLine As Label
    Friend WithEvents lblSignDoctor As Label
    Friend WithEvents lblSignLic As Label
    Friend WithEvents btnPrint As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnClose As Ferrando.UI.WinForms.Controles.FButton

End Class
