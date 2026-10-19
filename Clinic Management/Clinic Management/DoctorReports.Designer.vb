<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DoctorReports
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
        lblSubtitle = New Label()
        btnExport = New Ferrando.UI.WinForms.Controles.FButton()
        cardKpi1 = New Ferrando.UI.WinForms.Controles.FCard()
        lblKpi1Title = New Label()
        lblKpi1Value = New Label()
        lblKpi1Context = New Label()
        cardKpi2 = New Ferrando.UI.WinForms.Controles.FCard()
        lblKpi2Title = New Label()
        lblKpi2Value = New Label()
        lblKpi2Context = New Label()
        cardKpi3 = New Ferrando.UI.WinForms.Controles.FCard()
        lblKpi3Title = New Label()
        lblKpi3Value = New Label()
        lblKpi3Context = New Label()
        cardVolume = New Ferrando.UI.WinForms.Controles.FCard()
        lblVolumeTitle = New Label()
        cardBar1 = New Ferrando.UI.WinForms.Controles.FCard()
        lblWeek1 = New Label()
        cardBar2 = New Ferrando.UI.WinForms.Controles.FCard()
        lblWeek2 = New Label()
        cardBar3 = New Ferrando.UI.WinForms.Controles.FCard()
        lblWeek3 = New Label()
        cardBar4 = New Ferrando.UI.WinForms.Controles.FCard()
        lblWeek4 = New Label()
        cardBar5 = New Ferrando.UI.WinForms.Controles.FCard()
        lblWeek5 = New Label()
        cardDiagnoses = New Ferrando.UI.WinForms.Controles.FCard()
        lblDiagnosesTitle = New Label()
        lblDiag1Name = New Label()
        lblDiag1Value = New Label()
        lblDiag2Name = New Label()
        lblDiag2Value = New Label()
        lblDiag3Name = New Label()
        lblDiag3Value = New Label()
        lblDiag4Name = New Label()
        lblDiag4Value = New Label()
        cardHistory = New Ferrando.UI.WinForms.Controles.FCard()
        lblHistoryTitle = New Label()
        lblCol1 = New Label()
        lblCol2 = New Label()
        lblCol3 = New Label()
        lblCol4 = New Label()
        divHeader = New Panel()
        lblRow1Col1 = New Label()
        lblRow1Col2 = New Label()
        lblRow1Col3 = New Label()
        lblRow1Col4 = New Label()
        divRow1 = New Panel()
        lblRow2Col1 = New Label()
        lblRow2Col2 = New Label()
        lblRow2Col3 = New Label()
        lblRow2Col4 = New Label()
        divRow2 = New Panel()
        lblRow3Col1 = New Label()
        lblRow3Col2 = New Label()
        lblRow3Col3 = New Label()
        lblRow3Col4 = New Label()
        divRow3 = New Panel()
        sideBar.SuspendLayout()
        namePlaceHolder.SuspendLayout()
        FCard1.SuspendLayout()
        mainScreen.SuspendLayout()
        cardKpi1.SuspendLayout()
        cardKpi2.SuspendLayout()
        cardKpi3.SuspendLayout()
        cardVolume.SuspendLayout()
        cardDiagnoses.SuspendLayout()
        cardHistory.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.BackColor = Color.FromArgb(CByte(244), CByte(247), CByte(249))
        lblTitle.Font = New Font("Segoe UI", 18.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.FromArgb(CByte(22), CByte(51), CByte(65))
        lblTitle.Location = New Point(28, 18)
        lblTitle.Text = "Reports"
        lblTitle.Name = "lblTitle"
        lblTitle.TabIndex = 0
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.AutoSize = True
        lblSubtitle.BackColor = Color.FromArgb(CByte(244), CByte(247), CByte(249))
        lblSubtitle.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSubtitle.ForeColor = Color.FromArgb(CByte(115), CByte(138), CByte(148))
        lblSubtitle.Location = New Point(30, 54)
        lblSubtitle.Text = "Operational insights • September 1–22, 2026"
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.TabIndex = 1
        ' 
        ' btnExport
        ' 
        btnExport.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        btnExport.BorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnExport.BorderRadius = 8
        btnExport.BorderSize = 1
        btnExport.Cursor = Cursors.Hand
        btnExport.FlatAppearance.BorderSize = 0
        btnExport.FlatStyle = FlatStyle.Flat
        btnExport.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnExport.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnExport.Location = New Point(713, 22)
        btnExport.MouseEnterBackColor = Color.FromArgb(CByte(245), CByte(249), CByte(251))
        btnExport.MouseEnterBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnExport.MouseEnterBorderSize = 1
        btnExport.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnExport.MouseEnterForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnExport.MouseLeaveBackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        btnExport.MouseLeaveBorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnExport.MouseLeaveBorderSize = 1
        btnExport.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnExport.MouseLeaveForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnExport.Size = New Size(90, 30)
        btnExport.Text = "Export report"
        btnExport.UseVisualStyleBackColor = False
        btnExport.Name = "btnExport"
        btnExport.TabIndex = 2
        ' 
        ' cardKpi1
        ' 
        cardKpi1.Controls.Add(lblKpi1Title)
        cardKpi1.Controls.Add(lblKpi1Value)
        cardKpi1.Controls.Add(lblKpi1Context)
        cardKpi1.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardKpi1.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardKpi1.BorderHoverColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardKpi1.BorderRadius = 12
        cardKpi1.BorderSize = 1
        cardKpi1.EnableShadow = True
        cardKpi1.HoverTintColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardKpi1.Location = New Point(28, 78)
        cardKpi1.ShadowDepth = 4
        cardKpi1.Size = New Size(250, 106)
        cardKpi1.Name = "cardKpi1"
        cardKpi1.TabIndex = 3
        ' 
        ' lblKpi1Title
        ' 
        lblKpi1Title.AutoSize = True
        lblKpi1Title.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblKpi1Title.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblKpi1Title.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblKpi1Title.Location = New Point(16, 13)
        lblKpi1Title.Text = "Appointments"
        lblKpi1Title.Name = "lblKpi1Title"
        lblKpi1Title.TabIndex = 4
        ' 
        ' lblKpi1Value
        ' 
        lblKpi1Value.AutoSize = True
        lblKpi1Value.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblKpi1Value.Font = New Font("Segoe UI", 25.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblKpi1Value.ForeColor = Color.FromArgb(CByte(22), CByte(51), CByte(65))
        lblKpi1Value.Location = New Point(14, 33)
        lblKpi1Value.Text = "50"
        lblKpi1Value.Name = "lblKpi1Value"
        lblKpi1Value.TabIndex = 5
        ' 
        ' lblKpi1Context
        ' 
        lblKpi1Context.AutoSize = True
        lblKpi1Context.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblKpi1Context.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblKpi1Context.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        lblKpi1Context.Location = New Point(16, 78)
        lblKpi1Context.Text = "+8% vs Aug"
        lblKpi1Context.Name = "lblKpi1Context"
        lblKpi1Context.TabIndex = 6
        ' 
        ' cardKpi2
        ' 
        cardKpi2.Controls.Add(lblKpi2Title)
        cardKpi2.Controls.Add(lblKpi2Value)
        cardKpi2.Controls.Add(lblKpi2Context)
        cardKpi2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardKpi2.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardKpi2.BorderHoverColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardKpi2.BorderRadius = 12
        cardKpi2.BorderSize = 1
        cardKpi2.EnableShadow = True
        cardKpi2.HoverTintColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardKpi2.Location = New Point(290, 78)
        cardKpi2.ShadowDepth = 4
        cardKpi2.Size = New Size(250, 106)
        cardKpi2.Name = "cardKpi2"
        cardKpi2.TabIndex = 7
        ' 
        ' lblKpi2Title
        ' 
        lblKpi2Title.AutoSize = True
        lblKpi2Title.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblKpi2Title.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblKpi2Title.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblKpi2Title.Location = New Point(16, 13)
        lblKpi2Title.Text = "Completion rate"
        lblKpi2Title.Name = "lblKpi2Title"
        lblKpi2Title.TabIndex = 8
        ' 
        ' lblKpi2Value
        ' 
        lblKpi2Value.AutoSize = True
        lblKpi2Value.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblKpi2Value.Font = New Font("Segoe UI", 25.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblKpi2Value.ForeColor = Color.FromArgb(CByte(22), CByte(51), CByte(65))
        lblKpi2Value.Location = New Point(14, 33)
        lblKpi2Value.Text = "90%"
        lblKpi2Value.Name = "lblKpi2Value"
        lblKpi2Value.TabIndex = 9
        ' 
        ' lblKpi2Context
        ' 
        lblKpi2Context.AutoSize = True
        lblKpi2Context.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblKpi2Context.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblKpi2Context.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        lblKpi2Context.Location = New Point(16, 78)
        lblKpi2Context.Text = "240 completed"
        lblKpi2Context.Name = "lblKpi2Context"
        lblKpi2Context.TabIndex = 10
        ' 
        ' cardKpi3
        ' 
        cardKpi3.Controls.Add(lblKpi3Title)
        cardKpi3.Controls.Add(lblKpi3Value)
        cardKpi3.Controls.Add(lblKpi3Context)
        cardKpi3.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardKpi3.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardKpi3.BorderHoverColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardKpi3.BorderRadius = 12
        cardKpi3.BorderSize = 1
        cardKpi3.EnableShadow = True
        cardKpi3.HoverTintColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardKpi3.Location = New Point(553, 78)
        cardKpi3.ShadowDepth = 4
        cardKpi3.Size = New Size(250, 106)
        cardKpi3.Name = "cardKpi3"
        cardKpi3.TabIndex = 11
        ' 
        ' lblKpi3Title
        ' 
        lblKpi3Title.AutoSize = True
        lblKpi3Title.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblKpi3Title.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblKpi3Title.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblKpi3Title.Location = New Point(16, 13)
        lblKpi3Title.Text = "Patients seen"
        lblKpi3Title.Name = "lblKpi3Title"
        lblKpi3Title.TabIndex = 12
        ' 
        ' lblKpi3Value
        ' 
        lblKpi3Value.AutoSize = True
        lblKpi3Value.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblKpi3Value.Font = New Font("Segoe UI", 25.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblKpi3Value.ForeColor = Color.FromArgb(CByte(22), CByte(51), CByte(65))
        lblKpi3Value.Location = New Point(14, 33)
        lblKpi3Value.Text = "100"
        lblKpi3Value.Name = "lblKpi3Value"
        lblKpi3Value.TabIndex = 13
        ' 
        ' lblKpi3Context
        ' 
        lblKpi3Context.AutoSize = True
        lblKpi3Context.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblKpi3Context.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblKpi3Context.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        lblKpi3Context.Location = New Point(16, 78)
        lblKpi3Context.Text = "46 repeat visits"
        lblKpi3Context.Name = "lblKpi3Context"
        lblKpi3Context.TabIndex = 14
        ' 
        ' cardVolume
        ' 
        cardVolume.Controls.Add(lblVolumeTitle)
        cardVolume.Controls.Add(cardBar1)
        cardVolume.Controls.Add(lblWeek1)
        cardVolume.Controls.Add(cardBar2)
        cardVolume.Controls.Add(lblWeek2)
        cardVolume.Controls.Add(cardBar3)
        cardVolume.Controls.Add(lblWeek3)
        cardVolume.Controls.Add(cardBar4)
        cardVolume.Controls.Add(lblWeek4)
        cardVolume.Controls.Add(cardBar5)
        cardVolume.Controls.Add(lblWeek5)
        cardVolume.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardVolume.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardVolume.BorderHoverColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardVolume.BorderRadius = 12
        cardVolume.BorderSize = 1
        cardVolume.EnableShadow = True
        cardVolume.HoverTintColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardVolume.Location = New Point(28, 203)
        cardVolume.ShadowDepth = 4
        cardVolume.Size = New Size(498, 194)
        cardVolume.Name = "cardVolume"
        cardVolume.TabIndex = 15
        ' 
        ' lblVolumeTitle
        ' 
        lblVolumeTitle.AutoSize = True
        lblVolumeTitle.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblVolumeTitle.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblVolumeTitle.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblVolumeTitle.Location = New Point(16, 13)
        lblVolumeTitle.Text = "Appointment volume"
        lblVolumeTitle.Name = "lblVolumeTitle"
        lblVolumeTitle.TabIndex = 16
        ' 
        ' cardBar1
        ' 
        cardBar1.BackColor = Color.FromArgb(CByte(234), CByte(241), CByte(246))
        cardBar1.BorderColor = Color.FromArgb(CByte(234), CByte(241), CByte(246))
        cardBar1.BorderHoverColor = Color.FromArgb(CByte(234), CByte(241), CByte(246))
        cardBar1.BorderRadius = 4
        cardBar1.BorderSize = 0
        cardBar1.EnableShadow = False
        cardBar1.HoverTintColor = Color.FromArgb(CByte(234), CByte(241), CByte(246))
        cardBar1.Location = New Point(16, 95)
        cardBar1.ShadowDepth = 2
        cardBar1.Size = New Size(84, 69)
        cardBar1.Name = "cardBar1"
        cardBar1.TabIndex = 17
        ' 
        ' lblWeek1
        ' 
        lblWeek1.AutoSize = False
        lblWeek1.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblWeek1.Font = New Font("Segoe UI", 7.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblWeek1.ForeColor = Color.FromArgb(CByte(140), CByte(155), CByte(165))
        lblWeek1.Location = New Point(16, 168)
        lblWeek1.Size = New Size(84, 14)
        lblWeek1.TextAlign = ContentAlignment.MiddleCenter
        lblWeek1.Text = "W1"
        lblWeek1.Name = "lblWeek1"
        lblWeek1.TabIndex = 18
        ' 
        ' cardBar2
        ' 
        cardBar2.BackColor = Color.FromArgb(CByte(234), CByte(241), CByte(246))
        cardBar2.BorderColor = Color.FromArgb(CByte(234), CByte(241), CByte(246))
        cardBar2.BorderHoverColor = Color.FromArgb(CByte(234), CByte(241), CByte(246))
        cardBar2.BorderRadius = 4
        cardBar2.BorderSize = 0
        cardBar2.EnableShadow = False
        cardBar2.HoverTintColor = Color.FromArgb(CByte(234), CByte(241), CByte(246))
        cardBar2.Location = New Point(112, 66)
        cardBar2.ShadowDepth = 2
        cardBar2.Size = New Size(84, 98)
        cardBar2.Name = "cardBar2"
        cardBar2.TabIndex = 19
        ' 
        ' lblWeek2
        ' 
        lblWeek2.AutoSize = False
        lblWeek2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblWeek2.Font = New Font("Segoe UI", 7.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblWeek2.ForeColor = Color.FromArgb(CByte(140), CByte(155), CByte(165))
        lblWeek2.Location = New Point(112, 168)
        lblWeek2.Size = New Size(84, 14)
        lblWeek2.TextAlign = ContentAlignment.MiddleCenter
        lblWeek2.Text = "W2"
        lblWeek2.Name = "lblWeek2"
        lblWeek2.TabIndex = 20
        ' 
        ' cardBar3
        ' 
        cardBar3.BackColor = Color.FromArgb(CByte(234), CByte(241), CByte(246))
        cardBar3.BorderColor = Color.FromArgb(CByte(234), CByte(241), CByte(246))
        cardBar3.BorderHoverColor = Color.FromArgb(CByte(234), CByte(241), CByte(246))
        cardBar3.BorderRadius = 4
        cardBar3.BorderSize = 0
        cardBar3.EnableShadow = False
        cardBar3.HoverTintColor = Color.FromArgb(CByte(234), CByte(241), CByte(246))
        cardBar3.Location = New Point(208, 84)
        cardBar3.ShadowDepth = 2
        cardBar3.Size = New Size(84, 80)
        cardBar3.Name = "cardBar3"
        cardBar3.TabIndex = 21
        ' 
        ' lblWeek3
        ' 
        lblWeek3.AutoSize = False
        lblWeek3.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblWeek3.Font = New Font("Segoe UI", 7.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblWeek3.ForeColor = Color.FromArgb(CByte(140), CByte(155), CByte(165))
        lblWeek3.Location = New Point(208, 168)
        lblWeek3.Size = New Size(84, 14)
        lblWeek3.TextAlign = ContentAlignment.MiddleCenter
        lblWeek3.Text = "W3"
        lblWeek3.Name = "lblWeek3"
        lblWeek3.TabIndex = 22
        ' 
        ' cardBar4
        ' 
        cardBar4.BackColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        cardBar4.BorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        cardBar4.BorderHoverColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        cardBar4.BorderRadius = 4
        cardBar4.BorderSize = 0
        cardBar4.EnableShadow = False
        cardBar4.HoverTintColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        cardBar4.Location = New Point(304, 47)
        cardBar4.ShadowDepth = 2
        cardBar4.Size = New Size(84, 117)
        cardBar4.Name = "cardBar4"
        cardBar4.TabIndex = 23
        ' 
        ' lblWeek4
        ' 
        lblWeek4.AutoSize = False
        lblWeek4.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblWeek4.Font = New Font("Segoe UI", 7.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblWeek4.ForeColor = Color.FromArgb(CByte(140), CByte(155), CByte(165))
        lblWeek4.Location = New Point(304, 168)
        lblWeek4.Size = New Size(84, 14)
        lblWeek4.TextAlign = ContentAlignment.MiddleCenter
        lblWeek4.Text = "W4"
        lblWeek4.Name = "lblWeek4"
        lblWeek4.TabIndex = 24
        ' 
        ' cardBar5
        ' 
        cardBar5.BackColor = Color.FromArgb(CByte(234), CByte(241), CByte(246))
        cardBar5.BorderColor = Color.FromArgb(CByte(234), CByte(241), CByte(246))
        cardBar5.BorderHoverColor = Color.FromArgb(CByte(234), CByte(241), CByte(246))
        cardBar5.BorderRadius = 4
        cardBar5.BorderSize = 0
        cardBar5.EnableShadow = False
        cardBar5.HoverTintColor = Color.FromArgb(CByte(234), CByte(241), CByte(246))
        cardBar5.Location = New Point(400, 61)
        cardBar5.ShadowDepth = 2
        cardBar5.Size = New Size(84, 103)
        cardBar5.Name = "cardBar5"
        cardBar5.TabIndex = 25
        ' 
        ' lblWeek5
        ' 
        lblWeek5.AutoSize = False
        lblWeek5.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblWeek5.Font = New Font("Segoe UI", 7.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblWeek5.ForeColor = Color.FromArgb(CByte(140), CByte(155), CByte(165))
        lblWeek5.Location = New Point(400, 168)
        lblWeek5.Size = New Size(84, 14)
        lblWeek5.TextAlign = ContentAlignment.MiddleCenter
        lblWeek5.Text = "W5"
        lblWeek5.Name = "lblWeek5"
        lblWeek5.TabIndex = 26
        ' 
        ' cardDiagnoses
        ' 
        cardDiagnoses.Controls.Add(lblDiagnosesTitle)
        cardDiagnoses.Controls.Add(lblDiag1Name)
        cardDiagnoses.Controls.Add(lblDiag1Value)
        cardDiagnoses.Controls.Add(lblDiag2Name)
        cardDiagnoses.Controls.Add(lblDiag2Value)
        cardDiagnoses.Controls.Add(lblDiag3Name)
        cardDiagnoses.Controls.Add(lblDiag3Value)
        cardDiagnoses.Controls.Add(lblDiag4Name)
        cardDiagnoses.Controls.Add(lblDiag4Value)
        cardDiagnoses.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardDiagnoses.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardDiagnoses.BorderHoverColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardDiagnoses.BorderRadius = 12
        cardDiagnoses.BorderSize = 1
        cardDiagnoses.EnableShadow = True
        cardDiagnoses.HoverTintColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardDiagnoses.Location = New Point(538, 203)
        cardDiagnoses.ShadowDepth = 4
        cardDiagnoses.Size = New Size(265, 138)
        cardDiagnoses.Name = "cardDiagnoses"
        cardDiagnoses.TabIndex = 27
        ' 
        ' lblDiagnosesTitle
        ' 
        lblDiagnosesTitle.AutoSize = True
        lblDiagnosesTitle.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblDiagnosesTitle.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDiagnosesTitle.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblDiagnosesTitle.Location = New Point(16, 13)
        lblDiagnosesTitle.Text = "Common diagnoses"
        lblDiagnosesTitle.Name = "lblDiagnosesTitle"
        lblDiagnosesTitle.TabIndex = 28
        ' 
        ' lblDiag1Name
        ' 
        lblDiag1Name.AutoSize = True
        lblDiag1Name.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblDiag1Name.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDiag1Name.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        lblDiag1Name.Location = New Point(16, 39)
        lblDiag1Name.Text = "Upper respiratory infection"
        lblDiag1Name.Name = "lblDiag1Name"
        lblDiag1Name.TabIndex = 29
        ' 
        ' lblDiag1Value
        ' 
        lblDiag1Value.AutoSize = False
        lblDiag1Value.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblDiag1Value.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDiag1Value.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        lblDiag1Value.Location = New Point(159, 39)
        lblDiag1Value.Size = New Size(90, 14)
        lblDiag1Value.TextAlign = ContentAlignment.MiddleRight
        lblDiag1Value.Text = "62 • 32%"
        lblDiag1Value.Name = "lblDiag1Value"
        lblDiag1Value.TabIndex = 30
        ' 
        ' lblDiag2Name
        ' 
        lblDiag2Name.AutoSize = True
        lblDiag2Name.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblDiag2Name.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDiag2Name.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        lblDiag2Name.Location = New Point(16, 63)
        lblDiag2Name.Text = "Hypertension follow-up"
        lblDiag2Name.Name = "lblDiag2Name"
        lblDiag2Name.TabIndex = 31
        ' 
        ' lblDiag2Value
        ' 
        lblDiag2Value.AutoSize = False
        lblDiag2Value.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblDiag2Value.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDiag2Value.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        lblDiag2Value.Location = New Point(159, 63)
        lblDiag2Value.Size = New Size(90, 14)
        lblDiag2Value.TextAlign = ContentAlignment.MiddleRight
        lblDiag2Value.Text = "41 • 21%"
        lblDiag2Value.Name = "lblDiag2Value"
        lblDiag2Value.TabIndex = 32
        ' 
        ' lblDiag3Name
        ' 
        lblDiag3Name.AutoSize = True
        lblDiag3Name.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblDiag3Name.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDiag3Name.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        lblDiag3Name.Location = New Point(16, 87)
        lblDiag3Name.Text = "Allergic rhinitis"
        lblDiag3Name.Name = "lblDiag3Name"
        lblDiag3Name.TabIndex = 33
        ' 
        ' lblDiag3Value
        ' 
        lblDiag3Value.AutoSize = False
        lblDiag3Value.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblDiag3Value.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDiag3Value.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        lblDiag3Value.Location = New Point(159, 87)
        lblDiag3Value.Size = New Size(90, 14)
        lblDiag3Value.TextAlign = ContentAlignment.MiddleRight
        lblDiag3Value.Text = "36 • 18%"
        lblDiag3Value.Name = "lblDiag3Value"
        lblDiag3Value.TabIndex = 34
        ' 
        ' lblDiag4Name
        ' 
        lblDiag4Name.AutoSize = True
        lblDiag4Name.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblDiag4Name.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDiag4Name.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        lblDiag4Name.Location = New Point(16, 111)
        lblDiag4Name.Text = "Gastroenteritis"
        lblDiag4Name.Name = "lblDiag4Name"
        lblDiag4Name.TabIndex = 35
        ' 
        ' lblDiag4Value
        ' 
        lblDiag4Value.AutoSize = False
        lblDiag4Value.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblDiag4Value.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDiag4Value.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        lblDiag4Value.Location = New Point(159, 111)
        lblDiag4Value.Size = New Size(90, 14)
        lblDiag4Value.TextAlign = ContentAlignment.MiddleRight
        lblDiag4Value.Text = "24 • 12%"
        lblDiag4Value.Name = "lblDiag4Value"
        lblDiag4Value.TabIndex = 36
        ' 
        ' cardHistory
        ' 
        cardHistory.Controls.Add(lblHistoryTitle)
        cardHistory.Controls.Add(lblCol1)
        cardHistory.Controls.Add(lblCol2)
        cardHistory.Controls.Add(lblCol3)
        cardHistory.Controls.Add(lblCol4)
        cardHistory.Controls.Add(divHeader)
        cardHistory.Controls.Add(lblRow1Col1)
        cardHistory.Controls.Add(lblRow1Col2)
        cardHistory.Controls.Add(lblRow1Col3)
        cardHistory.Controls.Add(lblRow1Col4)
        cardHistory.Controls.Add(divRow1)
        cardHistory.Controls.Add(lblRow2Col1)
        cardHistory.Controls.Add(lblRow2Col2)
        cardHistory.Controls.Add(lblRow2Col3)
        cardHistory.Controls.Add(lblRow2Col4)
        cardHistory.Controls.Add(divRow2)
        cardHistory.Controls.Add(lblRow3Col1)
        cardHistory.Controls.Add(lblRow3Col2)
        cardHistory.Controls.Add(lblRow3Col3)
        cardHistory.Controls.Add(lblRow3Col4)
        cardHistory.Controls.Add(divRow3)
        cardHistory.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardHistory.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardHistory.BorderHoverColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardHistory.BorderRadius = 12
        cardHistory.BorderSize = 1
        cardHistory.EnableShadow = True
        cardHistory.HoverTintColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardHistory.Location = New Point(28, 417)
        cardHistory.ShadowDepth = 4
        cardHistory.Size = New Size(775, 210)
        cardHistory.Name = "cardHistory"
        cardHistory.TabIndex = 37
        ' 
        ' lblHistoryTitle
        ' 
        lblHistoryTitle.AutoSize = True
        lblHistoryTitle.UseMnemonic = False
        lblHistoryTitle.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblHistoryTitle.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblHistoryTitle.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblHistoryTitle.Location = New Point(16, 13)
        lblHistoryTitle.Text = "Patient visit history"
        lblHistoryTitle.Name = "lblHistoryTitle"
        lblHistoryTitle.TabIndex = 38
        ' 
        ' lblCol1
        ' 
        lblCol1.AutoSize = True
        lblCol1.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblCol1.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCol1.ForeColor = Color.FromArgb(CByte(120), CByte(135), CByte(145))
        lblCol1.Location = New Point(16, 48)
        lblCol1.Text = "Patient"
        lblCol1.Name = "lblCol1"
        lblCol1.TabIndex = 39
        ' 
        ' lblCol2
        ' 
        lblCol2.AutoSize = True
        lblCol2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblCol2.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCol2.ForeColor = Color.FromArgb(CByte(120), CByte(135), CByte(145))
        lblCol2.Location = New Point(205, 48)
        lblCol2.Text = "Visits"
        lblCol2.Name = "lblCol2"
        lblCol2.TabIndex = 40
        ' 
        ' lblCol3
        ' 
        lblCol3.AutoSize = True
        lblCol3.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblCol3.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCol3.ForeColor = Color.FromArgb(CByte(120), CByte(135), CByte(145))
        lblCol3.Location = New Point(396, 48)
        lblCol3.Text = "Last visit"
        lblCol3.Name = "lblCol3"
        lblCol3.TabIndex = 41
        ' 
        ' lblCol4
        ' 
        lblCol4.AutoSize = True
        lblCol4.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblCol4.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCol4.ForeColor = Color.FromArgb(CByte(120), CByte(135), CByte(145))
        lblCol4.Location = New Point(588, 48)
        lblCol4.Text = "Most recent diagnosis"
        lblCol4.Name = "lblCol4"
        lblCol4.TabIndex = 42
        ' 
        ' divHeader
        ' 
        divHeader.BackColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        divHeader.Location = New Point(16, 72)
        divHeader.Size = New Size(743, 1)
        divHeader.Name = "divHeader"
        divHeader.TabIndex = 43
        ' 
        ' lblRow1Col1
        ' 
        lblRow1Col1.AutoSize = True
        lblRow1Col1.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow1Col1.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow1Col1.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblRow1Col1.Location = New Point(16, 89)
        lblRow1Col1.Text = "Maria Santos"
        lblRow1Col1.Name = "lblRow1Col1"
        lblRow1Col1.TabIndex = 44
        ' 
        ' lblRow1Col2
        ' 
        lblRow1Col2.AutoSize = True
        lblRow1Col2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow1Col2.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow1Col2.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow1Col2.Location = New Point(205, 89)
        lblRow1Col2.Text = "3"
        lblRow1Col2.Name = "lblRow1Col2"
        lblRow1Col2.TabIndex = 45
        ' 
        ' lblRow1Col3
        ' 
        lblRow1Col3.AutoSize = True
        lblRow1Col3.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow1Col3.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow1Col3.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow1Col3.Location = New Point(396, 89)
        lblRow1Col3.Text = "Sep 22"
        lblRow1Col3.Name = "lblRow1Col3"
        lblRow1Col3.TabIndex = 46
        ' 
        ' lblRow1Col4
        ' 
        lblRow1Col4.AutoSize = True
        lblRow1Col4.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow1Col4.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow1Col4.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        lblRow1Col4.Location = New Point(588, 89)
        lblRow1Col4.Text = "Asthma follow-up"
        lblRow1Col4.Name = "lblRow1Col4"
        lblRow1Col4.TabIndex = 47
        ' 
        ' divRow1
        ' 
        divRow1.BackColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        divRow1.Location = New Point(16, 114)
        divRow1.Size = New Size(743, 1)
        divRow1.Name = "divRow1"
        divRow1.TabIndex = 48
        ' 
        ' lblRow2Col1
        ' 
        lblRow2Col1.AutoSize = True
        lblRow2Col1.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow2Col1.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow2Col1.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblRow2Col1.Location = New Point(16, 131)
        lblRow2Col1.Text = "Joshua Reyes"
        lblRow2Col1.Name = "lblRow2Col1"
        lblRow2Col1.TabIndex = 49
        ' 
        ' lblRow2Col2
        ' 
        lblRow2Col2.AutoSize = True
        lblRow2Col2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow2Col2.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow2Col2.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow2Col2.Location = New Point(205, 131)
        lblRow2Col2.Text = "2"
        lblRow2Col2.Name = "lblRow2Col2"
        lblRow2Col2.TabIndex = 50
        ' 
        ' lblRow2Col3
        ' 
        lblRow2Col3.AutoSize = True
        lblRow2Col3.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow2Col3.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow2Col3.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow2Col3.Location = New Point(396, 131)
        lblRow2Col3.Text = "Sep 22"
        lblRow2Col3.Name = "lblRow2Col3"
        lblRow2Col3.TabIndex = 51
        ' 
        ' lblRow2Col4
        ' 
        lblRow2Col4.AutoSize = True
        lblRow2Col4.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow2Col4.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow2Col4.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        lblRow2Col4.Location = New Point(588, 131)
        lblRow2Col4.Text = "Upper respiratory infection"
        lblRow2Col4.Name = "lblRow2Col4"
        lblRow2Col4.TabIndex = 52
        ' 
        ' divRow2
        ' 
        divRow2.BackColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        divRow2.Location = New Point(16, 156)
        divRow2.Size = New Size(743, 1)
        divRow2.Name = "divRow2"
        divRow2.TabIndex = 53
        ' 
        ' lblRow3Col1
        ' 
        lblRow3Col1.AutoSize = True
        lblRow3Col1.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow3Col1.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow3Col1.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblRow3Col1.Location = New Point(16, 173)
        lblRow3Col1.Text = "Ana Villanueva"
        lblRow3Col1.Name = "lblRow3Col1"
        lblRow3Col1.TabIndex = 54
        ' 
        ' lblRow3Col2
        ' 
        lblRow3Col2.AutoSize = True
        lblRow3Col2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow3Col2.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow3Col2.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow3Col2.Location = New Point(205, 173)
        lblRow3Col2.Text = "4"
        lblRow3Col2.Name = "lblRow3Col2"
        lblRow3Col2.TabIndex = 55
        ' 
        ' lblRow3Col3
        ' 
        lblRow3Col3.AutoSize = True
        lblRow3Col3.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow3Col3.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow3Col3.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow3Col3.Location = New Point(396, 173)
        lblRow3Col3.Text = "Aug 30"
        lblRow3Col3.Name = "lblRow3Col3"
        lblRow3Col3.TabIndex = 56
        ' 
        ' lblRow3Col4
        ' 
        lblRow3Col4.AutoSize = True
        lblRow3Col4.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow3Col4.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow3Col4.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        lblRow3Col4.Location = New Point(588, 173)
        lblRow3Col4.Text = "Hypertension follow-up"
        lblRow3Col4.Name = "lblRow3Col4"
        lblRow3Col4.TabIndex = 57
        ' 
        ' divRow3
        ' 
        divRow3.BackColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        divRow3.Location = New Point(16, 198)
        divRow3.Size = New Size(743, 1)
        divRow3.Name = "divRow3"
        divRow3.TabIndex = 58
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
        ' mainScreen
        ' 
        mainScreen.BackColor = Color.FromArgb(CByte(244), CByte(247), CByte(249))
        mainScreen.Controls.Add(lblTitle)
        mainScreen.Controls.Add(lblSubtitle)
        mainScreen.Controls.Add(btnExport)
        mainScreen.Controls.Add(cardKpi1)
        mainScreen.Controls.Add(cardKpi2)
        mainScreen.Controls.Add(cardKpi3)
        mainScreen.Controls.Add(cardVolume)
        mainScreen.Controls.Add(cardDiagnoses)
        mainScreen.Controls.Add(cardHistory)
        mainScreen.Location = New Point(176, 0)
        mainScreen.Name = "mainScreen"
        mainScreen.Size = New Size(832, 730)
        mainScreen.TabIndex = 1
        ' 
        ' Reports
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1008, 729)
        Controls.Add(mainScreen)
        Controls.Add(sideBar)
        Name = "DoctorReports"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Clinic Management - Doctor Reports"
        cardHistory.ResumeLayout(False)
        cardHistory.PerformLayout()
        cardDiagnoses.ResumeLayout(False)
        cardDiagnoses.PerformLayout()
        cardVolume.ResumeLayout(False)
        cardVolume.PerformLayout()
        cardKpi3.ResumeLayout(False)
        cardKpi3.PerformLayout()
        cardKpi2.ResumeLayout(False)
        cardKpi2.PerformLayout()
        cardKpi1.ResumeLayout(False)
        cardKpi1.PerformLayout()
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
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents btnExport As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents cardKpi1 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblKpi1Title As Label
    Friend WithEvents lblKpi1Value As Label
    Friend WithEvents lblKpi1Context As Label
    Friend WithEvents cardKpi2 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblKpi2Title As Label
    Friend WithEvents lblKpi2Value As Label
    Friend WithEvents lblKpi2Context As Label
    Friend WithEvents cardKpi3 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblKpi3Title As Label
    Friend WithEvents lblKpi3Value As Label
    Friend WithEvents lblKpi3Context As Label
    Friend WithEvents cardVolume As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblVolumeTitle As Label
    Friend WithEvents cardBar1 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblWeek1 As Label
    Friend WithEvents cardBar2 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblWeek2 As Label
    Friend WithEvents cardBar3 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblWeek3 As Label
    Friend WithEvents cardBar4 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblWeek4 As Label
    Friend WithEvents cardBar5 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblWeek5 As Label
    Friend WithEvents cardDiagnoses As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblDiagnosesTitle As Label
    Friend WithEvents lblDiag1Name As Label
    Friend WithEvents lblDiag1Value As Label
    Friend WithEvents lblDiag2Name As Label
    Friend WithEvents lblDiag2Value As Label
    Friend WithEvents lblDiag3Name As Label
    Friend WithEvents lblDiag3Value As Label
    Friend WithEvents lblDiag4Name As Label
    Friend WithEvents lblDiag4Value As Label
    Friend WithEvents cardHistory As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblHistoryTitle As Label
    Friend WithEvents lblCol1 As Label
    Friend WithEvents lblCol2 As Label
    Friend WithEvents lblCol3 As Label
    Friend WithEvents lblCol4 As Label
    Friend WithEvents divHeader As Panel
    Friend WithEvents lblRow1Col1 As Label
    Friend WithEvents lblRow1Col2 As Label
    Friend WithEvents lblRow1Col3 As Label
    Friend WithEvents lblRow1Col4 As Label
    Friend WithEvents divRow1 As Panel
    Friend WithEvents lblRow2Col1 As Label
    Friend WithEvents lblRow2Col2 As Label
    Friend WithEvents lblRow2Col3 As Label
    Friend WithEvents lblRow2Col4 As Label
    Friend WithEvents divRow2 As Panel
    Friend WithEvents lblRow3Col1 As Label
    Friend WithEvents lblRow3Col2 As Label
    Friend WithEvents lblRow3Col3 As Label
    Friend WithEvents lblRow3Col4 As Label
    Friend WithEvents divRow3 As Panel

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

End Class
