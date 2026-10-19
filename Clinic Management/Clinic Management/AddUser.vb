Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.Text.RegularExpressions
Imports Ferrando.UI.WinForms.Controles

''' <summary>
''' "Add user" wizard (3 steps) shown inside Form1.mainScreen.
''' Open it from the User management page with:  AddUser.ShowFrom(Me, Sub(created) ...)
''' Layout: tlpRoot (TableLayoutPanel) = header row + scrollable body row (pnlScroll).
''' </summary>
Public Class AddUser

    ' ---- Events
    Public Event UserCreated(user As NewUser)
    Public Event Finished(created As Boolean)

    ' ---- Data supplied by the host (replace with database values)
    Public Property ExistingUsers As List(Of ExistingUser) = SampleUsers()
    Private _staffId As String = "STF-0213"
    Public Property StaffId As String
        Get
            Return _staffId
        End Get
        Set(value As String)
            _staffId = value
            If fStaff IsNot Nothing Then fStaff.Box.Text = value
        End Set
    End Property

    ' ---- Colors
    Private Shared ReadOnly ColTeal As Color = Color.FromArgb(35, 137, 120)
    Private Shared ReadOnly ColNormalBorder As Color = Color.FromArgb(220, 228, 232)
    Private Shared ReadOnly ColErr As Color = Color.FromArgb(205, 75, 70)
    Private Shared ReadOnly ColErrText As Color = Color.FromArgb(185, 48, 40)
    Private Shared ReadOnly ColHint As Color = Color.FromArgb(140, 155, 165)
    Private Shared ReadOnly ColGrey As Color = Color.FromArgb(115, 138, 148)
    Private Shared ReadOnly ColDark As Color = Color.FromArgb(30, 45, 55)
    Private Shared ReadOnly ColMint As Color = Color.FromArgb(221, 240, 235)
    Private Shared ReadOnly ColSelectedBack As Color = Color.FromArgb(237, 247, 244)
    Private Shared ReadOnly ColCardBorder As Color = Color.FromArgb(232, 237, 240)
    Private Shared ReadOnly ColDivider As Color = Color.FromArgb(242, 244, 247)

    Private Shared ReadOnly FontStepNum As New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    Private Shared ReadOnly FontBadge As New Font("Segoe UI", 7.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    Private Shared ReadOnly FontStepActive As New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
    Private Shared ReadOnly FontStepIdle As New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
    Private Shared ReadOnly FontKey As New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
    Private Shared ReadOnly FontValue As New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))

    ' ---- A text field = card + textbox + message label
    Private Class FieldRef
        Public Card As FCard
        Public Box As TextBox
        Public Msg As Label
        Public Hint As String
        Public HasError As Boolean
        Public Focused As Boolean
    End Class

    Private fFirst, fLast, fUser, fEmail, fMobile, fStaff, fPrc As FieldRef
    Private allFields As List(Of FieldRef)

    ' ---- State
    Private currentStep As Integer = 1

    Public ReadOnly Property IsDirty As Boolean
        Get
            If fFirst IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(fFirst.Box.Text) Then Return True
            If fLast IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(fLast.Box.Text) Then Return True
            If fUser IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(fUser.Box.Text) Then Return True
            If fEmail IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(fEmail.Box.Text) Then Return True
            If fMobile IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(fMobile.Box.Text) Then Return True
            If fPrc IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(fPrc.Box.Text) Then Return True
            Return currentStep > 1
        End Get
    End Property


    Private selectedRole As String = "Doctor"
    Private startDate As Date = Date.Today
    Private calDrop As ToolStripDropDown
    Private cal As MonthCalendar

    Private stepCircles() As Panel
    Private stepNames() As Label
    Private stepLines() As Panel
    Private accessDots() As Panel
    Private accessItems() As Label

    Public Sub New()
        InitializeComponent()
        DoubleBuffered = True

        stepCircles = {pnlStepCircle1, pnlStepCircle2, pnlStepCircle3}
        stepNames = {lblStepName1, lblStepName2, lblStepName3}
        stepLines = {pnlStepLine1, pnlStepLine2}
        accessDots = {pnlAccessDot1, pnlAccessDot2, pnlAccessDot3, pnlAccessDot4, pnlAccessDot5, pnlAccessDot6}
        accessItems = {lblAccessItem1, lblAccessItem2, lblAccessItem3, lblAccessItem4, lblAccessItem5, lblAccessItem6}

        fFirst = MakeField(cardFirstName, txtFirstName, lblFirstNameMsg)
        fLast = MakeField(cardLastName, txtLastName, lblLastNameMsg)
        fUser = MakeField(cardUsername, txtUsername, lblUsernameMsg)
        fEmail = MakeField(cardEmail, txtEmail, lblEmailMsg)
        fMobile = MakeField(cardMobile, txtMobile, lblMobileMsg)
        fStaff = MakeField(cardStaffId, txtStaffId, lblStaffIdMsg)
        fPrc = MakeField(cardPrc, txtPrc, lblPrcMsg)
        allFields = New List(Of FieldRef) From {fFirst, fLast, fUser, fEmail, fMobile, fStaff, fPrc}

        fStaff.Box.Text = StaffId
        lblStartDateValue.Text = FormatDate(startDate)

        ' paint handlers for the custom-drawn bits
        For Each p In stepCircles : AddHandler p.Paint, AddressOf StepCircle_Paint : Next
        For Each p In {pnlNextBadge1, pnlNextBadge2, pnlNextBadge3, pnlNextBadge4} : AddHandler p.Paint, AddressOf Badge_Paint : Next
        For Each p In accessDots : AddHandler p.Paint, AddressOf Dot_Paint : Next
        For Each p In {pnlDoctorRadio, pnlReceptionistRadio} : AddHandler p.Paint, AddressOf Radio_Paint : Next
        For Each p In {pnlStartDateCaret, pnlSpecialtyCaret, pnlLengthCaret, pnlClinicCaret} : AddHandler p.Paint, AddressOf Caret_Paint : Next

        ' dropdowns
        WireDropdown(cardSpecialty, lblSpecialtyValue,
                     {"General Medicine", "Pediatrics", "Internal Medicine", "Family Medicine", "Obstetrics and Gynecology", "Dermatology", "Dentistry"})
        WireDropdown(cardLength, lblLengthValue, {"15 minutes", "20 minutes", "30 minutes", "45 minutes", "60 minutes"})
        WireDropdown(cardClinic, lblClinicValue, {"UCC Health Clinic"})
        AddHandler cardStartDate.Click, AddressOf StartDate_Click
        AddHandler lblStartDateValue.Click, AddressOf StartDate_Click
        AddHandler pnlStartDateCaret.Click, AddressOf StartDate_Click

        ' role cards
        For Each c In {cardRoleDoctor, cardRoleReceptionist}
            AddHandler c.Click, AddressOf Role_Click
            For Each child As Control In c.Controls : AddHandler child.Click, AddressOf Role_Click : Next
        Next

        ' Apply button styling
        UIThemeHelper.ApplySecondary(btnCancel)
        UIThemeHelper.ApplyPrimary(btnContinue1)
        UIThemeHelper.ApplySecondary(btnBack2)
        UIThemeHelper.ApplyPrimary(btnContinue2)
        UIThemeHelper.ApplySecondary(btnBack3)
        UIThemeHelper.ApplyPrimary(btnCreate)

        GoToStep(1)
    End Sub

    ''' <summary>Swaps this page in for <paramref name="current"/> inside the same parent (mainScreen).</summary>
    Public Shared Sub ShowFrom(current As Form, Optional onFinished As Action(Of Boolean) = Nothing, Optional existing As IEnumerable(Of ExistingUser) = Nothing, Optional nextStaffId As String = Nothing, Optional onUserCreated As Action(Of NewUser) = Nothing)
        Dim host As Control = current.Parent
        Dim page As New AddUser()
        If existing IsNot Nothing Then page.ExistingUsers = existing.ToList()
        If nextStaffId IsNot Nothing Then page.StaffId = nextStaffId

        If onUserCreated IsNot Nothing Then
            AddHandler page.UserCreated, Sub(u) onUserCreated(u)
        End If

        If host Is Nothing Then          ' not embedded -> open on its own
            page.Show()
            Return
        End If

        page.TopLevel = False
        page.FormBorderStyle = FormBorderStyle.None
        page.Dock = DockStyle.Fill

        AddHandler page.Finished,
            Sub(created As Boolean)
                host.Controls.Clear()
                host.Controls.Add(current)
                current.Show()
                page.BeginInvoke(New MethodInvoker(Sub() page.Dispose()))
                If onFinished IsNot Nothing Then onFinished(created)
            End Sub

        host.Controls.Clear()
        host.Controls.Add(page)
        page.Show()
    End Sub

    ' =====================================================================
    '  Step navigation
    ' =====================================================================
    Private Sub GoToStep(n As Integer)
        currentStep = n
        pnlStep1.Visible = (n = 1)
        pnlStep2.Visible = (n = 2)
        pnlStep3.Visible = (n = 3)

        pnlScroll.AutoScrollPosition = New Point(0, 0)   ' start each step at the top

        If n = 2 Then ApplyRoleUI()
        If n = 3 Then BuildReview()
        UpdateStepper()
    End Sub

    Private Sub UpdateStepper()
        For i As Integer = 0 To 2
            stepNames(i).Font = If(i + 1 = currentStep, FontStepActive, FontStepIdle)
            stepNames(i).ForeColor = If(i + 1 = currentStep, Color.FromArgb(22, 51, 65), ColGrey)
            stepCircles(i).Invalidate()
        Next
        For i As Integer = 0 To 1
            stepLines(i).BackColor = If(i + 1 < currentStep, ColTeal, ColNormalBorder)
        Next
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        RaiseEvent Finished(False)
    End Sub

    Private Sub btnContinue1_Click(sender As Object, e As EventArgs) Handles btnContinue1.Click
        If ValidateStep1() Then GoToStep(2)
    End Sub

    Private Sub btnBack2_Click(sender As Object, e As EventArgs) Handles btnBack2.Click
        GoToStep(1)
    End Sub

    Private Sub btnContinue2_Click(sender As Object, e As EventArgs) Handles btnContinue2.Click
        If ValidateStep2() Then GoToStep(3)
    End Sub

    Private Sub btnBack3_Click(sender As Object, e As EventArgs) Handles btnBack3.Click
        GoToStep(2)
    End Sub

    Private Sub lblEditAccount_Click(sender As Object, e As EventArgs) Handles lblEditAccount.Click
        GoToStep(1)
    End Sub

    Private Sub lblEditRole_Click(sender As Object, e As EventArgs) Handles lblEditRole.Click
        GoToStep(2)
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Dim u As NewUser = BuildUser()

        ' TODO (database): insert the user with Status = "Invited"
        '   - store a HASH of u.Password, never the plain text
        '   - create the 72-hour invitation link and send the invitation email
        Using dlg As New InviteCodeDialog(u.FullName, u.Role)
            u.InviteCode = dlg.InviteCode
            RaiseEvent UserCreated(u)
            AuditStore.Log("Rosa Dela Cruz", "Administrator", "User created", $"{u.FullName} ({u.Role})", "Success")
            dlg.ShowDialog(Me)
            AuditStore.Log("Rosa Dela Cruz", "Administrator", "Invitation created", $"One-time code generated for {u.FullName} ({dlg.InviteCode})", "Success")
        End Using

        RaiseEvent Finished(True)
    End Sub

    ' =====================================================================
    '  Step 1: account details + validation
    ' =====================================================================
    Private Function ValidateStep1() As Boolean
        Dim errors As Integer = 0
        For Each f In {fFirst, fLast, fUser, fEmail, fMobile} : ResetField(f) : Next

        If fFirst.Box.Text.Trim().Length = 0 Then Fail(fFirst, "Enter the first name.", errors)
        If fLast.Box.Text.Trim().Length = 0 Then Fail(fLast, "Enter the last name.", errors)

        Dim username As String = fUser.Box.Text.Trim()
        If username.Length = 0 Then
            Fail(fUser, "Enter a username.", errors)
        ElseIf Not Regex.IsMatch(username, "^[A-Za-z0-9._]{3,20}$") Then
            Fail(fUser, "Use 3-20 letters, numbers, dots or underscores.", errors)
        ElseIf ExistingUsers.Any(Function(u) String.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase)) Then
            Fail(fUser, "This username is already taken.", errors)
        End If

        Dim email As String = fEmail.Box.Text.Trim()
        If email.Length = 0 Then
            Fail(fEmail, "Enter the work email.", errors)
        ElseIf Not Regex.IsMatch(email, "^[^@\s]+@[^@\s]+\.[^@\s]+$") Then
            Fail(fEmail, "Enter a valid email address.", errors)
        Else
            Dim owner As ExistingUser = ExistingUsers.FirstOrDefault(Function(u) String.Equals(u.Email, email, StringComparison.OrdinalIgnoreCase))
            If owner IsNot Nothing Then Fail(fEmail, $"This email is already used by {owner.FullName} ({owner.Role}).", errors)
        End If

        Dim mobile As String = NormalizeMobile(fMobile.Box.Text)
        If mobile Is Nothing Then
            Fail(fMobile, "Enter a valid mobile number, for example 0917 555 0134.", errors)
        Else
            fMobile.Box.Text = mobile
            ResetField(fMobile)
        End If

        ShowBanner(errors)
        If errors > 0 Then
            For Each f In {fFirst, fLast, fUser, fEmail, fMobile}
                If f.HasError Then f.Box.Focus() : Exit For
            Next
        End If
        Return errors = 0
    End Function

    ''' <summary>Accepts 09XXXXXXXXX, +639XXXXXXXXX or 639XXXXXXXXX; returns "09XX XXX XXXX" or Nothing.</summary>
    Private Shared Function NormalizeMobile(raw As String) As String
        Dim d As String = Regex.Replace(If(raw, ""), "[^\d+]", "")
        If Regex.IsMatch(d, "^\+639\d{9}$") Then d = "0" & d.Substring(3)
        If Regex.IsMatch(d, "^639\d{9}$") Then d = "0" & d.Substring(2)
        If Not Regex.IsMatch(d, "^09\d{9}$") Then Return Nothing
        Return d.Substring(0, 4) & " " & d.Substring(4, 3) & " " & d.Substring(7)
    End Function

    Private Sub ShowBanner(errors As Integer)
        cardBanner.Visible = errors > 0
        If errors > 0 Then lblBanner.Text = $"Fix {errors} field{If(errors = 1, "", "s")} to continue."
        Dim dy As Integer = If(cardBanner.Visible, 44, 0)
        cardAccount.Top = dy
        cardNext.Top = dy
    End Sub

    ' =====================================================================
    '  Step 2: role and access
    ' =====================================================================
    Private Sub Role_Click(sender As Object, e As EventArgs)
        Dim c As Control = DirectCast(sender, Control)
        Dim card As FCard = If(TypeOf c Is FCard, DirectCast(c, FCard), DirectCast(c.Parent, FCard))
        selectedRole = CStr(card.Tag)
        ApplyRoleUI()
    End Sub

    Private Sub ApplyRoleUI()
        Dim isDoctor As Boolean = (selectedRole = "Doctor")

        SetRoleCard(cardRoleDoctor, pnlDoctorRadio, isDoctor)
        SetRoleCard(cardRoleReceptionist, pnlReceptionistRadio, Not isDoctor)

        lblRoleDetailsTitle.Text = selectedRole & " details"
        lblAccessIntro.Text = $"What a {selectedRole} can do in the system"

        Dim labels() As String
        If isDoctor Then
            labels = New String() {"View and edit patient records", "Write consultation notes", "Manage own schedule", "See all doctor schedules", "Manage user accounts", "View the audit log"}
        Else
            labels = New String() {"Register and update patients", "Book and manage appointments", "See all doctor schedules", "Write consultation notes", "Manage user accounts", "View the audit log"}
        End If
        For i As Integer = 0 To 5
            Dim allowed As Boolean = i < 3
            accessItems(i).Text = labels(i)
            accessItems(i).ForeColor = If(allowed, Color.FromArgb(45, 60, 70), ColHint)
            accessDots(i).Tag = allowed
            accessDots(i).Invalidate()
        Next

        ' Doctor shows 4 fields; Receptionist only needs the assigned clinic
        For Each c As Control In New Control() {lblSpecialtyLabel, cardSpecialty, lblPrcLabel, cardPrc, lblPrcMsg, lblLengthLabel, cardLength}
            c.Visible = isDoctor
        Next
        lblClinicLabel.Location = If(isDoctor, New Point(270, 224), New Point(18, 150))
        cardClinic.Location = If(isDoctor, New Point(270, 241), New Point(18, 167))

        Dim btnY As Integer = If(isDoctor, 300, 226)
        btnBack2.Top = btnY
        btnContinue2.Top = btnY
        cardRole.Height = btnY + 34 + 20
    End Sub

    Private Sub SetRoleCard(card As FCard, radio As Panel, selected As Boolean)
        card.BackColor = If(selected, ColSelectedBack, Color.White)
        card.HoverTintColor = card.BackColor
        card.BorderColor = If(selected, ColTeal, ColCardBorder)
        radio.Tag = selected
        radio.BackColor = card.BackColor
        radio.Invalidate()
        card.Invalidate()
    End Sub

    Private Function ValidateStep2() As Boolean
        ResetField(fPrc)
        If selectedRole = "Doctor" AndAlso Not Regex.IsMatch(fPrc.Box.Text.Trim(), "^\d{7}$") Then
            Dim n As Integer = 0
            Fail(fPrc, "Enter the 7-digit PRC license number.", n)
            fPrc.Box.Focus()
            Return False
        End If
        Return True
    End Function

    ' =====================================================================
    '  Step 3: review
    ' =====================================================================
    Private Sub BuildReview()
        Dim u As NewUser = BuildUser()

        Dim acct As New List(Of KeyValuePair(Of String, String)) From {
            Pair("Username", u.Username),
            Pair("Name", u.FullName),
            Pair("Work email", u.Email),
            Pair("Mobile number", u.Mobile),
            Pair("Staff ID", u.StaffId)
        }

        Dim role As New List(Of KeyValuePair(Of String, String)) From {Pair("Role", u.Role)}
        If u.Role = "Doctor" Then
            role.Add(Pair("Specialty", u.Specialty))
            role.Add(Pair("PRC license number", u.PrcLicense))
        Else
            role.Add(Pair("Assigned clinic", u.Clinic))
        End If

        FillRows(pnlReviewAccount, acct)
        FillRows(pnlReviewRole, role)

        lblReviewRoleHdr.Top = pnlReviewAccount.Bottom + 12
        lblEditRole.Top = lblReviewRoleHdr.Top + 1
        pnlReviewRole.Top = lblReviewRoleHdr.Top + 22
        btnBack3.Top = pnlReviewRole.Bottom + 18
        btnCreate.Top = btnBack3.Top
        cardReview.Height = btnBack3.Bottom + 20
    End Sub

    Private Shared Function Pair(k As String, v As String) As KeyValuePair(Of String, String)
        Return New KeyValuePair(Of String, String)(k, v)
    End Function

    Private Sub FillRows(host As Panel, rows As List(Of KeyValuePair(Of String, String)))
        For i As Integer = host.Controls.Count - 1 To 0 Step -1
            Dim c As Control = host.Controls(i)
            host.Controls.RemoveAt(i)
            c.Dispose()
        Next

        For i As Integer = 0 To rows.Count - 1
            ' rows stretch with the review card when the window is resized
            Dim row As New Panel() With {
                .Size = New Size(host.Width, 28),
                .Location = New Point(0, i * 28),
                .BackColor = Color.White,
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
            }
            AddHandler row.Paint, AddressOf ReviewRow_Paint
            AddHandler row.Resize, Sub(s As Object, ev As EventArgs) DirectCast(s, Control).Invalidate()
            row.Controls.Add(New Label() With {.AutoSize = True, .BackColor = Color.Transparent, .Font = FontKey, .ForeColor = ColGrey, .Location = New Point(0, 7), .Text = rows(i).Key})
            row.Controls.Add(New Label() With {.AutoSize = True, .BackColor = Color.Transparent, .Font = FontValue, .ForeColor = Color.FromArgb(22, 51, 65), .Location = New Point(150, 7), .Text = rows(i).Value})
            host.Controls.Add(row)
        Next
        host.Height = rows.Count * 28
    End Sub

    Private Sub ReviewRow_Paint(sender As Object, e As PaintEventArgs)
        Dim p As Control = DirectCast(sender, Control)
        Using pen As New Pen(ColDivider)
            e.Graphics.DrawLine(pen, 0, p.Height - 1, p.Width, p.Height - 1)
        End Using
    End Sub

    Private Function BuildUser() As NewUser
        Dim isDoctor As Boolean = (selectedRole = "Doctor")
        Dim minutes As Integer = 30
        Integer.TryParse(lblLengthValue.Text.Split(" "c)(0), minutes)

        Return New NewUser With {
            .FirstName = fFirst.Box.Text.Trim(),
            .LastName = fLast.Box.Text.Trim(),
            .Username = fUser.Box.Text.Trim(),
            .Password = "",
            .Email = fEmail.Box.Text.Trim().ToLowerInvariant(),
            .Mobile = fMobile.Box.Text.Trim(),
            .StaffId = fStaff.Box.Text.Trim(),
            .StartDate = startDate,
            .Role = selectedRole,
            .Specialty = If(isDoctor, lblSpecialtyValue.Text, ""),
            .PrcLicense = If(isDoctor, fPrc.Box.Text.Trim(), ""),
            .ConsultationMinutes = If(isDoctor, minutes, 0),
            .Clinic = lblClinicValue.Text
        }
    End Function

    ' =====================================================================
    '  Field helpers (focus border, error state)
    ' =====================================================================
    Private Function MakeField(card As FCard, box As TextBox, msg As Label) As FieldRef
        Dim f As New FieldRef() With {.Card = card, .Box = box, .Msg = msg, .Hint = msg.Text}
        AddHandler box.Enter, AddressOf Field_Enter
        AddHandler box.Leave, AddressOf Field_Leave
        AddHandler box.TextChanged, AddressOf Field_TextChanged
        AddHandler card.Click, AddressOf Field_CardClick
        Return f
    End Function

    Private Function FindField(ctl As Object) As FieldRef
        Return allFields.First(Function(f) ReferenceEquals(f.Box, ctl) OrElse ReferenceEquals(f.Card, ctl))
    End Function

    Private Sub ApplyBorder(f As FieldRef)
        f.Card.BorderColor = If(f.HasError, ColErr, If(f.Focused, ColTeal, ColNormalBorder))
        f.Card.BorderHoverColor = If(f.HasError, ColErr, ColTeal)
    End Sub

    Private Sub Field_Enter(sender As Object, e As EventArgs)
        Dim f As FieldRef = FindField(sender)
        f.Focused = True
        ApplyBorder(f)
    End Sub

    Private Sub Field_Leave(sender As Object, e As EventArgs)
        Dim f As FieldRef = FindField(sender)
        f.Focused = False
        ApplyBorder(f)
    End Sub

    Private Sub Field_TextChanged(sender As Object, e As EventArgs)
        Dim f As FieldRef = FindField(sender)
        If f.HasError Then ResetField(f)
    End Sub

    Private Sub Field_CardClick(sender As Object, e As EventArgs)
        FindField(sender).Box.Focus()
    End Sub

    Private Sub Fail(f As FieldRef, message As String, ByRef errors As Integer)
        f.HasError = True
        f.Msg.Text = message
        f.Msg.ForeColor = ColErrText
        ApplyBorder(f)
        errors += 1
    End Sub

    Private Sub ResetField(f As FieldRef)
        f.HasError = False
        f.Msg.Text = f.Hint
        f.Msg.ForeColor = ColHint
        ApplyBorder(f)
    End Sub

    ' =====================================================================
    '  Dropdowns + calendar
    ' =====================================================================
    Private Sub WireDropdown(card As FCard, valueLabel As Label, options() As String)
        Dim menu As New ContextMenuStrip() With {.Font = New Font("Segoe UI", 9.0F), .ShowImageMargin = False, .Tag = valueLabel}
        For Each opt As String In options
            Dim item As ToolStripMenuItem = DirectCast(menu.Items.Add(opt), ToolStripMenuItem)
            item.Tag = opt
            AddHandler item.Click, AddressOf DropItem_Click
        Next
        card.Tag = menu
        AddHandler card.Click, AddressOf Dropdown_Click
        For Each child As Control In card.Controls : AddHandler child.Click, AddressOf Dropdown_Click : Next
    End Sub

    Private Sub Dropdown_Click(sender As Object, e As EventArgs)
        Dim c As Control = DirectCast(sender, Control)
        Dim card As FCard = If(TypeOf c Is FCard, DirectCast(c, FCard), DirectCast(c.Parent, FCard))
        Dim menu As ContextMenuStrip = DirectCast(card.Tag, ContextMenuStrip)
        menu.MinimumSize = New Size(card.Width, 0)
        menu.Show(card, New Point(0, card.Height + 2))
    End Sub

    Private Sub DropItem_Click(sender As Object, e As EventArgs)
        Dim item As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
        Dim target As Label = DirectCast(item.Owner.Tag, Label)
        target.Text = CStr(item.Tag)
    End Sub

    Private Sub StartDate_Click(sender As Object, e As EventArgs)
        If calDrop Is Nothing Then
            cal = New MonthCalendar() With {.MaxSelectionCount = 1, .MinDate = Date.Today}
            AddHandler cal.DateSelected, AddressOf Cal_DateSelected
            calDrop = New ToolStripDropDown() With {.Padding = Padding.Empty}
            calDrop.Items.Add(New ToolStripControlHost(cal) With {.Margin = Padding.Empty, .Padding = Padding.Empty})
        End If
        cal.SetDate(If(startDate < Date.Today, Date.Today, startDate))
        calDrop.Show(cardStartDate, New Point(0, cardStartDate.Height + 2))
    End Sub

    Private Sub Cal_DateSelected(sender As Object, e As DateRangeEventArgs)
        startDate = e.Start.Date
        lblStartDateValue.Text = FormatDate(startDate)
        calDrop.Close()
    End Sub

    Private Shared Function FormatDate(d As Date) As String
        Return d.ToString("MMM d, yyyy", CultureInfo.InvariantCulture)
    End Function

    ' =====================================================================
    '  Custom drawing
    ' =====================================================================
    Private Sub StepCircle_Paint(sender As Object, e As PaintEventArgs)
        Dim p As Panel = DirectCast(sender, Panel)
        Dim idx As Integer = CInt(p.Tag)
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim r As New Rectangle(1, 1, p.Width - 3, p.Height - 3)

        If idx <= currentStep Then
            Using b As New SolidBrush(ColTeal) : g.FillEllipse(b, r) : End Using
            If idx < currentStep Then
                Using pen As New Pen(Color.White, 2.0F) With {.StartCap = LineCap.Round, .EndCap = LineCap.Round, .LineJoin = LineJoin.Round}
                    g.DrawLines(pen, {New PointF(p.Width * 0.3F, p.Height * 0.52F), New PointF(p.Width * 0.44F, p.Height * 0.66F), New PointF(p.Width * 0.72F, p.Height * 0.36F)})
                End Using
            Else
                DrawCentered(g, idx.ToString(), p.ClientRectangle, FontStepNum, Color.White)
            End If
        Else
            Using b As New SolidBrush(Color.White) : g.FillEllipse(b, r) : End Using
            Using pen As New Pen(Color.FromArgb(210, 222, 228)) : g.DrawEllipse(pen, r) : End Using
            DrawCentered(g, idx.ToString(), p.ClientRectangle, FontStepNum, ColGrey)
        End If
    End Sub

    Private Sub Badge_Paint(sender As Object, e As PaintEventArgs)
        Dim p As Panel = DirectCast(sender, Panel)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Using b As New SolidBrush(ColMint) : e.Graphics.FillEllipse(b, 0, 0, p.Width - 1, p.Height - 1) : End Using
        DrawCentered(e.Graphics, CStr(p.Tag), p.ClientRectangle, FontBadge, ColTeal)
    End Sub

    Private Sub Dot_Paint(sender As Object, e As PaintEventArgs)
        Dim p As Panel = DirectCast(sender, Panel)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim filled As Boolean = (p.Tag IsNot Nothing AndAlso CBool(p.Tag))
        If filled Then
            Using b As New SolidBrush(ColTeal) : e.Graphics.FillEllipse(b, 0, 0, p.Width - 1, p.Height - 1) : End Using
        Else
            Using pen As New Pen(Color.FromArgb(190, 200, 208)) : e.Graphics.DrawEllipse(pen, 0, 0, p.Width - 2, p.Height - 2) : End Using
        End If
    End Sub

    Private Sub Radio_Paint(sender As Object, e As PaintEventArgs)
        Dim p As Panel = DirectCast(sender, Panel)
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim selected As Boolean = (p.Tag IsNot Nothing AndAlso CBool(p.Tag))
        Dim r As New Rectangle(1, 1, p.Width - 3, p.Height - 3)
        If selected Then
            Using b As New SolidBrush(ColTeal) : g.FillEllipse(b, 3, 3, p.Width - 7, p.Height - 7) : End Using
        Else
            Using pen As New Pen(Color.FromArgb(200, 210, 216)) : g.DrawEllipse(pen, r) : End Using
        End If
    End Sub

    Private Sub Caret_Paint(sender As Object, e As PaintEventArgs)
        Dim p As Panel = DirectCast(sender, Panel)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Using b As New SolidBrush(Color.FromArgb(115, 135, 145))
            e.Graphics.FillPolygon(b, {New Point(0, 0), New Point(p.Width, 0), New Point(p.Width \ 2, p.Height)})
        End Using
    End Sub

    Private Shared Sub DrawCentered(g As Graphics, text As String, rect As Rectangle, f As Font, c As Color)
        Using sf As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
            Using br As New SolidBrush(c)
                g.DrawString(text, f, br, New RectangleF(rect.X, rect.Y, rect.Width, rect.Height), sf)
            End Using
        End Using
    End Sub

    ' =====================================================================
    '  Sample data (replace with a database query)
    ' =====================================================================
    Private Shared Function SampleUsers() As List(Of ExistingUser)
        Return New List(Of ExistingUser) From {
            New ExistingUser("Dr. Elena Cruz", "Doctor", "elena.cruz@uccclinic.edu.ph", "elena"),
            New ExistingUser("Dr. Paolo Vega", "Doctor", "paolo.vega@uccclinic.edu.ph", "paolo"),
            New ExistingUser("Dr. Lorna Bautista", "Doctor", "lorna.bautista@uccclinic.edu.ph", "lorna"),
            New ExistingUser("Ana Reyes", "Receptionist", "ana.reyes@uccclinic.edu.ph", "ana"),
            New ExistingUser("Mark Tolentino", "Receptionist", "mark.tolentino@uccclinic.edu.ph", "mark"),
            New ExistingUser("Rosa Dela Cruz", "Administrator", "rosa.delacruz@uccclinic.edu.ph", "rosa"),
            New ExistingUser("Joel Ramos", "Receptionist", "joel.ramos@uccclinic.edu.ph", "joel")
        }
    End Function


End Class

''' <summary>An account that already exists (used for duplicate checks).</summary>
Public Class ExistingUser
    Public Property FullName As String
    Public Property Role As String
    Public Property Email As String
    Public Property Username As String

    Public Sub New(fullName As String, role As String, email As String, username As String)
        Me.FullName = fullName
        Me.Role = role
        Me.Email = email
        Me.Username = username
    End Sub
End Class

''' <summary>The account collected by the wizard.</summary>
Public Class NewUser
    Public Property FirstName As String
    Public Property LastName As String
    Public Property Username As String
    Public Property Password As String
    Public Property Email As String
    Public Property Mobile As String
    Public Property StaffId As String
    Public Property StartDate As Date
    Public Property Role As String
    Public Property Specialty As String
    Public Property PrcLicense As String
    Public Property ConsultationMinutes As Integer
    Public Property Clinic As String
    Public Property Status As String = "Invited"
    Public Property InviteCode As String = ""

    Public ReadOnly Property FullName As String
        Get
            Return If(Role = "Doctor", "Dr. ", "") & FirstName & " " & LastName
        End Get
    End Property
End Class