<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserManagement
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
        lblTitle = New Label()
        lblSubtitle = New Label()
        btnArchive = New Ferrando.UI.WinForms.Controles.FButton()
        btnAddUser = New Ferrando.UI.WinForms.Controles.FButton()
        txtSearch = New TextBox()
        lblSearchIcon = New Label()
        cardSearch = New Ferrando.UI.WinForms.Controles.FCard()
        btnFilterRole = New Ferrando.UI.WinForms.Controles.FButton()
        btnFilterStatus = New Ferrando.UI.WinForms.Controles.FButton()
        lblCardTitle = New Label()
        lblColName = New Label()
        lblColEmail = New Label()
        lblColRole = New Label()
        lblColStatus = New Label()
        lblColLast = New Label()
        pnlHeaderLine = New Panel()
        pnlRows = New Panel()
        lblEmpty = New Label()
        cardStaff = New Ferrando.UI.WinForms.Controles.FCard()
        lblPermTitle = New Label()
        lblPermDoctor = New Label()
        lblPermDoctorDesc = New Label()
        lblPermReceptionist = New Label()
        lblPermReceptionistDesc = New Label()
        cardPerms = New Ferrando.UI.WinForms.Controles.FCard()
        cardSearch.SuspendLayout()
        cardStaff.SuspendLayout()
        cardPerms.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.BackColor = Color.Transparent
        lblTitle.Font = New Font("Segoe UI", 18.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.FromArgb(22, 51, 65)
        lblTitle.Location = New Point(28, 20)
        lblTitle.Name = "lblTitle"
        lblTitle.TabIndex = 0
        lblTitle.Text = "User management"
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.AutoSize = True
        lblSubtitle.BackColor = Color.Transparent
        lblSubtitle.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSubtitle.ForeColor = Color.FromArgb(115, 138, 148)
        lblSubtitle.Location = New Point(28, 54)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "12 staff accounts"
        ' 
        ' btnArchive
        ' 
        btnArchive.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnArchive.Cursor = Cursors.Hand
        btnArchive.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnArchive.Location = New Point(576, 22)
        btnArchive.Name = "btnArchive"
        btnArchive.Size = New Size(116, 34)
        btnArchive.TabIndex = 8
        btnArchive.Text = "📁 Archive (0)"
        ' 
        ' btnAddUser
        ' 
        btnAddUser.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnAddUser.BackColor = Color.FromArgb(29, 124, 107)
        btnAddUser.BorderColor = Color.FromArgb(29, 124, 107)
        btnAddUser.BorderRadius = 8
        btnAddUser.BorderSize = 0
        btnAddUser.Cursor = Cursors.Hand
        btnAddUser.FlatAppearance.BorderSize = 0
        btnAddUser.FlatStyle = FlatStyle.Flat
        btnAddUser.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnAddUser.ForeColor = Color.FromArgb(255, 255, 255)
        btnAddUser.Location = New Point(702, 22)
        btnAddUser.MouseEnterBackColor = Color.FromArgb(23, 105, 90)
        btnAddUser.MouseEnterBorderColor = Color.FromArgb(23, 105, 90)
        btnAddUser.MouseEnterBorderSize = 0
        btnAddUser.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnAddUser.MouseEnterForeColor = Color.FromArgb(255, 255, 255)
        btnAddUser.MouseLeaveBackColor = Color.FromArgb(29, 124, 107)
        btnAddUser.MouseLeaveBorderColor = Color.FromArgb(29, 124, 107)
        btnAddUser.MouseLeaveBorderSize = 0
        btnAddUser.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnAddUser.MouseLeaveForeColor = Color.FromArgb(255, 255, 255)
        btnAddUser.Name = "btnAddUser"
        btnAddUser.Size = New Size(100, 34)
        btnAddUser.TabIndex = 2
        btnAddUser.Text = "+ Add user"
        btnAddUser.UseVisualStyleBackColor = False
        ' 
        ' txtSearch
        ' 
        txtSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtSearch.BackColor = Color.White
        txtSearch.BorderStyle = BorderStyle.None
        txtSearch.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSearch.ForeColor = Color.FromArgb(30, 45, 55)
        txtSearch.Location = New Point(38, 10)
        txtSearch.Name = "txtSearch"
        txtSearch.PlaceholderText = "Search by name or email"
        txtSearch.Size = New Size(506, 16)
        txtSearch.TabIndex = 1
        ' 
        ' lblSearchIcon
        ' 
        lblSearchIcon.AutoSize = True
        lblSearchIcon.BackColor = Color.White
        lblSearchIcon.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSearchIcon.ForeColor = Color.FromArgb(140, 155, 165)
        lblSearchIcon.Location = New Point(12, 8)
        lblSearchIcon.Name = "lblSearchIcon"
        lblSearchIcon.TabIndex = 0
        lblSearchIcon.Text = "🔍"
        ' 
        ' cardSearch
        ' 
        cardSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        cardSearch.BackColor = Color.White
        cardSearch.BorderColor = Color.FromArgb(220, 228, 232)
        cardSearch.BorderHoverColor = Color.FromArgb(35, 137, 120)
        cardSearch.BorderRadius = 8
        cardSearch.BorderSize = 1
        cardSearch.Controls.Add(txtSearch)
        cardSearch.Controls.Add(lblSearchIcon)
        cardSearch.EnableShadow = False
        cardSearch.HoverTintColor = Color.White
        cardSearch.Location = New Point(28, 92)
        cardSearch.Name = "cardSearch"
        cardSearch.Padding = New Padding(0)
        cardSearch.ShadowDepth = 2
        cardSearch.Size = New Size(558, 36)
        cardSearch.TabIndex = 3
        ' 
        ' btnFilterRole
        ' 
        btnFilterRole.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnFilterRole.BackColor = Color.FromArgb(255, 255, 255)
        btnFilterRole.BorderColor = Color.FromArgb(210, 222, 228)
        btnFilterRole.BorderRadius = 8
        btnFilterRole.BorderSize = 1
        btnFilterRole.Cursor = Cursors.Hand
        btnFilterRole.FlatAppearance.BorderSize = 0
        btnFilterRole.FlatStyle = FlatStyle.Flat
        btnFilterRole.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnFilterRole.ForeColor = Color.FromArgb(30, 45, 55)
        btnFilterRole.Location = New Point(594, 92)
        btnFilterRole.MouseEnterBackColor = Color.FromArgb(245, 249, 251)
        btnFilterRole.MouseEnterBorderColor = Color.FromArgb(35, 137, 120)
        btnFilterRole.MouseEnterBorderSize = 1
        btnFilterRole.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnFilterRole.MouseEnterForeColor = Color.FromArgb(35, 137, 120)
        btnFilterRole.MouseLeaveBackColor = Color.FromArgb(255, 255, 255)
        btnFilterRole.MouseLeaveBorderColor = Color.FromArgb(210, 222, 228)
        btnFilterRole.MouseLeaveBorderSize = 1
        btnFilterRole.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnFilterRole.MouseLeaveForeColor = Color.FromArgb(30, 45, 55)
        btnFilterRole.Name = "btnFilterRole"
        btnFilterRole.Size = New Size(92, 36)
        btnFilterRole.TabIndex = 4
        btnFilterRole.Text = "All roles"
        btnFilterRole.UseVisualStyleBackColor = False
        ' 
        ' btnFilterStatus
        ' 
        btnFilterStatus.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnFilterStatus.BackColor = Color.FromArgb(255, 255, 255)
        btnFilterStatus.BorderColor = Color.FromArgb(210, 222, 228)
        btnFilterStatus.BorderRadius = 8
        btnFilterStatus.BorderSize = 1
        btnFilterStatus.Cursor = Cursors.Hand
        btnFilterStatus.FlatAppearance.BorderSize = 0
        btnFilterStatus.FlatStyle = FlatStyle.Flat
        btnFilterStatus.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnFilterStatus.ForeColor = Color.FromArgb(30, 45, 55)
        btnFilterStatus.Location = New Point(694, 92)
        btnFilterStatus.MouseEnterBackColor = Color.FromArgb(245, 249, 251)
        btnFilterStatus.MouseEnterBorderColor = Color.FromArgb(35, 137, 120)
        btnFilterStatus.MouseEnterBorderSize = 1
        btnFilterStatus.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnFilterStatus.MouseEnterForeColor = Color.FromArgb(35, 137, 120)
        btnFilterStatus.MouseLeaveBackColor = Color.FromArgb(255, 255, 255)
        btnFilterStatus.MouseLeaveBorderColor = Color.FromArgb(210, 222, 228)
        btnFilterStatus.MouseLeaveBorderSize = 1
        btnFilterStatus.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnFilterStatus.MouseLeaveForeColor = Color.FromArgb(30, 45, 55)
        btnFilterStatus.Name = "btnFilterStatus"
        btnFilterStatus.Size = New Size(108, 36)
        btnFilterStatus.TabIndex = 5
        btnFilterStatus.Text = "All statuses"
        btnFilterStatus.UseVisualStyleBackColor = False
        ' 
        ' lblCardTitle
        ' 
        lblCardTitle.AutoSize = True
        lblCardTitle.BackColor = Color.White
        lblCardTitle.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCardTitle.ForeColor = Color.FromArgb(30, 45, 55)
        lblCardTitle.Location = New Point(24, 18)
        lblCardTitle.Name = "lblCardTitle"
        lblCardTitle.TabIndex = 0
        lblCardTitle.Text = "Staff accounts"
        ' 
        ' lblColName
        ' 
        lblColName.AutoSize = True
        lblColName.BackColor = Color.White
        lblColName.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblColName.ForeColor = Color.FromArgb(120, 135, 145)
        lblColName.Location = New Point(20, 52)
        lblColName.Name = "lblColName"
        lblColName.TabIndex = 1
        lblColName.Text = "Name"
        ' 
        ' lblColEmail
        ' 
        lblColEmail.AutoSize = True
        lblColEmail.BackColor = Color.White
        lblColEmail.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblColEmail.ForeColor = Color.FromArgb(120, 135, 145)
        lblColEmail.Location = New Point(126, 52)
        lblColEmail.Name = "lblColEmail"
        lblColEmail.TabIndex = 2
        lblColEmail.Text = "Email"
        ' 
        ' lblColRole
        ' 
        lblColRole.AutoSize = True
        lblColRole.BackColor = Color.White
        lblColRole.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblColRole.ForeColor = Color.FromArgb(120, 135, 145)
        lblColRole.Location = New Point(304, 52)
        lblColRole.Name = "lblColRole"
        lblColRole.TabIndex = 3
        lblColRole.Text = "Role"
        ' 
        ' lblColStatus
        ' 
        lblColStatus.AutoSize = True
        lblColStatus.BackColor = Color.White
        lblColStatus.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblColStatus.ForeColor = Color.FromArgb(120, 135, 145)
        lblColStatus.Location = New Point(388, 52)
        lblColStatus.Name = "lblColStatus"
        lblColStatus.TabIndex = 4
        lblColStatus.Text = "Status"
        ' 
        ' lblColLast
        ' 
        lblColLast.AutoSize = True
        lblColLast.BackColor = Color.White
        lblColLast.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblColLast.ForeColor = Color.FromArgb(120, 135, 145)
        lblColLast.Location = New Point(460, 52)
        lblColLast.Name = "lblColLast"
        lblColLast.TabIndex = 5
        lblColLast.Text = "Last active"
        ' 
        ' pnlHeaderLine
        ' 
        pnlHeaderLine.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pnlHeaderLine.BackColor = Color.FromArgb(232, 237, 240)
        pnlHeaderLine.Location = New Point(20, 76)
        pnlHeaderLine.Name = "pnlHeaderLine"
        pnlHeaderLine.Size = New Size(576, 1)
        pnlHeaderLine.TabIndex = 7
        ' 
        ' pnlRows
        ' 
        pnlRows.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pnlRows.AutoScroll = True
        pnlRows.BackColor = Color.FromArgb(255, 255, 255)
        pnlRows.Location = New Point(20, 78)
        pnlRows.Name = "pnlRows"
        pnlRows.Size = New Size(576, 446)
        pnlRows.TabIndex = 8
        ' 
        ' lblEmpty
        ' 
        lblEmpty.AutoSize = True
        lblEmpty.BackColor = Color.White
        lblEmpty.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblEmpty.ForeColor = Color.FromArgb(140, 155, 165)
        lblEmpty.Location = New Point(24, 100)
        lblEmpty.Name = "lblEmpty"
        lblEmpty.TabIndex = 9
        lblEmpty.Text = "No accounts match your filters."
        ' 
        ' cardStaff
        ' 
        cardStaff.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        cardStaff.BackColor = Color.White
        cardStaff.BorderColor = Color.FromArgb(232, 237, 240)
        cardStaff.BorderHoverColor = Color.FromArgb(232, 237, 240)
        cardStaff.BorderRadius = 12
        cardStaff.BorderSize = 1
        cardStaff.Controls.Add(lblEmpty)
        cardStaff.Controls.Add(pnlRows)
        cardStaff.Controls.Add(pnlHeaderLine)
        cardStaff.Controls.Add(lblColLast)
        cardStaff.Controls.Add(lblColStatus)
        cardStaff.Controls.Add(lblColRole)
        cardStaff.Controls.Add(lblColEmail)
        cardStaff.Controls.Add(lblColName)
        cardStaff.Controls.Add(lblCardTitle)
        cardStaff.EnableShadow = True
        cardStaff.HoverTintColor = Color.White
        cardStaff.Location = New Point(28, 144)
        cardStaff.Name = "cardStaff"
        cardStaff.Padding = New Padding(0)
        cardStaff.ShadowDepth = 4
        cardStaff.Size = New Size(616, 540)
        cardStaff.TabIndex = 6
        ' 
        ' lblPermTitle
        ' 
        lblPermTitle.AutoSize = True
        lblPermTitle.BackColor = Color.White
        lblPermTitle.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPermTitle.ForeColor = Color.FromArgb(30, 45, 55)
        lblPermTitle.Location = New Point(16, 16)
        lblPermTitle.Name = "lblPermTitle"
        lblPermTitle.TabIndex = 0
        lblPermTitle.Text = "Role permissions"
        ' 
        ' lblPermDoctor
        ' 
        lblPermDoctor.AutoSize = True
        lblPermDoctor.BackColor = Color.White
        lblPermDoctor.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPermDoctor.ForeColor = Color.FromArgb(30, 45, 55)
        lblPermDoctor.Location = New Point(16, 48)
        lblPermDoctor.Name = "lblPermDoctor"
        lblPermDoctor.TabIndex = 1
        lblPermDoctor.Text = "Doctor"
        ' 
        ' lblPermDoctorDesc
        ' 
        lblPermDoctorDesc.AutoSize = True
        lblPermDoctorDesc.BackColor = Color.White
        lblPermDoctorDesc.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPermDoctorDesc.ForeColor = Color.FromArgb(115, 135, 145)
        lblPermDoctorDesc.Location = New Point(16, 67)
        lblPermDoctorDesc.MaximumSize = New Size(116, 0)
        lblPermDoctorDesc.Name = "lblPermDoctorDesc"
        lblPermDoctorDesc.TabIndex = 2
        lblPermDoctorDesc.Text = "Patient records, consultations, own schedule"
        ' 
        ' lblPermReceptionist
        ' 
        lblPermReceptionist.AutoSize = True
        lblPermReceptionist.BackColor = Color.White
        lblPermReceptionist.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPermReceptionist.ForeColor = Color.FromArgb(30, 45, 55)
        lblPermReceptionist.Location = New Point(16, 120)
        lblPermReceptionist.Name = "lblPermReceptionist"
        lblPermReceptionist.TabIndex = 3
        lblPermReceptionist.Text = "Receptionist"
        ' 
        ' lblPermReceptionistDesc
        ' 
        lblPermReceptionistDesc.AutoSize = True
        lblPermReceptionistDesc.BackColor = Color.White
        lblPermReceptionistDesc.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPermReceptionistDesc.ForeColor = Color.FromArgb(115, 135, 145)
        lblPermReceptionistDesc.Location = New Point(16, 139)
        lblPermReceptionistDesc.MaximumSize = New Size(116, 0)
        lblPermReceptionistDesc.Name = "lblPermReceptionistDesc"
        lblPermReceptionistDesc.TabIndex = 4
        lblPermReceptionistDesc.Text = "Patient registration, appointments, all doctor schedules"
        ' 
        ' cardPerms
        ' 
        cardPerms.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        cardPerms.BackColor = Color.White
        cardPerms.BorderColor = Color.FromArgb(232, 237, 240)
        cardPerms.BorderHoverColor = Color.FromArgb(232, 237, 240)
        cardPerms.BorderRadius = 12
        cardPerms.BorderSize = 1
        cardPerms.Controls.Add(lblPermReceptionistDesc)
        cardPerms.Controls.Add(lblPermReceptionist)
        cardPerms.Controls.Add(lblPermDoctorDesc)
        cardPerms.Controls.Add(lblPermDoctor)
        cardPerms.Controls.Add(lblPermTitle)
        cardPerms.EnableShadow = True
        cardPerms.HoverTintColor = Color.White
        cardPerms.Location = New Point(656, 144)
        cardPerms.Name = "cardPerms"
        cardPerms.Padding = New Padding(0)
        cardPerms.ShadowDepth = 4
        cardPerms.Size = New Size(146, 214)
        cardPerms.TabIndex = 7
        ' 
        ' UserManagement
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(244, 247, 249)
        ClientSize = New Size(830, 729)
        FormBorderStyle = FormBorderStyle.None
        Controls.Add(cardPerms)
        Controls.Add(cardStaff)
        Controls.Add(btnFilterStatus)
        Controls.Add(btnFilterRole)
        Controls.Add(cardSearch)
        Controls.Add(btnArchive)
        Controls.Add(btnAddUser)
        Controls.Add(lblSubtitle)
        Controls.Add(lblTitle)
        Name = "UserManagement"
        Text = "UserManagement"
        cardSearch.ResumeLayout(False)
        cardSearch.PerformLayout()
        cardStaff.ResumeLayout(False)
        cardStaff.PerformLayout()
        cardPerms.ResumeLayout(False)
        cardPerms.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents btnArchive As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnAddUser As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents lblSearchIcon As Label
    Friend WithEvents cardSearch As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents btnFilterRole As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnFilterStatus As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents lblCardTitle As Label
    Friend WithEvents lblColName As Label
    Friend WithEvents lblColEmail As Label
    Friend WithEvents lblColRole As Label
    Friend WithEvents lblColStatus As Label
    Friend WithEvents lblColLast As Label
    Friend WithEvents pnlHeaderLine As Panel
    Friend WithEvents pnlRows As Panel
    Friend WithEvents lblEmpty As Label
    Friend WithEvents cardStaff As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblPermTitle As Label
    Friend WithEvents lblPermDoctor As Label
    Friend WithEvents lblPermDoctorDesc As Label
    Friend WithEvents lblPermReceptionist As Label
    Friend WithEvents lblPermReceptionistDesc As Label
    Friend WithEvents cardPerms As Ferrando.UI.WinForms.Controles.FCard

End Class

