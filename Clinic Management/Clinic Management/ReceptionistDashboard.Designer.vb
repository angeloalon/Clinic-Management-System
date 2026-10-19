Imports FontAwesome.Sharp

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReceptionistDashboard

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
        btnLogout = New Ferrando.UI.WinForms.Controles.FButton()
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
        pnlDashboard = New Panel()
        lblGreeting = New Label()
        lblSubtitle = New Label()
        btnNewAppointment = New Ferrando.UI.WinForms.Controles.FButton()
        cardKpi1 = New Ferrando.UI.WinForms.Controles.FCard()
        lblCard1Context = New Label()
        lblCard1Value = New Label()
        lblCard1Title = New Label()
        cardKpi2 = New Ferrando.UI.WinForms.Controles.FCard()
        lblCard2Context = New Label()
        lblCard2Value = New Label()
        lblCard2Title = New Label()
        cardKpi3 = New Ferrando.UI.WinForms.Controles.FCard()
        lblCard3Context = New Label()
        lblCard3Value = New Label()
        lblCard3Title = New Label()
        cardKpi4 = New Ferrando.UI.WinForms.Controles.FCard()
        lblCard4Context = New Label()
        lblCard4Value = New Label()
        lblCard4Title = New Label()
        cardAppts = New Ferrando.UI.WinForms.Controles.FCard()
        lblApptsHeader = New Label()
        lblEmpty = New Label()
        lblRow1Time = New Label()
        lblRow1Patient = New Label()
        lblRow1Type = New Label()
        lblRow1Doctor = New Label()
        btnRow1Status = New Ferrando.UI.WinForms.Controles.FButton()
        pnlRow1Divider = New Panel()
        lblRow2Time = New Label()
        lblRow2Patient = New Label()
        lblRow2Type = New Label()
        lblRow2Doctor = New Label()
        btnRow2Status = New Ferrando.UI.WinForms.Controles.FButton()
        pnlRow2Divider = New Panel()
        lblRow3Time = New Label()
        lblRow3Patient = New Label()
        lblRow3Type = New Label()
        lblRow3Doctor = New Label()
        btnRow3Status = New Ferrando.UI.WinForms.Controles.FButton()
        pnlRow3Divider = New Panel()
        lblRow4Time = New Label()
        lblRow4Patient = New Label()
        lblRow4Type = New Label()
        lblRow4Doctor = New Label()
        btnRow4Status = New Ferrando.UI.WinForms.Controles.FButton()
        pnlRow4Divider = New Panel()
        cardQuick = New Ferrando.UI.WinForms.Controles.FCard()
        lblQuickTitle = New Label()
        btnRegisterPatient = New Ferrando.UI.WinForms.Controles.FButton()
        btnOpenConsultation = New Ferrando.UI.WinForms.Controles.FButton()
        cardRecent = New Ferrando.UI.WinForms.Controles.FCard()
        lblRecentTitle = New Label()
        lblRecent1 = New Label()
        lblRecent2 = New Label()
        lblRecent3 = New Label()
        Label5 = New Label()
        btnScheduleAppt = New Ferrando.UI.WinForms.Controles.FButton()
        sideBar.SuspendLayout()
        namePlaceHolder.SuspendLayout()
        FCard1.SuspendLayout()
        mainScreen.SuspendLayout()
        pnlDashboard.SuspendLayout()
        cardKpi1.SuspendLayout()
        cardKpi2.SuspendLayout()
        cardKpi3.SuspendLayout()
        cardKpi4.SuspendLayout()
        cardAppts.SuspendLayout()
        cardQuick.SuspendLayout()
        cardRecent.SuspendLayout()
        SuspendLayout()
        ' 
        ' sideBar
        ' 
        sideBar.BackColor = Color.FromArgb(CByte(17), CByte(54), CByte(70))
        sideBar.Controls.Add(btnLogout)
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
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.FromArgb(CByte(17), CByte(54), CByte(70))
        btnLogout.BorderColor = Color.Black
        btnLogout.BorderRadius = 10
        btnLogout.BorderSize = 0
        btnLogout.FlatAppearance.BorderSize = 0
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnLogout.ForeColor = Color.FromArgb(CByte(182), CByte(204), CByte(210))
        btnLogout.Location = New Point(3, 495)
        btnLogout.MouseEnterBackColor = Color.FromArgb(CByte(45), CByte(65), CByte(75))
        btnLogout.MouseEnterBorderColor = Color.Black
        btnLogout.MouseEnterBorderSize = 0
        btnLogout.MouseEnterFont = New Font("Microsoft Sans Serif", 10F)
        btnLogout.MouseEnterForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnLogout.MouseLeaveBackColor = Color.FromArgb(CByte(17), CByte(54), CByte(70))
        btnLogout.MouseLeaveBorderColor = Color.Black
        btnLogout.MouseLeaveBorderSize = 0
        btnLogout.MouseLeaveFont = New Font("Microsoft Sans Serif", 10F)
        btnLogout.MouseLeaveForeColor = Color.FromArgb(CByte(182), CByte(204), CByte(210))
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(162, 35)
        btnLogout.TabIndex = 12
        btnLogout.Text = "Log Out"
        btnLogout.UseVisualStyleBackColor = False
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
        txtRole.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtRole.ForeColor = Color.FromArgb(CByte(200), CByte(215), CByte(225))
        txtRole.Location = New Point(25, 34)
        txtRole.Name = "txtRole"
        txtRole.Size = New Size(75, 15)
        txtRole.TabIndex = 1
        txtRole.Text = "Receptionist"
        ' 
        ' txtName
        ' 
        txtName.AutoSize = True
        txtName.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtName.ForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        txtName.Location = New Point(18, 15)
        txtName.Name = "txtName"
        txtName.Size = New Size(123, 18)
        txtName.TabIndex = 0
        txtName.Text = "Ms. Diana Dina"
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
        Label3.Font = New Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        Label3.Location = New Point(17, 14)
        Label3.Name = "Label3"
        Label3.Size = New Size(19, 20)
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
        btnReports.Font = New Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnReports.ForeColor = Color.FromArgb(CByte(182), CByte(204), CByte(210))
        btnReports.Location = New Point(3, 358)
        btnReports.MouseEnterBackColor = Color.FromArgb(CByte(39), CByte(73), CByte(87))
        btnReports.MouseEnterBorderColor = Color.FromArgb(CByte(39), CByte(73), CByte(87))
        btnReports.MouseEnterBorderSize = 0
        btnReports.MouseEnterFont = New Font("Microsoft Sans Serif", 11.9999981F)
        btnReports.MouseEnterForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnReports.MouseLeaveBackColor = Color.FromArgb(CByte(17), CByte(54), CByte(70))
        btnReports.MouseLeaveBorderColor = Color.Black
        btnReports.MouseLeaveBorderSize = 0
        btnReports.MouseLeaveFont = New Font("Microsoft Sans Serif", 11.9999981F)
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
        btnConsultation.Font = New Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnConsultation.ForeColor = Color.FromArgb(CByte(182), CByte(204), CByte(210))
        btnConsultation.Location = New Point(3, 308)
        btnConsultation.MouseEnterBackColor = Color.FromArgb(CByte(39), CByte(73), CByte(87))
        btnConsultation.MouseEnterBorderColor = Color.FromArgb(CByte(39), CByte(73), CByte(87))
        btnConsultation.MouseEnterBorderSize = 0
        btnConsultation.MouseEnterFont = New Font("Microsoft Sans Serif", 11.9999981F)
        btnConsultation.MouseEnterForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnConsultation.MouseLeaveBackColor = Color.FromArgb(CByte(17), CByte(54), CByte(70))
        btnConsultation.MouseLeaveBorderColor = Color.Black
        btnConsultation.MouseLeaveBorderSize = 0
        btnConsultation.MouseLeaveFont = New Font("Microsoft Sans Serif", 11.9999981F)
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
        btnDoctor.Font = New Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDoctor.ForeColor = Color.FromArgb(CByte(182), CByte(204), CByte(210))
        btnDoctor.Location = New Point(3, 258)
        btnDoctor.MouseEnterBackColor = Color.FromArgb(CByte(39), CByte(73), CByte(87))
        btnDoctor.MouseEnterBorderColor = Color.FromArgb(CByte(39), CByte(73), CByte(87))
        btnDoctor.MouseEnterBorderSize = 0
        btnDoctor.MouseEnterFont = New Font("Microsoft Sans Serif", 11.9999981F)
        btnDoctor.MouseEnterForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnDoctor.MouseLeaveBackColor = Color.FromArgb(CByte(17), CByte(54), CByte(70))
        btnDoctor.MouseLeaveBorderColor = Color.Black
        btnDoctor.MouseLeaveBorderSize = 0
        btnDoctor.MouseLeaveFont = New Font("Microsoft Sans Serif", 11.9999981F)
        btnDoctor.MouseLeaveForeColor = Color.FromArgb(CByte(182), CByte(204), CByte(210))
        btnDoctor.Name = "btnDoctor"
        btnDoctor.Size = New Size(171, 35)
        btnDoctor.TabIndex = 4
        btnDoctor.Text = "Doctor Schedules"
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
        btnAppointment.Font = New Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnAppointment.ForeColor = Color.FromArgb(CByte(182), CByte(204), CByte(210))
        btnAppointment.Location = New Point(3, 208)
        btnAppointment.MouseEnterBackColor = Color.FromArgb(CByte(39), CByte(73), CByte(87))
        btnAppointment.MouseEnterBorderColor = Color.FromArgb(CByte(39), CByte(73), CByte(87))
        btnAppointment.MouseEnterBorderSize = 0
        btnAppointment.MouseEnterFont = New Font("Microsoft Sans Serif", 11.9999981F)
        btnAppointment.MouseEnterForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnAppointment.MouseLeaveBackColor = Color.FromArgb(CByte(17), CByte(54), CByte(70))
        btnAppointment.MouseLeaveBorderColor = Color.Black
        btnAppointment.MouseLeaveBorderSize = 0
        btnAppointment.MouseLeaveFont = New Font("Microsoft Sans Serif", 11.9999981F)
        btnAppointment.MouseLeaveForeColor = Color.FromArgb(CByte(182), CByte(204), CByte(210))
        btnAppointment.Name = "btnAppointment"
        btnAppointment.Size = New Size(171, 35)
        btnAppointment.TabIndex = 3
        btnAppointment.Text = "Appointments"
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
        btnPatients.Font = New Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnPatients.ForeColor = Color.FromArgb(CByte(182), CByte(204), CByte(210))
        btnPatients.Location = New Point(3, 161)
        btnPatients.MouseEnterBackColor = Color.FromArgb(CByte(39), CByte(73), CByte(87))
        btnPatients.MouseEnterBorderColor = Color.FromArgb(CByte(39), CByte(73), CByte(87))
        btnPatients.MouseEnterBorderSize = 0
        btnPatients.MouseEnterFont = New Font("Microsoft Sans Serif", 11.9999981F)
        btnPatients.MouseEnterForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnPatients.MouseLeaveBackColor = Color.FromArgb(CByte(17), CByte(54), CByte(70))
        btnPatients.MouseLeaveBorderColor = Color.Black
        btnPatients.MouseLeaveBorderSize = 0
        btnPatients.MouseLeaveFont = New Font("Microsoft Sans Serif", 11.9999981F)
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
        btnDashboard.Font = New Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDashboard.ForeColor = Color.FromArgb(CByte(182), CByte(204), CByte(210))
        btnDashboard.Location = New Point(3, 108)
        btnDashboard.MouseEnterBackColor = Color.FromArgb(CByte(39), CByte(73), CByte(87))
        btnDashboard.MouseEnterBorderColor = Color.FromArgb(CByte(39), CByte(73), CByte(87))
        btnDashboard.MouseEnterBorderSize = 0
        btnDashboard.MouseEnterFont = New Font("Microsoft Sans Serif", 11.9999981F)
        btnDashboard.MouseEnterForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnDashboard.MouseLeaveBackColor = Color.FromArgb(CByte(17), CByte(54), CByte(70))
        btnDashboard.MouseLeaveBorderColor = Color.Black
        btnDashboard.MouseLeaveBorderSize = 0
        btnDashboard.MouseLeaveFont = New Font("Microsoft Sans Serif", 11.9999981F)
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
        mainScreen.Controls.Add(pnlDashboard)
        mainScreen.Controls.Add(Label5)
        mainScreen.Location = New Point(176, 0)
        mainScreen.Name = "mainScreen"
        mainScreen.Size = New Size(831, 730)
        mainScreen.TabIndex = 1
        ' 
        ' pnlDashboard
        ' 
        pnlDashboard.BackColor = Color.FromArgb(CByte(244), CByte(247), CByte(249))
        pnlDashboard.Controls.Add(lblGreeting)
        pnlDashboard.Controls.Add(lblSubtitle)
        pnlDashboard.Controls.Add(btnNewAppointment)
        pnlDashboard.Controls.Add(cardKpi1)
        pnlDashboard.Controls.Add(cardKpi2)
        pnlDashboard.Controls.Add(cardKpi3)
        pnlDashboard.Controls.Add(cardKpi4)
        pnlDashboard.Controls.Add(cardAppts)
        pnlDashboard.Controls.Add(cardQuick)
        pnlDashboard.Controls.Add(cardRecent)
        pnlDashboard.Dock = DockStyle.Fill
        pnlDashboard.Location = New Point(0, 0)
        pnlDashboard.Name = "pnlDashboard"
        pnlDashboard.Size = New Size(831, 730)
        pnlDashboard.TabIndex = 1
        ' 
        ' lblGreeting
        ' 
        lblGreeting.AutoSize = True
        lblGreeting.BackColor = Color.Transparent
        lblGreeting.Font = New Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblGreeting.ForeColor = Color.FromArgb(CByte(22), CByte(51), CByte(65))
        lblGreeting.Location = New Point(28, 20)
        lblGreeting.Name = "lblGreeting"
        lblGreeting.Size = New Size(287, 32)
        lblGreeting.TabIndex = 1
        lblGreeting.Text = "Good morning, Ms. Diana"
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.AutoSize = True
        lblSubtitle.BackColor = Color.Transparent
        lblSubtitle.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSubtitle.ForeColor = Color.FromArgb(CByte(115), CByte(138), CByte(148))
        lblSubtitle.Location = New Point(28, 54)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(289, 15)
        lblSubtitle.TabIndex = 2
        lblSubtitle.Text = "Tuesday, September 22 • Clinic operations at a glance"
        ' 
        ' btnNewAppointment
        ' 
        btnNewAppointment.BackColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        btnNewAppointment.BorderColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        btnNewAppointment.BorderRadius = 8
        btnNewAppointment.BorderSize = 0
        btnNewAppointment.Cursor = Cursors.Hand
        btnNewAppointment.FlatAppearance.BorderSize = 0
        btnNewAppointment.FlatStyle = FlatStyle.Flat
        btnNewAppointment.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnNewAppointment.ForeColor = Color.White
        btnNewAppointment.Location = New Point(656, 24)
        btnNewAppointment.MouseEnterBackColor = Color.FromArgb(CByte(23), CByte(105), CByte(90))
        btnNewAppointment.MouseEnterBorderColor = Color.FromArgb(CByte(23), CByte(105), CByte(90))
        btnNewAppointment.MouseEnterBorderSize = 0
        btnNewAppointment.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnNewAppointment.MouseEnterForeColor = Color.White
        btnNewAppointment.MouseLeaveBackColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        btnNewAppointment.MouseLeaveBorderColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        btnNewAppointment.MouseLeaveBorderSize = 0
        btnNewAppointment.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnNewAppointment.MouseLeaveForeColor = Color.White
        btnNewAppointment.Name = "btnNewAppointment"
        btnNewAppointment.Size = New Size(148, 32)
        btnNewAppointment.TabIndex = 3
        btnNewAppointment.Text = "+ New appointment"
        btnNewAppointment.UseVisualStyleBackColor = False
        ' 
        ' cardKpi1
        ' 
        cardKpi1.BackColor = Color.White
        cardKpi1.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardKpi1.BorderHoverColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        cardKpi1.BorderRadius = 12
        cardKpi1.BorderSize = 1
        cardKpi1.Controls.Add(lblCard1Context)
        cardKpi1.Controls.Add(lblCard1Value)
        cardKpi1.Controls.Add(lblCard1Title)
        cardKpi1.EnableShadow = True
        cardKpi1.HoverTintColor = Color.White
        cardKpi1.Location = New Point(28, 90)
        cardKpi1.Name = "cardKpi1"
        cardKpi1.Padding = New Padding(15)
        cardKpi1.ShadowDepth = 4
        cardKpi1.Size = New Size(184, 104)
        cardKpi1.TabIndex = 7
        ' 
        ' lblCard1Context
        ' 
        lblCard1Context.AutoSize = True
        lblCard1Context.BackColor = Color.Transparent
        lblCard1Context.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCard1Context.ForeColor = Color.FromArgb(CByte(135), CByte(148), CByte(158))
        lblCard1Context.Location = New Point(16, 80)
        lblCard1Context.Name = "lblCard1Context"
        lblCard1Context.Size = New Size(68, 13)
        lblCard1Context.TabIndex = 6
        lblCard1Context.Text = "0 remaining"
        ' 
        ' lblCard1Value
        ' 
        lblCard1Value.AutoSize = True
        lblCard1Value.BackColor = Color.Transparent
        lblCard1Value.Font = New Font("Segoe UI", 25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCard1Value.ForeColor = Color.FromArgb(CByte(22), CByte(51), CByte(65))
        lblCard1Value.Location = New Point(12, 28)
        lblCard1Value.Name = "lblCard1Value"
        lblCard1Value.Size = New Size(38, 46)
        lblCard1Value.TabIndex = 5
        lblCard1Value.Text = "0"
        ' 
        ' lblCard1Title
        ' 
        lblCard1Title.AutoSize = True
        lblCard1Title.BackColor = Color.Transparent
        lblCard1Title.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCard1Title.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblCard1Title.Location = New Point(16, 12)
        lblCard1Title.Name = "lblCard1Title"
        lblCard1Title.Size = New Size(127, 15)
        lblCard1Title.TabIndex = 4
        lblCard1Title.Text = "Today's appointments"
        ' 
        ' cardKpi2
        ' 
        cardKpi2.BackColor = Color.White
        cardKpi2.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardKpi2.BorderHoverColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        cardKpi2.BorderRadius = 12
        cardKpi2.BorderSize = 1
        cardKpi2.Controls.Add(lblCard2Context)
        cardKpi2.Controls.Add(lblCard2Value)
        cardKpi2.Controls.Add(lblCard2Title)
        cardKpi2.EnableShadow = True
        cardKpi2.HoverTintColor = Color.White
        cardKpi2.Location = New Point(225, 90)
        cardKpi2.Name = "cardKpi2"
        cardKpi2.Padding = New Padding(15)
        cardKpi2.ShadowDepth = 4
        cardKpi2.Size = New Size(184, 104)
        cardKpi2.TabIndex = 11
        ' 
        ' lblCard2Context
        ' 
        lblCard2Context.AutoSize = True
        lblCard2Context.BackColor = Color.Transparent
        lblCard2Context.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCard2Context.ForeColor = Color.FromArgb(CByte(135), CByte(148), CByte(158))
        lblCard2Context.Location = New Point(16, 80)
        lblCard2Context.Name = "lblCard2Context"
        lblCard2Context.Size = New Size(87, 13)
        lblCard2Context.TabIndex = 10
        lblCard2Context.Text = "No one waiting"
        ' 
        ' lblCard2Value
        ' 
        lblCard2Value.AutoSize = True
        lblCard2Value.BackColor = Color.Transparent
        lblCard2Value.Font = New Font("Segoe UI", 25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCard2Value.ForeColor = Color.FromArgb(CByte(22), CByte(51), CByte(65))
        lblCard2Value.Location = New Point(12, 28)
        lblCard2Value.Name = "lblCard2Value"
        lblCard2Value.Size = New Size(38, 46)
        lblCard2Value.TabIndex = 9
        lblCard2Value.Text = "0"
        ' 
        ' lblCard2Title
        ' 
        lblCard2Title.AutoSize = True
        lblCard2Title.BackColor = Color.Transparent
        lblCard2Title.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCard2Title.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblCard2Title.Location = New Point(16, 12)
        lblCard2Title.Name = "lblCard2Title"
        lblCard2Title.Size = New Size(77, 15)
        lblCard2Title.TabIndex = 8
        lblCard2Title.Text = "Waiting now"
        ' 
        ' cardKpi3
        ' 
        cardKpi3.BackColor = Color.White
        cardKpi3.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardKpi3.BorderHoverColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        cardKpi3.BorderRadius = 12
        cardKpi3.BorderSize = 1
        cardKpi3.Controls.Add(lblCard3Context)
        cardKpi3.Controls.Add(lblCard3Value)
        cardKpi3.Controls.Add(lblCard3Title)
        cardKpi3.EnableShadow = True
        cardKpi3.HoverTintColor = Color.White
        cardKpi3.Location = New Point(422, 90)
        cardKpi3.Name = "cardKpi3"
        cardKpi3.Padding = New Padding(15)
        cardKpi3.ShadowDepth = 4
        cardKpi3.Size = New Size(184, 104)
        cardKpi3.TabIndex = 15
        ' 
        ' lblCard3Context
        ' 
        lblCard3Context.AutoSize = True
        lblCard3Context.BackColor = Color.Transparent
        lblCard3Context.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCard3Context.ForeColor = Color.FromArgb(CByte(135), CByte(148), CByte(158))
        lblCard3Context.Location = New Point(16, 80)
        lblCard3Context.Name = "lblCard3Context"
        lblCard3Context.Size = New Size(68, 13)
        lblCard3Context.TabIndex = 14
        lblCard3Context.Text = "0% of today"
        ' 
        ' lblCard3Value
        ' 
        lblCard3Value.AutoSize = True
        lblCard3Value.BackColor = Color.Transparent
        lblCard3Value.Font = New Font("Segoe UI", 25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCard3Value.ForeColor = Color.FromArgb(CByte(22), CByte(51), CByte(65))
        lblCard3Value.Location = New Point(12, 28)
        lblCard3Value.Name = "lblCard3Value"
        lblCard3Value.Size = New Size(38, 46)
        lblCard3Value.TabIndex = 13
        lblCard3Value.Text = "0"
        ' 
        ' lblCard3Title
        ' 
        lblCard3Title.AutoSize = True
        lblCard3Title.BackColor = Color.Transparent
        lblCard3Title.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCard3Title.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblCard3Title.Location = New Point(16, 12)
        lblCard3Title.Name = "lblCard3Title"
        lblCard3Title.Size = New Size(68, 15)
        lblCard3Title.TabIndex = 12
        lblCard3Title.Text = "Completed"
        ' 
        ' cardKpi4
        ' 
        cardKpi4.BackColor = Color.White
        cardKpi4.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardKpi4.BorderHoverColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        cardKpi4.BorderRadius = 12
        cardKpi4.BorderSize = 1
        cardKpi4.Controls.Add(lblCard4Context)
        cardKpi4.Controls.Add(lblCard4Value)
        cardKpi4.Controls.Add(lblCard4Title)
        cardKpi4.EnableShadow = True
        cardKpi4.HoverTintColor = Color.White
        cardKpi4.Location = New Point(619, 90)
        cardKpi4.Name = "cardKpi4"
        cardKpi4.Padding = New Padding(15)
        cardKpi4.ShadowDepth = 4
        cardKpi4.Size = New Size(184, 104)
        cardKpi4.TabIndex = 19
        ' 
        ' lblCard4Context
        ' 
        lblCard4Context.AutoSize = True
        lblCard4Context.BackColor = Color.Transparent
        lblCard4Context.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCard4Context.ForeColor = Color.FromArgb(CByte(135), CByte(148), CByte(158))
        lblCard4Context.Location = New Point(16, 80)
        lblCard4Context.Name = "lblCard4Context"
        lblCard4Context.Size = New Size(79, 13)
        lblCard4Context.TabIndex = 18
        lblCard4Context.Text = "0 rescheduled"
        ' 
        ' lblCard4Value
        ' 
        lblCard4Value.AutoSize = True
        lblCard4Value.BackColor = Color.Transparent
        lblCard4Value.Font = New Font("Segoe UI", 25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCard4Value.ForeColor = Color.FromArgb(CByte(205), CByte(80), CByte(75))
        lblCard4Value.Location = New Point(12, 28)
        lblCard4Value.Name = "lblCard4Value"
        lblCard4Value.Size = New Size(38, 46)
        lblCard4Value.TabIndex = 17
        lblCard4Value.Text = "0"
        ' 
        ' lblCard4Title
        ' 
        lblCard4Title.AutoSize = True
        lblCard4Title.BackColor = Color.Transparent
        lblCard4Title.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCard4Title.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblCard4Title.Location = New Point(16, 12)
        lblCard4Title.Name = "lblCard4Title"
        lblCard4Title.Size = New Size(60, 15)
        lblCard4Title.TabIndex = 16
        lblCard4Title.Text = "Cancelled"
        ' 
        ' cardAppts
        ' 
        cardAppts.BackColor = Color.White
        cardAppts.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardAppts.BorderHoverColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        cardAppts.BorderRadius = 12
        cardAppts.BorderSize = 1
        cardAppts.Controls.Add(lblApptsHeader)
        cardAppts.Controls.Add(lblEmpty)
        cardAppts.Controls.Add(lblRow1Time)
        cardAppts.Controls.Add(lblRow1Patient)
        cardAppts.Controls.Add(lblRow1Type)
        cardAppts.Controls.Add(lblRow1Doctor)
        cardAppts.Controls.Add(btnRow1Status)
        cardAppts.Controls.Add(pnlRow1Divider)
        cardAppts.Controls.Add(lblRow2Time)
        cardAppts.Controls.Add(lblRow2Patient)
        cardAppts.Controls.Add(lblRow2Type)
        cardAppts.Controls.Add(lblRow2Doctor)
        cardAppts.Controls.Add(btnRow2Status)
        cardAppts.Controls.Add(pnlRow2Divider)
        cardAppts.Controls.Add(lblRow3Time)
        cardAppts.Controls.Add(lblRow3Patient)
        cardAppts.Controls.Add(lblRow3Type)
        cardAppts.Controls.Add(lblRow3Doctor)
        cardAppts.Controls.Add(btnRow3Status)
        cardAppts.Controls.Add(pnlRow3Divider)
        cardAppts.Controls.Add(lblRow4Time)
        cardAppts.Controls.Add(lblRow4Patient)
        cardAppts.Controls.Add(lblRow4Type)
        cardAppts.Controls.Add(lblRow4Doctor)
        cardAppts.Controls.Add(btnRow4Status)
        cardAppts.Controls.Add(pnlRow4Divider)
        cardAppts.EnableShadow = True
        cardAppts.HoverTintColor = Color.White
        cardAppts.Location = New Point(28, 210)
        cardAppts.Name = "cardAppts"
        cardAppts.Padding = New Padding(15)
        cardAppts.ShadowDepth = 4
        cardAppts.Size = New Size(540, 236)
        cardAppts.TabIndex = 42
        ' 
        ' lblApptsHeader
        ' 
        lblApptsHeader.AutoSize = True
        lblApptsHeader.BackColor = Color.Transparent
        lblApptsHeader.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblApptsHeader.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblApptsHeader.Location = New Point(16, 14)
        lblApptsHeader.Name = "lblApptsHeader"
        lblApptsHeader.Size = New Size(155, 19)
        lblApptsHeader.TabIndex = 20
        lblApptsHeader.Text = "Today's appointments"
        ' 
        ' lblEmpty
        ' 
        lblEmpty.AutoSize = True
        lblEmpty.BackColor = Color.Transparent
        lblEmpty.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblEmpty.ForeColor = Color.FromArgb(CByte(140), CByte(155), CByte(165))
        lblEmpty.Location = New Point(16, 100)
        lblEmpty.Name = "lblEmpty"
        lblEmpty.Size = New Size(234, 17)
        lblEmpty.TabIndex = 21
        lblEmpty.Text = "No appointments scheduled for today."
        lblEmpty.Visible = False
        ' 
        ' lblRow1Time
        ' 
        lblRow1Time.AutoSize = True
        lblRow1Time.BackColor = Color.Transparent
        lblRow1Time.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRow1Time.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblRow1Time.Location = New Point(16, 62)
        lblRow1Time.Name = "lblRow1Time"
        lblRow1Time.Size = New Size(53, 15)
        lblRow1Time.TabIndex = 22
        lblRow1Time.Text = "9:00 AM"
        ' 
        ' lblRow1Patient
        ' 
        lblRow1Patient.AutoSize = True
        lblRow1Patient.BackColor = Color.Transparent
        lblRow1Patient.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow1Patient.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblRow1Patient.Location = New Point(120, 62)
        lblRow1Patient.Name = "lblRow1Patient"
        lblRow1Patient.Size = New Size(75, 15)
        lblRow1Patient.TabIndex = 23
        lblRow1Patient.Text = "Maria Santos"
        ' 
        ' lblRow1Type
        ' 
        lblRow1Type.AutoSize = True
        lblRow1Type.BackColor = Color.Transparent
        lblRow1Type.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow1Type.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblRow1Type.Location = New Point(268, 63)
        lblRow1Type.Name = "lblRow1Type"
        lblRow1Type.Size = New Size(61, 15)
        lblRow1Type.TabIndex = 24
        lblRow1Type.Text = "Follow-up"
        ' 
        ' lblRow1Doctor
        ' 
        lblRow1Doctor.BackColor = Color.Transparent
        lblRow1Doctor.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow1Doctor.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblRow1Doctor.Location = New Point(358, 63)
        lblRow1Doctor.Name = "lblRow1Doctor"
        lblRow1Doctor.Size = New Size(85, 16)
        lblRow1Doctor.TabIndex = 25
        lblRow1Doctor.Text = "Dr. Cruz"
        lblRow1Doctor.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnRow1Status
        ' 
        btnRow1Status.BackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnRow1Status.BorderColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnRow1Status.BorderRadius = 10
        btnRow1Status.BorderSize = 0
        btnRow1Status.FlatAppearance.BorderSize = 0
        btnRow1Status.FlatStyle = FlatStyle.Flat
        btnRow1Status.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRow1Status.ForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        btnRow1Status.Location = New Point(448, 59)
        btnRow1Status.MouseEnterBackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnRow1Status.MouseEnterBorderColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnRow1Status.MouseEnterBorderSize = 0
        btnRow1Status.MouseEnterFont = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRow1Status.MouseEnterForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        btnRow1Status.MouseLeaveBackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnRow1Status.MouseLeaveBorderColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnRow1Status.MouseLeaveBorderSize = 0
        btnRow1Status.MouseLeaveFont = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRow1Status.MouseLeaveForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        btnRow1Status.Name = "btnRow1Status"
        btnRow1Status.Size = New Size(76, 22)
        btnRow1Status.TabIndex = 26
        btnRow1Status.TabStop = False
        btnRow1Status.Text = "Completed"
        btnRow1Status.UseVisualStyleBackColor = False
        ' 
        ' pnlRow1Divider
        ' 
        pnlRow1Divider.BackColor = Color.FromArgb(CByte(242), CByte(244), CByte(247))
        pnlRow1Divider.Location = New Point(16, 91)
        pnlRow1Divider.Name = "pnlRow1Divider"
        pnlRow1Divider.Size = New Size(508, 1)
        pnlRow1Divider.TabIndex = 26
        ' 
        ' lblRow2Time
        ' 
        lblRow2Time.AutoSize = True
        lblRow2Time.BackColor = Color.Transparent
        lblRow2Time.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRow2Time.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblRow2Time.Location = New Point(16, 106)
        lblRow2Time.Name = "lblRow2Time"
        lblRow2Time.Size = New Size(60, 15)
        lblRow2Time.TabIndex = 27
        lblRow2Time.Text = "10:30 AM"
        ' 
        ' lblRow2Patient
        ' 
        lblRow2Patient.AutoSize = True
        lblRow2Patient.BackColor = Color.Transparent
        lblRow2Patient.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow2Patient.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblRow2Patient.Location = New Point(120, 106)
        lblRow2Patient.Name = "lblRow2Patient"
        lblRow2Patient.Size = New Size(76, 15)
        lblRow2Patient.TabIndex = 28
        lblRow2Patient.Text = "Joshua Reyes"
        ' 
        ' lblRow2Type
        ' 
        lblRow2Type.AutoSize = True
        lblRow2Type.BackColor = Color.Transparent
        lblRow2Type.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow2Type.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblRow2Type.Location = New Point(268, 107)
        lblRow2Type.Name = "lblRow2Type"
        lblRow2Type.Size = New Size(75, 15)
        lblRow2Type.TabIndex = 29
        lblRow2Type.Text = "Consultation"
        ' 
        ' lblRow2Doctor
        ' 
        lblRow2Doctor.BackColor = Color.Transparent
        lblRow2Doctor.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow2Doctor.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblRow2Doctor.Location = New Point(358, 107)
        lblRow2Doctor.Name = "lblRow2Doctor"
        lblRow2Doctor.Size = New Size(85, 16)
        lblRow2Doctor.TabIndex = 30
        lblRow2Doctor.Text = "Dr. Cruz"
        lblRow2Doctor.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnRow2Status
        ' 
        btnRow2Status.BackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnRow2Status.BorderColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnRow2Status.BorderRadius = 10
        btnRow2Status.BorderSize = 0
        btnRow2Status.FlatAppearance.BorderSize = 0
        btnRow2Status.FlatStyle = FlatStyle.Flat
        btnRow2Status.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRow2Status.ForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        btnRow2Status.Location = New Point(448, 103)
        btnRow2Status.MouseEnterBackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnRow2Status.MouseEnterBorderColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnRow2Status.MouseEnterBorderSize = 0
        btnRow2Status.MouseEnterFont = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRow2Status.MouseEnterForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        btnRow2Status.MouseLeaveBackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnRow2Status.MouseLeaveBorderColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnRow2Status.MouseLeaveBorderSize = 0
        btnRow2Status.MouseLeaveFont = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRow2Status.MouseLeaveForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        btnRow2Status.Name = "btnRow2Status"
        btnRow2Status.Size = New Size(76, 22)
        btnRow2Status.TabIndex = 31
        btnRow2Status.TabStop = False
        btnRow2Status.Text = "Pending"
        btnRow2Status.UseVisualStyleBackColor = False
        ' 
        ' pnlRow2Divider
        ' 
        pnlRow2Divider.BackColor = Color.FromArgb(CByte(242), CByte(244), CByte(247))
        pnlRow2Divider.Location = New Point(16, 135)
        pnlRow2Divider.Name = "pnlRow2Divider"
        pnlRow2Divider.Size = New Size(508, 1)
        pnlRow2Divider.TabIndex = 31
        ' 
        ' lblRow3Time
        ' 
        lblRow3Time.AutoSize = True
        lblRow3Time.BackColor = Color.Transparent
        lblRow3Time.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRow3Time.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblRow3Time.Location = New Point(16, 150)
        lblRow3Time.Name = "lblRow3Time"
        lblRow3Time.Size = New Size(52, 15)
        lblRow3Time.TabIndex = 32
        lblRow3Time.Text = "1:00 PM"
        ' 
        ' lblRow3Patient
        ' 
        lblRow3Patient.AutoSize = True
        lblRow3Patient.BackColor = Color.Transparent
        lblRow3Patient.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow3Patient.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblRow3Patient.Location = New Point(120, 150)
        lblRow3Patient.Name = "lblRow3Patient"
        lblRow3Patient.Size = New Size(85, 15)
        lblRow3Patient.TabIndex = 33
        lblRow3Patient.Text = "Ana Villanueva"
        ' 
        ' lblRow3Type
        ' 
        lblRow3Type.AutoSize = True
        lblRow3Type.BackColor = Color.Transparent
        lblRow3Type.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow3Type.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblRow3Type.Location = New Point(268, 151)
        lblRow3Type.Name = "lblRow3Type"
        lblRow3Type.Size = New Size(59, 15)
        lblRow3Type.TabIndex = 34
        lblRow3Type.Text = "Check-up"
        ' 
        ' lblRow3Doctor
        ' 
        lblRow3Doctor.BackColor = Color.Transparent
        lblRow3Doctor.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow3Doctor.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblRow3Doctor.Location = New Point(358, 151)
        lblRow3Doctor.Name = "lblRow3Doctor"
        lblRow3Doctor.Size = New Size(85, 16)
        lblRow3Doctor.TabIndex = 35
        lblRow3Doctor.Text = "Dr. Lim"
        lblRow3Doctor.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnRow3Status
        ' 
        btnRow3Status.BackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnRow3Status.BorderColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnRow3Status.BorderRadius = 10
        btnRow3Status.BorderSize = 0
        btnRow3Status.FlatAppearance.BorderSize = 0
        btnRow3Status.FlatStyle = FlatStyle.Flat
        btnRow3Status.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRow3Status.ForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        btnRow3Status.Location = New Point(448, 147)
        btnRow3Status.MouseEnterBackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnRow3Status.MouseEnterBorderColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnRow3Status.MouseEnterBorderSize = 0
        btnRow3Status.MouseEnterFont = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRow3Status.MouseEnterForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        btnRow3Status.MouseLeaveBackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnRow3Status.MouseLeaveBorderColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnRow3Status.MouseLeaveBorderSize = 0
        btnRow3Status.MouseLeaveFont = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRow3Status.MouseLeaveForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        btnRow3Status.Name = "btnRow3Status"
        btnRow3Status.Size = New Size(76, 22)
        btnRow3Status.TabIndex = 36
        btnRow3Status.TabStop = False
        btnRow3Status.Text = "Confirmed"
        btnRow3Status.UseVisualStyleBackColor = False
        ' 
        ' pnlRow3Divider
        ' 
        pnlRow3Divider.BackColor = Color.FromArgb(CByte(242), CByte(244), CByte(247))
        pnlRow3Divider.Location = New Point(16, 179)
        pnlRow3Divider.Name = "pnlRow3Divider"
        pnlRow3Divider.Size = New Size(508, 1)
        pnlRow3Divider.TabIndex = 36
        ' 
        ' lblRow4Time
        ' 
        lblRow4Time.AutoSize = True
        lblRow4Time.BackColor = Color.Transparent
        lblRow4Time.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRow4Time.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblRow4Time.Location = New Point(16, 194)
        lblRow4Time.Name = "lblRow4Time"
        lblRow4Time.Size = New Size(52, 15)
        lblRow4Time.TabIndex = 37
        lblRow4Time.Text = "3:30 PM"
        ' 
        ' lblRow4Patient
        ' 
        lblRow4Patient.AutoSize = True
        lblRow4Patient.BackColor = Color.Transparent
        lblRow4Patient.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow4Patient.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblRow4Patient.Location = New Point(120, 194)
        lblRow4Patient.Name = "lblRow4Patient"
        lblRow4Patient.Size = New Size(74, 15)
        lblRow4Patient.TabIndex = 38
        lblRow4Patient.Text = "Roberto Diaz"
        ' 
        ' lblRow4Type
        ' 
        lblRow4Type.AutoSize = True
        lblRow4Type.BackColor = Color.Transparent
        lblRow4Type.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow4Type.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblRow4Type.Location = New Point(268, 195)
        lblRow4Type.Name = "lblRow4Type"
        lblRow4Type.Size = New Size(61, 15)
        lblRow4Type.TabIndex = 39
        lblRow4Type.Text = "Follow-up"
        ' 
        ' lblRow4Doctor
        ' 
        lblRow4Doctor.BackColor = Color.Transparent
        lblRow4Doctor.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow4Doctor.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblRow4Doctor.Location = New Point(358, 195)
        lblRow4Doctor.Name = "lblRow4Doctor"
        lblRow4Doctor.Size = New Size(85, 16)
        lblRow4Doctor.TabIndex = 40
        lblRow4Doctor.Text = "Dr. Cruz"
        lblRow4Doctor.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnRow4Status
        ' 
        btnRow4Status.BackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnRow4Status.BorderColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnRow4Status.BorderRadius = 10
        btnRow4Status.BorderSize = 0
        btnRow4Status.FlatAppearance.BorderSize = 0
        btnRow4Status.FlatStyle = FlatStyle.Flat
        btnRow4Status.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRow4Status.ForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        btnRow4Status.Location = New Point(448, 191)
        btnRow4Status.MouseEnterBackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnRow4Status.MouseEnterBorderColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnRow4Status.MouseEnterBorderSize = 0
        btnRow4Status.MouseEnterFont = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRow4Status.MouseEnterForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        btnRow4Status.MouseLeaveBackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnRow4Status.MouseLeaveBorderColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        btnRow4Status.MouseLeaveBorderSize = 0
        btnRow4Status.MouseLeaveFont = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRow4Status.MouseLeaveForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        btnRow4Status.Name = "btnRow4Status"
        btnRow4Status.Size = New Size(76, 22)
        btnRow4Status.TabIndex = 41
        btnRow4Status.TabStop = False
        btnRow4Status.Text = "Cancelled"
        btnRow4Status.UseVisualStyleBackColor = False
        ' 
        ' pnlRow4Divider
        ' 
        pnlRow4Divider.BackColor = Color.FromArgb(CByte(242), CByte(244), CByte(247))
        pnlRow4Divider.Location = New Point(16, 223)
        pnlRow4Divider.Name = "pnlRow4Divider"
        pnlRow4Divider.Size = New Size(508, 1)
        pnlRow4Divider.TabIndex = 41
        ' 
        ' cardQuick
        ' 
        cardQuick.BackColor = Color.White
        cardQuick.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardQuick.BorderHoverColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        cardQuick.BorderRadius = 12
        cardQuick.BorderSize = 1
        cardQuick.Controls.Add(lblQuickTitle)
        cardQuick.Controls.Add(btnRegisterPatient)
        cardQuick.Controls.Add(btnOpenConsultation)
        cardQuick.EnableShadow = True
        cardQuick.HoverTintColor = Color.White
        cardQuick.Location = New Point(584, 210)
        cardQuick.Name = "cardQuick"
        cardQuick.Padding = New Padding(15)
        cardQuick.ShadowDepth = 4
        cardQuick.Size = New Size(220, 142)
        cardQuick.TabIndex = 47
        ' 
        ' lblQuickTitle
        ' 
        lblQuickTitle.AutoSize = True
        lblQuickTitle.BackColor = Color.Transparent
        lblQuickTitle.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblQuickTitle.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblQuickTitle.Location = New Point(16, 14)
        lblQuickTitle.Name = "lblQuickTitle"
        lblQuickTitle.Size = New Size(98, 19)
        lblQuickTitle.TabIndex = 43
        lblQuickTitle.Text = "Quick actions"
        ' 
        ' btnRegisterPatient
        ' 
        btnRegisterPatient.BackColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        btnRegisterPatient.BorderColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        btnRegisterPatient.BorderRadius = 8
        btnRegisterPatient.BorderSize = 0
        btnRegisterPatient.Cursor = Cursors.Hand
        btnRegisterPatient.FlatAppearance.BorderSize = 0
        btnRegisterPatient.FlatStyle = FlatStyle.Flat
        btnRegisterPatient.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRegisterPatient.ForeColor = Color.White
        btnRegisterPatient.Location = New Point(16, 46)
        btnRegisterPatient.MouseEnterBackColor = Color.FromArgb(CByte(23), CByte(105), CByte(90))
        btnRegisterPatient.MouseEnterBorderColor = Color.FromArgb(CByte(23), CByte(105), CByte(90))
        btnRegisterPatient.MouseEnterBorderSize = 0
        btnRegisterPatient.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRegisterPatient.MouseEnterForeColor = Color.White
        btnRegisterPatient.MouseLeaveBackColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        btnRegisterPatient.MouseLeaveBorderColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        btnRegisterPatient.MouseLeaveBorderSize = 0
        btnRegisterPatient.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRegisterPatient.MouseLeaveForeColor = Color.White
        btnRegisterPatient.Name = "btnRegisterPatient"
        btnRegisterPatient.Size = New Size(188, 30)
        btnRegisterPatient.TabIndex = 44
        btnRegisterPatient.Text = "Register patient"
        btnRegisterPatient.UseVisualStyleBackColor = False
        ' 
        ' btnOpenConsultation
        ' 
        btnOpenConsultation.BackColor = Color.White
        btnOpenConsultation.BorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnOpenConsultation.BorderRadius = 8
        btnOpenConsultation.BorderSize = 1
        btnOpenConsultation.Cursor = Cursors.Hand
        btnOpenConsultation.FlatAppearance.BorderSize = 0
        btnOpenConsultation.FlatStyle = FlatStyle.Flat
        btnOpenConsultation.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnOpenConsultation.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnOpenConsultation.Location = New Point(16, 92)
        btnOpenConsultation.MouseEnterBackColor = Color.FromArgb(CByte(245), CByte(249), CByte(251))
        btnOpenConsultation.MouseEnterBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnOpenConsultation.MouseEnterBorderSize = 1
        btnOpenConsultation.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnOpenConsultation.MouseEnterForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnOpenConsultation.MouseLeaveBackColor = Color.White
        btnOpenConsultation.MouseLeaveBorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnOpenConsultation.MouseLeaveBorderSize = 1
        btnOpenConsultation.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnOpenConsultation.MouseLeaveForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnOpenConsultation.Name = "btnOpenConsultation"
        btnOpenConsultation.Size = New Size(188, 32)
        btnOpenConsultation.TabIndex = 46
        btnOpenConsultation.Text = "Consultation Log"
        btnOpenConsultation.UseVisualStyleBackColor = False
        ' 
        ' cardRecent
        ' 
        cardRecent.BackColor = Color.White
        cardRecent.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardRecent.BorderHoverColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        cardRecent.BorderRadius = 12
        cardRecent.BorderSize = 1
        cardRecent.Controls.Add(lblRecentTitle)
        cardRecent.Controls.Add(lblRecent1)
        cardRecent.Controls.Add(lblRecent2)
        cardRecent.Controls.Add(lblRecent3)
        cardRecent.EnableShadow = True
        cardRecent.HoverTintColor = Color.White
        cardRecent.Location = New Point(584, 386)
        cardRecent.Name = "cardRecent"
        cardRecent.Padding = New Padding(15)
        cardRecent.ShadowDepth = 4
        cardRecent.Size = New Size(220, 120)
        cardRecent.TabIndex = 52
        ' 
        ' lblRecentTitle
        ' 
        lblRecentTitle.AutoSize = True
        lblRecentTitle.BackColor = Color.Transparent
        lblRecentTitle.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRecentTitle.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblRecentTitle.Location = New Point(16, 14)
        lblRecentTitle.Name = "lblRecentTitle"
        lblRecentTitle.Size = New Size(111, 19)
        lblRecentTitle.TabIndex = 48
        lblRecentTitle.Text = "Recent patients"
        ' 
        ' lblRecent1
        ' 
        lblRecent1.AutoSize = True
        lblRecent1.BackColor = Color.Transparent
        lblRecent1.Font = New Font("Segoe UI", 8.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRecent1.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        lblRecent1.Location = New Point(16, 44)
        lblRecent1.Name = "lblRecent1"
        lblRecent1.Size = New Size(129, 15)
        lblRecent1.TabIndex = 49
        lblRecent1.Text = "Maria Santos • PT-1048"
        ' 
        ' lblRecent2
        ' 
        lblRecent2.AutoSize = True
        lblRecent2.BackColor = Color.Transparent
        lblRecent2.Font = New Font("Segoe UI", 8.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRecent2.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        lblRecent2.Location = New Point(16, 68)
        lblRecent2.Name = "lblRecent2"
        lblRecent2.Size = New Size(130, 15)
        lblRecent2.TabIndex = 50
        lblRecent2.Text = "Joshua Reyes • PT-1051"
        ' 
        ' lblRecent3
        ' 
        lblRecent3.AutoSize = True
        lblRecent3.BackColor = Color.Transparent
        lblRecent3.Font = New Font("Segoe UI", 8.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRecent3.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        lblRecent3.Location = New Point(16, 92)
        lblRecent3.Name = "lblRecent3"
        lblRecent3.Size = New Size(139, 15)
        lblRecent3.TabIndex = 51
        lblRecent3.Text = "Ana Villanueva • PT-1026"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(346, 302)
        Label5.Name = "Label5"
        Label5.Size = New Size(118, 15)
        Label5.TabIndex = 0
        Label5.Text = "Dito mag lalagay yah"
        Label5.Visible = False
        ' 
        ' btnScheduleAppt
        ' 
        btnScheduleAppt.BackColor = Color.White
        btnScheduleAppt.BorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnScheduleAppt.BorderRadius = 8
        btnScheduleAppt.BorderSize = 1
        btnScheduleAppt.Cursor = Cursors.Hand
        btnScheduleAppt.FlatAppearance.BorderSize = 0
        btnScheduleAppt.FlatStyle = FlatStyle.Flat
        btnScheduleAppt.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnScheduleAppt.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnScheduleAppt.Location = New Point(16, 84)
        btnScheduleAppt.MouseEnterBackColor = Color.FromArgb(CByte(245), CByte(249), CByte(251))
        btnScheduleAppt.MouseEnterBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnScheduleAppt.MouseEnterBorderSize = 1
        btnScheduleAppt.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnScheduleAppt.MouseEnterForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnScheduleAppt.MouseLeaveBackColor = Color.White
        btnScheduleAppt.MouseLeaveBorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnScheduleAppt.MouseLeaveBorderSize = 1
        btnScheduleAppt.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnScheduleAppt.MouseLeaveForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnScheduleAppt.Name = "btnScheduleAppt"
        btnScheduleAppt.Size = New Size(188, 30)
        btnScheduleAppt.TabIndex = 45
        btnScheduleAppt.Text = "Schedule appointment"
        btnScheduleAppt.UseVisualStyleBackColor = False
        ' 
        ' ReceptionistDashboard
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1008, 705)
        Controls.Add(mainScreen)
        Controls.Add(sideBar)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "ReceptionistDashboard"
        StartPosition = FormStartPosition.CenterScreen
        Text = " "
        sideBar.ResumeLayout(False)
        sideBar.PerformLayout()
        namePlaceHolder.ResumeLayout(False)
        namePlaceHolder.PerformLayout()
        FCard1.ResumeLayout(False)
        FCard1.PerformLayout()
        mainScreen.ResumeLayout(False)
        mainScreen.PerformLayout()
        pnlDashboard.ResumeLayout(False)
        pnlDashboard.PerformLayout()
        cardKpi1.ResumeLayout(False)
        cardKpi1.PerformLayout()
        cardKpi2.ResumeLayout(False)
        cardKpi2.PerformLayout()
        cardKpi3.ResumeLayout(False)
        cardKpi3.PerformLayout()
        cardKpi4.ResumeLayout(False)
        cardKpi4.PerformLayout()
        cardAppts.ResumeLayout(False)
        cardAppts.PerformLayout()
        cardQuick.ResumeLayout(False)
        cardQuick.PerformLayout()
        cardRecent.ResumeLayout(False)
        cardRecent.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents sideBar As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents mainScreen As Panel
    Friend WithEvents Label5 As Label
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

    ' ---- Dashboard panel controls
    Friend WithEvents lblGreeting As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents btnNewAppointment As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents lblCard1Title As Label
    Friend WithEvents lblCard1Value As Label
    Friend WithEvents lblCard1Context As Label
    Friend WithEvents cardKpi1 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblCard2Title As Label
    Friend WithEvents lblCard2Value As Label
    Friend WithEvents lblCard2Context As Label
    Friend WithEvents cardKpi2 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblCard3Title As Label
    Friend WithEvents lblCard3Value As Label
    Friend WithEvents lblCard3Context As Label
    Friend WithEvents cardKpi3 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblCard4Title As Label
    Friend WithEvents lblCard4Value As Label
    Friend WithEvents lblCard4Context As Label
    Friend WithEvents cardKpi4 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblApptsHeader As Label
    Friend WithEvents lblEmpty As Label
    Friend WithEvents lblRow1Time As Label
    Friend WithEvents lblRow1Patient As Label
    Friend WithEvents lblRow1Type As Label
    Friend WithEvents lblRow1Doctor As Label
    Friend WithEvents btnRow1Status As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents pnlRow1Divider As Panel
    Friend WithEvents lblRow2Time As Label
    Friend WithEvents lblRow2Patient As Label
    Friend WithEvents lblRow2Type As Label
    Friend WithEvents lblRow2Doctor As Label
    Friend WithEvents btnRow2Status As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents pnlRow2Divider As Panel
    Friend WithEvents lblRow3Time As Label
    Friend WithEvents lblRow3Patient As Label
    Friend WithEvents lblRow3Type As Label
    Friend WithEvents lblRow3Doctor As Label
    Friend WithEvents btnRow3Status As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents pnlRow3Divider As Panel
    Friend WithEvents lblRow4Time As Label
    Friend WithEvents lblRow4Patient As Label
    Friend WithEvents lblRow4Type As Label
    Friend WithEvents lblRow4Doctor As Label
    Friend WithEvents btnRow4Status As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents pnlRow4Divider As Panel
    Friend WithEvents cardAppts As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblQuickTitle As Label
    Friend WithEvents btnRegisterPatient As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnScheduleAppt As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnOpenConsultation As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents cardQuick As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblRecentTitle As Label
    Friend WithEvents lblRecent1 As Label
    Friend WithEvents lblRecent2 As Label
    Friend WithEvents lblRecent3 As Label
    Friend WithEvents cardRecent As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents pnlDashboard As Panel
    Friend WithEvents btnLogout As Ferrando.UI.WinForms.Controles.FButton

End Class