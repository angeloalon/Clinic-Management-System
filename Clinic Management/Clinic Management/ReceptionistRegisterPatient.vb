Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.Linq
Imports System.Text.RegularExpressions

''' <summary>
''' Register New Patient page. Hosted inside mainScreen (Dock = Fill).
''' Raises PatientRegistered with the validated data, or CancelRequested.
''' </summary>
Public Class ReceptionistRegisterPatient

    Public Event PatientRegistered(patient As NewPatientRecord)
    Public Event CancelRequested()

    ' ---------- Palette (adjust to match DESIGN_SYSTEM.md if needed) ----------
    Private Shared ReadOnly PageBg As Color = ColorTranslator.FromHtml("#F4F7F9")
    Private Shared ReadOnly Ink As Color = ColorTranslator.FromHtml("#1E3342")
    Private Shared ReadOnly Muted As Color = ColorTranslator.FromHtml("#6B7C86")
    Private Shared ReadOnly HintGray As Color = ColorTranslator.FromHtml("#8C9BA5")
    Private Shared ReadOnly BorderGray As Color = ColorTranslator.FromHtml("#DCE4E8")
    Private Shared ReadOnly Teal As Color = ColorTranslator.FromHtml("#238978")
    Private Shared ReadOnly TealDark As Color = ColorTranslator.FromHtml("#1D7C6B")
    Private Shared ReadOnly PillFill As Color = ColorTranslator.FromHtml("#E6F5EB")
    Private Shared ReadOnly PillText As Color = ColorTranslator.FromHtml("#28874B")
    Private Shared ReadOnly ErrorRed As Color = ColorTranslator.FromHtml("#CD504B")
    Private Shared ReadOnly WarnFill As Color = ColorTranslator.FromHtml("#FDECEC")
    Private Shared ReadOnly WarnText As Color = ColorTranslator.FromHtml("#CD504B")
    Private Shared ReadOnly ReadOnlyFill As Color = ColorTranslator.FromHtml("#EEF2F4")

    Private Shared ReadOnly FTitle As New Font("Segoe UI", 18.0F, FontStyle.Regular)
    Private Shared ReadOnly FCardTitle As New Font("Segoe UI", 11.0F, FontStyle.Bold)
    Private Shared ReadOnly FBody As New Font("Segoe UI", 9.0F, FontStyle.Regular)
    Private Shared ReadOnly FBold As New Font("Segoe UI", 9.0F, FontStyle.Bold)
    Private Shared ReadOnly FCap As New Font("Segoe UI", 7.5F, FontStyle.Bold)
    Private Shared ReadOnly FSmall As New Font("Segoe UI", 8.0F, FontStyle.Regular)

    ' ---------- Controls ----------
    Private content As Panel
    Private lblTitle As Label
    Private lblSub As Label
    Private btnCancel As SoftButton
    Private btnRegister As SoftButton
    Private banner As SoftPanel
    Private lblIdCaption As Label
    Private pillId As SoftPanel
    Private lblPatientId As Label
    Private cardPersonal As SoftPanel
    Private cardContact As SoftPanel
    Private cardAddress As SoftPanel
    Private cardMedical As SoftPanel

    Private txtFirst As TextBox
    Private txtMiddle As TextBox
    Private txtLast As TextBox
    Private dtpDob As DateTimePicker
    Private txtAge As TextBox
    Private txtPhone As TextBox
    Private txtEmail As TextBox
    Private txtStreet As TextBox
    Private txtBarangay As TextBox
    Private cboCity As ComboBox
    Private cboProvince As ComboBox
    Private txtConditions As TextBox
    Private txtAllergies As TextBox

    Private pnlSex As SoftPanel
    Private lblSex As Label
    Private ReadOnly mnuSex As New ContextMenuStrip()
    Private errProvider As ErrorProvider

    ' ---------- State ----------
    Private _sex As String = ""
    Private _age As Integer = -1
    Private _dob As Date
    Private _patientId As String = "PT-1049"
    Private ReadOnly _showing As New HashSet(Of TextBox)()
    Private ReadOnly _wrappers As New List(Of SoftPanel)()

    Public Sub New()
        InitializeComponent()
        BuildUi()
    End Sub

