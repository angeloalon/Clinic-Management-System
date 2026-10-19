<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ForgotPasswordDialog
    Inherits System.Windows.Forms.Form

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
        cardMain = New Ferrando.UI.WinForms.Controles.FCard()
        lblTitle = New Label()
        lblSubtitle = New Label()
        cardAdminInfo = New Ferrando.UI.WinForms.Controles.FCard()
        lblAdminInfoTitle = New Label()
        lblAdminContact = New Label()
        lblEmail = New Label()
        cardEmail = New Ferrando.UI.WinForms.Controles.FCard()
        txtEmail = New TextBox()
        btnRequestReset = New Ferrando.UI.WinForms.Controles.FButton()
        chkAdminOverride = New CheckBox()
        pnlAdminOverride = New Panel()
        lblAdminKey = New Label()
        cardAdminKey = New Ferrando.UI.WinForms.Controles.FCard()
        txtAdminKey = New TextBox()
        lblNewPass = New Label()
        cardNewPass = New Ferrando.UI.WinForms.Controles.FCard()
        txtNewPass = New TextBox()
        btnImmediateReset = New Ferrando.UI.WinForms.Controles.FButton()
        btnClose = New Ferrando.UI.WinForms.Controles.FButton()
        cardMain.SuspendLayout()
        cardAdminInfo.SuspendLayout()
        cardEmail.SuspendLayout()
        pnlAdminOverride.SuspendLayout()
        cardAdminKey.SuspendLayout()
        cardNewPass.SuspendLayout()
        SuspendLayout()
        ' 
        ' cardMain
        ' 
        cardMain.BackColor = Color.White
        cardMain.BorderColor = Color.FromArgb(232, 237, 240)
        cardMain.BorderHoverColor = Color.FromArgb(232, 237, 240)
        cardMain.BorderRadius = 12
        cardMain.BorderSize = 1
        cardMain.Controls.Add(btnClose)
        cardMain.Controls.Add(pnlAdminOverride)
        cardMain.Controls.Add(chkAdminOverride)
        cardMain.Controls.Add(btnRequestReset)
        cardMain.Controls.Add(cardEmail)
        cardMain.Controls.Add(lblEmail)
        cardMain.Controls.Add(cardAdminInfo)
        cardMain.Controls.Add(lblSubtitle)
        cardMain.Controls.Add(lblTitle)
        cardMain.Dock = DockStyle.Fill
        cardMain.EnableShadow = False
        cardMain.HoverTintColor = Color.White
        cardMain.Location = New Point(16, 16)
        cardMain.Name = "cardMain"
        cardMain.Padding = New Padding(24)
        cardMain.ShadowDepth = 2
        cardMain.Size = New Size(448, 568)
        cardMain.TabIndex = 0
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.FromArgb(20, 45, 55)
        lblTitle.Location = New Point(24, 20)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(215, 25)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Staff Password Recovery"
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSubtitle.ForeColor = Color.FromArgb(100, 115, 125)
        lblSubtitle.Location = New Point(24, 48)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(400, 36)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "To ensure campus health record security, password resets are coordinated with the Clinic Administrator."
        ' 
        ' cardAdminInfo
        ' 
        cardAdminInfo.BackColor = Color.FromArgb(245, 248, 250)
        cardAdminInfo.BorderColor = Color.FromArgb(225, 235, 240)
        cardAdminInfo.BorderHoverColor = Color.FromArgb(225, 235, 240)
        cardAdminInfo.BorderRadius = 8
        cardAdminInfo.BorderSize = 1
        cardAdminInfo.Controls.Add(lblAdminContact)
        cardAdminInfo.Controls.Add(lblAdminInfoTitle)
        cardAdminInfo.EnableShadow = False
        cardAdminInfo.HoverTintColor = Color.FromArgb(245, 248, 250)
        cardAdminInfo.Location = New Point(24, 90)
        cardAdminInfo.Name = "cardAdminInfo"
        cardAdminInfo.Padding = New Padding(12)
        cardAdminInfo.ShadowDepth = 1
        cardAdminInfo.Size = New Size(400, 85)
        cardAdminInfo.TabIndex = 2
        ' 
        ' lblAdminInfoTitle
        ' 
        lblAdminInfoTitle.AutoSize = True
        lblAdminInfoTitle.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblAdminInfoTitle.ForeColor = Color.FromArgb(35, 137, 120)
        lblAdminInfoTitle.Location = New Point(10, 8)
        lblAdminInfoTitle.Name = "lblAdminInfoTitle"
        lblAdminInfoTitle.Size = New Size(198, 13)
        lblAdminInfoTitle.TabIndex = 0
        lblAdminInfoTitle.Text = "CLINIC ADMINISTRATION CONTACT"
        ' 
        ' lblAdminContact
        ' 
        lblAdminContact.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblAdminContact.ForeColor = Color.FromArgb(40, 60, 70)
        lblAdminContact.Location = New Point(10, 26)
        lblAdminContact.Name = "lblAdminContact"
        lblAdminContact.Size = New Size(378, 50)
        lblAdminContact.TabIndex = 1
        lblAdminContact.Text = "Administrator: Rosa Dela Cruz (Clinic Administrator)" & vbCrLf & "Office: UCC Health Clinic Admin Office, South Campus" & vbCrLf & "Email: rosa.delacruz@uccclinic.edu.ph  |  Ext. 104"
        ' 
        ' lblEmail
        ' 
        lblEmail.AutoSize = True
        lblEmail.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblEmail.ForeColor = Color.FromArgb(80, 100, 112)
        lblEmail.Location = New Point(24, 186)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(130, 13)
        lblEmail.TabIndex = 3
        lblEmail.Text = "REGISTERED WORK EMAIL"
        ' 
        ' cardEmail
        ' 
        cardEmail.BackColor = Color.White
        cardEmail.BorderColor = Color.FromArgb(220, 228, 232)
        cardEmail.BorderHoverColor = Color.FromArgb(35, 137, 120)
        cardEmail.BorderRadius = 8
        cardEmail.BorderSize = 1
        cardEmail.Controls.Add(txtEmail)
        cardEmail.EnableShadow = False
        cardEmail.HoverTintColor = Color.White
        cardEmail.Location = New Point(24, 204)
        cardEmail.Name = "cardEmail"
        cardEmail.Padding = New Padding(10, 8, 10, 8)
        cardEmail.ShadowDepth = 1
        cardEmail.Size = New Size(400, 36)
        cardEmail.TabIndex = 4
        ' 
        ' txtEmail
        ' 
        txtEmail.BorderStyle = BorderStyle.None
        txtEmail.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtEmail.ForeColor = Color.FromArgb(30, 45, 55)
        txtEmail.Location = New Point(10, 9)
        txtEmail.Name = "txtEmail"
        txtEmail.PlaceholderText = "e.g. elena.cruz@uccclinic.edu.ph"
        txtEmail.Size = New Size(380, 17)
        txtEmail.TabIndex = 0
        ' 
        ' btnRequestReset
        ' 
        btnRequestReset.BackColor = Color.FromArgb(29, 124, 107)
        btnRequestReset.BorderColor = Color.FromArgb(29, 124, 107)
        btnRequestReset.BorderRadius = 8
        btnRequestReset.BorderSize = 0
        btnRequestReset.FlatAppearance.BorderSize = 0
        btnRequestReset.FlatStyle = FlatStyle.Flat
        btnRequestReset.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRequestReset.ForeColor = Color.White
        btnRequestReset.Location = New Point(24, 250)
        btnRequestReset.Name = "btnRequestReset"
        btnRequestReset.Size = New Size(220, 34)
        btnRequestReset.TabIndex = 5
        btnRequestReset.Text = "Log Admin Reset Request"
        btnRequestReset.UseVisualStyleBackColor = False
        ' 
        ' chkAdminOverride
        ' 
        chkAdminOverride.AutoSize = True
        chkAdminOverride.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chkAdminOverride.ForeColor = Color.FromArgb(60, 80, 90)
        chkAdminOverride.Location = New Point(24, 300)
        chkAdminOverride.Name = "chkAdminOverride"
        chkAdminOverride.Size = New Size(295, 19)
        chkAdminOverride.TabIndex = 6
        chkAdminOverride.Text = "I have an administrator present for immediate reset"
        chkAdminOverride.UseVisualStyleBackColor = True
        ' 
        ' pnlAdminOverride
        ' 
        pnlAdminOverride.Controls.Add(btnImmediateReset)
        pnlAdminOverride.Controls.Add(cardNewPass)
        pnlAdminOverride.Controls.Add(lblNewPass)
        pnlAdminOverride.Controls.Add(cardAdminKey)
        pnlAdminOverride.Controls.Add(lblAdminKey)
        pnlAdminOverride.Location = New Point(24, 328)
        pnlAdminOverride.Name = "pnlAdminOverride"
        pnlAdminOverride.Size = New Size(400, 180)
        pnlAdminOverride.TabIndex = 7
        pnlAdminOverride.Visible = False
        ' 
        ' lblAdminKey
        ' 
        lblAdminKey.AutoSize = True
        lblAdminKey.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblAdminKey.ForeColor = Color.FromArgb(80, 100, 112)
        lblAdminKey.Location = New Point(0, 4)
        lblAdminKey.Name = "lblAdminKey"
        lblAdminKey.Size = New Size(230, 13)
        lblAdminKey.TabIndex = 0
        lblAdminKey.Text = "ADMINISTRATOR PASSWORD / MASTER KEY"
        ' 
        ' cardAdminKey
        ' 
        cardAdminKey.BackColor = Color.White
        cardAdminKey.BorderColor = Color.FromArgb(220, 228, 232)
        cardAdminKey.BorderHoverColor = Color.FromArgb(35, 137, 120)
        cardAdminKey.BorderRadius = 8
        cardAdminKey.BorderSize = 1
        cardAdminKey.Controls.Add(txtAdminKey)
        cardAdminKey.EnableShadow = False
        cardAdminKey.HoverTintColor = Color.White
        cardAdminKey.Location = New Point(0, 22)
        cardAdminKey.Name = "cardAdminKey"
        cardAdminKey.Padding = New Padding(10, 8, 10, 8)
        cardAdminKey.ShadowDepth = 1
        cardAdminKey.Size = New Size(400, 36)
        cardAdminKey.TabIndex = 1
        ' 
        ' txtAdminKey
        ' 
        txtAdminKey.BorderStyle = BorderStyle.None
        txtAdminKey.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtAdminKey.ForeColor = Color.FromArgb(30, 45, 55)
        txtAdminKey.Location = New Point(10, 9)
        txtAdminKey.Name = "txtAdminKey"
        txtAdminKey.PlaceholderText = "Enter admin password or master key"
        txtAdminKey.Size = New Size(380, 17)
        txtAdminKey.TabIndex = 0
        txtAdminKey.UseSystemPasswordChar = True
        ' 
        ' lblNewPass
        ' 
        lblNewPass.AutoSize = True
        lblNewPass.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblNewPass.ForeColor = Color.FromArgb(80, 100, 112)
        lblNewPass.Location = New Point(0, 64)
        lblNewPass.Name = "lblNewPass"
        lblNewPass.Size = New Size(95, 13)
        lblNewPass.TabIndex = 2
        lblNewPass.Text = "NEW PASSWORD"
        ' 
        ' cardNewPass
        ' 
        cardNewPass.BackColor = Color.White
        cardNewPass.BorderColor = Color.FromArgb(220, 228, 232)
        cardNewPass.BorderHoverColor = Color.FromArgb(35, 137, 120)
        cardNewPass.BorderRadius = 8
        cardNewPass.BorderSize = 1
        cardNewPass.Controls.Add(txtNewPass)
        cardNewPass.EnableShadow = False
        cardNewPass.HoverTintColor = Color.White
        cardNewPass.Location = New Point(0, 82)
        cardNewPass.Name = "cardNewPass"
        cardNewPass.Padding = New Padding(10, 8, 10, 8)
        cardNewPass.ShadowDepth = 1
        cardNewPass.Size = New Size(400, 36)
        cardNewPass.TabIndex = 3
        ' 
        ' txtNewPass
        ' 
        txtNewPass.BorderStyle = BorderStyle.None
        txtNewPass.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtNewPass.ForeColor = Color.FromArgb(30, 45, 55)
        txtNewPass.Location = New Point(10, 9)
        txtNewPass.Name = "txtNewPass"
        txtNewPass.PlaceholderText = "At least 8 characters"
        txtNewPass.Size = New Size(380, 17)
        txtNewPass.TabIndex = 0
        txtNewPass.UseSystemPasswordChar = True
        ' 
        ' btnImmediateReset
        ' 
        btnImmediateReset.BackColor = Color.FromArgb(29, 124, 107)
        btnImmediateReset.BorderColor = Color.FromArgb(29, 124, 107)
        btnImmediateReset.BorderRadius = 8
        btnImmediateReset.BorderSize = 0
        btnImmediateReset.FlatAppearance.BorderSize = 0
        btnImmediateReset.FlatStyle = FlatStyle.Flat
        btnImmediateReset.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnImmediateReset.ForeColor = Color.White
        btnImmediateReset.Location = New Point(0, 130)
        btnImmediateReset.Name = "btnImmediateReset"
        btnImmediateReset.Size = New Size(180, 34)
        btnImmediateReset.TabIndex = 4
        btnImmediateReset.Text = "Reset Password Now"
        btnImmediateReset.UseVisualStyleBackColor = False
        ' 
        ' btnClose
        ' 
        btnClose.BackColor = Color.FromArgb(240, 244, 246)
        btnClose.BorderColor = Color.FromArgb(220, 228, 232)
        btnClose.BorderRadius = 8
        btnClose.BorderSize = 1
        btnClose.FlatAppearance.BorderSize = 0
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnClose.ForeColor = Color.FromArgb(80, 95, 105)
        btnClose.Location = New Point(24, 518)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(100, 32)
        btnClose.TabIndex = 8
        btnClose.Text = "Back to Sign In"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' ForgotPasswordDialog
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(240, 244, 246)
        ClientSize = New Size(480, 600)
        Controls.Add(cardMain)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "ForgotPasswordDialog"
        Padding = New Padding(16)
        StartPosition = FormStartPosition.CenterParent
        Text = "Forgot Password - UCC Health Clinic"
        cardMain.ResumeLayout(False)
        cardMain.PerformLayout()
        cardAdminInfo.ResumeLayout(False)
        cardAdminInfo.PerformLayout()
        cardEmail.ResumeLayout(False)
        cardEmail.PerformLayout()
        pnlAdminOverride.ResumeLayout(False)
        pnlAdminOverride.PerformLayout()
        cardAdminKey.ResumeLayout(False)
        cardAdminKey.PerformLayout()
        cardNewPass.ResumeLayout(False)
        cardNewPass.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents cardMain As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents cardAdminInfo As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblAdminInfoTitle As Label
    Friend WithEvents lblAdminContact As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents cardEmail As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents btnRequestReset As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents chkAdminOverride As CheckBox
    Friend WithEvents pnlAdminOverride As Panel
    Friend WithEvents lblAdminKey As Label
    Friend WithEvents cardAdminKey As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents txtAdminKey As TextBox
    Friend WithEvents lblNewPass As Label
    Friend WithEvents cardNewPass As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents txtNewPass As TextBox
    Friend WithEvents btnImmediateReset As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnClose As Ferrando.UI.WinForms.Controles.FButton

End Class
