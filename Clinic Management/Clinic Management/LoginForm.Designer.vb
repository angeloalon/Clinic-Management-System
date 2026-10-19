Imports Ferrando.UI.WinForms.Controles

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LoginForm
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
        leftPanel = New Panel()
        lblFooterBrand = New Label()
        lblHeroSubtitle = New Label()
        lblHeroTitle = New Label()
        cardLogo = New FCard()
        lblLogo = New Label()
        rightPanel = New Panel()
        cardLogin = New FCard()
        lnkForgotPassword = New LinkLabel()
        lnkFirstTime = New LinkLabel()
        lblNotice = New Label()
        btnSignIn = New FButton()
        cardPasswordBox = New FCard()
        btnTogglePassword = New Label()
        txtPassword = New TextBox()
        lblPasswordTitle = New Label()
        cardEmailBox = New FCard()
        txtEmail = New TextBox()
        lblEmailTitle = New Label()
        lblSignInDesc = New Label()
        lblWelcome = New Label()
        pnlRoleSwitcher = New FCard()
        btnRoleDoctor = New FButton()
        btnRoleReceptionist = New FButton()
        btnRoleAdmin = New FButton()
        leftPanel.SuspendLayout()
        cardLogo.SuspendLayout()
        rightPanel.SuspendLayout()
        cardLogin.SuspendLayout()
        cardPasswordBox.SuspendLayout()
        cardEmailBox.SuspendLayout()
        pnlRoleSwitcher.SuspendLayout()
        SuspendLayout()
        ' 
        ' leftPanel
        ' 
        leftPanel.BackColor = Color.FromArgb(CByte(17), CByte(54), CByte(70))
        leftPanel.Controls.Add(lblFooterBrand)
        leftPanel.Controls.Add(lblHeroSubtitle)
        leftPanel.Controls.Add(lblHeroTitle)
        leftPanel.Controls.Add(cardLogo)
        leftPanel.Dock = DockStyle.Left
        leftPanel.Location = New Point(0, 0)
        leftPanel.Name = "leftPanel"
        leftPanel.Size = New Size(400, 729)
        leftPanel.TabIndex = 0
        ' 
        ' lblFooterBrand
        ' 
        lblFooterBrand.AutoSize = True
        lblFooterBrand.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblFooterBrand.ForeColor = Color.FromArgb(CByte(155), CByte(185), CByte(200))
        lblFooterBrand.Location = New Point(42, 665)
        lblFooterBrand.Name = "lblFooterBrand"
        lblFooterBrand.Size = New Size(266, 13)
        lblFooterBrand.TabIndex = 3
        lblFooterBrand.Text = "UNIVERSITY OF CALOOCAN CITY • HEALTH CLINIC"
        ' 
        ' lblHeroSubtitle
        ' 
        lblHeroSubtitle.AutoSize = True
        lblHeroSubtitle.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblHeroSubtitle.ForeColor = Color.FromArgb(CByte(180), CByte(204), CByte(212))
        lblHeroSubtitle.Location = New Point(42, 230)
        lblHeroSubtitle.Name = "lblHeroSubtitle"
        lblHeroSubtitle.Size = New Size(296, 51)
        lblHeroSubtitle.TabIndex = 2
        lblHeroSubtitle.Text = "A focused clinical operations workspace for" & vbCrLf & "appointments, patient records, consultations, and" & vbCrLf & "clinic reporting."
        ' 
        ' lblHeroTitle
        ' 
        lblHeroTitle.AutoSize = True
        lblHeroTitle.Font = New Font("Segoe UI", 24.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblHeroTitle.ForeColor = Color.White
        lblHeroTitle.Location = New Point(42, 132)
        lblHeroTitle.Name = "lblHeroTitle"
        lblHeroTitle.Size = New Size(281, 90)
        lblHeroTitle.TabIndex = 1
        lblHeroTitle.Text = "Care coordination," & vbCrLf & "clearly managed."
        ' 
        ' cardLogo
        ' 
        cardLogo.BackColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        cardLogo.BorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        cardLogo.BorderHoverColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        cardLogo.BorderRadius = 12
        cardLogo.BorderSize = 0
        cardLogo.Controls.Add(lblLogo)
        cardLogo.EnableShadow = True
        cardLogo.HoverTintColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        cardLogo.Location = New Point(42, 42)
        cardLogo.Name = "cardLogo"
        cardLogo.Padding = New Padding(12)
        cardLogo.ShadowDepth = 6
        cardLogo.Size = New Size(48, 48)
        cardLogo.TabIndex = 0
        ' 
        ' lblLogo
        ' 
        lblLogo.AutoSize = True
        lblLogo.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblLogo.ForeColor = Color.White
        lblLogo.Location = New Point(10, 8)
        lblLogo.Name = "lblLogo"
        lblLogo.Size = New Size(29, 30)
        lblLogo.TabIndex = 0
        lblLogo.Text = "+"
        lblLogo.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' rightPanel
        ' 
        rightPanel.BackColor = Color.FromArgb(CByte(246), CByte(248), CByte(250))
        rightPanel.Controls.Add(cardLogin)
        rightPanel.Dock = DockStyle.Fill
        rightPanel.Location = New Point(400, 0)
        rightPanel.Name = "rightPanel"
        rightPanel.Size = New Size(608, 729)
        rightPanel.TabIndex = 1
        ' 
        ' cardLogin
        ' 
        cardLogin.BackColor = Color.White
        cardLogin.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardLogin.BorderHoverColor = Color.FromArgb(CByte(215), CByte(225), CByte(230))
        cardLogin.BorderRadius = 12
        cardLogin.BorderSize = 1
        cardLogin.Controls.Add(lnkForgotPassword)
        cardLogin.Controls.Add(lnkFirstTime)
        cardLogin.Controls.Add(lblNotice)
        cardLogin.Controls.Add(btnSignIn)
        cardLogin.Controls.Add(cardPasswordBox)
        cardLogin.Controls.Add(lblPasswordTitle)
        cardLogin.Controls.Add(cardEmailBox)
        cardLogin.Controls.Add(lblEmailTitle)
        cardLogin.Controls.Add(lblSignInDesc)
        cardLogin.Controls.Add(lblWelcome)
        cardLogin.EnableShadow = True
        cardLogin.HoverTintColor = Color.White
        cardLogin.Location = New Point(126, 120)
        cardLogin.Name = "cardLogin"
        cardLogin.Padding = New Padding(24)
        cardLogin.ShadowDepth = 8
        cardLogin.Size = New Size(356, 370)
        cardLogin.TabIndex = 0
        ' 
        ' lnkForgotPassword
        ' 
        lnkForgotPassword.ActiveLinkColor = Color.FromArgb(CByte(23), CByte(105), CByte(90))
        lnkForgotPassword.AutoSize = True
        lnkForgotPassword.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lnkForgotPassword.LinkBehavior = LinkBehavior.HoverUnderline
        lnkForgotPassword.LinkColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        lnkForgotPassword.Location = New Point(230, 230)
        lnkForgotPassword.Name = "lnkForgotPassword"
        lnkForgotPassword.Size = New Size(100, 13)
        lnkForgotPassword.TabIndex = 10
        lnkForgotPassword.TabStop = True
        lnkForgotPassword.Text = "Forgot password?"
        lnkForgotPassword.VisitedLinkColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        ' 
        ' lnkFirstTime
        ' 
        lnkFirstTime.ActiveLinkColor = Color.FromArgb(CByte(23), CByte(105), CByte(90))
        lnkFirstTime.AutoSize = True
        lnkFirstTime.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lnkFirstTime.LinkBehavior = LinkBehavior.HoverUnderline
        lnkFirstTime.LinkColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        lnkFirstTime.Location = New Point(26, 335)
        lnkFirstTime.Name = "lnkFirstTime"
        lnkFirstTime.Size = New Size(203, 13)
        lnkFirstTime.TabIndex = 9
        lnkFirstTime.TabStop = True
        lnkFirstTime.Text = "First time signing in? Enter invite code"
        lnkFirstTime.VisitedLinkColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        ' 
        ' lblNotice
        ' 
        lblNotice.AutoSize = True
        lblNotice.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblNotice.ForeColor = Color.FromArgb(CByte(90), CByte(110), CByte(120))
        lblNotice.Location = New Point(26, 305)
        lblNotice.Name = "lblNotice"
        lblNotice.Size = New Size(160, 12)
        lblNotice.TabIndex = 8
        lblNotice.Text = "⦿  Authorized clinic personnel only"
        ' 
        ' btnSignIn
        ' 
        btnSignIn.BackColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        btnSignIn.BorderColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        btnSignIn.BorderRadius = 8
        btnSignIn.BorderSize = 0
        btnSignIn.FlatAppearance.BorderSize = 0
        btnSignIn.FlatStyle = FlatStyle.Flat
        btnSignIn.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSignIn.ForeColor = Color.White
        btnSignIn.Location = New Point(24, 250)
        btnSignIn.MouseEnterBackColor = Color.FromArgb(CByte(23), CByte(105), CByte(90))
        btnSignIn.MouseEnterBorderColor = Color.FromArgb(CByte(23), CByte(105), CByte(90))
        btnSignIn.MouseEnterBorderSize = 0
        btnSignIn.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnSignIn.MouseEnterForeColor = Color.White
        btnSignIn.MouseLeaveBackColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        btnSignIn.MouseLeaveBorderColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        btnSignIn.MouseLeaveBorderSize = 0
        btnSignIn.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnSignIn.MouseLeaveForeColor = Color.White
        btnSignIn.Name = "btnSignIn"
        btnSignIn.Size = New Size(116, 34)
        btnSignIn.TabIndex = 7
        btnSignIn.Text = "Sign in securely"
        btnSignIn.UseVisualStyleBackColor = False
        ' 
        ' cardPasswordBox
        ' 
        cardPasswordBox.BackColor = Color.White
        cardPasswordBox.BorderColor = Color.FromArgb(CByte(220), CByte(228), CByte(232))
        cardPasswordBox.BorderHoverColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        cardPasswordBox.BorderRadius = 8
        cardPasswordBox.BorderSize = 1
        cardPasswordBox.Controls.Add(btnTogglePassword)
        cardPasswordBox.Controls.Add(txtPassword)
        cardPasswordBox.EnableShadow = False
        cardPasswordBox.HoverTintColor = Color.White
        cardPasswordBox.Location = New Point(24, 178)
        cardPasswordBox.Name = "cardPasswordBox"
        cardPasswordBox.Padding = New Padding(10, 8, 10, 8)
        cardPasswordBox.ShadowDepth = 2
        cardPasswordBox.Size = New Size(308, 36)
        cardPasswordBox.TabIndex = 6
        ' 
        ' btnTogglePassword
        ' 
        btnTogglePassword.BackColor = Color.Transparent
        btnTogglePassword.Cursor = Cursors.Hand
        btnTogglePassword.Font = New Font("Segoe UI", 9.5F)
        btnTogglePassword.ForeColor = Color.FromArgb(CByte(120), CByte(140), CByte(150))
        btnTogglePassword.Location = New Point(276, 7)
        btnTogglePassword.Name = "btnTogglePassword"
        btnTogglePassword.Size = New Size(24, 20)
        btnTogglePassword.TabIndex = 1
        btnTogglePassword.Text = "👁"
        btnTogglePassword.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' txtPassword
        ' 
        txtPassword.BorderStyle = BorderStyle.None
        txtPassword.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtPassword.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        txtPassword.Location = New Point(10, 9)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(255, 17)
        txtPassword.TabIndex = 0
        txtPassword.UseSystemPasswordChar = True
        ' 
        ' lblPasswordTitle
        ' 
        lblPasswordTitle.AutoSize = True
        lblPasswordTitle.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPasswordTitle.ForeColor = Color.FromArgb(CByte(80), CByte(100), CByte(112))
        lblPasswordTitle.Location = New Point(24, 160)
        lblPasswordTitle.Name = "lblPasswordTitle"
        lblPasswordTitle.Size = New Size(61, 12)
        lblPasswordTitle.TabIndex = 5
        lblPasswordTitle.Text = "PASSWORD"
        ' 
        ' cardEmailBox
        ' 
        cardEmailBox.BackColor = Color.White
        cardEmailBox.BorderColor = Color.FromArgb(CByte(220), CByte(228), CByte(232))
        cardEmailBox.BorderHoverColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        cardEmailBox.BorderRadius = 8
        cardEmailBox.BorderSize = 1
        cardEmailBox.Controls.Add(txtEmail)
        cardEmailBox.EnableShadow = False
        cardEmailBox.HoverTintColor = Color.White
        cardEmailBox.Location = New Point(24, 114)
        cardEmailBox.Name = "cardEmailBox"
        cardEmailBox.Padding = New Padding(10, 8, 10, 8)
        cardEmailBox.ShadowDepth = 2
        cardEmailBox.Size = New Size(308, 36)
        cardEmailBox.TabIndex = 4
        ' 
        ' txtEmail
        ' 
        txtEmail.BorderStyle = BorderStyle.None
        txtEmail.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtEmail.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        txtEmail.Location = New Point(10, 9)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(288, 17)
        txtEmail.TabIndex = 0
        ' 
        ' lblEmailTitle
        ' 
        lblEmailTitle.AutoSize = True
        lblEmailTitle.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblEmailTitle.ForeColor = Color.FromArgb(CByte(80), CByte(100), CByte(112))
        lblEmailTitle.Location = New Point(24, 96)
        lblEmailTitle.Name = "lblEmailTitle"
        lblEmailTitle.Size = New Size(83, 12)
        lblEmailTitle.TabIndex = 3
        lblEmailTitle.Text = "EMAIL ADDRESS"
        ' 
        ' lblSignInDesc
        ' 
        lblSignInDesc.AutoSize = True
        lblSignInDesc.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSignInDesc.ForeColor = Color.FromArgb(CByte(85), CByte(105), CByte(118))
        lblSignInDesc.Location = New Point(24, 60)
        lblSignInDesc.Name = "lblSignInDesc"
        lblSignInDesc.Size = New Size(234, 15)
        lblSignInDesc.TabIndex = 1
        lblSignInDesc.Text = "Sign in to continue to the clinic workspace."
        ' 
        ' lblWelcome
        ' 
        lblWelcome.AutoSize = True
        lblWelcome.Font = New Font("Segoe UI", 16.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblWelcome.ForeColor = Color.FromArgb(CByte(22), CByte(51), CByte(65))
        lblWelcome.Location = New Point(22, 24)
        lblWelcome.Name = "lblWelcome"
        lblWelcome.Size = New Size(155, 30)
        lblWelcome.TabIndex = 0
        lblWelcome.Text = "Welcome back"
        ' 
        ' pnlRoleSwitcher
        ' 
        pnlRoleSwitcher.BackColor = Color.FromArgb(CByte(243), CByte(246), CByte(248))
        pnlRoleSwitcher.BorderColor = Color.FromArgb(CByte(235), CByte(240), CByte(243))
        pnlRoleSwitcher.BorderHoverColor = Color.FromArgb(CByte(235), CByte(240), CByte(243))
        pnlRoleSwitcher.BorderRadius = 8
        pnlRoleSwitcher.BorderSize = 1
        pnlRoleSwitcher.Controls.Add(btnRoleDoctor)
        pnlRoleSwitcher.Controls.Add(btnRoleReceptionist)
        pnlRoleSwitcher.Controls.Add(btnRoleAdmin)
        pnlRoleSwitcher.EnableShadow = False
        pnlRoleSwitcher.HoverTintColor = Color.FromArgb(CByte(243), CByte(246), CByte(248))
        pnlRoleSwitcher.Location = New Point(24, 94)
        pnlRoleSwitcher.Name = "pnlRoleSwitcher"
        pnlRoleSwitcher.Padding = New Padding(2)
        pnlRoleSwitcher.ShadowDepth = 1
        pnlRoleSwitcher.Size = New Size(308, 38)
        pnlRoleSwitcher.TabIndex = 2
        pnlRoleSwitcher.Visible = False
        ' 
        ' btnRoleDoctor
        ' 
        btnRoleDoctor.BackColor = Color.White
        btnRoleDoctor.BorderColor = Color.FromArgb(CByte(220), CByte(230), CByte(235))
        btnRoleDoctor.BorderRadius = 6
        btnRoleDoctor.BorderSize = 1
        btnRoleDoctor.FlatAppearance.BorderSize = 0
        btnRoleDoctor.FlatStyle = FlatStyle.Flat
        btnRoleDoctor.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRoleDoctor.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnRoleDoctor.Location = New Point(4, 3)
        btnRoleDoctor.MouseEnterBackColor = Color.White
        btnRoleDoctor.MouseEnterBorderColor = Color.FromArgb(CByte(220), CByte(230), CByte(235))
        btnRoleDoctor.MouseEnterBorderSize = 1
        btnRoleDoctor.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnRoleDoctor.MouseEnterForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnRoleDoctor.MouseLeaveBackColor = Color.White
        btnRoleDoctor.MouseLeaveBorderColor = Color.FromArgb(CByte(220), CByte(230), CByte(235))
        btnRoleDoctor.MouseLeaveBorderSize = 1
        btnRoleDoctor.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnRoleDoctor.MouseLeaveForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnRoleDoctor.Name = "btnRoleDoctor"
        btnRoleDoctor.Size = New Size(96, 30)
        btnRoleDoctor.TabIndex = 0
        btnRoleDoctor.Text = "Doctor"
        btnRoleDoctor.UseVisualStyleBackColor = False
        ' 
        ' btnRoleReceptionist
        ' 
        btnRoleReceptionist.BackColor = Color.FromArgb(CByte(243), CByte(246), CByte(248))
        btnRoleReceptionist.BorderColor = Color.FromArgb(CByte(243), CByte(246), CByte(248))
        btnRoleReceptionist.BorderRadius = 6
        btnRoleReceptionist.BorderSize = 0
        btnRoleReceptionist.FlatAppearance.BorderSize = 0
        btnRoleReceptionist.FlatStyle = FlatStyle.Flat
        btnRoleReceptionist.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnRoleReceptionist.ForeColor = Color.FromArgb(CByte(120), CByte(140), CByte(150))
        btnRoleReceptionist.Location = New Point(103, 3)
        btnRoleReceptionist.MouseEnterBackColor = Color.FromArgb(CByte(235), CByte(240), CByte(243))
        btnRoleReceptionist.MouseEnterBorderColor = Color.FromArgb(CByte(235), CByte(240), CByte(243))
        btnRoleReceptionist.MouseEnterBorderSize = 0
        btnRoleReceptionist.MouseEnterFont = New Font("Segoe UI", 8.5F)
        btnRoleReceptionist.MouseEnterForeColor = Color.FromArgb(CByte(80), CByte(100), CByte(110))
        btnRoleReceptionist.MouseLeaveBackColor = Color.FromArgb(CByte(243), CByte(246), CByte(248))
        btnRoleReceptionist.MouseLeaveBorderColor = Color.FromArgb(CByte(243), CByte(246), CByte(248))
        btnRoleReceptionist.MouseLeaveBorderSize = 0
        btnRoleReceptionist.MouseLeaveFont = New Font("Segoe UI", 8.5F)
        btnRoleReceptionist.MouseLeaveForeColor = Color.FromArgb(CByte(120), CByte(140), CByte(150))
        btnRoleReceptionist.Name = "btnRoleReceptionist"
        btnRoleReceptionist.Size = New Size(102, 30)
        btnRoleReceptionist.TabIndex = 1
        btnRoleReceptionist.Text = "Receptionist"
        btnRoleReceptionist.UseVisualStyleBackColor = False
        ' 
        ' btnRoleAdmin
        ' 
        btnRoleAdmin.BackColor = Color.FromArgb(CByte(243), CByte(246), CByte(248))
        btnRoleAdmin.BorderColor = Color.FromArgb(CByte(243), CByte(246), CByte(248))
        btnRoleAdmin.BorderRadius = 6
        btnRoleAdmin.BorderSize = 0
        btnRoleAdmin.FlatAppearance.BorderSize = 0
        btnRoleAdmin.FlatStyle = FlatStyle.Flat
        btnRoleAdmin.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnRoleAdmin.ForeColor = Color.FromArgb(CByte(120), CByte(140), CByte(150))
        btnRoleAdmin.Location = New Point(208, 3)
        btnRoleAdmin.MouseEnterBackColor = Color.FromArgb(CByte(235), CByte(240), CByte(243))
        btnRoleAdmin.MouseEnterBorderColor = Color.FromArgb(CByte(235), CByte(240), CByte(243))
        btnRoleAdmin.MouseEnterBorderSize = 0
        btnRoleAdmin.MouseEnterFont = New Font("Segoe UI", 8.5F)
        btnRoleAdmin.MouseEnterForeColor = Color.FromArgb(CByte(80), CByte(100), CByte(110))
        btnRoleAdmin.MouseLeaveBackColor = Color.FromArgb(CByte(243), CByte(246), CByte(248))
        btnRoleAdmin.MouseLeaveBorderColor = Color.FromArgb(CByte(243), CByte(246), CByte(248))
        btnRoleAdmin.MouseLeaveBorderSize = 0
        btnRoleAdmin.MouseLeaveFont = New Font("Segoe UI", 8.5F)
        btnRoleAdmin.MouseLeaveForeColor = Color.FromArgb(CByte(120), CByte(140), CByte(150))
        btnRoleAdmin.Name = "btnRoleAdmin"
        btnRoleAdmin.Size = New Size(96, 30)
        btnRoleAdmin.TabIndex = 2
        btnRoleAdmin.Text = "Admin"
        btnRoleAdmin.UseVisualStyleBackColor = False
        ' 
        ' LoginForm
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1008, 729)
        Controls.Add(rightPanel)
        Controls.Add(leftPanel)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "LoginForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Clinic Management - Sign In"
        leftPanel.ResumeLayout(False)
        leftPanel.PerformLayout()
        cardLogo.ResumeLayout(False)
        cardLogo.PerformLayout()
        rightPanel.ResumeLayout(False)
        cardLogin.ResumeLayout(False)
        cardLogin.PerformLayout()
        cardPasswordBox.ResumeLayout(False)
        cardPasswordBox.PerformLayout()
        cardEmailBox.ResumeLayout(False)
        cardEmailBox.PerformLayout()
        pnlRoleSwitcher.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents leftPanel As Panel
    Friend WithEvents rightPanel As Panel
    Friend WithEvents cardLogo As FCard
    Friend WithEvents lblLogo As Label
    Friend WithEvents lblHeroTitle As Label
    Friend WithEvents lblHeroSubtitle As Label
    Friend WithEvents lblFooterBrand As Label
    Friend WithEvents cardLogin As FCard
    Friend WithEvents lblWelcome As Label
    Friend WithEvents lblSignInDesc As Label
    Friend WithEvents pnlRoleSwitcher As FCard
    Friend WithEvents btnRoleDoctor As FButton
    Friend WithEvents btnRoleReceptionist As FButton
    Friend WithEvents btnRoleAdmin As FButton
    Friend WithEvents lblEmailTitle As Label
    Friend WithEvents cardEmailBox As FCard
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents lblPasswordTitle As Label
    Friend WithEvents cardPasswordBox As FCard
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnSignIn As FButton
    Friend WithEvents lblNotice As Label
    Friend WithEvents lnkFirstTime As LinkLabel
    Friend WithEvents lnkForgotPassword As LinkLabel
    Friend WithEvents btnTogglePassword As Label

End Class