#Region "Public API"

    ''' <summary>Sets the ID shown in the "Assigned patient ID" pill.</summary>
    Public Sub SetNextPatientId(id As String)
        _patientId = id
        SetPatientIdText(id)
        LayoutAll()
    End Sub

    ''' <summary>Clears every field back to its initial state.</summary>
    Public Sub ResetForm()
        For Each tb As TextBox In New TextBox() {txtFirst, txtMiddle, txtLast, txtPhone, txtEmail,
                                                  txtStreet, txtBarangay, txtConditions, txtAllergies}
            ShowHint(tb)
        Next
        dtpDob.Value = DateTime.Today.AddYears(-25)
        UpdateAge()

        LoadProvinces()
        If cboProvince.Items.Contains("Metro Manila") Then
            cboProvince.SelectedItem = "Metro Manila"
        ElseIf cboProvince.Items.Count > 0 Then
            cboProvince.SelectedIndex = 0
        End If

        _sex = ""
        lblSex.Text = "Select gender"
        lblSex.ForeColor = HintGray
        If errProvider IsNot Nothing Then
            errProvider.Clear()
        End If
        For Each w As SoftPanel In _wrappers
            w.BorderColor = BorderGray
        Next
        pnlScroll.AutoScrollPosition = New Point(0, 0)
    End Sub

#End Region

