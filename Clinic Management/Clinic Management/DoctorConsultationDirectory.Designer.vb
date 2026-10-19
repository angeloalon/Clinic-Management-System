Imports Ferrando.UI.WinForms.Controles

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DoctorConsultationDirectory
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
        cardConsultations = New FCard()
        lblEmpty = New Label()
        pnlRows = New Panel()
        pnlHeaderLine = New Panel()
        lblColAction = New Label()
        lblColStatus = New Label()
        lblColVisitType = New Label()
        lblColDoctor = New Label()
        lblColPatient = New Label()
        lblColDate = New Label()
        lblCardTitle = New Label()
        btnSort = New FButton()
        btnFilterAll = New FButton()
        cardSearch = New FCard()
        txtSearch = New TextBox()
        lblSearchIcon = New Label()
        btnStartConsultation = New FButton()
        lblSubtitle = New Label()
        lblTitle = New Label()
        mainScreen.SuspendLayout()
        cardConsultations.SuspendLayout()
        cardSearch.SuspendLayout()
        SuspendLayout()
        ' 
        ' mainScreen
        ' 
        mainScreen.BackColor = Color.FromArgb(CByte(244), CByte(247), CByte(249))
        mainScreen.Controls.Add(cardConsultations)
        mainScreen.Controls.Add(btnSort)
        mainScreen.Controls.Add(btnFilterAll)
        mainScreen.Controls.Add(cardSearch)
        mainScreen.Controls.Add(btnStartConsultation)
        mainScreen.Controls.Add(lblSubtitle)
        mainScreen.Controls.Add(lblTitle)
        mainScreen.Dock = DockStyle.Fill
        mainScreen.Location = New Point(0, 0)
        mainScreen.Name = "mainScreen"
        mainScreen.Size = New Size(1008, 729)
        mainScreen.TabIndex = 0
        ' 
        ' cardConsultations
        ' 
        cardConsultations.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        cardConsultations.BackColor = Color.White
        cardConsultations.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardConsultations.BorderHoverColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardConsultations.BorderRadius = 12
        cardConsultations.BorderSize = 1
        cardConsultations.Controls.Add(lblEmpty)
        cardConsultations.Controls.Add(pnlRows)
        cardConsultations.Controls.Add(pnlHeaderLine)
        cardConsultations.Controls.Add(lblColAction)
        cardConsultations.Controls.Add(lblColStatus)
        cardConsultations.Controls.Add(lblColVisitType)
        cardConsultations.Controls.Add(lblColDoctor)
        cardConsultations.Controls.Add(lblColPatient)
        cardConsultations.Controls.Add(lblColDate)
        cardConsultations.Controls.Add(lblCardTitle)
        cardConsultations.EnableShadow = True
        cardConsultations.HoverTintColor = Color.White
        cardConsultations.Location = New Point(28, 144)
        cardConsultations.Name = "cardConsultations"
        cardConsultations.ShadowDepth = 4
        cardConsultations.Size = New Size(952, 540)
        cardConsultations.TabIndex = 6
        ' 
        ' lblEmpty
        ' 
        lblEmpty.AutoSize = True
        lblEmpty.BackColor = Color.White
        lblEmpty.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblEmpty.ForeColor = Color.FromArgb(CByte(140), CByte(155), CByte(165))
        lblEmpty.Location = New Point(24, 100)
        lblEmpty.Name = "lblEmpty"
        lblEmpty.Size = New Size(220, 17)
        lblEmpty.TabIndex = 9
        lblEmpty.Text = "No consultations match your search."
        lblEmpty.Visible = False
        ' 
        ' pnlRows
        ' 
        pnlRows.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pnlRows.BackColor = Color.White
        pnlRows.Location = New Point(20, 78)
        pnlRows.Name = "pnlRows"
        pnlRows.Size = New Size(912, 400)
        pnlRows.TabIndex = 8
        ' 
        ' pnlHeaderLine
        ' 
        pnlHeaderLine.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pnlHeaderLine.BackColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        pnlHeaderLine.Location = New Point(20, 76)
        pnlHeaderLine.Name = "pnlHeaderLine"
        pnlHeaderLine.Size = New Size(912, 1)
        pnlHeaderLine.TabIndex = 7
        ' 
        ' lblColAction
        ' 
        lblColAction.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblColAction.AutoSize = True
        lblColAction.BackColor = Color.White
        lblColAction.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblColAction.ForeColor = Color.FromArgb(CByte(120), CByte(135), CByte(145))
        lblColAction.Location = New Point(872, 52)
        lblColAction.Name = "lblColAction"
        lblColAction.Size = New Size(42, 15)
        lblColAction.TabIndex = 6
        lblColAction.Text = "Action"
        ' 
        ' lblColStatus
        ' 
        lblColStatus.AutoSize = True
        lblColStatus.BackColor = Color.White
        lblColStatus.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblColStatus.ForeColor = Color.FromArgb(CByte(120), CByte(135), CByte(145))
        lblColStatus.Location = New Point(730, 52)
        lblColStatus.Name = "lblColStatus"
        lblColStatus.Size = New Size(39, 15)
        lblColStatus.TabIndex = 5
        lblColStatus.Text = "Status"
        ' 
        ' lblColVisitType
        ' 
        lblColVisitType.AutoSize = True
        lblColVisitType.BackColor = Color.White
        lblColVisitType.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblColVisitType.ForeColor = Color.FromArgb(CByte(120), CByte(135), CByte(145))
        lblColVisitType.Location = New Point(570, 52)
        lblColVisitType.Name = "lblColVisitType"
        lblColVisitType.Size = New Size(55, 15)
        lblColVisitType.TabIndex = 4
        lblColVisitType.Text = "Visit type"
        ' 
        ' lblColDoctor
        ' 
        lblColDoctor.AutoSize = True
        lblColDoctor.BackColor = Color.White
        lblColDoctor.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblColDoctor.ForeColor = Color.FromArgb(CByte(120), CByte(135), CByte(145))
        lblColDoctor.Location = New Point(390, 52)
        lblColDoctor.Name = "lblColDoctor"
        lblColDoctor.Size = New Size(43, 15)
        lblColDoctor.TabIndex = 3
        lblColDoctor.Text = "Doctor"
        ' 
        ' lblColPatient
        ' 
        lblColPatient.AutoSize = True
        lblColPatient.BackColor = Color.White
        lblColPatient.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblColPatient.ForeColor = Color.FromArgb(CByte(120), CByte(135), CByte(145))
        lblColPatient.Location = New Point(170, 52)
        lblColPatient.Name = "lblColPatient"
        lblColPatient.Size = New Size(44, 15)
        lblColPatient.TabIndex = 2
        lblColPatient.Text = "Patient"
        ' 
        ' lblColDate
        ' 
        lblColDate.AutoSize = True
        lblColDate.BackColor = Color.White
        lblColDate.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblColDate.ForeColor = Color.FromArgb(CByte(120), CByte(135), CByte(145))
        lblColDate.Location = New Point(24, 52)
        lblColDate.Name = "lblColDate"
        lblColDate.Size = New Size(31, 15)
        lblColDate.TabIndex = 1
        lblColDate.Text = "Date"
        ' 
        ' lblCardTitle
        ' 
        lblCardTitle.AutoSize = True
        lblCardTitle.BackColor = Color.White
        lblCardTitle.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCardTitle.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblCardTitle.Location = New Point(24, 18)
        lblCardTitle.Name = "lblCardTitle"
        lblCardTitle.Size = New Size(127, 19)
        lblCardTitle.TabIndex = 0
        lblCardTitle.Text = "Consultation Logs"
        ' 
        ' btnSort
        ' 
        btnSort.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnSort.BackColor = Color.White
        btnSort.BorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnSort.BorderRadius = 8
        btnSort.BorderSize = 1
        btnSort.Cursor = Cursors.Hand
        btnSort.FlatAppearance.BorderSize = 0
        btnSort.FlatStyle = FlatStyle.Flat
        btnSort.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSort.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnSort.Location = New Point(756, 92)
        btnSort.MouseEnterBackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        btnSort.MouseEnterBorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnSort.MouseEnterBorderSize = 1
        btnSort.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnSort.MouseEnterForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnSort.MouseLeaveBackColor = Color.White
        btnSort.MouseLeaveBorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnSort.MouseLeaveBorderSize = 1
        btnSort.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnSort.MouseLeaveForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnSort.Name = "btnSort"
        btnSort.Size = New Size(116, 36)
        btnSort.TabIndex = 5
        btnSort.Text = "Date (Newest) ▾"
        btnSort.UseVisualStyleBackColor = False
        ' 
        ' btnFilterAll
        ' 
        btnFilterAll.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnFilterAll.BackColor = Color.White
        btnFilterAll.BorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnFilterAll.BorderRadius = 8
        btnFilterAll.BorderSize = 1
        btnFilterAll.Cursor = Cursors.Hand
        btnFilterAll.FlatAppearance.BorderSize = 0
        btnFilterAll.FlatStyle = FlatStyle.Flat
        btnFilterAll.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnFilterAll.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnFilterAll.Location = New Point(602, 92)
        btnFilterAll.MouseEnterBackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        btnFilterAll.MouseEnterBorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnFilterAll.MouseEnterBorderSize = 1
        btnFilterAll.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnFilterAll.MouseEnterForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnFilterAll.MouseLeaveBackColor = Color.White
        btnFilterAll.MouseLeaveBorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnFilterAll.MouseLeaveBorderSize = 1
        btnFilterAll.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        btnFilterAll.MouseLeaveForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnFilterAll.Name = "btnFilterAll"
        btnFilterAll.Size = New Size(142, 36)
        btnFilterAll.TabIndex = 4
        btnFilterAll.Text = "All consultations ▾"
        btnFilterAll.UseVisualStyleBackColor = False
        ' 
        ' cardSearch
        ' 
        cardSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        cardSearch.BackColor = Color.White
        cardSearch.BorderColor = Color.FromArgb(CByte(220), CByte(228), CByte(232))
        cardSearch.BorderHoverColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        cardSearch.BorderRadius = 8
        cardSearch.BorderSize = 1
        cardSearch.Controls.Add(txtSearch)
        cardSearch.Controls.Add(lblSearchIcon)
        cardSearch.EnableShadow = False
        cardSearch.HoverTintColor = Color.White
        cardSearch.Location = New Point(28, 92)
        cardSearch.Name = "cardSearch"
        cardSearch.ShadowDepth = 2
        cardSearch.Size = New Size(560, 36)
        cardSearch.TabIndex = 3
        ' 
        ' txtSearch
        ' 
        txtSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtSearch.BackColor = Color.White
        txtSearch.BorderStyle = BorderStyle.None
        txtSearch.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSearch.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        txtSearch.Location = New Point(38, 10)
        txtSearch.Name = "txtSearch"
        txtSearch.PlaceholderText = "Search name, patient ID, diagnosis, visit type..."
        txtSearch.Size = New Size(508, 16)
        txtSearch.TabIndex = 1
        ' 
        ' lblSearchIcon
        ' 
        lblSearchIcon.AutoSize = True
        lblSearchIcon.BackColor = Color.White
        lblSearchIcon.Font = New Font("Segoe MDL2 Assets", 9.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSearchIcon.ForeColor = Color.FromArgb(CByte(140), CByte(155), CByte(165))
        lblSearchIcon.Location = New Point(12, 10)
        lblSearchIcon.Name = "lblSearchIcon"
        lblSearchIcon.Size = New Size(20, 13)
        lblSearchIcon.TabIndex = 0
        lblSearchIcon.Text = ""
        ' 
        ' btnStartConsultation
        ' 
        btnStartConsultation.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnStartConsultation.BackColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        btnStartConsultation.BorderColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        btnStartConsultation.BorderRadius = 8
        btnStartConsultation.BorderSize = 0
        btnStartConsultation.Cursor = Cursors.Hand
        btnStartConsultation.FlatAppearance.BorderSize = 0
        btnStartConsultation.FlatStyle = FlatStyle.Flat
        btnStartConsultation.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnStartConsultation.ForeColor = Color.White
        btnStartConsultation.Location = New Point(830, 24)
        btnStartConsultation.MouseEnterBackColor = Color.FromArgb(CByte(23), CByte(105), CByte(90))
        btnStartConsultation.MouseEnterBorderColor = Color.FromArgb(CByte(23), CByte(105), CByte(90))
        btnStartConsultation.MouseEnterBorderSize = 0
        btnStartConsultation.MouseEnterFont = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnStartConsultation.MouseEnterForeColor = Color.White
        btnStartConsultation.MouseLeaveBackColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        btnStartConsultation.MouseLeaveBorderColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        btnStartConsultation.MouseLeaveBorderSize = 0
        btnStartConsultation.MouseLeaveFont = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnStartConsultation.MouseLeaveForeColor = Color.White
        btnStartConsultation.Name = "btnStartConsultation"
        btnStartConsultation.Size = New Size(150, 36)
        btnStartConsultation.TabIndex = 2
        btnStartConsultation.Text = "+ Start Consultation"
        btnStartConsultation.UseVisualStyleBackColor = False
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.AutoSize = True
        lblSubtitle.BackColor = Color.Transparent
        lblSubtitle.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSubtitle.ForeColor = Color.FromArgb(CByte(115), CByte(138), CByte(148))
        lblSubtitle.Location = New Point(28, 54)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(325, 15)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "Review past consultations and start pending patient sessions"
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.BackColor = Color.Transparent
        lblTitle.Font = New Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.FromArgb(CByte(22), CByte(51), CByte(65))
        lblTitle.Location = New Point(28, 20)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(253, 32)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Consultation Directory"
        ' 
        ' DoctorConsultationDirectory
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(244), CByte(247), CByte(249))
        ClientSize = New Size(1008, 729)
        Controls.Add(mainScreen)
        FormBorderStyle = FormBorderStyle.None
        Name = "DoctorConsultationDirectory"
        StartPosition = FormStartPosition.CenterScreen
        Text = "DoctorConsultationDirectory"
        mainScreen.ResumeLayout(False)
        mainScreen.PerformLayout()
        cardConsultations.ResumeLayout(False)
        cardConsultations.PerformLayout()
        cardSearch.ResumeLayout(False)
        cardSearch.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents mainScreen As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents btnStartConsultation As FButton
    Friend WithEvents cardSearch As FCard
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents lblSearchIcon As Label
    Friend WithEvents btnFilterAll As FButton
    Friend WithEvents btnSort As FButton
    Friend WithEvents cardConsultations As FCard
    Friend WithEvents lblCardTitle As Label
    Friend WithEvents lblColDate As Label
    Friend WithEvents lblColPatient As Label
    Friend WithEvents lblColDoctor As Label
    Friend WithEvents lblColVisitType As Label
    Friend WithEvents lblColStatus As Label
    Friend WithEvents lblColAction As Label
    Friend WithEvents pnlHeaderLine As Panel
    Friend WithEvents pnlRows As Panel
    Friend WithEvents lblEmpty As Label

End Class
