Imports System.Globalization
Imports Ferrando.UI.WinForms.Controles

Public Class ReceptionistPatients

    ' ---- Events the host form listens to
    Public Event PatientSelected(patientId As String)
    Public Event RegisterPatientRequested As EventHandler

    ' ---- Layout constants (must match the Designer)
    Private Const RowHeight As Integer = 44
    Private Const TableTop As Integer = 140
    Private Const RowsTop As Integer = 70
    Private Const SearchPlaceholder As String = "Search name, patient ID, phone..."

    ' ---- Non-ASCII characters built at runtime so the source stays plain ASCII
    Private Shared ReadOnly Bullet As String = ChrW(&H2022).ToString()
    Private Shared ReadOnly Caret As String = " " & ChrW(&H25BE).ToString()
    Private Shared ReadOnly SearchIcon As String = Char.ConvertFromUtf32(&H1F50D)

    ' ---- Colors (DESIGN_SYSTEM.md)
    Private Shared ReadOnly ColTeal As Color = Color.FromArgb(35, 137, 120)
    Private Shared ReadOnly ColSearchBorder As Color = Color.FromArgb(220, 228, 232)
    Private Shared ReadOnly ColInputText As Color = Color.FromArgb(30, 45, 55)
    Private Shared ReadOnly ColPlaceholder As Color = Color.FromArgb(100, 120, 130)
    Private Shared ReadOnly ColRowHover As Color = Color.FromArgb(246, 249, 251)
    Private Shared ReadOnly ColDivider As Color = Color.FromArgb(242, 244, 247)
    Private Shared ReadOnly ColName As Color = Color.FromArgb(35, 45, 55)
    Private Shared ReadOnly ColMeta As Color = Color.FromArgb(115, 135, 145)

    Private Shared ReadOnly FontName As New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
    Private Shared ReadOnly FontCell As New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))

    ' ---- State
    Private allPatients As New List(Of PatientRecord)
    Private registeredTotal As Integer
    Private filterMode As String = "all"        ' all | new | returning
    Private sortMode As String = "newest"       ' newest | oldest | name | id
    Private showingPlaceholder As Boolean = True
    Private suppressSearch As Boolean = False
    Private _currentPage As Integer = 1
    Private Const PageSize As Integer = 10
    Private pnlPagination As Panel
    Private btnPrevPage As FButton
    Private btnNextPage As FButton
    Private lblPageInfo As Label

    Public Sub New()
        InitializeComponent()
        DoubleBuffered = True

        lblSearchIcon.Text = SearchIcon
        btnFilterAll.Text = "All patients" & Caret
        btnFilterVisit.Text = "Last visit" & Caret
        SetPlaceholder()
        SetupPaginationControls()
    End Sub

    Private Sub SetupPaginationControls()
        If pnlPagination IsNot Nothing Then Return
        pnlPagination = New Panel With {
            .Height = 44,
            .Dock = DockStyle.Bottom,
            .BackColor = Color.White
        }

        btnPrevPage = New FButton With {
            .Text = "‹ Previous",
            .Size = New Size(90, 30),
            .Location = New Point(20, 7),
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        }
        UIThemeHelper.ApplySecondary(btnPrevPage)
        AddHandler btnPrevPage.Click, Sub()
                                          If _currentPage > 1 Then
                                              _currentPage -= 1
                                              ApplyFilters()
                                          End If
                                      End Sub

        lblPageInfo = New Label With {
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Regular),
            .ForeColor = Color.FromArgb(100, 120, 130),
            .AutoSize = False,
            .Size = New Size(240, 30),
            .Location = New Point(125, 7),
            .TextAlign = ContentAlignment.MiddleLeft
        }

        btnNextPage = New FButton With {
            .Text = "Next ›",
            .Size = New Size(90, 30),
            .Location = New Point(380, 7),
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        }
        UIThemeHelper.ApplySecondary(btnNextPage)
        AddHandler btnNextPage.Click, Sub()
                                          _currentPage += 1
                                          ApplyFilters()
                                      End Sub

        pnlPagination.Controls.AddRange(New Control() {btnPrevPage, lblPageInfo, btnNextPage})
        cardTable.Controls.Add(pnlPagination)
        pnlPagination.BringToFront()
    End Sub

    Private Sub ReceptionistPatients_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If allPatients.Count > 0 Then ApplyFilters()
    End Sub

    ' =====================================================================
    '  Public API
    ' =====================================================================

    ''' <summary>Loads the patient list. totalCount = total registered patients (defaults to list size).</summary>
    Public Sub LoadPatients(patients As IEnumerable(Of PatientRecord), Optional totalCount As Integer = 0)
        allPatients = patients.ToList()
        registeredTotal = If(totalCount > 0, totalCount, allPatients.Count)
        lblHeaderSubtitle.Text = String.Format(CultureInfo.InvariantCulture,
            "{0:N0} registered patients {1} Single clinic record", registeredTotal, Bullet)
        _currentPage = 1
        ApplyFilters()
    End Sub

    ' =====================================================================
    '  Filtering / sorting / rendering
    ' =====================================================================
    Private Sub ApplyFilters()
        Dim q As String = If(showingPlaceholder, "", txtSearch.Text.Trim())
        Dim items As IEnumerable(Of PatientRecord) = allPatients

        If q.Length > 0 Then items = items.Where(Function(p) Matches(p, q))

        Select Case filterMode
            Case "new" : items = items.Where(Function(p) Not p.LastVisit.HasValue)
            Case "returning" : items = items.Where(Function(p) p.LastVisit.HasValue)
        End Select

        Select Case sortMode
            Case "oldest"
                items = items.OrderBy(Function(p) Not p.LastVisit.HasValue).ThenBy(Function(p) If(p.LastVisit.HasValue, p.LastVisit.Value, Date.MaxValue))
            Case "name"
                items = items.OrderBy(Function(p) p.FullName, StringComparer.CurrentCultureIgnoreCase)
            Case "id"
                items = items.OrderBy(Function(p) p.PatientId, StringComparer.OrdinalIgnoreCase)
            Case Else   ' newest first, "new patients" (no visit yet) at the bottom
                items = items.OrderByDescending(Function(p) If(p.LastVisit.HasValue, p.LastVisit.Value, Date.MinValue)).ThenBy(Function(p) p.FullName)
        End Select

        Dim filteredList = items.ToList()
        Dim totalPages = Math.Max(1, CInt(Math.Ceiling(filteredList.Count / CDbl(PageSize))))
        If _currentPage > totalPages Then _currentPage = totalPages
        If _currentPage < 1 Then _currentPage = 1

        If lblPageInfo IsNot Nothing Then
            lblPageInfo.Text = $"Page {_currentPage} of {totalPages} ({filteredList.Count} patients)"
        End If
        If btnPrevPage IsNot Nothing Then btnPrevPage.Enabled = (_currentPage > 1)
        If btnNextPage IsNot Nothing Then btnNextPage.Enabled = (_currentPage < totalPages)

        Dim pagedItems = filteredList.Skip((_currentPage - 1) * PageSize).Take(PageSize).ToList()
        RenderRows(pagedItems)
    End Sub

    Private Shared Function Matches(p As PatientRecord, q As String) As Boolean
        If p.FullName IsNot Nothing AndAlso p.FullName.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0 Then Return True
        If p.PatientId IsNot Nothing AndAlso p.PatientId.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0 Then Return True

        Dim qDigits As String = DigitsOnly(q)
        Return qDigits.Length > 0 AndAlso DigitsOnly(p.Contact).Contains(qDigits)
    End Function

    Private Shared Function DigitsOnly(s As String) As String
        If s Is Nothing Then Return ""
        Return New String(s.Where(Function(ch) Char.IsDigit(ch)).ToArray())
    End Function

    Private Sub RenderRows(items As List(Of PatientRecord))
        SuspendLayout()
        ClearRows()

        Dim n As Integer = items.Count
        lblEmpty.Visible = (n = 0)
        pnlRows.Visible = (n > 0)

        Dim availableH As Integer = Math.Max(Height - TableTop - 28 - RowsTop - 14, RowHeight)
        pnlRows.Height = Math.Min(n * RowHeight, availableH)

        ' leave room for the scrollbar only when the list actually scrolls
        Dim rowWidth As Integer = If(n * RowHeight > pnlRows.Height, pnlRows.Width - SystemInformation.VerticalScrollBarWidth, pnlRows.Width)

        For i As Integer = 0 To n - 1
            pnlRows.Controls.Add(CreateRow(items(i), i, rowWidth))
        Next

        cardTable.Height = If(n = 0, 150, RowsTop + pnlRows.Height + 54)
        ResumeLayout(True)
    End Sub

    Private Sub ClearRows()
        pnlRows.AutoScrollPosition = New Point(0, 0)
        For i As Integer = pnlRows.Controls.Count - 1 To 0 Step -1
            Dim c As Control = pnlRows.Controls(i)
            pnlRows.Controls.RemoveAt(i)
            c.Dispose()
        Next
    End Sub

    Private Function CreateRow(p As PatientRecord, index As Integer, width As Integer) As Panel
        Dim row As New Panel() With {
            .Size = New Size(width, RowHeight),
            .Location = New Point(0, index * RowHeight),
            .BackColor = Color.White,
            .Cursor = Cursors.Hand,
            .Tag = p.PatientId
        }

        Dim lastVisit As String = If(p.LastVisit.HasValue,
            p.LastVisit.Value.ToString("MMM d, yyyy", CultureInfo.InvariantCulture), "New patient")

        Dim normName = ValidationHelper.NormalizeProperCase(p.FullName)
        row.Controls.Add(MakeCell(normName, 0, FontName, ColName))
        row.Controls.Add(MakeCell(p.PatientId, 160, FontCell, ColMeta))
        row.Controls.Add(MakeCell($"{p.Age} {Bullet} {p.Sex}", 310, FontCell, ColMeta))
        row.Controls.Add(MakeCell(p.Contact, 460, FontCell, ColMeta))
        row.Controls.Add(MakeCell(lastVisit, 600, FontCell, ColMeta))

        AddHandler row.Paint, AddressOf Row_Paint
        AddHandler row.MouseEnter, AddressOf Row_MouseEnter
        AddHandler row.MouseLeave, AddressOf Row_MouseLeave
        AddHandler row.Click, AddressOf Row_Click
        Return row
    End Function

    Private Function MakeCell(text As String, x As Integer, f As Font, c As Color) As Label
        Dim lbl As New Label() With {
            .AutoSize = False,
            .AutoEllipsis = True,
            .BackColor = Color.Transparent,
            .Cursor = Cursors.Hand,
            .Font = f,
            .ForeColor = c,
            .Location = New Point(x, 13),
            .Size = New Size(135, 18),
            .Text = text,
            .TextAlign = ContentAlignment.MiddleLeft
        }
        AddHandler lbl.MouseEnter, AddressOf Row_MouseEnter
        AddHandler lbl.MouseLeave, AddressOf Row_MouseLeave
        AddHandler lbl.Click, AddressOf Row_Click
        Return lbl
    End Function

    ' =====================================================================
    '  Row interaction
    ' =====================================================================
    Private Shared Function GetRow(sender As Object) As Panel
        Dim ctl As Control = DirectCast(sender, Control)
        Return If(TypeOf ctl Is Panel, DirectCast(ctl, Panel), DirectCast(ctl.Parent, Panel))
    End Function

    Private Sub Row_Paint(sender As Object, e As PaintEventArgs)
        Dim row As Control = DirectCast(sender, Control)
        Using pen As New Pen(ColDivider)
            e.Graphics.DrawLine(pen, 0, RowHeight - 1, row.Width, RowHeight - 1)
        End Using
    End Sub

    Private Sub Row_MouseEnter(sender As Object, e As EventArgs)
        GetRow(sender).BackColor = ColRowHover
    End Sub

    Private Sub Row_MouseLeave(sender As Object, e As EventArgs)
        Dim row As Panel = GetRow(sender)
        ' moving from the row onto one of its labels also raises MouseLeave; ignore that
        If Not row.ClientRectangle.Contains(row.PointToClient(Cursor.Position)) Then row.BackColor = Color.White
    End Sub

    Private Sub Row_Click(sender As Object, e As EventArgs)
        Dim row As Panel = GetRow(sender)
        If row.Tag IsNot Nothing Then RaiseEvent PatientSelected(CStr(row.Tag))
    End Sub

    ' =====================================================================
    '  Search box (placeholder + teal focus border)
    ' =====================================================================
    Private Sub SetPlaceholder()
        suppressSearch = True
        showingPlaceholder = True
        txtSearch.Text = SearchPlaceholder
        txtSearch.ForeColor = ColPlaceholder
        suppressSearch = False
    End Sub

    Private Sub txtSearch_Enter(sender As Object, e As EventArgs) Handles txtSearch.Enter
        cardSearch.BorderColor = ColTeal
        If showingPlaceholder Then
            suppressSearch = True
            showingPlaceholder = False
            txtSearch.Text = ""
            txtSearch.ForeColor = ColInputText
            suppressSearch = False
        End If
    End Sub

    Private Sub txtSearch_Leave(sender As Object, e As EventArgs) Handles txtSearch.Leave
        cardSearch.BorderColor = ColSearchBorder
        If txtSearch.Text.Trim().Length = 0 Then SetPlaceholder()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If suppressSearch OrElse showingPlaceholder Then Return
        ApplyFilters()
    End Sub

    Private Sub FocusSearch(sender As Object, e As EventArgs) Handles cardSearch.Click, lblSearchIcon.Click
        txtSearch.Focus()
    End Sub

    ' =====================================================================
    '  Filter dropdowns
    ' =====================================================================
    Private Sub btnFilterAll_Click(sender As Object, e As EventArgs) Handles btnFilterAll.Click
        cmsFilterAll.Show(btnFilterAll, New Point(0, btnFilterAll.Height + 2))
    End Sub

    Private Sub btnFilterVisit_Click(sender As Object, e As EventArgs) Handles btnFilterVisit.Click
        cmsFilterVisit.Show(btnFilterVisit, New Point(0, btnFilterVisit.Height + 2))
    End Sub

    Private Sub FilterItem_Click(sender As Object, e As EventArgs) Handles miFilterAll.Click, miFilterNew.Click, miFilterReturning.Click
        Dim mi As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
        filterMode = CStr(mi.Tag)
        btnFilterAll.Text = mi.Text & Caret
        ApplyFilters()
    End Sub

    Private Sub SortItem_Click(sender As Object, e As EventArgs) Handles miSortNewest.Click, miSortOldest.Click, miSortName.Click, miSortId.Click
        Dim mi As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
        sortMode = CStr(mi.Tag)

        Select Case sortMode
            Case "newest" : btnFilterVisit.Text = "Last visit" & Caret
            Case "oldest" : btnFilterVisit.Text = "Oldest visit" & Caret
            Case "name" : btnFilterVisit.Text = "Name A-Z" & Caret
            Case "id" : btnFilterVisit.Text = "Patient ID" & Caret
        End Select
        ApplyFilters()
    End Sub

    Private Sub btnRegisterPatient_Click(sender As Object, e As EventArgs) Handles btnRegisterPatient.Click
        RaiseEvent RegisterPatientRequested(Me, EventArgs.Empty)
    End Sub

End Class

''' <summary>One row in the patient directory.</summary>
Public Class PatientRecord
    Public Property PatientId As String
    Public Property FullName As String
    Public Property Age As Integer
    Public Property Sex As String
    Public Property Contact As String
    ''' <summary>Nothing = new patient (no visit yet).</summary>
    Public Property LastVisit As Date?
End Class