#Region "Build UI"

    Private Sub BuildUi()
        content = New Panel() With {.BackColor = PageBg, .Location = New Point(0, 0), .Size = New Size(800, 700)}
        pnlScroll.Controls.Add(content)

        ' ----- Header -----
        lblTitle = New Label() With {.Text = "Register New Patient", .Font = FTitle, .ForeColor = Ink,
                                     .AutoSize = True, .BackColor = PageBg, .Location = New Point(24, 18)}
        lblSub = New Label() With {.Text = "Create a primary clinical record for a new health clinic visitor.",
                                   .Font = FBody, .ForeColor = Muted, .AutoSize = True,
                                   .BackColor = PageBg, .Location = New Point(26, 56)}

        btnCancel = New SoftButton() With {.Text = "Cancel", .Size = New Size(84, 36), .Font = FBold,
                                           .ForeColor = Ink, .NormalColor = Color.White,
                                           .HoverColor = ColorTranslator.FromHtml("#F1F5F7"), .BorderColor = BorderGray}
        btnRegister = New SoftButton() With {.Text = "Register Patient", .Size = New Size(132, 36), .Font = FBold,
                                             .ForeColor = Color.White, .NormalColor = Teal,
                                             .HoverColor = TealDark, .BorderColor = Teal}
        AddHandler btnCancel.Click, Sub(s, e) RaiseEvent CancelRequested()
        AddHandler btnRegister.Click, Sub(s, e) OnRegisterClicked()

        ' ----- Info banner -----
        banner = MakeBox(10, Color.White, BorderGray, PageBg)
        banner.Height = 40
        AddHandler banner.Paint, Sub(s, e)
                                     e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
                                     Using b As New SolidBrush(Teal)
                                         e.Graphics.FillEllipse(b, 14, 17, 6, 6)
                                     End Using
                                 End Sub
        Dim lblBanner As New Label() With {.Text = "Patient will be permanently logged into the UCC health record directory.",
                                           .Font = FBody, .ForeColor = Ink, .AutoSize = True,
                                           .BackColor = Color.White, .Location = New Point(28, 11)}
        lblIdCaption = New Label() With {.Text = "ASSIGNED PATIENT ID:", .Font = FCap, .ForeColor = Muted,
                                         .AutoSize = True, .BackColor = Color.White}
        pillId = MakeBox(8, PillFill, PillFill, Color.White)
        pillId.Size = New Size(70, 22)
        lblPatientId = New Label() With {.Font = FCap, .ForeColor = PillText, .AutoSize = True, .BackColor = PillFill}
        pillId.Controls.Add(lblPatientId)
        banner.Controls.Add(lblBanner)
        banner.Controls.Add(lblIdCaption)
        banner.Controls.Add(pillId)
        SetPatientIdText(_patientId)

        ' ----- Validation Provider -----
        errProvider = New ErrorProvider() With {.BlinkStyle = ErrorBlinkStyle.NeverBlink}

        ' ----- Personal information -----
        cardPersonal = MakeCard("Personal Information", 172)
        Dim gp1 As TableLayoutPanel = MakeGrid(New Integer() {58}, 33.3F, 33.3F, 33.4F)
        gp1.Controls.Add(MakeField("FIRST NAME", "e.g. Maria", txtFirst), 0, 0)
        gp1.Controls.Add(MakeField("MIDDLE NAME", "e.g. Lopez", txtMiddle), 1, 0)
        gp1.Controls.Add(MakeField("LAST NAME", "e.g. Santos", txtLast, False, 0), 2, 0)
        AddGrid(cardPersonal, gp1, 50)

        ValidationHelper.AttachNameValidation(txtFirst, errProvider, "First name")
        ValidationHelper.AttachNameValidation(txtMiddle, errProvider, "Middle name")
        ValidationHelper.AttachNameValidation(txtLast, errProvider, "Last name")

        Dim gp2 As TableLayoutPanel = MakeGrid(New Integer() {58}, 50.0F, 22.0F, 28.0F)
        gp2.Controls.Add(MakeDateField("DATE OF BIRTH", dtpDob), 0, 0)
        gp2.Controls.Add(MakeField("AGE", "Auto-computed", txtAge), 1, 0)
        gp2.Controls.Add(MakeSexField(), 2, 0)
        AddGrid(cardPersonal, gp2, 108)

        txtAge.ReadOnly = True
        txtAge.TabStop = False
        txtAge.BackColor = ReadOnlyFill
        DirectCast(txtAge.Parent, SoftPanel).FillColor = ReadOnlyFill
        AddHandler dtpDob.ValueChanged, Sub(s, e) UpdateAge()
        UpdateAge()

        ' ----- Contact information -----
        cardContact = MakeCard("Contact Information", 114)
        Dim gc As TableLayoutPanel = MakeGrid(New Integer() {58}, 50.0F, 50.0F)
        gc.Controls.Add(MakeField("PHONE NUMBER", "e.g. 0917 XXX XXXX", txtPhone), 0, 0)
        gc.Controls.Add(MakeField("EMAIL ADDRESS", "e.g. maria.santos@email.com", txtEmail, False, 0), 1, 0)
        AddGrid(cardContact, gc, 50)

        ValidationHelper.AttachPhoneValidation(txtPhone, errProvider)

        ' ----- Full address -----
        cardAddress = MakeCard("Full Address", 172)
        Dim ga As TableLayoutPanel = MakeGrid(New Integer() {58, 58}, 50.0F, 50.0F)
        ga.Controls.Add(MakeField("STREET ADDRESS", "House No., Street name", txtStreet), 0, 0)
        ga.Controls.Add(MakeField("BARANGAY", "e.g. Bagong Silang", txtBarangay, False, 0), 1, 0)
        ga.Controls.Add(MakeComboField("PROVINCE", cboProvince), 0, 1)
        ga.Controls.Add(MakeComboField("CITY / MUNICIPALITY", cboCity, 0), 1, 1)
        AddGrid(cardAddress, ga, 50)

        LoadProvinces()
        AddHandler cboProvince.SelectedIndexChanged, Sub(s, e)
                                                         If cboProvince.SelectedItem IsNot Nothing Then
                                                             LoadCities(cboProvince.SelectedItem.ToString())
                                                         End If
                                                     End Sub
        If cboProvince.Items.Contains("Metro Manila") Then
            cboProvince.SelectedItem = "Metro Manila"
        ElseIf cboProvince.Items.Count > 0 Then
            cboProvince.SelectedIndex = 0
        End If

        ' Apply theme styling to action buttons
        UIThemeHelper.ApplySecondary(btnCancel)
        UIThemeHelper.ApplyPrimary(btnRegister)

        ' ----- Medical history -----
        cardMedical = MakeCard("Medical History", 360)
        Dim gm As TableLayoutPanel = MakeGrid(New Integer() {114, 72, 114}, 100.0F)
        gm.Controls.Add(MakeField("KNOWN MEDICAL CONDITIONS",
                                  "List active clinical diagnoses (e.g. Mild asthma, Seasonal allergies) or write 'None'.",
                                  txtConditions, True, 0), 0, 0)
        gm.Controls.Add(MakeWarning(), 0, 1)
        gm.Controls.Add(MakeField("KNOWN DRUG ALLERGIES",
                                  "Specify sensitive active agents (e.g. Penicillin) or write 'No known drug allergies'.",
                                  txtAllergies, True, 0), 0, 2)
        AddGrid(cardMedical, gm, 50)

        ' ----- Sex menu -----
        mnuSex.Font = FBody
        For Each opt As String In New String() {"Male", "Female", "Other"}
            Dim item As New ToolStripMenuItem(opt)
            AddHandler item.Click, Sub(s, e) SelectSex(DirectCast(s, ToolStripMenuItem).Text)
            mnuSex.Items.Add(item)
        Next

        content.Controls.AddRange(New Control() {lblTitle, lblSub, btnCancel, btnRegister, banner,
                                                 cardPersonal, cardContact, cardAddress, cardMedical})

        AddHandler pnlScroll.Resize, Sub(s, e) LayoutAll()
        LayoutAll()
    End Sub

    Private Sub LayoutAll()
        If content Is Nothing Then Return
        Const pad As Integer = 24
        Dim w As Integer = Math.Max(pnlScroll.ClientSize.Width, 700)
        Dim inner As Integer = w - 2 * pad

        btnRegister.Location = New Point(w - pad - btnRegister.Width, 22)
        btnCancel.Location = New Point(btnRegister.Left - 10 - btnCancel.Width, 22)

        banner.SetBounds(pad, 84, inner, 40)
        pillId.Location = New Point(banner.Width - 14 - pillId.Width, 9)
        lblIdCaption.Location = New Point(pillId.Left - 8 - lblIdCaption.Width, (banner.Height - lblIdCaption.Height) \ 2)

        Dim leftW As Integer = CInt(inner * 0.64)
        Dim rightW As Integer = inner - leftW - 16
        Dim y As Integer = 140
        cardPersonal.SetBounds(pad, y, leftW, cardPersonal.Height)
        y += cardPersonal.Height + 16
        cardContact.SetBounds(pad, y, leftW, cardContact.Height)
        y += cardContact.Height + 16
        cardAddress.SetBounds(pad, y, leftW, cardAddress.Height)
        y += cardAddress.Height + 16
        cardMedical.SetBounds(pad + leftW + 16, 140, rightW, cardMedical.Height)

        content.Size = New Size(w, Math.Max(y, cardMedical.Bottom + 16) + 8)
    End Sub

    Private Sub SetPatientIdText(id As String)
        lblPatientId.Text = id
        pillId.Width = lblPatientId.Width + 20
        lblPatientId.Location = New Point(10, (pillId.Height - lblPatientId.Height) \ 2)
    End Sub

