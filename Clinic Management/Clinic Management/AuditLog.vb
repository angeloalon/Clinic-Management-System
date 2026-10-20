Imports System.IO
Imports System.Linq
Imports System.Text
Imports Ferrando.UI.WinForms.Controles

Public Class AuditLog

    Private Const PageSize As Integer = 10
    Private Const AllUsers As String = "All users"
    Private Const AllActions As String = "All actions"
    Private Const Placeholder As String = "Search by user or action"

    Private Class RowUi
        Public Container As Panel
        Public TimeLbl As Label
        Public UserLbl As Label
        Public RoleLbl As Label
        Public ActionLbl As Label
        Public DetailsLbl As Label
        Public Pill As BadgeLabel
        Public Divider As Panel
    End Class

    Private ReadOnly _rows As New List(Of RowUi)()
    Private _filtered As New List(Of AuditEntry)()
    Private _emptyLbl As Label
    Private _currentPage As Integer = 1

    Private _userFilter As String = AllUsers
    Private _actionFilter As String = AllActions
    Private _days As Integer = -1                ' -1 = all time (past history shows up), 0 = today, 7, 30
    Private _placeholderOn As Boolean = True
    Private ReadOnly _tip As New ToolTip()

    Private paginationCtrl As PaginationControl

    Public Sub New()
        InitializeComponent()

        ' Hide all legacy static 8 designer rows
        For k As Integer = 1 To 8
            Dim p = Ctl(Of Control)("cardResult" & k)
            If p IsNot Nothing Then p.Visible = False
            Dim d = Ctl(Of Control)("divRow" & k)
            If d IsNot Nothing Then d.Visible = False
            For c As Integer = 1 To 5
                Dim l = Ctl(Of Control)("lblRow" & k & "Col" & c)
                If l IsNot Nothing Then l.Visible = False
            Next
        Next

        ' Adjust card and headers to comfortably fit 10 rows + pagination
        cardActivity.Height = 520

        ' Align header labels to exact non-overlapping columns
        If lblCol1 IsNot Nothing Then lblCol1.Location = New Point(16, 49)
        If lblCol2 IsNot Nothing Then lblCol2.Location = New Point(118, 49)
        If lblCol3 IsNot Nothing Then lblCol3.Location = New Point(238, 49)
        If lblCol4 IsNot Nothing Then lblCol4.Location = New Point(345, 49)
        If lblCol5 IsNot Nothing Then lblCol5.Location = New Point(475, 49)
        If lblCol6 IsNot Nothing Then lblCol6.Location = New Point(698, 49)
        If divHeader IsNot Nothing Then divHeader.Location = New Point(16, 70)

        ' Build 10 dynamic rows with proper column bounds
        Dim startY As Integer = 78
        Dim rowH As Integer = 38
        For k As Integer = 0 To PageSize - 1
            Dim yPos As Integer = startY + (k * rowH)
            Dim r As New RowUi()

            r.TimeLbl = New Label With {
                .AutoSize = False,
                .Location = New Point(16, yPos + 6),
                .Size = New Size(96, 20),
                .Font = New Font("Segoe UI", 8.5F),
                .ForeColor = Hx("#4B5F69"),
                .AutoEllipsis = True
            }

            r.UserLbl = New Label With {
                .AutoSize = False,
                .Location = New Point(118, yPos + 6),
                .Size = New Size(114, 20),
                .Font = New Font("Segoe UI", 8.5F),
                .ForeColor = Hx("#232D37"),
                .AutoEllipsis = True
            }

            r.RoleLbl = New Label With {
                .AutoSize = False,
                .Location = New Point(238, yPos + 6),
                .Size = New Size(100, 20),
                .Font = New Font("Segoe UI", 8.5F),
                .ForeColor = Hx("#4B5F69"),
                .AutoEllipsis = True
            }

            r.ActionLbl = New Label With {
                .AutoSize = False,
                .Location = New Point(345, yPos + 6),
                .Size = New Size(125, 20),
                .Font = New Font("Segoe UI", 8.5F),
                .ForeColor = Hx("#4B5F69"),
                .AutoEllipsis = True
            }

            r.DetailsLbl = New Label With {
                .AutoSize = False,
                .Location = New Point(475, yPos + 6),
                .Size = New Size(215, 20),
                .Font = New Font("Segoe UI", 8.5F),
                .ForeColor = Hx("#4B5F69"),
                .AutoEllipsis = True
            }

            r.Pill = New BadgeLabel With {
                .Location = New Point(698, yPos + 5),
                .Size = New Size(62, 22),
                .Font = New Font("Segoe UI", 8.0F, FontStyle.Bold)
            }

            r.Divider = New Panel With {
                .Location = New Point(16, yPos + rowH - 1),
                .Size = New Size(743, 1),
                .BackColor = Hx("#F2F4F7")
            }

            cardActivity.Controls.Add(r.TimeLbl)
            cardActivity.Controls.Add(r.UserLbl)
            cardActivity.Controls.Add(r.RoleLbl)
            cardActivity.Controls.Add(r.ActionLbl)
            cardActivity.Controls.Add(r.DetailsLbl)
            cardActivity.Controls.Add(r.Pill)
            cardActivity.Controls.Add(r.Divider)

            _rows.Add(r)
        Next

        ' Setup pagination footer
        SetupPagination()

        _emptyLbl = New Label With {
            .AutoSize = True,
            .Text = "No matching records.",
            .Font = New Font("Segoe UI", 9.0F),
            .BackColor = Color.White,
            .ForeColor = Hx("#8C9BA5"),
            .Location = New Point(16, 93),
            .Visible = False
        }
        cardActivity.Controls.Add(_emptyLbl)

        btnFilterDate.Text = "All time ▾"

        AddHandler cardSearch.Click, Sub() txtSearch.Focus()
        AddHandler txtSearch.Enter, AddressOf Search_Enter
        AddHandler txtSearch.Leave, AddressOf Search_Leave
        AddHandler txtSearch.TextChanged, Sub()
            If Not _placeholderOn Then
                _currentPage = 1
                Refresh_Rows()
            End If
        End Sub
        AddHandler btnFilterUsers.Click, AddressOf FilterUsers_Click
        AddHandler btnFilterActions.Click, AddressOf FilterActions_Click
        AddHandler btnFilterDate.Click, AddressOf FilterDate_Click
        AddHandler btnExport.Click, AddressOf Export_Click
        AddHandler Me.VisibleChanged, Sub() If Visible Then Refresh_Rows()

        Refresh_Rows()
    End Sub

    Private Sub SetupPagination()
        If paginationCtrl IsNot Nothing Then Return

        paginationCtrl = New PaginationControl With {
            .Location = New Point(16, 466),
            .Size = New Size(743, 38),
            .BackColor = Color.White
        }
        AddHandler paginationCtrl.PageChanged, Sub(newPage)
                                                  _currentPage = newPage
                                                  Refresh_Rows()
                                              End Sub
        cardActivity.Controls.Add(paginationCtrl)
    End Sub

    Private Function Ctl(Of T As Control)(name As String) As T
        Dim found As Control() = Controls.Find(name, True)
        If found.Length = 0 Then Return Nothing
        Return DirectCast(found(0), T)
    End Function

    ' ------------------------------------------------------------------ rows

    Public Sub Refresh_Rows()
        Dim term As String = If(_placeholderOn, "", txtSearch.Text.Trim())

        _filtered = AuditStore.Entries.Where(Function(a) Matches(a, term)) _
                                      .OrderByDescending(Function(a) a.Time).ToList()

        Dim totalCount As Integer = _filtered.Count
        Dim totalPages As Integer = Math.Max(1, CInt(Math.Ceiling(totalCount / CDbl(PageSize))))
        If _currentPage > totalPages Then _currentPage = totalPages
        If _currentPage < 1 Then _currentPage = 1

        Dim paged = _filtered.Skip((_currentPage - 1) * PageSize).Take(PageSize).ToList()

        For i As Integer = 0 To PageSize - 1
            If i < paged.Count Then
                BindRow(_rows(i), paged(i))
            Else
                HideRow(_rows(i))
            End If
        Next

        _emptyLbl.Visible = (totalCount = 0)

        If paginationCtrl IsNot Nothing Then
            paginationCtrl.SetPagination(_currentPage, totalPages, totalCount, PageSize, "entries")
        End If
    End Sub

    Private Function Matches(a As AuditEntry, term As String) As Boolean
        If _userFilter <> AllUsers AndAlso a.UserName <> _userFilter Then Return False
        If _actionFilter <> AllActions AndAlso a.Action <> _actionFilter Then Return False

        If _days = 0 AndAlso a.Time.Date <> DateTime.Today Then Return False
        If _days > 0 AndAlso a.Time < DateTime.Now.AddDays(-_days) Then Return False

        If term.Length > 0 Then
            Dim hay As String = a.UserName & " " & a.Role & " " & a.Action & " " & a.Details
            If hay.IndexOf(term, StringComparison.OrdinalIgnoreCase) < 0 Then Return False
        End If
        Return True
    End Function

    Private Sub HideRow(r As RowUi)
        r.TimeLbl.Visible = False
        r.UserLbl.Visible = False
        r.RoleLbl.Visible = False
        r.ActionLbl.Visible = False
        r.DetailsLbl.Visible = False
        r.Pill.Visible = False
        r.Divider.Visible = False
    End Sub

    Private Sub BindRow(r As RowUi, a As AuditEntry)
        r.TimeLbl.Text = a.Time.ToString("MMM d, h:mm tt")
        r.UserLbl.Text = a.UserName
        r.RoleLbl.Text = a.Role
        r.ActionLbl.Text = a.Action
        r.DetailsLbl.Text = a.Details

        _tip.SetToolTip(r.UserLbl, a.UserName)
        _tip.SetToolTip(r.RoleLbl, a.Role)
        _tip.SetToolTip(r.ActionLbl, a.Action)
        _tip.SetToolTip(r.DetailsLbl, a.Details)

        ApplyResult(r, a.Result)

        r.TimeLbl.Visible = True
        r.UserLbl.Visible = True
        r.RoleLbl.Visible = True
        r.ActionLbl.Visible = True
        r.DetailsLbl.Visible = True
        r.Pill.Visible = True
        r.Divider.Visible = True
    End Sub

    Private Sub ApplyResult(r As RowUi, result As String)
        Dim bg, fg As Color
        Dim w As Integer

        Select Case result
            Case "Denied"
                bg = Hx("#FEF3E2") : fg = Hx("#D97706") : w = 58
            Case "Failed"
                bg = Hx("#FDECEC") : fg = Hx("#CD504B") : w = 54
            Case Else   ' Success
                bg = Hx("#E6F5EB") : fg = Hx("#28874B") : w = 62
        End Select

        r.Pill.FillColor = bg
        r.Pill.ForeColor = fg
        r.Pill.Text = If(String.IsNullOrWhiteSpace(result), "Success", result)
        r.Pill.Width = w
        r.Pill.Location = New Point(698, r.Pill.Location.Y)
        r.Pill.Invalidate()
    End Sub

    ' ------------------------------------------------------------------ search box

    Private Sub Search_Enter(sender As Object, e As EventArgs)
        If _placeholderOn Then
            _placeholderOn = False
            txtSearch.Text = ""
            txtSearch.ForeColor = Hx("#1E2D37")
        End If
    End Sub

    Private Sub Search_Leave(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            _placeholderOn = True
            txtSearch.Text = Placeholder
            txtSearch.ForeColor = Hx("#8C9BA5")
            _currentPage = 1
            Refresh_Rows()
        End If
    End Sub

    ' ------------------------------------------------------------------ filters

    Private Sub FilterUsers_Click(sender As Object, e As EventArgs)
        Dim items As New List(Of String) From {AllUsers}
        items.AddRange(AuditStore.Entries.Select(Function(a) a.UserName).Distinct().OrderBy(Function(s) s))
        ShowMenu(btnFilterUsers, items, _userFilter,
                 Sub(v)
                     _userFilter = v
                     _currentPage = 1
                     btnFilterUsers.Text = Shorten(v) & " ▾"
                 End Sub)
    End Sub

    Private Sub FilterActions_Click(sender As Object, e As EventArgs)
        Dim items As New List(Of String) From {AllActions}
        items.AddRange(AuditStore.Entries.Select(Function(a) a.Action).Distinct().OrderBy(Function(s) s))
        ShowMenu(btnFilterActions, items, _actionFilter,
                 Sub(v)
                     _actionFilter = v
                     _currentPage = 1
                     btnFilterActions.Text = Shorten(v) & " ▾"
                 End Sub)
    End Sub

    Private Sub FilterDate_Click(sender As Object, e As EventArgs)
        Dim menu As New ContextMenuStrip()
        Dim opts As String() = {"Today", "Last 7 days", "Last 30 days", "All time"}
        Dim vals As Integer() = {0, 7, 30, -1}
        For i As Integer = 0 To opts.Length - 1
            Dim label As String = opts(i)
            Dim d As Integer = vals(i)
            Dim mi As ToolStripMenuItem = CType(menu.Items.Add(label), ToolStripMenuItem)
            mi.Checked = (d = _days)
            AddHandler mi.Click, Sub()
                                     _days = d
                                     _currentPage = 1
                                     btnFilterDate.Text = label & " ▾"
                                     Refresh_Rows()
                                 End Sub
        Next
        menu.Show(btnFilterDate, New Point(0, btnFilterDate.Height))
    End Sub

    Private Sub ShowMenu(anchor As Control, items As List(Of String), current As String, onPick As Action(Of String))
        Dim menu As New ContextMenuStrip()
        For Each it As String In items
            Dim choice As String = it
            Dim mi As ToolStripMenuItem = CType(menu.Items.Add(choice), ToolStripMenuItem)
            mi.Checked = (choice = current)
            AddHandler mi.Click, Sub()
                                     onPick(choice)
                                     Refresh_Rows()
                                 End Sub
        Next
        menu.Show(anchor, New Point(0, anchor.Height))
    End Sub

    Private Shared Function Shorten(s As String) As String
        Return If(s.Length > 11, s.Substring(0, 10) & "…", s)
    End Function

    ' ------------------------------------------------------------------ export

    Private Sub Export_Click(sender As Object, e As EventArgs)
        If _filtered.Count = 0 Then
            MessageBox.Show("There are no records to export.", "Audit log",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using dlg As New SaveFileDialog With {
            .Filter = "CSV file (*.csv)|*.csv",
            .FileName = "audit-log-" & DateTime.Now.ToString("yyyyMMdd-HHmm") & ".csv"}
            If dlg.ShowDialog() <> DialogResult.OK Then Return

            Try
                Dim sb As New StringBuilder()
                sb.AppendLine("Time,User,Role,Action,Details,Result")
                For Each a As AuditEntry In _filtered
                    sb.AppendLine(String.Join(",", New String() {
                        Q(a.Time.ToString("yyyy-MM-dd HH:mm")), Q(a.UserName), Q(a.Role),
                        Q(a.Action), Q(a.Details), Q(a.Result)}))
                Next
                File.WriteAllText(dlg.FileName, sb.ToString(), New UTF8Encoding(True))
                AuditStore.Log("Rosa Dela Cruz", "Administrator", "Audit log exported", $"{_filtered.Count} records exported to {Path.GetFileName(dlg.FileName)}", "Success")
                Refresh_Rows()
                MessageBox.Show("Exported " & _filtered.Count & " record(s).", "Audit log",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Export failed: " & ex.Message, "Audit log",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Shared Function Q(v As String) As String
        Return """" & If(v, "").Replace("""", """""") & """"
    End Function

    Private Shared Function Hx(code As String) As Color
        Return ColorTranslator.FromHtml(code)
    End Function

End Class