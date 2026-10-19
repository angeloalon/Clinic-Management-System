<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DoctorAppointment
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
        cboDoctorFilter = New ComboBox()
        cardShowing = New Ferrando.UI.WinForms.Controles.FCard()
        lblShowing = New Label()
        cardSchedule = New Ferrando.UI.WinForms.Controles.FCard()
        lblWeek = New Label()
        btnDay1 = New Ferrando.UI.WinForms.Controles.FButton()
        btnDay2 = New Ferrando.UI.WinForms.Controles.FButton()
        btnDay3 = New Ferrando.UI.WinForms.Controles.FButton()
        btnDay4 = New Ferrando.UI.WinForms.Controles.FButton()
        btnDay5 = New Ferrando.UI.WinForms.Controles.FButton()
        lblColTime = New Label()
        lblColPatient = New Label()
        lblColVisit = New Label()
        lblColStatus = New Label()
        lblColAction = New Label()
        divHeader = New Panel()
        lblTime1 = New Label()
        lblPatient1 = New Label()
        lblPatientId1 = New Label()
        lblVisit1 = New Label()
        cardStatus1 = New Ferrando.UI.WinForms.Controles.FCard()
        lblDot1 = New Label()
        lblStatus1 = New Label()
        btnNoShow1 = New Ferrando.UI.WinForms.Controles.FButton()
        btnOpen1 = New Ferrando.UI.WinForms.Controles.FButton()
        lblAction1 = New Label()
        divRow1 = New Panel()
        lblTime2 = New Label()
        lblPatient2 = New Label()
        lblPatientId2 = New Label()
        lblVisit2 = New Label()
        cardStatus2 = New Ferrando.UI.WinForms.Controles.FCard()
        lblDot2 = New Label()
        lblStatus2 = New Label()
        btnNoShow2 = New Ferrando.UI.WinForms.Controles.FButton()
        btnOpen2 = New Ferrando.UI.WinForms.Controles.FButton()
        lblAction2 = New Label()
        divRow2 = New Panel()
        lblTime3 = New Label()
        lblPatient3 = New Label()
        lblPatientId3 = New Label()
        lblVisit3 = New Label()
        cardStatus3 = New Ferrando.UI.WinForms.Controles.FCard()
        lblDot3 = New Label()
        lblStatus3 = New Label()
        btnNoShow3 = New Ferrando.UI.WinForms.Controles.FButton()
        btnOpen3 = New Ferrando.UI.WinForms.Controles.FButton()
        lblAction3 = New Label()
        divRow3 = New Panel()
        lblTime4 = New Label()
        lblPatient4 = New Label()
        lblPatientId4 = New Label()
        lblVisit4 = New Label()
        cardStatus4 = New Ferrando.UI.WinForms.Controles.FCard()
        lblDot4 = New Label()
        lblStatus4 = New Label()
        btnNoShow4 = New Ferrando.UI.WinForms.Controles.FButton()
        btnOpen4 = New Ferrando.UI.WinForms.Controles.FButton()
        lblAction4 = New Label()
        divRow4 = New Panel()
        lblTime5 = New Label()
        lblPatient5 = New Label()
        lblPatientId5 = New Label()
        lblVisit5 = New Label()
        cardStatus5 = New Ferrando.UI.WinForms.Controles.FCard()
        lblDot5 = New Label()
        lblStatus5 = New Label()
        btnNoShow5 = New Ferrando.UI.WinForms.Controles.FButton()
        btnOpen5 = New Ferrando.UI.WinForms.Controles.FButton()
        lblAction5 = New Label()
        lblLegendDotPending = New Label()
        lblLegendPending = New Label()
        lblLegendDotConfirmed = New Label()
        lblLegendConfirmed = New Label()
        lblLegendDotCompleted = New Label()
        lblLegendCompleted = New Label()
        lblLegendDotCancelled = New Label()
        lblLegendCancelled = New Label()
        cardEmpty = New Ferrando.UI.WinForms.Controles.FCard()
        lblEmptyTitle = New Label()
        lblEmptySub = New Label()
        sideBar.SuspendLayout()
        namePlaceHolder.SuspendLayout()
        FCard1.SuspendLayout()
        mainScreen.SuspendLayout()
        cardShowing.SuspendLayout()
        cardSchedule.SuspendLayout()
        cardStatus1.SuspendLayout()
        cardStatus2.SuspendLayout()
        cardStatus3.SuspendLayout()
        cardStatus4.SuspendLayout()
        cardStatus5.SuspendLayout()
        cardEmpty.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.BackColor = Color.FromArgb(CByte(244), CByte(247), CByte(249))
        lblTitle.Font = New Font("Segoe UI", 18.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.FromArgb(CByte(22), CByte(51), CByte(65))
        lblTitle.Location = New Point(28, 18)
        lblTitle.Text = "My Appointments"
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
        lblSubtitle.Text = "Update the status of your own visits"
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.TabIndex = 1
        ' 
        ' cboDoctorFilter
        ' 
        cboDoctorFilter.BackColor = Color.White
        cboDoctorFilter.DropDownStyle = ComboBoxStyle.DropDownList
        cboDoctorFilter.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cboDoctorFilter.ForeColor = Color.FromArgb(CByte(22), CByte(51), CByte(65))
        cboDoctorFilter.FormattingEnabled = True
        cboDoctorFilter.Location = New Point(625, 26)
        cboDoctorFilter.Name = "cboDoctorFilter"
        cboDoctorFilter.Size = New Size(178, 25)
        cboDoctorFilter.TabIndex = 2
        ' 
        ' cardShowing
        ' 
        cardShowing.Controls.Add(lblShowing)
        cardShowing.BackColor = Color.FromArgb(CByte(227), CByte(242), CByte(239))
        cardShowing.BorderColor = Color.FromArgb(CByte(227), CByte(242), CByte(239))
        cardShowing.BorderHoverColor = Color.FromArgb(CByte(227), CByte(242), CByte(239))
        cardShowing.BorderRadius = 10
        cardShowing.BorderSize = 0
        cardShowing.EnableShadow = False
        cardShowing.HoverTintColor = Color.FromArgb(CByte(227), CByte(242), CByte(239))
        cardShowing.Location = New Point(635, 28)
        cardShowing.ShadowDepth = 2
        cardShowing.Size = New Size(168, 24)
        cardShowing.Name = "cardShowing"
        cardShowing.TabIndex = 2
        cardShowing.Visible = False
        ' 
        ' lblShowing
        ' 
        lblShowing.AutoSize = False
        lblShowing.BackColor = Color.FromArgb(CByte(227), CByte(242), CByte(239))
        lblShowing.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblShowing.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        lblShowing.Location = New Point(0, 0)
        lblShowing.Size = New Size(168, 24)
        lblShowing.TextAlign = ContentAlignment.MiddleCenter
        lblShowing.Text = "Showing only your patients"
        lblShowing.Name = "lblShowing"
        lblShowing.TabIndex = 3
        ' 
        ' cardSchedule
        ' 
        cardSchedule.Controls.Add(lblWeek)
        cardSchedule.Controls.Add(btnDay1)
        cardSchedule.Controls.Add(btnDay2)
        cardSchedule.Controls.Add(btnDay3)
        cardSchedule.Controls.Add(btnDay4)
        cardSchedule.Controls.Add(btnDay5)
        cardSchedule.Controls.Add(lblColTime)
        cardSchedule.Controls.Add(lblColPatient)
        cardSchedule.Controls.Add(lblColVisit)
        cardSchedule.Controls.Add(lblColStatus)
        cardSchedule.Controls.Add(lblColAction)
        cardSchedule.Controls.Add(divHeader)
        cardSchedule.Controls.Add(lblTime1)
        cardSchedule.Controls.Add(lblPatient1)
        cardSchedule.Controls.Add(lblPatientId1)
        cardSchedule.Controls.Add(lblVisit1)
        cardSchedule.Controls.Add(cardStatus1)
        cardSchedule.Controls.Add(btnNoShow1)
        cardSchedule.Controls.Add(btnOpen1)
        cardSchedule.Controls.Add(lblAction1)
        cardSchedule.Controls.Add(divRow1)
        cardSchedule.Controls.Add(lblTime2)
        cardSchedule.Controls.Add(lblPatient2)
        cardSchedule.Controls.Add(lblPatientId2)
        cardSchedule.Controls.Add(lblVisit2)
        cardSchedule.Controls.Add(cardStatus2)
        cardSchedule.Controls.Add(btnNoShow2)
        cardSchedule.Controls.Add(btnOpen2)
        cardSchedule.Controls.Add(lblAction2)
        cardSchedule.Controls.Add(divRow2)
        cardSchedule.Controls.Add(lblTime3)
        cardSchedule.Controls.Add(lblPatient3)
        cardSchedule.Controls.Add(lblPatientId3)
        cardSchedule.Controls.Add(lblVisit3)
        cardSchedule.Controls.Add(cardStatus3)
        cardSchedule.Controls.Add(btnNoShow3)
        cardSchedule.Controls.Add(btnOpen3)
        cardSchedule.Controls.Add(lblAction3)
        cardSchedule.Controls.Add(divRow3)
        cardSchedule.Controls.Add(lblTime4)
        cardSchedule.Controls.Add(lblPatient4)
        cardSchedule.Controls.Add(lblPatientId4)
        cardSchedule.Controls.Add(lblVisit4)
        cardSchedule.Controls.Add(cardStatus4)
        cardSchedule.Controls.Add(btnNoShow4)
        cardSchedule.Controls.Add(btnOpen4)
        cardSchedule.Controls.Add(lblAction4)
        cardSchedule.Controls.Add(divRow4)
        cardSchedule.Controls.Add(lblTime5)
        cardSchedule.Controls.Add(lblPatient5)
        cardSchedule.Controls.Add(lblPatientId5)
        cardSchedule.Controls.Add(lblVisit5)
        cardSchedule.Controls.Add(cardStatus5)
        cardSchedule.Controls.Add(btnNoShow5)
        cardSchedule.Controls.Add(btnOpen5)
        cardSchedule.Controls.Add(lblAction5)
        cardSchedule.Controls.Add(lblLegendDotPending)
        cardSchedule.Controls.Add(lblLegendPending)
        cardSchedule.Controls.Add(lblLegendDotConfirmed)
        cardSchedule.Controls.Add(lblLegendConfirmed)
        cardSchedule.Controls.Add(lblLegendDotCompleted)
        cardSchedule.Controls.Add(lblLegendCompleted)
        cardSchedule.Controls.Add(lblLegendDotCancelled)
        cardSchedule.Controls.Add(lblLegendCancelled)
        cardSchedule.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardSchedule.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardSchedule.BorderHoverColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardSchedule.BorderRadius = 12
        cardSchedule.BorderSize = 1
        cardSchedule.EnableShadow = True
        cardSchedule.HoverTintColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardSchedule.Location = New Point(28, 80)
        cardSchedule.ShadowDepth = 4
        cardSchedule.Size = New Size(775, 392)
        cardSchedule.Name = "cardSchedule"
        cardSchedule.TabIndex = 4
        ' 
        ' lblWeek
        ' 
        lblWeek.AutoSize = True
        lblWeek.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblWeek.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblWeek.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblWeek.Location = New Point(16, 14)
        lblWeek.Text = "September 21–25, 2026"
        lblWeek.Name = "lblWeek"
        lblWeek.TabIndex = 5
        ' 
        ' btnDay1
        ' 
        btnDay1.BackColor = Color.FromArgb(CByte(243), CByte(246), CByte(248))
        btnDay1.BorderColor = Color.FromArgb(CByte(243), CByte(246), CByte(248))
        btnDay1.BorderRadius = 8
        btnDay1.BorderSize = 0
        btnDay1.Cursor = Cursors.Hand
        btnDay1.FlatAppearance.BorderSize = 0
        btnDay1.FlatStyle = FlatStyle.Flat
        btnDay1.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDay1.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        btnDay1.Location = New Point(16, 40)
        btnDay1.MouseEnterBackColor = Color.FromArgb(CByte(230), CByte(238), CByte(241))
        btnDay1.MouseEnterBorderColor = Color.FromArgb(CByte(230), CByte(238), CByte(241))
        btnDay1.MouseEnterBorderSize = 0
        btnDay1.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDay1.MouseEnterForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnDay1.MouseLeaveBackColor = Color.FromArgb(CByte(243), CByte(246), CByte(248))
        btnDay1.MouseLeaveBorderColor = Color.FromArgb(CByte(243), CByte(246), CByte(248))
        btnDay1.MouseLeaveBorderSize = 0
        btnDay1.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDay1.MouseLeaveForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        btnDay1.Size = New Size(142, 32)
        btnDay1.Text = "Mon 21"
        btnDay1.UseVisualStyleBackColor = False
        btnDay1.Name = "btnDay1"
        btnDay1.TabIndex = 6
        ' 
        ' btnDay2
        ' 
        btnDay2.BackColor = Color.FromArgb(CByte(243), CByte(246), CByte(248))
        btnDay2.BorderColor = Color.FromArgb(CByte(243), CByte(246), CByte(248))
        btnDay2.BorderRadius = 8
        btnDay2.BorderSize = 0
        btnDay2.Cursor = Cursors.Hand
        btnDay2.FlatAppearance.BorderSize = 0
        btnDay2.FlatStyle = FlatStyle.Flat
        btnDay2.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDay2.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        btnDay2.Location = New Point(166, 40)
        btnDay2.MouseEnterBackColor = Color.FromArgb(CByte(230), CByte(238), CByte(241))
        btnDay2.MouseEnterBorderColor = Color.FromArgb(CByte(230), CByte(238), CByte(241))
        btnDay2.MouseEnterBorderSize = 0
        btnDay2.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDay2.MouseEnterForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnDay2.MouseLeaveBackColor = Color.FromArgb(CByte(243), CByte(246), CByte(248))
        btnDay2.MouseLeaveBorderColor = Color.FromArgb(CByte(243), CByte(246), CByte(248))
        btnDay2.MouseLeaveBorderSize = 0
        btnDay2.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDay2.MouseLeaveForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        btnDay2.Size = New Size(142, 32)
        btnDay2.Text = "Tue 22"
        btnDay2.UseVisualStyleBackColor = False
        btnDay2.Name = "btnDay2"
        btnDay2.TabIndex = 7
        ' 
        ' btnDay3
        ' 
        btnDay3.BackColor = Color.FromArgb(CByte(243), CByte(246), CByte(248))
        btnDay3.BorderColor = Color.FromArgb(CByte(243), CByte(246), CByte(248))
        btnDay3.BorderRadius = 8
        btnDay3.BorderSize = 0
        btnDay3.Cursor = Cursors.Hand
        btnDay3.FlatAppearance.BorderSize = 0
        btnDay3.FlatStyle = FlatStyle.Flat
        btnDay3.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDay3.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        btnDay3.Location = New Point(316, 40)
        btnDay3.MouseEnterBackColor = Color.FromArgb(CByte(230), CByte(238), CByte(241))
        btnDay3.MouseEnterBorderColor = Color.FromArgb(CByte(230), CByte(238), CByte(241))
        btnDay3.MouseEnterBorderSize = 0
        btnDay3.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDay3.MouseEnterForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnDay3.MouseLeaveBackColor = Color.FromArgb(CByte(243), CByte(246), CByte(248))
        btnDay3.MouseLeaveBorderColor = Color.FromArgb(CByte(243), CByte(246), CByte(248))
        btnDay3.MouseLeaveBorderSize = 0
        btnDay3.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDay3.MouseLeaveForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        btnDay3.Size = New Size(142, 32)
        btnDay3.Text = "Wed 23"
        btnDay3.UseVisualStyleBackColor = False
        btnDay3.Name = "btnDay3"
        btnDay3.TabIndex = 8
        ' 
        ' btnDay4
        ' 
        btnDay4.BackColor = Color.FromArgb(CByte(243), CByte(246), CByte(248))
        btnDay4.BorderColor = Color.FromArgb(CByte(243), CByte(246), CByte(248))
        btnDay4.BorderRadius = 8
        btnDay4.BorderSize = 0
        btnDay4.Cursor = Cursors.Hand
        btnDay4.FlatAppearance.BorderSize = 0
        btnDay4.FlatStyle = FlatStyle.Flat
        btnDay4.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDay4.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        btnDay4.Location = New Point(466, 40)
        btnDay4.MouseEnterBackColor = Color.FromArgb(CByte(230), CByte(238), CByte(241))
        btnDay4.MouseEnterBorderColor = Color.FromArgb(CByte(230), CByte(238), CByte(241))
        btnDay4.MouseEnterBorderSize = 0
        btnDay4.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDay4.MouseEnterForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnDay4.MouseLeaveBackColor = Color.FromArgb(CByte(243), CByte(246), CByte(248))
        btnDay4.MouseLeaveBorderColor = Color.FromArgb(CByte(243), CByte(246), CByte(248))
        btnDay4.MouseLeaveBorderSize = 0
        btnDay4.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDay4.MouseLeaveForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        btnDay4.Size = New Size(142, 32)
        btnDay4.Text = "Thu 24"
        btnDay4.UseVisualStyleBackColor = False
        btnDay4.Name = "btnDay4"
        btnDay4.TabIndex = 9
        ' 
        ' btnDay5
        ' 
        btnDay5.BackColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnDay5.BorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnDay5.BorderRadius = 8
        btnDay5.BorderSize = 0
        btnDay5.Cursor = Cursors.Hand
        btnDay5.FlatAppearance.BorderSize = 0
        btnDay5.FlatStyle = FlatStyle.Flat
        btnDay5.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnDay5.ForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnDay5.Location = New Point(616, 40)
        btnDay5.MouseEnterBackColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        btnDay5.MouseEnterBorderColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        btnDay5.MouseEnterBorderSize = 0
        btnDay5.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnDay5.MouseEnterForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnDay5.MouseLeaveBackColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnDay5.MouseLeaveBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnDay5.MouseLeaveBorderSize = 0
        btnDay5.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnDay5.MouseLeaveForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnDay5.Size = New Size(142, 32)
        btnDay5.Text = "Fri 25"
        btnDay5.UseVisualStyleBackColor = False
        btnDay5.Name = "btnDay5"
        btnDay5.TabIndex = 10
        ' 
        ' lblColTime
        ' 
        lblColTime.AutoSize = True
        lblColTime.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblColTime.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblColTime.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblColTime.Location = New Point(16, 82)
        lblColTime.Text = "TIME"
        lblColTime.Name = "lblColTime"
        lblColTime.TabIndex = 11
        ' 
        ' lblColPatient
        ' 
        lblColPatient.AutoSize = True
        lblColPatient.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblColPatient.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblColPatient.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblColPatient.Location = New Point(100, 82)
        lblColPatient.Text = "PATIENT"
        lblColPatient.Name = "lblColPatient"
        lblColPatient.TabIndex = 12
        ' 
        ' lblColVisit
        ' 
        lblColVisit.AutoSize = True
        lblColVisit.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblColVisit.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblColVisit.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblColVisit.Location = New Point(240, 82)
        lblColVisit.Text = "VISIT TYPE"
        lblColVisit.Name = "lblColVisit"
        lblColVisit.TabIndex = 13
        ' 
        ' lblColStatus
        ' 
        lblColStatus.AutoSize = False
        lblColStatus.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblColStatus.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblColStatus.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblColStatus.Location = New Point(430, 82)
        lblColStatus.Size = New Size(90, 14)
        lblColStatus.TextAlign = ContentAlignment.MiddleCenter
        lblColStatus.Text = "STATUS"
        lblColStatus.Name = "lblColStatus"
        lblColStatus.TabIndex = 14
        ' 
        ' lblColAction
        ' 
        lblColAction.AutoSize = False
        lblColAction.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblColAction.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblColAction.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblColAction.Location = New Point(550, 82)
        lblColAction.Size = New Size(195, 14)
        lblColAction.TextAlign = ContentAlignment.MiddleCenter
        lblColAction.Text = "ACTION"
        lblColAction.Name = "lblColAction"
        lblColAction.TabIndex = 15
        ' 
        ' divHeader
        ' 
        divHeader.BackColor = Color.FromArgb(CByte(242), CByte(244), CByte(247))
        divHeader.Location = New Point(16, 100)
        divHeader.Size = New Size(743, 1)
        divHeader.Name = "divHeader"
        divHeader.TabIndex = 16
        ' 
        ' lblTime1
        ' 
        lblTime1.AutoSize = True
        lblTime1.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblTime1.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTime1.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblTime1.Location = New Point(16, 119)
        lblTime1.Text = "8:30 AM"
        lblTime1.Name = "lblTime1"
        lblTime1.TabIndex = 17
        ' 
        ' lblPatient1
        ' 
        lblPatient1.AutoSize = True
        lblPatient1.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblPatient1.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPatient1.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblPatient1.Location = New Point(100, 110)
        lblPatient1.Text = "Maria Santos"
        lblPatient1.Name = "lblPatient1"
        lblPatient1.TabIndex = 18
        ' 
        ' lblPatientId1
        ' 
        lblPatientId1.AutoSize = True
        lblPatientId1.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblPatientId1.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPatientId1.ForeColor = Color.FromArgb(CByte(140), CByte(155), CByte(165))
        lblPatientId1.Location = New Point(100, 127)
        lblPatientId1.Text = "PT-10425"
        lblPatientId1.Name = "lblPatientId1"
        lblPatientId1.TabIndex = 19
        ' 
        ' lblVisit1
        ' 
        lblVisit1.AutoSize = True
        lblVisit1.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblVisit1.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblVisit1.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        lblVisit1.AutoSize = True
        lblVisit1.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblVisit1.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblVisit1.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        lblVisit1.Location = New Point(240, 119)
        lblVisit1.Text = "Follow-up consultation"
        lblVisit1.Name = "lblVisit1"
        lblVisit1.TabIndex = 20
        ' 
        ' cardStatus1
        ' 
        cardStatus1.Controls.Add(lblDot1)
        cardStatus1.Controls.Add(lblStatus1)
        cardStatus1.BackColor = Color.FromArgb(CByte(238), CByte(242), CByte(244))
        cardStatus1.BorderColor = Color.FromArgb(CByte(238), CByte(242), CByte(244))
        cardStatus1.BorderHoverColor = Color.FromArgb(CByte(238), CByte(242), CByte(244))
        cardStatus1.BorderRadius = 10
        cardStatus1.BorderSize = 0
        cardStatus1.EnableShadow = False
        cardStatus1.HoverTintColor = Color.FromArgb(CByte(238), CByte(242), CByte(244))
        cardStatus1.Location = New Point(436, 116)
        cardStatus1.ShadowDepth = 2
        cardStatus1.Size = New Size(78, 22)
        cardStatus1.Name = "cardStatus1"
        cardStatus1.TabIndex = 21
        ' 
        ' lblDot1
        ' 
        lblDot1.AutoSize = True
        lblDot1.BackColor = Color.FromArgb(CByte(238), CByte(242), CByte(244))
        lblDot1.Font = New Font("Segoe UI", 6.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDot1.ForeColor = Color.FromArgb(CByte(115), CByte(138), CByte(148))
        lblDot1.Location = New Point(9, 4)
        lblDot1.Text = "●"
        lblDot1.Name = "lblDot1"
        lblDot1.TabIndex = 22
        ' 
        ' lblStatus1
        ' 
        lblStatus1.AutoSize = True
        lblStatus1.BackColor = Color.FromArgb(CByte(238), CByte(242), CByte(244))
        lblStatus1.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStatus1.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblStatus1.Location = New Point(19, 3)
        lblStatus1.Text = "Confirmed"
        lblStatus1.Name = "lblStatus1"
        lblStatus1.TabIndex = 23
        ' 
        ' btnNoShow1
        ' 
        btnNoShow1.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        btnNoShow1.BorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnNoShow1.BorderRadius = 8
        btnNoShow1.BorderSize = 1
        btnNoShow1.Cursor = Cursors.Hand
        btnNoShow1.FlatAppearance.BorderSize = 0
        btnNoShow1.FlatStyle = FlatStyle.Flat
        btnNoShow1.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnNoShow1.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnNoShow1.Location = New Point(600, 113)
        btnNoShow1.MouseEnterBackColor = Color.FromArgb(CByte(245), CByte(249), CByte(251))
        btnNoShow1.MouseEnterBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnNoShow1.MouseEnterBorderSize = 1
        btnNoShow1.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnNoShow1.MouseEnterForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnNoShow1.MouseLeaveBackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        btnNoShow1.MouseLeaveBorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnNoShow1.MouseLeaveBorderSize = 1
        btnNoShow1.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnNoShow1.MouseLeaveForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnNoShow1.Size = New Size(96, 28)
        btnNoShow1.Text = "Mark no-show"
        btnNoShow1.UseVisualStyleBackColor = False
        btnNoShow1.Name = "btnNoShow1"
        btnNoShow1.TabIndex = 24
        ' 
        ' btnOpen1
        ' 
        btnOpen1.BackColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnOpen1.BorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnOpen1.BorderRadius = 8
        btnOpen1.BorderSize = 0
        btnOpen1.Cursor = Cursors.Hand
        btnOpen1.FlatAppearance.BorderSize = 0
        btnOpen1.FlatStyle = FlatStyle.Flat
        btnOpen1.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnOpen1.ForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnOpen1.Location = New Point(586, 113)
        btnOpen1.MouseEnterBackColor = Color.FromArgb(CByte(23), CByte(105), CByte(90))
        btnOpen1.MouseEnterBorderColor = Color.FromArgb(CByte(23), CByte(105), CByte(90))
        btnOpen1.MouseEnterBorderSize = 0
        btnOpen1.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnOpen1.MouseEnterForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnOpen1.MouseLeaveBackColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnOpen1.MouseLeaveBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnOpen1.MouseLeaveBorderSize = 0
        btnOpen1.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnOpen1.MouseLeaveForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnOpen1.Size = New Size(122, 28)
        btnOpen1.Text = "Open consultation"
        btnOpen1.UseVisualStyleBackColor = False
        btnOpen1.Visible = False
        btnOpen1.Name = "btnOpen1"
        btnOpen1.TabIndex = 25
        ' 
        ' lblAction1
        ' 
        lblAction1.AutoSize = False
        lblAction1.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblAction1.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblAction1.ForeColor = Color.FromArgb(CByte(140), CByte(155), CByte(165))
        lblAction1.Location = New Point(550, 119)
        lblAction1.Size = New Size(195, 16)
        lblAction1.TextAlign = ContentAlignment.MiddleCenter
        lblAction1.Text = "Mark no-show"
        lblAction1.Visible = False
        lblAction1.Name = "lblAction1"
        lblAction1.TabIndex = 26
        ' 
        ' divRow1
        ' 
        divRow1.BackColor = Color.FromArgb(CByte(242), CByte(244), CByte(247))
        divRow1.Location = New Point(16, 151)
        divRow1.Size = New Size(743, 1)
        divRow1.Name = "divRow1"
        divRow1.TabIndex = 27
        ' 
        ' lblTime2
        ' 
        lblTime2.AutoSize = True
        lblTime2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblTime2.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTime2.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblTime2.Location = New Point(16, 169)
        lblTime2.Text = "9:15 AM"
        lblTime2.Name = "lblTime2"
        lblTime2.TabIndex = 28
        ' 
        ' lblPatient2
        ' 
        lblPatient2.AutoSize = True
        lblPatient2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblPatient2.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPatient2.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblPatient2.Location = New Point(100, 160)
        lblPatient2.Text = "Noah Reyes"
        lblPatient2.Name = "lblPatient2"
        lblPatient2.TabIndex = 29
        ' 
        ' lblPatientId2
        ' 
        lblPatientId2.AutoSize = True
        lblPatientId2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblPatientId2.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPatientId2.ForeColor = Color.FromArgb(CByte(140), CByte(155), CByte(165))
        lblPatientId2.Location = New Point(100, 177)
        lblPatientId2.Text = "PT-10861"
        lblPatientId2.Name = "lblPatientId2"
        lblPatientId2.TabIndex = 30
        ' 
        ' lblVisit2
        ' 
        lblVisit2.AutoSize = True
        lblVisit2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblVisit2.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblVisit2.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        lblVisit2.Location = New Point(240, 169)
        lblVisit2.Text = "General consultation"
        lblVisit2.Name = "lblVisit2"
        lblVisit2.TabIndex = 31
        ' 
        ' cardStatus2
        ' 
        cardStatus2.Controls.Add(lblDot2)
        cardStatus2.Controls.Add(lblStatus2)
        cardStatus2.BackColor = Color.FromArgb(CByte(254), CByte(243), CByte(226))
        cardStatus2.BorderColor = Color.FromArgb(CByte(254), CByte(243), CByte(226))
        cardStatus2.BorderHoverColor = Color.FromArgb(CByte(254), CByte(243), CByte(226))
        cardStatus2.BorderRadius = 10
        cardStatus2.BorderSize = 0
        cardStatus2.EnableShadow = False
        cardStatus2.HoverTintColor = Color.FromArgb(CByte(254), CByte(243), CByte(226))
        cardStatus2.Location = New Point(436, 166)
        cardStatus2.ShadowDepth = 2
        cardStatus2.Size = New Size(70, 22)
        cardStatus2.Name = "cardStatus2"
        cardStatus2.TabIndex = 32
        ' 
        ' lblDot2
        ' 
        lblDot2.AutoSize = True
        lblDot2.BackColor = Color.FromArgb(CByte(254), CByte(243), CByte(226))
        lblDot2.Font = New Font("Segoe UI", 6.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDot2.ForeColor = Color.FromArgb(CByte(217), CByte(119), CByte(6))
        lblDot2.Location = New Point(9, 4)
        lblDot2.Text = "●"
        lblDot2.Name = "lblDot2"
        lblDot2.TabIndex = 33
        ' 
        ' lblStatus2
        ' 
        lblStatus2.AutoSize = True
        lblStatus2.BackColor = Color.FromArgb(CByte(254), CByte(243), CByte(226))
        lblStatus2.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStatus2.ForeColor = Color.FromArgb(CByte(217), CByte(119), CByte(6))
        lblStatus2.Location = New Point(19, 3)
        lblStatus2.Text = "Pending"
        lblStatus2.Name = "lblStatus2"
        lblStatus2.TabIndex = 34
        ' 
        ' btnNoShow2
        ' 
        btnNoShow2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        btnNoShow2.BorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnNoShow2.BorderRadius = 8
        btnNoShow2.BorderSize = 1
        btnNoShow2.Cursor = Cursors.Hand
        btnNoShow2.FlatAppearance.BorderSize = 0
        btnNoShow2.FlatStyle = FlatStyle.Flat
        btnNoShow2.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnNoShow2.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnNoShow2.Location = New Point(600, 163)
        btnNoShow2.MouseEnterBackColor = Color.FromArgb(CByte(245), CByte(249), CByte(251))
        btnNoShow2.MouseEnterBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnNoShow2.MouseEnterBorderSize = 1
        btnNoShow2.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnNoShow2.MouseEnterForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnNoShow2.MouseLeaveBackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        btnNoShow2.MouseLeaveBorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnNoShow2.MouseLeaveBorderSize = 1
        btnNoShow2.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnNoShow2.MouseLeaveForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnNoShow2.Size = New Size(92, 28)
        btnNoShow2.Text = "Mark no-show"
        btnNoShow2.UseVisualStyleBackColor = False
        btnNoShow2.Visible = False
        btnNoShow2.Name = "btnNoShow2"
        btnNoShow2.TabIndex = 35
        ' 
        ' btnOpen2
        ' 
        btnOpen2.BackColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnOpen2.BorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnOpen2.BorderRadius = 8
        btnOpen2.BorderSize = 0
        btnOpen2.Cursor = Cursors.Hand
        btnOpen2.FlatAppearance.BorderSize = 0
        btnOpen2.FlatStyle = FlatStyle.Flat
        btnOpen2.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnOpen2.ForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnOpen2.Location = New Point(586, 163)
        btnOpen2.MouseEnterBackColor = Color.FromArgb(CByte(23), CByte(105), CByte(90))
        btnOpen2.MouseEnterBorderColor = Color.FromArgb(CByte(23), CByte(105), CByte(90))
        btnOpen2.MouseEnterBorderSize = 0
        btnOpen2.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnOpen2.MouseEnterForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnOpen2.MouseLeaveBackColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnOpen2.MouseLeaveBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnOpen2.MouseLeaveBorderSize = 0
        btnOpen2.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnOpen2.MouseLeaveForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnOpen2.Size = New Size(122, 28)
        btnOpen2.Text = "Open consultation"
        btnOpen2.UseVisualStyleBackColor = False
        btnOpen2.Name = "btnOpen2"
        btnOpen2.TabIndex = 36
        ' 
        ' lblAction2
        ' 
        lblAction2.AutoSize = False
        lblAction2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblAction2.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblAction2.ForeColor = Color.FromArgb(CByte(140), CByte(155), CByte(165))
        lblAction2.Location = New Point(550, 169)
        lblAction2.Size = New Size(195, 16)
        lblAction2.TextAlign = ContentAlignment.MiddleCenter
        lblAction2.Text = "No action needed"
        lblAction2.Visible = False
        lblAction2.Name = "lblAction2"
        lblAction2.TabIndex = 37
        ' 
        ' divRow2
        ' 
        divRow2.BackColor = Color.FromArgb(CByte(242), CByte(244), CByte(247))
        divRow2.Location = New Point(16, 201)
        divRow2.Size = New Size(743, 1)
        divRow2.Name = "divRow2"
        divRow2.TabIndex = 38
        ' 
        ' lblTime3
        ' 
        lblTime3.AutoSize = True
        lblTime3.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblTime3.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTime3.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblTime3.Location = New Point(16, 219)
        lblTime3.Text = "10:30 AM"
        lblTime3.Name = "lblTime3"
        lblTime3.TabIndex = 39
        ' 
        ' lblPatient3
        ' 
        lblPatient3.AutoSize = True
        lblPatient3.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblPatient3.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPatient3.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblPatient3.Location = New Point(100, 210)
        lblPatient3.Text = "Angela Mendoza"
        lblPatient3.Name = "lblPatient3"
        lblPatient3.TabIndex = 40
        ' 
        ' lblPatientId3
        ' 
        lblPatientId3.AutoSize = True
        lblPatientId3.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblPatientId3.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPatientId3.ForeColor = Color.FromArgb(CByte(140), CByte(155), CByte(165))
        lblPatientId3.Location = New Point(100, 227)
        lblPatientId3.Text = "PT-09734"
        lblPatientId3.Name = "lblPatientId3"
        lblPatientId3.TabIndex = 41
        ' 
        ' lblVisit3
        ' 
        lblVisit3.AutoSize = True
        lblVisit3.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblVisit3.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblVisit3.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        lblVisit3.Location = New Point(240, 219)
        lblVisit3.Text = "Medical certificate"
        lblVisit3.Name = "lblVisit3"
        lblVisit3.TabIndex = 42
        ' 
        ' cardStatus3
        ' 
        cardStatus3.Controls.Add(lblDot3)
        cardStatus3.Controls.Add(lblStatus3)
        cardStatus3.BackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        cardStatus3.BorderColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        cardStatus3.BorderHoverColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        cardStatus3.BorderRadius = 10
        cardStatus3.BorderSize = 0
        cardStatus3.EnableShadow = False
        cardStatus3.HoverTintColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        cardStatus3.Location = New Point(436, 216)
        cardStatus3.ShadowDepth = 2
        cardStatus3.Size = New Size(80, 22)
        cardStatus3.Name = "cardStatus3"
        cardStatus3.TabIndex = 43
        ' 
        ' lblDot3
        ' 
        lblDot3.AutoSize = True
        lblDot3.BackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        lblDot3.Font = New Font("Segoe UI", 6.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDot3.ForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        lblDot3.Location = New Point(9, 4)
        lblDot3.Text = "●"
        lblDot3.Name = "lblDot3"
        lblDot3.TabIndex = 44
        ' 
        ' lblStatus3
        ' 
        lblStatus3.AutoSize = True
        lblStatus3.BackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        lblStatus3.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStatus3.ForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        lblStatus3.Location = New Point(19, 3)
        lblStatus3.Text = "Completed"
        lblStatus3.Name = "lblStatus3"
        lblStatus3.TabIndex = 45
        ' 
        ' btnNoShow3
        ' 
        btnNoShow3.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        btnNoShow3.BorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnNoShow3.BorderRadius = 8
        btnNoShow3.BorderSize = 1
        btnNoShow3.Cursor = Cursors.Hand
        btnNoShow3.FlatAppearance.BorderSize = 0
        btnNoShow3.FlatStyle = FlatStyle.Flat
        btnNoShow3.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnNoShow3.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnNoShow3.Location = New Point(600, 213)
        btnNoShow3.MouseEnterBackColor = Color.FromArgb(CByte(245), CByte(249), CByte(251))
        btnNoShow3.MouseEnterBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnNoShow3.MouseEnterBorderSize = 1
        btnNoShow3.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnNoShow3.MouseEnterForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnNoShow3.MouseLeaveBackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        btnNoShow3.MouseLeaveBorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnNoShow3.MouseLeaveBorderSize = 1
        btnNoShow3.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnNoShow3.MouseLeaveForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnNoShow3.Size = New Size(92, 28)
        btnNoShow3.Text = "Mark no-show"
        btnNoShow3.UseVisualStyleBackColor = False
        btnNoShow3.Visible = False
        btnNoShow3.Name = "btnNoShow3"
        btnNoShow3.TabIndex = 46
        ' 
        ' btnOpen3
        ' 
        btnOpen3.BackColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnOpen3.BorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnOpen3.BorderRadius = 8
        btnOpen3.BorderSize = 0
        btnOpen3.Cursor = Cursors.Hand
        btnOpen3.FlatAppearance.BorderSize = 0
        btnOpen3.FlatStyle = FlatStyle.Flat
        btnOpen3.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnOpen3.ForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnOpen3.Location = New Point(586, 213)
        btnOpen3.MouseEnterBackColor = Color.FromArgb(CByte(23), CByte(105), CByte(90))
        btnOpen3.MouseEnterBorderColor = Color.FromArgb(CByte(23), CByte(105), CByte(90))
        btnOpen3.MouseEnterBorderSize = 0
        btnOpen3.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnOpen3.MouseEnterForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnOpen3.MouseLeaveBackColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnOpen3.MouseLeaveBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnOpen3.MouseLeaveBorderSize = 0
        btnOpen3.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnOpen3.MouseLeaveForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnOpen3.Size = New Size(122, 28)
        btnOpen3.Text = "Open consultation"
        btnOpen3.UseVisualStyleBackColor = False
        btnOpen3.Visible = False
        btnOpen3.Name = "btnOpen3"
        btnOpen3.TabIndex = 47
        ' 
        ' lblAction3
        ' 
        lblAction3.AutoSize = False
        lblAction3.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblAction3.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblAction3.ForeColor = Color.FromArgb(CByte(140), CByte(155), CByte(165))
        lblAction3.Location = New Point(550, 219)
        lblAction3.Size = New Size(195, 16)
        lblAction3.TextAlign = ContentAlignment.MiddleCenter
        lblAction3.Text = "No action needed"
        lblAction3.Name = "lblAction3"
        lblAction3.TabIndex = 48
        ' 
        ' divRow3
        ' 
        divRow3.BackColor = Color.FromArgb(CByte(242), CByte(244), CByte(247))
        divRow3.Location = New Point(16, 251)
        divRow3.Size = New Size(743, 1)
        divRow3.Name = "divRow3"
        divRow3.TabIndex = 49
        ' 
        ' lblTime4
        ' 
        lblTime4.AutoSize = True
        lblTime4.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblTime4.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTime4.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblTime4.Location = New Point(16, 269)
        lblTime4.Text = "1:00 PM"
        lblTime4.Name = "lblTime4"
        lblTime4.TabIndex = 50
        ' 
        ' lblPatient4
        ' 
        lblPatient4.AutoSize = True
        lblPatient4.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblPatient4.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPatient4.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblPatient4.Location = New Point(100, 260)
        lblPatient4.Text = "Gabriel Lim"
        lblPatient4.Name = "lblPatient4"
        lblPatient4.TabIndex = 51
        ' 
        ' lblPatientId4
        ' 
        lblPatientId4.AutoSize = True
        lblPatientId4.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblPatientId4.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPatientId4.ForeColor = Color.FromArgb(CByte(140), CByte(155), CByte(165))
        lblPatientId4.Location = New Point(100, 277)
        lblPatientId4.Text = "PT-11209"
        lblPatientId4.Name = "lblPatientId4"
        lblPatientId4.TabIndex = 52
        ' 
        ' lblVisit4
        ' 
        lblVisit4.AutoSize = True
        lblVisit4.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblVisit4.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblVisit4.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        lblVisit4.Location = New Point(240, 269)
        lblVisit4.Text = "Blood pressure review"
        lblVisit4.Name = "lblVisit4"
        lblVisit4.TabIndex = 53
        ' 
        ' cardStatus4
        ' 
        cardStatus4.Controls.Add(lblDot4)
        cardStatus4.Controls.Add(lblStatus4)
        cardStatus4.BackColor = Color.FromArgb(CByte(238), CByte(242), CByte(244))
        cardStatus4.BorderColor = Color.FromArgb(CByte(238), CByte(242), CByte(244))
        cardStatus4.BorderHoverColor = Color.FromArgb(CByte(238), CByte(242), CByte(244))
        cardStatus4.BorderRadius = 10
        cardStatus4.BorderSize = 0
        cardStatus4.EnableShadow = False
        cardStatus4.HoverTintColor = Color.FromArgb(CByte(238), CByte(242), CByte(244))
        cardStatus4.Location = New Point(436, 266)
        cardStatus4.ShadowDepth = 2
        cardStatus4.Size = New Size(78, 22)
        cardStatus4.Name = "cardStatus4"
        cardStatus4.TabIndex = 54
        ' 
        ' lblDot4
        ' 
        lblDot4.AutoSize = True
        lblDot4.BackColor = Color.FromArgb(CByte(238), CByte(242), CByte(244))
        lblDot4.Font = New Font("Segoe UI", 6.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDot4.ForeColor = Color.FromArgb(CByte(115), CByte(138), CByte(148))
        lblDot4.Location = New Point(9, 4)
        lblDot4.Text = "●"
        lblDot4.Name = "lblDot4"
        lblDot4.TabIndex = 55
        ' 
        ' lblStatus4
        ' 
        lblStatus4.AutoSize = True
        lblStatus4.BackColor = Color.FromArgb(CByte(238), CByte(242), CByte(244))
        lblStatus4.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStatus4.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblStatus4.Location = New Point(19, 3)
        lblStatus4.Text = "Confirmed"
        lblStatus4.Name = "lblStatus4"
        lblStatus4.TabIndex = 56
        ' 
        ' btnNoShow4
        ' 
        btnNoShow4.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        btnNoShow4.BorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnNoShow4.BorderRadius = 8
        btnNoShow4.BorderSize = 1
        btnNoShow4.Cursor = Cursors.Hand
        btnNoShow4.FlatAppearance.BorderSize = 0
        btnNoShow4.FlatStyle = FlatStyle.Flat
        btnNoShow4.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnNoShow4.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnNoShow4.Location = New Point(600, 263)
        btnNoShow4.MouseEnterBackColor = Color.FromArgb(CByte(245), CByte(249), CByte(251))
        btnNoShow4.MouseEnterBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnNoShow4.MouseEnterBorderSize = 1
        btnNoShow4.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnNoShow4.MouseEnterForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnNoShow4.MouseLeaveBackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        btnNoShow4.MouseLeaveBorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnNoShow4.MouseLeaveBorderSize = 1
        btnNoShow4.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnNoShow4.MouseLeaveForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnNoShow4.Size = New Size(92, 28)
        btnNoShow4.Text = "Mark no-show"
        btnNoShow4.UseVisualStyleBackColor = False
        btnNoShow4.Name = "btnNoShow4"
        btnNoShow4.TabIndex = 57
        ' 
        ' btnOpen4
        ' 
        btnOpen4.BackColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnOpen4.BorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnOpen4.BorderRadius = 8
        btnOpen4.BorderSize = 0
        btnOpen4.Cursor = Cursors.Hand
        btnOpen4.FlatAppearance.BorderSize = 0
        btnOpen4.FlatStyle = FlatStyle.Flat
        btnOpen4.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnOpen4.ForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnOpen4.Location = New Point(586, 263)
        btnOpen4.MouseEnterBackColor = Color.FromArgb(CByte(23), CByte(105), CByte(90))
        btnOpen4.MouseEnterBorderColor = Color.FromArgb(CByte(23), CByte(105), CByte(90))
        btnOpen4.MouseEnterBorderSize = 0
        btnOpen4.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnOpen4.MouseEnterForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnOpen4.MouseLeaveBackColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnOpen4.MouseLeaveBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnOpen4.MouseLeaveBorderSize = 0
        btnOpen4.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnOpen4.MouseLeaveForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnOpen4.Size = New Size(122, 28)
        btnOpen4.Text = "Open consultation"
        btnOpen4.UseVisualStyleBackColor = False
        btnOpen4.Visible = False
        btnOpen4.Name = "btnOpen4"
        btnOpen4.TabIndex = 58
        ' 
        ' lblAction4
        ' 
        lblAction4.AutoSize = False
        lblAction4.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblAction4.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblAction4.ForeColor = Color.FromArgb(CByte(140), CByte(155), CByte(165))
        lblAction4.Location = New Point(550, 269)
        lblAction4.Size = New Size(195, 16)
        lblAction4.TextAlign = ContentAlignment.MiddleCenter
        lblAction4.Text = "No action needed"
        lblAction4.Visible = False
        lblAction4.Name = "lblAction4"
        lblAction4.TabIndex = 59
        ' 
        ' divRow4
        ' 
        divRow4.BackColor = Color.FromArgb(CByte(242), CByte(244), CByte(247))
        divRow4.Location = New Point(16, 301)
        divRow4.Size = New Size(743, 1)
        divRow4.Name = "divRow4"
        divRow4.TabIndex = 60
        ' 
        ' lblTime5
        ' 
        lblTime5.AutoSize = True
        lblTime5.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblTime5.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTime5.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblTime5.Location = New Point(16, 319)
        lblTime5.Text = "2:45 PM"
        lblTime5.Name = "lblTime5"
        lblTime5.TabIndex = 61
        ' 
        ' lblPatient5
        ' 
        lblPatient5.AutoSize = True
        lblPatient5.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblPatient5.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPatient5.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblPatient5.Location = New Point(100, 310)
        lblPatient5.Text = "Sofia Navarro"
        lblPatient5.Name = "lblPatient5"
        lblPatient5.TabIndex = 62
        ' 
        ' lblPatientId5
        ' 
        lblPatientId5.AutoSize = True
        lblPatientId5.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblPatientId5.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPatientId5.ForeColor = Color.FromArgb(CByte(140), CByte(155), CByte(165))
        lblPatientId5.Location = New Point(100, 327)
        lblPatientId5.Text = "PT-10172"
        lblPatientId5.Name = "lblPatientId5"
        lblPatientId5.TabIndex = 63
        ' 
        ' lblVisit5
        ' 
        lblVisit5.AutoSize = True
        lblVisit5.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblVisit5.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblVisit5.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        lblVisit5.Location = New Point(240, 319)
        lblVisit5.Text = "General consultation"
        lblVisit5.Name = "lblVisit5"
        lblVisit5.TabIndex = 64
        ' 
        ' cardStatus5
        ' 
        cardStatus5.Controls.Add(lblDot5)
        cardStatus5.Controls.Add(lblStatus5)
        cardStatus5.BackColor = Color.FromArgb(CByte(253), CByte(236), CByte(236))
        cardStatus5.BorderColor = Color.FromArgb(CByte(253), CByte(236), CByte(236))
        cardStatus5.BorderHoverColor = Color.FromArgb(CByte(253), CByte(236), CByte(236))
        cardStatus5.BorderRadius = 10
        cardStatus5.BorderSize = 0
        cardStatus5.EnableShadow = False
        cardStatus5.HoverTintColor = Color.FromArgb(CByte(253), CByte(236), CByte(236))
        cardStatus5.Location = New Point(436, 316)
        cardStatus5.ShadowDepth = 2
        cardStatus5.Size = New Size(76, 22)
        cardStatus5.Name = "cardStatus5"
        cardStatus5.TabIndex = 65
        ' 
        ' lblDot5
        ' 
        lblDot5.AutoSize = True
        lblDot5.BackColor = Color.FromArgb(CByte(253), CByte(236), CByte(236))
        lblDot5.Font = New Font("Segoe UI", 6.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDot5.ForeColor = Color.FromArgb(CByte(205), CByte(80), CByte(75))
        lblDot5.Location = New Point(9, 4)
        lblDot5.Text = "●"
        lblDot5.Name = "lblDot5"
        lblDot5.TabIndex = 66
        ' 
        ' lblStatus5
        ' 
        lblStatus5.AutoSize = True
        lblStatus5.BackColor = Color.FromArgb(CByte(253), CByte(236), CByte(236))
        lblStatus5.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStatus5.ForeColor = Color.FromArgb(CByte(205), CByte(80), CByte(75))
        lblStatus5.Location = New Point(19, 3)
        lblStatus5.Text = "Cancelled"
        lblStatus5.Name = "lblStatus5"
        lblStatus5.TabIndex = 67
        ' 
        ' btnNoShow5
        ' 
        btnNoShow5.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        btnNoShow5.BorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnNoShow5.BorderRadius = 8
        btnNoShow5.BorderSize = 1
        btnNoShow5.Cursor = Cursors.Hand
        btnNoShow5.FlatAppearance.BorderSize = 0
        btnNoShow5.FlatStyle = FlatStyle.Flat
        btnNoShow5.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnNoShow5.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnNoShow5.Location = New Point(600, 313)
        btnNoShow5.MouseEnterBackColor = Color.FromArgb(CByte(245), CByte(249), CByte(251))
        btnNoShow5.MouseEnterBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnNoShow5.MouseEnterBorderSize = 1
        btnNoShow5.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnNoShow5.MouseEnterForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnNoShow5.MouseLeaveBackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        btnNoShow5.MouseLeaveBorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnNoShow5.MouseLeaveBorderSize = 1
        btnNoShow5.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnNoShow5.MouseLeaveForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnNoShow5.Size = New Size(92, 28)
        btnNoShow5.Text = "Mark no-show"
        btnNoShow5.UseVisualStyleBackColor = False
        btnNoShow5.Visible = False
        btnNoShow5.Name = "btnNoShow5"
        btnNoShow5.TabIndex = 68
        ' 
        ' btnOpen5
        ' 
        btnOpen5.BackColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnOpen5.BorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnOpen5.BorderRadius = 8
        btnOpen5.BorderSize = 0
        btnOpen5.Cursor = Cursors.Hand
        btnOpen5.FlatAppearance.BorderSize = 0
        btnOpen5.FlatStyle = FlatStyle.Flat
        btnOpen5.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnOpen5.ForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnOpen5.Location = New Point(586, 313)
        btnOpen5.MouseEnterBackColor = Color.FromArgb(CByte(23), CByte(105), CByte(90))
        btnOpen5.MouseEnterBorderColor = Color.FromArgb(CByte(23), CByte(105), CByte(90))
        btnOpen5.MouseEnterBorderSize = 0
        btnOpen5.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnOpen5.MouseEnterForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnOpen5.MouseLeaveBackColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnOpen5.MouseLeaveBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnOpen5.MouseLeaveBorderSize = 0
        btnOpen5.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnOpen5.MouseLeaveForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnOpen5.Size = New Size(122, 28)
        btnOpen5.Text = "Open consultation"
        btnOpen5.UseVisualStyleBackColor = False
        btnOpen5.Visible = False
        btnOpen5.Name = "btnOpen5"
        btnOpen5.TabIndex = 69
        ' 
        ' lblAction5
        ' 
        lblAction5.AutoSize = False
        lblAction5.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblAction5.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblAction5.ForeColor = Color.FromArgb(CByte(140), CByte(155), CByte(165))
        lblAction5.Location = New Point(550, 319)
        lblAction5.Size = New Size(195, 16)
        lblAction5.TextAlign = ContentAlignment.MiddleCenter
        lblAction5.Text = "Cancelled by front desk"
        lblAction5.Name = "lblAction5"
        lblAction5.TabIndex = 70
        ' 
        ' lblLegendDotPending
        ' 
        lblLegendDotPending.AutoSize = True
        lblLegendDotPending.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblLegendDotPending.Font = New Font("Segoe UI", 6.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblLegendDotPending.ForeColor = Color.FromArgb(CByte(217), CByte(119), CByte(6))
        lblLegendDotPending.Location = New Point(16, 367)
        lblLegendDotPending.Text = "●"
        lblLegendDotPending.Name = "lblLegendDotPending"
        lblLegendDotPending.TabIndex = 71
        ' 
        ' lblLegendPending
        ' 
        lblLegendPending.AutoSize = True
        lblLegendPending.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblLegendPending.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblLegendPending.ForeColor = Color.FromArgb(CByte(115), CByte(138), CByte(148))
        lblLegendPending.Location = New Point(25, 364)
        lblLegendPending.Text = "Pending"
        lblLegendPending.Name = "lblLegendPending"
        lblLegendPending.TabIndex = 72
        ' 
        ' lblLegendDotConfirmed
        ' 
        lblLegendDotConfirmed.AutoSize = True
        lblLegendDotConfirmed.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblLegendDotConfirmed.Font = New Font("Segoe UI", 6.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblLegendDotConfirmed.ForeColor = Color.FromArgb(CByte(115), CByte(138), CByte(148))
        lblLegendDotConfirmed.Location = New Point(76, 367)
        lblLegendDotConfirmed.Text = "●"
        lblLegendDotConfirmed.Name = "lblLegendDotConfirmed"
        lblLegendDotConfirmed.TabIndex = 73
        ' 
        ' lblLegendConfirmed
        ' 
        lblLegendConfirmed.AutoSize = True
        lblLegendConfirmed.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblLegendConfirmed.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblLegendConfirmed.ForeColor = Color.FromArgb(CByte(115), CByte(138), CByte(148))
        lblLegendConfirmed.Location = New Point(85, 364)
        lblLegendConfirmed.Text = "Confirmed"
        lblLegendConfirmed.Name = "lblLegendConfirmed"
        lblLegendConfirmed.TabIndex = 74
        ' 
        ' lblLegendDotCompleted
        ' 
        lblLegendDotCompleted.AutoSize = True
        lblLegendDotCompleted.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblLegendDotCompleted.Font = New Font("Segoe UI", 6.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblLegendDotCompleted.ForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        lblLegendDotCompleted.Location = New Point(148, 367)
        lblLegendDotCompleted.Text = "●"
        lblLegendDotCompleted.Name = "lblLegendDotCompleted"
        lblLegendDotCompleted.TabIndex = 75
        ' 
        ' lblLegendCompleted
        ' 
        lblLegendCompleted.AutoSize = True
        lblLegendCompleted.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblLegendCompleted.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblLegendCompleted.ForeColor = Color.FromArgb(CByte(115), CByte(138), CByte(148))
        lblLegendCompleted.Location = New Point(157, 364)
        lblLegendCompleted.Text = "Completed"
        lblLegendCompleted.Name = "lblLegendCompleted"
        lblLegendCompleted.TabIndex = 76
        ' 
        ' lblLegendDotCancelled
        ' 
        lblLegendDotCancelled.AutoSize = True
        lblLegendDotCancelled.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblLegendDotCancelled.Font = New Font("Segoe UI", 6.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblLegendDotCancelled.ForeColor = Color.FromArgb(CByte(205), CByte(80), CByte(75))
        lblLegendDotCancelled.Location = New Point(222, 367)
        lblLegendDotCancelled.Text = "●"
        lblLegendDotCancelled.Name = "lblLegendDotCancelled"
        lblLegendDotCancelled.TabIndex = 77
        ' 
        ' lblLegendCancelled
        ' 
        lblLegendCancelled.AutoSize = True
        lblLegendCancelled.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblLegendCancelled.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblLegendCancelled.ForeColor = Color.FromArgb(CByte(115), CByte(138), CByte(148))
        lblLegendCancelled.Location = New Point(231, 364)
        lblLegendCancelled.Text = "Cancelled"
        lblLegendCancelled.Name = "lblLegendCancelled"
        lblLegendCancelled.TabIndex = 78
        ' 
        ' cardEmpty
        ' 
        cardEmpty.Controls.Add(lblEmptyTitle)
        cardEmpty.Controls.Add(lblEmptySub)
        cardEmpty.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardEmpty.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardEmpty.BorderHoverColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardEmpty.BorderRadius = 12
        cardEmpty.BorderSize = 1
        cardEmpty.EnableShadow = True
        cardEmpty.HoverTintColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardEmpty.Location = New Point(28, 489)
        cardEmpty.ShadowDepth = 4
        cardEmpty.Size = New Size(775, 92)
        cardEmpty.Name = "cardEmpty"
        cardEmpty.TabIndex = 79
        ' 
        ' lblEmptyTitle
        ' 
        lblEmptyTitle.AutoSize = False
        lblEmptyTitle.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblEmptyTitle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblEmptyTitle.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblEmptyTitle.Location = New Point(0, 26)
        lblEmptyTitle.Size = New Size(775, 18)
        lblEmptyTitle.TextAlign = ContentAlignment.MiddleCenter
        lblEmptyTitle.Text = "No appointments scheduled for this day"
        lblEmptyTitle.Name = "lblEmptyTitle"
        lblEmptyTitle.TabIndex = 80
        ' 
        ' lblEmptySub
        ' 
        lblEmptySub.AutoSize = False
        lblEmptySub.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblEmptySub.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblEmptySub.ForeColor = Color.FromArgb(CByte(140), CByte(155), CByte(165))
        lblEmptySub.Location = New Point(0, 47)
        lblEmptySub.Size = New Size(775, 16)
        lblEmptySub.TextAlign = ContentAlignment.MiddleCenter
        lblEmptySub.Text = "New bookings will appear automatically."
        lblEmptySub.Name = "lblEmptySub"
        lblEmptySub.TabIndex = 81
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
        mainScreen.Controls.Add(cboDoctorFilter)
        mainScreen.Controls.Add(cardShowing)
        mainScreen.Controls.Add(cardSchedule)
        mainScreen.Controls.Add(cardEmpty)
        mainScreen.Location = New Point(176, 0)
        mainScreen.Name = "mainScreen"
        mainScreen.Size = New Size(832, 730)
        mainScreen.TabIndex = 1
        ' 
        ' DoctorAppointment
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1008, 729)
        Controls.Add(mainScreen)
        Controls.Add(sideBar)
        Name = "DoctorAppointment"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Clinic Management - Doctor Appointments"
        cardEmpty.ResumeLayout(False)
        cardEmpty.PerformLayout()
        cardStatus5.ResumeLayout(False)
        cardStatus5.PerformLayout()
        cardStatus4.ResumeLayout(False)
        cardStatus4.PerformLayout()
        cardStatus3.ResumeLayout(False)
        cardStatus3.PerformLayout()
        cardStatus2.ResumeLayout(False)
        cardStatus2.PerformLayout()
        cardStatus1.ResumeLayout(False)
        cardStatus1.PerformLayout()
        cardSchedule.ResumeLayout(False)
        cardSchedule.PerformLayout()
        cardShowing.ResumeLayout(False)
        cardShowing.PerformLayout()
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
    Friend WithEvents cboDoctorFilter As ComboBox
    Friend WithEvents cardShowing As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblShowing As Label
    Friend WithEvents cardSchedule As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblWeek As Label
    Friend WithEvents btnDay1 As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnDay2 As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnDay3 As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnDay4 As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnDay5 As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents lblColTime As Label
    Friend WithEvents lblColPatient As Label
    Friend WithEvents lblColVisit As Label
    Friend WithEvents lblColStatus As Label
    Friend WithEvents lblColAction As Label
    Friend WithEvents divHeader As Panel
    Friend WithEvents lblTime1 As Label
    Friend WithEvents lblPatient1 As Label
    Friend WithEvents lblPatientId1 As Label
    Friend WithEvents lblVisit1 As Label
    Friend WithEvents cardStatus1 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblDot1 As Label
    Friend WithEvents lblStatus1 As Label
    Friend WithEvents btnNoShow1 As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnOpen1 As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents lblAction1 As Label
    Friend WithEvents divRow1 As Panel
    Friend WithEvents lblTime2 As Label
    Friend WithEvents lblPatient2 As Label
    Friend WithEvents lblPatientId2 As Label
    Friend WithEvents lblVisit2 As Label
    Friend WithEvents cardStatus2 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblDot2 As Label
    Friend WithEvents lblStatus2 As Label
    Friend WithEvents btnNoShow2 As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnOpen2 As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents lblAction2 As Label
    Friend WithEvents divRow2 As Panel
    Friend WithEvents lblTime3 As Label
    Friend WithEvents lblPatient3 As Label
    Friend WithEvents lblPatientId3 As Label
    Friend WithEvents lblVisit3 As Label
    Friend WithEvents cardStatus3 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblDot3 As Label
    Friend WithEvents lblStatus3 As Label
    Friend WithEvents btnNoShow3 As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnOpen3 As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents lblAction3 As Label
    Friend WithEvents divRow3 As Panel
    Friend WithEvents lblTime4 As Label
    Friend WithEvents lblPatient4 As Label
    Friend WithEvents lblPatientId4 As Label
    Friend WithEvents lblVisit4 As Label
    Friend WithEvents cardStatus4 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblDot4 As Label
    Friend WithEvents lblStatus4 As Label
    Friend WithEvents btnNoShow4 As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnOpen4 As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents lblAction4 As Label
    Friend WithEvents divRow4 As Panel
    Friend WithEvents lblTime5 As Label
    Friend WithEvents lblPatient5 As Label
    Friend WithEvents lblPatientId5 As Label
    Friend WithEvents lblVisit5 As Label
    Friend WithEvents cardStatus5 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblDot5 As Label
    Friend WithEvents lblStatus5 As Label
    Friend WithEvents btnNoShow5 As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnOpen5 As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents lblAction5 As Label
    Friend WithEvents lblLegendDotPending As Label
    Friend WithEvents lblLegendPending As Label
    Friend WithEvents lblLegendDotConfirmed As Label
    Friend WithEvents lblLegendConfirmed As Label
    Friend WithEvents lblLegendDotCompleted As Label
    Friend WithEvents lblLegendCompleted As Label
    Friend WithEvents lblLegendDotCancelled As Label
    Friend WithEvents lblLegendCancelled As Label
    Friend WithEvents cardEmpty As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblEmptyTitle As Label
    Friend WithEvents lblEmptySub As Label

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