#End Region

#Region "Control factories"

    Private Function MakeBox(radius As Integer, fill As Color, border As Color, backdrop As Color) As SoftPanel
        Return New SoftPanel() With {.Radius = radius, .FillColor = fill, .BorderColor = border, .BackColor = backdrop}
    End Function

    Private Function MakeCard(title As String, height As Integer) As SoftPanel
        Dim c As SoftPanel = MakeBox(12, Color.White, BorderGray, PageBg)
        c.Height = height
        c.Controls.Add(New Label() With {.Text = title, .Font = FCardTitle, .ForeColor = Ink,
                                         .AutoSize = True, .BackColor = Color.White, .Location = New Point(18, 16)})
        Return c
    End Function

    Private Function MakeGrid(rowHeights As Integer(), ParamArray cols As Single()) As TableLayoutPanel
        Dim g As New TableLayoutPanel() With {.ColumnCount = cols.Length, .RowCount = rowHeights.Length,
                                              .BackColor = Color.White, .Margin = Padding.Empty,
                                              .Padding = Padding.Empty}
        For Each c As Single In cols
            g.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, c))
        Next
        Dim total As Integer = 0
        For Each h As Integer In rowHeights
            g.RowStyles.Add(New RowStyle(SizeType.Absolute, h))
            total += h
        Next
        g.Size = New Size(200, total)
        Return g
    End Function

    Private Sub AddGrid(card As SoftPanel, g As TableLayoutPanel, y As Integer)
        g.Location = New Point(18, y)
        g.Width = Math.Max(card.Width - 36, 50)
        card.Controls.Add(g)
        AddHandler card.Resize, Sub(s, e) g.Width = Math.Max(card.Width - 36, 50)
    End Sub

    ''' <summary>Caption label plus a rounded input wrapper, sized to its grid cell.</summary>
    Private Function MakeHost(caption As String, gap As Integer, wrapHeight As Integer, ByRef wrapOut As SoftPanel) As Panel
        Dim host As New Panel() With {.Dock = DockStyle.Fill, .Margin = New Padding(0, 0, gap, 0),
                                      .BackColor = Color.White}
        Dim cap As New Label() With {.Text = caption, .Font = FCap, .ForeColor = Muted, .AutoSize = False,
                                     .BackColor = Color.White, .Location = New Point(0, 0), .Size = New Size(100, 14)}
        Dim wrap As SoftPanel = MakeBox(8, Color.White, BorderGray, Color.White)
        wrap.Location = New Point(0, 17)
        wrap.Size = New Size(100, wrapHeight)
        host.Controls.Add(cap)
        host.Controls.Add(wrap)
        AddHandler host.Resize, Sub(s, e)
                                    cap.Width = host.Width
                                    wrap.Width = host.Width
                                End Sub
        _wrappers.Add(wrap)
        wrapOut = wrap
        Return host
    End Function

    Private Function MakeField(caption As String, hint As String, ByRef box As TextBox,
                               Optional multiline As Boolean = False,
                               Optional gap As Integer = 12) As Panel
        Dim wrap As SoftPanel = Nothing
        Dim host As Panel = MakeHost(caption, gap, If(multiline, 88, 34), wrap)

        Dim tb As New TextBox() With {.BorderStyle = BorderStyle.None, .Font = FBody, .BackColor = Color.White,
                                      .ForeColor = Ink, .Multiline = multiline, .Tag = hint}
        wrap.Controls.Add(tb)
        AddHandler wrap.Resize, Sub(s, e)
                                    If multiline Then
                                        tb.SetBounds(10, 8, wrap.Width - 20, wrap.Height - 16)
                                    Else
                                        tb.SetBounds(10, (wrap.Height - tb.Height) \ 2, wrap.Width - 20, tb.Height)
                                    End If
                                End Sub

        ShowHint(tb)

        AddHandler tb.Enter, Sub(s, e)
                                 If _showing.Contains(tb) Then
                                     _showing.Remove(tb)
                                     tb.Text = ""
                                     tb.ForeColor = Ink
                                 End If
                                 wrap.BorderColor = Teal
                             End Sub
        AddHandler tb.Leave, Sub(s, e)
                                 If tb.Text.Trim().Length = 0 Then ShowHint(tb)
                                 wrap.BorderColor = BorderGray
                             End Sub
        AddHandler tb.TextChanged, Sub(s, e)
                                       If Not _showing.Contains(tb) Then
                                           wrap.BorderColor = If(tb.Focused, Teal, BorderGray)
                                       End If
                                   End Sub
        box = tb
        Return host
    End Function

    Private Function MakeDateField(caption As String, ByRef picker As DateTimePicker, Optional gap As Integer = 12) As Panel
        Dim wrap As SoftPanel = Nothing
        Dim host As Panel = MakeHost(caption, gap, 34, wrap)

        Dim dtp As New DateTimePicker() With {
            .Format = DateTimePickerFormat.Custom,
            .CustomFormat = "yyyy-MM-dd",
            .Font = FBody,
            .MaxDate = DateTime.Today,
            .Value = DateTime.Today.AddYears(-25),
            .CalendarTitleBackColor = Teal,
            .CalendarTitleForeColor = Color.White
        }
        wrap.Controls.Add(dtp)
        AddHandler wrap.Resize, Sub(s, e)
                                    dtp.SetBounds(10, (wrap.Height - dtp.Height) \ 2, wrap.Width - 20, dtp.Height)
                                End Sub

        picker = dtp
        Return host
    End Function

    Private Function MakeComboField(caption As String, ByRef combo As ComboBox, Optional gap As Integer = 12) As Panel
        Dim wrap As SoftPanel = Nothing
        Dim host As Panel = MakeHost(caption, gap, 34, wrap)

        Dim cbo As New ComboBox() With {
            .DropDownStyle = ComboBoxStyle.DropDown,
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend,
            .AutoCompleteSource = AutoCompleteSource.ListItems,
            .Font = FBody,
            .BackColor = Color.White,
            .ForeColor = Ink,
            .FlatStyle = FlatStyle.Flat
        }
        wrap.Controls.Add(cbo)
        AddHandler wrap.Resize, Sub(s, e)
                                    cbo.SetBounds(10, (wrap.Height - cbo.Height) \ 2, wrap.Width - 20, cbo.Height)
                                End Sub

        combo = cbo
        Return host
    End Function

    Private Sub LoadProvinces()
        cboProvince.Items.Clear()
        Dim provinces = SqliteGeoRepository.GetProvinces()
        For Each p In provinces
            cboProvince.Items.Add(p)
        Next
    End Sub

    Private Sub LoadCities(provinceName As String)
        cboCity.Items.Clear()
        Dim cities = SqliteGeoRepository.GetCitiesByProvince(provinceName)
        For Each c In cities
            cboCity.Items.Add(c)
        Next
        If cboCity.Items.Count > 0 Then
            cboCity.SelectedIndex = 0
        End If
    End Sub

    Private Function MakeSexField() As Panel
        Dim wrap As SoftPanel = Nothing
        Dim host As Panel = MakeHost("SEX", 0, 34, wrap)
        pnlSex = wrap
        lblSex = New Label() With {.Text = "Select gender", .Font = FBody, .ForeColor = HintGray,
                                   .BackColor = Color.White, .AutoSize = False, .Location = New Point(10, 0),
                                   .Size = New Size(80, 34), .TextAlign = ContentAlignment.MiddleLeft,
                                   .Cursor = Cursors.Hand}
        pnlSex.Cursor = Cursors.Hand
        pnlSex.Controls.Add(lblSex)
        AddHandler pnlSex.Resize, Sub(s, e) lblSex.Width = Math.Max(pnlSex.Width - 30, 20)
        AddHandler pnlSex.Paint, Sub(s, e)
                                     e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
                                     Dim cx As Integer = pnlSex.Width - 18
                                     Dim cy As Integer = pnlSex.Height \ 2
                                     Using p As New Pen(Muted, 1.5F)
                                         e.Graphics.DrawLines(p, New Point() {New Point(cx - 4, cy - 2),
                                                                             New Point(cx, cy + 2),
                                                                             New Point(cx + 4, cy - 2)})
                                     End Using
                                 End Sub
        AddHandler pnlSex.Click, Sub(s, e) ShowSexMenu()
        AddHandler lblSex.Click, Sub(s, e) ShowSexMenu()
        Return host
    End Function

    Private Function MakeWarning() As SoftPanel
        Dim bx As SoftPanel = MakeBox(6, WarnFill, WarnFill, Color.White)
        bx.Dock = DockStyle.Fill
        bx.Margin = New Padding(0, 4, 0, 4)
        Dim t1 As New Label() With {.Text = "IMPORTANT: DRUG ALLERGIES", .Font = FCap, .ForeColor = WarnText,
                                    .BackColor = WarnFill, .AutoSize = True, .Location = New Point(10, 9)}
        Dim t2 As New Label() With {.Text = "Specifying drug sensitivity acts as a safety stop when generating prescriptions.",
                                    .Font = FSmall, .ForeColor = WarnText, .BackColor = WarnFill,
                                    .AutoSize = False, .Location = New Point(10, 25), .Size = New Size(200, 34)}
        bx.Controls.Add(t1)
        bx.Controls.Add(t2)
        AddHandler bx.Resize, Sub(s, e) t2.Width = Math.Max(bx.Width - 20, 20)
        Return bx
    End Function

#End Region

#Region "Placeholder helpers"

    Private Sub ShowHint(tb As TextBox)
        _showing.Add(tb)
        tb.ForeColor = HintGray
        tb.Text = CStr(tb.Tag)
    End Sub

    Private Sub SetValue(tb As TextBox, value As String)
        If String.IsNullOrEmpty(value) Then
            ShowHint(tb)
        Else
            _showing.Remove(tb)
            tb.ForeColor = Ink
            tb.Text = value
        End If
    End Sub

    Private Function GetValue(tb As TextBox) As String
        If _showing.Contains(tb) Then Return ""
        Return tb.Text.Trim()
    End Function

#End Region

#Region "Age and sex"

    Private Sub UpdateAge()
        If dtpDob Is Nothing Then Return
        Dim dob = dtpDob.Value.Date
        If dob <= Date.Today AndAlso dob.Year >= 1900 Then
            Dim a As Integer = Date.Today.Year - dob.Year
            If dob > Date.Today.AddYears(-a) Then a -= 1
            _dob = dob
            SetAge(a)
        Else
            SetAge(-1)
        End If
    End Sub

    Private Sub SetAge(value As Integer)
        _age = value
        If value < 0 Then
            ShowHint(txtAge)
        Else
            _showing.Remove(txtAge)
            txtAge.ForeColor = Ink
            txtAge.Text = value.ToString()
        End If
    End Sub

    Private Sub ShowSexMenu()
        mnuSex.Show(pnlSex, New Point(0, pnlSex.Height + 2))
    End Sub

    Private Sub SelectSex(value As String)
        _sex = value
        lblSex.Text = value
        lblSex.ForeColor = Ink
        pnlSex.BorderColor = BorderGray
    End Sub

#End Region

#Region "Validation and submit"

    Private Sub MarkInvalid(c As Control)
        Dim p As SoftPanel = If(TypeOf c Is TextBox, TryCast(c.Parent, SoftPanel), TryCast(c, SoftPanel))
        If p IsNot Nothing Then p.BorderColor = ErrorRed
    End Sub

    Private Sub OnRegisterClicked()
        For Each w As SoftPanel In _wrappers
            w.BorderColor = BorderGray
        Next

        Dim msgs As New List(Of String)()
        Dim firstBad As Control = Nothing
        Dim check As Action(Of Control, Boolean, String) = Sub(c, ok, msg)
                                                               If ok Then Return
                                                               msgs.Add(msg)
                                                               MarkInvalid(c)
                                                               If firstBad Is Nothing Then firstBad = c
                                                           End Sub

        Dim firstName = GetValue(txtFirst)
        Dim lastName = GetValue(txtLast)
        Dim phone = GetValue(txtPhone)
        Dim email = GetValue(txtEmail)
        Dim street = GetValue(txtStreet)
        Dim barangay = GetValue(txtBarangay)
        Dim conditions = GetValue(txtConditions)
        Dim allergies = GetValue(txtAllergies)

        check(txtFirst, ValidationHelper.IsValidName(firstName), "First name is required and can only contain letters, spaces, hyphens, and ñ.")
        check(txtLast, ValidationHelper.IsValidName(lastName), "Last name is required and can only contain letters, spaces, hyphens, and ñ.")
        check(dtpDob, _age >= 0 AndAlso _dob <= Date.Today, "Date of birth must be today or earlier.")
        check(pnlSex, _sex.Length > 0, "Please select a gender.")
        check(txtPhone, ValidationHelper.IsValidPhone(phone), "Phone number must be a valid 11-digit Philippine mobile number starting with 09 (e.g. 09171234567).")
        check(txtEmail, email.Length = 0 OrElse Regex.IsMatch(email, "^[^@\s]+@[^@\s]+\.[^@\s]+$"),
              "Email address is not valid (or leave it blank).")
        check(txtStreet, street.Length > 0, "Street address is required.")
        check(txtBarangay, barangay.Length > 0, "Barangay is required.")

        Dim provinceStr = If(cboProvince.SelectedItem IsNot Nothing, cboProvince.SelectedItem.ToString(), cboProvince.Text.Trim())
        Dim cityStr = If(cboCity.SelectedItem IsNot Nothing, cboCity.SelectedItem.ToString(), cboCity.Text.Trim())

        check(cboProvince, Not String.IsNullOrWhiteSpace(provinceStr), "Please select or enter a province.")
        check(cboCity, Not String.IsNullOrWhiteSpace(cityStr), "Please select or enter a city/municipality.")
        check(txtConditions, conditions.Length > 0, "Known medical conditions: list them or write 'None'.")
        check(txtAllergies, allergies.Length > 0, "Known drug allergies: list them or write 'No known drug allergies'.")

        If msgs.Count > 0 Then
            If TypeOf firstBad Is TextBox Then firstBad.Focus()
            MessageBox.Show("Please fix the following:" & vbCrLf & vbCrLf &
                            String.Join(vbCrLf, msgs.Select(Function(m) "- " & m)),
                            "Register patient", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Normalize names and addresses to Proper Case
        firstName = ValidationHelper.NormalizeProperCase(firstName)
        Dim middleName = ValidationHelper.NormalizeProperCase(GetValue(txtMiddle))
        lastName = ValidationHelper.NormalizeProperCase(lastName)
        street = ValidationHelper.NormalizeProperCase(street)
        barangay = ValidationHelper.NormalizeProperCase(barangay)

        ' Duplicate detection: Check phone number
        Dim dupByPhone = PatientRepository.FindDuplicateByPhone(phone, _patientId)
        If dupByPhone IsNot Nothing Then
            Dim res = MessageBox.Show(
                $"DUPLICATE CONTACT NUMBER DETECTED" & vbCrLf & vbCrLf &
                $"The phone number {phone} is already registered to:" & vbCrLf &
                $"• Patient: {dupByPhone.Name}" & vbCrLf &
                $"• Patient ID: {dupByPhone.PatientId}" & vbCrLf &
                $"• Birth Date: {dupByPhone.BirthDate}" & vbCrLf & vbCrLf &
                "Do you still want to proceed with registering this new patient?",
                "Duplicate Contact Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If res <> DialogResult.Yes Then
                txtPhone.Focus()
                Return
            End If
        End If

        ' Duplicate detection: Check Name + BirthDate identity profile
        Dim fullCheckName = String.Join(" ", New String() {firstName, middleName, lastName}.Where(Function(s) Not String.IsNullOrWhiteSpace(s)))
        Dim dupByProfile = PatientRepository.FindDuplicateProfile(fullCheckName, "Born " & _dob.ToString("MMMM dd, yyyy"), _patientId)
        If dupByProfile Is Nothing Then
            dupByProfile = PatientRepository.FindDuplicateProfile(fullCheckName, _dob.ToString("yyyy-MM-dd"), _patientId)
        End If
        If dupByProfile IsNot Nothing Then
            MessageBox.Show(
                $"DUPLICATE PATIENT PROFILE DETECTED" & vbCrLf & vbCrLf &
                $"A patient with the identical name and date of birth already exists in the clinic database:" & vbCrLf &
                $"• Patient Name: {dupByProfile.Name}" & vbCrLf &
                $"• Patient ID: {dupByProfile.PatientId}" & vbCrLf &
                $"• Registered Contact: {dupByProfile.Contact}" & vbCrLf & vbCrLf &
                "Registration cannot proceed for an identical patient record.",
                "Duplicate Patient Detected", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtFirst.Focus()
            Return
        End If

        Dim rec As New NewPatientRecord() With {
            .PatientId = _patientId,
            .FirstName = firstName,
            .MiddleName = middleName,
            .LastName = lastName,
            .DateOfBirth = _dob,
            .Age = _age,
            .Sex = _sex,
            .Phone = phone,
            .Email = email,
            .Street = street,
            .Barangay = barangay,
            .City = cityStr,
            .Province = provinceStr,
            .MedicalConditions = conditions,
            .DrugAllergies = allergies
        }
        RaiseEvent PatientRegistered(rec)
    End Sub

#End Region

End Class

''' <summary>Validated data from the Register Patient form.</summary>
Public Class NewPatientRecord
    Public Property PatientId As String
    Public Property FirstName As String
    Public Property MiddleName As String
    Public Property LastName As String
    Public Property DateOfBirth As Date
    Public Property Age As Integer
    Public Property Sex As String
    Public Property Phone As String
    Public Property Email As String
    Public Property Street As String
    Public Property Barangay As String
    Public Property City As String
    Public Property Province As String
    Public Property MedicalConditions As String
    Public Property DrugAllergies As String

    Public ReadOnly Property FullName As String
        Get
            Return String.Join(" ", New String() {FirstName, MiddleName, LastName} _
                               .Where(Function(p) Not String.IsNullOrWhiteSpace(p)))
        End Get
    End Property
