Imports System.Linq
Imports Ferrando.UI.WinForms.Controles

Public Class DoctorAppointment

    Private sidebarHandler As SidebarHandler

    Private Const RowCount As Integer = 5

    Private Class RowUi
        Public TimeLbl As Label
        Public PatientLbl As Label
        Public IdLbl As Label
        Public VisitLbl As Label
        Public Pill As FCard
        Public Dot As Label
        Public StatusLbl As Label
        Public NoShowBtn As FButton
        Public OpenBtn As FButton
        Public ActionLbl As Label
        Public Divider As Panel
    End Class

    Private ReadOnly _rows As New List(Of RowUi)()
    Private ReadOnly _tabs As New List(Of FButton)()
    Private _currentWeekMonday As DateTime
    Private _selectedDate As DateTime
    Private btnPrevWeek As FButton
    Private btnToday As FButton
    Private btnNextWeek As FButton

    ' Search & Pagination
    Private txtSearch As TextBox
    Private _currentPage As Integer = 1
    Private btnPrevPage As FButton
    Private btnNextPage As FButton
    Private lblPageInfo As Label
    Private lblRange As Label

    ' Card layout (the card is stretched to fit the window so it is never clipped)
    Private Const CardRightMargin As Integer = 30
    Private Const CardMinWidth As Integer = 720
    Private Const TabGap As Integer = 10
    Private _tabPad As Integer = -1

    ' Original (unscrolled) position of the card. cardSchedule.Left/Top change while
    ' mainScreen is scrolled, so the layout math uses these captured values instead.
    Private _cardLeft As Integer
    Private _cardTop As Integer

    Private Property _selectedDay As Integer
        Get
            Return _selectedDate.Day
        End Get
        Set(value As Integer)
            SelectDay(value)
        End Set
    End Property

    Private Shared ReadOnly TabFont As New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point)
    Private Shared ReadOnly TabFontActive As New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point)

    Private Sub DoctorAppointment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sidebarHandler = New SidebarHandler(btnDashboard, btnPatients, btnAppointment,
                                            btnDoctor, btnConsultation, btnReports)
        sidebarHandler.SetActive(btnAppointment)

        ' Initialize week dates
        Dim today = DateTime.Today
        Dim diff = (7 + (CInt(today.DayOfWeek) - CInt(DayOfWeek.Monday))) Mod 7
        _currentWeekMonday = today.AddDays(-diff).Date
        _selectedDate = today.Date
        If today.DayOfWeek = DayOfWeek.Saturday OrElse today.DayOfWeek = DayOfWeek.Sunday Then
            _selectedDate = _currentWeekMonday
        End If

        ' Add week navigation buttons next to lblWeek inside cardSchedule
        If btnPrevWeek Is Nothing AndAlso cardSchedule IsNot Nothing Then
            Dim fNav As New Font("Segoe UI", 8.5F, FontStyle.Bold)
            btnPrevWeek = New FButton With {
                .Text = "‹",
                .Size = New Size(26, 24),
                .Location = New Point(If(lblWeek IsNot Nothing, lblWeek.Right + 12, 210), 11),
                .Font = fNav,
                .BorderRadius = 4,
                .BorderSize = 0,
                .Cursor = Cursors.Hand
            }
            UIThemeHelper.ApplySecondary(btnPrevWeek)
            AddHandler btnPrevWeek.Click, Sub() GoToWeek(_currentWeekMonday.AddDays(-7))
            cardSchedule.Controls.Add(btnPrevWeek)

            btnToday = New FButton With {
                .Text = "Today",
                .Size = New Size(48, 24),
                .Location = New Point(btnPrevWeek.Right + 4, 11),
                .Font = New Font("Segoe UI", 7.5F, FontStyle.Bold),
                .BorderRadius = 4,
                .BorderSize = 0,
                .Cursor = Cursors.Hand
            }
            UIThemeHelper.ApplySecondary(btnToday)
            AddHandler btnToday.Click, Sub() GoToDate(DateTime.Today)
            cardSchedule.Controls.Add(btnToday)

            btnNextWeek = New FButton With {
                .Text = "›",
                .Size = New Size(26, 24),
                .Location = New Point(btnToday.Right + 4, 11),
                .Font = fNav,
                .BorderRadius = 4,
                .BorderSize = 0,
                .Cursor = Cursors.Hand
            }
            UIThemeHelper.ApplySecondary(btnNextWeek)
            AddHandler btnNextWeek.Click, Sub() GoToWeek(_currentWeekMonday.AddDays(7))
            cardSchedule.Controls.Add(btnNextWeek)
        End If

        ' Day tabs
        _tabs.Clear()
        For d As Integer = 1 To 5
            Dim tab As FButton = Ctl(Of FButton)("btnDay" & d)
            If tab IsNot Nothing Then
                RemoveHandler tab.Click, AddressOf DayTab_Click
                AddHandler tab.Click, AddressOf DayTab_Click
                _tabs.Add(tab)
            End If
        Next

        ' Table rows.
        _rows.Clear()
        For k As Integer = 1 To RowCount
            Dim r As New RowUi()
            r.TimeLbl = Ctl(Of Label)("lblTime" & k)
            r.PatientLbl = Ctl(Of Label)("lblPatient" & k)
            r.IdLbl = Ctl(Of Label)("lblPatientId" & k)
            r.VisitLbl = Ctl(Of Label)("lblVisit" & k)
            r.Pill = Ctl(Of FCard)("cardStatus" & k)
            r.Dot = Ctl(Of Label)("lblDot" & k)
            r.StatusLbl = Ctl(Of Label)("lblStatus" & k)
            r.NoShowBtn = Ctl(Of FButton)("btnNoShow" & k)
            r.OpenBtn = Ctl(Of FButton)("btnOpen" & k)
            r.ActionLbl = Ctl(Of Label)("lblAction" & k)
            r.Divider = Ctl(Of Panel)("divRow" & k)     ' Nothing for the last row

            If r.NoShowBtn IsNot Nothing Then
                UIThemeHelper.ApplyDanger(r.NoShowBtn)
                RemoveHandler r.NoShowBtn.Click, AddressOf NoShow_Click
                AddHandler r.NoShowBtn.Click, AddressOf NoShow_Click
            End If
            If r.OpenBtn IsNot Nothing Then
                UIThemeHelper.ApplyPrimary(r.OpenBtn)
                RemoveHandler r.OpenBtn.Click, AddressOf OpenConsultation_Click
                AddHandler r.OpenBtn.Click, AddressOf OpenConsultation_Click
            End If
            _rows.Add(r)
        Next

        ' Width is managed by LayoutCard() so the card always fits inside mainScreen
        cardSchedule.Anchor = AnchorStyles.Top Or AnchorStyles.Left

        ' Scrolling: when the window is smaller than the card, scroll instead of clipping
        _cardLeft = cardSchedule.Left
        _cardTop = cardSchedule.Top
        mainScreen.AutoScroll = True

        ' Only force a minimum size when running as a standalone window.
        ' When hosted inside DoctorShell this would push the form wider than the visible area.
        If Me.TopLevel Then Me.MinimumSize = New Size(960, 600)

        Dim currentDoc = If(CurrentUser.IsAuthenticated, CurrentUser.FullName, "Dr. Elena Cruz")
        If CurrentUser.IsAuthenticated Then
            txtName.Text = CurrentUser.FullName
            txtRole.Text = If(CurrentUser.Role = "Doctor", "General Physician", CurrentUser.Role)
        End If

        ' Show Doctor Privacy Badge
        If cardShowing IsNot Nothing Then
            cardShowing.Visible = True
            cardShowing.Location = New Point(310, 26)
            cardShowing.Size = New Size(200, 26)
            lblShowing.Text = "Doctor: " & currentDoc
        End If

        ' Search Box for Doctor Queue
        If txtSearch Is Nothing Then
            txtSearch = New TextBox With {
                .Location = New Point(520, 26),
                .Size = New Size(130, 25),
                .Font = New Font("Segoe UI", 9.0F),
                .ForeColor = Color.FromArgb(22, 51, 65),
                .PlaceholderText = "Search patient...",
                .Anchor = AnchorStyles.Top Or AnchorStyles.Right
            }
            AddHandler txtSearch.TextChanged, Sub()
                                                  _currentPage = 1
                                                  RefreshData()
                                              End Sub
            mainScreen.Controls.Add(txtSearch)
        End If

        ' Status Filter (repurposing cboDoctorFilter)
        If cboDoctorFilter IsNot Nothing Then
            cboDoctorFilter.Location = New Point(660, 26)
            cboDoctorFilter.Size = New Size(140, 25)
            cboDoctorFilter.Anchor = AnchorStyles.Top Or AnchorStyles.Right
            cboDoctorFilter.Items.Clear()
            cboDoctorFilter.Items.AddRange(New Object() {"All Statuses", "Confirmed", "Pending", "Completed", "Cancelled"})
            cboDoctorFilter.SelectedIndex = 0
        End If

        ' Pagination controls inside cardSchedule
        If btnPrevPage Is Nothing AndAlso cardSchedule IsNot Nothing Then
            Dim fNav As New Font("Segoe UI", 8.0F, FontStyle.Bold)
            btnPrevPage = New FButton With {
                .Text = "‹ Prev",
                .Size = New Size(54, 22),
                .Location = New Point(610, 360),
                .Font = fNav,
                .BorderRadius = 4,
                .BorderSize = 0,
                .Cursor = Cursors.Hand,
                .Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
            }
            UIThemeHelper.ApplySecondary(btnPrevPage)
            AddHandler btnPrevPage.Click, Sub()
                                              If _currentPage > 1 Then
                                                  _currentPage -= 1
                                                  ShowDate(_selectedDate)
                                              End If
                                          End Sub
            cardSchedule.Controls.Add(btnPrevPage)

            lblPageInfo = New Label With {
                .Text = "1 / 1",
                .Font = New Font("Segoe UI", 7.5F, FontStyle.Regular),
                .ForeColor = Color.FromArgb(115, 138, 148),
                .Location = New Point(668, 363),
                .AutoSize = True,
                .Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
            }
            cardSchedule.Controls.Add(lblPageInfo)

            btnNextPage = New FButton With {
                .Text = "Next ›",
                .Size = New Size(54, 22),
                .Location = New Point(706, 360),
                .Font = fNav,
                .BorderRadius = 4,
                .BorderSize = 0,
                .Cursor = Cursors.Hand,
                .Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
            }
            UIThemeHelper.ApplySecondary(btnNextPage)
            AddHandler btnNextPage.Click, Sub()
                                              _currentPage += 1
                                              ShowDate(_selectedDate)
                                          End Sub
            cardSchedule.Controls.Add(btnNextPage)

            lblRange = New Label With {
                .Text = "",
                .Font = New Font("Segoe UI", 7.5F, FontStyle.Regular),
                .ForeColor = Color.FromArgb(115, 138, 148),
                .AutoSize = False,
                .Size = New Size(150, 22),
                .TextAlign = ContentAlignment.MiddleRight,
                .Location = New Point(450, 360),
                .Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
            }
            cardSchedule.Controls.Add(lblRange)
        End If

        ' Host cardEmpty directly inside cardSchedule for clean in-table empty state
        If cardEmpty IsNot Nothing AndAlso cardSchedule IsNot Nothing Then
            If cardEmpty.Parent IsNot cardSchedule Then
                mainScreen.Controls.Remove(cardEmpty)
                cardSchedule.Controls.Add(cardEmpty)
            End If
            cardEmpty.Location = New Point(16, 140)
            cardEmpty.Size = New Size(cardSchedule.Width - 32, 100)
            cardEmpty.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
            cardEmpty.BorderSize = 0
            cardEmpty.EnableShadow = False
            cardEmpty.BringToFront()
            lblEmptyTitle.Size = New Size(cardEmpty.Width, 20)
            lblEmptySub.Size = New Size(cardEmpty.Width, 20)
            lblEmptyTitle.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
            lblEmptySub.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        End If

        Dim tt As New ToolTip()
        If btnPrevWeek IsNot Nothing Then tt.SetToolTip(btnPrevWeek, "Previous week")
        If btnToday IsNot Nothing Then tt.SetToolTip(btnToday, "Go to today")
        If btnNextWeek IsNot Nothing Then tt.SetToolTip(btnNextWeek, "Next week")
        If txtSearch IsNot Nothing Then tt.SetToolTip(txtSearch, "Search patient by name or ID")
        If cboDoctorFilter IsNot Nothing Then tt.SetToolTip(cboDoctorFilter, "Filter appointments by status")

        ' Subscribe to reactive updates from Receptionist check-in / booking
        AddHandler ClinicData.DataChanged, AddressOf RefreshData

        LayoutCard()
        UpdateWeekTabs()
        ShowDate(_selectedDate)
    End Sub

    ' ------------------------------------------------------------------ layout

    Private Sub mainScreen_Resize(sender As Object, e As EventArgs) Handles mainScreen.Resize
        LayoutCard()
    End Sub

    Private Sub DoctorAppointment_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        LayoutCard()
    End Sub

    Private Sub DoctorAppointment_ParentChanged(sender As Object, e As EventArgs) Handles MyBase.ParentChanged
        LayoutCard()
    End Sub

    ''' <summary>
    ''' Fits the schedule card inside the visible area (so its right edge is never cut off)
    ''' and spreads the day tabs, row dividers and pager across the new width.
    ''' </summary>
    Private Sub LayoutCard()
        If cardSchedule Is Nothing OrElse mainScreen Is Nothing Then Return

        ' Real visible width = form width, capped by whatever is hosting it
        Dim visibleRight As Integer = Me.ClientSize.Width
        If Me.Parent IsNot Nothing Then visibleRight = Math.Min(visibleRight, Me.Parent.ClientSize.Width)

        ' Don't let mainScreen stick out past the visible area
        If mainScreen.Dock = DockStyle.None AndAlso mainScreen.Right > visibleRight Then
            mainScreen.Width = Math.Max(1, visibleRight - mainScreen.Left)
        End If

        Dim availWidth As Integer = Math.Min(mainScreen.ClientSize.Width, visibleRight - mainScreen.Left)
        Dim w As Integer = Math.Max(CardMinWidth, availWidth - _cardLeft - CardRightMargin)
        cardSchedule.Width = w

        ' Scrollbars appear automatically when the content is bigger than the visible area
        mainScreen.AutoScrollMinSize = New Size(_cardLeft + CardMinWidth + CardRightMargin,
                                                _cardTop + cardSchedule.Height + 24)

        ' Day tabs: equal width across the card
        If _tabs.Count = 5 Then
            If _tabPad < 0 Then _tabPad = Math.Max(8, _tabs(0).Left)
            Dim tw As Integer = (w - (_tabPad * 2) - (TabGap * 4)) \ 5
            For i As Integer = 0 To 4
                _tabs(i).SetBounds(_tabPad + i * (tw + TabGap), _tabs(i).Top, tw, _tabs(i).Height)
            Next
        End If

        ' Row dividers
        For Each r In _rows
            If r.Divider IsNot Nothing Then
                r.Divider.Width = Math.Max(1, w - (r.Divider.Left * 2))
            End If
        Next

        ' Pager (right-aligned inside the card)
        If btnNextPage IsNot Nothing AndAlso btnPrevPage IsNot Nothing AndAlso lblPageInfo IsNot Nothing Then
            btnNextPage.Left = w - 14 - btnNextPage.Width
            btnPrevPage.Left = btnNextPage.Left - 96
            lblPageInfo.Left = btnNextPage.Left - 38
            If lblRange IsNot Nothing Then lblRange.Left = btnPrevPage.Left - lblRange.Width - 8
        End If

        ' Empty-state card
        If cardEmpty IsNot Nothing AndAlso cardEmpty.Parent Is cardSchedule Then
            cardEmpty.Width = Math.Max(1, w - 32)
            If lblEmptyTitle IsNot Nothing Then lblEmptyTitle.Width = cardEmpty.Width
            If lblEmptySub IsNot Nothing Then lblEmptySub.Width = cardEmpty.Width
        End If
    End Sub

    ' ------------------------------------------------------------------ navigation

    Public Sub GoToWeek(mon As DateTime)
        _currentPage = 1
        _currentWeekMonday = mon.Date
        If _selectedDate < _currentWeekMonday OrElse _selectedDate > _currentWeekMonday.AddDays(4) Then
            _selectedDate = _currentWeekMonday
        End If
        UpdateWeekTabs()
        ShowDate(_selectedDate)
    End Sub

    Public Sub GoToDate(targetDate As DateTime)
        Dim diff = (7 + (CInt(targetDate.DayOfWeek) - CInt(DayOfWeek.Monday))) Mod 7
        _currentWeekMonday = targetDate.Date.AddDays(-diff)
        _currentPage = 1
        _selectedDate = targetDate.Date
        UpdateWeekTabs()
        ShowDate(_selectedDate)
    End Sub

    Public Sub SelectDay(dayNum As Integer)
        _currentPage = 1
        For i As Integer = 0 To 4
            Dim d = _currentWeekMonday.AddDays(i)
            If d.Day = dayNum Then
                _selectedDate = d
                UpdateWeekTabs()
                ShowDate(_selectedDate)
                Return
            End If
        Next
        Try
            _selectedDate = New DateTime(_currentWeekMonday.Year, _currentWeekMonday.Month, dayNum)
            Dim diff = (7 + (CInt(_selectedDate.DayOfWeek) - CInt(DayOfWeek.Monday))) Mod 7
            _currentWeekMonday = _selectedDate.AddDays(-diff)
        Catch
        End Try
        UpdateWeekTabs()
        ShowDate(_selectedDate)
    End Sub

    Public Sub ShowDay(day As Integer)
        SelectDay(day)
    End Sub

    Private Sub UpdateWeekTabs()
        If lblWeek IsNot Nothing Then
            lblWeek.Text = $"{_currentWeekMonday:MMMM dd} – {_currentWeekMonday.AddDays(4):dd, yyyy}"
            If btnPrevWeek IsNot Nothing Then
                btnPrevWeek.Location = New Point(lblWeek.Right + 12, 11)
                btnToday.Location = New Point(btnPrevWeek.Right + 4, 11)
                btnNextWeek.Location = New Point(btnToday.Right + 4, 11)
            End If
        End If

        For i As Integer = 0 To _tabs.Count - 1
            Dim d = _currentWeekMonday.AddDays(i)
            Dim tab = _tabs(i)
            tab.Text = d.ToString("ddd dd")
            tab.Tag = d.ToString("yyyy-MM-dd")
            StyleTab(tab, d.Date = _selectedDate.Date)
        Next
    End Sub

    Private Sub cboDoctorFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDoctorFilter.SelectedIndexChanged
        _currentPage = 1
        RefreshData()
    End Sub

    Public Sub RefreshData()
        If _rows.Count > 0 Then
            UpdateWeekTabs()
            ShowDate(_selectedDate)
        End If
    End Sub

    Private Sub DoctorAppointment_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible AndAlso _rows.Count > 0 Then
            LayoutCard()
            RefreshData()
        End If
    End Sub

    Private Function Ctl(Of T As Control)(name As String) As T
        Dim found As Control() = Controls.Find(name, True)
        If found.Length = 0 Then Return Nothing
        Return DirectCast(found(0), T)
    End Function

    ' ------------------------------------------------------------------ day view

    Private Sub ShowDate(d As DateTime)
        _selectedDate = d.Date

        For Each tab As FButton In _tabs
            Dim tabDateStr = TryCast(tab.Tag, String)
            Dim td As DateTime
            If Not String.IsNullOrEmpty(tabDateStr) AndAlso DateTime.TryParse(tabDateStr, td) Then
                StyleTab(tab, td.Date = _selectedDate.Date)
            ElseIf TypeOf tab.Tag Is Integer Then
                StyleTab(tab, CInt(tab.Tag) = _selectedDate.Day)
            End If
        Next

        Dim currentDoc = If(CurrentUser.IsAuthenticated, CurrentUser.FullName, "Dr. Elena Cruz")
        Dim docShort = If(String.IsNullOrEmpty(currentDoc), "", currentDoc.Replace("Dr.", "").Trim())

        ' Doctors strictly see only their own appointments (admin holds the cross-doctor view)
        Dim query = ClinicData.Appointments.Where(Function(a) a.MatchesDate(_selectedDate) AndAlso
            Not String.IsNullOrWhiteSpace(a.DoctorName) AndAlso
            (a.DoctorName.Equals(currentDoc, StringComparison.OrdinalIgnoreCase) OrElse
             (Not String.IsNullOrEmpty(docShort) AndAlso a.DoctorName.IndexOf(docShort, StringComparison.OrdinalIgnoreCase) >= 0) OrElse
             (currentDoc.IndexOf("Cruz", StringComparison.OrdinalIgnoreCase) >= 0 AndAlso a.DoctorName.IndexOf("Cruz", StringComparison.OrdinalIgnoreCase) >= 0) OrElse
             (currentDoc.IndexOf("Lim", StringComparison.OrdinalIgnoreCase) >= 0 AndAlso a.DoctorName.IndexOf("Lim", StringComparison.OrdinalIgnoreCase) >= 0)))

        ' Filter by status
        If cboDoctorFilter IsNot Nothing AndAlso cboDoctorFilter.SelectedIndex > 0 Then
            Dim selStatus = cboDoctorFilter.SelectedItem.ToString()
            query = query.Where(Function(a) a.Status.Equals(selStatus, StringComparison.OrdinalIgnoreCase))
        End If

        ' Filter by search term
        If txtSearch IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
            Dim term = txtSearch.Text.Trim()
            query = query.Where(Function(a) (a.PatientName IsNot Nothing AndAlso a.PatientName.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0) OrElse
                                            (a.PatientId IsNot Nothing AndAlso a.PatientId.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0))
        End If

        Dim allItems As List(Of AppointmentItem) = query.OrderBy(Function(a) a.Minutes).ToList()
        Dim totalItems As Integer = allItems.Count
        Dim totalPages As Integer = Math.Max(1, CInt(Math.Ceiling(totalItems / CDbl(RowCount))))
        If _currentPage > totalPages Then _currentPage = totalPages
        If _currentPage < 1 Then _currentPage = 1

        Dim items = allItems.Skip((_currentPage - 1) * RowCount).Take(RowCount).ToList()

        For i As Integer = 0 To RowCount - 1
            If i < items.Count Then
                BindRow(_rows(i), items(i), i < items.Count - 1)
            Else
                HideRow(_rows(i))
            End If
        Next

        cardEmpty.Visible = (totalItems = 0)

        If lblPageInfo IsNot Nothing Then
            lblPageInfo.Text = $"{_currentPage} / {totalPages}"
            btnPrevPage.Enabled = (_currentPage > 1)
            btnNextPage.Enabled = (_currentPage < totalPages)
            ' Pager is always visible; Prev/Next are simply disabled when there is nowhere to go
            btnPrevPage.Visible = True
            btnNextPage.Visible = True
            lblPageInfo.Visible = True

            If lblRange IsNot Nothing Then
                Dim firstShown As Integer = If(totalItems = 0, 0, (_currentPage - 1) * RowCount + 1)
                Dim lastShown As Integer = If(totalItems = 0, 0, firstShown + items.Count - 1)
                lblRange.Text = $"Showing {firstShown}–{lastShown} of {totalItems}"
                lblRange.Visible = True
            End If
        End If
    End Sub

    Private Sub HideRow(r As RowUi)
        For Each c As Control In New Control() {r.TimeLbl, r.PatientLbl, r.IdLbl, r.VisitLbl, r.Pill,
                                                 r.NoShowBtn, r.OpenBtn, r.ActionLbl}
            If c IsNot Nothing Then c.Visible = False
        Next
        If r.Divider IsNot Nothing Then r.Divider.Visible = False
    End Sub

    Private Sub BindRow(r As RowUi, a As AppointmentItem, showDivider As Boolean)
        r.TimeLbl.Text = ClinicData.FormatTime(a.Minutes)
        r.PatientLbl.Text = a.PatientName
        r.IdLbl.Text = a.PatientId
        r.IdLbl.ForeColor = Color.FromArgb(95, 115, 125)
        r.VisitLbl.Text = a.VisitType

        For Each c As Control In New Control() {r.TimeLbl, r.PatientLbl, r.IdLbl, r.VisitLbl, r.Pill}
            If c IsNot Nothing Then c.Visible = True
        Next

        ApplyStatus(r, a.Status)

        r.NoShowBtn.Tag = a
        r.OpenBtn.Tag = a
        r.NoShowBtn.Visible = (a.Status = "Confirmed")
        r.OpenBtn.Visible = (a.Status = "Pending")
        r.ActionLbl.Visible = (a.Status = "Completed" OrElse a.Status = "Cancelled")
        r.ActionLbl.ForeColor = Color.FromArgb(95, 115, 125)

        If a.Status = "Completed" Then
            r.ActionLbl.Text = "No action needed"
        ElseIf a.Status = "Cancelled" Then
            r.ActionLbl.Text = If(String.IsNullOrEmpty(a.Note), "Cancelled by front desk", a.Note)
        End If

        If r.Divider IsNot Nothing Then r.Divider.Visible = showDivider
    End Sub

    Private Sub ApplyStatus(r As RowUi, status As String)
        Dim bg, fg, dot As Color
        Dim w As Integer

        Select Case status
            Case "Pending"
                bg = ClinicData.Hx("#FEF3E2") : fg = ClinicData.Hx("#D97706") : dot = fg : w = 70
            Case "Completed"
                bg = ClinicData.Hx("#E6F5EB") : fg = ClinicData.Hx("#28874B") : dot = fg : w = 80
            Case "Cancelled"
                bg = ClinicData.Hx("#FDECEC") : fg = ClinicData.Hx("#CD504B") : dot = fg : w = 76
            Case Else   ' Confirmed
                bg = ClinicData.Hx("#EEF2F4") : fg = ClinicData.Hx("#4B5F69") : dot = ClinicData.Hx("#738A94") : w = 78
        End Select

        r.Pill.BackColor = bg
        r.Pill.BorderColor = bg
        r.Pill.BorderHoverColor = bg
        r.Pill.HoverTintColor = bg
        r.Pill.Width = w

        r.Dot.BackColor = bg
        r.Dot.ForeColor = dot
        r.StatusLbl.BackColor = bg
        r.StatusLbl.ForeColor = fg
        r.StatusLbl.Text = status

        r.Pill.Invalidate()
    End Sub

    Private Shared Sub StyleTab(tab As FButton, active As Boolean)
        Dim back As Color = If(active, ClinicData.Hx("#238978"), ClinicData.Hx("#F3F6F8"))
        Dim fore As Color = If(active, ClinicData.Hx("#FFFEFF"), ClinicData.Hx("#4B5F69"))
        Dim fnt As Font = If(active, TabFontActive, TabFont)

        tab.BackColor = back
        tab.ForeColor = fore
        tab.Font = fnt

        tab.MouseEnterBackColor = If(active, ClinicData.Hx("#1D7C6B"), ClinicData.Hx("#E6EEF1"))
        tab.MouseEnterForeColor = If(active, fore, ClinicData.Hx("#238978"))
        tab.MouseEnterFont = fnt

        tab.MouseLeaveBackColor = back
        tab.MouseLeaveForeColor = fore
        tab.MouseLeaveFont = fnt
    End Sub

    ' ------------------------------------------------------------------ events

    Private Sub DayTab_Click(sender As Object, e As EventArgs)
        _currentPage = 1
        Dim btn = DirectCast(sender, FButton)
        Dim dateStr = TryCast(btn.Tag, String)
        Dim d As DateTime
        If Not String.IsNullOrEmpty(dateStr) AndAlso DateTime.TryParse(dateStr, d) Then
            _selectedDate = d.Date
            UpdateWeekTabs()
            ShowDate(_selectedDate)
        ElseIf TypeOf btn.Tag Is Integer Then
            SelectDay(CInt(btn.Tag))
        End If
    End Sub

    Private Sub NoShow_Click(sender As Object, e As EventArgs)
        Dim a As AppointmentItem = TryCast(DirectCast(sender, Control).Tag, AppointmentItem)
        If a Is Nothing Then Return

        Dim answer As DialogResult = MessageBox.Show(
            "Mark " & a.PatientName & " (" & ClinicData.FormatTime(a.Minutes) & ") as a no-show?",
            "Mark no-show", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer <> DialogResult.Yes Then Return

        a.Status = "Cancelled"
        a.Note = "Marked as no-show"
        ClinicData.UpdateAppointment(a)
        RefreshData()
    End Sub

    Private Sub OpenConsultation_Click(sender As Object, e As EventArgs)
        Dim a As AppointmentItem = TryCast(DirectCast(sender, Control).Tag, AppointmentItem)
        If a Is Nothing Then Return

        If DoctorShell.Current IsNot Nothing Then
            DoctorShell.Current.OpenConsultation(a)
        Else
            Dim consultForm As New DoctorConsultation(a)
            consultForm.Show()
            Me.Hide()
        End If
    End Sub

    ' ------------------------------------------------------------------ sidebar navigation

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        If DoctorShell.Current IsNot Nothing Then
            DoctorShell.Current.NavigateTo(DoctorTab.Dashboard)
        Else
            Dim f As New DoctorDashboard()
            f.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub btnPatients_Click(sender As Object, e As EventArgs) Handles btnPatients.Click
        If DoctorShell.Current IsNot Nothing Then
            DoctorShell.Current.NavigateTo(DoctorTab.Patients)
        Else
            Dim f As New DoctorPatients()
            f.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub btnAppointment_Click(sender As Object, e As EventArgs) Handles btnAppointment.Click
        If DoctorShell.Current IsNot Nothing Then DoctorShell.Current.NavigateTo(DoctorTab.Appointments)
    End Sub

    Private Sub btnDoctor_Click(sender As Object, e As EventArgs) Handles btnDoctor.Click
        If DoctorShell.Current IsNot Nothing Then
            DoctorShell.Current.NavigateTo(DoctorTab.Schedule)
        Else
            Dim f As New DoctorSchedule()
            f.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub btnConsultation_Click(sender As Object, e As EventArgs) Handles btnConsultation.Click
        If DoctorShell.Current IsNot Nothing Then
            DoctorShell.Current.NavigateTo(DoctorTab.Consultation)
        Else
            Dim f As New DoctorConsultation()
            f.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        If DoctorShell.Current IsNot Nothing Then
            DoctorShell.Current.NavigateTo(DoctorTab.Reports)
        Else
            Dim f As New DoctorReports()
            f.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub DoctorAppointment_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If DoctorShell.Current Is Nothing AndAlso Me.Parent Is Nothing Then
            Application.Exit()
        End If
    End Sub

End Class

' Compatibility alias
Public Class Appointment
    Inherits DoctorAppointment
End Class