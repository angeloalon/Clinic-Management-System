Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.Linq
Imports Ferrando.UI.WinForms.Controles

''' <summary>
''' Receptionist Appointment Center.
''' Manages clinic-wide appointments across multiple doctors with doctor filtering,
''' day tabs, search, pagination, patient details navigation, and check-in / no-show status handling.
''' </summary>
Public Class ReceptionistAppointment

    ' ---------- Events ----------
    Public Event PatientSelected(patientId As String)
    Public Event BookAppointmentRequested()

    ' ---------- Styling Palette ----------
    Private Shared ReadOnly ClrPageBg As Color = ColorTranslator.FromHtml("#F4F7F9")
    Private Shared ReadOnly ClrTitle As Color = ColorTranslator.FromHtml("#16303F")
    Private Shared ReadOnly ClrSubtitle As Color = ColorTranslator.FromHtml("#738A94")
    Private Shared ReadOnly ClrMuted As Color = ColorTranslator.FromHtml("#8C9BA5")
    Private Shared ReadOnly ClrTeal As Color = ColorTranslator.FromHtml("#238978")
    Private Shared ReadOnly ClrTealDark As Color = ColorTranslator.FromHtml("#1D7C6B")
    Private Shared ReadOnly ClrBorder As Color = ColorTranslator.FromHtml("#DCE4E8")
    Private Shared ReadOnly ClrDivider As Color = ColorTranslator.FromHtml("#F0F4F6")
    Private Shared ReadOnly ClrRowHover As Color = ColorTranslator.FromHtml("#F8FAFC")

    ' Status colors
    Private Shared ReadOnly BgPending As Color = ColorTranslator.FromHtml("#FEF3E2")
    Private Shared ReadOnly FgPending As Color = ColorTranslator.FromHtml("#D97706")
    Private Shared ReadOnly BgConfirmed As Color = ColorTranslator.FromHtml("#E6F5EB")
    Private Shared ReadOnly FgConfirmed As Color = ColorTranslator.FromHtml("#28874B")
    Private Shared ReadOnly BgCompleted As Color = ColorTranslator.FromHtml("#E6F5EB")
    Private Shared ReadOnly FgCompleted As Color = ColorTranslator.FromHtml("#28874B")
    Private Shared ReadOnly BgCancelled As Color = ColorTranslator.FromHtml("#FDECEC")
    Private Shared ReadOnly FgCancelled As Color = ColorTranslator.FromHtml("#CD504B")

    ' Fonts
    Private Const FontName As String = "Segoe UI"
    Private Shared ReadOnly FTitle As New Font(FontName, 18.0F, FontStyle.Regular)
    Private Shared ReadOnly FSub As New Font(FontName, 9.0F, FontStyle.Regular)
    Private Shared ReadOnly FCardTitle As New Font(FontName, 7.5F, FontStyle.Bold)
    Private Shared ReadOnly FCardValue As New Font(FontName, 18.0F, FontStyle.Bold)
    Private Shared ReadOnly FCardSub As New Font(FontName, 8.0F, FontStyle.Regular)
    Private Shared ReadOnly FHeader As New Font(FontName, 7.5F, FontStyle.Bold)
    Private Shared ReadOnly FCell As New Font(FontName, 8.5F, FontStyle.Regular)
    Private Shared ReadOnly FCellBold As New Font(FontName, 9.0F, FontStyle.Bold)
    Private Shared ReadOnly FCellSmall As New Font(FontName, 8.0F, FontStyle.Regular)
    Private Shared ReadOnly FAction As New Font(FontName, 8.0F, FontStyle.Bold)

    ' Layout constants
    Private Const TableTop As Integer = 248
    Private Const RowHeight As Integer = 48
    Private Const SearchPlaceholder As String = "Search patient, doctor..."

    ' State
    Private _currentWeekMonday As DateTime
    Private _selectedDate As DateTime
    Private _selectedDoctor As String = "All"
    Private _selectedStatus As String = "All"
    Private _searchQuery As String = ""
    Private _isPlaceholderActive As Boolean = True

    ' Pagination state
    Private _currentPage As Integer = 1
    Private _pageSize As Integer = 10
    Private _lastFilterKey As String = ""

    ''' <summary>Panel that can take focus so the mouse wheel scrolls it.</summary>
    Private Class ScrollPanel
        Inherits Panel
        Public Sub New()
            SetStyle(ControlStyles.Selectable, True)
            SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            TabStop = False
        End Sub
    End Class

    Private Property _selectedDay As Integer
        Get
            Return _selectedDate.Day
        End Get
        Set(value As Integer)
            SelectDay(value)
        End Set
    End Property

    ' UI Controls
    Private lblTitle As Label
    Private lblSubtitle As Label

    ' Week Navigation controls
    Private btnPrevWeek As FButton
    Private btnToday As FButton
    Private btnNextWeek As FButton
    Private lblWeekRange As Label

    ' KPI cards
    Private cardKpiTotal As FCard
    Private lblKpiTotalVal As Label
    Private lblKpiTotalSub As Label

    Private cardKpiConfirmed As FCard
    Private lblKpiConfirmedVal As Label
    Private lblKpiConfirmedSub As Label

    Private cardKpiPending As FCard
    Private lblKpiPendingVal As Label
    Private lblKpiPendingSub As Label

    Private cardKpiCompleted As FCard
    Private lblKpiCompletedVal As Label
    Private lblKpiCompletedSub As Label

    ' Day tabs
    Private dayButtons As New List(Of FButton)

    ' Filters & Search
    Private btnDoctorFilter As FButton
    Private btnStatusFilter As FButton
    Private cmsDoctorFilter As ContextMenuStrip
    Private cmsStatusFilter As ContextMenuStrip

    Private cardSearch As FCard
    Private lblSearchIcon As Label
    Private txtSearch As TextBox

    ' Schedule Table
    Private cardTable As FCard
    Private pnlRows As ScrollPanel
    Private lblEmpty As Label

    ' Pager
    Private pnlPager As Panel
    Private lblPageInfo As Label
    Private lblPageNum As Label
    Private btnPrevPage As FButton
    Private btnNextPage As FButton
    Private btnPageSize As FButton
    Private cmsPageSize As ContextMenuStrip

    ' Appointment Store (Shared Multi-Doctor Repository)
    Private Shared ReadOnly Property _appointments As List(Of AppointmentItem)
        Get
            Return ClinicData.Appointments
        End Get
    End Property

    Public Sub New()
        InitializeComponent()
        DoubleBuffered = True
        InitWeekDate()
        EnsureAppointmentsLoaded()
        BuildUi()
        RefreshData()
    End Sub

    ' =========================================================================
    '  Public API & Week Navigation
    ' =========================================================================

    Private Sub InitWeekDate()
        Dim today = DateTime.Today
        Dim diff = (7 + (CInt(today.DayOfWeek) - CInt(DayOfWeek.Monday))) Mod 7
        _currentWeekMonday = today.AddDays(-diff).Date
        _selectedDate = today.Date
        If today.DayOfWeek = DayOfWeek.Saturday OrElse today.DayOfWeek = DayOfWeek.Sunday Then
            _selectedDate = _currentWeekMonday
        End If
    End Sub

    Public Sub GoToWeek(mon As DateTime)
        _currentWeekMonday = mon.Date
        If _selectedDate < _currentWeekMonday OrElse _selectedDate > _currentWeekMonday.AddDays(4) Then
            _selectedDate = _currentWeekMonday
        End If
        UpdateWeekControls()
        RefreshData()
    End Sub

    Public Sub GoToDate(targetDate As DateTime)
        Dim diff = (7 + (CInt(targetDate.DayOfWeek) - CInt(DayOfWeek.Monday))) Mod 7
        _currentWeekMonday = targetDate.Date.AddDays(-diff)
        _selectedDate = targetDate.Date
        UpdateWeekControls()
        RefreshData()
    End Sub

    Public Sub RefreshData()
        UpdateKpis()
        RenderRows()
    End Sub

    Public Sub FocusPatient(patientId As String)
        _searchQuery = patientId.ToLower()
        If txtSearch IsNot Nothing Then
            txtSearch.Text = patientId
            _isPlaceholderActive = False
            txtSearch.ForeColor = Color.FromArgb(30, 45, 55)
        End If
        RefreshData()
    End Sub

    Public Sub SelectDay(day As Integer)
        For i As Integer = 0 To 4
            Dim d = _currentWeekMonday.AddDays(i)
            If d.Day = day Then
                _selectedDate = d
                UpdateWeekControls()
                RefreshData()
                Return
            End If
        Next
        Try
            _selectedDate = New DateTime(_currentWeekMonday.Year, _currentWeekMonday.Month, day)
            Dim diff = (7 + (CInt(_selectedDate.DayOfWeek) - CInt(DayOfWeek.Monday))) Mod 7
            _currentWeekMonday = _selectedDate.AddDays(-diff)
        Catch
        End Try
        UpdateWeekControls()
        RefreshData()
    End Sub

    Private Sub DayButton_Click(sender As Object, e As EventArgs)
        Dim btn = DirectCast(sender, FButton)
        Dim dateStr = TryCast(btn.Tag, String)
        Dim d As DateTime
        If Not String.IsNullOrEmpty(dateStr) AndAlso DateTime.TryParse(dateStr, d) Then
            _selectedDate = d.Date
            UpdateWeekControls()
            RefreshData()
        End If
    End Sub

    Private Sub UpdateWeekControls()
        If lblWeekRange IsNot Nothing Then
            Dim fri = _currentWeekMonday.AddDays(4)
            lblWeekRange.Text = $"{_currentWeekMonday:MMM dd} – {fri:MMM dd, yyyy}"
        End If

        For i As Integer = 0 To dayButtons.Count - 1
            Dim d = _currentWeekMonday.AddDays(i)
            Dim btn = dayButtons(i)
            btn.Text = d.ToString("ddd dd")
            btn.Tag = d.ToString("yyyy-MM-dd")
            StyleDayTab(btn, d.Date = _selectedDate.Date)
        Next
    End Sub

    ' =========================================================================
    '  UI Construction
    ' =========================================================================

    Private Sub BuildUi()
        pnlContainer.SuspendLayout()
        pnlContainer.Controls.Clear()

        ' 1. Header
        lblTitle = New Label With {
            .Text = "Appointments",
            .Font = FTitle,
            .ForeColor = ClrTitle,
            .Location = New Point(26, 18),
            .AutoSize = True
        }
        pnlContainer.Controls.Add(lblTitle)

        lblSubtitle = New Label With {
            .Text = "All clinic appointments across all doctors • UCC Health Clinic",
            .Font = FSub,
            .ForeColor = ClrSubtitle,
            .Location = New Point(28, 54),
            .AutoSize = True
        }
        pnlContainer.Controls.Add(lblSubtitle)

        ' Book Appointment Button
        Dim fBook As New Font(FontName, 8.5F, FontStyle.Bold)
        Dim btnBookAppt As New FButton With {
            .Text = "+ Book Appointment",
            .Size = New Size(150, 32),
            .Location = New Point(652, 18),
            .Font = fBook,
            .MouseEnterFont = fBook,
            .MouseLeaveFont = fBook,
            .TextAlign = ContentAlignment.MiddleCenter
        }
        UIThemeHelper.ApplyPrimary(btnBookAppt)
        btnBookAppt.Text = "+ Book Appointment"
        btnBookAppt.Font = fBook
        btnBookAppt.MouseEnterFont = fBook
        btnBookAppt.MouseLeaveFont = fBook
        btnBookAppt.TextAlign = ContentAlignment.MiddleCenter
        AddHandler btnBookAppt.Click, Sub()
                                          Using dlg As New ReceptionistBookAppointmentDialog(_selectedDate)
                                              If dlg.ShowDialog() = DialogResult.OK Then
                                                  If dlg.BookedDate.HasValue Then
                                                      GoToDate(dlg.BookedDate.Value)
                                                  Else
                                                      RefreshData()
                                                  End If
                                              End If
                                          End Using
                                      End Sub
        pnlContainer.Controls.Add(btnBookAppt)

        ' 2. KPI Cards
        Dim kpiY As Integer = 78
        Dim kpiW As Integer = 182
        Dim kpiH As Integer = 88
        Dim kpiGap As Integer = 16

        cardKpiTotal = CreateKpiCard("TOTAL TODAY", "0", "0 remaining", 26, kpiY, kpiW, kpiH, lblKpiTotalVal, lblKpiTotalSub)
        cardKpiConfirmed = CreateKpiCard("CONFIRMED", "0", "Ready to be seen", 26 + (kpiW + kpiGap), kpiY, kpiW, kpiH, lblKpiConfirmedVal, lblKpiConfirmedSub)
        cardKpiPending = CreateKpiCard("PENDING CHECK-IN", "0", "Awaiting patient", 26 + (kpiW + kpiGap) * 2, kpiY, kpiW, kpiH, lblKpiPendingVal, lblKpiPendingSub)
        cardKpiCompleted = CreateKpiCard("COMPLETED", "0", "Consultations done", 26 + (kpiW + kpiGap) * 3, kpiY, kpiW, kpiH, lblKpiCompletedVal, lblKpiCompletedSub)

        pnlContainer.Controls.AddRange(New Control() {cardKpiTotal, cardKpiConfirmed, cardKpiPending, cardKpiCompleted})

        ' 3. Week Navigation Bar
        Dim navY As Integer = 176
        Dim fNavBtn As New Font(FontName, 9.0F, FontStyle.Bold)

        btnPrevWeek = New FButton With {
            .Text = "‹",
            .Size = New Size(28, 26),
            .Location = New Point(26, navY),
            .Font = fNavBtn,
            .BorderRadius = 4,
            .BorderSize = 0,
            .Cursor = Cursors.Hand
        }
        UIThemeHelper.ApplySecondary(btnPrevWeek)
        AddHandler btnPrevWeek.Click, Sub() GoToWeek(_currentWeekMonday.AddDays(-7))
        pnlContainer.Controls.Add(btnPrevWeek)

        btnToday = New FButton With {
            .Text = "Today",
            .Size = New Size(54, 26),
            .Location = New Point(58, navY),
            .Font = New Font(FontName, 8.0F, FontStyle.Bold),
            .BorderRadius = 4,
            .BorderSize = 0,
            .Cursor = Cursors.Hand
        }
        UIThemeHelper.ApplySecondary(btnToday)
        AddHandler btnToday.Click, Sub() GoToDate(DateTime.Today)
        pnlContainer.Controls.Add(btnToday)

        btnNextWeek = New FButton With {
            .Text = "›",
            .Size = New Size(28, 26),
            .Location = New Point(116, navY),
            .Font = fNavBtn,
            .BorderRadius = 4,
            .BorderSize = 0,
            .Cursor = Cursors.Hand
        }
        UIThemeHelper.ApplySecondary(btnNextWeek)
        AddHandler btnNextWeek.Click, Sub() GoToWeek(_currentWeekMonday.AddDays(7))
        pnlContainer.Controls.Add(btnNextWeek)

        lblWeekRange = New Label With {
            .Location = New Point(152, navY + 4),
            .Font = New Font(FontName, 9.5F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(22, 51, 65),
            .AutoSize = True
        }
        pnlContainer.Controls.Add(lblWeekRange)

        ' Filter Bar (Dynamic Day Tabs + Doctor filter + Status filter + Search)
        Dim filterY As Integer = 208
        Dim dayX As Integer = 26
        dayButtons.Clear()

        For i As Integer = 0 To 4
            Dim btn As New FButton With {
                .Size = New Size(66, 30),
                .Location = New Point(dayX, filterY),
                .BorderRadius = 6,
                .BorderSize = 0,
                .Cursor = Cursors.Hand
            }
            AddHandler btn.Click, AddressOf DayButton_Click
            dayButtons.Add(btn)
            pnlContainer.Controls.Add(btn)
            dayX += 70
        Next

        UpdateWeekControls()

        ' Doctor filter dropdown button
        Dim fFilter As New Font(FontName, 8.5F, FontStyle.Bold)
        btnDoctorFilter = New FButton With {
            .Text = "All Doctors  ▾",
            .Size = New Size(108, 30),
            .Location = New Point(380, filterY),
            .BackColor = Color.White,
            .BorderColor = ClrBorder,
            .BorderSize = 1,
            .BorderRadius = 6,
            .Font = fFilter,
            .MouseEnterFont = fFilter,
            .MouseLeaveFont = fFilter,
            .ForeColor = Color.FromArgb(45, 60, 70),
            .Cursor = Cursors.Hand
        }
        btnDoctorFilter.MouseEnterBackColor = Color.FromArgb(246, 249, 251)
        btnDoctorFilter.MouseLeaveBackColor = Color.White
        btnDoctorFilter.MouseEnterForeColor = Color.FromArgb(45, 60, 70)
        btnDoctorFilter.MouseLeaveForeColor = Color.FromArgb(45, 60, 70)
        AddHandler btnDoctorFilter.Click, AddressOf BtnDoctorFilter_Click
        pnlContainer.Controls.Add(btnDoctorFilter)
        InitDoctorMenu()

        ' Status filter dropdown button
        btnStatusFilter = New FButton With {
            .Text = "All Statuses  ▾",
            .Size = New Size(102, 30),
            .Location = New Point(494, filterY),
            .BackColor = Color.White,
            .BorderColor = ClrBorder,
            .BorderSize = 1,
            .BorderRadius = 6,
            .Font = fFilter,
            .MouseEnterFont = fFilter,
            .MouseLeaveFont = fFilter,
            .ForeColor = Color.FromArgb(45, 60, 70),
            .Cursor = Cursors.Hand
        }
        btnStatusFilter.MouseEnterBackColor = Color.FromArgb(246, 249, 251)
        btnStatusFilter.MouseLeaveBackColor = Color.White
        btnStatusFilter.MouseEnterForeColor = Color.FromArgb(45, 60, 70)
        btnStatusFilter.MouseLeaveForeColor = Color.FromArgb(45, 60, 70)
        AddHandler btnStatusFilter.Click, AddressOf BtnStatusFilter_Click
        pnlContainer.Controls.Add(btnStatusFilter)
        InitStatusMenu()

        ' Search Box
        cardSearch = New FCard With {
            .Location = New Point(602, filterY),
            .Size = New Size(200, 30),
            .BackColor = Color.White,
            .BorderColor = ClrBorder,
            .BorderRadius = 6,
            .BorderSize = 1,
            .EnableShadow = False,
            .Padding = New Padding(6, 4, 6, 4)
        }
        lblSearchIcon = New Label With {
            .Text = ChrW(&H26B2).ToString(),
            .Font = New Font(FontName, 9.0F),
            .ForeColor = ClrMuted,
            .Location = New Point(6, 7),
            .Size = New Size(16, 16)
        }
        txtSearch = New TextBox With {
            .BorderStyle = BorderStyle.None,
            .Font = New Font(FontName, 8.5F),
            .ForeColor = ClrMuted,
            .Text = SearchPlaceholder,
            .Location = New Point(26, 7),
            .Width = 166
        }
        AddHandler txtSearch.GotFocus, AddressOf TxtSearch_GotFocus
        AddHandler txtSearch.LostFocus, AddressOf TxtSearch_LostFocus
        AddHandler txtSearch.TextChanged, AddressOf TxtSearch_TextChanged
        cardSearch.Controls.AddRange(New Control() {lblSearchIcon, txtSearch})
        pnlContainer.Controls.Add(cardSearch)

        ' 4. Schedule Table Card
        cardTable = New FCard With {
            .Location = New Point(26, TableTop),
            .Size = New Size(776, 430),
            .BackColor = Color.White,
            .BorderColor = Color.FromArgb(232, 237, 240),
            .BorderHoverColor = Color.FromArgb(232, 237, 240),
            .HoverTintColor = Color.White,
            .BorderRadius = 10,
            .BorderSize = 1,
            .EnableShadow = True,
            .ShadowDepth = 3
        }

        ' Table header columns
        Dim colY As Integer = 12
        cardTable.Controls.Add(CreateHeaderLabel("TIME", 14, colY))
        cardTable.Controls.Add(CreateHeaderLabel("PATIENT", 66, colY))
        cardTable.Controls.Add(CreateHeaderLabel("DOCTOR", 175, colY))
        cardTable.Controls.Add(CreateHeaderLabel("VISIT TYPE", 330, colY))
        cardTable.Controls.Add(CreateHeaderLabel("STATUS", 414, colY))
        cardTable.Controls.Add(CreateHeaderLabel("ACTIONS", 502, colY))

        Dim divHeader As New Panel With {
            .Location = New Point(14, 32),
            .Size = New Size(748, 1),
            .BackColor = ClrDivider
        }
        cardTable.Controls.Add(divHeader)

        ' Rows container (scrollable)
        pnlRows = New ScrollPanel With {
            .Location = New Point(14, 34),
            .Size = New Size(748, 336),
            .AutoScroll = True,
            .BackColor = Color.White
        }
        cardTable.Controls.Add(pnlRows)

        lblEmpty = New Label With {
            .Text = "No appointments match your filters.",
            .Font = New Font(FontName, 9.5F, FontStyle.Regular),
            .ForeColor = ClrMuted,
            .Location = New Point(20, 60),
            .Size = New Size(736, 30),
            .TextAlign = ContentAlignment.MiddleCenter,
            .Visible = False
        }
        cardTable.Controls.Add(lblEmpty)

        BuildPager()

        pnlContainer.Controls.Add(cardTable)
        pnlContainer.ResumeLayout(True)
    End Sub

    Private Function CreateKpiCard(title As String, val As String, subText As String,
                                   x As Integer, y As Integer, w As Integer, h As Integer,
                                   ByRef outVal As Label, ByRef outSub As Label) As FCard
        Dim card As New FCard With {
            .Location = New Point(x, y),
            .Size = New Size(w, h),
            .BackColor = Color.White,
            .BorderColor = Color.FromArgb(232, 237, 240),
            .BorderHoverColor = Color.FromArgb(232, 237, 240),
            .HoverTintColor = Color.White,
            .BorderRadius = 8,
            .BorderSize = 1,
            .EnableShadow = True,
            .ShadowDepth = 2
        }

        Dim lblT As New Label With {
            .Text = title,
            .Font = FCardTitle,
            .ForeColor = ClrMuted,
            .BackColor = Color.Transparent,
            .Location = New Point(14, 10),
            .AutoSize = True
        }
        outVal = New Label With {
            .Text = val,
            .Font = FCardValue,
            .ForeColor = ClrTitle,
            .BackColor = Color.Transparent,
            .Location = New Point(12, 26),
            .AutoSize = True
        }
        outSub = New Label With {
            .Text = subText,
            .Font = FCardSub,
            .ForeColor = ClrSubtitle,
            .BackColor = Color.Transparent,
            .Location = New Point(14, 62),
            .AutoSize = True
        }
        card.Controls.AddRange(New Control() {lblT, outVal, outSub})
        Return card
    End Function

    Private Function CreateHeaderLabel(text As String, x As Integer, y As Integer) As Label
        Return New Label With {
            .Text = text,
            .Font = FHeader,
            .ForeColor = ClrSubtitle,
            .Location = New Point(x, y),
            .AutoSize = True,
            .BackColor = Color.Transparent
        }
    End Function

    Private Sub StyleDayTab(btn As FButton, active As Boolean)
        Dim back = If(active, ClrTeal, Color.FromArgb(243, 246, 248))
        Dim fore = If(active, Color.White, Color.FromArgb(75, 95, 105))
        Dim f = If(active, New Font(FontName, 8.5F, FontStyle.Bold), New Font(FontName, 8.5F, FontStyle.Regular))

        btn.BackColor = back
        btn.ForeColor = fore
        btn.Font = f
        btn.MouseEnterFont = f
        btn.MouseLeaveFont = f
        btn.MouseEnterBackColor = If(active, ClrTealDark, Color.FromArgb(230, 238, 241))
        btn.MouseEnterForeColor = If(active, Color.White, ClrTeal)
        btn.MouseLeaveBackColor = back
        btn.MouseLeaveForeColor = fore
    End Sub

    ' =========================================================================
    '  Pager
    ' =========================================================================

    Private Sub BuildPager()
        pnlPager = New Panel With {
            .Location = New Point(14, 374),
            .Size = New Size(748, 40),
            .BackColor = Color.White
        }
        pnlPager.Controls.Add(New Panel With {
            .Location = New Point(0, 0),
            .Size = New Size(748, 1),
            .BackColor = ClrDivider
        })

        lblPageInfo = New Label With {
            .Font = FCellSmall,
            .ForeColor = ClrSubtitle,
            .Location = New Point(4, 13),
            .AutoSize = True
        }

        btnPageSize = New FButton With {
            .Text = $"{_pageSize} per page  ▾",
            .Size = New Size(120, 26),
            .Location = New Point(470, 7),
            .BackColor = Color.White,
            .BorderColor = ClrBorder,
            .BorderSize = 1,
            .BorderRadius = 4,
            .Font = FAction,
            .MouseEnterFont = FAction,
            .MouseLeaveFont = FAction,
            .ForeColor = Color.FromArgb(45, 60, 70),
            .Cursor = Cursors.Hand
        }
        btnPageSize.MouseEnterBackColor = Color.FromArgb(246, 249, 251)
        btnPageSize.MouseLeaveBackColor = Color.White
        btnPageSize.MouseEnterForeColor = Color.FromArgb(45, 60, 70)
        btnPageSize.MouseLeaveForeColor = Color.FromArgb(45, 60, 70)

        cmsPageSize = New ContextMenuStrip()
        cmsPageSize.Font = New Font(FontName, 9.0F)
        For Each n In {5, 10, 20, 50}
            Dim size = n
            Dim it = cmsPageSize.Items.Add($"{size} per page")
            AddHandler it.Click, Sub()
                                     _pageSize = size
                                     _currentPage = 1
                                     btnPageSize.Text = $"{size} per page  ▾"
                                     RefreshData()
                                 End Sub
        Next
        AddHandler btnPageSize.Click, Sub() cmsPageSize.Show(btnPageSize, 0, btnPageSize.Height)

        btnPrevPage = New FButton With {
            .Text = "‹",
            .Size = New Size(28, 26),
            .Location = New Point(598, 7),
            .Font = FAction,
            .BorderRadius = 4,
            .BorderSize = 0,
            .Cursor = Cursors.Hand
        }
        UIThemeHelper.ApplySecondary(btnPrevPage)
        AddHandler btnPrevPage.Click, Sub()
                                          _currentPage -= 1
                                          RefreshData()
                                      End Sub

        lblPageNum = New Label With {
            .Font = New Font(FontName, 8.5F, FontStyle.Bold),
            .ForeColor = ClrTitle,
            .Location = New Point(630, 7),
            .Size = New Size(86, 26),
            .TextAlign = ContentAlignment.MiddleCenter
        }

        btnNextPage = New FButton With {
            .Text = "›",
            .Size = New Size(28, 26),
            .Location = New Point(720, 7),
            .Font = FAction,
            .BorderRadius = 4,
            .BorderSize = 0,
            .Cursor = Cursors.Hand
        }
        UIThemeHelper.ApplySecondary(btnNextPage)
        AddHandler btnNextPage.Click, Sub()
                                          _currentPage += 1
                                          RefreshData()
                                      End Sub

        pnlPager.Controls.AddRange(New Control() {lblPageInfo, btnPageSize, btnPrevPage, lblPageNum, btnNextPage})
        cardTable.Controls.Add(pnlPager)
    End Sub

    Private Sub UpdatePager(totalCount As Integer, totalPages As Integer)
        If pnlPager Is Nothing Then Return
        pnlPager.Visible = totalCount > 0
        If totalCount = 0 Then Return

        Dim first = (_currentPage - 1) * _pageSize + 1
        Dim last = Math.Min(_currentPage * _pageSize, totalCount)
        lblPageInfo.Text = $"Showing {first}–{last} of {totalCount}"
        lblPageNum.Text = $"Page {_currentPage} of {totalPages}"
        btnPrevPage.Enabled = _currentPage > 1
        btnNextPage.Enabled = _currentPage < totalPages
    End Sub

    ' =========================================================================
    '  Filter Menus
    ' =========================================================================

    Private Sub InitDoctorMenu()
        If cmsDoctorFilter Is Nothing Then
            cmsDoctorFilter = New ContextMenuStrip()
            cmsDoctorFilter.Font = New Font(FontName, 9.0F)
        End If
        cmsDoctorFilter.Items.Clear()

        Dim itAll = cmsDoctorFilter.Items.Add("All Doctors")
        AddHandler itAll.Click, Sub()
                                    _selectedDoctor = "All"
                                    btnDoctorFilter.Text = "All Doctors  ▾"
                                    RefreshData()
                                End Sub

        ' Dynamically discover all active clinic doctors
        Dim docNames As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        For Each d In StaffStore.Doctors
            If Not String.IsNullOrWhiteSpace(d.Name) AndAlso Not String.Equals(d.Status, "Suspended", StringComparison.OrdinalIgnoreCase) Then
                docNames.Add(d.Name)
            End If
        Next
        For Each a In ClinicData.Appointments
            If Not String.IsNullOrWhiteSpace(a.DoctorName) Then
                docNames.Add(a.DoctorName)
            End If
        Next
        If docNames.Count = 0 Then
            docNames.Add("Dr. Elena Cruz")
            docNames.Add("Dr. Marco Lim")
        End If

        For Each dName In docNames.OrderBy(Function(n) n)
            Dim currentDocName = dName
            Dim shortName = currentDocName
            If currentDocName.StartsWith("Dr. ", StringComparison.OrdinalIgnoreCase) Then
                Dim parts = currentDocName.Substring(4).Trim().Split(" "c)
                If parts.Length > 0 Then shortName = "Dr. " & parts(parts.Length - 1)
            End If

            Dim itDoc = cmsDoctorFilter.Items.Add(currentDocName)
            AddHandler itDoc.Click, Sub()
                                        _selectedDoctor = currentDocName
                                        btnDoctorFilter.Text = shortName & "  ▾"
                                        RefreshData()
                                    End Sub
        Next
    End Sub

    Private Sub InitStatusMenu()
        cmsStatusFilter = New ContextMenuStrip()
        cmsStatusFilter.Font = New Font(FontName, 9.0F)

        Dim statuses = {"All Statuses", "Pending", "Confirmed", "Completed", "Cancelled"}
        For Each st In statuses
            Dim currentSt = st
            Dim it = cmsStatusFilter.Items.Add(currentSt)
            AddHandler it.Click, Sub()
                                     _selectedStatus = If(currentSt = "All Statuses", "All", currentSt)
                                     btnStatusFilter.Text = currentSt & "  ▾"
                                     RefreshData()
                                 End Sub
        Next
    End Sub

    Private Sub BtnDoctorFilter_Click(sender As Object, e As EventArgs)
        cmsDoctorFilter.Show(btnDoctorFilter, 0, btnDoctorFilter.Height)
    End Sub

    Private Sub BtnStatusFilter_Click(sender As Object, e As EventArgs)
        cmsStatusFilter.Show(btnStatusFilter, 0, btnStatusFilter.Height)
    End Sub

    ' =========================================================================
    '  Search Box UX
    ' =========================================================================

    Private Sub TxtSearch_GotFocus(sender As Object, e As EventArgs)
        If _isPlaceholderActive Then
            txtSearch.Text = ""
            txtSearch.ForeColor = Color.FromArgb(30, 45, 55)
            _isPlaceholderActive = False
        End If
        cardSearch.BorderColor = ClrTeal
    End Sub

    Private Sub TxtSearch_LostFocus(sender As Object, e As EventArgs)
        cardSearch.BorderColor = ClrBorder
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            txtSearch.Text = SearchPlaceholder
            txtSearch.ForeColor = ClrMuted
            _isPlaceholderActive = True
        End If
    End Sub

    Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs)
        If _isPlaceholderActive Then Return
        _searchQuery = txtSearch.Text.Trim().ToLower()
        RefreshData()
    End Sub

    ' =========================================================================
    '  Data Query & Row Rendering
    ' =========================================================================

    Private Sub UpdateKpis()
        Dim dayItems = _appointments.Where(Function(a) a.MatchesDate(_selectedDate)).ToList()
        If _selectedDoctor <> "All" Then
            dayItems = dayItems.Where(Function(a) a.DoctorName.Equals(_selectedDoctor, StringComparison.OrdinalIgnoreCase)).ToList()
        End If

        Dim total = dayItems.Count
        Dim confirmed = dayItems.Where(Function(a) a.Status.Equals("Confirmed", StringComparison.OrdinalIgnoreCase)).Count()
        Dim pending = dayItems.Where(Function(a) a.Status.Equals("Pending", StringComparison.OrdinalIgnoreCase)).Count()
        Dim completed = dayItems.Where(Function(a) a.Status.Equals("Completed", StringComparison.OrdinalIgnoreCase)).Count()
        Dim remaining = total - completed - dayItems.Where(Function(a) a.Status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase)).Count()

        If lblKpiTotalVal IsNot Nothing Then
            lblKpiTotalVal.Text = total.ToString()
            lblKpiTotalSub.Text = $"{remaining} remaining"

            lblKpiConfirmedVal.Text = confirmed.ToString()
            lblKpiConfirmedSub.Text = If(confirmed > 0, "Ready to be seen", "None confirmed")

            lblKpiPendingVal.Text = pending.ToString()
            lblKpiPendingSub.Text = If(pending > 0, "Awaiting check-in", "All checked in")

            lblKpiCompletedVal.Text = completed.ToString()
            lblKpiCompletedSub.Text = If(total > 0, $"{CInt(Math.Round(completed * 100.0 / total))}% of day", "0%")
        End If
    End Sub

    Private Sub RenderRows()
        If pnlRows Is Nothing Then Return

        pnlRows.SuspendLayout()
        For i As Integer = pnlRows.Controls.Count - 1 To 0 Step -1
            Dim c = pnlRows.Controls(i)
            pnlRows.Controls.RemoveAt(i)
            c.Dispose()
        Next

        Dim items = _appointments.Where(Function(a) a.MatchesDate(_selectedDate)).ToList()

        ' Doctor filter
        If _selectedDoctor <> "All" Then
            items = items.Where(Function(a) a.DoctorName.Equals(_selectedDoctor, StringComparison.OrdinalIgnoreCase)).ToList()
        End If

        ' Status filter
        If _selectedStatus <> "All" Then
            items = items.Where(Function(a) a.Status.Equals(_selectedStatus, StringComparison.OrdinalIgnoreCase)).ToList()
        End If

        ' Search query
        If Not String.IsNullOrWhiteSpace(_searchQuery) Then
            items = items.Where(Function(a)
                                    Return a.PatientName.ToLower().Contains(_searchQuery) OrElse
                                           a.PatientId.ToLower().Contains(_searchQuery) OrElse
                                           a.DoctorName.ToLower().Contains(_searchQuery) OrElse
                                           a.VisitType.ToLower().Contains(_searchQuery)
                                End Function).ToList()
        End If

        items = items.OrderBy(Function(a) a.Minutes).ToList()

        ' Reset to page 1 whenever the filters/day/search change
        Dim filterKey = $"{_selectedDate:yyyyMMdd}|{_selectedDoctor}|{_selectedStatus}|{_searchQuery}"
        If filterKey <> _lastFilterKey Then
            _currentPage = 1
            _lastFilterKey = filterKey
        End If

        Dim totalCount = items.Count
        Dim totalPages = Math.Max(1, CInt(Math.Ceiling(totalCount / CDbl(_pageSize))))
        _currentPage = Math.Max(1, Math.Min(_currentPage, totalPages))
        Dim pageItems = items.Skip((_currentPage - 1) * _pageSize).Take(_pageSize).ToList()

        lblEmpty.Text = $"No appointments scheduled for {_selectedDate:dddd, MMMM dd, yyyy}."
        lblEmpty.Visible = (totalCount = 0)
        pnlRows.Visible = (totalCount > 0)

        Dim y As Integer = 0
        For i As Integer = 0 To pageItems.Count - 1
            Dim row = CreateRow(pageItems(i), y, i < pageItems.Count - 1)
            pnlRows.Controls.Add(row)
            y += RowHeight
        Next

        pnlRows.AutoScrollPosition = New Point(0, 0)
        UpdatePager(totalCount, totalPages)
        pnlRows.ResumeLayout(True)
    End Sub

    Private Function MakeActionButton(text As String, x As Integer, w As Integer) As FButton
        Return New FButton With {
            .Text = text,
            .Size = New Size(w, 26),
            .Location = New Point(x, 11),
            .TextAlign = ContentAlignment.MiddleCenter,
            .Padding = New Padding(0),
            .Cursor = Cursors.Hand
        }
    End Function

    ' ApplyPrimary/Secondary/Danger may reset fonts, so set them again afterwards
    Private Sub FixActionFont(btn As FButton)
        btn.Font = FAction
        btn.MouseEnterFont = FAction
        btn.MouseLeaveFont = FAction
    End Sub

    Private Function CreateRow(item As AppointmentItem, y As Integer, showDivider As Boolean) As Panel
        Dim row As New Panel With {
            .Location = New Point(0, y),
            .Size = New Size(pnlRows.Width - SystemInformation.VerticalScrollBarWidth, RowHeight),
            .BackColor = Color.White,
            .Cursor = Cursors.Default
        }

        ' Hover effect (+ focus so the mouse wheel scrolls the list)
        AddHandler row.MouseEnter, Sub()
                                       row.BackColor = ClrRowHover
                                       pnlRows.Focus()
                                   End Sub
        AddHandler row.MouseLeave, Sub()
                                       If Not row.ClientRectangle.Contains(row.PointToClient(Cursor.Position)) Then
                                           row.BackColor = Color.White
                                       End If
                                   End Sub

        ' 1. TIME
        Dim lblTime As New Label With {
            .Text = ClinicData.FormatTime(item.Minutes),
            .Font = FCellBold,
            .ForeColor = ClrTitle,
            .Location = New Point(14, 15),
            .Size = New Size(54, 20),
            .BackColor = Color.Transparent
        }
        row.Controls.Add(lblTime)

        ' 2. PATIENT (Clickable name + ID)
        Dim normPatient = ValidationHelper.NormalizeProperCase(item.PatientName)
        Dim lblPatientName As New Label With {
            .Text = normPatient,
            .Font = FCellBold,
            .ForeColor = ClrTeal,
            .Location = New Point(66, 8),
            .AutoSize = True,
            .Cursor = Cursors.Hand,
            .BackColor = Color.Transparent
        }
        Dim lblPatientId As New Label With {
            .Text = item.PatientId,
            .Font = FCellSmall,
            .ForeColor = ClrMuted,
            .Location = New Point(66, 27),
            .AutoSize = True,
            .BackColor = Color.Transparent
        }
        AddHandler lblPatientName.Click, Sub() RaiseEvent PatientSelected(item.PatientId)
        row.Controls.AddRange(New Control() {lblPatientName, lblPatientId})

        ' 3. DOCTOR
        Dim lblDocName As New Label With {
            .Text = If(String.IsNullOrEmpty(item.DoctorName), "Dr. Elena Cruz", item.DoctorName),
            .Font = FCell,
            .ForeColor = ClrTitle,
            .Location = New Point(175, 8),
            .AutoSize = True,
            .BackColor = Color.Transparent
        }
        Dim docRoleText = If(String.IsNullOrEmpty(item.DoctorRole), "General Physician", item.DoctorRole)
        Dim lblDocRole As New Label With {
            .Text = docRoleText,
            .Font = FCellSmall,
            .ForeColor = ClrMuted,
            .Location = New Point(175, 27),
            .AutoSize = True,
            .BackColor = Color.Transparent
        }
        row.Controls.AddRange(New Control() {lblDocName, lblDocRole})

        ' 4. VISIT TYPE
        Dim lblVisit As New Label With {
            .Text = item.VisitType,
            .Font = FCell,
            .ForeColor = Color.FromArgb(60, 75, 85),
            .Location = New Point(330, 15),
            .AutoSize = True,
            .BackColor = Color.Transparent
        }
        row.Controls.Add(lblVisit)

        ' 5. STATUS PILL
        Dim pill As FCard = CreateStatusPill(item.Status, 414, 12)
        row.Controls.Add(pill)

        ' 6. ACTIONS (Check-in, Reschedule, No-show, or Note)
        If item.Status.Equals("Confirmed", StringComparison.OrdinalIgnoreCase) Then
            Dim btnCheckIn = MakeActionButton("Check in", 502, 64)
            UIThemeHelper.ApplyPrimary(btnCheckIn)
            FixActionFont(btnCheckIn)
            AddHandler btnCheckIn.Click, Sub()
                                             item.Status = "Pending"
                                             item.Note = "Checked in at reception (" & DateTime.Now.ToString("h:mm tt") & ")"
                                             ClinicData.UpdateAppointment(item)
                                             RefreshData()
                                         End Sub
            row.Controls.Add(btnCheckIn)

            Dim btnReschedule = MakeActionButton("Reschedule", 572, 78)
            UIThemeHelper.ApplySecondary(btnReschedule)
            FixActionFont(btnReschedule)
            AddHandler btnReschedule.Click, Sub()
                                                Using dlg As New ReceptionistBookAppointmentDialog(item)
                                                    If dlg.ShowDialog(Me.FindForm()) = DialogResult.OK Then
                                                        If dlg.BookedDate.HasValue Then
                                                            GoToDate(dlg.BookedDate.Value)
                                                        Else
                                                            RefreshData()
                                                        End If
                                                    End If
                                                End Using
                                            End Sub
            row.Controls.Add(btnReschedule)

            Dim btnNoShow = MakeActionButton("No-show", 656, 64)
            UIThemeHelper.ApplyDanger(btnNoShow)
            FixActionFont(btnNoShow)
            AddHandler btnNoShow.Click, Sub()
                                            Dim ans = MessageBox.Show($"Mark {item.PatientName} ({ClinicData.FormatTime(item.Minutes)}) as a no-show?",
                                                                      "No-Show", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                            If ans = DialogResult.Yes Then
                                                item.Status = "Cancelled"
                                                item.Note = "Marked as no-show"
                                                ClinicData.UpdateAppointment(item)
                                                RefreshData()
                                            End If
                                        End Sub
            row.Controls.Add(btnNoShow)

        ElseIf item.Status.Equals("Pending", StringComparison.OrdinalIgnoreCase) Then
            Dim lblNote As New Label With {
                .Text = "In waiting room",
                .Font = FCellBold,
                .ForeColor = FgPending,
                .Location = New Point(502, 15),
                .AutoSize = True,
                .BackColor = Color.Transparent
            }
            row.Controls.Add(lblNote)

        Else
            Dim lblNote As New Label With {
                .Text = If(item.Status.Equals("Completed", StringComparison.OrdinalIgnoreCase), "Completed",
                           If(String.IsNullOrEmpty(item.Note), "Cancelled", item.Note)),
                .Font = FCellSmall,
                .ForeColor = ClrMuted,
                .Location = New Point(502, 15),
                .AutoSize = True,
                .BackColor = Color.Transparent
            }
            row.Controls.Add(lblNote)
        End If

        ' Divider
        If showDivider Then
            Dim div As New Panel With {
                .Dock = DockStyle.Bottom,
                .Height = 1,
                .BackColor = ClrDivider
            }
            row.Controls.Add(div)
        End If

        Return row
    End Function

    Private Function CreateStatusPill(status As String, x As Integer, y As Integer) As FCard
        Dim bg, fg As Color
        Dim w As Integer = 76

        Select Case status.Trim().ToLowerInvariant()
            Case "pending"
                bg = BgPending : fg = FgPending : w = 70
            Case "completed"
                bg = BgCompleted : fg = FgCompleted : w = 82
            Case "cancelled"
                bg = BgCancelled : fg = FgCancelled : w = 76
            Case Else   ' Confirmed
                bg = BgConfirmed : fg = FgConfirmed : w = 78
        End Select

        Dim pill As New FCard With {
            .Location = New Point(x, y),
            .Size = New Size(w, 24),
            .BackColor = bg,
            .BorderColor = bg,
            .BorderHoverColor = bg,
            .HoverTintColor = bg,
            .BorderRadius = 6,
            .BorderSize = 0,
            .EnableShadow = False
        }

        Dim dot As New Label With {
            .Text = ChrW(&H25CF).ToString(),
            .Font = New Font(FontName, 7.0F),
            .ForeColor = fg,
            .BackColor = Color.Transparent,
            .Location = New Point(6, 4),
            .Size = New Size(12, 14)
        }
        Dim lbl As New Label With {
            .Text = status,
            .Font = New Font(FontName, 7.5F, FontStyle.Bold),
            .ForeColor = fg,
            .BackColor = Color.Transparent,
            .Location = New Point(18, 4),
            .AutoSize = True
        }
        pill.Controls.AddRange(New Control() {dot, lbl})
        Return pill
    End Function

    ' =========================================================================
    '  Appointments Mock Dataset (Shared Repository)
    ' =========================================================================

    Public Shared Function GetDoctorRoom(doctorName As String) As String
        Dim doc = If(doctorName, "").Trim()
        If doc.IndexOf("Cruz", StringComparison.OrdinalIgnoreCase) >= 0 Then
            Return "Room 101"
        ElseIf doc.IndexOf("Lim", StringComparison.OrdinalIgnoreCase) >= 0 Then
            Return "Room 102"
        ElseIf doc.IndexOf("Vega", StringComparison.OrdinalIgnoreCase) >= 0 Then
            Return "Room 103"
        ElseIf doc.IndexOf("Bautista", StringComparison.OrdinalIgnoreCase) >= 0 OrElse doc.IndexOf("salas", StringComparison.OrdinalIgnoreCase) >= 0 Then
            Return "Room 104"
        Else
            Return "Room 105"
        End If
    End Function

    Private Shared Sub EnsureAppointmentsLoaded()
        ' Shared data lives in ClinicData.Appointments
    End Sub

End Class

''' <summary>Compatibility alias for Receptionist appointment items.</summary>
Public Class ReceptionistAppointmentItem
    Inherits AppointmentItem
End Class