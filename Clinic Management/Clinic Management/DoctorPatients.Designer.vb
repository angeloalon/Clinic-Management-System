Imports FontAwesome.Sharp
Imports Ferrando.UI.WinForms.Controles

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DoctorPatients
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
        cardPatientsTable = New FCard()
        pnlRowsContainer = New Panel()
        dividerHeader = New Panel()
        lblColLastVisit = New Label()
        lblColContact = New Label()
        lblColAgeSex = New Label()
        lblColPatientId = New Label()
        lblColPatient = New Label()
        lblCardTitle = New Label()
        btnFilterVisit = New FButton()
        btnFilterAll = New FButton()
        cardSearch = New FCard()
        txtSearch = New TextBox()
        lblSearchIcon = New Label()
        lblClearSearch = New Label()
        lblPatientCount = New Label()
        lblHeaderSubtitle = New Label()
        lblHeaderTitle = New Label()
        sideBar.SuspendLayout()
        namePlaceHolder.SuspendLayout()
        FCard1.SuspendLayout()
        mainScreen.SuspendLayout()
        cardPatientsTable.SuspendLayout()
        cardSearch.SuspendLayout()
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
        mainScreen.Controls.Add(cardPatientsTable)
        mainScreen.Controls.Add(btnFilterVisit)
        mainScreen.Controls.Add(btnFilterAll)
        mainScreen.Controls.Add(cardSearch)
        mainScreen.Controls.Add(lblHeaderSubtitle)
        mainScreen.Controls.Add(lblHeaderTitle)
        mainScreen.Location = New Point(176, 0)
        mainScreen.Name = "mainScreen"
        mainScreen.Size = New Size(832, 730)
        mainScreen.TabIndex = 1
        ' 
        ' cardPatientsTable
        ' 
        cardPatientsTable.BackColor = Color.White
        cardPatientsTable.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardPatientsTable.BorderHoverColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        cardPatientsTable.BorderRadius = 12
        cardPatientsTable.BorderSize = 1
        cardPatientsTable.Controls.Add(lblPatientCount)
        cardPatientsTable.Controls.Add(pnlRowsContainer)
        cardPatientsTable.Controls.Add(dividerHeader)
        cardPatientsTable.Controls.Add(lblColLastVisit)
        cardPatientsTable.Controls.Add(lblColContact)
        cardPatientsTable.Controls.Add(lblColAgeSex)
        cardPatientsTable.Controls.Add(lblColPatientId)
        cardPatientsTable.Controls.Add(lblColPatient)
        cardPatientsTable.Controls.Add(lblCardTitle)
        cardPatientsTable.EnableShadow = True
        cardPatientsTable.HoverTintColor = Color.White
        cardPatientsTable.Location = New Point(28, 138)
        cardPatientsTable.Name = "cardPatientsTable"
        cardPatientsTable.Padding = New Padding(16)
        cardPatientsTable.ShadowDepth = 4
        cardPatientsTable.Size = New Size(770, 320)
        cardPatientsTable.TabIndex = 5
        ' 
        ' pnlRowsContainer
        ' 
        pnlRowsContainer.BackColor = Color.White
        pnlRowsContainer.Location = New Point(16, 84)
        pnlRowsContainer.Name = "pnlRowsContainer"
        pnlRowsContainer.Size = New Size(738, 220)
        pnlRowsContainer.TabIndex = 7
        ' 
        ' dividerHeader
        ' 
        dividerHeader.BackColor = Color.FromArgb(CByte(242), CByte(244), CByte(247))
        dividerHeader.Location = New Point(20, 78)
        dividerHeader.Name = "dividerHeader"
        dividerHeader.Size = New Size(730, 1)
        dividerHeader.TabIndex = 6
        ' 
        ' lblColLastVisit
        ' 
        lblColLastVisit.AutoSize = True
        lblColLastVisit.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblColLastVisit.ForeColor = Color.FromArgb(CByte(120), CByte(135), CByte(145))
        lblColLastVisit.Location = New Point(630, 54)
        lblColLastVisit.Name = "lblColLastVisit"
        lblColLastVisit.Size = New Size(52, 15)
        lblColLastVisit.TabIndex = 5
        lblColLastVisit.Text = "Last visit"
        ' 
        ' lblColContact
        ' 
        lblColContact.AutoSize = True
        lblColContact.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblColContact.ForeColor = Color.FromArgb(CByte(120), CByte(135), CByte(145))
        lblColContact.Location = New Point(480, 54)
        lblColContact.Name = "lblColContact"
        lblColContact.Size = New Size(49, 15)
        lblColContact.TabIndex = 4
        lblColContact.Text = "Contact"
        ' 
        ' lblColAgeSex
        ' 
        lblColAgeSex.AutoSize = True
        lblColAgeSex.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblColAgeSex.ForeColor = Color.FromArgb(CByte(120), CByte(135), CByte(145))
        lblColAgeSex.Location = New Point(330, 54)
        lblColAgeSex.Name = "lblColAgeSex"
        lblColAgeSex.Size = New Size(58, 15)
        lblColAgeSex.TabIndex = 3
        lblColAgeSex.Text = "Age / sex"
        ' 
        ' lblColPatientId
        ' 
        lblColPatientId.AutoSize = True
        lblColPatientId.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblColPatientId.ForeColor = Color.FromArgb(CByte(120), CByte(135), CByte(145))
        lblColPatientId.Location = New Point(180, 54)
        lblColPatientId.Name = "lblColPatientId"
        lblColPatientId.Size = New Size(58, 15)
        lblColPatientId.TabIndex = 2
        lblColPatientId.Text = "Patient ID"
        ' 
        ' lblColPatient
        ' 
        lblColPatient.AutoSize = True
        lblColPatient.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblColPatient.ForeColor = Color.FromArgb(CByte(120), CByte(135), CByte(145))
        lblColPatient.Location = New Point(20, 54)
        lblColPatient.Name = "lblColPatient"
        lblColPatient.Size = New Size(44, 15)
        lblColPatient.TabIndex = 1
        lblColPatient.Text = "Patient"
        ' 
        ' lblCardTitle
        ' 
        lblCardTitle.AutoSize = True
        lblCardTitle.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCardTitle.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblCardTitle.Location = New Point(20, 18)
        lblCardTitle.Name = "lblCardTitle"
        lblCardTitle.Size = New Size(62, 19)
        lblCardTitle.TabIndex = 0
        lblCardTitle.Text = "Patients"
        ' 
        ' lblPatientCount
        ' 
        lblPatientCount.AutoSize = True
        lblPatientCount.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPatientCount.ForeColor = Color.FromArgb(CByte(120), CByte(135), CByte(145))
        lblPatientCount.Location = New Point(82, 22)
        lblPatientCount.Name = "lblPatientCount"
        lblPatientCount.Size = New Size(75, 13)
        lblPatientCount.TabIndex = 8
        lblPatientCount.Text = "• 5 registered"
        ' 
        ' btnFilterVisit
        ' 
        btnFilterVisit.BackColor = Color.White
        btnFilterVisit.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        btnFilterVisit.BorderRadius = 8
        btnFilterVisit.BorderSize = 1
        btnFilterVisit.FlatAppearance.BorderSize = 0
        btnFilterVisit.FlatStyle = FlatStyle.Flat
        btnFilterVisit.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnFilterVisit.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnFilterVisit.Location = New Point(700, 86)
        btnFilterVisit.MouseEnterBackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        btnFilterVisit.MouseEnterBorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnFilterVisit.MouseEnterBorderSize = 1
        btnFilterVisit.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnFilterVisit.MouseEnterForeColor = Color.FromArgb(CByte(20), CByte(35), CByte(45))
        btnFilterVisit.MouseLeaveBackColor = Color.White
        btnFilterVisit.MouseLeaveBorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        btnFilterVisit.MouseLeaveBorderSize = 1
        btnFilterVisit.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnFilterVisit.MouseLeaveForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnFilterVisit.Name = "btnFilterVisit"
        btnFilterVisit.Size = New Size(98, 36)
        btnFilterVisit.TabIndex = 4
        btnFilterVisit.Text = "Last visit  ▾"
        btnFilterVisit.UseVisualStyleBackColor = False
        ' 
        ' btnFilterAll
        ' 
        btnFilterAll.BackColor = Color.White
        btnFilterAll.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        btnFilterAll.BorderRadius = 8
        btnFilterAll.BorderSize = 1
        btnFilterAll.FlatAppearance.BorderSize = 0
        btnFilterAll.FlatStyle = FlatStyle.Flat
        btnFilterAll.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnFilterAll.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnFilterAll.Location = New Point(584, 86)
        btnFilterAll.MouseEnterBackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        btnFilterAll.MouseEnterBorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnFilterAll.MouseEnterBorderSize = 1
        btnFilterAll.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnFilterAll.MouseEnterForeColor = Color.FromArgb(CByte(20), CByte(35), CByte(45))
        btnFilterAll.MouseLeaveBackColor = Color.White
        btnFilterAll.MouseLeaveBorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        btnFilterAll.MouseLeaveBorderSize = 1
        btnFilterAll.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnFilterAll.MouseLeaveForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnFilterAll.Name = "btnFilterAll"
        btnFilterAll.Size = New Size(106, 36)
        btnFilterAll.TabIndex = 3
        btnFilterAll.Text = "All patients  ▾"
        btnFilterAll.UseVisualStyleBackColor = False
        ' 
        ' cardSearch
        ' 
        cardSearch.BackColor = Color.White
        cardSearch.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardSearch.BorderHoverColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        cardSearch.BorderRadius = 8
        cardSearch.BorderSize = 1
        cardSearch.Controls.Add(lblClearSearch)
        cardSearch.Controls.Add(txtSearch)
        cardSearch.Controls.Add(lblSearchIcon)
        cardSearch.EnableShadow = False
        cardSearch.HoverTintColor = Color.White
        cardSearch.Location = New Point(28, 86)
        cardSearch.Name = "cardSearch"
        cardSearch.Padding = New Padding(10, 8, 10, 8)
        cardSearch.ShadowDepth = 2
        cardSearch.Size = New Size(544, 36)
        cardSearch.TabIndex = 2
        ' 
        ' lblClearSearch
        ' 
        lblClearSearch.AutoSize = True
        lblClearSearch.Cursor = Cursors.Hand
        lblClearSearch.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblClearSearch.ForeColor = Color.FromArgb(CByte(160), CByte(175), CByte(185))
        lblClearSearch.Location = New Point(518, 8)
        lblClearSearch.Name = "lblClearSearch"
        lblClearSearch.Size = New Size(16, 17)
        lblClearSearch.TabIndex = 2
        lblClearSearch.Text = "×"
        lblClearSearch.Visible = False
        ' 
        ' txtSearch
        ' 
        txtSearch.BorderStyle = BorderStyle.None
        txtSearch.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSearch.ForeColor = Color.FromArgb(CByte(100), CByte(120), CByte(130))
        txtSearch.Location = New Point(32, 9)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(480, 16)
        txtSearch.TabIndex = 1
        txtSearch.Text = "Search name, patient ID, phone..."
        ' 
        ' lblSearchIcon
        ' 
        lblSearchIcon.AutoSize = True
        lblSearchIcon.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSearchIcon.ForeColor = Color.FromArgb(CByte(150), CByte(165), CByte(175))
        lblSearchIcon.Location = New Point(8, 9)
        lblSearchIcon.Name = "lblSearchIcon"
        lblSearchIcon.Size = New Size(20, 17)
        lblSearchIcon.TabIndex = 0
        lblSearchIcon.Text = "🔍"
        ' 
        ' lblHeaderSubtitle
        ' 
        lblHeaderSubtitle.AutoSize = True
        lblHeaderSubtitle.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblHeaderSubtitle.ForeColor = Color.FromArgb(CByte(115), CByte(138), CByte(148))
        lblHeaderSubtitle.Location = New Point(29, 54)
        lblHeaderSubtitle.Name = "lblHeaderSubtitle"
        lblHeaderSubtitle.Size = New Size(244, 15)
        lblHeaderSubtitle.TabIndex = 1
        lblHeaderSubtitle.Text = "1,248 registered patients • Single clinic record"
        ' 
        ' lblHeaderTitle
        ' 
        lblHeaderTitle.AutoSize = True
        lblHeaderTitle.Font = New Font("Segoe UI", 18.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblHeaderTitle.ForeColor = Color.FromArgb(CByte(22), CByte(51), CByte(65))
        lblHeaderTitle.Location = New Point(28, 20)
        lblHeaderTitle.Name = "lblHeaderTitle"
        lblHeaderTitle.Size = New Size(138, 32)
        lblHeaderTitle.TabIndex = 0
        lblHeaderTitle.Text = "My Patients"
        ' 
        ' DoctorPatients
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1008, 729)
        Controls.Add(mainScreen)
        Controls.Add(sideBar)
        Name = "DoctorPatients"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Clinic Management - My Patients"
        sideBar.ResumeLayout(False)
        sideBar.PerformLayout()
        namePlaceHolder.ResumeLayout(False)
        namePlaceHolder.PerformLayout()
        FCard1.ResumeLayout(False)
        FCard1.PerformLayout()
        mainScreen.ResumeLayout(False)
        mainScreen.PerformLayout()
        cardPatientsTable.ResumeLayout(False)
        cardPatientsTable.PerformLayout()
        cardSearch.ResumeLayout(False)
        cardSearch.PerformLayout()
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

    Friend WithEvents lblHeaderTitle As Label
    Friend WithEvents lblHeaderSubtitle As Label
    Friend WithEvents cardSearch As FCard
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents lblSearchIcon As Label
    Friend WithEvents lblClearSearch As Label
    Friend WithEvents btnFilterAll As FButton
    Friend WithEvents btnFilterVisit As FButton
    Friend WithEvents cardPatientsTable As FCard
    Friend WithEvents lblCardTitle As Label
    Friend WithEvents lblPatientCount As Label
    Friend WithEvents lblColPatient As Label
    Friend WithEvents lblColPatientId As Label
    Friend WithEvents lblColAgeSex As Label
    Friend WithEvents lblColContact As Label
    Friend WithEvents lblColLastVisit As Label
    Friend WithEvents dividerHeader As Panel
    Friend WithEvents pnlRowsContainer As Panel

End Class
