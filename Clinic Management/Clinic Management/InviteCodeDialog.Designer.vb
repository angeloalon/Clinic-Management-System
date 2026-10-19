<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InviteCodeDialog
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
        cardCodeBox = New Ferrando.UI.WinForms.Controles.FCard()
        lblInviteCode = New Label()
        btnCopy = New Ferrando.UI.WinForms.Controles.FButton()
        lblNotice = New Label()
        lblStaffDetail = New Label()
        btnDone = New Ferrando.UI.WinForms.Controles.FButton()
        cardMain.SuspendLayout()
        cardCodeBox.SuspendLayout()
        SuspendLayout()
        ' 
        ' cardMain
        ' 
        cardMain.BackColor = Color.White
        cardMain.BorderColor = Color.FromArgb(232, 237, 240)
        cardMain.BorderHoverColor = Color.FromArgb(232, 237, 240)
        cardMain.BorderRadius = 12
        cardMain.BorderSize = 1
        cardMain.Controls.Add(btnDone)
        cardMain.Controls.Add(lblStaffDetail)
        cardMain.Controls.Add(lblNotice)
        cardMain.Controls.Add(cardCodeBox)
        cardMain.Controls.Add(lblSubtitle)
        cardMain.Controls.Add(lblTitle)
        cardMain.Dock = DockStyle.Fill
        cardMain.EnableShadow = False
        cardMain.HoverTintColor = Color.White
        cardMain.Location = New Point(0, 0)
        cardMain.Name = "cardMain"
        cardMain.Padding = New Padding(24)
        cardMain.ShadowDepth = 4
        cardMain.Size = New Size(420, 310)
        cardMain.TabIndex = 0
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(22, 51, 65)
        lblTitle.Location = New Point(24, 20)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(198, 25)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Staff Account Created"
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.Font = New Font("Segoe UI", 8.75F)
        lblSubtitle.ForeColor = Color.FromArgb(115, 138, 148)
        lblSubtitle.Location = New Point(24, 48)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(372, 36)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "Share this one-time invitation code with the staff member so they can set their password."
        ' 
        ' cardCodeBox
        ' 
        cardCodeBox.BackColor = Color.FromArgb(244, 247, 249)
        cardCodeBox.BorderColor = Color.FromArgb(210, 222, 228)
        cardCodeBox.BorderHoverColor = Color.FromArgb(210, 222, 228)
        cardCodeBox.BorderRadius = 8
        cardCodeBox.BorderSize = 1
        cardCodeBox.Controls.Add(btnCopy)
        cardCodeBox.Controls.Add(lblInviteCode)
        cardCodeBox.EnableShadow = False
        cardCodeBox.HoverTintColor = Color.FromArgb(244, 247, 249)
        cardCodeBox.Location = New Point(24, 96)
        cardCodeBox.Name = "cardCodeBox"
        cardCodeBox.ShadowDepth = 2
        cardCodeBox.Size = New Size(372, 54)
        cardCodeBox.TabIndex = 2
        ' 
        ' lblInviteCode
        ' 
        lblInviteCode.Font = New Font("Consolas", 16.0F, FontStyle.Bold)
        lblInviteCode.ForeColor = Color.FromArgb(35, 137, 120)
        lblInviteCode.Location = New Point(16, 12)
        lblInviteCode.Name = "lblInviteCode"
        lblInviteCode.Size = New Size(240, 30)
        lblInviteCode.TabIndex = 0
        lblInviteCode.Text = "K9X2-7M4P"
        lblInviteCode.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' btnCopy
        ' 
        btnCopy.BackColor = Color.White
        btnCopy.BorderColor = Color.FromArgb(210, 222, 228)
        btnCopy.BorderRadius = 6
        btnCopy.BorderSize = 1
        btnCopy.Cursor = Cursors.Hand
        btnCopy.FlatAppearance.BorderSize = 0
        btnCopy.FlatStyle = FlatStyle.Flat
        btnCopy.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnCopy.ForeColor = Color.FromArgb(30, 45, 55)
        btnCopy.Location = New Point(272, 10)
        btnCopy.Name = "btnCopy"
        btnCopy.Size = New Size(88, 34)
        btnCopy.TabIndex = 1
        btnCopy.Text = "Copy code"
        btnCopy.UseVisualStyleBackColor = False
        ' 
        ' lblNotice
        ' 
        lblNotice.Font = New Font("Segoe UI", 8.0F)
        lblNotice.ForeColor = Color.FromArgb(140, 155, 165)
        lblNotice.Location = New Point(24, 160)
        lblNotice.Name = "lblNotice"
        lblNotice.Size = New Size(372, 32)
        lblNotice.TabIndex = 3
        lblNotice.Text = "• Code expires in 72 hours. Shown once for security." & vbCrLf & "• Account status is set to Invited until first sign-in."
        ' 
        ' lblStaffDetail
        ' 
        lblStaffDetail.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        lblStaffDetail.ForeColor = Color.FromArgb(45, 60, 70)
        lblStaffDetail.Location = New Point(24, 202)
        lblStaffDetail.Name = "lblStaffDetail"
        lblStaffDetail.Size = New Size(372, 20)
        lblStaffDetail.TabIndex = 4
        lblStaffDetail.Text = "Staff: Dr. Maria Santos (Doctor)"
        ' 
        ' btnDone
        ' 
        btnDone.BackColor = Color.FromArgb(35, 137, 120)
        btnDone.BorderColor = Color.FromArgb(35, 137, 120)
        btnDone.BorderRadius = 8
        btnDone.BorderSize = 0
        btnDone.Cursor = Cursors.Hand
        btnDone.FlatAppearance.BorderSize = 0
        btnDone.FlatStyle = FlatStyle.Flat
        btnDone.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnDone.ForeColor = Color.White
        btnDone.Location = New Point(24, 240)
        btnDone.Name = "btnDone"
        btnDone.Size = New Size(372, 38)
        btnDone.TabIndex = 5
        btnDone.Text = "Done"
        btnDone.UseVisualStyleBackColor = False
        ' 
        ' InviteCodeDialog
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(420, 310)
        Controls.Add(cardMain)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "InviteCodeDialog"
        StartPosition = FormStartPosition.CenterParent
        Text = "Invitation Code"
        cardMain.ResumeLayout(False)
        cardMain.PerformLayout()
        cardCodeBox.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents cardMain As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents cardCodeBox As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblInviteCode As Label
    Friend WithEvents btnCopy As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents lblNotice As Label
    Friend WithEvents lblStaffDetail As Label
    Friend WithEvents btnDone As Ferrando.UI.WinForms.Controles.FButton

End Class
