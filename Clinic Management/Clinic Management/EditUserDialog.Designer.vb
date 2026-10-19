<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditUserDialog
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
        pnlHeader = New Panel()
        lblSubtitle = New Label()
        lblTitle = New Label()
        pnlBody = New Panel()
        cardClinicBox = New Ferrando.UI.WinForms.Controles.FCard()
        cboClinic = New ComboBox()
        lblClinicLabel = New Label()
        cardStatusBox = New Ferrando.UI.WinForms.Controles.FCard()
        cboStatus = New ComboBox()
        lblStatusLabel = New Label()
        cardRoleBox = New Ferrando.UI.WinForms.Controles.FCard()
        cboRole = New ComboBox()
        lblRoleLabel = New Label()
        lblStaffEmail = New Label()
        lblStaffName = New Label()
        btnCancel = New Ferrando.UI.WinForms.Controles.FButton()
        btnSave = New Ferrando.UI.WinForms.Controles.FButton()
        btnArchiveUser = New Ferrando.UI.WinForms.Controles.FButton()
        pnlHeader.SuspendLayout()
        pnlBody.SuspendLayout()
        cardClinicBox.SuspendLayout()
        cardStatusBox.SuspendLayout()
        cardRoleBox.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.White
        pnlHeader.Controls.Add(lblSubtitle)
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(464, 76)
        pnlHeader.TabIndex = 0
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.AutoSize = True
        lblSubtitle.Font = New Font("Segoe UI", 8.5F)
        lblSubtitle.ForeColor = Color.FromArgb(115, 138, 148)
        lblSubtitle.Location = New Point(24, 46)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(245, 15)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "Update staff role, access status, and clinic"
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(22, 51, 65)
        lblTitle.Location = New Point(22, 16)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(183, 25)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Edit Staff Account"
        ' 
        ' pnlBody
        ' 
        pnlBody.BackColor = Color.FromArgb(244, 247, 249)
        pnlBody.Controls.Add(cardClinicBox)
        pnlBody.Controls.Add(lblClinicLabel)
        pnlBody.Controls.Add(cardStatusBox)
        pnlBody.Controls.Add(lblStatusLabel)
        pnlBody.Controls.Add(cardRoleBox)
        pnlBody.Controls.Add(lblRoleLabel)
        pnlBody.Controls.Add(lblStaffEmail)
        pnlBody.Controls.Add(lblStaffName)
        pnlBody.Controls.Add(btnArchiveUser)
        pnlBody.Controls.Add(btnCancel)
        pnlBody.Controls.Add(btnSave)
        pnlBody.Dock = DockStyle.Fill
        pnlBody.Location = New Point(0, 76)
        pnlBody.Name = "pnlBody"
        pnlBody.Size = New Size(464, 344)
        pnlBody.TabIndex = 1
        ' 
        ' cardClinicBox
        ' 
        cardClinicBox.BackColor = Color.White
        cardClinicBox.BorderColor = Color.FromArgb(220, 228, 232)
        cardClinicBox.BorderHoverColor = Color.FromArgb(35, 137, 120)
        cardClinicBox.BorderRadius = 8
        cardClinicBox.BorderSize = 1
        cardClinicBox.Controls.Add(cboClinic)
        cardClinicBox.EnableShadow = False
        cardClinicBox.HoverTintColor = Color.White
        cardClinicBox.Location = New Point(24, 218)
        cardClinicBox.Name = "cardClinicBox"
        cardClinicBox.Padding = New Padding(4)
        cardClinicBox.ShadowDepth = 2
        cardClinicBox.Size = New Size(416, 36)
        cardClinicBox.TabIndex = 5
        ' 
        ' cboClinic
        ' 
        cboClinic.Dock = DockStyle.Fill
        cboClinic.DropDownStyle = ComboBoxStyle.DropDownList
        cboClinic.FlatStyle = FlatStyle.Flat
        cboClinic.Font = New Font("Segoe UI", 9.0F)
        cboClinic.FormattingEnabled = True
        cboClinic.Location = New Point(4, 4)
        cboClinic.Name = "cboClinic"
        cboClinic.Size = New Size(408, 23)
        cboClinic.TabIndex = 0
        ' 
        ' lblClinicLabel
        ' 
        lblClinicLabel.AutoSize = True
        lblClinicLabel.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        lblClinicLabel.ForeColor = Color.FromArgb(70, 85, 95)
        lblClinicLabel.Location = New Point(24, 200)
        lblClinicLabel.Name = "lblClinicLabel"
        lblClinicLabel.Size = New Size(92, 15)
        lblClinicLabel.TabIndex = 4
        lblClinicLabel.Text = "Assigned clinic"
        ' 
        ' cardStatusBox
        ' 
        cardStatusBox.BackColor = Color.White
        cardStatusBox.BorderColor = Color.FromArgb(220, 228, 232)
        cardStatusBox.BorderHoverColor = Color.FromArgb(35, 137, 120)
        cardStatusBox.BorderRadius = 8
        cardStatusBox.BorderSize = 1
        cardStatusBox.Controls.Add(cboStatus)
        cardStatusBox.EnableShadow = False
        cardStatusBox.HoverTintColor = Color.White
        cardStatusBox.Location = New Point(236, 148)
        cardStatusBox.Name = "cardStatusBox"
        cardStatusBox.Padding = New Padding(4)
        cardStatusBox.ShadowDepth = 2
        cardStatusBox.Size = New Size(204, 36)
        cardStatusBox.TabIndex = 3
        ' 
        ' cboStatus
        ' 
        cboStatus.Dock = DockStyle.Fill
        cboStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cboStatus.FlatStyle = FlatStyle.Flat
        cboStatus.Font = New Font("Segoe UI", 9.0F)
        cboStatus.FormattingEnabled = True
        cboStatus.Location = New Point(4, 4)
        cboStatus.Name = "cboStatus"
        cboStatus.Size = New Size(196, 23)
        cboStatus.TabIndex = 0
        ' 
        ' lblStatusLabel
        ' 
        lblStatusLabel.AutoSize = True
        lblStatusLabel.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        lblStatusLabel.ForeColor = Color.FromArgb(70, 85, 95)
        lblStatusLabel.Location = New Point(236, 130)
        lblStatusLabel.Name = "lblStatusLabel"
        lblStatusLabel.Size = New Size(88, 15)
        lblStatusLabel.TabIndex = 2
        lblStatusLabel.Text = "Account status"
        ' 
        ' cardRoleBox
        ' 
        cardRoleBox.BackColor = Color.White
        cardRoleBox.BorderColor = Color.FromArgb(220, 228, 232)
        cardRoleBox.BorderHoverColor = Color.FromArgb(35, 137, 120)
        cardRoleBox.BorderRadius = 8
        cardRoleBox.BorderSize = 1
        cardRoleBox.Controls.Add(cboRole)
        cardRoleBox.EnableShadow = False
        cardRoleBox.HoverTintColor = Color.White
        cardRoleBox.Location = New Point(24, 148)
        cardRoleBox.Name = "cardRoleBox"
        cardRoleBox.Padding = New Padding(4)
        cardRoleBox.ShadowDepth = 2
        cardRoleBox.Size = New Size(196, 36)
        cardRoleBox.TabIndex = 1
        ' 
        ' cboRole
        ' 
        cboRole.Dock = DockStyle.Fill
        cboRole.DropDownStyle = ComboBoxStyle.DropDownList
        cboRole.FlatStyle = FlatStyle.Flat
        cboRole.Font = New Font("Segoe UI", 9.0F)
        cboRole.FormattingEnabled = True
        cboRole.Location = New Point(4, 4)
        cboRole.Name = "cboRole"
        cboRole.Size = New Size(188, 23)
        cboRole.TabIndex = 0
        ' 
        ' lblRoleLabel
        ' 
        lblRoleLabel.AutoSize = True
        lblRoleLabel.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        lblRoleLabel.ForeColor = Color.FromArgb(70, 85, 95)
        lblRoleLabel.Location = New Point(24, 130)
        lblRoleLabel.Name = "lblRoleLabel"
        lblRoleLabel.Size = New Size(62, 15)
        lblRoleLabel.TabIndex = 0
        lblRoleLabel.Text = "Staff role"
        ' 
        ' lblStaffEmail
        ' 
        lblStaffEmail.AutoSize = True
        lblStaffEmail.Font = New Font("Segoe UI", 9.0F)
        lblStaffEmail.ForeColor = Color.FromArgb(115, 138, 148)
        lblStaffEmail.Location = New Point(24, 42)
        lblStaffEmail.Name = "lblStaffEmail"
        lblStaffEmail.Size = New Size(153, 15)
        lblStaffEmail.TabIndex = 7
        lblStaffEmail.Text = "staff.email@uccclinic.edu.ph"
        ' 
        ' lblStaffName
        ' 
        lblStaffName.AutoSize = True
        lblStaffName.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        lblStaffName.ForeColor = Color.FromArgb(30, 45, 55)
        lblStaffName.Location = New Point(24, 18)
        lblStaffName.Name = "lblStaffName"
        lblStaffName.Size = New Size(95, 21)
        lblStaffName.TabIndex = 6
        lblStaffName.Text = "Staff Name"
        ' 
        ' btnArchiveUser
        ' 
        btnArchiveUser.BackColor = Color.FromArgb(253, 236, 236)
        btnArchiveUser.BorderColor = Color.FromArgb(244, 204, 202)
        btnArchiveUser.BorderRadius = 8
        btnArchiveUser.BorderSize = 1
        btnArchiveUser.Cursor = Cursors.Hand
        btnArchiveUser.FlatAppearance.BorderSize = 0
        btnArchiveUser.FlatStyle = FlatStyle.Flat
        btnArchiveUser.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnArchiveUser.ForeColor = Color.FromArgb(205, 80, 75)
        btnArchiveUser.Location = New Point(24, 282)
        btnArchiveUser.Name = "btnArchiveUser"
        btnArchiveUser.Size = New Size(116, 36)
        btnArchiveUser.TabIndex = 10
        btnArchiveUser.Text = "🗑 Delete User"
        btnArchiveUser.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.White
        btnCancel.BorderColor = Color.FromArgb(210, 222, 228)
        btnCancel.BorderRadius = 8
        btnCancel.BorderSize = 1
        btnCancel.Cursor = Cursors.Hand
        btnCancel.DialogResult = DialogResult.Cancel
        btnCancel.FlatAppearance.BorderSize = 0
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnCancel.ForeColor = Color.FromArgb(70, 85, 95)
        btnCancel.Location = New Point(216, 282)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(104, 36)
        btnCancel.TabIndex = 8
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.FromArgb(35, 137, 120)
        btnSave.BorderColor = Color.FromArgb(35, 137, 120)
        btnSave.BorderRadius = 8
        btnSave.BorderSize = 0
        btnSave.Cursor = Cursors.Hand
        btnSave.FlatAppearance.BorderSize = 0
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnSave.ForeColor = Color.White
        btnSave.Location = New Point(328, 282)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(112, 36)
        btnSave.TabIndex = 9
        btnSave.Text = "Save changes"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' EditUserDialog
        ' 
        AcceptButton = btnSave
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = btnCancel
        ClientSize = New Size(464, 420)
        Controls.Add(pnlBody)
        Controls.Add(pnlHeader)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "EditUserDialog"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterParent
        Text = "Edit Staff Account"
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        pnlBody.ResumeLayout(False)
        pnlBody.PerformLayout()
        cardClinicBox.ResumeLayout(False)
        cardStatusBox.ResumeLayout(False)
        cardRoleBox.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents pnlBody As Panel
    Friend WithEvents lblStaffName As Label
    Friend WithEvents lblStaffEmail As Label
    Friend WithEvents lblRoleLabel As Label
    Friend WithEvents cardRoleBox As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents cboRole As ComboBox
    Friend WithEvents lblStatusLabel As Label
    Friend WithEvents cardStatusBox As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents lblClinicLabel As Label
    Friend WithEvents cardClinicBox As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents cboClinic As ComboBox
    Friend WithEvents btnCancel As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnSave As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnArchiveUser As Ferrando.UI.WinForms.Controles.FButton

End Class
