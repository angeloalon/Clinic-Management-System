<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ClinicSettings
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
        btnSave = New Ferrando.UI.WinForms.Controles.FButton()
        cardProfile = New Ferrando.UI.WinForms.Controles.FCard()
        lblProfileTitle = New Label()
        lblClinicName = New Label()
        cardClinicNameBox = New Ferrando.UI.WinForms.Controles.FCard()
        txtClinicName = New TextBox()
        lblClinicType = New Label()
        cardClinicTypeBox = New Ferrando.UI.WinForms.Controles.FCard()
        txtClinicType = New TextBox()
        lblAddress = New Label()
        cardAddressBox = New Ferrando.UI.WinForms.Controles.FCard()
        txtAddress = New TextBox()
        lblContact = New Label()
        cardContactBox = New Ferrando.UI.WinForms.Controles.FCard()
        txtContact = New TextBox()
        lblEmail = New Label()
        cardEmailBox = New Ferrando.UI.WinForms.Controles.FCard()
        txtEmail = New TextBox()
        lblApptLength = New Label()
        cardApptLengthBox = New Ferrando.UI.WinForms.Controles.FCard()
        txtApptLength = New TextBox()
        cardHours = New Ferrando.UI.WinForms.Controles.FCard()
        lblHoursTitle = New Label()
        lblDay1 = New Label()
        lblHours1 = New Label()
        divHours1 = New Panel()
        lblDay2 = New Label()
        lblHours2 = New Label()
        divHours2 = New Panel()
        lblDay3 = New Label()
        cardClosed = New Ferrando.UI.WinForms.Controles.FCard()
        lblClosed = New Label()
        divHours3 = New Panel()
        cardTypes = New Ferrando.UI.WinForms.Controles.FCard()
        lblTypesTitle = New Label()
        lblType1 = New Label()
        cardDur1 = New Ferrando.UI.WinForms.Controles.FCard()
        lblDur1 = New Label()
        divType1 = New Panel()
        lblType2 = New Label()
        cardDur2 = New Ferrando.UI.WinForms.Controles.FCard()
        lblDur2 = New Label()
        divType2 = New Panel()
        lblType3 = New Label()
        cardDur3 = New Ferrando.UI.WinForms.Controles.FCard()
        lblDur3 = New Label()
        divType3 = New Panel()
        lblType4 = New Label()
        cardDur4 = New Ferrando.UI.WinForms.Controles.FCard()
        lblDur4 = New Label()
        cardProfile.SuspendLayout()
        cardClinicNameBox.SuspendLayout()
        cardClinicTypeBox.SuspendLayout()
        cardAddressBox.SuspendLayout()
        cardContactBox.SuspendLayout()
        cardEmailBox.SuspendLayout()
        cardApptLengthBox.SuspendLayout()
        cardHours.SuspendLayout()
        cardClosed.SuspendLayout()
        cardTypes.SuspendLayout()
        cardDur1.SuspendLayout()
        cardDur2.SuspendLayout()
        cardDur3.SuspendLayout()
        cardDur4.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.BackColor = Color.FromArgb(CByte(244), CByte(247), CByte(249))
        lblTitle.Font = New Font("Segoe UI", 18.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.FromArgb(CByte(22), CByte(51), CByte(65))
        lblTitle.Location = New Point(28, 18)
        lblTitle.Text = "Clinic settings"
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
        lblSubtitle.Text = "Clinic profile, opening hours and appointment types"
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.TabIndex = 1
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnSave.BorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnSave.BorderRadius = 8
        btnSave.BorderSize = 0
        btnSave.Cursor = Cursors.Hand
        btnSave.FlatAppearance.BorderSize = 0
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSave.ForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnSave.Location = New Point(703, 22)
        btnSave.MouseEnterBackColor = Color.FromArgb(CByte(23), CByte(105), CByte(90))
        btnSave.MouseEnterBorderColor = Color.FromArgb(CByte(23), CByte(105), CByte(90))
        btnSave.MouseEnterBorderSize = 0
        btnSave.MouseEnterFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSave.MouseEnterForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnSave.MouseLeaveBackColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnSave.MouseLeaveBorderColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        btnSave.MouseLeaveBorderSize = 0
        btnSave.MouseLeaveFont = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSave.MouseLeaveForeColor = Color.FromArgb(CByte(255), CByte(254), CByte(255))
        btnSave.Size = New Size(100, 30)
        btnSave.Text = "Save changes"
        btnSave.UseVisualStyleBackColor = False
        btnSave.Name = "btnSave"
        btnSave.TabIndex = 2
        ' 
        ' cardProfile
        ' 
        cardProfile.Controls.Add(lblProfileTitle)
        cardProfile.Controls.Add(lblClinicName)
        cardProfile.Controls.Add(cardClinicNameBox)
        cardProfile.Controls.Add(lblClinicType)
        cardProfile.Controls.Add(cardClinicTypeBox)
        cardProfile.Controls.Add(lblAddress)
        cardProfile.Controls.Add(cardAddressBox)
        cardProfile.Controls.Add(lblContact)
        cardProfile.Controls.Add(cardContactBox)
        cardProfile.Controls.Add(lblEmail)
        cardProfile.Controls.Add(cardEmailBox)
        cardProfile.Controls.Add(lblApptLength)
        cardProfile.Controls.Add(cardApptLengthBox)
        cardProfile.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardProfile.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardProfile.BorderHoverColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardProfile.BorderRadius = 12
        cardProfile.BorderSize = 1
        cardProfile.EnableShadow = True
        cardProfile.HoverTintColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardProfile.Location = New Point(28, 83)
        cardProfile.ShadowDepth = 4
        cardProfile.Size = New Size(493, 223)
        cardProfile.Name = "cardProfile"
        cardProfile.TabIndex = 3
        ' 
        ' lblProfileTitle
        ' 
        lblProfileTitle.AutoSize = True
        lblProfileTitle.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblProfileTitle.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblProfileTitle.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblProfileTitle.Location = New Point(16, 13)
        lblProfileTitle.Text = "Clinic profile"
        lblProfileTitle.Name = "lblProfileTitle"
        lblProfileTitle.TabIndex = 4
        ' 
        ' lblClinicName
        ' 
        lblClinicName.AutoSize = True
        lblClinicName.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblClinicName.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblClinicName.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblClinicName.Location = New Point(16, 42)
        lblClinicName.Text = "Clinic name"
        lblClinicName.Name = "lblClinicName"
        lblClinicName.TabIndex = 5
        ' 
        ' cardClinicNameBox
        ' 
        cardClinicNameBox.Controls.Add(txtClinicName)
        cardClinicNameBox.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardClinicNameBox.BorderColor = Color.FromArgb(CByte(220), CByte(228), CByte(232))
        cardClinicNameBox.BorderHoverColor = Color.FromArgb(CByte(220), CByte(228), CByte(232))
        cardClinicNameBox.BorderRadius = 8
        cardClinicNameBox.BorderSize = 1
        cardClinicNameBox.EnableShadow = False
        cardClinicNameBox.HoverTintColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardClinicNameBox.Location = New Point(16, 58)
        cardClinicNameBox.ShadowDepth = 2
        cardClinicNameBox.Size = New Size(222, 30)
        cardClinicNameBox.Name = "cardClinicNameBox"
        cardClinicNameBox.TabIndex = 6
        ' 
        ' txtClinicName
        ' 
        txtClinicName.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        txtClinicName.BorderStyle = BorderStyle.None
        txtClinicName.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtClinicName.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        txtClinicName.Location = New Point(10, 7)
        txtClinicName.Size = New Size(202, 16)
        txtClinicName.Text = "UCC Health Clinic"
        txtClinicName.Name = "txtClinicName"
        txtClinicName.TabIndex = 7
        ' 
        ' lblClinicType
        ' 
        lblClinicType.AutoSize = True
        lblClinicType.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblClinicType.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblClinicType.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblClinicType.Location = New Point(254, 42)
        lblClinicType.Text = "Clinic type"
        lblClinicType.Name = "lblClinicType"
        lblClinicType.TabIndex = 8
        ' 
        ' cardClinicTypeBox
        ' 
        cardClinicTypeBox.Controls.Add(txtClinicType)
        cardClinicTypeBox.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardClinicTypeBox.BorderColor = Color.FromArgb(CByte(220), CByte(228), CByte(232))
        cardClinicTypeBox.BorderHoverColor = Color.FromArgb(CByte(220), CByte(228), CByte(232))
        cardClinicTypeBox.BorderRadius = 8
        cardClinicTypeBox.BorderSize = 1
        cardClinicTypeBox.EnableShadow = False
        cardClinicTypeBox.HoverTintColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardClinicTypeBox.Location = New Point(254, 58)
        cardClinicTypeBox.ShadowDepth = 2
        cardClinicTypeBox.Size = New Size(222, 30)
        cardClinicTypeBox.Name = "cardClinicTypeBox"
        cardClinicTypeBox.TabIndex = 9
        ' 
        ' txtClinicType
        ' 
        txtClinicType.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        txtClinicType.BorderStyle = BorderStyle.None
        txtClinicType.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtClinicType.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        txtClinicType.Location = New Point(10, 7)
        txtClinicType.Size = New Size(202, 16)
        txtClinicType.Text = "General practice"
        txtClinicType.Name = "txtClinicType"
        txtClinicType.TabIndex = 10
        ' 
        ' lblAddress
        ' 
        lblAddress.AutoSize = True
        lblAddress.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblAddress.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblAddress.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblAddress.Location = New Point(16, 100)
        lblAddress.Text = "Address"
        lblAddress.Name = "lblAddress"
        lblAddress.TabIndex = 11
        ' 
        ' cardAddressBox
        ' 
        cardAddressBox.Controls.Add(txtAddress)
        cardAddressBox.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardAddressBox.BorderColor = Color.FromArgb(CByte(220), CByte(228), CByte(232))
        cardAddressBox.BorderHoverColor = Color.FromArgb(CByte(220), CByte(228), CByte(232))
        cardAddressBox.BorderRadius = 8
        cardAddressBox.BorderSize = 1
        cardAddressBox.EnableShadow = False
        cardAddressBox.HoverTintColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardAddressBox.Location = New Point(16, 116)
        cardAddressBox.ShadowDepth = 2
        cardAddressBox.Size = New Size(222, 30)
        cardAddressBox.Name = "cardAddressBox"
        cardAddressBox.TabIndex = 12
        ' 
        ' txtAddress
        ' 
        txtAddress.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        txtAddress.BorderStyle = BorderStyle.None
        txtAddress.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtAddress.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        txtAddress.Location = New Point(10, 7)
        txtAddress.Size = New Size(202, 16)
        txtAddress.Text = "Health Clinic, Caloocan City"
        txtAddress.Name = "txtAddress"
        txtAddress.TabIndex = 13
        ' 
        ' lblContact
        ' 
        lblContact.AutoSize = True
        lblContact.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblContact.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblContact.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblContact.Location = New Point(254, 100)
        lblContact.Text = "Contact number"
        lblContact.Name = "lblContact"
        lblContact.TabIndex = 14
        ' 
        ' cardContactBox
        ' 
        cardContactBox.Controls.Add(txtContact)
        cardContactBox.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardContactBox.BorderColor = Color.FromArgb(CByte(220), CByte(228), CByte(232))
        cardContactBox.BorderHoverColor = Color.FromArgb(CByte(220), CByte(228), CByte(232))
        cardContactBox.BorderRadius = 8
        cardContactBox.BorderSize = 1
        cardContactBox.EnableShadow = False
        cardContactBox.HoverTintColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardContactBox.Location = New Point(254, 116)
        cardContactBox.ShadowDepth = 2
        cardContactBox.Size = New Size(222, 30)
        cardContactBox.Name = "cardContactBox"
        cardContactBox.TabIndex = 15
        ' 
        ' txtContact
        ' 
        txtContact.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        txtContact.BorderStyle = BorderStyle.None
        txtContact.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtContact.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        txtContact.Location = New Point(10, 7)
        txtContact.Size = New Size(202, 16)
        txtContact.Text = "(02) 8555 0142"
        txtContact.Name = "txtContact"
        txtContact.TabIndex = 16
        ' 
        ' lblEmail
        ' 
        lblEmail.AutoSize = True
        lblEmail.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblEmail.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblEmail.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblEmail.Location = New Point(16, 158)
        lblEmail.Text = "Email"
        lblEmail.Name = "lblEmail"
        lblEmail.TabIndex = 17
        ' 
        ' cardEmailBox
        ' 
        cardEmailBox.Controls.Add(txtEmail)
        cardEmailBox.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardEmailBox.BorderColor = Color.FromArgb(CByte(220), CByte(228), CByte(232))
        cardEmailBox.BorderHoverColor = Color.FromArgb(CByte(220), CByte(228), CByte(232))
        cardEmailBox.BorderRadius = 8
        cardEmailBox.BorderSize = 1
        cardEmailBox.EnableShadow = False
        cardEmailBox.HoverTintColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardEmailBox.Location = New Point(16, 174)
        cardEmailBox.ShadowDepth = 2
        cardEmailBox.Size = New Size(222, 30)
        cardEmailBox.Name = "cardEmailBox"
        cardEmailBox.TabIndex = 18
        ' 
        ' txtEmail
        ' 
        txtEmail.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        txtEmail.BorderStyle = BorderStyle.None
        txtEmail.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtEmail.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        txtEmail.Location = New Point(10, 7)
        txtEmail.Size = New Size(202, 16)
        txtEmail.Text = "clinic@uccclinic.edu.ph"
        txtEmail.Name = "txtEmail"
        txtEmail.TabIndex = 19
        ' 
        ' lblApptLength
        ' 
        lblApptLength.AutoSize = True
        lblApptLength.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblApptLength.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblApptLength.ForeColor = Color.FromArgb(CByte(115), CByte(135), CByte(145))
        lblApptLength.Location = New Point(254, 158)
        lblApptLength.Text = "Default appointment length"
        lblApptLength.Name = "lblApptLength"
        lblApptLength.TabIndex = 20
        ' 
        ' cardApptLengthBox
        ' 
        cardApptLengthBox.Controls.Add(txtApptLength)
        cardApptLengthBox.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardApptLengthBox.BorderColor = Color.FromArgb(CByte(220), CByte(228), CByte(232))
        cardApptLengthBox.BorderHoverColor = Color.FromArgb(CByte(220), CByte(228), CByte(232))
        cardApptLengthBox.BorderRadius = 8
        cardApptLengthBox.BorderSize = 1
        cardApptLengthBox.EnableShadow = False
        cardApptLengthBox.HoverTintColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardApptLengthBox.Location = New Point(254, 174)
        cardApptLengthBox.ShadowDepth = 2
        cardApptLengthBox.Size = New Size(222, 30)
        cardApptLengthBox.Name = "cardApptLengthBox"
        cardApptLengthBox.TabIndex = 21
        ' 
        ' txtApptLength
        ' 
        txtApptLength.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        txtApptLength.BorderStyle = BorderStyle.None
        txtApptLength.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtApptLength.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        txtApptLength.Location = New Point(10, 7)
        txtApptLength.Size = New Size(202, 16)
        txtApptLength.Text = "30 minutes"
        txtApptLength.Name = "txtApptLength"
        txtApptLength.TabIndex = 22
        ' 
        ' cardHours
        ' 
        cardHours.Controls.Add(lblHoursTitle)
        cardHours.Controls.Add(lblDay1)
        cardHours.Controls.Add(lblHours1)
        cardHours.Controls.Add(divHours1)
        cardHours.Controls.Add(lblDay2)
        cardHours.Controls.Add(lblHours2)
        cardHours.Controls.Add(divHours2)
        cardHours.Controls.Add(lblDay3)
        cardHours.Controls.Add(cardClosed)
        cardHours.Controls.Add(divHours3)
        cardHours.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardHours.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardHours.BorderHoverColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardHours.BorderRadius = 12
        cardHours.BorderSize = 1
        cardHours.EnableShadow = True
        cardHours.HoverTintColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardHours.Location = New Point(531, 83)
        cardHours.ShadowDepth = 4
        cardHours.Size = New Size(272, 177)
        cardHours.Name = "cardHours"
        cardHours.TabIndex = 23
        ' 
        ' lblHoursTitle
        ' 
        lblHoursTitle.AutoSize = True
        lblHoursTitle.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblHoursTitle.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblHoursTitle.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblHoursTitle.Location = New Point(16, 13)
        lblHoursTitle.Text = "Opening hours"
        lblHoursTitle.Name = "lblHoursTitle"
        lblHoursTitle.TabIndex = 24
        ' 
        ' lblDay1
        ' 
        lblDay1.AutoSize = True
        lblDay1.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblDay1.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDay1.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        lblDay1.Location = New Point(16, 51)
        lblDay1.Text = "Monday – Friday"
        lblDay1.Name = "lblDay1"
        lblDay1.TabIndex = 25
        ' 
        ' lblHours1
        ' 
        lblHours1.AutoSize = True
        lblHours1.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblHours1.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblHours1.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblHours1.Location = New Point(116, 51)
        lblHours1.Text = "8:00 AM – 5:00 PM"
        lblHours1.Name = "lblHours1"
        lblHours1.TabIndex = 26
        ' 
        ' divHours1
        ' 
        divHours1.BackColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        divHours1.Location = New Point(16, 75)
        divHours1.Size = New Size(240, 1)
        divHours1.Name = "divHours1"
        divHours1.TabIndex = 27
        ' 
        ' lblDay2
        ' 
        lblDay2.AutoSize = True
        lblDay2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblDay2.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDay2.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        lblDay2.Location = New Point(16, 95)
        lblDay2.Text = "Saturday"
        lblDay2.Name = "lblDay2"
        lblDay2.TabIndex = 28
        ' 
        ' lblHours2
        ' 
        lblHours2.AutoSize = True
        lblHours2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblHours2.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblHours2.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblHours2.Location = New Point(116, 95)
        lblHours2.Text = "8:00 AM – 12:00 PM"
        lblHours2.Name = "lblHours2"
        lblHours2.TabIndex = 29
        ' 
        ' divHours2
        ' 
        divHours2.BackColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        divHours2.Location = New Point(16, 119)
        divHours2.Size = New Size(240, 1)
        divHours2.Name = "divHours2"
        divHours2.TabIndex = 30
        ' 
        ' lblDay3
        ' 
        lblDay3.AutoSize = True
        lblDay3.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblDay3.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDay3.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        lblDay3.Location = New Point(16, 139)
        lblDay3.Text = "Sunday"
        lblDay3.Name = "lblDay3"
        lblDay3.TabIndex = 31
        ' 
        ' cardClosed
        ' 
        cardClosed.Controls.Add(lblClosed)
        cardClosed.BackColor = Color.FromArgb(CByte(238), CByte(242), CByte(244))
        cardClosed.BorderColor = Color.FromArgb(CByte(238), CByte(242), CByte(244))
        cardClosed.BorderHoverColor = Color.FromArgb(CByte(238), CByte(242), CByte(244))
        cardClosed.BorderRadius = 10
        cardClosed.BorderSize = 0
        cardClosed.EnableShadow = False
        cardClosed.HoverTintColor = Color.FromArgb(CByte(238), CByte(242), CByte(244))
        cardClosed.Location = New Point(116, 136)
        cardClosed.ShadowDepth = 2
        cardClosed.Size = New Size(50, 20)
        cardClosed.Name = "cardClosed"
        cardClosed.TabIndex = 32
        ' 
        ' lblClosed
        ' 
        lblClosed.AutoSize = False
        lblClosed.BackColor = Color.FromArgb(CByte(238), CByte(242), CByte(244))
        lblClosed.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblClosed.ForeColor = Color.FromArgb(CByte(75), CByte(95), CByte(105))
        lblClosed.Location = New Point(0, 0)
        lblClosed.Size = New Size(50, 20)
        lblClosed.TextAlign = ContentAlignment.MiddleCenter
        lblClosed.Text = "Closed"
        lblClosed.Name = "lblClosed"
        lblClosed.TabIndex = 33
        ' 
        ' divHours3
        ' 
        divHours3.BackColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        divHours3.Location = New Point(16, 163)
        divHours3.Size = New Size(240, 1)
        divHours3.Name = "divHours3"
        divHours3.TabIndex = 34
        ' 
        ' cardTypes
        ' 
        cardTypes.Controls.Add(lblTypesTitle)
        cardTypes.Controls.Add(lblType1)
        cardTypes.Controls.Add(cardDur1)
        cardTypes.Controls.Add(divType1)
        cardTypes.Controls.Add(lblType2)
        cardTypes.Controls.Add(cardDur2)
        cardTypes.Controls.Add(divType2)
        cardTypes.Controls.Add(lblType3)
        cardTypes.Controls.Add(cardDur3)
        cardTypes.Controls.Add(divType3)
        cardTypes.Controls.Add(lblType4)
        cardTypes.Controls.Add(cardDur4)
        cardTypes.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardTypes.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardTypes.BorderHoverColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardTypes.BorderRadius = 12
        cardTypes.BorderSize = 1
        cardTypes.EnableShadow = True
        cardTypes.HoverTintColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        cardTypes.Location = New Point(531, 273)
        cardTypes.ShadowDepth = 4
        cardTypes.Size = New Size(272, 224)
        cardTypes.Name = "cardTypes"
        cardTypes.TabIndex = 35
        ' 
        ' lblTypesTitle
        ' 
        lblTypesTitle.AutoSize = True
        lblTypesTitle.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblTypesTitle.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTypesTitle.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblTypesTitle.Location = New Point(16, 13)
        lblTypesTitle.Text = "Appointment types"
        lblTypesTitle.Name = "lblTypesTitle"
        lblTypesTitle.TabIndex = 36
        ' 
        ' lblType1
        ' 
        lblType1.AutoSize = True
        lblType1.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblType1.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblType1.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        lblType1.Location = New Point(16, 52)
        lblType1.Text = "General consultation"
        lblType1.Name = "lblType1"
        lblType1.TabIndex = 37
        ' 
        ' cardDur1
        ' 
        cardDur1.Controls.Add(lblDur1)
        cardDur1.BackColor = Color.FromArgb(CByte(227), CByte(242), CByte(239))
        cardDur1.BorderColor = Color.FromArgb(CByte(227), CByte(242), CByte(239))
        cardDur1.BorderHoverColor = Color.FromArgb(CByte(227), CByte(242), CByte(239))
        cardDur1.BorderRadius = 10
        cardDur1.BorderSize = 0
        cardDur1.EnableShadow = False
        cardDur1.HoverTintColor = Color.FromArgb(CByte(227), CByte(242), CByte(239))
        cardDur1.Location = New Point(157, 49)
        cardDur1.ShadowDepth = 2
        cardDur1.Size = New Size(46, 20)
        cardDur1.Name = "cardDur1"
        cardDur1.TabIndex = 38
        ' 
        ' lblDur1
        ' 
        lblDur1.AutoSize = False
        lblDur1.BackColor = Color.FromArgb(CByte(227), CByte(242), CByte(239))
        lblDur1.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDur1.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        lblDur1.Location = New Point(0, 0)
        lblDur1.Size = New Size(46, 20)
        lblDur1.TextAlign = ContentAlignment.MiddleCenter
        lblDur1.Text = "30 min"
        lblDur1.Name = "lblDur1"
        lblDur1.TabIndex = 39
        ' 
        ' divType1
        ' 
        divType1.BackColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        divType1.Location = New Point(16, 77)
        divType1.Size = New Size(240, 1)
        divType1.Name = "divType1"
        divType1.TabIndex = 40
        ' 
        ' lblType2
        ' 
        lblType2.AutoSize = True
        lblType2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblType2.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblType2.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        lblType2.Location = New Point(16, 98)
        lblType2.Text = "Follow-up"
        lblType2.Name = "lblType2"
        lblType2.TabIndex = 41
        ' 
        ' cardDur2
        ' 
        cardDur2.Controls.Add(lblDur2)
        cardDur2.BackColor = Color.FromArgb(CByte(227), CByte(242), CByte(239))
        cardDur2.BorderColor = Color.FromArgb(CByte(227), CByte(242), CByte(239))
        cardDur2.BorderHoverColor = Color.FromArgb(CByte(227), CByte(242), CByte(239))
        cardDur2.BorderRadius = 10
        cardDur2.BorderSize = 0
        cardDur2.EnableShadow = False
        cardDur2.HoverTintColor = Color.FromArgb(CByte(227), CByte(242), CByte(239))
        cardDur2.Location = New Point(157, 95)
        cardDur2.ShadowDepth = 2
        cardDur2.Size = New Size(46, 20)
        cardDur2.Name = "cardDur2"
        cardDur2.TabIndex = 42
        ' 
        ' lblDur2
        ' 
        lblDur2.AutoSize = False
        lblDur2.BackColor = Color.FromArgb(CByte(227), CByte(242), CByte(239))
        lblDur2.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDur2.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        lblDur2.Location = New Point(0, 0)
        lblDur2.Size = New Size(46, 20)
        lblDur2.TextAlign = ContentAlignment.MiddleCenter
        lblDur2.Text = "15 min"
        lblDur2.Name = "lblDur2"
        lblDur2.TabIndex = 43
        ' 
        ' divType2
        ' 
        divType2.BackColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        divType2.Location = New Point(16, 123)
        divType2.Size = New Size(240, 1)
        divType2.Name = "divType2"
        divType2.TabIndex = 44
        ' 
        ' lblType3
        ' 
        lblType3.AutoSize = True
        lblType3.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblType3.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblType3.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        lblType3.Location = New Point(16, 144)
        lblType3.Text = "Check-up"
        lblType3.Name = "lblType3"
        lblType3.TabIndex = 45
        ' 
        ' cardDur3
        ' 
        cardDur3.Controls.Add(lblDur3)
        cardDur3.BackColor = Color.FromArgb(CByte(227), CByte(242), CByte(239))
        cardDur3.BorderColor = Color.FromArgb(CByte(227), CByte(242), CByte(239))
        cardDur3.BorderHoverColor = Color.FromArgb(CByte(227), CByte(242), CByte(239))
        cardDur3.BorderRadius = 10
        cardDur3.BorderSize = 0
        cardDur3.EnableShadow = False
        cardDur3.HoverTintColor = Color.FromArgb(CByte(227), CByte(242), CByte(239))
        cardDur3.Location = New Point(157, 141)
        cardDur3.ShadowDepth = 2
        cardDur3.Size = New Size(46, 20)
        cardDur3.Name = "cardDur3"
        cardDur3.TabIndex = 46
        ' 
        ' lblDur3
        ' 
        lblDur3.AutoSize = False
        lblDur3.BackColor = Color.FromArgb(CByte(227), CByte(242), CByte(239))
        lblDur3.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDur3.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        lblDur3.Location = New Point(0, 0)
        lblDur3.Size = New Size(46, 20)
        lblDur3.TextAlign = ContentAlignment.MiddleCenter
        lblDur3.Text = "45 min"
        lblDur3.Name = "lblDur3"
        lblDur3.TabIndex = 47
        ' 
        ' divType3
        ' 
        divType3.BackColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        divType3.Location = New Point(16, 169)
        divType3.Size = New Size(240, 1)
        divType3.Name = "divType3"
        divType3.TabIndex = 48
        ' 
        ' lblType4
        ' 
        lblType4.AutoSize = True
        lblType4.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        lblType4.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblType4.ForeColor = Color.FromArgb(CByte(45), CByte(60), CByte(70))
        lblType4.Location = New Point(16, 190)
        lblType4.Text = "Vaccination"
        lblType4.Name = "lblType4"
        lblType4.TabIndex = 49
        ' 
        ' cardDur4
        ' 
        cardDur4.Controls.Add(lblDur4)
        cardDur4.BackColor = Color.FromArgb(CByte(227), CByte(242), CByte(239))
        cardDur4.BorderColor = Color.FromArgb(CByte(227), CByte(242), CByte(239))
        cardDur4.BorderHoverColor = Color.FromArgb(CByte(227), CByte(242), CByte(239))
        cardDur4.BorderRadius = 10
        cardDur4.BorderSize = 0
        cardDur4.EnableShadow = False
        cardDur4.HoverTintColor = Color.FromArgb(CByte(227), CByte(242), CByte(239))
        cardDur4.Location = New Point(157, 187)
        cardDur4.ShadowDepth = 2
        cardDur4.Size = New Size(46, 20)
        cardDur4.Name = "cardDur4"
        cardDur4.TabIndex = 50
        ' 
        ' lblDur4
        ' 
        lblDur4.AutoSize = False
        lblDur4.BackColor = Color.FromArgb(CByte(227), CByte(242), CByte(239))
        lblDur4.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDur4.ForeColor = Color.FromArgb(CByte(35), CByte(137), CByte(120))
        lblDur4.Location = New Point(0, 0)
        lblDur4.Size = New Size(46, 20)
        lblDur4.TextAlign = ContentAlignment.MiddleCenter
        lblDur4.Text = "15 min"
        lblDur4.Name = "lblDur4"
        lblDur4.TabIndex = 51
        ' 
        ' ClinicSettings
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(244), CByte(247), CByte(249))
        Controls.Add(lblTitle)
        Controls.Add(lblSubtitle)
        Controls.Add(btnSave)
        Controls.Add(cardProfile)
        Controls.Add(cardHours)
        Controls.Add(cardTypes)
        Name = "ClinicSettings"
        Size = New Size(831, 730)
        cardDur4.ResumeLayout(False)
        cardDur4.PerformLayout()
        cardDur3.ResumeLayout(False)
        cardDur3.PerformLayout()
        cardDur2.ResumeLayout(False)
        cardDur2.PerformLayout()
        cardDur1.ResumeLayout(False)
        cardDur1.PerformLayout()
        cardTypes.ResumeLayout(False)
        cardTypes.PerformLayout()
        cardClosed.ResumeLayout(False)
        cardClosed.PerformLayout()
        cardHours.ResumeLayout(False)
        cardHours.PerformLayout()
        cardApptLengthBox.ResumeLayout(False)
        cardApptLengthBox.PerformLayout()
        cardEmailBox.ResumeLayout(False)
        cardEmailBox.PerformLayout()
        cardContactBox.ResumeLayout(False)
        cardContactBox.PerformLayout()
        cardAddressBox.ResumeLayout(False)
        cardAddressBox.PerformLayout()
        cardClinicTypeBox.ResumeLayout(False)
        cardClinicTypeBox.PerformLayout()
        cardClinicNameBox.ResumeLayout(False)
        cardClinicNameBox.PerformLayout()
        cardProfile.ResumeLayout(False)
        cardProfile.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents btnSave As Ferrando.UI.WinForms.Controles.FButton
    Friend WithEvents cardProfile As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblProfileTitle As Label
    Friend WithEvents lblClinicName As Label
    Friend WithEvents cardClinicNameBox As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents txtClinicName As TextBox
    Friend WithEvents lblClinicType As Label
    Friend WithEvents cardClinicTypeBox As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents txtClinicType As TextBox
    Friend WithEvents lblAddress As Label
    Friend WithEvents cardAddressBox As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents lblContact As Label
    Friend WithEvents cardContactBox As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents txtContact As TextBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents cardEmailBox As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents lblApptLength As Label
    Friend WithEvents cardApptLengthBox As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents txtApptLength As TextBox
    Friend WithEvents cardHours As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblHoursTitle As Label
    Friend WithEvents lblDay1 As Label
    Friend WithEvents lblHours1 As Label
    Friend WithEvents divHours1 As Panel
    Friend WithEvents lblDay2 As Label
    Friend WithEvents lblHours2 As Label
    Friend WithEvents divHours2 As Panel
    Friend WithEvents lblDay3 As Label
    Friend WithEvents cardClosed As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblClosed As Label
    Friend WithEvents divHours3 As Panel
    Friend WithEvents cardTypes As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblTypesTitle As Label
    Friend WithEvents lblType1 As Label
    Friend WithEvents cardDur1 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblDur1 As Label
    Friend WithEvents divType1 As Panel
    Friend WithEvents lblType2 As Label
    Friend WithEvents cardDur2 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblDur2 As Label
    Friend WithEvents divType2 As Panel
    Friend WithEvents lblType3 As Label
    Friend WithEvents cardDur3 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblDur3 As Label
    Friend WithEvents divType3 As Panel
    Friend WithEvents lblType4 As Label
    Friend WithEvents cardDur4 As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblDur4 As Label

End Class