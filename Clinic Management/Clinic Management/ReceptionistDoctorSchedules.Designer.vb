<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReceptionistDoctorSchedules
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
        btnAddAvailability = New Ferrando.UI.WinForms.Controles.FButton()
        lblDoc1Name = New Label()
        lblDoc1Role = New Label()
        cardDoctor1 = New Ferrando.UI.WinForms.Controles.FCard()
        lblDoc2Name = New Label()
        lblDoc2Role = New Label()
        cardDoctor2 = New Ferrando.UI.WinForms.Controles.FCard()
        lblLegendAppt = New Label()
        lblLegendAvail = New Label()
        lblLegendBlocked = New Label()
        cardDoctor1.SuspendLayout()
        cardDoctor2.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.BackColor = Color.Transparent
        lblTitle.Font = New Font("Segoe UI", 18.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.FromArgb(CByte(22), CByte(51), CByte(65))
        lblTitle.Location = New Point(26, 20)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(198, 32)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Doctor schedules"
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.AutoSize = True
        lblSubtitle.BackColor = Color.Transparent
        lblSubtitle.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSubtitle.ForeColor = Color.FromArgb(CByte(115), CByte(138), CByte(148))
        lblSubtitle.Location = New Point(28, 58)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(140, 15)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "Manage clinic availability"
        ' 
        ' btnAddAvailability
        ' 
        btnAddAvailability.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnAddAvailability.BackColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        btnAddAvailability.BorderColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        btnAddAvailability.BorderRadius = 8
        btnAddAvailability.BorderSize = 0
        btnAddAvailability.Cursor = Cursors.Hand
        btnAddAvailability.FlatAppearance.BorderSize = 0
        btnAddAvailability.FlatStyle = FlatStyle.Flat
        btnAddAvailability.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnAddAvailability.ForeColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        btnAddAvailability.Location = New Point(668, 22)
        btnAddAvailability.MouseEnterBackColor = Color.FromArgb(CByte(23), CByte(105), CByte(90))
        btnAddAvailability.MouseEnterBorderColor = Color.FromArgb(CByte(23), CByte(105), CByte(90))
        btnAddAvailability.MouseEnterBorderSize = 0
        btnAddAvailability.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnAddAvailability.MouseEnterForeColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        btnAddAvailability.MouseLeaveBackColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        btnAddAvailability.MouseLeaveBorderColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        btnAddAvailability.MouseLeaveBorderSize = 0
        btnAddAvailability.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnAddAvailability.MouseLeaveForeColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        btnAddAvailability.Name = "btnAddAvailability"
        btnAddAvailability.Size = New Size(134, 34)
        btnAddAvailability.TabIndex = 2
        btnAddAvailability.Text = "+ Add availability"
        btnAddAvailability.UseVisualStyleBackColor = False
        ' 
        ' lblDoc1Name
        ' 
        lblDoc1Name.AutoSize = False
        lblDoc1Name.BackColor = Color.Transparent
        lblDoc1Name.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDoc1Name.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblDoc1Name.Location = New Point(10, 7)
        lblDoc1Name.Size = New Size(200, 16)
        lblDoc1Name.TextAlign = ContentAlignment.MiddleCenter
        lblDoc1Name.Name = "lblDoc1Name"
        lblDoc1Name.TabIndex = 0
        lblDoc1Name.Text = "Doctor 1"
        ' 
        ' lblDoc1Role
        ' 
        lblDoc1Role.AutoSize = False
        lblDoc1Role.BackColor = Color.Transparent
        lblDoc1Role.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDoc1Role.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblDoc1Role.Location = New Point(10, 26)
        lblDoc1Role.Size = New Size(200, 14)
        lblDoc1Role.TextAlign = ContentAlignment.MiddleCenter
        lblDoc1Role.Name = "lblDoc1Role"
        lblDoc1Role.TabIndex = 1
        lblDoc1Role.Text = "Role"
        ' 
        ' cardDoctor1
        ' 
        cardDoctor1.BackColor = Color.White
        cardDoctor1.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardDoctor1.BorderHoverColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardDoctor1.BorderRadius = 10
        cardDoctor1.BorderSize = 1
        cardDoctor1.Controls.Add(lblDoc1Role)
        cardDoctor1.Controls.Add(lblDoc1Name)
        cardDoctor1.Cursor = Cursors.Hand
        cardDoctor1.EnableShadow = False
        cardDoctor1.HoverTintColor = Color.White
        cardDoctor1.Location = New Point(28, 92)
        cardDoctor1.Name = "cardDoctor1"
        cardDoctor1.ShadowDepth = 2
        cardDoctor1.Size = New Size(220, 44)
        cardDoctor1.TabIndex = 3
        ' 
        ' lblDoc2Name
        ' 
        lblDoc2Name.AutoSize = False
        lblDoc2Name.BackColor = Color.Transparent
        lblDoc2Name.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDoc2Name.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblDoc2Name.Location = New Point(10, 7)
        lblDoc2Name.Size = New Size(200, 16)
        lblDoc2Name.TextAlign = ContentAlignment.MiddleCenter
        lblDoc2Name.Name = "lblDoc2Name"
        lblDoc2Name.TabIndex = 0
        lblDoc2Name.Text = "Doctor 2"
        ' 
        ' lblDoc2Role
        ' 
        lblDoc2Role.AutoSize = False
        lblDoc2Role.BackColor = Color.Transparent
        lblDoc2Role.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDoc2Role.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblDoc2Role.Location = New Point(10, 26)
        lblDoc2Role.Size = New Size(200, 14)
        lblDoc2Role.TextAlign = ContentAlignment.MiddleCenter
        lblDoc2Role.Name = "lblDoc2Role"
        lblDoc2Role.TabIndex = 1
        lblDoc2Role.Text = "Role"
        ' 
        ' cardDoctor2
        ' 
        cardDoctor2.BackColor = Color.White
        cardDoctor2.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardDoctor2.BorderHoverColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardDoctor2.BorderRadius = 10
        cardDoctor2.BorderSize = 1
        cardDoctor2.Controls.Add(lblDoc2Role)
        cardDoctor2.Controls.Add(lblDoc2Name)
        cardDoctor2.Cursor = Cursors.Hand
        cardDoctor2.EnableShadow = False
        cardDoctor2.HoverTintColor = Color.White
        cardDoctor2.Location = New Point(256, 92)
        cardDoctor2.Name = "cardDoctor2"
        cardDoctor2.ShadowDepth = 2
        cardDoctor2.Size = New Size(220, 44)
        cardDoctor2.TabIndex = 4
        ' 
        ' lblLegendAppt
        ' 
        lblLegendAppt.AutoSize = True
        lblLegendAppt.BackColor = Color.Transparent
        lblLegendAppt.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblLegendAppt.ForeColor = Color.FromArgb(CByte(115), CByte(130), CByte(140))
        lblLegendAppt.Location = New Point(26, 498)
        lblLegendAppt.Name = "lblLegendAppt"
        lblLegendAppt.Size = New Size(63, 12)
        lblLegendAppt.TabIndex = 5
        lblLegendAppt.Text = "Appointment"
        ' 
        ' lblLegendAvail
        ' 
        lblLegendAvail.AutoSize = True
        lblLegendAvail.BackColor = Color.Transparent
        lblLegendAvail.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblLegendAvail.ForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        lblLegendAvail.Location = New Point(125, 498)
        lblLegendAvail.Name = "lblLegendAvail"
        lblLegendAvail.Size = New Size(43, 12)
        lblLegendAvail.TabIndex = 6
        lblLegendAvail.Text = "Available"
        ' 
        ' lblLegendBlocked
        ' 
        lblLegendBlocked.AutoSize = True
        lblLegendBlocked.BackColor = Color.Transparent
        lblLegendBlocked.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblLegendBlocked.ForeColor = Color.FromArgb(CByte(205), CByte(80), CByte(75))
        lblLegendBlocked.Location = New Point(195, 498)
        lblLegendBlocked.Name = "lblLegendBlocked"
        lblLegendBlocked.Size = New Size(99, 12)
        lblLegendBlocked.TabIndex = 7
        lblLegendBlocked.Text = "Blocked / unavailable"
        ' 
        ' DoctorSchedules
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(244), CByte(247), CByte(249))
        ClientSize = New Size(830, 729)
        Controls.Add(lblLegendBlocked)
        Controls.Add(lblLegendAvail)
        Controls.Add(lblLegendAppt)
        Controls.Add(cardDoctor2)
        Controls.Add(cardDoctor1)
        Controls.Add(btnAddAvailability)
        Controls.Add(lblSubtitle)
        Controls.Add(lblTitle)
        FormBorderStyle = FormBorderStyle.None
        Name = "ReceptionistDoctorSchedules"
        Text = "ReceptionistDoctorSchedules"
        cardDoctor1.ResumeLayout(False)
        cardDoctor1.PerformLayout()
        cardDoctor2.ResumeLayout(False)
        cardDoctor2.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents btnAddAvailability As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents lblDoc1Name As Label
    Friend WithEvents lblDoc1Role As Label
    Friend WithEvents cardDoctor1 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblDoc2Name As Label
    Friend WithEvents lblDoc2Role As Label
    Friend WithEvents cardDoctor2 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblLegendAppt As Label
    Friend WithEvents lblLegendAvail As Label
    Friend WithEvents lblLegendBlocked As Label

End Class

