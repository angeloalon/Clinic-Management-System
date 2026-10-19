Imports FontAwesome.Sharp

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DoctorDashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        lblGreeting = New Label()
        lblSubtitle = New Label()
        cardTodayAppts = New Ferrando.UI.WinForms.Controles.FCard()
        lblCard1Title = New Label()
        lblCard1Value = New Label()
        lblCard1Sub = New Label()
        cardWaitingNow = New Ferrando.UI.WinForms.Controles.FCard()
        lblCard2Title = New Label()
        lblCard2Value = New Label()
        lblCard2Sub = New Label()
        cardCompleted = New Ferrando.UI.WinForms.Controles.FCard()
        lblCard3Title = New Label()
        lblCard3Value = New Label()
        lblCard3Sub = New Label()
        cardCancelled = New Ferrando.UI.WinForms.Controles.FCard()
        lblCard4Title = New Label()
        lblCard4Value = New Label()
        lblCard4Sub = New Label()
        cardApptsList = New Ferrando.UI.WinForms.Controles.FCard()
        lblApptsHeader = New Label()
        lblRow1Time = New Label()
        lblRow1Patient = New Label()
        lblRow1Type = New Label()
        lblRow1Doctor = New Label()
        btnBadgeCompleted = New Ferrando.UI.WinForms.Controles.FButton()
        lineDivider1 = New Panel()
        lblRow2Time = New Label()
        lblRow2Patient = New Label()
        lblRow2Type = New Label()
        lblRow2Doctor = New Label()
        btnBadgePending1 = New Ferrando.UI.WinForms.Controles.FButton()
        lineDivider2 = New Panel()
        lblRow3Time = New Label()
        lblRow3Patient = New Label()
        lblRow3Type = New Label()
        lblRow3Doctor = New Label()
        btnBadgePending2 = New Ferrando.UI.WinForms.Controles.FButton()
        cardQuickActions = New Ferrando.UI.WinForms.Controles.FCard()
        lblQuickActionsHeader = New Label()
        btnScheduleAppt = New Ferrando.UI.WinForms.Controles.FButton()
        btnOpenConsultation = New Ferrando.UI.WinForms.Controles.FButton()
        cardRecentPatients = New Ferrando.UI.WinForms.Controles.FCard()
        lblRecentPatientsHeader = New Label()
        lblRecent1 = New Label()
        lblRecent2 = New Label()
        lblRecent3 = New Label()
        sideBar.SuspendLayout()
        namePlaceHolder.SuspendLayout()
        FCard1.SuspendLayout()
        mainScreen.SuspendLayout()
        cardTodayAppts.SuspendLayout()
        cardWaitingNow.SuspendLayout()
        cardCompleted.SuspendLayout()
        cardCancelled.SuspendLayout()
        cardApptsList.SuspendLayout()
        cardQuickActions.SuspendLayout()
        cardRecentPatients.SuspendLayout()
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
        mainScreen.Controls.Add(lblGreeting)
        mainScreen.Controls.Add(lblSubtitle)
        mainScreen.Controls.Add(cardTodayAppts)
        mainScreen.Controls.Add(cardWaitingNow)
        mainScreen.Controls.Add(cardCompleted)
        mainScreen.Controls.Add(cardCancelled)
        mainScreen.Controls.Add(cardApptsList)
        mainScreen.Controls.Add(cardQuickActions)
        mainScreen.Controls.Add(cardRecentPatients)
        mainScreen.Location = New Point(176, 0)
        mainScreen.Name = "mainScreen"
        mainScreen.Size = New Size(832, 730)
        mainScreen.TabIndex = 1
        ' 
        ' lblGreeting
        ' 
        lblGreeting.AutoSize = True
        lblGreeting.Font = New Font("Segoe UI", 18.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblGreeting.ForeColor = Color.FromArgb(CByte(22), CByte(51), CByte(65))
        lblGreeting.Location = New Point(28, 20)
        lblGreeting.Name = "lblGreeting"
        lblGreeting.Size = New Size(269, 32)
        lblGreeting.TabIndex = 0
        lblGreeting.Text = "Good morning, Dr. Cruz"
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.AutoSize = True
        lblSubtitle.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSubtitle.ForeColor = Color.FromArgb(CByte(115), CByte(138), CByte(148))
        lblSubtitle.Location = New Point(29, 54)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(264, 15)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "Tuesday, September 22 • Clinic operations at a glance"
        ' 
        ' cardTodayAppts
        ' 
        cardTodayAppts.BackColor = Color.White
        cardTodayAppts.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardTodayAppts.BorderHoverColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        cardTodayAppts.BorderRadius = 12
        cardTodayAppts.BorderSize = 1
        cardTodayAppts.Controls.Add(lblCard1Sub)
        cardTodayAppts.Controls.Add(lblCard1Value)
        cardTodayAppts.Controls.Add(lblCard1Title)
        cardTodayAppts.EnableShadow = True
        cardTodayAppts.HoverTintColor = Color.White
        cardTodayAppts.Location = New Point(28, 86)
        cardTodayAppts.Name = "cardTodayAppts"
        cardTodayAppts.Padding = New Padding(14, 12, 14, 12)
        cardTodayAppts.ShadowDepth = 4
        cardTodayAppts.Size = New Size(184, 104)
        cardTodayAppts.TabIndex = 2
        ' 
        ' lblCard1Title
        ' 
        lblCard1Title.AutoSize = True
        lblCard1Title.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCard1Title.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblCard1Title.Location = New Point(14, 12)
        lblCard1Title.Name = "lblCard1Title"
        lblCard1Title.Size = New Size(125, 15)
        lblCard1Title.TabIndex = 0
        lblCard1Title.Text = "Today's appointments"
        ' 
        ' lblCard1Value
        ' 
        lblCard1Value.AutoSize = True
        lblCard1Value.Font = New Font("Segoe UI", 25.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCard1Value.ForeColor = Color.FromArgb(CByte(22), CByte(51), CByte(65))
        lblCard1Value.Location = New Point(10, 28)
        lblCard1Value.Name = "lblCard1Value"
        lblCard1Value.Size = New Size(38, 46)
        lblCard1Value.TabIndex = 1
        lblCard1Value.Text = "3"
        ' 
        ' lblCard1Sub
        ' 
        lblCard1Sub.AutoSize = True
        lblCard1Sub.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCard1Sub.ForeColor = Color.FromArgb(CByte(135), CByte(148), CByte(158))
        lblCard1Sub.Location = New Point(14, 76)
        lblCard1Sub.Name = "lblCard1Sub"
        lblCard1Sub.Size = New Size(67, 13)
        lblCard1Sub.TabIndex = 2
        lblCard1Sub.Text = "2 remaining"
        ' 
        ' cardWaitingNow
        ' 
        cardWaitingNow.BackColor = Color.White
        cardWaitingNow.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardWaitingNow.BorderHoverColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        cardWaitingNow.BorderRadius = 12
        cardWaitingNow.BorderSize = 1
        cardWaitingNow.Controls.Add(lblCard2Sub)
        cardWaitingNow.Controls.Add(lblCard2Value)
        cardWaitingNow.Controls.Add(lblCard2Title)
        cardWaitingNow.EnableShadow = True
        cardWaitingNow.HoverTintColor = Color.White
        cardWaitingNow.Location = New Point(226, 86)
        cardWaitingNow.Name = "cardWaitingNow"
        cardWaitingNow.Padding = New Padding(14, 12, 14, 12)
        cardWaitingNow.ShadowDepth = 4
        cardWaitingNow.Size = New Size(184, 104)
        cardWaitingNow.TabIndex = 3
        ' 
        ' lblCard2Title
        ' 
        lblCard2Title.AutoSize = True
        lblCard2Title.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCard2Title.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblCard2Title.Location = New Point(14, 12)
        lblCard2Title.Name = "lblCard2Title"
        lblCard2Title.Size = New Size(74, 15)
        lblCard2Title.TabIndex = 0
        lblCard2Title.Text = "Waiting now"
        ' 
        ' lblCard2Value
        ' 
        lblCard2Value.AutoSize = True
        lblCard2Value.Font = New Font("Segoe UI", 25.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCard2Value.ForeColor = Color.FromArgb(CByte(22), CByte(51), CByte(65))
        lblCard2Value.Location = New Point(10, 28)
        lblCard2Value.Name = "lblCard2Value"
        lblCard2Value.Size = New Size(38, 46)
        lblCard2Value.TabIndex = 1
        lblCard2Value.Text = "2"
        ' 
        ' lblCard2Sub
        ' 
        lblCard2Sub.AutoSize = True
        lblCard2Sub.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCard2Sub.ForeColor = Color.FromArgb(CByte(135), CByte(148), CByte(158))
        lblCard2Sub.Location = New Point(14, 76)
        lblCard2Sub.Name = "lblCard2Sub"
        lblCard2Sub.Size = New Size(70, 13)
        lblCard2Sub.TabIndex = 2
        lblCard2Sub.Text = "Avg. 11 min"
        ' 
        ' cardCompleted
        ' 
        cardCompleted.BackColor = Color.White
        cardCompleted.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardCompleted.BorderHoverColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        cardCompleted.BorderRadius = 12
        cardCompleted.BorderSize = 1
        cardCompleted.Controls.Add(lblCard3Sub)
        cardCompleted.Controls.Add(lblCard3Value)
        cardCompleted.Controls.Add(lblCard3Title)
        cardCompleted.EnableShadow = True
        cardCompleted.HoverTintColor = Color.White
        cardCompleted.Location = New Point(424, 86)
        cardCompleted.Name = "cardCompleted"
        cardCompleted.Padding = New Padding(14, 12, 14, 12)
        cardCompleted.ShadowDepth = 4
        cardCompleted.Size = New Size(184, 104)
        cardCompleted.TabIndex = 4
        ' 
        ' lblCard3Title
        ' 
        lblCard3Title.AutoSize = True
        lblCard3Title.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCard3Title.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblCard3Title.Location = New Point(14, 12)
        lblCard3Title.Name = "lblCard3Title"
        lblCard3Title.Size = New Size(67, 15)
        lblCard3Title.TabIndex = 0
        lblCard3Title.Text = "Completed"
        ' 
        ' lblCard3Value
        ' 
        lblCard3Value.AutoSize = True
        lblCard3Value.Font = New Font("Segoe UI", 25.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCard3Value.ForeColor = Color.FromArgb(CByte(22), CByte(51), CByte(65))
        lblCard3Value.Location = New Point(10, 28)
        lblCard3Value.Name = "lblCard3Value"
        lblCard3Value.Size = New Size(38, 46)
        lblCard3Value.TabIndex = 1
        lblCard3Value.Text = "1"
        ' 
        ' lblCard3Sub
        ' 
        lblCard3Sub.AutoSize = True
        lblCard3Sub.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCard3Sub.ForeColor = Color.FromArgb(CByte(135), CByte(148), CByte(158))
        lblCard3Sub.Location = New Point(14, 76)
        lblCard3Sub.Name = "lblCard3Sub"
        lblCard3Sub.Size = New Size(68, 13)
        lblCard3Sub.TabIndex = 2
        lblCard3Sub.Text = "67% of today"
        ' 
        ' cardCancelled
        ' 
        cardCancelled.BackColor = Color.White
        cardCancelled.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardCancelled.BorderHoverColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        cardCancelled.BorderRadius = 12
        cardCancelled.BorderSize = 1
        cardCancelled.Controls.Add(lblCard4Sub)
        cardCancelled.Controls.Add(lblCard4Value)
        cardCancelled.Controls.Add(lblCard4Title)
        cardCancelled.EnableShadow = True
        cardCancelled.HoverTintColor = Color.White
        cardCancelled.Location = New Point(622, 86)
        cardCancelled.Name = "cardCancelled"
        cardCancelled.Padding = New Padding(14, 12, 14, 12)
        cardCancelled.ShadowDepth = 4
        cardCancelled.Size = New Size(180, 104)
        cardCancelled.TabIndex = 5
        ' 
        ' lblCard4Title
        ' 
        lblCard4Title.AutoSize = True
        lblCard4Title.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCard4Title.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblCard4Title.Location = New Point(14, 12)
        lblCard4Title.Name = "lblCard4Title"
        lblCard4Title.Size = New Size(60, 15)
        lblCard4Title.TabIndex = 0
        lblCard4Title.Text = "Cancelled"
        ' 
        ' lblCard4Value
        ' 
        lblCard4Value.AutoSize = True
        lblCard4Value.Font = New Font("Segoe UI", 25.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCard4Value.ForeColor = Color.FromArgb(CByte(205), CByte(80), CByte(75))
        lblCard4Value.Location = New Point(10, 28)
        lblCard4Value.Name = "lblCard4Value"
        lblCard4Value.Size = New Size(38, 46)
        lblCard4Value.TabIndex = 1
        lblCard4Value.Text = "0"
        ' 
        ' lblCard4Sub
        ' 
        lblCard4Sub.AutoSize = True
        lblCard4Sub.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCard4Sub.ForeColor = Color.FromArgb(CByte(135), CByte(148), CByte(158))
        lblCard4Sub.Location = New Point(14, 76)
        lblCard4Sub.Name = "lblCard4Sub"
        lblCard4Sub.Size = New Size(76, 13)
        lblCard4Sub.TabIndex = 2
        lblCard4Sub.Text = "2 rescheduled"
        ' 
        ' cardApptsList
        ' 
        cardApptsList.BackColor = Color.White
        cardApptsList.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardApptsList.BorderHoverColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        cardApptsList.BorderRadius = 12
        cardApptsList.BorderSize = 1
        cardApptsList.Controls.Add(btnBadgePending2)
        cardApptsList.Controls.Add(lblRow3Doctor)
        cardApptsList.Controls.Add(lblRow3Type)
        cardApptsList.Controls.Add(lblRow3Patient)
        cardApptsList.Controls.Add(lblRow3Time)
        cardApptsList.Controls.Add(lineDivider2)
        cardApptsList.Controls.Add(btnBadgePending1)
        cardApptsList.Controls.Add(lblRow2Doctor)
        cardApptsList.Controls.Add(lblRow2Type)
        cardApptsList.Controls.Add(lblRow2Patient)
        cardApptsList.Controls.Add(lblRow2Time)
        cardApptsList.Controls.Add(lineDivider1)
        cardApptsList.Controls.Add(btnBadgeCompleted)
        cardApptsList.Controls.Add(lblRow1Doctor)
        cardApptsList.Controls.Add(lblRow1Type)
        cardApptsList.Controls.Add(lblRow1Patient)
        cardApptsList.Controls.Add(lblRow1Time)
        cardApptsList.Controls.Add(lblApptsHeader)
        cardApptsList.EnableShadow = True
        cardApptsList.HoverTintColor = Color.White
        cardApptsList.Location = New Point(28, 206)
        cardApptsList.Name = "cardApptsList"
        cardApptsList.Padding = New Padding(16)
        cardApptsList.ShadowDepth = 4
        cardApptsList.Size = New Size(520, 260)
        cardApptsList.TabIndex = 6
        ' 
        ' lblApptsHeader
        ' 
        lblApptsHeader.AutoSize = True
        lblApptsHeader.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblApptsHeader.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblApptsHeader.Location = New Point(18, 16)
        lblApptsHeader.Name = "lblApptsHeader"
        lblApptsHeader.Size = New Size(149, 19)
        lblApptsHeader.TabIndex = 0
        lblApptsHeader.Text = "Today's appointments"
        ' 
        ' lblRow1Time
        ' 
        lblRow1Time.AutoSize = True
        lblRow1Time.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRow1Time.ForeColor = Color.FromArgb(CByte(40), CByte(55), CByte(65))
        lblRow1Time.Location = New Point(20, 68)
        lblRow1Time.Name = "lblRow1Time"
        lblRow1Time.Size = New Size(54, 15)
        lblRow1Time.TabIndex = 1
        lblRow1Time.Text = "8:00 AM"
        ' 
        ' lblRow1Patient
        ' 
        lblRow1Patient.AutoSize = True
        lblRow1Patient.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow1Patient.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblRow1Patient.Location = New Point(125, 68)
        lblRow1Patient.Name = "lblRow1Patient"
        lblRow1Patient.Size = New Size(74, 15)
        lblRow1Patient.TabIndex = 2
        lblRow1Patient.Text = "Maria Santos"
        ' 
        ' lblRow1Type
        ' 
        lblRow1Type.AutoSize = True
        lblRow1Type.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow1Type.ForeColor = Color.FromArgb(CByte(125), CByte(140), CByte(150))
        lblRow1Type.Location = New Point(245, 68)
        lblRow1Type.Name = "lblRow1Type"
        lblRow1Type.Size = New Size(59, 15)
        lblRow1Type.TabIndex = 3
        lblRow1Type.Text = "Follow-up"
        ' 
        ' lblRow1Doctor
        ' 
        lblRow1Doctor.AutoSize = True
        lblRow1Doctor.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow1Doctor.ForeColor = Color.FromArgb(CByte(125), CByte(140), CByte(150))
        lblRow1Doctor.Location = New Point(350, 68)
        lblRow1Doctor.Name = "lblRow1Doctor"
        lblRow1Doctor.Size = New Size(50, 15)
        lblRow1Doctor.TabIndex = 4
        lblRow1Doctor.Text = "Dr. Cruz"
        ' 
        ' btnBadgeCompleted
        ' 
        btnBadgeCompleted.BackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnBadgeCompleted.BorderColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnBadgeCompleted.BorderRadius = 10
        btnBadgeCompleted.BorderSize = 0
        btnBadgeCompleted.FlatAppearance.BorderSize = 0
        btnBadgeCompleted.FlatStyle = FlatStyle.Flat
        btnBadgeCompleted.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnBadgeCompleted.ForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        btnBadgeCompleted.Location = New Point(425, 64)
        btnBadgeCompleted.MouseEnterBackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnBadgeCompleted.MouseEnterBorderColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnBadgeCompleted.MouseEnterBorderSize = 0
        btnBadgeCompleted.MouseEnterFont = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        btnBadgeCompleted.MouseEnterForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        btnBadgeCompleted.MouseLeaveBackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnBadgeCompleted.MouseLeaveBorderColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnBadgeCompleted.MouseLeaveBorderSize = 0
        btnBadgeCompleted.MouseLeaveFont = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        btnBadgeCompleted.MouseLeaveForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        btnBadgeCompleted.Name = "btnBadgeCompleted"
        btnBadgeCompleted.Size = New Size(76, 24)
        btnBadgeCompleted.TabIndex = 5
        btnBadgeCompleted.Text = "Completed"
        btnBadgeCompleted.UseVisualStyleBackColor = False
        ' 
        ' lineDivider1
        ' 
        lineDivider1.BackColor = Color.FromArgb(CByte(242), CByte(244), CByte(247))
        lineDivider1.Location = New Point(20, 106)
        lineDivider1.Name = "lineDivider1"
        lineDivider1.Size = New Size(480, 1)
        lineDivider1.TabIndex = 6
        ' 
        ' lblRow2Time
        ' 
        lblRow2Time.AutoSize = True
        lblRow2Time.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRow2Time.ForeColor = Color.FromArgb(CByte(40), CByte(55), CByte(65))
        lblRow2Time.Location = New Point(20, 128)
        lblRow2Time.Name = "lblRow2Time"
        lblRow2Time.Size = New Size(60, 15)
        lblRow2Time.TabIndex = 7
        lblRow2Time.Text = "10:30 AM"
        ' 
        ' lblRow2Patient
        ' 
        lblRow2Patient.AutoSize = True
        lblRow2Patient.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow2Patient.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblRow2Patient.Location = New Point(125, 128)
        lblRow2Patient.Name = "lblRow2Patient"
        lblRow2Patient.Size = New Size(72, 15)
        lblRow2Patient.TabIndex = 8
        lblRow2Patient.Text = "Joshua Reyes"
        ' 
        ' lblRow2Type
        ' 
        lblRow2Type.AutoSize = True
        lblRow2Type.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow2Type.ForeColor = Color.FromArgb(CByte(125), CByte(140), CByte(150))
        lblRow2Type.Location = New Point(245, 128)
        lblRow2Type.Name = "lblRow2Type"
        lblRow2Type.Size = New Size(74, 15)
        lblRow2Type.TabIndex = 9
        lblRow2Type.Text = "Consultation"
        ' 
        ' lblRow2Doctor
        ' 
        lblRow2Doctor.AutoSize = True
        lblRow2Doctor.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow2Doctor.ForeColor = Color.FromArgb(CByte(125), CByte(140), CByte(150))
        lblRow2Doctor.Location = New Point(350, 128)
        lblRow2Doctor.Name = "lblRow2Doctor"
        lblRow2Doctor.Size = New Size(50, 15)
        lblRow2Doctor.TabIndex = 10
        lblRow2Doctor.Text = "Dr. Cruz"
        ' 
        ' btnBadgePending1
        ' 
        btnBadgePending1.BackColor = Color.FromArgb(CByte(254), CByte(243), CByte(226))
        btnBadgePending1.BorderColor = Color.FromArgb(CByte(254), CByte(243), CByte(226))
        btnBadgePending1.BorderRadius = 10
        btnBadgePending1.BorderSize = 0
        btnBadgePending1.FlatAppearance.BorderSize = 0
        btnBadgePending1.FlatStyle = FlatStyle.Flat
        btnBadgePending1.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnBadgePending1.ForeColor = Color.FromArgb(CByte(217), CByte(119), CByte(6))
        btnBadgePending1.Location = New Point(425, 124)
        btnBadgePending1.MouseEnterBackColor = Color.FromArgb(CByte(254), CByte(243), CByte(226))
        btnBadgePending1.MouseEnterBorderColor = Color.FromArgb(CByte(254), CByte(243), CByte(226))
        btnBadgePending1.MouseEnterBorderSize = 0
        btnBadgePending1.MouseEnterFont = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        btnBadgePending1.MouseEnterForeColor = Color.FromArgb(CByte(217), CByte(119), CByte(6))
        btnBadgePending1.MouseLeaveBackColor = Color.FromArgb(CByte(254), CByte(243), CByte(226))
        btnBadgePending1.MouseLeaveBorderColor = Color.FromArgb(CByte(254), CByte(243), CByte(226))
        btnBadgePending1.MouseLeaveBorderSize = 0
        btnBadgePending1.MouseLeaveFont = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        btnBadgePending1.MouseLeaveForeColor = Color.FromArgb(CByte(217), CByte(119), CByte(6))
        btnBadgePending1.Name = "btnBadgePending1"
        btnBadgePending1.Size = New Size(76, 24)
        btnBadgePending1.TabIndex = 11
        btnBadgePending1.Text = "Pending"
        btnBadgePending1.UseVisualStyleBackColor = False
        ' 
        ' lineDivider2
        ' 
        lineDivider2.BackColor = Color.FromArgb(CByte(242), CByte(244), CByte(247))
        lineDivider2.Location = New Point(20, 168)
        lineDivider2.Name = "lineDivider2"
        lineDivider2.Size = New Size(480, 1)
        lineDivider2.TabIndex = 12
        ' 
        ' lblRow3Time
        ' 
        lblRow3Time.AutoSize = True
        lblRow3Time.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRow3Time.ForeColor = Color.FromArgb(CByte(40), CByte(55), CByte(65))
        lblRow3Time.Location = New Point(20, 190)
        lblRow3Time.Name = "lblRow3Time"
        lblRow3Time.Size = New Size(54, 15)
        lblRow3Time.TabIndex = 13
        lblRow3Time.Text = "3:30 PM"
        ' 
        ' lblRow3Patient
        ' 
        lblRow3Patient.AutoSize = True
        lblRow3Patient.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow3Patient.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblRow3Patient.Location = New Point(125, 190)
        lblRow3Patient.Name = "lblRow3Patient"
        lblRow3Patient.Size = New Size(74, 15)
        lblRow3Patient.TabIndex = 14
        lblRow3Patient.Text = "Roberto Diaz"
        ' 
        ' lblRow3Type
        ' 
        lblRow3Type.AutoSize = True
        lblRow3Type.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow3Type.ForeColor = Color.FromArgb(CByte(125), CByte(140), CByte(150))
        lblRow3Type.Location = New Point(245, 190)
        lblRow3Type.Name = "lblRow3Type"
        lblRow3Type.Size = New Size(59, 15)
        lblRow3Type.TabIndex = 15
        lblRow3Type.Text = "Follow-up"
        ' 
        ' lblRow3Doctor
        ' 
        lblRow3Doctor.AutoSize = True
        lblRow3Doctor.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow3Doctor.ForeColor = Color.FromArgb(CByte(125), CByte(140), CByte(150))
        lblRow3Doctor.Location = New Point(350, 190)
        lblRow3Doctor.Name = "lblRow3Doctor"
        lblRow3Doctor.Size = New Size(50, 15)
        lblRow3Doctor.TabIndex = 16
        lblRow3Doctor.Text = "Dr. Cruz"
        ' 
        ' btnBadgePending2
        ' 
        btnBadgePending2.BackColor = Color.FromArgb(CByte(254), CByte(243), CByte(226))
        btnBadgePending2.BorderColor = Color.FromArgb(CByte(254), CByte(243), CByte(226))
        btnBadgePending2.BorderRadius = 10
        btnBadgePending2.BorderSize = 0
        btnBadgePending2.FlatAppearance.BorderSize = 0
        btnBadgePending2.FlatStyle = FlatStyle.Flat
        btnBadgePending2.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnBadgePending2.ForeColor = Color.FromArgb(CByte(217), CByte(119), CByte(6))
        btnBadgePending2.Location = New Point(425, 186)
        btnBadgePending2.MouseEnterBackColor = Color.FromArgb(CByte(254), CByte(243), CByte(226))
        btnBadgePending2.MouseEnterBorderColor = Color.FromArgb(CByte(254), CByte(243), CByte(226))
        btnBadgePending2.MouseEnterBorderSize = 0
        btnBadgePending2.MouseEnterFont = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        btnBadgePending2.MouseEnterForeColor = Color.FromArgb(CByte(217), CByte(119), CByte(6))
        btnBadgePending2.MouseLeaveBackColor = Color.FromArgb(CByte(254), CByte(243), CByte(226))
        btnBadgePending2.MouseLeaveBorderColor = Color.FromArgb(CByte(254), CByte(243), CByte(226))
        btnBadgePending2.MouseLeaveBorderSize = 0
        btnBadgePending2.MouseLeaveFont = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        btnBadgePending2.MouseLeaveForeColor = Color.FromArgb(CByte(217), CByte(119), CByte(6))
        btnBadgePending2.Name = "btnBadgePending2"
        btnBadgePending2.Size = New Size(76, 24)
        btnBadgePending2.TabIndex = 17
        btnBadgePending2.Text = "Pending"
        btnBadgePending2.UseVisualStyleBackColor = False
        ' 
        ' cardQuickActions
        ' 
        cardQuickActions.BackColor = Color.White
        cardQuickActions.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardQuickActions.BorderHoverColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        cardQuickActions.BorderRadius = 12
        cardQuickActions.BorderSize = 1
        cardQuickActions.Controls.Add(btnOpenConsultation)
        cardQuickActions.Controls.Add(lblQuickActionsHeader)
        cardQuickActions.EnableShadow = True
        cardQuickActions.HoverTintColor = Color.White
        cardQuickActions.Location = New Point(562, 206)
        cardQuickActions.Name = "cardQuickActions"
        cardQuickActions.Padding = New Padding(16, 14, 16, 14)
        cardQuickActions.ShadowDepth = 4
        cardQuickActions.Size = New Size(240, 96)
        cardQuickActions.TabIndex = 7
        ' 
        ' lblQuickActionsHeader
        ' 
        lblQuickActionsHeader.AutoSize = True
        lblQuickActionsHeader.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblQuickActionsHeader.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblQuickActionsHeader.Location = New Point(16, 14)
        lblQuickActionsHeader.Name = "lblQuickActionsHeader"
        lblQuickActionsHeader.Size = New Size(99, 19)
        lblQuickActionsHeader.TabIndex = 0
        lblQuickActionsHeader.Text = "Quick actions"
        ' 
        ' btnOpenConsultation
        ' 
        btnOpenConsultation.BackColor = Color.White
        btnOpenConsultation.BorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnOpenConsultation.BorderRadius = 8
        btnOpenConsultation.BorderSize = 1
        btnOpenConsultation.FlatAppearance.BorderSize = 0
        btnOpenConsultation.FlatStyle = FlatStyle.Flat
        btnOpenConsultation.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnOpenConsultation.ForeColor = Color.FromArgb(CByte(27), CByte(54), CByte(68))
        btnOpenConsultation.Location = New Point(16, 44)
        btnOpenConsultation.MouseEnterBackColor = Color.FromArgb(CByte(245), CByte(249), CByte(251))
        btnOpenConsultation.MouseEnterBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnOpenConsultation.MouseEnterBorderSize = 1
        btnOpenConsultation.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnOpenConsultation.MouseEnterForeColor = Color.FromArgb(CByte(17), CByte(54), CByte(70))
        btnOpenConsultation.MouseLeaveBackColor = Color.White
        btnOpenConsultation.MouseLeaveBorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnOpenConsultation.MouseLeaveBorderSize = 1
        btnOpenConsultation.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnOpenConsultation.MouseLeaveForeColor = Color.FromArgb(CByte(27), CByte(54), CByte(68))
        btnOpenConsultation.Name = "btnOpenConsultation"
        btnOpenConsultation.Size = New Size(208, 32)
        btnOpenConsultation.TabIndex = 1
        btnOpenConsultation.Text = "Open consultation"
        btnOpenConsultation.UseVisualStyleBackColor = False
        ' 
        ' cardRecentPatients
        ' 
        cardRecentPatients.BackColor = Color.White
        cardRecentPatients.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardRecentPatients.BorderHoverColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        cardRecentPatients.BorderRadius = 12
        cardRecentPatients.BorderSize = 1
        cardRecentPatients.Controls.Add(lblRecent3)
        cardRecentPatients.Controls.Add(lblRecent2)
        cardRecentPatients.Controls.Add(lblRecent1)
        cardRecentPatients.Controls.Add(lblRecentPatientsHeader)
        cardRecentPatients.EnableShadow = True
        cardRecentPatients.HoverTintColor = Color.White
        cardRecentPatients.Location = New Point(562, 334)
        cardRecentPatients.Name = "cardRecentPatients"
        cardRecentPatients.Padding = New Padding(16, 14, 16, 14)
        cardRecentPatients.ShadowDepth = 4
        cardRecentPatients.Size = New Size(240, 132)
        cardRecentPatients.TabIndex = 8
        ' 
        ' lblRecentPatientsHeader
        ' 
        lblRecentPatientsHeader.AutoSize = True
        lblRecentPatientsHeader.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRecentPatientsHeader.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblRecentPatientsHeader.Location = New Point(16, 14)
        lblRecentPatientsHeader.Name = "lblRecentPatientsHeader"
        lblRecentPatientsHeader.Size = New Size(111, 19)
        lblRecentPatientsHeader.TabIndex = 0
        lblRecentPatientsHeader.Text = "Recent patients"
        ' 
        ' lblRecent1
        ' 
        lblRecent1.AutoSize = True
        lblRecent1.Font = New Font("Segoe UI", 8.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRecent1.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        lblRecent1.Location = New Point(16, 42)
        lblRecent1.Name = "lblRecent1"
        lblRecent1.Size = New Size(129, 15)
        lblRecent1.TabIndex = 1
        lblRecent1.Text = "Maria Santos • PT-1048"
        ' 
        ' lblRecent2
        ' 
        lblRecent2.AutoSize = True
        lblRecent2.Font = New Font("Segoe UI", 8.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRecent2.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        lblRecent2.Location = New Point(16, 70)
        lblRecent2.Name = "lblRecent2"
        lblRecent2.Size = New Size(127, 15)
        lblRecent2.TabIndex = 2
        lblRecent2.Text = "Joshua Reyes • PT-1051"
        ' 
        ' lblRecent3
        ' 
        lblRecent3.AutoSize = True
        lblRecent3.Font = New Font("Segoe UI", 8.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRecent3.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        lblRecent3.Location = New Point(16, 98)
        lblRecent3.Name = "lblRecent3"
        lblRecent3.Size = New Size(136, 15)
        lblRecent3.TabIndex = 3
        lblRecent3.Text = "Ana Villanueva • PT-1028"
        ' 
        ' DoctorDashboard
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1008, 729)
        Controls.Add(mainScreen)
        Controls.Add(sideBar)
        Name = "DoctorDashboard"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Clinic Management - Doctor Dashboard"
        sideBar.ResumeLayout(False)
        sideBar.PerformLayout()
        namePlaceHolder.ResumeLayout(False)
        namePlaceHolder.PerformLayout()
        FCard1.ResumeLayout(False)
        FCard1.PerformLayout()
        mainScreen.ResumeLayout(False)
        mainScreen.PerformLayout()
        cardTodayAppts.ResumeLayout(False)
        cardTodayAppts.PerformLayout()
        cardWaitingNow.ResumeLayout(False)
        cardWaitingNow.PerformLayout()
        cardCompleted.ResumeLayout(False)
        cardCompleted.PerformLayout()
        cardCancelled.ResumeLayout(False)
        cardCancelled.PerformLayout()
        cardApptsList.ResumeLayout(False)
        cardApptsList.PerformLayout()
        cardQuickActions.ResumeLayout(False)
        cardQuickActions.PerformLayout()
        cardRecentPatients.ResumeLayout(False)
        cardRecentPatients.PerformLayout()
        ResumeLayout(False)
    End Sub

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

    Friend WithEvents lblGreeting As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents cardTodayAppts As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblCard1Title As Label
    Friend WithEvents lblCard1Value As Label
    Friend WithEvents lblCard1Sub As Label
    Friend WithEvents cardWaitingNow As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblCard2Title As Label
    Friend WithEvents lblCard2Value As Label
    Friend WithEvents lblCard2Sub As Label
    Friend WithEvents cardCompleted As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblCard3Title As Label
    Friend WithEvents lblCard3Value As Label
    Friend WithEvents lblCard3Sub As Label
    Friend WithEvents cardCancelled As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblCard4Title As Label
    Friend WithEvents lblCard4Value As Label
    Friend WithEvents lblCard4Sub As Label
    Friend WithEvents cardApptsList As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblApptsHeader As Label
    Friend WithEvents lblRow1Time As Label
    Friend WithEvents lblRow1Patient As Label
    Friend WithEvents lblRow1Type As Label
    Friend WithEvents lblRow1Doctor As Label
    Friend WithEvents btnBadgeCompleted As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents lineDivider1 As Panel
    Friend WithEvents lblRow2Time As Label
    Friend WithEvents lblRow2Patient As Label
    Friend WithEvents lblRow2Type As Label
    Friend WithEvents lblRow2Doctor As Label
    Friend WithEvents btnBadgePending1 As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents lineDivider2 As Panel
    Friend WithEvents lblRow3Time As Label
    Friend WithEvents lblRow3Patient As Label
    Friend WithEvents lblRow3Type As Label
    Friend WithEvents lblRow3Doctor As Label
    Friend WithEvents btnBadgePending2 As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents cardQuickActions As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblQuickActionsHeader As Label
    Friend WithEvents btnScheduleAppt As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnOpenConsultation As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents cardRecentPatients As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblRecentPatientsHeader As Label
    Friend WithEvents lblRecent1 As Label
    Friend WithEvents lblRecent2 As Label
    Friend WithEvents lblRecent3 As Label

End Class
