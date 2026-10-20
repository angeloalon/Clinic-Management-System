Imports FontAwesome.Sharp
Imports Ferrando.UI.WinForms.Controles

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DoctorPatientInformation
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
        sideBar = New Panel()
        namePlaceHolder = New FCard()
        txtRole = New Label()
        txtName = New Label()
        FCard1 = New FCard()
        Label3 = New Label()
        btnReports = New FButton()
        btnConsultation = New FButton()
        Label2 = New Label()
        btnDoctor = New FButton()
        Label1 = New Label()
        btnAppointment = New FButton()
        btnPatients = New FButton()
        btnDashboard = New FButton()
        mainScreen = New Panel()
        btnBackToPatients = New FButton()
        cardUpcoming = New FCard()
        btnUpcomingBadge = New FButton()
        lblUpcomingDetails = New Label()
        lblUpcomingDate = New Label()
        lblUpcomingTitle = New Label()
        cardVisitTimeline = New FCard()
        btnV3Badge = New FButton()
        lblV3Doc = New Label()
        lblV3Diag = New Label()
        lblV3Type = New Label()
        lblV3Date = New Label()
        divV2 = New Panel()
        btnV2Badge = New FButton()
        lblV2Doc = New Label()
        lblV2Diag = New Label()
        lblV2Type = New Label()
        lblV2Date = New Label()
        divV1 = New Panel()
        btnV1Badge = New FButton()
        lblV1Doc = New Label()
        lblV1Diag = New Label()
        lblV1Type = New Label()
        lblV1Date = New Label()
        lblVisitTimelineTitle = New Label()
        cardMedicalHistory = New FCard()
        lblAllergiesValue = New Label()
        lblAllergiesHeader = New Label()
        lblConditionsValue = New Label()
        lblConditionsHeader = New Label()
        lblMedHistoryTitle = New Label()
        cardDemographics = New FCard()
        lblAddress = New Label()
        lblEmail = New Label()
        lblPhone = New Label()
        lblBirthDate = New Label()
        lblAgeSex = New Label()
        lblDemoTitle = New Label()
        lblPatientSubtitle = New Label()
        lblPatientName = New Label()
        sideBar.SuspendLayout()
        namePlaceHolder.SuspendLayout()
        FCard1.SuspendLayout()
        mainScreen.SuspendLayout()
        cardUpcoming.SuspendLayout()
        cardVisitTimeline.SuspendLayout()
        cardMedicalHistory.SuspendLayout()
        cardDemographics.SuspendLayout()
        SuspendLayout()
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
        btnReports.MouseLeaveBackColor = Color.DodgerBlue
        btnReports.MouseLeaveBorderColor = Color.Black
        btnReports.MouseLeaveBorderSize = 0
        btnReports.MouseLeaveFont = New Font("Century Gothic", 11.0F)
        btnReports.MouseLeaveForeColor = Color.White
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
        btnPatients.BackColor = Color.FromArgb(CByte(39), CByte(73), CByte(87))
        btnPatients.BorderColor = Color.Black
        btnPatients.BorderRadius = 10
        btnPatients.BorderSize = 0
        btnPatients.FlatAppearance.BorderSize = 0
        btnPatients.FlatStyle = FlatStyle.Flat
        btnPatients.Font = New Font("Noto Sans Georgian Bold", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnPatients.ForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnPatients.Location = New Point(3, 161)
        btnPatients.MouseEnterBackColor = Color.FromArgb(CByte(39), CByte(73), CByte(87))
        btnPatients.MouseEnterBorderColor = Color.FromArgb(CByte(39), CByte(73), CByte(87))
        btnPatients.MouseEnterBorderSize = 0
        btnPatients.MouseEnterFont = New Font("Noto Sans Georgian Bold", 11.9999981F)
        btnPatients.MouseEnterForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnPatients.MouseLeaveBackColor = Color.FromArgb(CByte(39), CByte(73), CByte(87))
        btnPatients.MouseLeaveBorderColor = Color.Black
        btnPatients.MouseLeaveBorderSize = 0
        btnPatients.MouseLeaveFont = New Font("Noto Sans Georgian Bold", 11.9999981F)
        btnPatients.MouseLeaveForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
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
        mainScreen.Controls.Add(btnBackToPatients)
        mainScreen.Controls.Add(cardUpcoming)
        mainScreen.Controls.Add(cardVisitTimeline)
        mainScreen.Controls.Add(cardMedicalHistory)
        mainScreen.Controls.Add(cardDemographics)
        mainScreen.Controls.Add(lblPatientSubtitle)
        mainScreen.Controls.Add(lblPatientName)
        mainScreen.Location = New Point(176, 0)
        mainScreen.Name = "mainScreen"
        mainScreen.Size = New Size(832, 730)
        mainScreen.TabIndex = 1
        ' 
        ' btnBackToPatients
        ' 
        btnBackToPatients.BackColor = Color.White
        btnBackToPatients.BorderColor = Color.FromArgb(CByte(220), CByte(230), CByte(235))
        btnBackToPatients.BorderRadius = 6
        btnBackToPatients.BorderSize = 1
        btnBackToPatients.FlatAppearance.BorderSize = 0
        btnBackToPatients.FlatStyle = FlatStyle.Flat
        btnBackToPatients.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnBackToPatients.ForeColor = Color.FromArgb(CByte(80), CByte(100), CByte(115))
        btnBackToPatients.Location = New Point(680, 24)
        btnBackToPatients.MouseEnterBackColor = Color.FromArgb(CByte(245), CByte(249), CByte(251))
        btnBackToPatients.MouseEnterBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnBackToPatients.MouseEnterBorderSize = 1
        btnBackToPatients.MouseEnterFont = New Font("Segoe UI", 8.25F, FontStyle.Regular)
        btnBackToPatients.MouseEnterForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnBackToPatients.MouseLeaveBackColor = Color.White
        btnBackToPatients.MouseLeaveBorderColor = Color.FromArgb(CByte(220), CByte(230), CByte(235))
        btnBackToPatients.MouseLeaveBorderSize = 1
        btnBackToPatients.MouseLeaveFont = New Font("Segoe UI", 8.25F, FontStyle.Regular)
        btnBackToPatients.MouseLeaveForeColor = Color.FromArgb(CByte(80), CByte(100), CByte(115))
        btnBackToPatients.Name = "btnBackToPatients"
        btnBackToPatients.Size = New Size(118, 28)
        btnBackToPatients.TabIndex = 6
        btnBackToPatients.Text = "← Back to Patients"
        btnBackToPatients.UseVisualStyleBackColor = False
        ' 
        ' cardUpcoming
        ' 
        cardUpcoming.BackColor = Color.White
        cardUpcoming.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardUpcoming.BorderHoverColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        cardUpcoming.BorderRadius = 12
        cardUpcoming.BorderSize = 1
        cardUpcoming.Controls.Add(btnUpcomingBadge)
        cardUpcoming.Controls.Add(lblUpcomingDetails)
        cardUpcoming.Controls.Add(lblUpcomingDate)
        cardUpcoming.Controls.Add(lblUpcomingTitle)
        cardUpcoming.EnableShadow = True
        cardUpcoming.HoverTintColor = Color.White
        cardUpcoming.Location = New Point(576, 274)
        cardUpcoming.Name = "cardUpcoming"
        cardUpcoming.Padding = New Padding(16, 14, 16, 14)
        cardUpcoming.ShadowDepth = 4
        cardUpcoming.Size = New Size(222, 126)
        cardUpcoming.TabIndex = 5
        ' 
        ' btnUpcomingBadge
        ' 
        btnUpcomingBadge.BackColor = Color.FromArgb(CByte(232), CByte(246), CByte(235))
        btnUpcomingBadge.BorderColor = Color.FromArgb(CByte(232), CByte(246), CByte(235))
        btnUpcomingBadge.BorderRadius = 10
        btnUpcomingBadge.BorderSize = 0
        btnUpcomingBadge.FlatAppearance.BorderSize = 0
        btnUpcomingBadge.FlatStyle = FlatStyle.Flat
        btnUpcomingBadge.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnUpcomingBadge.ForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        btnUpcomingBadge.Location = New Point(16, 88)
        btnUpcomingBadge.MouseEnterBackColor = Color.FromArgb(CByte(232), CByte(246), CByte(235))
        btnUpcomingBadge.MouseEnterBorderColor = Color.FromArgb(CByte(232), CByte(246), CByte(235))
        btnUpcomingBadge.MouseEnterBorderSize = 0
        btnUpcomingBadge.MouseEnterFont = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        btnUpcomingBadge.MouseEnterForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        btnUpcomingBadge.MouseLeaveBackColor = Color.FromArgb(CByte(232), CByte(246), CByte(235))
        btnUpcomingBadge.MouseLeaveBorderColor = Color.FromArgb(CByte(232), CByte(246), CByte(235))
        btnUpcomingBadge.MouseLeaveBorderSize = 0
        btnUpcomingBadge.MouseLeaveFont = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        btnUpcomingBadge.MouseLeaveForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        btnUpcomingBadge.Name = "btnUpcomingBadge"
        btnUpcomingBadge.Size = New Size(72, 22)
        btnUpcomingBadge.TabIndex = 3
        btnUpcomingBadge.Text = "Confirmed"
        btnUpcomingBadge.UseVisualStyleBackColor = False
        ' 
        ' lblUpcomingDetails
        ' 
        lblUpcomingDetails.AutoSize = True
        lblUpcomingDetails.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblUpcomingDetails.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblUpcomingDetails.Location = New Point(16, 64)
        lblUpcomingDetails.Name = "lblUpcomingDetails"
        lblUpcomingDetails.Size = New Size(140, 15)
        lblUpcomingDetails.TabIndex = 2
        lblUpcomingDetails.Text = "Dr. Elena Cruz • Follow-up"
        ' 
        ' lblUpcomingDate
        ' 
        lblUpcomingDate.AutoSize = True
        lblUpcomingDate.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblUpcomingDate.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblUpcomingDate.Location = New Point(16, 42)
        lblUpcomingDate.Name = "lblUpcomingDate"
        lblUpcomingDate.Size = New Size(108, 19)
        lblUpcomingDate.TabIndex = 1
        lblUpcomingDate.Text = "Oct 20 • 9:00 AM"
        ' 
        ' lblUpcomingTitle
        ' 
        lblUpcomingTitle.AutoSize = True
        lblUpcomingTitle.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblUpcomingTitle.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblUpcomingTitle.Location = New Point(16, 14)
        lblUpcomingTitle.Name = "lblUpcomingTitle"
        lblUpcomingTitle.Size = New Size(167, 19)
        lblUpcomingTitle.TabIndex = 0
        lblUpcomingTitle.Text = "Upcoming appointments"
        ' 
        ' cardVisitTimeline
        ' 
        cardVisitTimeline.BackColor = Color.White
        cardVisitTimeline.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardVisitTimeline.BorderHoverColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        cardVisitTimeline.BorderRadius = 12
        cardVisitTimeline.BorderSize = 1
        cardVisitTimeline.Controls.Add(btnV3Badge)
        cardVisitTimeline.Controls.Add(lblV3Doc)
        cardVisitTimeline.Controls.Add(lblV3Diag)
        cardVisitTimeline.Controls.Add(lblV3Type)
        cardVisitTimeline.Controls.Add(lblV3Date)
        cardVisitTimeline.Controls.Add(divV2)
        cardVisitTimeline.Controls.Add(btnV2Badge)
        cardVisitTimeline.Controls.Add(lblV2Doc)
        cardVisitTimeline.Controls.Add(lblV2Diag)
        cardVisitTimeline.Controls.Add(lblV2Type)
        cardVisitTimeline.Controls.Add(lblV2Date)
        cardVisitTimeline.Controls.Add(divV1)
        cardVisitTimeline.Controls.Add(btnV1Badge)
        cardVisitTimeline.Controls.Add(lblV1Doc)
        cardVisitTimeline.Controls.Add(lblV1Diag)
        cardVisitTimeline.Controls.Add(lblV1Type)
        cardVisitTimeline.Controls.Add(lblV1Date)
        cardVisitTimeline.Controls.Add(lblVisitTimelineTitle)
        cardVisitTimeline.EnableShadow = True
        cardVisitTimeline.HoverTintColor = Color.White
        cardVisitTimeline.Location = New Point(28, 274)
        cardVisitTimeline.Name = "cardVisitTimeline"
        cardVisitTimeline.Padding = New Padding(16)
        cardVisitTimeline.ShadowDepth = 4
        cardVisitTimeline.Size = New Size(530, 206)
        cardVisitTimeline.TabIndex = 4
        ' 
        ' btnV3Badge
        ' 
        btnV3Badge.BackColor = Color.FromArgb(CByte(232), CByte(246), CByte(235))
        btnV3Badge.BorderColor = Color.FromArgb(CByte(232), CByte(246), CByte(235))
        btnV3Badge.BorderRadius = 10
        btnV3Badge.BorderSize = 0
        btnV3Badge.FlatAppearance.BorderSize = 0
        btnV3Badge.FlatStyle = FlatStyle.Flat
        btnV3Badge.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnV3Badge.ForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        btnV3Badge.Location = New Point(440, 158)
        btnV3Badge.MouseEnterBackColor = Color.FromArgb(CByte(232), CByte(246), CByte(235))
        btnV3Badge.MouseEnterBorderColor = Color.FromArgb(CByte(232), CByte(246), CByte(235))
        btnV3Badge.MouseEnterBorderSize = 0
        btnV3Badge.MouseEnterFont = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        btnV3Badge.MouseEnterForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        btnV3Badge.MouseLeaveBackColor = Color.FromArgb(CByte(232), CByte(246), CByte(235))
        btnV3Badge.MouseLeaveBorderColor = Color.FromArgb(CByte(232), CByte(246), CByte(235))
        btnV3Badge.MouseLeaveBorderSize = 0
        btnV3Badge.MouseLeaveFont = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        btnV3Badge.MouseLeaveForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        btnV3Badge.Name = "btnV3Badge"
        btnV3Badge.Size = New Size(72, 22)
        btnV3Badge.TabIndex = 17
        btnV3Badge.Text = "Completed"
        btnV3Badge.UseVisualStyleBackColor = False
        ' 
        ' lblV3Doc
        ' 
        lblV3Doc.AutoSize = True
        lblV3Doc.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblV3Doc.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblV3Doc.Location = New Point(340, 162)
        lblV3Doc.Name = "lblV3Doc"
        lblV3Doc.Size = New Size(74, 15)
        lblV3Doc.TabIndex = 16
        lblV3Doc.Text = "Dr. Marco Lim"
        ' 
        ' lblV3Diag
        ' 
        lblV3Diag.AutoSize = True
        lblV3Diag.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblV3Diag.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblV3Diag.Location = New Point(210, 162)
        lblV3Diag.Name = "lblV3Diag"
        lblV3Diag.Size = New Size(113, 15)
        lblV3Diag.TabIndex = 15
        lblV3Diag.Text = "Routine assessment"
        ' 
        ' lblV3Type
        ' 
        lblV3Type.AutoSize = True
        lblV3Type.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblV3Type.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblV3Type.Location = New Point(115, 162)
        lblV3Type.Name = "lblV3Type"
        lblV3Type.Size = New Size(57, 15)
        lblV3Type.TabIndex = 14
        lblV3Type.Text = "Check-up"
        ' 
        ' lblV3Date
        ' 
        lblV3Date.AutoSize = True
        lblV3Date.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblV3Date.ForeColor = Color.FromArgb(CByte(35), CByte(50), CByte(60))
        lblV3Date.Location = New Point(16, 162)
        lblV3Date.Name = "lblV3Date"
        lblV3Date.Size = New Size(73, 15)
        lblV3Date.TabIndex = 13
        lblV3Date.Text = "Jan 08, 2026"
        ' 
        ' divV2
        ' 
        divV2.BackColor = Color.FromArgb(CByte(242), CByte(244), CByte(247))
        divV2.Location = New Point(16, 146)
        divV2.Name = "divV2"
        divV2.Size = New Size(498, 1)
        divV2.TabIndex = 12
        ' 
        ' btnV2Badge
        ' 
        btnV2Badge.BackColor = Color.FromArgb(CByte(232), CByte(246), CByte(235))
        btnV2Badge.BorderColor = Color.FromArgb(CByte(232), CByte(246), CByte(235))
        btnV2Badge.BorderRadius = 10
        btnV2Badge.BorderSize = 0
        btnV2Badge.FlatAppearance.BorderSize = 0
        btnV2Badge.FlatStyle = FlatStyle.Flat
        btnV2Badge.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnV2Badge.ForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        btnV2Badge.Location = New Point(440, 108)
        btnV2Badge.MouseEnterBackColor = Color.FromArgb(CByte(232), CByte(246), CByte(235))
        btnV2Badge.MouseEnterBorderColor = Color.FromArgb(CByte(232), CByte(246), CByte(235))
        btnV2Badge.MouseEnterBorderSize = 0
        btnV2Badge.MouseEnterFont = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        btnV2Badge.MouseEnterForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        btnV2Badge.MouseLeaveBackColor = Color.FromArgb(CByte(232), CByte(246), CByte(235))
        btnV2Badge.MouseLeaveBorderColor = Color.FromArgb(CByte(232), CByte(246), CByte(235))
        btnV2Badge.MouseLeaveBorderSize = 0
        btnV2Badge.MouseLeaveFont = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        btnV2Badge.MouseLeaveForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        btnV2Badge.Name = "btnV2Badge"
        btnV2Badge.Size = New Size(72, 22)
        btnV2Badge.TabIndex = 11
        btnV2Badge.Text = "Completed"
        btnV2Badge.UseVisualStyleBackColor = False
        ' 
        ' lblV2Doc
        ' 
        lblV2Doc.AutoSize = True
        lblV2Doc.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblV2Doc.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblV2Doc.Location = New Point(340, 112)
        lblV2Doc.Name = "lblV2Doc"
        lblV2Doc.Size = New Size(78, 15)
        lblV2Doc.TabIndex = 10
        lblV2Doc.Text = "Dr. Elena Cruz"
        ' 
        ' lblV2Diag
        ' 
        lblV2Diag.AutoSize = True
        lblV2Diag.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblV2Diag.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblV2Diag.Location = New Point(210, 112)
        lblV2Diag.Name = "lblV2Diag"
        lblV2Diag.Size = New Size(86, 15)
        lblV2Diag.TabIndex = 9
        lblV2Diag.Text = "Allergic rhinitis"
        ' 
        ' lblV2Type
        ' 
        lblV2Type.AutoSize = True
        lblV2Type.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblV2Type.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblV2Type.Location = New Point(115, 112)
        lblV2Type.Name = "lblV2Type"
        lblV2Type.Size = New Size(74, 15)
        lblV2Type.TabIndex = 8
        lblV2Type.Text = "Consultation"
        ' 
        ' lblV2Date
        ' 
        lblV2Date.AutoSize = True
        lblV2Date.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblV2Date.ForeColor = Color.FromArgb(CByte(35), CByte(50), CByte(60))
        lblV2Date.Location = New Point(16, 112)
        lblV2Date.Name = "lblV2Date"
        lblV2Date.Size = New Size(75, 15)
        lblV2Date.TabIndex = 7
        lblV2Date.Text = "Jun 16, 2026"
        ' 
        ' divV1
        ' 
        divV1.BackColor = Color.FromArgb(CByte(242), CByte(244), CByte(247))
        divV1.Location = New Point(16, 96)
        divV1.Name = "divV1"
        divV1.Size = New Size(498, 1)
        divV1.TabIndex = 6
        ' 
        ' btnV1Badge
        ' 
        btnV1Badge.BackColor = Color.FromArgb(CByte(232), CByte(246), CByte(235))
        btnV1Badge.BorderColor = Color.FromArgb(CByte(232), CByte(246), CByte(235))
        btnV1Badge.BorderRadius = 10
        btnV1Badge.BorderSize = 0
        btnV1Badge.FlatAppearance.BorderSize = 0
        btnV1Badge.FlatStyle = FlatStyle.Flat
        btnV1Badge.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnV1Badge.ForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        btnV1Badge.Location = New Point(440, 58)
        btnV1Badge.MouseEnterBackColor = Color.FromArgb(CByte(232), CByte(246), CByte(235))
        btnV1Badge.MouseEnterBorderColor = Color.FromArgb(CByte(232), CByte(246), CByte(235))
        btnV1Badge.MouseEnterBorderSize = 0
        btnV1Badge.MouseEnterFont = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        btnV1Badge.MouseEnterForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        btnV1Badge.MouseLeaveBackColor = Color.FromArgb(CByte(232), CByte(246), CByte(235))
        btnV1Badge.MouseLeaveBorderColor = Color.FromArgb(CByte(232), CByte(246), CByte(235))
        btnV1Badge.MouseLeaveBorderSize = 0
        btnV1Badge.MouseLeaveFont = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        btnV1Badge.MouseLeaveForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        btnV1Badge.Name = "btnV1Badge"
        btnV1Badge.Size = New Size(72, 22)
        btnV1Badge.TabIndex = 5
        btnV1Badge.Text = "Completed"
        btnV1Badge.UseVisualStyleBackColor = False
        ' 
        ' lblV1Doc
        ' 
        lblV1Doc.AutoSize = True
        lblV1Doc.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblV1Doc.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblV1Doc.Location = New Point(340, 62)
        lblV1Doc.Name = "lblV1Doc"
        lblV1Doc.Size = New Size(78, 15)
        lblV1Doc.TabIndex = 4
        lblV1Doc.Text = "Dr. Elena Cruz"
        ' 
        ' lblV1Diag
        ' 
        lblV1Diag.AutoSize = True
        lblV1Diag.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblV1Diag.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblV1Diag.Location = New Point(210, 62)
        lblV1Diag.Name = "lblV1Diag"
        lblV1Diag.Size = New Size(105, 15)
        lblV1Diag.TabIndex = 3
        lblV1Diag.Text = "Asthma controlled"
        ' 
        ' lblV1Type
        ' 
        lblV1Type.AutoSize = True
        lblV1Type.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblV1Type.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblV1Type.Location = New Point(115, 62)
        lblV1Type.Name = "lblV1Type"
        lblV1Type.Size = New Size(59, 15)
        lblV1Type.TabIndex = 2
        lblV1Type.Text = "Follow-up"
        ' 
        ' lblV1Date
        ' 
        lblV1Date.AutoSize = True
        lblV1Date.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblV1Date.ForeColor = Color.FromArgb(CByte(35), CByte(50), CByte(60))
        lblV1Date.Location = New Point(16, 62)
        lblV1Date.Name = "lblV1Date"
        lblV1Date.Size = New Size(75, 15)
        lblV1Date.TabIndex = 1
        lblV1Date.Text = "Sep 22, 2026"
        ' 
        ' lblVisitTimelineTitle
        ' 
        lblVisitTimelineTitle.AutoSize = True
        lblVisitTimelineTitle.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblVisitTimelineTitle.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblVisitTimelineTitle.Location = New Point(16, 14)
        lblVisitTimelineTitle.Name = "lblVisitTimelineTitle"
        lblVisitTimelineTitle.Size = New Size(99, 19)
        lblVisitTimelineTitle.TabIndex = 0
        lblVisitTimelineTitle.Text = "Visit timeline"
        ' 
        ' cardMedicalHistory
        ' 
        cardMedicalHistory.BackColor = Color.White
        cardMedicalHistory.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardMedicalHistory.BorderHoverColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        cardMedicalHistory.BorderRadius = 12
        cardMedicalHistory.BorderSize = 1
        cardMedicalHistory.Controls.Add(lblAllergiesValue)
        cardMedicalHistory.Controls.Add(lblAllergiesHeader)
        cardMedicalHistory.Controls.Add(lblConditionsValue)
        cardMedicalHistory.Controls.Add(lblConditionsHeader)
        cardMedicalHistory.Controls.Add(lblMedHistoryTitle)
        cardMedicalHistory.EnableShadow = True
        cardMedicalHistory.HoverTintColor = Color.White
        cardMedicalHistory.Location = New Point(356, 86)
        cardMedicalHistory.Name = "cardMedicalHistory"
        cardMedicalHistory.Padding = New Padding(16, 14, 16, 14)
        cardMedicalHistory.ShadowDepth = 4
        cardMedicalHistory.Size = New Size(442, 102)
        cardMedicalHistory.TabIndex = 3
        ' 
        ' lblAllergiesValue
        ' 
        lblAllergiesValue.AutoSize = True
        lblAllergiesValue.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblAllergiesValue.ForeColor = Color.FromArgb(CByte(205), CByte(75), CByte(75))
        lblAllergiesValue.Location = New Point(265, 64)
        lblAllergiesValue.Name = "lblAllergiesValue"
        lblAllergiesValue.Size = New Size(54, 15)
        lblAllergiesValue.TabIndex = 4
        lblAllergiesValue.Text = "Penicillin"
        ' 
        ' lblAllergiesHeader
        ' 
        lblAllergiesHeader.AutoSize = True
        lblAllergiesHeader.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblAllergiesHeader.ForeColor = Color.FromArgb(CByte(140), CByte(155), CByte(165))
        lblAllergiesHeader.Location = New Point(265, 44)
        lblAllergiesHeader.Name = "lblAllergiesHeader"
        lblAllergiesHeader.Size = New Size(89, 12)
        lblAllergiesHeader.TabIndex = 3
        lblAllergiesHeader.Text = "DRUG ALLERGIES"
        ' 
        ' lblConditionsValue
        ' 
        lblConditionsValue.AutoSize = True
        lblConditionsValue.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblConditionsValue.ForeColor = Color.FromArgb(CByte(35), CByte(50), CByte(60))
        lblConditionsValue.Location = New Point(16, 64)
        lblConditionsValue.Name = "lblConditionsValue"
        lblConditionsValue.Size = New Size(183, 15)
        lblConditionsValue.TabIndex = 2
        lblConditionsValue.Text = "Mild asthma • Seasonal allergies"
        ' 
        ' lblConditionsHeader
        ' 
        lblConditionsHeader.AutoSize = True
        lblConditionsHeader.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblConditionsHeader.ForeColor = Color.FromArgb(CByte(140), CByte(155), CByte(165))
        lblConditionsHeader.Location = New Point(16, 44)
        lblConditionsHeader.Name = "lblConditionsHeader"
        lblConditionsHeader.Size = New Size(111, 12)
        lblConditionsHeader.TabIndex = 1
        lblConditionsHeader.Text = "KNOWN CONDITIONS"
        ' 
        ' lblMedHistoryTitle
        ' 
        lblMedHistoryTitle.AutoSize = True
        lblMedHistoryTitle.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblMedHistoryTitle.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblMedHistoryTitle.Location = New Point(16, 14)
        lblMedHistoryTitle.Name = "lblMedHistoryTitle"
        lblMedHistoryTitle.Size = New Size(110, 19)
        lblMedHistoryTitle.TabIndex = 0
        lblMedHistoryTitle.Text = "Medical history"
        ' 
        ' cardDemographics
        ' 
        cardDemographics.BackColor = Color.White
        cardDemographics.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardDemographics.BorderHoverColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        cardDemographics.BorderRadius = 12
        cardDemographics.BorderSize = 1
        cardDemographics.Controls.Add(lblAddress)
        cardDemographics.Controls.Add(lblEmail)
        cardDemographics.Controls.Add(lblPhone)
        cardDemographics.Controls.Add(lblBirthDate)
        cardDemographics.Controls.Add(lblAgeSex)
        cardDemographics.Controls.Add(lblDemoTitle)
        cardDemographics.EnableShadow = True
        cardDemographics.HoverTintColor = Color.White
        cardDemographics.Location = New Point(28, 86)
        cardDemographics.Name = "cardDemographics"
        cardDemographics.Padding = New Padding(16, 14, 16, 14)
        cardDemographics.ShadowDepth = 4
        cardDemographics.Size = New Size(308, 168)
        cardDemographics.TabIndex = 2
        ' 
        ' lblAddress
        ' 
        lblAddress.AutoSize = True
        lblAddress.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblAddress.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblAddress.Location = New Point(16, 134)
        lblAddress.Name = "lblAddress"
        lblAddress.Size = New Size(163, 15)
        lblAddress.TabIndex = 5
        lblAddress.Text = "Bagong Silang, Caloocan City"
        ' 
        ' lblEmail
        ' 
        lblEmail.AutoSize = True
        lblEmail.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblEmail.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblEmail.Location = New Point(16, 110)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(130, 15)
        lblEmail.TabIndex = 4
        lblEmail.Text = "maria.santos@email.com"
        ' 
        ' lblPhone
        ' 
        lblPhone.AutoSize = True
        lblPhone.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPhone.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblPhone.Location = New Point(16, 86)
        lblPhone.Name = "lblPhone"
        lblPhone.Size = New Size(79, 15)
        lblPhone.TabIndex = 3
        lblPhone.Text = "0917 432 8801"
        ' 
        ' lblBirthDate
        ' 
        lblBirthDate.AutoSize = True
        lblBirthDate.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblBirthDate.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblBirthDate.Location = New Point(16, 62)
        lblBirthDate.Name = "lblBirthDate"
        lblBirthDate.Size = New Size(119, 15)
        lblBirthDate.TabIndex = 2
        lblBirthDate.Text = "Born March 14, 1992"
        ' 
        ' lblAgeSex
        ' 
        lblAgeSex.AutoSize = True
        lblAgeSex.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblAgeSex.ForeColor = Color.FromArgb(CByte(35), CByte(50), CByte(60))
        lblAgeSex.Location = New Point(16, 38)
        lblAgeSex.Name = "lblAgeSex"
        lblAgeSex.Size = New Size(106, 15)
        lblAgeSex.TabIndex = 1
        lblAgeSex.Text = "34 years old • Female"
        ' 
        ' lblDemoTitle
        ' 
        lblDemoTitle.AutoSize = True
        lblDemoTitle.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDemoTitle.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblDemoTitle.Location = New Point(16, 14)
        lblDemoTitle.Name = "lblDemoTitle"
        lblDemoTitle.Size = New Size(100, 19)
        lblDemoTitle.TabIndex = 0
        lblDemoTitle.Text = "Demographics"
        ' 
        ' lblPatientSubtitle
        ' 
        lblPatientSubtitle.AutoSize = True
        lblPatientSubtitle.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPatientSubtitle.ForeColor = Color.FromArgb(CByte(115), CByte(138), CByte(148))
        lblPatientSubtitle.Location = New Point(29, 54)
        lblPatientSubtitle.Name = "lblPatientSubtitle"
        lblPatientSubtitle.Size = New Size(265, 15)
        lblPatientSubtitle.TabIndex = 1
        lblPatientSubtitle.Text = "Patient PT-1048 • Record updated today at 8:42 AM"
        ' 
        ' lblPatientName
        ' 
        lblPatientName.AutoSize = True
        lblPatientName.Font = New Font("Segoe UI", 18.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPatientName.ForeColor = Color.FromArgb(CByte(22), CByte(51), CByte(65))
        lblPatientName.Location = New Point(28, 20)
        lblPatientName.Name = "lblPatientName"
        lblPatientName.Size = New Size(150, 32)
        lblPatientName.TabIndex = 0
        lblPatientName.Text = "Maria Santos"
        ' 
        ' PatientInformation
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1008, 729)
        Controls.Add(mainScreen)
        Controls.Add(sideBar)
        Name = "DoctorPatientInformation"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Clinic Management - Doctor Patient Information"
        sideBar.ResumeLayout(False)
        sideBar.PerformLayout()
        namePlaceHolder.ResumeLayout(False)
        namePlaceHolder.PerformLayout()
        FCard1.ResumeLayout(False)
        FCard1.PerformLayout()
        mainScreen.ResumeLayout(False)
        mainScreen.PerformLayout()
        cardUpcoming.ResumeLayout(False)
        cardUpcoming.PerformLayout()
        cardVisitTimeline.ResumeLayout(False)
        cardVisitTimeline.PerformLayout()
        cardMedicalHistory.ResumeLayout(False)
        cardMedicalHistory.PerformLayout()
        cardDemographics.ResumeLayout(False)
        cardDemographics.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents sideBar As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents mainScreen As Panel
    Friend WithEvents btnDashboard As FButton
    Friend WithEvents btnReports As FButton
    Friend WithEvents btnConsultation As FButton
    Friend WithEvents btnDoctor As FButton
    Friend WithEvents btnAppointment As FButton
    Friend WithEvents btnPatients As FButton
    Friend WithEvents FCard1 As FCard
    Friend WithEvents Label3 As Label
    Friend WithEvents namePlaceHolder As FCard
    Friend WithEvents txtName As Label
    Friend WithEvents txtRole As Label

    Friend WithEvents lblPatientName As Label
    Friend WithEvents lblPatientSubtitle As Label
    Friend WithEvents cardDemographics As FCard
    Friend WithEvents lblDemoTitle As Label
    Friend WithEvents lblAgeSex As Label
    Friend WithEvents lblBirthDate As Label
    Friend WithEvents lblPhone As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblAddress As Label
    Friend WithEvents cardMedicalHistory As FCard
    Friend WithEvents lblMedHistoryTitle As Label
    Friend WithEvents lblConditionsHeader As Label
    Friend WithEvents lblConditionsValue As Label
    Friend WithEvents lblAllergiesHeader As Label
    Friend WithEvents lblAllergiesValue As Label
    Friend WithEvents cardVisitTimeline As FCard
    Friend WithEvents lblVisitTimelineTitle As Label
    Friend WithEvents lblV1Date As Label
    Friend WithEvents lblV1Type As Label
    Friend WithEvents lblV1Diag As Label
    Friend WithEvents lblV1Doc As Label
    Friend WithEvents btnV1Badge As FButton
    Friend WithEvents divV1 As Panel
    Friend WithEvents lblV2Date As Label
    Friend WithEvents lblV2Type As Label
    Friend WithEvents lblV2Diag As Label
    Friend WithEvents lblV2Doc As Label
    Friend WithEvents btnV2Badge As FButton
    Friend WithEvents divV2 As Panel
    Friend WithEvents lblV3Date As Label
    Friend WithEvents lblV3Type As Label
    Friend WithEvents lblV3Diag As Label
    Friend WithEvents lblV3Doc As Label
    Friend WithEvents btnV3Badge As FButton
    Friend WithEvents cardUpcoming As FCard
    Friend WithEvents lblUpcomingTitle As Label
    Friend WithEvents lblUpcomingDate As Label
    Friend WithEvents lblUpcomingDetails As Label
    Friend WithEvents btnUpcomingBadge As FButton
    Friend WithEvents btnBackToPatients As FButton

End Class
