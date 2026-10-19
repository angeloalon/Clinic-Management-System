Imports System.Drawing.Drawing2D
Imports Ferrando.UI.WinForms.Controles

Public Class UserManagement

    ' ------------------------------------------------------------------
    '  Data model
    ' ------------------------------------------------------------------
    Public Event AddUserRequested()
    Public Event EditUserRequested(email As String)

    Private Const RowHeight As Integer = 44
    Private ReadOnly Arrow As String = " " & ChrW(&H25BE)

    Private _roleFilter As String = "All roles"
    Private _statusFilter As String = "All statuses"

    Private ReadOnly cmsRoles As New ContextMenuStrip()
    Private ReadOnly cmsStatuses As New ContextMenuStrip()

    Private ReadOnly Property _accounts As List(Of StaffAccount)
        Get
            Return StaffStore.Accounts
        End Get
    End Property

    Public Function FindAccount(email As String) As StaffAccount
        Return StaffStore.FindByEmail(email)
    End Function

    Public Sub RefreshData()
        Dim activeCount = StaffStore.Accounts.Count
        lblSubtitle.Text = $"{activeCount} staff accounts " & ChrW(&H2022) & " 3 roles"
        Dim archCount = StaffStore.ArchivedCount
        If btnArchive IsNot Nothing Then
            btnArchive.Text = If(archCount > 0, $"📁 Archive ({archCount})", "📁 Archive (0)")
        End If
        RefreshRows()
    End Sub

    ' column x offsets inside pnlRows (pnlRows.Left = 20)
    Private ReadOnly _colX As Integer() = {0, 106, 284, 368, 440}

    ' ------------------------------------------------------------------
    '  Setup
    ' ------------------------------------------------------------------
    Public Sub New()
        InitializeComponent()
        SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        DoubleBuffered = True
    End Sub

    Private _currentPage As Integer = 1
    Private Const PageSize As Integer = 8

    Private pnlPagination As Panel
    Private lblPageInfo As Label
    Private lblPageNum As Label
    Private btnPrevPage As FButton
    Private btnNextPage As FButton

    Private Sub UserManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblSearchIcon.Font = New Font("Segoe MDL2 Assets", 10.0F)
        lblSearchIcon.Text = ChrW(&HE721)

        If btnArchive IsNot Nothing Then
            UIThemeHelper.ApplySecondary(btnArchive)
        End If

        btnFilterRole.Text = _roleFilter & Arrow
        btnFilterStatus.Text = _statusFilter & Arrow

        BuildMenu(cmsRoles, {"All roles", "Doctor", "Receptionist", "Administrator"},
                  Sub(value)
                      _roleFilter = value
                      _currentPage = 1
                      btnFilterRole.Text = value & Arrow
                      RefreshRows()
                  End Sub)

        BuildMenu(cmsStatuses, {"All statuses", "Active", "On leave", "Invited", "Suspended"},
                  Sub(value)
                      _statusFilter = value
                      _currentPage = 1
                      btnFilterStatus.Text = value & Arrow
                      RefreshRows()
                  End Sub)

        SetupPagination()
        LayoutTable()
        RefreshData()
    End Sub

    Private Sub SetupPagination()
        If pnlPagination IsNot Nothing Then Return

        pnlPagination = New Panel With {
            .Height = 36,
            .BackColor = Color.White,
            .Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        }

        lblPageInfo = New Label With {
            .AutoSize = True,
            .Font = New Font("Segoe UI", 8.5F),
            .ForeColor = Color.FromArgb(115, 138, 148),
            .Location = New Point(0, 10),
            .Text = "Showing 0 of 0 staff"
        }
        pnlPagination.Controls.Add(lblPageInfo)

        btnNextPage = New FButton With {
            .Text = "Next ›",
            .Size = New Size(72, 28),
            .Font = New Font("Segoe UI", 8.0F, FontStyle.Bold),
            .Cursor = Cursors.Hand,
            .Anchor = AnchorStyles.Top Or AnchorStyles.Right
        }
        UIThemeHelper.ApplySecondary(btnNextPage)
        AddHandler btnNextPage.Click, Sub()
            _currentPage += 1
            RefreshRows()
        End Sub

        lblPageNum = New Label With {
            .AutoSize = False,
            .Size = New Size(90, 28),
            .TextAlign = ContentAlignment.MiddleCenter,
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(30, 45, 55),
            .Anchor = AnchorStyles.Top Or AnchorStyles.Right
        }

        btnPrevPage = New FButton With {
            .Text = "‹ Prev",
            .Size = New Size(72, 28),
            .Font = New Font("Segoe UI", 8.0F, FontStyle.Bold),
            .Cursor = Cursors.Hand,
            .Anchor = AnchorStyles.Top Or AnchorStyles.Right
        }
        UIThemeHelper.ApplySecondary(btnPrevPage)
        AddHandler btnPrevPage.Click, Sub()
            _currentPage -= 1
            RefreshRows()
        End Sub

        pnlPagination.Controls.Add(btnPrevPage)
        pnlPagination.Controls.Add(lblPageNum)
        pnlPagination.Controls.Add(btnNextPage)

        cardStaff.Controls.Add(pnlPagination)
    End Sub

    Private Sub UserManagement_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        LayoutTable()
    End Sub

    Private Sub LayoutTable()
        If cardStaff Is Nothing OrElse pnlRows Is Nothing Then Return
        cardStaff.Height = Math.Max(380, ClientSize.Height - cardStaff.Top - 24)
        pnlRows.Height = cardStaff.ClientSize.Height - pnlRows.Top - 52
        If pnlHeaderLine IsNot Nothing Then
            pnlHeaderLine.Width = pnlRows.Width
        End If
        If pnlPagination IsNot Nothing Then
            pnlPagination.Location = New Point(20, cardStaff.ClientSize.Height - 44)
            pnlPagination.Width = cardStaff.ClientSize.Width - 40
            btnNextPage.Location = New Point(pnlPagination.Width - btnNextPage.Width, 4)
            lblPageNum.Location = New Point(btnNextPage.Left - lblPageNum.Width - 4, 4)
            btnPrevPage.Location = New Point(lblPageNum.Left - btnPrevPage.Width - 4, 4)
        End If
    End Sub

    Private Sub BuildMenu(cms As ContextMenuStrip, options As String(), onPick As Action(Of String))
        cms.Font = New Font("Segoe UI", 9.0F)
        cms.ShowImageMargin = False
        cms.Items.Clear()
        For Each opt In options
            Dim value As String = opt
            Dim mi As New ToolStripMenuItem(value)
            AddHandler mi.Click, Sub() onPick(value)
            cms.Items.Add(mi)
        Next
    End Sub

    ' ------------------------------------------------------------------
    '  Events
    ' ------------------------------------------------------------------
    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        AddUser.ShowFrom(Me,
                         onFinished:=Sub(created)
                                         If created Then
                                             RefreshData()
                                         End If
                                     End Sub,
                         onUserCreated:=Sub(u)
                                            StaffStore.AddAccount(u.FullName, u.Email, u.Role, "Invited", u.Clinic, u.InviteCode)
                                        End Sub)
    End Sub

    Private Sub btnArchive_Click(sender As Object, e As EventArgs) Handles btnArchive.Click
        Using dlg As New ArchivedUsersDialog()
            dlg.ShowDialog(Me)
            If dlg.HasChanges Then
                RefreshData()
            End If
        End Using
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        _currentPage = 1
        RefreshRows()
    End Sub

    Private Sub btnFilterRole_Click(sender As Object, e As EventArgs) Handles btnFilterRole.Click
        cmsRoles.Show(btnFilterRole, New Point(0, btnFilterRole.Height + 2))
    End Sub

    Private Sub btnFilterStatus_Click(sender As Object, e As EventArgs) Handles btnFilterStatus.Click
        cmsStatuses.Show(btnFilterStatus, New Point(0, btnFilterStatus.Height + 2))
    End Sub

    ' ------------------------------------------------------------------
    '  Table
    ' ------------------------------------------------------------------
    Private Sub RefreshRows()
        Dim term As String = txtSearch.Text.Trim()

        Dim result As List(Of StaffAccount) =
            _accounts.Where(Function(a)
                                If _roleFilter <> "All roles" AndAlso a.Role <> _roleFilter Then Return False
                                If _statusFilter <> "All statuses" AndAlso a.Status <> _statusFilter Then Return False
                                If term = "" Then Return True
                                Return a.Name.Contains(term, StringComparison.OrdinalIgnoreCase) OrElse
                                       a.Email.Contains(term, StringComparison.OrdinalIgnoreCase)
                            End Function).ToList()

        Dim totalCount As Integer = result.Count
        Dim totalPages As Integer = Math.Max(1, CInt(Math.Ceiling(totalCount / CDbl(PageSize))))
        If _currentPage > totalPages Then _currentPage = totalPages
        If _currentPage < 1 Then _currentPage = 1

        Dim paged As List(Of StaffAccount) = result.Skip((_currentPage - 1) * PageSize).Take(PageSize).ToList()

        SuspendLayout()
        pnlRows.SuspendLayout()

        pnlRows.AutoScrollPosition = New Point(0, 0)

        For i As Integer = pnlRows.Controls.Count - 1 To 0 Step -1
            Dim c As Control = pnlRows.Controls(i)
            pnlRows.Controls.RemoveAt(i)
            c.Dispose()
        Next

        Dim rowWidth As Integer = pnlRows.Width

        Dim y As Integer = 0
        For Each a In paged
            pnlRows.Controls.Add(BuildRow(a, y, rowWidth))
            y += RowHeight
        Next

        lblEmpty.Visible = (totalCount = 0)

        If pnlPagination IsNot Nothing Then
            Dim startIdx = If(totalCount = 0, 0, (_currentPage - 1) * PageSize + 1)
            Dim endIdx = Math.Min(_currentPage * PageSize, totalCount)
            lblPageInfo.Text = $"Showing {startIdx}–{endIdx} of {totalCount} staff"
            lblPageNum.Text = $"Page {_currentPage} of {totalPages}"
            btnPrevPage.Enabled = (_currentPage > 1)
            btnNextPage.Enabled = (_currentPage < totalPages)
            pnlPagination.Visible = (totalCount > 0)
        End If

        pnlRows.ResumeLayout()
        ResumeLayout()
    End Sub

    Private Function BuildRow(a As StaffAccount, y As Integer, rowWidth As Integer) As Panel
        Dim row As New Panel With {
            .Location = New Point(0, y),
            .Size = New Size(rowWidth, RowHeight),
            .BackColor = Color.White
        }

        Dim muted As Color = Color.FromArgb(115, 130, 140)

        row.Controls.Add(MakeCell(a.Name, _colX(0), 104, Color.FromArgb(35, 45, 55), 9.0F))
        row.Controls.Add(MakeCell(a.Email, _colX(1), 172, muted))
        row.Controls.Add(MakeCell(a.Role, _colX(2), 80, muted))

        ' status badge
        Dim fill As Color, fore As Color
        StatusColors(a.Status, fill, fore)
        Dim badgeFont As New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Dim badgeW As Integer = TextRenderer.MeasureText(a.Status, badgeFont).Width + 18
        row.Controls.Add(New BadgeLabel With {
            .Location = New Point(_colX(3), 12),
            .Size = New Size(badgeW, 20),
            .Text = a.Status,
            .Font = badgeFont,
            .FillColor = fill,
            .ForeColor = fore
        })

        row.Controls.Add(MakeCell(a.LastActive, _colX(4), 78, muted))

        ' Edit link
        Dim edit As New Label With {
            .AutoSize = True,
            .BackColor = Color.Transparent,
            .Cursor = Cursors.Hand,
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0)),
            .ForeColor = Color.FromArgb(35, 137, 120),
            .Text = "Edit"
        }
        edit.Location = New Point(row.Width - 36, 13)
        Dim email As String = a.Email
        AddHandler edit.Click, Sub() RaiseEvent EditUserRequested(email)
        row.Controls.Add(edit)
        edit.BringToFront()

        row.Controls.Add(New Panel With {
            .Dock = DockStyle.Bottom,
            .Height = 1,
            .BackColor = Color.FromArgb(242, 244, 247)
        })

        ' hover tint & mouse wheel forwarding
        Dim hoverOn As Action = Sub()
                                    row.BackColor = Color.FromArgb(246, 249, 251)
                                    If Not pnlRows.Focused Then pnlRows.Focus()
                                End Sub
        Dim hoverOff As Action =
            Sub()
                If Not row.ClientRectangle.Contains(row.PointToClient(Cursor.Position)) Then
                    row.BackColor = Color.White
                End If
            End Sub
        AddHandler row.MouseEnter, Sub() hoverOn()
        AddHandler row.MouseLeave, Sub() hoverOff()
        For Each c As Control In row.Controls
            AddHandler c.MouseEnter, Sub() hoverOn()
            AddHandler c.MouseLeave, Sub() hoverOff()
        Next

        Return row
    End Function

    Private Sub ArchiveAccountAction(acc As StaffAccount)
        If acc Is Nothing Then Return

        ' Safeguard: Cannot archive the currently logged-in account
        If CurrentUser.IsAuthenticated AndAlso String.Equals(CurrentUser.Email, acc.Email, StringComparison.OrdinalIgnoreCase) Then
            MessageBox.Show("You cannot delete or archive your own currently active administrator account.",
                            "Action Blocked",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
            Return
        End If

        Dim confirm = MessageBox.Show($"Are you sure you want to delete '{acc.Name}' ({acc.Role})?" & vbCrLf & vbCrLf &
                                      "This account will be moved to the Archive and their clinic login access will be deactivated." & vbCrLf &
                                      "You can bring them back at any time from the Archive.",
                                      "Delete Staff Account",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Warning)

        If confirm = DialogResult.Yes Then
            StaffStore.ArchiveAccount(acc.Email)
            AuditStore.Log(CurrentUser.FullName, CurrentUser.Role, "User archived", $"{acc.Name} ({acc.Role}, {acc.Email}) was moved to archive", "Success")
            RefreshData()
            MessageBox.Show($"'{acc.Name}' has been moved to the archive.", "User Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Shared Sub StatusColors(status As String, ByRef fill As Color, ByRef fore As Color)
        Select Case status
            Case "Active"
                fill = Color.FromArgb(230, 245, 235) : fore = Color.FromArgb(40, 135, 75)
            Case "On leave"
                fill = Color.FromArgb(254, 243, 226) : fore = Color.FromArgb(217, 119, 6)
            Case "Invited"
                fill = Color.FromArgb(230, 240, 250) : fore = Color.FromArgb(55, 105, 160)
            Case Else   ' Suspended
                fill = Color.FromArgb(252, 228, 228) : fore = Color.FromArgb(205, 80, 75)
        End Select
    End Sub

    Private Function MakeCell(text As String, x As Integer, width As Integer, color As Color,
                              Optional size As Single = 8.25F) As Label
        Return New Label With {
            .AutoSize = False,
            .AutoEllipsis = True,
            .BackColor = Color.Transparent,
            .Font = New Font("Segoe UI", size, FontStyle.Regular, GraphicsUnit.Point, CByte(0)),
            .ForeColor = color,
            .Location = New Point(x, 12),
            .Size = New Size(width, 20),
            .Text = text,
            .TextAlign = ContentAlignment.MiddleLeft
        }
    End Function

End Class

' ----------------------------------------------------------------------
'  Small rounded status pill
' ----------------------------------------------------------------------
Friend Class BadgeLabel
    Inherits Control

    Public Property FillColor As Color = Color.FromArgb(230, 245, 235)

    Public Sub New()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or
                 ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw, True)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        e.Graphics.Clear(If(Parent IsNot Nothing, Parent.BackColor, Color.White))
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Dim d As Integer = Height - 1
        Using path As New GraphicsPath()
            path.AddArc(0, 0, d, d, 90, 180)
            path.AddArc(Width - 1 - d, 0, d, d, 270, 180)
            path.CloseFigure()
            Using b As New SolidBrush(FillColor)
                e.Graphics.FillPath(b, path)
            End Using
        End Using

        TextRenderer.DrawText(e.Graphics, Text, Font, New Rectangle(0, 0, Width, Height), ForeColor,
                              TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter Or
                              TextFormatFlags.NoPadding)
    End Sub
End Class

