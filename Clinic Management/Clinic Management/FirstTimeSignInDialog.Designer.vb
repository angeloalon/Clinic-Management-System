<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FirstTimeSignInDialog
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
        lblEmail = New Label()
        cardEmail = New Ferrando.UI.WinForms.Controles.FCard()
        txtEmail = New TextBox()
        lblCode = New Label()
        cardCode = New Ferrando.UI.WinForms.Controles.FCard()
        txtCode = New TextBox()
        lblNewPass = New Label()
        cardNewPass = New Ferrando.UI.WinForms.Controles.FCard()
        txtNewPass = New TextBox()
        lblConfirmPass = New Label()
        cardConfirmPass = New Ferrando.UI.WinForms.Controles.FCard()
        txtConfirmPass = New TextBox()
        btnActivate = New Ferrando.UI.WinForms.Controles.FButton()
        btnCancel = New Ferrando.UI.WinForms.Controles.FButton()
        cardMain.SuspendLayout()
        cardEmail.SuspendLayout()
        cardCode.SuspendLayout()
        cardNewPass.SuspendLayout()
        cardConfirmPass.SuspendLayout()
        SuspendLayout()
        ' 
        ' cardMain
        ' 
        cardMain.BackColor = Color.White
        cardMain.BorderColor = Color.FromArgb(232, 237, 240)
        cardMain.BorderHoverColor = Color.FromArgb(232, 237, 240)
        cardMain.BorderRadius = 12
        cardMain.BorderSize = 1
        cardMain.Controls.Add(btnCancel)
        cardMain.Controls.Add(btnActivate)
        cardMain.Controls.Add(cardConfirmPass)
        cardMain.Controls.Add(lblConfirmPass)
        cardMain.Controls.Add(cardNewPass)
        cardMain.Controls.Add(lblNewPass)
        cardMain.Controls.Add(cardCode)
        cardMain.Controls.Add(lblCode)
        cardMain.Controls.Add(cardEmail)
        cardMain.Controls.Add(lblEmail)
        cardMain.Controls.Add(lblSubtitle)
        cardMain.Controls.Add(lblTitle)
        cardMain.Dock = DockStyle.Fill
        cardMain.EnableShadow = False
        cardMain.HoverTintColor = Color.White
        cardMain.Location = Point.Empty
        cardMain.Name = "cardMain"
        cardMain.Padding = New Padding(24)
        cardMain.ShadowDepth = 4
        cardMain.Size = New Size(420, 440)
        cardMain.TabIndex = 0
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(22, 51, 65)
        lblTitle.Location = New Point(24, 18)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(245, 25)
        lblTitle.TabIndex = 0
        lblTitle.Text = "First Time Signing In?"
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.Font = New Font("Segoe UI", 8.5F)
        lblSubtitle.ForeColor = Color.FromArgb(115, 138, 148)
        lblSubtitle.Location = New Point(24, 46)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(372, 32)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "Enter your work email and the invitation code provided by your administrator to activate your account."
        ' 
        ' lblEmail
        ' 
        lblEmail.AutoSize = True
        lblEmail.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold)
        lblEmail.ForeColor = Color.FromArgb(80, 100, 112)
        lblEmail.Location = New Point(24, 88)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(74, 12)
        lblEmail.TabIndex = 2
        lblEmail.Text = "WORK EMAIL"
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
        cardEmail.Location = New Point(24, 104)
        cardEmail.Name = "cardEmail"
        cardEmail.Padding = New Padding(10, 8, 10, 8)
        cardEmail.ShadowDepth = 2
        cardEmail.Size = New Size(372, 36)
        cardEmail.TabIndex = 3
        ' 
        ' txtEmail
        ' 
        txtEmail.BorderStyle = BorderStyle.None
        txtEmail.Font = New Font("Segoe UI", 9.5F)
        txtEmail.ForeColor = Color.FromArgb(30, 45, 55)
        txtEmail.Location = New Point(10, 9)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(352, 17)
        txtEmail.TabIndex = 0
        ' 
        ' lblCode
        ' 
        lblCode.AutoSize = True
        lblCode.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold)
        lblCode.ForeColor = Color.FromArgb(80, 100, 112)
        lblCode.Location = New Point(24, 148)
        lblCode.Name = "lblCode"
        lblCode.Size = New Size(149, 12)
        lblCode.TabIndex = 4
        lblCode.Text = "INVITATION CODE (XXXX-XXXX)"
        ' 
        ' cardCode
        ' 
        cardCode.BackColor = Color.White
        cardCode.BorderColor = Color.FromArgb(220, 228, 232)
        cardCode.BorderHoverColor = Color.FromArgb(35, 137, 120)
        cardCode.BorderRadius = 8
        cardCode.BorderSize = 1
        cardCode.Controls.Add(txtCode)
        cardCode.EnableShadow = False
        cardCode.HoverTintColor = Color.White
        cardCode.Location = New Point(24, 164)
        cardCode.Name = "cardCode"
        cardCode.Padding = New Padding(10, 8, 10, 8)
        cardCode.ShadowDepth = 2
        cardCode.Size = New Size(372, 36)
        cardCode.TabIndex = 5
        ' 
        ' txtCode
        ' 
        txtCode.BorderStyle = BorderStyle.None
        txtCode.Font = New Font("Segoe UI", 9.5F)
        txtCode.ForeColor = Color.FromArgb(30, 45, 55)
        txtCode.Location = New Point(10, 9)
        txtCode.Name = "txtCode"
        txtCode.Size = New Size(352, 17)
        txtCode.TabIndex = 0
        ' 
        ' lblNewPass
        ' 
        lblNewPass.AutoSize = True
        lblNewPass.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold)
        lblNewPass.ForeColor = Color.FromArgb(80, 100, 112)
        lblNewPass.Location = New Point(24, 208)
        lblNewPass.Name = "lblNewPass"
        lblNewPass.Size = New Size(125, 12)
        lblNewPass.TabIndex = 6
        lblNewPass.Text = "CREATE PASSWORD (8+)"
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
        cardNewPass.Location = New Point(24, 224)
        cardNewPass.Name = "cardNewPass"
        cardNewPass.Padding = New Padding(10, 8, 10, 8)
        cardNewPass.ShadowDepth = 2
        cardNewPass.Size = New Size(372, 36)
        cardNewPass.TabIndex = 7
        ' 
        ' txtNewPass
        ' 
        txtNewPass.BorderStyle = BorderStyle.None
        txtNewPass.Font = New Font("Segoe UI", 9.5F)
        txtNewPass.ForeColor = Color.FromArgb(30, 45, 55)
        txtNewPass.Location = New Point(10, 9)
        txtNewPass.Name = "txtNewPass"
        txtNewPass.Size = New Size(352, 17)
        txtNewPass.TabIndex = 0
        txtNewPass.UseSystemPasswordChar = True
        ' 
        ' lblConfirmPass
        ' 
        lblConfirmPass.AutoSize = True
        lblConfirmPass.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold)
        lblConfirmPass.ForeColor = Color.FromArgb(80, 100, 112)
        lblConfirmPass.Location = New Point(24, 268)
        lblConfirmPass.Name = "lblConfirmPass"
        lblConfirmPass.Size = New Size(111, 12)
        lblConfirmPass.TabIndex = 8
        lblConfirmPass.Text = "CONFIRM PASSWORD"
        ' 
        ' cardConfirmPass
        ' 
        cardConfirmPass.BackColor = Color.White
        cardConfirmPass.BorderColor = Color.FromArgb(220, 228, 232)
        cardConfirmPass.BorderHoverColor = Color.FromArgb(35, 137, 120)
        cardConfirmPass.BorderRadius = 8
        cardConfirmPass.BorderSize = 1
        cardConfirmPass.Controls.Add(txtConfirmPass)
        cardConfirmPass.EnableShadow = False
        cardConfirmPass.HoverTintColor = Color.White
        cardConfirmPass.Location = New Point(24, 284)
        cardConfirmPass.Name = "cardConfirmPass"
        cardConfirmPass.Padding = New Padding(10, 8, 10, 8)
        cardConfirmPass.ShadowDepth = 2
        cardConfirmPass.Size = New Size(372, 36)
        cardConfirmPass.TabIndex = 9
        ' 
        ' txtConfirmPass
        ' 
        txtConfirmPass.BorderStyle = BorderStyle.None
        txtConfirmPass.Font = New Font("Segoe UI", 9.5F)
        txtConfirmPass.ForeColor = Color.FromArgb(30, 45, 55)
        txtConfirmPass.Location = New Point(10, 9)
        txtConfirmPass.Name = "txtConfirmPass"
        txtConfirmPass.Size = New Size(352, 17)
        txtConfirmPass.TabIndex = 0
        txtConfirmPass.UseSystemPasswordChar = True
        ' 
        ' btnActivate
        ' 
        btnActivate.BackColor = Color.FromArgb(29, 124, 107)
        btnActivate.BorderColor = Color.FromArgb(29, 124, 107)
        btnActivate.BorderRadius = 8
        btnActivate.BorderSize = 0
        btnActivate.Cursor = Cursors.Hand
        btnActivate.FlatAppearance.BorderSize = 0
        btnActivate.FlatStyle = FlatStyle.Flat
        btnActivate.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnActivate.ForeColor = Color.White
        btnActivate.Location = New Point(24, 344)
        btnActivate.MouseEnterBackColor = Color.FromArgb(23, 105, 90)
        btnActivate.MouseEnterBorderColor = Color.FromArgb(23, 105, 90)
        btnActivate.MouseEnterBorderSize = 0
        btnActivate.MouseEnterFont = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnActivate.MouseEnterForeColor = Color.White
        btnActivate.MouseLeaveBackColor = Color.FromArgb(29, 124, 107)
        btnActivate.MouseLeaveBorderColor = Color.FromArgb(29, 124, 107)
        btnActivate.MouseLeaveBorderSize = 0
        btnActivate.MouseLeaveFont = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnActivate.MouseLeaveForeColor = Color.White
        btnActivate.Name = "btnActivate"
        btnActivate.Size = New Size(372, 38)
        btnActivate.TabIndex = 10
        btnActivate.Text = "Activate Account & Continue"
        btnActivate.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.White
        btnCancel.BorderColor = Color.FromArgb(210, 222, 228)
        btnCancel.BorderRadius = 8
        btnCancel.BorderSize = 1
        btnCancel.Cursor = Cursors.Hand
        btnCancel.FlatAppearance.BorderSize = 0
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnCancel.ForeColor = Color.FromArgb(115, 138, 148)
        btnCancel.Location = New Point(24, 390)
        btnCancel.MouseEnterBackColor = Color.FromArgb(245, 249, 251)
        btnCancel.MouseEnterBorderColor = Color.FromArgb(29, 124, 107)
        btnCancel.MouseEnterBorderSize = 1
        btnCancel.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnCancel.MouseEnterForeColor = Color.FromArgb(23, 105, 90)
        btnCancel.MouseLeaveBackColor = Color.White
        btnCancel.MouseLeaveBorderColor = Color.FromArgb(210, 222, 228)
        btnCancel.MouseLeaveBorderSize = 1
        btnCancel.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnCancel.MouseLeaveForeColor = Color.FromArgb(115, 138, 148)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(372, 30)
        btnCancel.TabIndex = 11
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' FirstTimeSignInDialog
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(420, 440)
        Controls.Add(cardMain)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "FirstTimeSignInDialog"
        StartPosition = FormStartPosition.CenterParent
        Text = "First Time Sign-In"
        cardMain.ResumeLayout(False)
        cardMain.PerformLayout()
        cardEmail.ResumeLayout(False)
        cardEmail.PerformLayout()
        cardCode.ResumeLayout(False)
        cardCode.PerformLayout()
        cardNewPass.ResumeLayout(False)
        cardNewPass.PerformLayout()
        cardConfirmPass.ResumeLayout(False)
        cardConfirmPass.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents cardMain As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents cardEmail As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents lblCode As Label
    Friend WithEvents cardCode As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents txtCode As TextBox
    Friend WithEvents lblNewPass As Label
    Friend WithEvents cardNewPass As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents txtNewPass As TextBox
    Friend WithEvents lblConfirmPass As Label
    Friend WithEvents cardConfirmPass As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents txtConfirmPass As TextBox
    Friend WithEvents btnActivate As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnCancel As Ferrando.UI.WinForms.Controles.FButton

End Class