End Class

''' <summary>Panel with a rounded, bordered, filled background.</summary>
Public Class SoftPanel
    Inherits Panel

    Private _radius As Integer = 8
    Private _borderColor As Color = Color.Gainsboro
    Private _fillColor As Color = Color.White

    Public Sub New()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or
                 ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw, True)
    End Sub

    Public Property Radius As Integer
        Get
            Return _radius
        End Get
        Set(value As Integer)
            _radius = value
            Invalidate()
        End Set
    End Property

    Public Property BorderColor As Color
        Get
            Return _borderColor
        End Get
        Set(value As Color)
            _borderColor = value
            Invalidate()
        End Set
    End Property

    Public Property FillColor As Color
        Get
            Return _fillColor
        End Get
        Set(value As Color)
            _fillColor = value
            Invalidate()
        End Set
    End Property

    Public Shared Function RoundRect(r As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        If radius <= 0 Then
            path.AddRectangle(r)
            Return path
        End If
        Dim d As Integer = radius * 2
        path.AddArc(r.X, r.Y, d, d, 180, 90)
        path.AddArc(r.Right - d, r.Y, d, d, 270, 90)
        path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90)
        path.AddArc(r.X, r.Bottom - d, d, d, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        e.Graphics.Clear(BackColor)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Using path As GraphicsPath = RoundRect(New Rectangle(0, 0, Width - 1, Height - 1), _radius)
            Using b As New SolidBrush(_fillColor)
                e.Graphics.FillPath(b, path)
            End Using
            Using p As New Pen(_borderColor)
                e.Graphics.DrawPath(p, path)
            End Using
        End Using
        MyBase.OnPaint(e)
    End Sub
End Class

''' <summary>Flat rounded button with a hover color.</summary>
Public Class SoftButton
    Inherits Control

    Private _hover As Boolean

    Public Property Radius As Integer = 8
    Public Property NormalColor As Color = Color.White
    Public Property HoverColor As Color = Color.WhiteSmoke
    Public Property BorderColor As Color = Color.Gainsboro

    Public Sub New()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or
                 ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw, True)
        Cursor = Cursors.Hand
    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        _hover = True
        Invalidate()
        MyBase.OnMouseEnter(e)
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        _hover = False
        Invalidate()
        MyBase.OnMouseLeave(e)
    End Sub

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        Invalidate()
        MyBase.OnTextChanged(e)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        g.Clear(If(Parent IsNot Nothing, Parent.BackColor, BackColor))
        g.SmoothingMode = SmoothingMode.AntiAlias
        Using path As GraphicsPath = SoftPanel.RoundRect(New Rectangle(0, 0, Width - 1, Height - 1), Radius)
            Using b As New SolidBrush(If(_hover, HoverColor, NormalColor))
                g.FillPath(b, path)
            End Using
            Using p As New Pen(BorderColor)
                g.DrawPath(p, path)
            End Using
        End Using
        TextRenderer.DrawText(g, Text, Font, ClientRectangle, ForeColor,
                              TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter Or
                              TextFormatFlags.SingleLine)
    End Sub
End Class