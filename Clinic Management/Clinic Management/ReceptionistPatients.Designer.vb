<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReceptionistPatients
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        components = New System.ComponentModel.Container()
        lblHeaderTitle = New Label()
        lblHeaderSubtitle = New Label()
        btnRegisterPatient = New Ferrando.UI.WinForms.Controles.FButton()
        lblSearchIcon = New Label()
        txtSearch = New TextBox()
        cardSearch = New Ferrando.UI.WinForms.Controles.FCard()
        btnFilterAll = New Ferrando.UI.WinForms.Controles.FButton()
        btnFilterVisit = New Ferrando.UI.WinForms.Controles.FButton()
        cmsFilterAll = New ContextMenuStrip(components)
        miFilterAll = New ToolStripMenuItem()
        miFilterNew = New ToolStripMenuItem()
        miFilterReturning = New ToolStripMenuItem()
        cmsFilterVisit = New ContextMenuStrip(components)
        miSortNewest = New ToolStripMenuItem()
        miSortOldest = New ToolStripMenuItem()
        miSortName = New ToolStripMenuItem()
        miSortId = New ToolStripMenuItem()
        lblCardTitle = New Label()
        lblColPatient = New Label()
        lblColPatientId = New Label()
        lblColAgeSex = New Label()
        lblColContact = New Label()
        lblColLastVisit = New Label()
        pnlHeaderDivider = New Panel()
        lblEmpty = New Label()
        pnlRows = New Panel()
        cardTable = New Ferrando.UI.WinForms.Controles.FCard()
        cardSearch.SuspendLayout()
        cmsFilterAll.SuspendLayout()
        cmsFilterVisit.SuspendLayout()
        cardTable.SuspendLayout()
        pnlRows.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblHeaderTitle
        ' 
        lblHeaderTitle.AutoSize = True
        lblHeaderTitle.BackColor = Color.Transparent
        lblHeaderTitle.Font = New Font("Segoe UI", 18.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblHeaderTitle.ForeColor = Color.FromArgb(22, 51, 65)
        lblHeaderTitle.Location = New Point(28, 20)
        lblHeaderTitle.Name = "lblHeaderTitle"
        lblHeaderTitle.TabIndex = 1
        lblHeaderTitle.Text = "Patient directory"
        ' 
        ' lblHeaderSubtitle
        ' 
        lblHeaderSubtitle.AutoSize = True
        lblHeaderSubtitle.BackColor = Color.Transparent
        lblHeaderSubtitle.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblHeaderSubtitle.ForeColor = Color.FromArgb(115, 138, 148)
        lblHeaderSubtitle.Location = New Point(28, 54)
        lblHeaderSubtitle.Name = "lblHeaderSubtitle"
        lblHeaderSubtitle.TabIndex = 2
        lblHeaderSubtitle.Text = "1,248 registered patients • Single clinic record"
        ' 
        ' btnRegisterPatient
        ' 
        btnRegisterPatient.BackColor = Color.FromArgb(29, 124, 107)
        btnRegisterPatient.BorderColor = Color.FromArgb(29, 124, 107)
        btnRegisterPatient.BorderRadius = 8
        btnRegisterPatient.BorderSize = 0
        btnRegisterPatient.Cursor = Cursors.Hand
        btnRegisterPatient.FlatAppearance.BorderSize = 0
        btnRegisterPatient.FlatStyle = FlatStyle.Flat
        btnRegisterPatient.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRegisterPatient.ForeColor = Color.White
        btnRegisterPatient.Location = New Point(656, 24)
        btnRegisterPatient.MouseEnterBackColor = Color.FromArgb(23, 105, 90)
        btnRegisterPatient.MouseEnterBorderColor = Color.FromArgb(23, 105, 90)
        btnRegisterPatient.MouseEnterBorderSize = 0
        btnRegisterPatient.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRegisterPatient.MouseEnterForeColor = Color.White
        btnRegisterPatient.MouseLeaveBackColor = Color.FromArgb(29, 124, 107)
        btnRegisterPatient.MouseLeaveBorderColor = Color.FromArgb(29, 124, 107)
        btnRegisterPatient.MouseLeaveBorderSize = 0
        btnRegisterPatient.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRegisterPatient.MouseLeaveForeColor = Color.White
        btnRegisterPatient.Name = "btnRegisterPatient"
        btnRegisterPatient.Size = New Size(148, 32)
        btnRegisterPatient.TabIndex = 3
        btnRegisterPatient.Text = "+ Register patient"
        btnRegisterPatient.UseVisualStyleBackColor = False
        ' 
        ' lblSearchIcon
        ' 
        lblSearchIcon.AutoSize = True
        lblSearchIcon.BackColor = Color.Transparent
        lblSearchIcon.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSearchIcon.ForeColor = Color.FromArgb(100, 120, 130)
        lblSearchIcon.Location = New Point(12, 9)
        lblSearchIcon.Name = "lblSearchIcon"
        lblSearchIcon.TabIndex = 4
        lblSearchIcon.Text = "🔍"
        ' 
        ' txtSearch
        ' 
        txtSearch.BackColor = Color.White
        txtSearch.BorderStyle = BorderStyle.None
        txtSearch.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSearch.ForeColor = Color.FromArgb(100, 120, 130)
        txtSearch.Location = New Point(36, 10)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(512, 16)
        txtSearch.TabIndex = 5
        txtSearch.Text = "Search name, patient ID, phone..."
        ' 
        ' cardSearch
        ' 
        cardSearch.BackColor = Color.White
        cardSearch.BorderColor = Color.FromArgb(220, 228, 232)
        cardSearch.BorderHoverColor = Color.FromArgb(35, 137, 120)
        cardSearch.BorderRadius = 8
        cardSearch.BorderSize = 1
        cardSearch.Controls.Add(lblSearchIcon)
        cardSearch.Controls.Add(txtSearch)
        cardSearch.EnableShadow = False
        cardSearch.HoverTintColor = Color.White
        cardSearch.Location = New Point(28, 88)
        cardSearch.Name = "cardSearch"
        cardSearch.ShadowDepth = 2
        cardSearch.Size = New Size(560, 36)
        cardSearch.TabIndex = 6
        ' 
        ' btnFilterAll
        ' 
        btnFilterAll.BackColor = Color.White
        btnFilterAll.BorderColor = Color.FromArgb(210, 222, 228)
        btnFilterAll.BorderRadius = 8
        btnFilterAll.BorderSize = 1
        btnFilterAll.Cursor = Cursors.Hand
        btnFilterAll.FlatAppearance.BorderSize = 0
        btnFilterAll.FlatStyle = FlatStyle.Flat
        btnFilterAll.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnFilterAll.ForeColor = Color.FromArgb(30, 45, 55)
        btnFilterAll.Location = New Point(596, 88)
        btnFilterAll.MouseEnterBackColor = Color.FromArgb(248, 250, 252)
        btnFilterAll.MouseEnterBorderColor = Color.FromArgb(210, 222, 228)
        btnFilterAll.MouseEnterBorderSize = 1
        btnFilterAll.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnFilterAll.MouseEnterForeColor = Color.FromArgb(30, 45, 55)
        btnFilterAll.MouseLeaveBackColor = Color.White
        btnFilterAll.MouseLeaveBorderColor = Color.FromArgb(210, 222, 228)
        btnFilterAll.MouseLeaveBorderSize = 1
        btnFilterAll.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnFilterAll.MouseLeaveForeColor = Color.FromArgb(30, 45, 55)
        btnFilterAll.Name = "btnFilterAll"
        btnFilterAll.Size = New Size(100, 36)
        btnFilterAll.TabIndex = 7
        btnFilterAll.Text = "All patients"
        btnFilterAll.UseVisualStyleBackColor = False
        ' 
        ' btnFilterVisit
        ' 
        btnFilterVisit.BackColor = Color.White
        btnFilterVisit.BorderColor = Color.FromArgb(210, 222, 228)
        btnFilterVisit.BorderRadius = 8
        btnFilterVisit.BorderSize = 1
        btnFilterVisit.Cursor = Cursors.Hand
        btnFilterVisit.FlatAppearance.BorderSize = 0
        btnFilterVisit.FlatStyle = FlatStyle.Flat
        btnFilterVisit.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnFilterVisit.ForeColor = Color.FromArgb(30, 45, 55)
        btnFilterVisit.Location = New Point(704, 88)
        btnFilterVisit.MouseEnterBackColor = Color.FromArgb(248, 250, 252)
        btnFilterVisit.MouseEnterBorderColor = Color.FromArgb(210, 222, 228)
        btnFilterVisit.MouseEnterBorderSize = 1
        btnFilterVisit.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnFilterVisit.MouseEnterForeColor = Color.FromArgb(30, 45, 55)
        btnFilterVisit.MouseLeaveBackColor = Color.White
        btnFilterVisit.MouseLeaveBorderColor = Color.FromArgb(210, 222, 228)
        btnFilterVisit.MouseLeaveBorderSize = 1
        btnFilterVisit.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnFilterVisit.MouseLeaveForeColor = Color.FromArgb(30, 45, 55)
        btnFilterVisit.Name = "btnFilterVisit"
        btnFilterVisit.Size = New Size(100, 36)
        btnFilterVisit.TabIndex = 8
        btnFilterVisit.Text = "Last visit"
        btnFilterVisit.UseVisualStyleBackColor = False
        ' 
        ' cmsFilterAll
        ' 
        cmsFilterAll.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmsFilterAll.ForeColor = Color.FromArgb(30, 45, 55)
        cmsFilterAll.Items.AddRange(New ToolStripItem() {miFilterAll, miFilterNew, miFilterReturning})
        cmsFilterAll.Name = "cmsFilterAll"
        cmsFilterAll.ShowImageMargin = False
        cmsFilterAll.Size = New Size(170, 70)
        ' 
        ' miFilterAll
        ' 
        miFilterAll.Name = "miFilterAll"
        miFilterAll.Size = New Size(169, 22)
        miFilterAll.Tag = "all"
        miFilterAll.Text = "All patients"
        ' 
        ' miFilterNew
        ' 
        miFilterNew.Name = "miFilterNew"
        miFilterNew.Size = New Size(169, 22)
        miFilterNew.Tag = "new"
        miFilterNew.Text = "New patients"
        ' 
        ' miFilterReturning
        ' 
        miFilterReturning.Name = "miFilterReturning"
        miFilterReturning.Size = New Size(169, 22)
        miFilterReturning.Tag = "returning"
        miFilterReturning.Text = "Returning patients"
        ' 
        ' cmsFilterVisit
        ' 
        cmsFilterVisit.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmsFilterVisit.ForeColor = Color.FromArgb(30, 45, 55)
        cmsFilterVisit.Items.AddRange(New ToolStripItem() {miSortNewest, miSortOldest, miSortName, miSortId})
        cmsFilterVisit.Name = "cmsFilterVisit"
        cmsFilterVisit.ShowImageMargin = False
        cmsFilterVisit.Size = New Size(190, 92)
        ' 
        ' miSortNewest
        ' 
        miSortNewest.Name = "miSortNewest"
        miSortNewest.Size = New Size(189, 22)
        miSortNewest.Tag = "newest"
        miSortNewest.Text = "Last visit (newest first)"
        ' 
        ' miSortOldest
        ' 
        miSortOldest.Name = "miSortOldest"
        miSortOldest.Size = New Size(189, 22)
        miSortOldest.Tag = "oldest"
        miSortOldest.Text = "Last visit (oldest first)"
        ' 
        ' miSortName
        ' 
        miSortName.Name = "miSortName"
        miSortName.Size = New Size(189, 22)
        miSortName.Tag = "name"
        miSortName.Text = "Name (A-Z)"
        ' 
        ' miSortId
        ' 
        miSortId.Name = "miSortId"
        miSortId.Size = New Size(189, 22)
        miSortId.Tag = "id"
        miSortId.Text = "Patient ID"
        ' 
        ' lblCardTitle
        ' 
        lblCardTitle.AutoSize = True
        lblCardTitle.BackColor = Color.Transparent
        lblCardTitle.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCardTitle.ForeColor = Color.FromArgb(30, 45, 55)
        lblCardTitle.Location = New Point(19, 16)
        lblCardTitle.Name = "lblCardTitle"
        lblCardTitle.TabIndex = 9
        lblCardTitle.Text = "Patients"
        ' 
        ' lblColPatient
        ' 
        lblColPatient.AutoSize = True
        lblColPatient.BackColor = Color.Transparent
        lblColPatient.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblColPatient.ForeColor = Color.FromArgb(120, 135, 145)
        lblColPatient.Location = New Point(20, 54)
        lblColPatient.Name = "lblColPatient"
        lblColPatient.TabIndex = 10
        lblColPatient.Text = "Patient"
        ' 
        ' lblColPatientId
        ' 
        lblColPatientId.AutoSize = True
        lblColPatientId.BackColor = Color.Transparent
        lblColPatientId.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblColPatientId.ForeColor = Color.FromArgb(120, 135, 145)
        lblColPatientId.Location = New Point(180, 54)
        lblColPatientId.Name = "lblColPatientId"
        lblColPatientId.TabIndex = 11
        lblColPatientId.Text = "Patient ID"
        ' 
        ' lblColAgeSex
        ' 
        lblColAgeSex.AutoSize = True
        lblColAgeSex.BackColor = Color.Transparent
        lblColAgeSex.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblColAgeSex.ForeColor = Color.FromArgb(120, 135, 145)
        lblColAgeSex.Location = New Point(330, 54)
        lblColAgeSex.Name = "lblColAgeSex"
        lblColAgeSex.TabIndex = 12
        lblColAgeSex.Text = "Age / sex"
        ' 
        ' lblColContact
        ' 
        lblColContact.AutoSize = True
        lblColContact.BackColor = Color.Transparent
        lblColContact.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblColContact.ForeColor = Color.FromArgb(120, 135, 145)
        lblColContact.Location = New Point(480, 54)
        lblColContact.Name = "lblColContact"
        lblColContact.TabIndex = 13
        lblColContact.Text = "Contact"
        ' 
        ' lblColLastVisit
        ' 
        lblColLastVisit.AutoSize = True
        lblColLastVisit.BackColor = Color.Transparent
        lblColLastVisit.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblColLastVisit.ForeColor = Color.FromArgb(120, 135, 145)
        lblColLastVisit.Location = New Point(620, 54)
        lblColLastVisit.Name = "lblColLastVisit"
        lblColLastVisit.TabIndex = 14
        lblColLastVisit.Text = "Last visit"
        ' 
        ' pnlHeaderDivider
        ' 
        pnlHeaderDivider.BackColor = Color.FromArgb(242, 244, 247)
        pnlHeaderDivider.Location = New Point(20, 75)
        pnlHeaderDivider.Name = "pnlHeaderDivider"
        pnlHeaderDivider.Size = New Size(736, 1)
        pnlHeaderDivider.TabIndex = 15
        ' 
        ' lblEmpty
        ' 
        lblEmpty.AutoSize = True
        lblEmpty.BackColor = Color.Transparent
        lblEmpty.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblEmpty.ForeColor = Color.FromArgb(140, 155, 165)
        lblEmpty.Location = New Point(19, 100)
        lblEmpty.Name = "lblEmpty"
        lblEmpty.TabIndex = 16
        lblEmpty.Text = "No patients match your search."
        lblEmpty.Visible = False
        ' 
        ' pnlRows
        ' 
        pnlRows.AutoScroll = True
        pnlRows.BackColor = Color.White
        pnlRows.Location = New Point(20, 80)
        pnlRows.Name = "pnlRows"
        pnlRows.Size = New Size(736, 210)
        pnlRows.TabIndex = 17
        ' 
        ' cardTable
        ' 
        cardTable.BackColor = Color.White
        cardTable.BorderColor = Color.FromArgb(232, 237, 240)
        cardTable.BorderHoverColor = Color.FromArgb(210, 222, 228)
        cardTable.BorderRadius = 12
        cardTable.BorderSize = 1
        cardTable.Controls.Add(lblCardTitle)
        cardTable.Controls.Add(lblColPatient)
        cardTable.Controls.Add(lblColPatientId)
        cardTable.Controls.Add(lblColAgeSex)
        cardTable.Controls.Add(lblColContact)
        cardTable.Controls.Add(lblColLastVisit)
        cardTable.Controls.Add(pnlHeaderDivider)
        cardTable.Controls.Add(lblEmpty)
        cardTable.Controls.Add(pnlRows)
        cardTable.EnableShadow = True
        cardTable.HoverTintColor = Color.White
        cardTable.Location = New Point(28, 140)
        cardTable.Name = "cardTable"
        cardTable.ShadowDepth = 4
        cardTable.Size = New Size(776, 304)
        cardTable.TabIndex = 18
        ' 
        ' Patients
        ' 
        AutoScaleMode = AutoScaleMode.None
        BackColor = Color.FromArgb(244, 247, 249)
        Controls.Add(lblHeaderTitle)
        Controls.Add(lblHeaderSubtitle)
        Controls.Add(btnRegisterPatient)
        Controls.Add(cardSearch)
        Controls.Add(btnFilterAll)
        Controls.Add(btnFilterVisit)
        Controls.Add(cardTable)
        Name = "Patients"
        Size = New Size(831, 730)
        cardSearch.ResumeLayout(False)
        cardSearch.PerformLayout()
        cmsFilterAll.ResumeLayout(False)
        cmsFilterVisit.ResumeLayout(False)
        cardTable.ResumeLayout(False)
        cardTable.PerformLayout()
        pnlRows.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblHeaderTitle As Label
    Friend WithEvents lblHeaderSubtitle As Label
    Friend WithEvents btnRegisterPatient As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents lblSearchIcon As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents cardSearch As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents btnFilterAll As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnFilterVisit As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents cmsFilterAll As ContextMenuStrip
    Friend WithEvents miFilterAll As ToolStripMenuItem
    Friend WithEvents miFilterNew As ToolStripMenuItem
    Friend WithEvents miFilterReturning As ToolStripMenuItem
    Friend WithEvents cmsFilterVisit As ContextMenuStrip
    Friend WithEvents miSortNewest As ToolStripMenuItem
    Friend WithEvents miSortOldest As ToolStripMenuItem
    Friend WithEvents miSortName As ToolStripMenuItem
    Friend WithEvents miSortId As ToolStripMenuItem
    Friend WithEvents lblCardTitle As Label
    Friend WithEvents lblColPatient As Label
    Friend WithEvents lblColPatientId As Label
    Friend WithEvents lblColAgeSex As Label
    Friend WithEvents lblColContact As Label
    Friend WithEvents lblColLastVisit As Label
    Friend WithEvents pnlHeaderDivider As Panel
    Friend WithEvents lblEmpty As Label
    Friend WithEvents pnlRows As Panel
    Friend WithEvents cardTable As Ferrando.UI.WinForms.Controles.FCard

End Class