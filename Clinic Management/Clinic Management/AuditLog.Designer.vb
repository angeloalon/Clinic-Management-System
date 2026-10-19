<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AuditLog
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
        lblTitle = New Label()
        lblSubtitle = New Label()
        btnExport = New Ferrando.UI.WinForms.Controles.FButton()
        txtSearch = New TextBox()
        cardSearch = New Ferrando.UI.WinForms.Controles.FCard()
        btnFilterUsers = New Ferrando.UI.WinForms.Controles.FButton()
        btnFilterActions = New Ferrando.UI.WinForms.Controles.FButton()
        btnFilterDate = New Ferrando.UI.WinForms.Controles.FButton()
        lblActivityTitle = New Label()
        lblCol1 = New Label()
        lblCol2 = New Label()
        lblCol3 = New Label()
        lblCol4 = New Label()
        lblCol5 = New Label()
        lblCol6 = New Label()
        divHeader = New Panel()
        lblRow1Col1 = New Label()
        lblRow1Col2 = New Label()
        lblRow1Col3 = New Label()
        lblRow1Col4 = New Label()
        lblRow1Col5 = New Label()
        cardResult1 = New Ferrando.UI.WinForms.Controles.FCard()
        lblResult1 = New Label()
        divRow1 = New Panel()
        lblRow2Col1 = New Label()
        lblRow2Col2 = New Label()
        lblRow2Col3 = New Label()
        lblRow2Col4 = New Label()
        lblRow2Col5 = New Label()
        cardResult2 = New Ferrando.UI.WinForms.Controles.FCard()
        lblResult2 = New Label()
        divRow2 = New Panel()
        lblRow3Col1 = New Label()
        lblRow3Col2 = New Label()
        lblRow3Col3 = New Label()
        lblRow3Col4 = New Label()
        lblRow3Col5 = New Label()
        cardResult3 = New Ferrando.UI.WinForms.Controles.FCard()
        lblResult3 = New Label()
        divRow3 = New Panel()
        lblRow4Col1 = New Label()
        lblRow4Col2 = New Label()
        lblRow4Col3 = New Label()
        lblRow4Col4 = New Label()
        lblRow4Col5 = New Label()
        cardResult4 = New Ferrando.UI.WinForms.Controles.FCard()
        lblResult4 = New Label()
        divRow4 = New Panel()
        lblRow5Col1 = New Label()
        lblRow5Col2 = New Label()
        lblRow5Col3 = New Label()
        lblRow5Col4 = New Label()
        lblRow5Col5 = New Label()
        cardResult5 = New Ferrando.UI.WinForms.Controles.FCard()
        lblResult5 = New Label()
        divRow5 = New Panel()
        lblRow6Col1 = New Label()
        lblRow6Col2 = New Label()
        lblRow6Col3 = New Label()
        lblRow6Col4 = New Label()
        lblRow6Col5 = New Label()
        cardResult6 = New Ferrando.UI.WinForms.Controles.FCard()
        lblResult6 = New Label()
        divRow6 = New Panel()
        lblRow7Col1 = New Label()
        lblRow7Col2 = New Label()
        lblRow7Col3 = New Label()
        lblRow7Col4 = New Label()
        lblRow7Col5 = New Label()
        cardResult7 = New Ferrando.UI.WinForms.Controles.FCard()
        lblResult7 = New Label()
        divRow7 = New Panel()
        lblRow8Col1 = New Label()
        lblRow8Col2 = New Label()
        lblRow8Col3 = New Label()
        lblRow8Col4 = New Label()
        lblRow8Col5 = New Label()
        cardResult8 = New Ferrando.UI.WinForms.Controles.FCard()
        lblResult8 = New Label()
        divRow8 = New Panel()
        cardActivity = New Ferrando.UI.WinForms.Controles.FCard()
        cardSearch.SuspendLayout()
        cardResult1.SuspendLayout()
        cardResult2.SuspendLayout()
        cardResult3.SuspendLayout()
        cardResult4.SuspendLayout()
        cardResult5.SuspendLayout()
        cardResult6.SuspendLayout()
        cardResult7.SuspendLayout()
        cardResult8.SuspendLayout()
        cardActivity.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.BackColor = Color.FromArgb(CByte(244), CByte(247), CByte(249))
        lblTitle.Font = New Font("Segoe UI", 18.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.FromArgb(CByte(22), CByte(51), CByte(65))
        lblTitle.Location = New Point(28, 18)
        lblTitle.Text = "Audit log"
        lblTitle.Name = "lblTitle"
        lblTitle.TabIndex = 0
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.AutoSize = True
        lblSubtitle.BackColor = Color.FromArgb(CByte(244), CByte(247), CByte(249))
        lblSubtitle.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSubtitle.ForeColor = Color.FromArgb(CByte(115), CByte(138), CByte(148))
        lblSubtitle.Location = New Point(30, 54)
        lblSubtitle.Text = "Every sign-in and record change, for accountability."
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.TabIndex = 1
        ' 
        ' btnExport
        ' 
        btnExport.BackColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        btnExport.BorderColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        btnExport.BorderRadius = 8
        btnExport.BorderSize = 0
        btnExport.Cursor = Cursors.Hand
        btnExport.FlatAppearance.BorderSize = 0
        btnExport.FlatStyle = FlatStyle.Flat
        btnExport.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnExport.ForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnExport.Location = New Point(713, 22)
        btnExport.MouseEnterBackColor = Color.FromArgb(CByte(23), CByte(105), CByte(90))
        btnExport.MouseEnterBorderColor = Color.FromArgb(CByte(23), CByte(105), CByte(90))
        btnExport.MouseEnterBorderSize = 0
        btnExport.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnExport.MouseEnterForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnExport.MouseLeaveBackColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        btnExport.MouseLeaveBorderColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        btnExport.MouseLeaveBorderSize = 0
        btnExport.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnExport.MouseLeaveForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnExport.Size = New Size(90, 30)
        btnExport.Text = "Export CSV"
        btnExport.UseVisualStyleBackColor = False
        btnExport.Name = "btnExport"
        btnExport.TabIndex = 2
        ' 
        ' cardSearch
        ' 
        cardSearch.Controls.Add(txtSearch)
        cardSearch.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardSearch.BorderColor = Color.FromArgb(CByte(220), CByte(228), CByte(232))
        cardSearch.BorderHoverColor = Color.FromArgb(CByte(220), CByte(228), CByte(232))
        cardSearch.BorderRadius = 8
        cardSearch.BorderSize = 1
        cardSearch.EnableShadow = False
        cardSearch.HoverTintColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardSearch.Location = New Point(28, 82)
        cardSearch.ShadowDepth = 2
        cardSearch.Size = New Size(485, 32)
        cardSearch.Name = "cardSearch"
        cardSearch.TabIndex = 4
        ' 
        ' txtSearch
        ' 
        txtSearch.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        txtSearch.BorderStyle = BorderStyle.None
        txtSearch.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSearch.ForeColor = Color.FromArgb(CByte(140), CByte(155), CByte(165))
        txtSearch.Location = New Point(12, 8)
        txtSearch.Size = New Size(461, 16)
        txtSearch.Text = "Search by user or action"
        txtSearch.Name = "txtSearch"
        txtSearch.TabIndex = 3
        ' 
        ' btnFilterUsers
        ' 
        btnFilterUsers.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        btnFilterUsers.BorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnFilterUsers.BorderRadius = 8
        btnFilterUsers.BorderSize = 1
        btnFilterUsers.Cursor = Cursors.Hand
        btnFilterUsers.FlatAppearance.BorderSize = 0
        btnFilterUsers.FlatStyle = FlatStyle.Flat
        btnFilterUsers.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnFilterUsers.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnFilterUsers.Location = New Point(523, 82)
        btnFilterUsers.MouseEnterBackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        btnFilterUsers.MouseEnterBorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnFilterUsers.MouseEnterBorderSize = 1
        btnFilterUsers.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnFilterUsers.MouseEnterForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnFilterUsers.MouseLeaveBackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        btnFilterUsers.MouseLeaveBorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnFilterUsers.MouseLeaveBorderSize = 1
        btnFilterUsers.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnFilterUsers.MouseLeaveForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnFilterUsers.Size = New Size(84, 32)
        btnFilterUsers.Text = "All users ▾"
        btnFilterUsers.UseVisualStyleBackColor = False
        btnFilterUsers.Name = "btnFilterUsers"
        btnFilterUsers.TabIndex = 5
        ' 
        ' btnFilterActions
        ' 
        btnFilterActions.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        btnFilterActions.BorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnFilterActions.BorderRadius = 8
        btnFilterActions.BorderSize = 1
        btnFilterActions.Cursor = Cursors.Hand
        btnFilterActions.FlatAppearance.BorderSize = 0
        btnFilterActions.FlatStyle = FlatStyle.Flat
        btnFilterActions.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnFilterActions.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnFilterActions.Location = New Point(615, 82)
        btnFilterActions.MouseEnterBackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        btnFilterActions.MouseEnterBorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnFilterActions.MouseEnterBorderSize = 1
        btnFilterActions.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnFilterActions.MouseEnterForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnFilterActions.MouseLeaveBackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        btnFilterActions.MouseLeaveBorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnFilterActions.MouseLeaveBorderSize = 1
        btnFilterActions.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnFilterActions.MouseLeaveForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnFilterActions.Size = New Size(92, 32)
        btnFilterActions.Text = "All actions ▾"
        btnFilterActions.UseVisualStyleBackColor = False
        btnFilterActions.Name = "btnFilterActions"
        btnFilterActions.TabIndex = 6
        ' 
        ' btnFilterDate
        ' 
        btnFilterDate.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        btnFilterDate.BorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnFilterDate.BorderRadius = 8
        btnFilterDate.BorderSize = 1
        btnFilterDate.Cursor = Cursors.Hand
        btnFilterDate.FlatAppearance.BorderSize = 0
        btnFilterDate.FlatStyle = FlatStyle.Flat
        btnFilterDate.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnFilterDate.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnFilterDate.Location = New Point(715, 82)
        btnFilterDate.MouseEnterBackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
        btnFilterDate.MouseEnterBorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnFilterDate.MouseEnterBorderSize = 1
        btnFilterDate.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnFilterDate.MouseEnterForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnFilterDate.MouseLeaveBackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        btnFilterDate.MouseLeaveBorderColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        btnFilterDate.MouseLeaveBorderSize = 1
        btnFilterDate.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnFilterDate.MouseLeaveForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        btnFilterDate.Size = New Size(88, 32)
        btnFilterDate.Text = "Last 7 days ▾"
        btnFilterDate.UseVisualStyleBackColor = False
        btnFilterDate.Name = "btnFilterDate"
        btnFilterDate.TabIndex = 7
        ' 
        ' cardActivity
        ' 
        cardActivity.Controls.Add(lblActivityTitle)
        cardActivity.Controls.Add(lblCol1)
        cardActivity.Controls.Add(lblCol2)
        cardActivity.Controls.Add(lblCol3)
        cardActivity.Controls.Add(lblCol4)
        cardActivity.Controls.Add(lblCol5)
        cardActivity.Controls.Add(lblCol6)
        cardActivity.Controls.Add(divHeader)
        cardActivity.Controls.Add(lblRow1Col1)
        cardActivity.Controls.Add(lblRow1Col2)
        cardActivity.Controls.Add(lblRow1Col3)
        cardActivity.Controls.Add(lblRow1Col4)
        cardActivity.Controls.Add(lblRow1Col5)
        cardActivity.Controls.Add(cardResult1)
        cardActivity.Controls.Add(divRow1)
        cardActivity.Controls.Add(lblRow2Col1)
        cardActivity.Controls.Add(lblRow2Col2)
        cardActivity.Controls.Add(lblRow2Col3)
        cardActivity.Controls.Add(lblRow2Col4)
        cardActivity.Controls.Add(lblRow2Col5)
        cardActivity.Controls.Add(cardResult2)
        cardActivity.Controls.Add(divRow2)
        cardActivity.Controls.Add(lblRow3Col1)
        cardActivity.Controls.Add(lblRow3Col2)
        cardActivity.Controls.Add(lblRow3Col3)
        cardActivity.Controls.Add(lblRow3Col4)
        cardActivity.Controls.Add(lblRow3Col5)
        cardActivity.Controls.Add(cardResult3)
        cardActivity.Controls.Add(divRow3)
        cardActivity.Controls.Add(lblRow4Col1)
        cardActivity.Controls.Add(lblRow4Col2)
        cardActivity.Controls.Add(lblRow4Col3)
        cardActivity.Controls.Add(lblRow4Col4)
        cardActivity.Controls.Add(lblRow4Col5)
        cardActivity.Controls.Add(cardResult4)
        cardActivity.Controls.Add(divRow4)
        cardActivity.Controls.Add(lblRow5Col1)
        cardActivity.Controls.Add(lblRow5Col2)
        cardActivity.Controls.Add(lblRow5Col3)
        cardActivity.Controls.Add(lblRow5Col4)
        cardActivity.Controls.Add(lblRow5Col5)
        cardActivity.Controls.Add(cardResult5)
        cardActivity.Controls.Add(divRow5)
        cardActivity.Controls.Add(lblRow6Col1)
        cardActivity.Controls.Add(lblRow6Col2)
        cardActivity.Controls.Add(lblRow6Col3)
        cardActivity.Controls.Add(lblRow6Col4)
        cardActivity.Controls.Add(lblRow6Col5)
        cardActivity.Controls.Add(cardResult6)
        cardActivity.Controls.Add(divRow6)
        cardActivity.Controls.Add(lblRow7Col1)
        cardActivity.Controls.Add(lblRow7Col2)
        cardActivity.Controls.Add(lblRow7Col3)
        cardActivity.Controls.Add(lblRow7Col4)
        cardActivity.Controls.Add(lblRow7Col5)
        cardActivity.Controls.Add(cardResult7)
        cardActivity.Controls.Add(divRow7)
        cardActivity.Controls.Add(lblRow8Col1)
        cardActivity.Controls.Add(lblRow8Col2)
        cardActivity.Controls.Add(lblRow8Col3)
        cardActivity.Controls.Add(lblRow8Col4)
        cardActivity.Controls.Add(lblRow8Col5)
        cardActivity.Controls.Add(cardResult8)
        cardActivity.Controls.Add(divRow8)
        cardActivity.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardActivity.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardActivity.BorderHoverColor = Color.FromArgb(CByte(210), CByte(222), CByte(228))
        cardActivity.BorderRadius = 12
        cardActivity.BorderSize = 1
        cardActivity.EnableShadow = True
        cardActivity.HoverTintColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardActivity.Location = New Point(28, 133)
        cardActivity.ShadowDepth = 4
        cardActivity.Size = New Size(775, 451)
        cardActivity.Name = "cardActivity"
        cardActivity.TabIndex = 80
        ' 
        ' lblActivityTitle
        ' 
        lblActivityTitle.AutoSize = True
        lblActivityTitle.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblActivityTitle.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblActivityTitle.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblActivityTitle.Location = New Point(16, 13)
        lblActivityTitle.Text = "Activity"
        lblActivityTitle.Name = "lblActivityTitle"
        lblActivityTitle.TabIndex = 8
        ' 
        ' lblCol1
        ' 
        lblCol1.AutoSize = True
        lblCol1.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblCol1.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCol1.ForeColor = Color.FromArgb(CByte(120), CByte(135), CByte(145))
        lblCol1.Location = New Point(16, 49)
        lblCol1.Text = "Time"
        lblCol1.Name = "lblCol1"
        lblCol1.TabIndex = 9
        ' 
        ' lblCol2
        ' 
        lblCol2.AutoSize = True
        lblCol2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblCol2.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCol2.ForeColor = Color.FromArgb(CByte(120), CByte(135), CByte(145))
        lblCol2.Location = New Point(112, 49)
        lblCol2.Text = "User"
        lblCol2.Name = "lblCol2"
        lblCol2.TabIndex = 10
        ' 
        ' lblCol3
        ' 
        lblCol3.AutoSize = True
        lblCol3.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblCol3.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCol3.ForeColor = Color.FromArgb(CByte(120), CByte(135), CByte(145))
        lblCol3.Location = New Point(214, 49)
        lblCol3.Text = "Role"
        lblCol3.Name = "lblCol3"
        lblCol3.TabIndex = 11
        ' 
        ' lblCol4
        ' 
        lblCol4.AutoSize = True
        lblCol4.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblCol4.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCol4.ForeColor = Color.FromArgb(CByte(120), CByte(135), CByte(145))
        lblCol4.Location = New Point(285, 49)
        lblCol4.Text = "Action"
        lblCol4.Name = "lblCol4"
        lblCol4.TabIndex = 12
        ' 
        ' lblCol5
        ' 
        lblCol5.AutoSize = True
        lblCol5.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblCol5.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCol5.ForeColor = Color.FromArgb(CByte(120), CByte(135), CByte(145))
        lblCol5.Location = New Point(445, 49)
        lblCol5.Text = "Details"
        lblCol5.Name = "lblCol5"
        lblCol5.TabIndex = 13
        ' 
        ' lblCol6
        ' 
        lblCol6.AutoSize = True
        lblCol6.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblCol6.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCol6.ForeColor = Color.FromArgb(CByte(120), CByte(135), CByte(145))
        lblCol6.Location = New Point(702, 49)
        lblCol6.Text = "Result"
        lblCol6.Name = "lblCol6"
        lblCol6.TabIndex = 14
        ' 
        ' divHeader
        ' 
        divHeader.BackColor = Color.FromArgb(CByte(242), CByte(244), CByte(247))
        divHeader.Location = New Point(16, 70)
        divHeader.Size = New Size(743, 1)
        divHeader.Name = "divHeader"
        divHeader.TabIndex = 15
        ' 
        ' lblRow1Col1
        ' 
        lblRow1Col1.AutoSize = True
        lblRow1Col1.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow1Col1.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow1Col1.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow1Col1.Location = New Point(16, 93)
        lblRow1Col1.Text = "Sep 29, 9:12 AM"
        lblRow1Col1.Name = "lblRow1Col1"
        lblRow1Col1.TabIndex = 16
        ' 
        ' lblRow1Col2
        ' 
        lblRow1Col2.AutoSize = True
        lblRow1Col2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow1Col2.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow1Col2.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblRow1Col2.Location = New Point(112, 93)
        lblRow1Col2.Text = "Elena Cruz"
        lblRow1Col2.Name = "lblRow1Col2"
        lblRow1Col2.TabIndex = 17
        ' 
        ' lblRow1Col3
        ' 
        lblRow1Col3.AutoSize = True
        lblRow1Col3.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow1Col3.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow1Col3.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow1Col3.Location = New Point(214, 93)
        lblRow1Col3.Text = "Doctor"
        lblRow1Col3.Name = "lblRow1Col3"
        lblRow1Col3.TabIndex = 18
        ' 
        ' lblRow1Col4
        ' 
        lblRow1Col4.AutoSize = True
        lblRow1Col4.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow1Col4.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow1Col4.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow1Col4.Location = New Point(298, 93)
        lblRow1Col4.Text = "Availability updated"
        lblRow1Col4.Name = "lblRow1Col4"
        lblRow1Col4.TabIndex = 19
        ' 
        ' lblRow1Col5
        ' 
        lblRow1Col5.AutoSize = True
        lblRow1Col5.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow1Col5.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow1Col5.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow1Col5.Location = New Point(450, 93)
        lblRow1Col5.Text = "Tuesday slots changed to 9 AM – 12 PM"
        lblRow1Col5.Name = "lblRow1Col5"
        lblRow1Col5.TabIndex = 20
        ' 
        ' cardResult1
        ' 
        cardResult1.Controls.Add(lblResult1)
        cardResult1.BackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        cardResult1.BorderColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        cardResult1.BorderHoverColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        cardResult1.BorderRadius = 10
        cardResult1.BorderSize = 0
        cardResult1.EnableShadow = False
        cardResult1.HoverTintColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        cardResult1.Location = New Point(704, 89)
        cardResult1.ShadowDepth = 2
        cardResult1.Size = New Size(56, 22)
        cardResult1.Name = "cardResult1"
        cardResult1.TabIndex = 21
        ' 
        ' lblResult1
        ' 
        lblResult1.AutoSize = False
        lblResult1.BackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        lblResult1.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblResult1.ForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        lblResult1.Location = New Point(0, 0)
        lblResult1.Size = New Size(56, 22)
        lblResult1.TextAlign = ContentAlignment.MiddleCenter
        lblResult1.Text = "Success"
        lblResult1.Name = "lblResult1"
        lblResult1.TabIndex = 22
        ' 
        ' divRow1
        ' 
        divRow1.BackColor = Color.FromArgb(CByte(242), CByte(244), CByte(247))
        divRow1.Location = New Point(16, 123)
        divRow1.Size = New Size(743, 1)
        divRow1.Name = "divRow1"
        divRow1.TabIndex = 23
        ' 
        ' lblRow2Col1
        ' 
        lblRow2Col1.AutoSize = True
        lblRow2Col1.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow2Col1.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow2Col1.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow2Col1.Location = New Point(16, 139)
        lblRow2Col1.Text = "Sep 29, 8:47 AM"
        lblRow2Col1.Name = "lblRow2Col1"
        lblRow2Col1.TabIndex = 24
        ' 
        ' lblRow2Col2
        ' 
        lblRow2Col2.AutoSize = True
        lblRow2Col2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow2Col2.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow2Col2.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblRow2Col2.Location = New Point(112, 139)
        lblRow2Col2.Text = "Ana Reyes"
        lblRow2Col2.Name = "lblRow2Col2"
        lblRow2Col2.TabIndex = 25
        ' 
        ' lblRow2Col3
        ' 
        lblRow2Col3.AutoSize = True
        lblRow2Col3.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow2Col3.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow2Col3.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow2Col3.Location = New Point(214, 139)
        lblRow2Col3.Text = "Receptionist"
        lblRow2Col3.Name = "lblRow2Col3"
        lblRow2Col3.TabIndex = 26
        ' 
        ' lblRow2Col4
        ' 
        lblRow2Col4.AutoSize = True
        lblRow2Col4.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow2Col4.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow2Col4.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow2Col4.Location = New Point(298, 139)
        lblRow2Col4.Text = "Appointments booked"
        lblRow2Col4.Name = "lblRow2Col4"
        lblRow2Col4.TabIndex = 27
        ' 
        ' lblRow2Col5
        ' 
        lblRow2Col5.AutoSize = True
        lblRow2Col5.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow2Col5.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow2Col5.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow2Col5.Location = New Point(450, 139)
        lblRow2Col5.Text = "8 appointments created"
        lblRow2Col5.Name = "lblRow2Col5"
        lblRow2Col5.TabIndex = 28
        ' 
        ' cardResult2
        ' 
        cardResult2.Controls.Add(lblResult2)
        cardResult2.BackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        cardResult2.BorderColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        cardResult2.BorderHoverColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        cardResult2.BorderRadius = 10
        cardResult2.BorderSize = 0
        cardResult2.EnableShadow = False
        cardResult2.HoverTintColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        cardResult2.Location = New Point(704, 135)
        cardResult2.ShadowDepth = 2
        cardResult2.Size = New Size(56, 22)
        cardResult2.Name = "cardResult2"
        cardResult2.TabIndex = 29
        ' 
        ' lblResult2
        ' 
        lblResult2.AutoSize = False
        lblResult2.BackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        lblResult2.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblResult2.ForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        lblResult2.Location = New Point(0, 0)
        lblResult2.Size = New Size(56, 22)
        lblResult2.TextAlign = ContentAlignment.MiddleCenter
        lblResult2.Text = "Success"
        lblResult2.Name = "lblResult2"
        lblResult2.TabIndex = 30
        ' 
        ' divRow2
        ' 
        divRow2.BackColor = Color.FromArgb(CByte(242), CByte(244), CByte(247))
        divRow2.Location = New Point(16, 169)
        divRow2.Size = New Size(743, 1)
        divRow2.Name = "divRow2"
        divRow2.TabIndex = 31
        ' 
        ' lblRow3Col1
        ' 
        lblRow3Col1.AutoSize = True
        lblRow3Col1.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow3Col1.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow3Col1.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow3Col1.Location = New Point(16, 185)
        lblRow3Col1.Text = "Sep 28, 4:05 PM"
        lblRow3Col1.Name = "lblRow3Col1"
        lblRow3Col1.TabIndex = 32
        ' 
        ' lblRow3Col2
        ' 
        lblRow3Col2.AutoSize = True
        lblRow3Col2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow3Col2.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow3Col2.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblRow3Col2.Location = New Point(112, 185)
        lblRow3Col2.Text = "Rosa Dela Cruz"
        lblRow3Col2.Name = "lblRow3Col2"
        lblRow3Col2.TabIndex = 33
        ' 
        ' lblRow3Col3
        ' 
        lblRow3Col3.AutoSize = True
        lblRow3Col3.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow3Col3.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow3Col3.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow3Col3.Location = New Point(214, 185)
        lblRow3Col3.Text = "Administrator"
        lblRow3Col3.Name = "lblRow3Col3"
        lblRow3Col3.TabIndex = 34
        ' 
        ' lblRow3Col4
        ' 
        lblRow3Col4.AutoSize = True
        lblRow3Col4.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow3Col4.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow3Col4.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow3Col4.Location = New Point(298, 185)
        lblRow3Col4.Text = "User created"
        lblRow3Col4.Name = "lblRow3Col4"
        lblRow3Col4.TabIndex = 35
        ' 
        ' lblRow3Col5
        ' 
        lblRow3Col5.AutoSize = True
        lblRow3Col5.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow3Col5.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow3Col5.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow3Col5.Location = New Point(450, 185)
        lblRow3Col5.Text = "Mark Tolentino (Receptionist)"
        lblRow3Col5.Name = "lblRow3Col5"
        lblRow3Col5.TabIndex = 36
        ' 
        ' cardResult3
        ' 
        cardResult3.Controls.Add(lblResult3)
        cardResult3.BackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        cardResult3.BorderColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        cardResult3.BorderHoverColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        cardResult3.BorderRadius = 10
        cardResult3.BorderSize = 0
        cardResult3.EnableShadow = False
        cardResult3.HoverTintColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        cardResult3.Location = New Point(704, 181)
        cardResult3.ShadowDepth = 2
        cardResult3.Size = New Size(56, 22)
        cardResult3.Name = "cardResult3"
        cardResult3.TabIndex = 37
        ' 
        ' lblResult3
        ' 
        lblResult3.AutoSize = False
        lblResult3.BackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        lblResult3.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblResult3.ForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        lblResult3.Location = New Point(0, 0)
        lblResult3.Size = New Size(56, 22)
        lblResult3.TextAlign = ContentAlignment.MiddleCenter
        lblResult3.Text = "Success"
        lblResult3.Name = "lblResult3"
        lblResult3.TabIndex = 38
        ' 
        ' divRow3
        ' 
        divRow3.BackColor = Color.FromArgb(CByte(242), CByte(244), CByte(247))
        divRow3.Location = New Point(16, 215)
        divRow3.Size = New Size(743, 1)
        divRow3.Name = "divRow3"
        divRow3.TabIndex = 39
        ' 
        ' lblRow4Col1
        ' 
        lblRow4Col1.AutoSize = True
        lblRow4Col1.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow4Col1.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow4Col1.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow4Col1.Location = New Point(16, 231)
        lblRow4Col1.Text = "Sep 28, 3:40 PM"
        lblRow4Col1.Name = "lblRow4Col1"
        lblRow4Col1.TabIndex = 40
        ' 
        ' lblRow4Col2
        ' 
        lblRow4Col2.AutoSize = True
        lblRow4Col2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow4Col2.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow4Col2.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblRow4Col2.Location = New Point(112, 231)
        lblRow4Col2.Text = "Rosa Dela Cruz"
        lblRow4Col2.Name = "lblRow4Col2"
        lblRow4Col2.TabIndex = 41
        ' 
        ' lblRow4Col3
        ' 
        lblRow4Col3.AutoSize = True
        lblRow4Col3.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow4Col3.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow4Col3.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow4Col3.Location = New Point(214, 231)
        lblRow4Col3.Text = "Administrator"
        lblRow4Col3.Name = "lblRow4Col3"
        lblRow4Col3.TabIndex = 42
        ' 
        ' lblRow4Col4
        ' 
        lblRow4Col4.AutoSize = True
        lblRow4Col4.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow4Col4.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow4Col4.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow4Col4.Location = New Point(298, 231)
        lblRow4Col4.Text = "Password reset"
        lblRow4Col4.Name = "lblRow4Col4"
        lblRow4Col4.TabIndex = 43
        ' 
        ' lblRow4Col5
        ' 
        lblRow4Col5.AutoSize = True
        lblRow4Col5.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow4Col5.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow4Col5.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow4Col5.Location = New Point(450, 231)
        lblRow4Col5.Text = "Dr. Paolo Vega"
        lblRow4Col5.Name = "lblRow4Col5"
        lblRow4Col5.TabIndex = 44
        ' 
        ' cardResult4
        ' 
        cardResult4.Controls.Add(lblResult4)
        cardResult4.BackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        cardResult4.BorderColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        cardResult4.BorderHoverColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        cardResult4.BorderRadius = 10
        cardResult4.BorderSize = 0
        cardResult4.EnableShadow = False
        cardResult4.HoverTintColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        cardResult4.Location = New Point(704, 227)
        cardResult4.ShadowDepth = 2
        cardResult4.Size = New Size(56, 22)
        cardResult4.Name = "cardResult4"
        cardResult4.TabIndex = 45
        ' 
        ' lblResult4
        ' 
        lblResult4.AutoSize = False
        lblResult4.BackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        lblResult4.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblResult4.ForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        lblResult4.Location = New Point(0, 0)
        lblResult4.Size = New Size(56, 22)
        lblResult4.TextAlign = ContentAlignment.MiddleCenter
        lblResult4.Text = "Success"
        lblResult4.Name = "lblResult4"
        lblResult4.TabIndex = 46
        ' 
        ' divRow4
        ' 
        divRow4.BackColor = Color.FromArgb(CByte(242), CByte(244), CByte(247))
        divRow4.Location = New Point(16, 261)
        divRow4.Size = New Size(743, 1)
        divRow4.Name = "divRow4"
        divRow4.TabIndex = 47
        ' 
        ' lblRow5Col1
        ' 
        lblRow5Col1.AutoSize = True
        lblRow5Col1.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow5Col1.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow5Col1.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow5Col1.Location = New Point(16, 277)
        lblRow5Col1.Text = "Sep 28, 3:12 PM"
        lblRow5Col1.Name = "lblRow5Col1"
        lblRow5Col1.TabIndex = 48
        ' 
        ' lblRow5Col2
        ' 
        lblRow5Col2.AutoSize = True
        lblRow5Col2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow5Col2.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow5Col2.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblRow5Col2.Location = New Point(112, 277)
        lblRow5Col2.Text = "Rosa Dela Cruz"
        lblRow5Col2.Name = "lblRow5Col2"
        lblRow5Col2.TabIndex = 49
        ' 
        ' lblRow5Col3
        ' 
        lblRow5Col3.AutoSize = True
        lblRow5Col3.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow5Col3.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow5Col3.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow5Col3.Location = New Point(214, 277)
        lblRow5Col3.Text = "Administrator"
        lblRow5Col3.Name = "lblRow5Col3"
        lblRow5Col3.TabIndex = 50
        ' 
        ' lblRow5Col4
        ' 
        lblRow5Col4.AutoSize = True
        lblRow5Col4.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow5Col4.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow5Col4.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow5Col4.Location = New Point(298, 277)
        lblRow5Col4.Text = "Record access blocked"
        lblRow5Col4.Name = "lblRow5Col4"
        lblRow5Col4.TabIndex = 51
        ' 
        ' lblRow5Col5
        ' 
        lblRow5Col5.AutoSize = True
        lblRow5Col5.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow5Col5.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow5Col5.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow5Col5.Location = New Point(450, 277)
        lblRow5Col5.Text = "Admins cannot open clinical notes"
        lblRow5Col5.Name = "lblRow5Col5"
        lblRow5Col5.TabIndex = 52
        ' 
        ' cardResult5
        ' 
        cardResult5.Controls.Add(lblResult5)
        cardResult5.BackColor = Color.FromArgb(CByte(254), CByte(243), CByte(226))
        cardResult5.BorderColor = Color.FromArgb(CByte(254), CByte(243), CByte(226))
        cardResult5.BorderHoverColor = Color.FromArgb(CByte(254), CByte(243), CByte(226))
        cardResult5.BorderRadius = 10
        cardResult5.BorderSize = 0
        cardResult5.EnableShadow = False
        cardResult5.HoverTintColor = Color.FromArgb(CByte(254), CByte(243), CByte(226))
        cardResult5.Location = New Point(704, 273)
        cardResult5.ShadowDepth = 2
        cardResult5.Size = New Size(52, 22)
        cardResult5.Name = "cardResult5"
        cardResult5.TabIndex = 53
        ' 
        ' lblResult5
        ' 
        lblResult5.AutoSize = False
        lblResult5.BackColor = Color.FromArgb(CByte(254), CByte(243), CByte(226))
        lblResult5.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblResult5.ForeColor = Color.FromArgb(CByte(217), CByte(119), CByte(6))
        lblResult5.Location = New Point(0, 0)
        lblResult5.Size = New Size(52, 22)
        lblResult5.TextAlign = ContentAlignment.MiddleCenter
        lblResult5.Text = "Denied"
        lblResult5.Name = "lblResult5"
        lblResult5.TabIndex = 54
        ' 
        ' divRow5
        ' 
        divRow5.BackColor = Color.FromArgb(CByte(242), CByte(244), CByte(247))
        divRow5.Location = New Point(16, 307)
        divRow5.Size = New Size(743, 1)
        divRow5.Name = "divRow5"
        divRow5.TabIndex = 55
        ' 
        ' lblRow6Col1
        ' 
        lblRow6Col1.AutoSize = True
        lblRow6Col1.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow6Col1.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow6Col1.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow6Col1.Location = New Point(16, 323)
        lblRow6Col1.Text = "Sep 27, 10:15 AM"
        lblRow6Col1.Name = "lblRow6Col1"
        lblRow6Col1.TabIndex = 56
        ' 
        ' lblRow6Col2
        ' 
        lblRow6Col2.AutoSize = True
        lblRow6Col2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow6Col2.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow6Col2.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblRow6Col2.Location = New Point(112, 323)
        lblRow6Col2.Text = "Rosa Dela Cruz"
        lblRow6Col2.Name = "lblRow6Col2"
        lblRow6Col2.TabIndex = 57
        ' 
        ' lblRow6Col3
        ' 
        lblRow6Col3.AutoSize = True
        lblRow6Col3.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow6Col3.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow6Col3.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow6Col3.Location = New Point(214, 323)
        lblRow6Col3.Text = "Administrator"
        lblRow6Col3.Name = "lblRow6Col3"
        lblRow6Col3.TabIndex = 58
        ' 
        ' lblRow6Col4
        ' 
        lblRow6Col4.AutoSize = True
        lblRow6Col4.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow6Col4.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow6Col4.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow6Col4.Location = New Point(298, 323)
        lblRow6Col4.Text = "Clinic hours edited"
        lblRow6Col4.Name = "lblRow6Col4"
        lblRow6Col4.TabIndex = 59
        ' 
        ' lblRow6Col5
        ' 
        lblRow6Col5.AutoSize = True
        lblRow6Col5.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow6Col5.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow6Col5.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow6Col5.Location = New Point(450, 323)
        lblRow6Col5.Text = "All Saints' Day closure added"
        lblRow6Col5.Name = "lblRow6Col5"
        lblRow6Col5.TabIndex = 60
        ' 
        ' cardResult6
        ' 
        cardResult6.Controls.Add(lblResult6)
        cardResult6.BackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        cardResult6.BorderColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        cardResult6.BorderHoverColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        cardResult6.BorderRadius = 10
        cardResult6.BorderSize = 0
        cardResult6.EnableShadow = False
        cardResult6.HoverTintColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        cardResult6.Location = New Point(704, 319)
        cardResult6.ShadowDepth = 2
        cardResult6.Size = New Size(56, 22)
        cardResult6.Name = "cardResult6"
        cardResult6.TabIndex = 61
        ' 
        ' lblResult6
        ' 
        lblResult6.AutoSize = False
        lblResult6.BackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        lblResult6.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblResult6.ForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        lblResult6.Location = New Point(0, 0)
        lblResult6.Size = New Size(56, 22)
        lblResult6.TextAlign = ContentAlignment.MiddleCenter
        lblResult6.Text = "Success"
        lblResult6.Name = "lblResult6"
        lblResult6.TabIndex = 62
        ' 
        ' divRow6
        ' 
        divRow6.BackColor = Color.FromArgb(CByte(242), CByte(244), CByte(247))
        divRow6.Location = New Point(16, 353)
        divRow6.Size = New Size(743, 1)
        divRow6.Name = "divRow6"
        divRow6.TabIndex = 63
        ' 
        ' lblRow7Col1
        ' 
        lblRow7Col1.AutoSize = True
        lblRow7Col1.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow7Col1.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow7Col1.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow7Col1.Location = New Point(16, 369)
        lblRow7Col1.Text = "Sep 26, 7:58 AM"
        lblRow7Col1.Name = "lblRow7Col1"
        lblRow7Col1.TabIndex = 64
        ' 
        ' lblRow7Col2
        ' 
        lblRow7Col2.AutoSize = True
        lblRow7Col2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow7Col2.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow7Col2.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblRow7Col2.Location = New Point(112, 369)
        lblRow7Col2.Text = "ana.reyes"
        lblRow7Col2.Name = "lblRow7Col2"
        lblRow7Col2.TabIndex = 65
        ' 
        ' lblRow7Col3
        ' 
        lblRow7Col3.AutoSize = True
        lblRow7Col3.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow7Col3.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow7Col3.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow7Col3.Location = New Point(214, 369)
        lblRow7Col3.Text = "Unknown"
        lblRow7Col3.Name = "lblRow7Col3"
        lblRow7Col3.TabIndex = 66
        ' 
        ' lblRow7Col4
        ' 
        lblRow7Col4.AutoSize = True
        lblRow7Col4.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow7Col4.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow7Col4.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow7Col4.Location = New Point(298, 369)
        lblRow7Col4.Text = "Sign-in attempt"
        lblRow7Col4.Name = "lblRow7Col4"
        lblRow7Col4.TabIndex = 67
        ' 
        ' lblRow7Col5
        ' 
        lblRow7Col5.AutoSize = True
        lblRow7Col5.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow7Col5.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow7Col5.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow7Col5.Location = New Point(450, 369)
        lblRow7Col5.Text = "Incorrect password (2 of 5 tries)"
        lblRow7Col5.Name = "lblRow7Col5"
        lblRow7Col5.TabIndex = 68
        ' 
        ' cardResult7
        ' 
        cardResult7.Controls.Add(lblResult7)
        cardResult7.BackColor = Color.FromArgb(CByte(253), CByte(236), CByte(236))
        cardResult7.BorderColor = Color.FromArgb(CByte(253), CByte(236), CByte(236))
        cardResult7.BorderHoverColor = Color.FromArgb(CByte(253), CByte(236), CByte(236))
        cardResult7.BorderRadius = 10
        cardResult7.BorderSize = 0
        cardResult7.EnableShadow = False
        cardResult7.HoverTintColor = Color.FromArgb(CByte(253), CByte(236), CByte(236))
        cardResult7.Location = New Point(704, 365)
        cardResult7.ShadowDepth = 2
        cardResult7.Size = New Size(48, 22)
        cardResult7.Name = "cardResult7"
        cardResult7.TabIndex = 69
        ' 
        ' lblResult7
        ' 
        lblResult7.AutoSize = False
        lblResult7.BackColor = Color.FromArgb(CByte(253), CByte(236), CByte(236))
        lblResult7.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblResult7.ForeColor = Color.FromArgb(CByte(205), CByte(80), CByte(75))
        lblResult7.Location = New Point(0, 0)
        lblResult7.Size = New Size(48, 22)
        lblResult7.TextAlign = ContentAlignment.MiddleCenter
        lblResult7.Text = "Failed"
        lblResult7.Name = "lblResult7"
        lblResult7.TabIndex = 70
        ' 
        ' divRow7
        ' 
        divRow7.BackColor = Color.FromArgb(CByte(242), CByte(244), CByte(247))
        divRow7.Location = New Point(16, 399)
        divRow7.Size = New Size(743, 1)
        divRow7.Name = "divRow7"
        divRow7.TabIndex = 71
        ' 
        ' lblRow8Col1
        ' 
        lblRow8Col1.AutoSize = True
        lblRow8Col1.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow8Col1.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow8Col1.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow8Col1.Location = New Point(16, 415)
        lblRow8Col1.Text = "Sep 26, 7:59 AM"
        lblRow8Col1.Name = "lblRow8Col1"
        lblRow8Col1.TabIndex = 72
        ' 
        ' lblRow8Col2
        ' 
        lblRow8Col2.AutoSize = True
        lblRow8Col2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow8Col2.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow8Col2.ForeColor = Color.FromArgb(CByte(35), CByte(45), CByte(55))
        lblRow8Col2.Location = New Point(112, 415)
        lblRow8Col2.Text = "Ana Reyes"
        lblRow8Col2.Name = "lblRow8Col2"
        lblRow8Col2.TabIndex = 73
        ' 
        ' lblRow8Col3
        ' 
        lblRow8Col3.AutoSize = True
        lblRow8Col3.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow8Col3.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow8Col3.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow8Col3.Location = New Point(214, 415)
        lblRow8Col3.Text = "Receptionist"
        lblRow8Col3.Name = "lblRow8Col3"
        lblRow8Col3.TabIndex = 74
        ' 
        ' lblRow8Col4
        ' 
        lblRow8Col4.AutoSize = True
        lblRow8Col4.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow8Col4.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow8Col4.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow8Col4.Location = New Point(298, 415)
        lblRow8Col4.Text = "Sign-in"
        lblRow8Col4.Name = "lblRow8Col4"
        lblRow8Col4.TabIndex = 75
        ' 
        ' lblRow8Col5
        ' 
        lblRow8Col5.AutoSize = True
        lblRow8Col5.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblRow8Col5.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRow8Col5.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblRow8Col5.Location = New Point(450, 415)
        lblRow8Col5.Text = "Succeeded on retry"
        lblRow8Col5.Name = "lblRow8Col5"
        lblRow8Col5.TabIndex = 76
        ' 
        ' cardResult8
        ' 
        cardResult8.Controls.Add(lblResult8)
        cardResult8.BackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        cardResult8.BorderColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        cardResult8.BorderHoverColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        cardResult8.BorderRadius = 10
        cardResult8.BorderSize = 0
        cardResult8.EnableShadow = False
        cardResult8.HoverTintColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        cardResult8.Location = New Point(704, 411)
        cardResult8.ShadowDepth = 2
        cardResult8.Size = New Size(56, 22)
        cardResult8.Name = "cardResult8"
        cardResult8.TabIndex = 77
        ' 
        ' lblResult8
        ' 
        lblResult8.AutoSize = False
        lblResult8.BackColor = Color.FromArgb(CByte(230), CByte(245), CByte(235))
        lblResult8.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblResult8.ForeColor = Color.FromArgb(CByte(40), CByte(135), CByte(75))
        lblResult8.Location = New Point(0, 0)
        lblResult8.Size = New Size(56, 22)
        lblResult8.TextAlign = ContentAlignment.MiddleCenter
        lblResult8.Text = "Success"
        lblResult8.Name = "lblResult8"
        lblResult8.TabIndex = 78
        ' 
        ' divRow8
        ' 
        divRow8.BackColor = Color.FromArgb(CByte(242), CByte(244), CByte(247))
        divRow8.Location = New Point(16, 445)
        divRow8.Size = New Size(743, 1)
        divRow8.Name = "divRow8"
        divRow8.TabIndex = 79
        ' 
        ' AuditLog
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(244), CByte(247), CByte(249))
        Controls.Add(lblTitle)
        Controls.Add(lblSubtitle)
        Controls.Add(btnExport)
        Controls.Add(cardSearch)
        Controls.Add(btnFilterUsers)
        Controls.Add(btnFilterActions)
        Controls.Add(btnFilterDate)
        Controls.Add(cardActivity)
        Name = "AuditLog"
        Size = New Size(831, 730)
        cardActivity.ResumeLayout(False)
        cardActivity.PerformLayout()
        cardResult8.ResumeLayout(False)
        cardResult8.PerformLayout()
        cardResult7.ResumeLayout(False)
        cardResult7.PerformLayout()
        cardResult6.ResumeLayout(False)
        cardResult6.PerformLayout()
        cardResult5.ResumeLayout(False)
        cardResult5.PerformLayout()
        cardResult4.ResumeLayout(False)
        cardResult4.PerformLayout()
        cardResult3.ResumeLayout(False)
        cardResult3.PerformLayout()
        cardResult2.ResumeLayout(False)
        cardResult2.PerformLayout()
        cardResult1.ResumeLayout(False)
        cardResult1.PerformLayout()
        cardSearch.ResumeLayout(False)
        cardSearch.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents btnExport As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents cardSearch As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents btnFilterUsers As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnFilterActions As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents btnFilterDate As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents lblActivityTitle As Label
    Friend WithEvents lblCol1 As Label
    Friend WithEvents lblCol2 As Label
    Friend WithEvents lblCol3 As Label
    Friend WithEvents lblCol4 As Label
    Friend WithEvents lblCol5 As Label
    Friend WithEvents lblCol6 As Label
    Friend WithEvents divHeader As Panel
    Friend WithEvents lblRow1Col1 As Label
    Friend WithEvents lblRow1Col2 As Label
    Friend WithEvents lblRow1Col3 As Label
    Friend WithEvents lblRow1Col4 As Label
    Friend WithEvents lblRow1Col5 As Label
    Friend WithEvents cardResult1 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblResult1 As Label
    Friend WithEvents divRow1 As Panel
    Friend WithEvents lblRow2Col1 As Label
    Friend WithEvents lblRow2Col2 As Label
    Friend WithEvents lblRow2Col3 As Label
    Friend WithEvents lblRow2Col4 As Label
    Friend WithEvents lblRow2Col5 As Label
    Friend WithEvents cardResult2 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblResult2 As Label
    Friend WithEvents divRow2 As Panel
    Friend WithEvents lblRow3Col1 As Label
    Friend WithEvents lblRow3Col2 As Label
    Friend WithEvents lblRow3Col3 As Label
    Friend WithEvents lblRow3Col4 As Label
    Friend WithEvents lblRow3Col5 As Label
    Friend WithEvents cardResult3 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblResult3 As Label
    Friend WithEvents divRow3 As Panel
    Friend WithEvents lblRow4Col1 As Label
    Friend WithEvents lblRow4Col2 As Label
    Friend WithEvents lblRow4Col3 As Label
    Friend WithEvents lblRow4Col4 As Label
    Friend WithEvents lblRow4Col5 As Label
    Friend WithEvents cardResult4 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblResult4 As Label
    Friend WithEvents divRow4 As Panel
    Friend WithEvents lblRow5Col1 As Label
    Friend WithEvents lblRow5Col2 As Label
    Friend WithEvents lblRow5Col3 As Label
    Friend WithEvents lblRow5Col4 As Label
    Friend WithEvents lblRow5Col5 As Label
    Friend WithEvents cardResult5 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblResult5 As Label
    Friend WithEvents divRow5 As Panel
    Friend WithEvents lblRow6Col1 As Label
    Friend WithEvents lblRow6Col2 As Label
    Friend WithEvents lblRow6Col3 As Label
    Friend WithEvents lblRow6Col4 As Label
    Friend WithEvents lblRow6Col5 As Label
    Friend WithEvents cardResult6 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblResult6 As Label
    Friend WithEvents divRow6 As Panel
    Friend WithEvents lblRow7Col1 As Label
    Friend WithEvents lblRow7Col2 As Label
    Friend WithEvents lblRow7Col3 As Label
    Friend WithEvents lblRow7Col4 As Label
    Friend WithEvents lblRow7Col5 As Label
    Friend WithEvents cardResult7 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblResult7 As Label
    Friend WithEvents divRow7 As Panel
    Friend WithEvents lblRow8Col1 As Label
    Friend WithEvents lblRow8Col2 As Label
    Friend WithEvents lblRow8Col3 As Label
    Friend WithEvents lblRow8Col4 As Label
    Friend WithEvents lblRow8Col5 As Label
    Friend WithEvents cardResult8 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblResult8 As Label
    Friend WithEvents divRow8 As Panel
    Friend WithEvents cardActivity As Ferrando.UI.WinForms.Controles.FCard

End Class