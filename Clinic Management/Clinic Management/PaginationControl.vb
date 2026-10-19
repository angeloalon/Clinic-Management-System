Imports System.Drawing
Imports System.Windows.Forms
Imports Ferrando.UI.WinForms.Controles

''' <summary>
''' Reusable pagination control providing entry counts ("Showing 1–10 of 436 entries")
''' and interactive numeric page buttons with Prev / Next navigation.
''' </summary>
Public Class PaginationControl
    Inherits Panel

    Public Event PageChanged(newPage As Integer)

    Private _currentPage As Integer = 1
    Private _totalPages As Integer = 1
    Private _totalCount As Integer = 0
    Private _pageSize As Integer = 10
    Private _itemNoun As String = "entries"

    Private ReadOnly lblInfo As New Label()
    Private ReadOnly pnlButtons As New Panel()
    Private ReadOnly btnPrev As New FButton()
    Private ReadOnly btnNext As New FButton()
    Private ReadOnly _pageButtons As New List(Of Control)()

    Public Sub New()
        DoubleBuffered = True
        SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw, True)
        BackColor = Color.White
        Height = 34

        lblInfo.AutoSize = True
        lblInfo.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular)
        lblInfo.ForeColor = Color.FromArgb(115, 138, 148)
        lblInfo.BackColor = Color.Transparent
        lblInfo.Location = New Point(4, 8)
        Controls.Add(lblInfo)

        pnlButtons.Height = 30
        pnlButtons.BackColor = Color.Transparent
        Controls.Add(pnlButtons)

        btnPrev.Text = "‹ Prev"
        btnPrev.Size = New Size(64, 26)
        btnPrev.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        AddHandler btnPrev.Click, Sub()
                                      If _currentPage > 1 Then
                                          RaiseEvent PageChanged(_currentPage - 1)
                                      End If
                                  End Sub

        btnNext.Text = "Next ›"
        btnNext.Size = New Size(64, 26)
        btnNext.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        AddHandler btnNext.Click, Sub()
                                      If _currentPage < _totalPages Then
                                          RaiseEvent PageChanged(_currentPage + 1)
                                      End If
                                  End Sub
    End Sub

    ''' <summary>
    ''' Updates pagination state and re-renders entry text and numeric buttons.
    ''' </summary>
    Public Sub SetPagination(currentPage As Integer, totalPages As Integer, totalCount As Integer, Optional pageSize As Integer = 10, Optional itemNoun As String = "entries")
        _totalCount = Math.Max(0, totalCount)
        _totalPages = Math.Max(1, totalPages)
        _currentPage = Math.Max(1, Math.Min(currentPage, _totalPages))
        _pageSize = Math.Max(1, pageSize)
        _itemNoun = itemNoun

        If _totalCount = 0 Then
            lblInfo.Text = $"Showing 0 of 0 {_itemNoun}"
            Visible = False
            Return
        End If

        Visible = True
        Dim startIdx = (_currentPage - 1) * _pageSize + 1
        Dim endIdx = Math.Min(_currentPage * _pageSize, _totalCount)
        lblInfo.Text = $"Showing {startIdx}–{endIdx} of {_totalCount} {_itemNoun}"

        RenderButtons()
        LayoutControls()
    End Sub

    Private Sub RenderButtons()
        pnlButtons.SuspendLayout()

        ' Clear previously generated numeric buttons and ellipses
        For Each c In _pageButtons
            pnlButtons.Controls.Remove(c)
            c.Dispose()
        Next
        _pageButtons.Clear()
        pnlButtons.Controls.Remove(btnPrev)
        pnlButtons.Controls.Remove(btnNext)

        ' Previous button
        btnPrev.Location = New Point(0, 2)
        If _currentPage > 1 Then
            btnPrev.Enabled = True
            btnPrev.Cursor = Cursors.Hand
            UIThemeHelper.ApplySecondary(btnPrev)
        Else
            btnPrev.Enabled = False
            btnPrev.Cursor = Cursors.Default
            UIThemeHelper.ApplyDisabled(btnPrev)
        End If
        pnlButtons.Controls.Add(btnPrev)

        Dim curX As Integer = btnPrev.Right + 5
        Dim pages = CalculatePages(_currentPage, _totalPages)

        For Each pageNum In pages
            If pageNum = -1 Then
                ' Ellipsis indicator
                Dim lblDots As New Label With {
                    .Text = "...",
                    .Size = New Size(20, 26),
                    .Location = New Point(curX, 2),
                    .TextAlign = ContentAlignment.MiddleCenter,
                    .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold),
                    .ForeColor = Color.FromArgb(115, 138, 148),
                    .BackColor = Color.Transparent
                }
                pnlButtons.Controls.Add(lblDots)
                _pageButtons.Add(lblDots)
                curX += lblDots.Width + 4
            Else
                Dim p = pageNum
                Dim isCurr = (p = _currentPage)
                Dim btnW = If(p >= 100, 36, 30)
                Dim btnPage As New FButton With {
                    .Text = p.ToString(),
                    .Size = New Size(btnW, 26),
                    .Location = New Point(curX, 2),
                    .Font = New Font("Segoe UI", 8.5F, If(isCurr, FontStyle.Bold, FontStyle.Regular)),
                    .Cursor = If(isCurr, Cursors.Default, Cursors.Hand)
                }
                UIThemeHelper.ApplyPageNumber(btnPage, isCurr)
                If Not isCurr Then
                    AddHandler btnPage.Click, Sub()
                                                  RaiseEvent PageChanged(p)
                                              End Sub
                End If
                pnlButtons.Controls.Add(btnPage)
                _pageButtons.Add(btnPage)
                curX += btnPage.Width + 4
            End If
        Next

        ' Next button
        btnNext.Location = New Point(curX, 2)
        If _currentPage < _totalPages Then
            btnNext.Enabled = True
            btnNext.Cursor = Cursors.Hand
            UIThemeHelper.ApplySecondary(btnNext)
        Else
            btnNext.Enabled = False
            btnNext.Cursor = Cursors.Default
            UIThemeHelper.ApplyDisabled(btnNext)
        End If
        pnlButtons.Controls.Add(btnNext)

        curX += btnNext.Width
        pnlButtons.Width = curX
        pnlButtons.ResumeLayout()
    End Sub

    Private Sub LayoutControls()
        lblInfo.Location = New Point(4, Math.Max(0, (Height - lblInfo.Height) \ 2))
        Dim targetLeft = Math.Max(lblInfo.Right + 8, Width - pnlButtons.Width - 4)
        pnlButtons.Location = New Point(targetLeft, Math.Max(0, (Height - pnlButtons.Height) \ 2))
    End Sub

    Protected Overrides Sub OnResize(eventargs As EventArgs)
        MyBase.OnResize(eventargs)
        LayoutControls()
    End Sub

    ''' <summary>
    ''' Computes the windowed list of page numbers to render. -1 denotes an ellipsis ("...").
    ''' </summary>
    Private Shared Function CalculatePages(current As Integer, total As Integer) As List(Of Integer)
        Dim pages As New List(Of Integer)()
        If total <= 1 Then
            pages.Add(1)
            Return pages
        End If

        If total <= 7 Then
            For i As Integer = 1 To total
                pages.Add(i)
            Next
            Return pages
        End If

        If current <= 4 Then
            For i As Integer = 1 To 5
                pages.Add(i)
            Next
            pages.Add(-1)
            pages.Add(total)
        ElseIf current >= total - 3 Then
            pages.Add(1)
            pages.Add(-1)
            For i As Integer = total - 4 To total
                pages.Add(i)
            Next
        Else
            pages.Add(1)
            pages.Add(-1)
            pages.Add(current - 1)
            pages.Add(current)
            pages.Add(current + 1)
            pages.Add(-1)
            pages.Add(total)
        End If

        Return pages
    End Function

End Class
