<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReceptionistConsultation

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
        mainScreen = New Panel()
        lblTitle = New Label()
        lblSubtitle = New Label()
        btnFilterVisit = New Ferrando.UI.WinForms.Controles.FButton()
        btnFilterAll = New Ferrando.UI.WinForms.Controles.FButton()
        btnFilterDoctor = New Ferrando.UI.WinForms.Controles.FButton()
        cardSearch = New Ferrando.UI.WinForms.Controles.FCard()
        txtSearch = New TextBox()
        lblSearchIcon = New Label()
        cardPatients = New Ferrando.UI.WinForms.Controles.FCard()
        lblEmpty = New Label()
        pnlRows = New Panel()
        pnlHeaderLine = New Panel()
        lblColLastVisit = New Label()
        lblColContact = New Label()
        lblColAgeSex = New Label()
        lblColPatientId = New Label()
        lblColPatient = New Label()
        lblCardTitle = New Label()
        mainScreen.SuspendLayout()
        cardSearch.SuspendLayout()
        cardPatients.SuspendLayout()
        SuspendLayout()
        ' 
        ' mainScreen
        ' 
        mainScreen.BackColor = Color.FromArgb(244, 247, 249)
        mainScreen.Controls.Add(cardPatients)
        mainScreen.Controls.Add(cardSearch)
        mainScreen.Controls.Add(btnFilterAll)
        mainScreen.Controls.Add(btnFilterDoctor)
        mainScreen.Controls.Add(btnFilterVisit)
        mainScreen.Controls.Add(lblSubtitle)
        mainScreen.Controls.Add(lblTitle)
        mainScreen.Dock = DockStyle.Fill
        mainScreen.Location = New Point(0, 0)
        mainScreen.Name = "mainScreen"
        mainScreen.Size = New Size(1008, 729)
        mainScreen.TabIndex = 1
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.BackColor = Color.Transparent
        lblTitle.Font = New Font("Segoe UI", 18.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.FromArgb(22, 51, 65)
        lblTitle.Location = New Point(28, 20)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(262, 32)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Consultation Directory"
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.AutoSize = True
        lblSubtitle.BackColor = Color.Transparent
        lblSubtitle.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSubtitle.ForeColor = Color.FromArgb(115, 138, 148)
        lblSubtitle.Location = New Point(28, 54)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(250, 15)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "All clinic consultations and clinical visit logs"
        ' 
        ' btnFilterVisit
        ' 
        btnFilterVisit.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnFilterVisit.BackColor = Color.White
        btnFilterVisit.BorderColor = Color.FromArgb(210, 222, 228)
        btnFilterVisit.BorderRadius = 8
        btnFilterVisit.BorderSize = 1
        btnFilterVisit.Cursor = Cursors.Hand
        btnFilterVisit.FlatAppearance.BorderSize = 0
        btnFilterVisit.FlatStyle = FlatStyle.Flat
        btnFilterVisit.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnFilterVisit.ForeColor = Color.FromArgb(30, 45, 55)
        btnFilterVisit.Location = New Point(711, 92)
        btnFilterVisit.MouseEnterBackColor = Color.FromArgb(248, 250, 252)
        btnFilterVisit.MouseEnterBorderColor = Color.FromArgb(210, 222, 228)
        btnFilterVisit.MouseEnterBorderSize = 1
        btnFilterVisit.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnFilterVisit.MouseEnterForeColor = Color.FromArgb(30, 45, 55)
        btnFilterVisit.MouseLeaveBackColor = Color.White
        btnFilterVisit.MouseLeaveBorderColor = Color.FromArgb(210, 222, 228)
        btnFilterVisit.MouseLeaveBorderSize = 1
        btnFilterVisit.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnFilterVisit.MouseLeaveForeColor = Color.FromArgb(30, 45, 55)
        btnFilterVisit.Name = "btnFilterVisit"
        btnFilterVisit.Size = New Size(92, 36)
        btnFilterVisit.TabIndex = 3
        btnFilterVisit.Text = "Last visit"
        btnFilterVisit.UseVisualStyleBackColor = False
        ' 
        ' btnFilterAll
        ' 
        btnFilterAll.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnFilterAll.BackColor = Color.White
        btnFilterAll.BorderColor = Color.FromArgb(210, 222, 228)
        btnFilterAll.BorderRadius = 8
        btnFilterAll.BorderSize = 1
        btnFilterAll.Cursor = Cursors.Hand
        btnFilterAll.FlatAppearance.BorderSize = 0
        btnFilterAll.FlatStyle = FlatStyle.Flat
        btnFilterAll.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnFilterAll.ForeColor = Color.FromArgb(30, 45, 55)
        btnFilterAll.Location = New Point(599, 92)
        btnFilterAll.MouseEnterBackColor = Color.FromArgb(248, 250, 252)
        btnFilterAll.MouseEnterBorderColor = Color.FromArgb(210, 222, 228)
        btnFilterAll.MouseEnterBorderSize = 1
        btnFilterAll.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnFilterAll.MouseEnterForeColor = Color.FromArgb(30, 45, 55)
        btnFilterAll.MouseLeaveBackColor = Color.White
        btnFilterAll.MouseLeaveBorderColor = Color.FromArgb(210, 222, 228)
        btnFilterAll.MouseLeaveBorderSize = 1
        btnFilterAll.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnFilterAll.MouseLeaveForeColor = Color.FromArgb(30, 45, 55)
        btnFilterAll.Name = "btnFilterAll"
        btnFilterAll.Size = New Size(142, 36)
        btnFilterAll.TabIndex = 2
        btnFilterAll.Text = "All consultations"
        btnFilterAll.UseVisualStyleBackColor = False
        ' 
        ' btnFilterDoctor
        ' 
        btnFilterDoctor.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnFilterDoctor.BackColor = Color.White
        btnFilterDoctor.BorderColor = Color.FromArgb(210, 222, 228)
        btnFilterDoctor.BorderRadius = 8
        btnFilterDoctor.BorderSize = 1
        btnFilterDoctor.Cursor = Cursors.Hand
        btnFilterDoctor.FlatAppearance.BorderSize = 0
        btnFilterDoctor.FlatStyle = FlatStyle.Flat
        btnFilterDoctor.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnFilterDoctor.ForeColor = Color.FromArgb(30, 45, 55)
        btnFilterDoctor.Location = New Point(475, 92)
        btnFilterDoctor.MouseEnterBackColor = Color.FromArgb(248, 250, 252)
        btnFilterDoctor.MouseEnterBorderColor = Color.FromArgb(210, 222, 228)
        btnFilterDoctor.MouseEnterBorderSize = 1
        btnFilterDoctor.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnFilterDoctor.MouseEnterForeColor = Color.FromArgb(30, 45, 55)
        btnFilterDoctor.MouseLeaveBackColor = Color.White
        btnFilterDoctor.MouseLeaveBorderColor = Color.FromArgb(210, 222, 228)
        btnFilterDoctor.MouseLeaveBorderSize = 1
        btnFilterDoctor.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnFilterDoctor.MouseLeaveForeColor = Color.FromArgb(30, 45, 55)
        btnFilterDoctor.Name = "btnFilterDoctor"
        btnFilterDoctor.Size = New Size(135, 36)
        btnFilterDoctor.TabIndex = 3
        btnFilterDoctor.Text = "All doctors"
        btnFilterDoctor.UseVisualStyleBackColor = False
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
        cardSearch.Size = New Size(563, 36)
        cardSearch.TabIndex = 4
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
        txtSearch.PlaceholderText = "Search name, patient ID, phone..."
        txtSearch.Size = New Size(511, 16)
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
        lblSearchIcon.Size = New Size(20, 17)
        lblSearchIcon.TabIndex = 0
        lblSearchIcon.Text = "o"
        ' 
        ' cardPatients
        ' 
        cardPatients.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        cardPatients.BackColor = Color.White
        cardPatients.BorderColor = Color.FromArgb(232, 237, 240)
        cardPatients.BorderHoverColor = Color.FromArgb(232, 237, 240)
        cardPatients.BorderRadius = 12
        cardPatients.BorderSize = 1
        cardPatients.Controls.Add(lblEmpty)
        cardPatients.Controls.Add(pnlRows)
        cardPatients.Controls.Add(pnlHeaderLine)
        cardPatients.Controls.Add(lblColLastVisit)
        cardPatients.Controls.Add(lblColContact)
        cardPatients.Controls.Add(lblColAgeSex)
        cardPatients.Controls.Add(lblColPatientId)
        cardPatients.Controls.Add(lblColPatient)
        cardPatients.Controls.Add(lblCardTitle)
        cardPatients.EnableShadow = True
        cardPatients.HoverTintColor = Color.White
        cardPatients.Location = New Point(28, 144)
        cardPatients.Name = "cardPatients"
        cardPatients.Padding = New Padding(0)
        cardPatients.ShadowDepth = 4
        cardPatients.Size = New Size(775, 320)
        cardPatients.TabIndex = 5
        ' 
        ' lblEmpty
        ' 
        lblEmpty.AutoSize = True
        lblEmpty.BackColor = Color.White
        lblEmpty.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblEmpty.ForeColor = Color.FromArgb(140, 155, 165)
        lblEmpty.Location = New Point(24, 100)
        lblEmpty.Name = "lblEmpty"
        lblEmpty.Size = New Size(179, 17)
        lblEmpty.TabIndex = 8
        lblEmpty.Text = "No patients match your search."
        lblEmpty.Visible = False
        ' 
        ' pnlRows
        ' 
        pnlRows.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pnlRows.BackColor = Color.White
        pnlRows.Location = New Point(20, 78)
        pnlRows.Name = "pnlRows"
        pnlRows.Size = New Size(735, 200)
        pnlRows.TabIndex = 7
        ' 
        ' pnlHeaderLine
        ' 
        pnlHeaderLine.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pnlHeaderLine.BackColor = Color.FromArgb(232, 237, 240)
        pnlHeaderLine.Location = New Point(20, 76)
        pnlHeaderLine.Name = "pnlHeaderLine"
        pnlHeaderLine.Size = New Size(735, 1)
        pnlHeaderLine.TabIndex = 6
        ' 
        ' lblColLastVisit
        ' 
        lblColLastVisit.AutoSize = True
        lblColLastVisit.BackColor = Color.White
        lblColLastVisit.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblColLastVisit.ForeColor = Color.FromArgb(120, 135, 145)
        lblColLastVisit.Location = New Point(620, 52)
        lblColLastVisit.Name = "lblColLastVisit"
        lblColLastVisit.Size = New Size(40, 15)
        lblColLastVisit.TabIndex = 5
        lblColLastVisit.Text = "Status"
        ' 
        ' lblColContact
        ' 
        lblColContact.AutoSize = True
        lblColContact.BackColor = Color.White
        lblColContact.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblColContact.ForeColor = Color.FromArgb(120, 135, 145)
        lblColContact.Location = New Point(468, 52)
        lblColContact.Name = "lblColContact"
        lblColContact.Size = New Size(57, 15)
        lblColContact.TabIndex = 4
        lblColContact.Text = "Visit type"
        ' 
        ' lblColAgeSex
        ' 
        lblColAgeSex.AutoSize = True
        lblColAgeSex.BackColor = Color.White
        lblColAgeSex.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblColAgeSex.ForeColor = Color.FromArgb(120, 135, 145)
        lblColAgeSex.Location = New Point(316, 52)
        lblColAgeSex.Name = "lblColAgeSex"
        lblColAgeSex.Size = New Size(43, 15)
        lblColAgeSex.TabIndex = 3
        lblColAgeSex.Text = "Doctor"
        ' 
        ' lblColPatientId
        ' 
        lblColPatientId.AutoSize = True
        lblColPatientId.BackColor = Color.White
        lblColPatientId.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblColPatientId.ForeColor = Color.FromArgb(120, 135, 145)
        lblColPatientId.Location = New Point(165, 52)
        lblColPatientId.Name = "lblColPatientId"
        lblColPatientId.Size = New Size(44, 15)
        lblColPatientId.TabIndex = 2
        lblColPatientId.Text = "Patient"
        ' 
        ' lblColPatient
        ' 
        lblColPatient.AutoSize = True
        lblColPatient.BackColor = Color.White
        lblColPatient.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblColPatient.ForeColor = Color.FromArgb(120, 135, 145)
        lblColPatient.Location = New Point(24, 52)
        lblColPatient.Name = "lblColPatient"
        lblColPatient.Size = New Size(31, 15)
        lblColPatient.TabIndex = 1
        lblColPatient.Text = "Date"
        ' 
        ' lblCardTitle
        ' 
        lblCardTitle.AutoSize = True
        lblCardTitle.BackColor = Color.White
        lblCardTitle.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCardTitle.ForeColor = Color.FromArgb(30, 45, 55)
        lblCardTitle.Location = New Point(24, 18)
        lblCardTitle.Name = "lblCardTitle"
        lblCardTitle.Size = New Size(99, 19)
        lblCardTitle.TabIndex = 0
        lblCardTitle.Text = "Consultations"
        ' 
        ' ReceptionistConsultation
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(244, 247, 249)
        ClientSize = New Size(1008, 729)
        Controls.Add(mainScreen)
        StartPosition = FormStartPosition.CenterScreen
        Name = "ReceptionistConsultation"
        Text = "ReceptionistConsultation"
        mainScreen.ResumeLayout(False)
        mainScreen.PerformLayout()
        cardSearch.ResumeLayout(False)
        cardSearch.PerformLayout()
        cardPatients.ResumeLayout(False)
        cardPatients.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents mainScreen As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents btnFilterVisit As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnFilterAll As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnFilterDoctor As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents cardSearch As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents lblSearchIcon As Label
    Friend WithEvents cardPatients As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblEmpty As Label
    Friend WithEvents pnlRows As Panel
    Friend WithEvents pnlHeaderLine As Panel
    Friend WithEvents lblColLastVisit As Label
    Friend WithEvents lblColContact As Label
    Friend WithEvents lblColAgeSex As Label
    Friend WithEvents lblColPatientId As Label
    Friend WithEvents lblColPatient As Label
    Friend WithEvents lblCardTitle As Label

End Class

