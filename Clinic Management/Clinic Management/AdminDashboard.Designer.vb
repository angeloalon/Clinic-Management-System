<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdminDashboard
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
        lblGreeting = New Label()
        lblSubtitle = New Label()
        btnAddUser = New Ferrando.UI.WinForms.Controles.FButton()
        lblKpi1Title = New Label()
        lblKpi1Value = New Label()
        lblKpi1Note = New Label()
        cardKpi1 = New Ferrando.UI.WinForms.Controles.FCard()
        lblKpi2Title = New Label()
        lblKpi2Value = New Label()
        lblKpi2Note = New Label()
        cardKpi2 = New Ferrando.UI.WinForms.Controles.FCard()
        lblKpi3Title = New Label()
        lblKpi3Value = New Label()
        lblKpi3Note = New Label()
        cardKpi3 = New Ferrando.UI.WinForms.Controles.FCard()
        lblKpi4Title = New Label()
        lblKpi4Value = New Label()
        lblKpi4Note = New Label()
        cardKpi4 = New Ferrando.UI.WinForms.Controles.FCard()
        lblRecentTitle = New Label()
        pnlActivity = New Panel()
        cardRecent = New Ferrando.UI.WinForms.Controles.FCard()
        lblStaffTitle = New Label()
        lblRoleName1 = New Label()
        lblRoleCount1 = New Label()
        pnlFill1 = New Panel()
        pnlTrack1 = New Panel()
        lblRoleName2 = New Label()
        lblRoleCount2 = New Label()
        pnlFill2 = New Panel()
        pnlTrack2 = New Panel()
        lblRoleName3 = New Label()
        lblRoleCount3 = New Label()
        pnlFill3 = New Panel()
        pnlTrack3 = New Panel()
        lblStaffFooter = New Label()
        cardStaff = New Ferrando.UI.WinForms.Controles.FCard()
        cardKpi1.SuspendLayout()
        cardKpi2.SuspendLayout()
        cardKpi3.SuspendLayout()
        cardKpi4.SuspendLayout()
        cardRecent.SuspendLayout()
        cardStaff.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblGreeting
        ' 
        lblGreeting.AutoSize = True
        lblGreeting.BackColor = Color.Transparent
        lblGreeting.Font = New Font("Segoe UI", 18.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblGreeting.ForeColor = Color.FromArgb(22, 51, 65)
        lblGreeting.Location = New Point(28, 20)
        lblGreeting.Name = "lblGreeting"
        lblGreeting.TabIndex = 0
        lblGreeting.Text = "Good morning, Rosa"
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
        lblSubtitle.Text = "Clinic administration"
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
        ' lblKpi1Title
        ' 
        lblKpi1Title.AutoSize = True
        lblKpi1Title.BackColor = Color.White
        lblKpi1Title.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblKpi1Title.ForeColor = Color.FromArgb(115, 135, 145)
        lblKpi1Title.Location = New Point(16, 10)
        lblKpi1Title.Name = "lblKpi1Title"
        lblKpi1Title.TabIndex = 0
        lblKpi1Title.Text = "Active staff"
        ' 
        ' lblKpi1Value
        ' 
        lblKpi1Value.AutoSize = True
        lblKpi1Value.BackColor = Color.White
        lblKpi1Value.Font = New Font("Segoe UI", 25.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblKpi1Value.ForeColor = Color.FromArgb(22, 51, 65)
        lblKpi1Value.Location = New Point(14, 24)
        lblKpi1Value.Name = "lblKpi1Value"
        lblKpi1Value.TabIndex = 1
        lblKpi1Value.Text = "12"
        ' 
        ' lblKpi1Note
        ' 
        lblKpi1Note.AutoSize = True
        lblKpi1Note.BackColor = Color.White
        lblKpi1Note.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblKpi1Note.ForeColor = Color.FromArgb(135, 148, 158)
        lblKpi1Note.Location = New Point(16, 66)
        lblKpi1Note.Name = "lblKpi1Note"
        lblKpi1Note.TabIndex = 2
        lblKpi1Note.Text = "+1 this week"
        ' 
        ' cardKpi1
        ' 
        cardKpi1.BackColor = Color.White
        cardKpi1.BorderColor = Color.FromArgb(232, 237, 240)
        cardKpi1.BorderHoverColor = Color.FromArgb(232, 237, 240)
        cardKpi1.BorderRadius = 12
        cardKpi1.BorderSize = 1
        cardKpi1.Controls.Add(lblKpi1Note)
        cardKpi1.Controls.Add(lblKpi1Value)
        cardKpi1.Controls.Add(lblKpi1Title)
        cardKpi1.EnableShadow = True
        cardKpi1.HoverTintColor = Color.White
        cardKpi1.Location = New Point(28, 92)
        cardKpi1.Name = "cardKpi1"
        cardKpi1.Padding = New Padding(0)
        cardKpi1.ShadowDepth = 4
        cardKpi1.Size = New Size(185, 92)
        cardKpi1.TabIndex = 3
        ' 
        ' lblKpi2Title
        ' 
        lblKpi2Title.AutoSize = True
        lblKpi2Title.BackColor = Color.White
        lblKpi2Title.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblKpi2Title.ForeColor = Color.FromArgb(115, 135, 145)
        lblKpi2Title.Location = New Point(16, 10)
        lblKpi2Title.Name = "lblKpi2Title"
        lblKpi2Title.TabIndex = 0
        lblKpi2Title.Text = "Appointments today"
        ' 
        ' lblKpi2Value
        ' 
        lblKpi2Value.AutoSize = True
        lblKpi2Value.BackColor = Color.White
        lblKpi2Value.Font = New Font("Segoe UI", 25.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblKpi2Value.ForeColor = Color.FromArgb(22, 51, 65)
        lblKpi2Value.Location = New Point(14, 24)
        lblKpi2Value.Name = "lblKpi2Value"
        lblKpi2Value.TabIndex = 1
        lblKpi2Value.Text = "38"
        ' 
        ' lblKpi2Note
        ' 
        lblKpi2Note.AutoSize = True
        lblKpi2Note.BackColor = Color.White
        lblKpi2Note.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblKpi2Note.ForeColor = Color.FromArgb(135, 148, 158)
        lblKpi2Note.Location = New Point(16, 66)
        lblKpi2Note.Name = "lblKpi2Note"
        lblKpi2Note.TabIndex = 2
        lblKpi2Note.Text = "6 awaiting confirmation"
        ' 
        ' cardKpi2
        ' 
        cardKpi2.BackColor = Color.White
        cardKpi2.BorderColor = Color.FromArgb(232, 237, 240)
        cardKpi2.BorderHoverColor = Color.FromArgb(232, 237, 240)
        cardKpi2.BorderRadius = 12
        cardKpi2.BorderSize = 1
        cardKpi2.Controls.Add(lblKpi2Note)
        cardKpi2.Controls.Add(lblKpi2Value)
        cardKpi2.Controls.Add(lblKpi2Title)
        cardKpi2.EnableShadow = True
        cardKpi2.HoverTintColor = Color.White
        cardKpi2.Location = New Point(224, 92)
        cardKpi2.Name = "cardKpi2"
        cardKpi2.Padding = New Padding(0)
        cardKpi2.ShadowDepth = 4
        cardKpi2.Size = New Size(185, 92)
        cardKpi2.TabIndex = 4
        ' 
        ' lblKpi3Title
        ' 
        lblKpi3Title.AutoSize = True
        lblKpi3Title.BackColor = Color.White
        lblKpi3Title.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblKpi3Title.ForeColor = Color.FromArgb(115, 135, 145)
        lblKpi3Title.Location = New Point(16, 10)
        lblKpi3Title.Name = "lblKpi3Title"
        lblKpi3Title.TabIndex = 0
        lblKpi3Title.Text = "Leave requests"
        ' 
        ' lblKpi3Value
        ' 
        lblKpi3Value.AutoSize = True
        lblKpi3Value.BackColor = Color.White
        lblKpi3Value.Font = New Font("Segoe UI", 25.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblKpi3Value.ForeColor = Color.FromArgb(22, 51, 65)
        lblKpi3Value.Location = New Point(14, 24)
        lblKpi3Value.Name = "lblKpi3Value"
        lblKpi3Value.TabIndex = 1
        lblKpi3Value.Text = "3"
        ' 
        ' lblKpi3Note
        ' 
        lblKpi3Note.AutoSize = True
        lblKpi3Note.BackColor = Color.White
        lblKpi3Note.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblKpi3Note.ForeColor = Color.FromArgb(135, 148, 158)
        lblKpi3Note.Location = New Point(16, 66)
        lblKpi3Note.Name = "lblKpi3Note"
        lblKpi3Note.TabIndex = 2
        lblKpi3Note.Text = "Pending approval"
        ' 
        ' cardKpi3
        ' 
        cardKpi3.BackColor = Color.White
        cardKpi3.BorderColor = Color.FromArgb(232, 237, 240)
        cardKpi3.BorderHoverColor = Color.FromArgb(232, 237, 240)
        cardKpi3.BorderRadius = 12
        cardKpi3.BorderSize = 1
        cardKpi3.Controls.Add(lblKpi3Note)
        cardKpi3.Controls.Add(lblKpi3Value)
        cardKpi3.Controls.Add(lblKpi3Title)
        cardKpi3.EnableShadow = True
        cardKpi3.HoverTintColor = Color.White
        cardKpi3.Location = New Point(420, 92)
        cardKpi3.Name = "cardKpi3"
        cardKpi3.Padding = New Padding(0)
        cardKpi3.ShadowDepth = 4
        cardKpi3.Size = New Size(185, 92)
        cardKpi3.TabIndex = 5
        ' 
        ' lblKpi4Title
        ' 
        lblKpi4Title.AutoSize = True
        lblKpi4Title.BackColor = Color.White
        lblKpi4Title.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblKpi4Title.ForeColor = Color.FromArgb(115, 135, 145)
        lblKpi4Title.Location = New Point(16, 10)
        lblKpi4Title.Name = "lblKpi4Title"
        lblKpi4Title.TabIndex = 0
        lblKpi4Title.Text = "Accounts to review"
        ' 
        ' lblKpi4Value
        ' 
        lblKpi4Value.AutoSize = True
        lblKpi4Value.BackColor = Color.White
        lblKpi4Value.Font = New Font("Segoe UI", 25.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblKpi4Value.ForeColor = Color.FromArgb(22, 51, 65)
        lblKpi4Value.Location = New Point(14, 24)
        lblKpi4Value.Name = "lblKpi4Value"
        lblKpi4Value.TabIndex = 1
        lblKpi4Value.Text = "2"
        ' 
        ' lblKpi4Note
        ' 
        lblKpi4Note.AutoSize = True
        lblKpi4Note.BackColor = Color.White
        lblKpi4Note.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblKpi4Note.ForeColor = Color.FromArgb(135, 148, 158)
        lblKpi4Note.Location = New Point(16, 66)
        lblKpi4Note.Name = "lblKpi4Note"
        lblKpi4Note.TabIndex = 2
        lblKpi4Note.Text = "Inactive for 30+ days"
        ' 
        ' cardKpi4
        ' 
        cardKpi4.BackColor = Color.White
        cardKpi4.BorderColor = Color.FromArgb(232, 237, 240)
        cardKpi4.BorderHoverColor = Color.FromArgb(232, 237, 240)
        cardKpi4.BorderRadius = 12
        cardKpi4.BorderSize = 1
        cardKpi4.Controls.Add(lblKpi4Note)
        cardKpi4.Controls.Add(lblKpi4Value)
        cardKpi4.Controls.Add(lblKpi4Title)
        cardKpi4.EnableShadow = True
        cardKpi4.HoverTintColor = Color.White
        cardKpi4.Location = New Point(616, 92)
        cardKpi4.Name = "cardKpi4"
        cardKpi4.Padding = New Padding(0)
        cardKpi4.ShadowDepth = 4
        cardKpi4.Size = New Size(185, 92)
        cardKpi4.TabIndex = 6
        ' 
        ' lblRecentTitle
        ' 
        lblRecentTitle.AutoSize = True
        lblRecentTitle.BackColor = Color.White
        lblRecentTitle.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRecentTitle.ForeColor = Color.FromArgb(30, 45, 55)
        lblRecentTitle.Location = New Point(20, 14)
        lblRecentTitle.Name = "lblRecentTitle"
        lblRecentTitle.TabIndex = 0
        lblRecentTitle.Text = "Recent activity"
        ' 
        ' pnlActivity
        ' 
        pnlActivity.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pnlActivity.BackColor = Color.FromArgb(255, 255, 255)
        pnlActivity.Location = New Point(14, 40)
        pnlActivity.Name = "pnlActivity"
        pnlActivity.Size = New Size(472, 264)
        pnlActivity.TabIndex = 1
        ' 
        ' cardRecent
        ' 
        cardRecent.BackColor = Color.White
        cardRecent.BorderColor = Color.FromArgb(232, 237, 240)
        cardRecent.BorderHoverColor = Color.FromArgb(232, 237, 240)
        cardRecent.BorderRadius = 12
        cardRecent.BorderSize = 1
        cardRecent.Controls.Add(pnlActivity)
        cardRecent.Controls.Add(lblRecentTitle)
        cardRecent.EnableShadow = True
        cardRecent.HoverTintColor = Color.White
        cardRecent.Location = New Point(28, 200)
        cardRecent.Name = "cardRecent"
        cardRecent.Padding = New Padding(0)
        cardRecent.ShadowDepth = 4
        cardRecent.Size = New Size(500, 308)
        cardRecent.TabIndex = 7
        ' 
        ' lblStaffTitle
        ' 
        lblStaffTitle.AutoSize = True
        lblStaffTitle.BackColor = Color.White
        lblStaffTitle.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStaffTitle.ForeColor = Color.FromArgb(30, 45, 55)
        lblStaffTitle.Location = New Point(20, 14)
        lblStaffTitle.Name = "lblStaffTitle"
        lblStaffTitle.TabIndex = 0
        lblStaffTitle.Text = "Staff by role"
        ' 
        ' lblRoleName1
        ' 
        lblRoleName1.AutoSize = True
        lblRoleName1.BackColor = Color.White
        lblRoleName1.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRoleName1.ForeColor = Color.FromArgb(45, 60, 70)
        lblRoleName1.Location = New Point(20, 46)
        lblRoleName1.Name = "lblRoleName1"
        lblRoleName1.TabIndex = 1
        lblRoleName1.Text = "Doctors"
        ' 
        ' lblRoleCount1
        ' 
        lblRoleCount1.AutoSize = True
        lblRoleCount1.BackColor = Color.White
        lblRoleCount1.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRoleCount1.ForeColor = Color.FromArgb(30, 45, 55)
        lblRoleCount1.Location = New Point(224, 46)
        lblRoleCount1.Name = "lblRoleCount1"
        lblRoleCount1.TabIndex = 2
        lblRoleCount1.Text = "0"
        ' 
        ' pnlFill1
        ' 
        pnlFill1.BackColor = Color.FromArgb(35, 137, 120)
        pnlFill1.Location = New Point(0, 0)
        pnlFill1.Name = "pnlFill1"
        pnlFill1.Size = New Size(0, 6)
        pnlFill1.TabIndex = 0
        ' 
        ' pnlTrack1
        ' 
        pnlTrack1.BackColor = Color.FromArgb(232, 237, 240)
        pnlTrack1.Controls.Add(pnlFill1)
        pnlTrack1.Location = New Point(20, 68)
        pnlTrack1.Name = "pnlTrack1"
        pnlTrack1.Size = New Size(218, 6)
        pnlTrack1.TabIndex = 3
        ' 
        ' lblRoleName2
        ' 
        lblRoleName2.AutoSize = True
        lblRoleName2.BackColor = Color.White
        lblRoleName2.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRoleName2.ForeColor = Color.FromArgb(45, 60, 70)
        lblRoleName2.Location = New Point(20, 86)
        lblRoleName2.Name = "lblRoleName2"
        lblRoleName2.TabIndex = 5
        lblRoleName2.Text = "Receptionists"
        ' 
        ' lblRoleCount2
        ' 
        lblRoleCount2.AutoSize = True
        lblRoleCount2.BackColor = Color.White
        lblRoleCount2.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRoleCount2.ForeColor = Color.FromArgb(30, 45, 55)
        lblRoleCount2.Location = New Point(224, 86)
        lblRoleCount2.Name = "lblRoleCount2"
        lblRoleCount2.TabIndex = 6
        lblRoleCount2.Text = "0"
        ' 
        ' pnlFill2
        ' 
        pnlFill2.BackColor = Color.FromArgb(35, 137, 120)
        pnlFill2.Location = New Point(0, 0)
        pnlFill2.Name = "pnlFill2"
        pnlFill2.Size = New Size(0, 6)
        pnlFill2.TabIndex = 0
        ' 
        ' pnlTrack2
        ' 
        pnlTrack2.BackColor = Color.FromArgb(232, 237, 240)
        pnlTrack2.Controls.Add(pnlFill2)
        pnlTrack2.Location = New Point(20, 108)
        pnlTrack2.Name = "pnlTrack2"
        pnlTrack2.Size = New Size(218, 6)
        pnlTrack2.TabIndex = 7
        ' 
        ' lblRoleName3
        ' 
        lblRoleName3.AutoSize = True
        lblRoleName3.BackColor = Color.White
        lblRoleName3.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRoleName3.ForeColor = Color.FromArgb(45, 60, 70)
        lblRoleName3.Location = New Point(20, 126)
        lblRoleName3.Name = "lblRoleName3"
        lblRoleName3.TabIndex = 9
        lblRoleName3.Text = "Administrators"
        ' 
        ' lblRoleCount3
        ' 
        lblRoleCount3.AutoSize = True
        lblRoleCount3.BackColor = Color.White
        lblRoleCount3.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRoleCount3.ForeColor = Color.FromArgb(30, 45, 55)
        lblRoleCount3.Location = New Point(224, 126)
        lblRoleCount3.Name = "lblRoleCount3"
        lblRoleCount3.TabIndex = 10
        lblRoleCount3.Text = "0"
        ' 
        ' pnlFill3
        ' 
        pnlFill3.BackColor = Color.FromArgb(35, 137, 120)
        pnlFill3.Location = New Point(0, 0)
        pnlFill3.Name = "pnlFill3"
        pnlFill3.Size = New Size(0, 6)
        pnlFill3.TabIndex = 0
        ' 
        ' pnlTrack3
        ' 
        pnlTrack3.BackColor = Color.FromArgb(232, 237, 240)
        pnlTrack3.Controls.Add(pnlFill3)
        pnlTrack3.Location = New Point(20, 148)
        pnlTrack3.Name = "pnlTrack3"
        pnlTrack3.Size = New Size(218, 6)
        pnlTrack3.TabIndex = 11
        ' 
        ' lblStaffFooter
        ' 
        lblStaffFooter.AutoSize = True
        lblStaffFooter.BackColor = Color.White
        lblStaffFooter.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblStaffFooter.ForeColor = Color.FromArgb(135, 148, 158)
        lblStaffFooter.Location = New Point(20, 172)
        lblStaffFooter.Name = "lblStaffFooter"
        lblStaffFooter.TabIndex = 13
        lblStaffFooter.Text = "12 active accounts"
        ' 
        ' cardStaff
        ' 
        cardStaff.BackColor = Color.White
        cardStaff.BorderColor = Color.FromArgb(232, 237, 240)
        cardStaff.BorderHoverColor = Color.FromArgb(232, 237, 240)
        cardStaff.BorderRadius = 12
        cardStaff.BorderSize = 1
        cardStaff.Controls.Add(lblStaffFooter)
        cardStaff.Controls.Add(pnlTrack3)
        cardStaff.Controls.Add(lblRoleCount3)
        cardStaff.Controls.Add(lblRoleName3)
        cardStaff.Controls.Add(pnlTrack2)
        cardStaff.Controls.Add(lblRoleCount2)
        cardStaff.Controls.Add(lblRoleName2)
        cardStaff.Controls.Add(pnlTrack1)
        cardStaff.Controls.Add(lblRoleCount1)
        cardStaff.Controls.Add(lblRoleName1)
        cardStaff.Controls.Add(lblStaffTitle)
        cardStaff.EnableShadow = True
        cardStaff.HoverTintColor = Color.White
        cardStaff.Location = New Point(544, 200)
        cardStaff.Name = "cardStaff"
        cardStaff.Padding = New Padding(0)
        cardStaff.ShadowDepth = 4
        cardStaff.Size = New Size(258, 204)
        cardStaff.TabIndex = 8
        ' 
        ' AdminDashboard
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(244, 247, 249)
        ClientSize = New Size(830, 729)
        FormBorderStyle = FormBorderStyle.None
        Controls.Add(cardStaff)
        Controls.Add(cardRecent)
        Controls.Add(cardKpi4)
        Controls.Add(cardKpi3)
        Controls.Add(cardKpi2)
        Controls.Add(cardKpi1)
        Controls.Add(btnAddUser)
        Controls.Add(lblSubtitle)
        Controls.Add(lblGreeting)
        Name = "AdminDashboard"
        Text = "AdminDashboard"
        cardKpi1.ResumeLayout(False)
        cardKpi1.PerformLayout()
        cardKpi2.ResumeLayout(False)
        cardKpi2.PerformLayout()
        cardKpi3.ResumeLayout(False)
        cardKpi3.PerformLayout()
        cardKpi4.ResumeLayout(False)
        cardKpi4.PerformLayout()
        cardRecent.ResumeLayout(False)
        cardRecent.PerformLayout()
        cardStaff.ResumeLayout(False)
        cardStaff.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblGreeting As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents btnAddUser As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents lblKpi1Title As Label
    Friend WithEvents lblKpi1Value As Label
    Friend WithEvents lblKpi1Note As Label
    Friend WithEvents cardKpi1 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblKpi2Title As Label
    Friend WithEvents lblKpi2Value As Label
    Friend WithEvents lblKpi2Note As Label
    Friend WithEvents cardKpi2 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblKpi3Title As Label
    Friend WithEvents lblKpi3Value As Label
    Friend WithEvents lblKpi3Note As Label
    Friend WithEvents cardKpi3 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblKpi4Title As Label
    Friend WithEvents lblKpi4Value As Label
    Friend WithEvents lblKpi4Note As Label
    Friend WithEvents cardKpi4 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblRecentTitle As Label
    Friend WithEvents pnlActivity As Panel
    Friend WithEvents cardRecent As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblStaffTitle As Label
    Friend WithEvents lblRoleName1 As Label
    Friend WithEvents lblRoleCount1 As Label
    Friend WithEvents pnlFill1 As Panel
    Friend WithEvents pnlTrack1 As Panel
    Friend WithEvents lblRoleName2 As Label
    Friend WithEvents lblRoleCount2 As Label
    Friend WithEvents pnlFill2 As Panel
    Friend WithEvents pnlTrack2 As Panel
    Friend WithEvents lblRoleName3 As Label
    Friend WithEvents lblRoleCount3 As Label
    Friend WithEvents pnlFill3 As Panel
    Friend WithEvents pnlTrack3 As Panel
    Friend WithEvents lblStaffFooter As Label
    Friend WithEvents cardStaff As Ferrando.UI.WinForms.Controles.FCard

End Class

