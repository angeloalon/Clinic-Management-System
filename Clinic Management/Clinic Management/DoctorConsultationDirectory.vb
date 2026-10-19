Imports System.Globalization
Imports Ferrando.UI.WinForms.Controles

Public Class DoctorConsultationDirectory

    Private Enum ConsultationFilter
        All
        Completed
        Pending
    End Enum

    Private Enum SortMode
        DateDesc
        PatientName
        Status
    End Enum

    Private _filter As ConsultationFilter = ConsultationFilter.All
    Private _sort As SortMode = SortMode.DateDesc

    Private ReadOnly cmsFilterAll As New ContextMenuStrip()
    Private ReadOnly cmsSort As New ContextMenuStrip()

    Private Const RowHeight As Integer = 46
    Private Const ActionBtnWidth As Integer = 84
    Private Const ActionRightPad As Integer = 8
    Private ReadOnly Arrow As String = " " & ChrW(&H25BE)

    Private _currentPage As Integer = 1
    Private Const PageSize As Integer = 10
    Private pnlPagination As Panel
    Private lblPageInfo As Label
    Private btnPrevPage As FButton
    Private btnNextPage As FButton

    Public Sub New()
        InitializeComponent()
        SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        DoubleBuffered = True
    End Sub

    Private ReadOnly Property _consultations As List(Of AppointmentItem)
        Get
            Dim currentDoc = If(CurrentUser.IsAuthenticated, CurrentUser.FullName, "Dr. Elena Cruz")
            Dim docShort = If(String.IsNullOrEmpty(currentDoc), "", currentDoc.Replace("Dr.", "").Trim())

            Dim docFilter = Function(docName As String) As Boolean
                                If String.IsNullOrWhiteSpace(docName) Then Return False
                                If docName.Equals(currentDoc, StringComparison.OrdinalIgnoreCase) Then Return True
                                If Not String.IsNullOrEmpty(docShort) AndAlso docName.IndexOf(docShort, StringComparison.OrdinalIgnoreCase) >= 0 Then Return True
                                If currentDoc.IndexOf("Cruz", StringComparison.OrdinalIgnoreCase) >= 0 AndAlso docName.IndexOf("Cruz", StringComparison.OrdinalIgnoreCase) >= 0 Then Return True
                                If currentDoc.IndexOf("Lim", StringComparison.OrdinalIgnoreCase) >= 0 AndAlso docName.IndexOf("Lim", StringComparison.OrdinalIgnoreCase) >= 0 Then Return True
                                Return False
                            End Function

            Dim all = ClinicData.Appointments.Where(Function(a) docFilter(a.DoctorName)).ToList()
            Return all.OrderByDescending(Function(a)
                                             Dim d As Date
                                             If Not String.IsNullOrEmpty(a.AppointmentDate) AndAlso DateTime.TryParse(a.AppointmentDate, d) Then
                                                 d = d.Date
                                             Else
                                                 d = New Date(2026, 9, Math.Min(Math.Max(a.Day, 1), 30))
                                             End If
                                             Return d
                                         End Function).
                       ThenByDescending(Function(a)
                                            Dim ts As DateTime = DateTime.MinValue
                                            If Not String.IsNullOrEmpty(a.UpdatedAt) AndAlso DateTime.TryParse(a.UpdatedAt, ts) Then
                                                Return ts
                                            ElseIf Not String.IsNullOrEmpty(a.CreatedAt) AndAlso DateTime.TryParse(a.CreatedAt, ts) Then
                                                Return ts
                                            End If
                                            Return DateTime.MinValue.AddMinutes(a.Minutes)
                                        End Function).ToList()
        End Get
    End Property

    Private Sub DoctorConsultationDirectory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ---- Scrolling ----
        mainScreen.AutoScroll = True
        mainScreen.HorizontalScroll.Enabled = False
        mainScreen.HorizontalScroll.Visible = False

        ' Mouse wheel goes to the focused control, so take focus when the mouse enters
        AddHandler mainScreen.MouseEnter, Sub() FocusScrollArea()
        AddHandler cardConsultations.MouseEnter, Sub() FocusScrollArea()
        AddHandler pnlRows.MouseEnter, Sub() FocusScrollArea()

        btnFilterAll.Text = "All consultations" & Arrow
        btnSort.Text = "Date (Newest)" & Arrow

        BuildMenu(cmsFilterAll, {
            ("All consultations", ConsultationFilter.All),
            ("Completed", ConsultationFilter.Completed),
            ("Waiting / Pending", ConsultationFilter.Pending)
        })
        BuildSortMenu()

        AddHandler ClinicData.DataChanged, Sub()
                                               If IsHandleCreated AndAlso Not IsDisposed Then
                                                   BeginInvoke(Sub() RefreshRows())
                                               End If
                                           End Sub

        AlignHeaderColumns()
        RefreshRows()
    End Sub

    Private Sub FocusScrollArea()
        If mainScreen IsNot Nothing AndAlso Not mainScreen.Focused Then
            mainScreen.Focus()
        End If
    End Sub

    Private Sub DoctorConsultationDirectory_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Visible Then
            RefreshRows()
        End If
    End Sub

    Private Sub DoctorConsultationDirectory_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        AlignHeaderColumns()
        RefreshRows()
    End Sub

    Private Sub AlignHeaderColumns()
        If cardConsultations Is Nothing OrElse pnlRows Is Nothing Then Return

        Dim padLeft = 28
        ' Reserve room for the vertical scrollbar so it never covers the card
        Dim totalW = mainScreen.ClientSize.Width - (padLeft * 2) - SystemInformation.VerticalScrollBarWidth
        If totalW > 400 Then
            cardConsultations.Width = totalW
            pnlRows.Width = totalW - 40
            pnlHeaderLine.Width = totalW - 40
            cardSearch.Width = Math.Max(240, totalW - btnFilterAll.Width - btnSort.Width - 32)
            btnFilterAll.Left = cardSearch.Right + 12
            btnSort.Left = btnFilterAll.Right + 12
        End If

        ' Header positions = row positions + 20 (pnlRows left offset inside the card)
        Dim w = pnlRows.Width
        lblColDate.Left = 24
        lblColPatient.Left = 24 + CInt(w * 0.16)
        lblColDoctor.Left = 24 + CInt(w * 0.41)
        lblColVisitType.Left = 24 + CInt(w * 0.6)
        lblColStatus.Left = 24 + CInt(w * 0.74)
        ' Action column is pinned to the right edge so the buttons never get cut off
        lblColAction.Left = 20 + (w - ActionBtnWidth - ActionRightPad)
    End Sub

    Private Sub BuildMenu(cms As ContextMenuStrip, items As (String, ConsultationFilter)())
        cms.Font = New Font("Segoe UI", 9.0F)
        cms.ShowImageMargin = False
        cms.Items.Clear()
        For Each it In items
            Dim text As String = it.Item1
            Dim value As ConsultationFilter = it.Item2
            Dim mi As New ToolStripMenuItem(text)
            AddHandler mi.Click,
                Sub()
                    _filter = value
                    _currentPage = 1
                    btnFilterAll.Text = text & Arrow
                    RefreshRows(True)
                End Sub
            cms.Items.Add(mi)
        Next
    End Sub

    Private Sub BuildSortMenu()
        cmsSort.Font = New Font("Segoe UI", 9.0F)
        cmsSort.ShowImageMargin = False
        cmsSort.Items.Clear()

        Dim options As (String, SortMode)() = {
            ("Date (Newest)", SortMode.DateDesc),
            ("Patient name", SortMode.PatientName),
            ("Status", SortMode.Status)
        }
        For Each it In options
            Dim text As String = it.Item1
            Dim value As SortMode = it.Item2
            Dim mi As New ToolStripMenuItem(text)
            AddHandler mi.Click,
                Sub()
                    _sort = value
                    _currentPage = 1
                    btnSort.Text = text & Arrow
                    RefreshRows(True)
                End Sub
            cmsSort.Items.Add(mi)
        Next
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        _currentPage = 1
        RefreshRows(True)
    End Sub

    Private Sub btnFilterAll_Click(sender As Object, e As EventArgs) Handles btnFilterAll.Click
        cmsFilterAll.Show(btnFilterAll, New Point(0, btnFilterAll.Height + 2))
    End Sub

    Private Sub btnSort_Click(sender As Object, e As EventArgs) Handles btnSort.Click
        cmsSort.Show(btnSort, New Point(0, btnSort.Height + 2))
    End Sub

    Private Sub btnStartConsultation_Click(sender As Object, e As EventArgs) Handles btnStartConsultation.Click
        Dim currentDoc = If(CurrentUser.IsAuthenticated, CurrentUser.FullName, "Dr. Elena Cruz")
        Dim pending = ClinicData.Appointments.FirstOrDefault(Function(a)
                                                                 If Not a.Status.Equals("Pending", StringComparison.OrdinalIgnoreCase) Then Return False
                                                                 If String.IsNullOrWhiteSpace(a.DoctorName) Then Return True
                                                                 Return a.DoctorName.IndexOf(currentDoc.Replace("Dr.", "").Trim(), StringComparison.OrdinalIgnoreCase) >= 0
                                                             End Function)
        If pending Is Nothing Then
            pending = ClinicData.Appointments.FirstOrDefault(Function(a) a.Status.Equals("Pending", StringComparison.OrdinalIgnoreCase))
        End If

        If pending IsNot Nothing Then
            If DoctorShell.Current IsNot Nothing Then
                DoctorShell.Current.OpenConsultation(pending)
            End If
        Else
            ' Open empty consultation session
            If DoctorShell.Current IsNot Nothing Then
                DoctorShell.Current.OpenConsultation(Nothing)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Rebuilds the visible rows for the current page.
    ''' Pass resetScroll:=True when the user changes page, filter, sort or search
    ''' so the view jumps back to the top.
    ''' </summary>
    Public Sub RefreshRows(Optional resetScroll As Boolean = False)
        Dim term As String = txtSearch.Text.Trim()

        Dim result As List(Of AppointmentItem) =
            _consultations.Where(Function(a)
                                     If _filter = ConsultationFilter.Completed AndAlso Not a.Status.Equals("Completed", StringComparison.OrdinalIgnoreCase) Then Return False
                                     If _filter = ConsultationFilter.Pending AndAlso Not a.Status.Equals("Pending", StringComparison.OrdinalIgnoreCase) Then Return False
                                     If term = "" Then Return True
                                     Return (a.PatientName IsNot Nothing AndAlso a.PatientName.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0) OrElse
                                            (a.PatientId IsNot Nothing AndAlso a.PatientId.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0) OrElse
                                            (a.DoctorName IsNot Nothing AndAlso a.DoctorName.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0) OrElse
                                            (a.VisitType IsNot Nothing AndAlso a.VisitType.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0) OrElse
                                            (a.Diagnosis IsNot Nothing AndAlso a.Diagnosis.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0)
                                 End Function).ToList()

        Select Case _sort
            Case SortMode.PatientName
                result = result.OrderBy(Function(a) a.PatientName).ToList()
            Case SortMode.Status
                result = result.OrderBy(Function(a) a.Status).ToList()
            Case Else
                result = result.OrderByDescending(Function(a)
                                                      Dim d As Date
                                                      If Not String.IsNullOrEmpty(a.AppointmentDate) AndAlso DateTime.TryParse(a.AppointmentDate, d) Then
                                                          d = d.Date
                                                      Else
                                                          d = New Date(2026, 9, Math.Min(Math.Max(a.Day, 1), 30))
                                                      End If
                                                      Return d
                                                  End Function).
                                ThenByDescending(Function(a)
                                                     Dim ts As DateTime = DateTime.MinValue
                                                     If Not String.IsNullOrEmpty(a.UpdatedAt) AndAlso DateTime.TryParse(a.UpdatedAt, ts) Then
                                                         Return ts
                                                     ElseIf Not String.IsNullOrEmpty(a.CreatedAt) AndAlso DateTime.TryParse(a.CreatedAt, ts) Then
                                                         Return ts
                                                     End If
                                                     Return DateTime.MinValue.AddMinutes(a.Minutes)
                                                 End Function).ToList()
        End Select

        Dim totalCount = result.Count
        Dim totalPages = Math.Max(1, CInt(Math.Ceiling(totalCount / CDbl(PageSize))))
        If _currentPage > totalPages Then _currentPage = totalPages
        If _currentPage < 1 Then _currentPage = 1

        Dim pageRows = result.Skip((_currentPage - 1) * PageSize).Take(PageSize).ToList()

        ' Remember scroll position so background refreshes don't yank the view
        Dim savedScrollY As Integer = -mainScreen.AutoScrollPosition.Y

        SuspendLayout()
        pnlRows.SuspendLayout()

        For i As Integer = pnlRows.Controls.Count - 1 To 0 Step -1
            Dim c As Control = pnlRows.Controls(i)
            pnlRows.Controls.RemoveAt(i)
            c.Dispose()
        Next

        Dim y As Integer = 0
        For Each item In pageRows
            pnlRows.Controls.Add(BuildRow(item, y))
            y += RowHeight
        Next
        pnlRows.Height = Math.Max(y, 1)

        EnsurePaginationControls()
        Dim startItem = If(totalCount = 0, 0, (_currentPage - 1) * PageSize + 1)
        Dim endItem = Math.Min(_currentPage * PageSize, totalCount)
        lblPageInfo.Text = $"Showing {startItem}-{endItem} of {totalCount} consultations  •  Page {_currentPage} of {totalPages}"
        btnPrevPage.Enabled = (_currentPage > 1)
        btnNextPage.Enabled = (_currentPage < totalPages)

        pnlPagination.Top = pnlRows.Bottom + 8
        pnlPagination.Width = pnlRows.Width
        cardConsultations.Height = Math.Max(320, pnlPagination.Bottom + 16)

        lblEmpty.Text = "No consultations match your search."
        lblEmpty.Visible = (totalCount = 0)
        pnlPagination.Visible = (totalCount > 0)

        pnlRows.ResumeLayout()
        ResumeLayout()

        ' ---- Scrolling: tell the scroll panel how tall the content is ----
        mainScreen.AutoScrollMinSize = New Size(0, cardConsultations.Bottom + 24)

        If resetScroll Then
            mainScreen.AutoScrollPosition = New Point(0, 0)
        Else
            mainScreen.AutoScrollPosition = New Point(0, savedScrollY)
        End If
    End Sub

    Private Sub EnsurePaginationControls()
        If pnlPagination IsNot Nothing Then Return

        pnlPagination = New Panel With {
            .Location = New Point(20, pnlRows.Bottom + 8),
            .Size = New Size(pnlRows.Width, 36),
            .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right,
            .BackColor = Color.White
        }

        lblPageInfo = New Label With {
            .AutoSize = True,
            .Location = New Point(4, 9),
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Regular),
            .ForeColor = Color.FromArgb(115, 138, 148),
            .BackColor = Color.Transparent
        }
        pnlPagination.Controls.Add(lblPageInfo)

        btnNextPage = New FButton With {
            .Text = "Next ›",
            .Size = New Size(76, 30),
            .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
            .Location = New Point(pnlPagination.Width - 76, 3),
            .Cursor = Cursors.Hand,
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        }
        UIThemeHelper.ApplySecondary(btnNextPage)
        AddHandler btnNextPage.Click, Sub()
                                          _currentPage += 1
                                          RefreshRows(True)
                                      End Sub
        pnlPagination.Controls.Add(btnNextPage)

        btnPrevPage = New FButton With {
            .Text = "‹ Prev",
            .Size = New Size(76, 30),
            .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
            .Location = New Point(pnlPagination.Width - 160, 3),
            .Cursor = Cursors.Hand,
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        }
        UIThemeHelper.ApplySecondary(btnPrevPage)
        AddHandler btnPrevPage.Click, Sub()
                                          _currentPage -= 1
                                          RefreshRows(True)
                                      End Sub
        pnlPagination.Controls.Add(btnPrevPage)

        cardConsultations.Controls.Add(pnlPagination)
    End Sub

    Private Function BuildRow(appt As AppointmentItem, y As Integer) As Panel
        Dim row As New Panel With {
            .Location = New Point(0, y),
            .Size = New Size(pnlRows.Width, RowHeight),
            .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right,
            .BackColor = Color.White,
            .Cursor = Cursors.Hand
        }

        Dim w = pnlRows.Width
        Dim col0 = 4
        Dim col1 = 4 + CInt(w * 0.16)
        Dim col2 = 4 + CInt(w * 0.41)
        Dim col3 = 4 + CInt(w * 0.6)
        Dim col4 = 4 + CInt(w * 0.74)
        Dim col5 = w - ActionBtnWidth - ActionRightPad

        Dim d As Date
        If Not String.IsNullOrEmpty(appt.AppointmentDate) AndAlso DateTime.TryParse(appt.AppointmentDate, d) Then
            d = d.Date.AddMinutes(appt.Minutes)
        Else
            d = New Date(2026, 9, Math.Min(Math.Max(appt.Day, 1), 30)).AddMinutes(appt.Minutes)
        End If

        Dim dateStr = d.ToString("MMM dd, yyyy", CultureInfo.InvariantCulture)
        Dim normPatient = ValidationHelper.NormalizeProperCase(appt.PatientName)
        Dim docDisplay = If(String.IsNullOrEmpty(appt.DoctorName), "Dr. Elena Cruz", appt.DoctorName)
        Dim visitDisplay = If(String.IsNullOrEmpty(appt.VisitType), "Consultation", appt.VisitType)
        Dim statusDisplay = If(String.IsNullOrEmpty(appt.Status), "Confirmed", appt.Status)

        row.Controls.Add(MakeCell(dateStr, col0, Color.FromArgb(35, 45, 55), 8.5F, True))
        row.Controls.Add(MakeCell(normPatient & " (" & appt.PatientId & ")", col1, Color.FromArgb(23, 105, 90), 8.5F, True))
        row.Controls.Add(MakeCell(docDisplay, col2, Color.FromArgb(40, 55, 65)))
        row.Controls.Add(MakeCell(visitDisplay, col3, Color.FromArgb(115, 130, 140)))

        ' Status Pill
        Dim pill As New Label With {
            .AutoSize = False,
            .Size = New Size(76, 22),
            .Location = New Point(col4, 11),
            .TextAlign = ContentAlignment.MiddleCenter,
            .Text = statusDisplay,
            .Font = New Font("Segoe UI", 7.5F, FontStyle.Bold)
        }
        Select Case statusDisplay.ToLowerInvariant()
            Case "completed"
                pill.BackColor = Color.FromArgb(230, 245, 235) : pill.ForeColor = Color.FromArgb(40, 135, 75)
            Case "pending"
                pill.BackColor = Color.FromArgb(254, 243, 226) : pill.ForeColor = Color.FromArgb(217, 119, 6)
            Case "cancelled"
                pill.BackColor = Color.FromArgb(253, 236, 235) : pill.ForeColor = Color.FromArgb(205, 80, 75)
            Case Else
                pill.BackColor = Color.FromArgb(243, 246, 248) : pill.ForeColor = Color.FromArgb(120, 140, 150)
        End Select
        row.Controls.Add(pill)

        ' Action Button
        Dim btnAction As New FButton With {
            .Location = New Point(col5, 8),
            .Size = New Size(ActionBtnWidth, 28),
            .Cursor = Cursors.Hand,
            .Font = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        }
        If statusDisplay.Equals("Completed", StringComparison.OrdinalIgnoreCase) Then
            btnAction.Text = "View Chart"
            UIThemeHelper.ApplySecondary(btnAction)
        Else
            btnAction.Text = "Start"
            UIThemeHelper.ApplyPrimary(btnAction)
        End If

        AddHandler btnAction.Click,
            Sub(s, ev)
                If DoctorShell.Current IsNot Nothing Then
                    DoctorShell.Current.OpenConsultation(appt)
                End If
            End Sub
        row.Controls.Add(btnAction)

        row.Controls.Add(New Panel With {
            .Dock = DockStyle.Bottom,
            .Height = 1,
            .BackColor = Color.FromArgb(242, 244, 247)
        })

        Dim hoverOn As Action = Sub()
                                    row.BackColor = Color.FromArgb(246, 249, 251)
                                    FocusScrollArea()
                                End Sub
        Dim hoverOff As Action =
            Sub()
                If Not row.ClientRectangle.Contains(row.PointToClient(Cursor.Position)) Then
                    row.BackColor = Color.White
                End If
            End Sub

        Dim rowClick As EventHandler =
            Sub(s, ev)
                If DoctorShell.Current IsNot Nothing Then
                    DoctorShell.Current.OpenConsultation(appt)
                End If
            End Sub

        AddHandler row.MouseEnter, Sub() hoverOn()
        AddHandler row.MouseLeave, Sub() hoverOff()
        AddHandler row.Click, rowClick

        For Each ctrl As Control In row.Controls
            If ctrl IsNot btnAction Then
                ctrl.Cursor = Cursors.Hand
                AddHandler ctrl.MouseEnter, Sub() hoverOn()
                AddHandler ctrl.MouseLeave, Sub() hoverOff()
                AddHandler ctrl.Click, rowClick
            End If
        Next

        Return row
    End Function

    Private Function MakeCell(text As String, x As Integer, color As Color, Optional size As Single = 8.5F, Optional isBold As Boolean = False) As Label
        Return New Label With {
            .AutoSize = True,
            .BackColor = Color.Transparent,
            .Font = New Font("Segoe UI", size, If(isBold, FontStyle.Bold, FontStyle.Regular), GraphicsUnit.Point, CByte(0)),
            .ForeColor = color,
            .Location = New Point(x, 13),
            .Text = text
        }
    End Function

    Private Sub mainScreen_Paint(sender As Object, e As PaintEventArgs) Handles mainScreen.Paint

    End Sub
End Class