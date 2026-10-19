Imports FontAwesome.Sharp

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdminFormSidebar
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
        tlpRoot = New TableLayoutPanel()
        sideBar = New Panel()
        btnAudit = New Ferrando.UI.WinForms.Controles.FButton()
        btnLogout = New Ferrando.UI.WinForms.Controles.FButton()
        namePlaceHolder = New Ferrando.UI.WinForms.Controles.FCard()
        txtRole = New Label()
        txtName = New Label()
        FCard1 = New Ferrando.UI.WinForms.Controles.FCard()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        btnClinicSettings = New Ferrando.UI.WinForms.Controles.FButton()
        btnUserManagement = New Ferrando.UI.WinForms.Controles.FButton()
        btnDashboard = New Ferrando.UI.WinForms.Controles.FButton()
        mainScreen = New Panel()
        tlpRoot.SuspendLayout()
        sideBar.SuspendLayout()
        namePlaceHolder.SuspendLayout()
        FCard1.SuspendLayout()
        mainScreen.SuspendLayout()
        SuspendLayout()
        ' 
        ' tlpRoot (main responsive layout: fixed sidebar column + stretchy content column)
        ' 
        tlpRoot.ColumnCount = 2
        tlpRoot.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 178.0F))
        tlpRoot.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        tlpRoot.Controls.Add(sideBar, 0, 0)
        tlpRoot.Controls.Add(mainScreen, 1, 0)
        tlpRoot.Dock = DockStyle.Fill
        tlpRoot.Location = New Point(0, 0)
        tlpRoot.Margin = New Padding(0)
        tlpRoot.Name = "tlpRoot"
        tlpRoot.Padding = New Padding(0)
        tlpRoot.RowCount = 1
        tlpRoot.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        tlpRoot.Size = New Size(1008, 729)
        tlpRoot.TabIndex = 0
        ' 
        ' sideBar
        ' 
        sideBar.AutoScroll = True
        sideBar.AutoScrollMinSize = New Size(0, 440)
        sideBar.BackColor = Color.FromArgb(17, 54, 70)
        sideBar.Controls.Add(btnLogout)
        sideBar.Controls.Add(namePlaceHolder)
        sideBar.Controls.Add(FCard1)
        sideBar.Controls.Add(Label2)
        sideBar.Controls.Add(Label1)
        sideBar.Controls.Add(btnAudit)
        sideBar.Controls.Add(btnClinicSettings)
        sideBar.Controls.Add(btnUserManagement)
        sideBar.Controls.Add(btnDashboard)
        sideBar.Dock = DockStyle.Fill
        sideBar.Margin = New Padding(0)
        sideBar.Name = "sideBar"
        sideBar.TabIndex = 0
        ' 
        ' FCard1 (logo box)
        ' 
        FCard1.BackColor = Color.FromArgb(35, 137, 120)
        FCard1.BackgroundImageLayout = ImageLayout.None
        FCard1.BorderColor = Color.FromArgb(35, 137, 120)
        FCard1.BorderHoverColor = Color.FromArgb(35, 137, 120)
        FCard1.BorderRadius = 12
        FCard1.BorderSize = 1
        FCard1.Controls.Add(Label3)
        FCard1.EnableShadow = True
        FCard1.HoverTintColor = Color.FromArgb(35, 137, 120)
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
        Label3.ForeColor = Color.FromArgb(255, 254, 255)
        Label3.Location = New Point(17, 14)
        Label3.Name = "Label3"
        Label3.Size = New Size(19, 22)
        Label3.TabIndex = 1
        Label3.Text = "+"
        Label3.TextAlign = ContentAlignment.MiddleCenter
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
        ' btnDashboard
        ' 
        btnDashboard.BackColor = Color.FromArgb(17, 54, 70)
        btnDashboard.BorderColor = Color.Black
        btnDashboard.BorderRadius = 10
        btnDashboard.BorderSize = 0
        btnDashboard.FlatAppearance.BorderSize = 0
        btnDashboard.FlatStyle = FlatStyle.Flat
        btnDashboard.Font = New Font("Noto Sans Georgian", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDashboard.ForeColor = Color.FromArgb(182, 204, 210)
        btnDashboard.Location = New Point(3, 92)
        btnDashboard.MouseEnterBackColor = Color.FromArgb(39, 73, 87)
        btnDashboard.MouseEnterBorderColor = Color.FromArgb(39, 73, 87)
        btnDashboard.MouseEnterBorderSize = 0
        btnDashboard.MouseEnterFont = New Font("Noto Sans Georgian", 11.9999981F)
        btnDashboard.MouseEnterForeColor = Color.FromArgb(255, 254, 255)
        btnDashboard.MouseLeaveBackColor = Color.FromArgb(17, 54, 70)
        btnDashboard.MouseLeaveBorderColor = Color.Black
        btnDashboard.MouseLeaveBorderSize = 0
        btnDashboard.MouseLeaveFont = New Font("Noto Sans Georgian", 11.9999981F)
        btnDashboard.MouseLeaveForeColor = Color.FromArgb(182, 204, 210)
        btnDashboard.Name = "btnDashboard"
        btnDashboard.Size = New Size(171, 35)
        btnDashboard.TabIndex = 1
        btnDashboard.Text = "Dashboard"
        btnDashboard.UseVisualStyleBackColor = False
        ' 
        ' btnUserManagement
        ' 
        btnUserManagement.BackColor = Color.FromArgb(17, 54, 70)
        btnUserManagement.BorderColor = Color.Black
        btnUserManagement.BorderRadius = 10
        btnUserManagement.BorderSize = 0
        btnUserManagement.FlatAppearance.BorderSize = 0
        btnUserManagement.FlatStyle = FlatStyle.Flat
        btnUserManagement.Font = New Font("Noto Sans Georgian", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnUserManagement.ForeColor = Color.FromArgb(182, 204, 210)
        btnUserManagement.Location = New Point(3, 130)
        btnUserManagement.MouseEnterBackColor = Color.FromArgb(39, 73, 87)
        btnUserManagement.MouseEnterBorderColor = Color.FromArgb(39, 73, 87)
        btnUserManagement.MouseEnterBorderSize = 0
        btnUserManagement.MouseEnterFont = New Font("Noto Sans Georgian", 11.9999981F)
        btnUserManagement.MouseEnterForeColor = Color.FromArgb(255, 254, 255)
        btnUserManagement.MouseLeaveBackColor = Color.FromArgb(17, 54, 70)
        btnUserManagement.MouseLeaveBorderColor = Color.Black
        btnUserManagement.MouseLeaveBorderSize = 0
        btnUserManagement.MouseLeaveFont = New Font("Noto Sans Georgian", 11.9999981F)
        btnUserManagement.MouseLeaveForeColor = Color.FromArgb(182, 204, 210)
        btnUserManagement.Name = "btnUserManagement"
        btnUserManagement.Size = New Size(171, 35)
        btnUserManagement.TabIndex = 2
        btnUserManagement.Text = "User management"
        btnUserManagement.UseVisualStyleBackColor = False
        ' 
        ' btnClinicSettings
        ' 
        btnClinicSettings.BackColor = Color.FromArgb(17, 54, 70)
        btnClinicSettings.BorderColor = Color.Black
        btnClinicSettings.BorderRadius = 10
        btnClinicSettings.BorderSize = 0
        btnClinicSettings.FlatAppearance.BorderSize = 0
        btnClinicSettings.FlatStyle = FlatStyle.Flat
        btnClinicSettings.Font = New Font("Noto Sans Georgian", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnClinicSettings.ForeColor = Color.FromArgb(182, 204, 210)
        btnClinicSettings.Location = New Point(3, 168)
        btnClinicSettings.MouseEnterBackColor = Color.FromArgb(39, 73, 87)
        btnClinicSettings.MouseEnterBorderColor = Color.FromArgb(39, 73, 87)
        btnClinicSettings.MouseEnterBorderSize = 0
        btnClinicSettings.MouseEnterFont = New Font("Noto Sans Georgian", 11.9999981F)
        btnClinicSettings.MouseEnterForeColor = Color.FromArgb(255, 254, 255)
        btnClinicSettings.MouseLeaveBackColor = Color.FromArgb(17, 54, 70)
        btnClinicSettings.MouseLeaveBorderColor = Color.Black
        btnClinicSettings.MouseLeaveBorderSize = 0
        btnClinicSettings.MouseLeaveFont = New Font("Noto Sans Georgian", 11.9999981F)
        btnClinicSettings.MouseLeaveForeColor = Color.FromArgb(182, 204, 210)
        btnClinicSettings.Name = "btnClinicSettings"
        btnClinicSettings.Size = New Size(171, 35)
        btnClinicSettings.TabIndex = 3
        btnClinicSettings.Text = "Clinic settings"
        btnClinicSettings.UseVisualStyleBackColor = False
        ' 
        ' btnAudit
        ' 
        btnAudit.BackColor = Color.FromArgb(17, 54, 70)
        btnAudit.BorderColor = Color.Black
        btnAudit.BorderRadius = 10
        btnAudit.BorderSize = 0
        btnAudit.FlatAppearance.BorderSize = 0
        btnAudit.FlatStyle = FlatStyle.Flat
        btnAudit.Font = New Font("Noto Sans Georgian", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnAudit.ForeColor = Color.FromArgb(182, 204, 210)
        btnAudit.Location = New Point(3, 206)
        btnAudit.MouseEnterBackColor = Color.FromArgb(39, 73, 87)
        btnAudit.MouseEnterBorderColor = Color.FromArgb(39, 73, 87)
        btnAudit.MouseEnterBorderSize = 0
        btnAudit.MouseEnterFont = New Font("Noto Sans Georgian", 11.9999981F)
        btnAudit.MouseEnterForeColor = Color.FromArgb(255, 254, 255)
        btnAudit.MouseLeaveBackColor = Color.FromArgb(17, 54, 70)
        btnAudit.MouseLeaveBorderColor = Color.Black
        btnAudit.MouseLeaveBorderSize = 0
        btnAudit.MouseLeaveFont = New Font("Noto Sans Georgian", 11.9999981F)
        btnAudit.MouseLeaveForeColor = Color.FromArgb(182, 204, 210)
        btnAudit.Name = "btnAudit"
        btnAudit.Size = New Size(171, 35)
        btnAudit.TabIndex = 4
        btnAudit.Text = "Audit log"
        btnAudit.UseVisualStyleBackColor = False
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.FromArgb(CByte(17), CByte(54), CByte(70))
        btnLogout.BorderColor = Color.Black
        btnLogout.BorderRadius = 10
        btnLogout.BorderSize = 0
        btnLogout.FlatAppearance.BorderSize = 0
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Noto Sans Georgian", 10.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnLogout.ForeColor = Color.FromArgb(CByte(182), CByte(204), CByte(210))
        btnLogout.Location = New Point(3, 389)
        btnLogout.MouseEnterBackColor = Color.FromArgb(CByte(45), CByte(65), CByte(75))
        btnLogout.MouseEnterBorderColor = Color.Black
        btnLogout.MouseEnterBorderSize = 0
        btnLogout.MouseEnterFont = New Font("Noto Sans Georgian", 10.0F)
        btnLogout.MouseEnterForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnLogout.MouseLeaveBackColor = Color.FromArgb(CByte(17), CByte(54), CByte(70))
        btnLogout.MouseLeaveBorderColor = Color.Black
        btnLogout.MouseLeaveBorderSize = 0
        btnLogout.MouseLeaveFont = New Font("Noto Sans Georgian", 10.0F)
        btnLogout.MouseLeaveForeColor = Color.FromArgb(CByte(182), CByte(204), CByte(210))
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(162, 35)
        btnLogout.TabIndex = 12
        btnLogout.Text = "Log Out"
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' namePlaceHolder (profile card)
        ' 
        namePlaceHolder.BackColor = Color.FromArgb(29, 64, 79)
        namePlaceHolder.BorderColor = Color.FromArgb(29, 64, 79)
        namePlaceHolder.BorderHoverColor = Color.FromArgb(29, 64, 79)
        namePlaceHolder.BorderRadius = 12
        namePlaceHolder.BorderSize = 1
        namePlaceHolder.Controls.Add(txtRole)
        namePlaceHolder.Controls.Add(txtName)
        namePlaceHolder.EnableShadow = True
        namePlaceHolder.HoverTintColor = Color.FromArgb(29, 64, 79)
        namePlaceHolder.Location = New Point(8, 317)
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
        txtRole.ForeColor = Color.FromArgb(200, 215, 225)
        txtRole.Location = New Point(15, 35)
        txtRole.Name = "txtRole"
        txtRole.Size = New Size(112, 17)
        txtRole.TabIndex = 1
        txtRole.Text = "Clinic Administrator"
        ' 
        ' txtName
        ' 
        txtName.AutoSize = True
        txtName.Font = New Font("Noto Sans Georgian Bold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtName.ForeColor = Color.FromArgb(255, 254, 255)
        txtName.Location = New Point(15, 13)
        txtName.Name = "txtName"
        txtName.Size = New Size(128, 20)
        txtName.TabIndex = 0
        txtName.Text = "Rosa Dela Cruz"
        ' 
        ' mainScreen
        ' 
        mainScreen.AutoScroll = True
        mainScreen.AutoScrollMinSize = New Size(820, 620)
        mainScreen.BackColor = Color.FromArgb(244, 247, 249)
        mainScreen.Dock = DockStyle.Fill
        mainScreen.Margin = New Padding(0)
        mainScreen.Name = "mainScreen"
        mainScreen.TabIndex = 1
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1008, 729)
        Controls.Add(tlpRoot)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = True
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = " "
        tlpRoot.ResumeLayout(False)
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

    Friend WithEvents tlpRoot As TableLayoutPanel
    Friend WithEvents sideBar As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents mainScreen As Panel
    Friend WithEvents btnDashboard As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnClinicSettings As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnUserManagement As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnAudit As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnLogout As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents FCard1 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents Label3 As Label
    Friend WithEvents namePlaceHolder As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents txtName As Label
    Friend WithEvents txtRole As Label

End Class