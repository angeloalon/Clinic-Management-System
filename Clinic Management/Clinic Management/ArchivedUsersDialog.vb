Imports System.Drawing
Imports System.Windows.Forms
Imports Ferrando.UI.WinForms.Controles

Public Class ArchivedUsersDialog
    Inherits Form

    Public Property HasChanges As Boolean = False

    Private txtSearch As TextBox
    Private pnlRows As Panel
    Private lblEmpty As Label
    Private chkSelectAll As CheckBox
    Private btnBringBackSelected As FButton
    Private btnClose As FButton
    Private lblSelectionCount As Label

    Private ReadOnly _rowCheckboxes As New Dictionary(Of StaffAccount, CheckBox)()

    Public Sub New()
        InitializeComponent()
        SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        DoubleBuffered = True
    End Sub

    Private Sub InitializeComponent()
        Me.Text = "Archived Staff Accounts"
        Me.Size = New Size(770, 560)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.BackColor = Color.FromArgb(244, 247, 249)
        Me.Font = New Font("Segoe UI", 9.0F)

        Dim card As New FCard With {
            .Location = New Point(18, 14),
            .Size = New Size(720, 492),
            .BackColor = Color.White,
            .BorderColor = Color.FromArgb(232, 237, 240),
            .BorderRadius = 12,
            .BorderSize = 1,
            .EnableShadow = True,
            .ShadowDepth = 4,
            .HoverTintColor = Color.White
        }

        Dim lblTitle As New Label With {
            .Text = "Archived Staff Accounts",
            .Font = New Font("Segoe UI", 13.0F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(22, 51, 65),
            .Location = New Point(20, 14),
            .AutoSize = True
        }
        card.Controls.Add(lblTitle)

        Dim lblSub As New Label With {
            .Text = "Deleted accounts are safely archived here. Select any staff member to bring back to active status.",
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Regular),
            .ForeColor = Color.FromArgb(115, 138, 148),
            .Location = New Point(20, 40),
            .AutoSize = True
        }
        card.Controls.Add(lblSub)

        ' Search Box
        Dim cardSearch As New FCard With {
            .Location = New Point(20, 70),
            .Size = New Size(680, 36),
            .BackColor = Color.White,
            .BorderColor = Color.FromArgb(220, 228, 232),
            .BorderRadius = 8,
            .BorderSize = 1,
            .EnableShadow = False,
            .HoverTintColor = Color.White
        }

        Dim lblIcon As New Label With {
            .Text = "🔍",
            .Location = New Point(10, 8),
            .Size = New Size(22, 20),
            .Font = New Font("Segoe UI", 9.5F),
            .ForeColor = Color.FromArgb(140, 155, 165)
        }
        cardSearch.Controls.Add(lblIcon)

        txtSearch = New TextBox With {
            .Location = New Point(36, 9),
            .Size = New Size(630, 20),
            .BorderStyle = BorderStyle.None,
            .BackColor = Color.White,
            .Font = New Font("Segoe UI", 9.0F),
            .ForeColor = Color.FromArgb(30, 45, 55),
            .PlaceholderText = "Search archived accounts by name or email..."
        }
        AddHandler txtSearch.TextChanged, Sub() RefreshList()
        cardSearch.Controls.Add(txtSearch)
        card.Controls.Add(cardSearch)

        ' Table Header
        Dim pnlHeader As New Panel With {
            .Location = New Point(20, 116),
            .Size = New Size(680, 28),
            .BackColor = Color.FromArgb(248, 250, 252)
        }

        chkSelectAll = New CheckBox With {
            .Location = New Point(10, 6),
            .Size = New Size(18, 18),
            .Cursor = Cursors.Hand
        }
        AddHandler chkSelectAll.CheckedChanged, AddressOf ChkSelectAll_CheckedChanged
        pnlHeader.Controls.Add(chkSelectAll)

        Dim CreateHeaderLabel = Function(text As String, x As Integer, w As Integer) As Label
                                    Dim l As New Label With {
                                        .Text = text,
                                        .Location = New Point(x, 6),
                                        .Size = New Size(w, 18),
                                        .Font = New Font("Segoe UI", 8.0F, FontStyle.Bold),
                                        .ForeColor = Color.FromArgb(115, 130, 140)
                                    }
                                    Return l
                                End Function

        pnlHeader.Controls.Add(CreateHeaderLabel("STAFF MEMBER", 36, 170))
        pnlHeader.Controls.Add(CreateHeaderLabel("EMAIL ADDRESS", 212, 175))
        pnlHeader.Controls.Add(CreateHeaderLabel("ROLE", 395, 80))
        pnlHeader.Controls.Add(CreateHeaderLabel("ARCHIVED ON", 480, 105))
        pnlHeader.Controls.Add(CreateHeaderLabel("ACTION", 595, 75))
        card.Controls.Add(pnlHeader)

        ' Rows container
        pnlRows = New Panel With {
            .Location = New Point(20, 146),
            .Size = New Size(680, 284),
            .BackColor = Color.White,
            .AutoScroll = True
        }
        card.Controls.Add(pnlRows)

        ' Empty state label
        lblEmpty = New Label With {
            .Text = "📁 No archived accounts found." & vbCrLf & "When a staff account is deleted, it will be kept in this archive.",
            .TextAlign = ContentAlignment.MiddleCenter,
            .Font = New Font("Segoe UI", 9.5F, FontStyle.Regular),
            .ForeColor = Color.FromArgb(140, 155, 165),
            .Location = New Point(20, 220),
            .Size = New Size(680, 60),
            .Visible = False
        }
        card.Controls.Add(lblEmpty)

        ' Footer actions
        lblSelectionCount = New Label With {
            .Location = New Point(20, 444),
            .Size = New Size(200, 24),
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Regular),
            .ForeColor = Color.FromArgb(115, 138, 148),
            .Text = "0 accounts selected",
            .TextAlign = ContentAlignment.MiddleLeft
        }
        card.Controls.Add(lblSelectionCount)

        btnClose = New FButton With {
            .Text = "Close",
            .Size = New Size(80, 32),
            .Location = New Point(620, 440),
            .Cursor = Cursors.Hand,
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        }
        UIThemeHelper.ApplySecondary(btnClose)
        AddHandler btnClose.Click, Sub()
                                       Me.DialogResult = DialogResult.OK
                                       Me.Close()
                                   End Sub
        card.Controls.Add(btnClose)

        btnBringBackSelected = New FButton With {
            .Text = "↩ Bring Back Selected",
            .Size = New Size(155, 32),
            .Location = New Point(455, 440),
            .Cursor = Cursors.Hand,
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
            .Enabled = False
        }
        UIThemeHelper.ApplyPrimary(btnBringBackSelected)
        AddHandler btnBringBackSelected.Click, AddressOf BtnBringBackSelected_Click
        card.Controls.Add(btnBringBackSelected)

        Me.Controls.Add(card)
        Me.CancelButton = btnClose

        AddHandler Me.Load, Sub() RefreshList()
    End Sub

    Private Sub ChkSelectAll_CheckedChanged(sender As Object, e As EventArgs)
        Dim isChecked = chkSelectAll.Checked
        For Each kvp In _rowCheckboxes
            kvp.Value.Checked = isChecked
        Next
        UpdateSelectionState()
    End Sub

    Private Sub UpdateSelectionState()
        Dim count = _rowCheckboxes.Values.Where(Function(c) c.Checked).Count()
        lblSelectionCount.Text = $"{count} account(s) selected"
        btnBringBackSelected.Enabled = (count > 0)
    End Sub

    Private Sub RefreshList()
        pnlRows.SuspendLayout()
        pnlRows.Controls.Clear()
        _rowCheckboxes.Clear()

        Dim term = If(txtSearch IsNot Nothing, txtSearch.Text.Trim(), "")
        Dim list = StaffStore.ArchivedAccounts

        If Not String.IsNullOrEmpty(term) Then
            list = list.Where(Function(a)
                                  Return a.Name.Contains(term, StringComparison.OrdinalIgnoreCase) OrElse
                                         a.Email.Contains(term, StringComparison.OrdinalIgnoreCase) OrElse
                                         a.Role.Contains(term, StringComparison.OrdinalIgnoreCase)
                              End Function).ToList()
        End If

        lblEmpty.Visible = (list.Count = 0)
        chkSelectAll.Enabled = (list.Count > 0)
        If list.Count = 0 Then chkSelectAll.Checked = False

        Dim rowW = pnlRows.Width - 4
        Dim y = 0
        Dim rowH = 42

        For Each acc In list
            Dim item = acc
            Dim row As New Panel With {
                .Location = New Point(0, y),
                .Size = New Size(rowW, rowH),
                .BackColor = Color.White
            }

            ' Checkbox
            Dim chk As New CheckBox With {
                .Location = New Point(10, 13),
                .Size = New Size(18, 18),
                .Cursor = Cursors.Hand
            }
            AddHandler chk.CheckedChanged, Sub() UpdateSelectionState()
            _rowCheckboxes(item) = chk
            row.Controls.Add(chk)

            ' Name
            Dim lblName As New Label With {
                .Text = item.Name,
                .Location = New Point(36, 12),
                .Size = New Size(170, 18),
                .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(30, 45, 55),
                .AutoEllipsis = True
            }
            row.Controls.Add(lblName)

            ' Email
            Dim lblEmail As New Label With {
                .Text = item.Email,
                .Location = New Point(212, 12),
                .Size = New Size(175, 18),
                .Font = New Font("Segoe UI", 8.25F, FontStyle.Regular),
                .ForeColor = Color.FromArgb(115, 130, 140),
                .AutoEllipsis = True
            }
            row.Controls.Add(lblEmail)

            ' Role Pill
            Dim fill As Color, fore As Color
            Select Case item.Role
                Case "Doctor"
                    fill = Color.FromArgb(232, 240, 254) : fore = Color.FromArgb(26, 115, 232)
                Case "Receptionist"
                    fill = Color.FromArgb(254, 243, 226) : fore = Color.FromArgb(217, 119, 6)
                Case Else
                    fill = Color.FromArgb(230, 245, 235) : fore = Color.FromArgb(40, 135, 75)
            End Select

            Dim roleBadge As New BadgeLabel With {
                .Location = New Point(395, 11),
                .Size = New Size(76, 20),
                .Text = item.Role,
                .Font = New Font("Segoe UI", 7.5F, FontStyle.Bold),
                .FillColor = fill,
                .ForeColor = fore
            }
            row.Controls.Add(roleBadge)

            ' Archived Date
            Dim dateText As String = "—"
            If Not String.IsNullOrWhiteSpace(item.ArchivedAt) Then
                Dim dt As DateTime
                If DateTime.TryParse(item.ArchivedAt, dt) Then
                    dateText = dt.ToString("MMM dd, yyyy")
                Else
                    dateText = item.ArchivedAt
                End If
            End If

            Dim lblDate As New Label With {
                .Text = dateText,
                .Location = New Point(480, 12),
                .Size = New Size(105, 18),
                .Font = New Font("Segoe UI", 8.0F),
                .ForeColor = Color.FromArgb(135, 148, 158),
                .AutoEllipsis = True
            }
            row.Controls.Add(lblDate)

            ' Single Bring Back Button
            Dim btnRestore As New FButton With {
                .Text = "↩ Bring Back",
                .Location = New Point(590, 8),
                .Size = New Size(82, 26),
                .Font = New Font("Segoe UI", 7.5F, FontStyle.Bold),
                .Cursor = Cursors.Hand
            }
            UIThemeHelper.ApplyPrimary(btnRestore)
            AddHandler btnRestore.Click, Sub() RestoreSingle(item)
            row.Controls.Add(btnRestore)

            ' Divider
            row.Controls.Add(New Panel With {
                .Dock = DockStyle.Bottom,
                .Height = 1,
                .BackColor = Color.FromArgb(242, 244, 247)
            })

            ' Hover tint
            Dim hoverOn = Sub() row.BackColor = Color.FromArgb(246, 249, 251)
            Dim hoverOff = Sub()
                               If Not row.ClientRectangle.Contains(row.PointToClient(Cursor.Position)) Then
                                   row.BackColor = Color.White
                               End If
                           End Sub
            AddHandler row.MouseEnter, Sub() hoverOn()
            AddHandler row.MouseLeave, Sub() hoverOff()
            For Each c As Control In row.Controls
                If c IsNot chk AndAlso c IsNot btnRestore Then
                    AddHandler c.MouseEnter, Sub() hoverOn()
                    AddHandler c.MouseLeave, Sub() hoverOff()
                End If
            Next

            pnlRows.Controls.Add(row)
            y += rowH
        Next

        UpdateSelectionState()
        pnlRows.ResumeLayout()
    End Sub

    Private Sub RestoreSingle(acc As StaffAccount)
        If acc Is Nothing Then Return

        Dim result = MessageBox.Show($"Are you sure you want to bring back '{acc.Name}' ({acc.Role}) to active staff?" & vbCrLf & vbCrLf &
                                     "Their login credentials will be reactivated and they will reappear in the staff directory.",
                                     "Bring Back Staff Account",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            StaffStore.RestoreAccount(acc.Email)
            AuditStore.Log(CurrentUser.FullName, CurrentUser.Role, "User restored", $"{acc.Name} ({acc.Email}) was restored from archive to active status", "Success")
            HasChanges = True
            RefreshList()
            MessageBox.Show($"'{acc.Name}' has been restored to active staff successfully.", "Account Restored", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub BtnBringBackSelected_Click(sender As Object, e As EventArgs)
        Dim selected = _rowCheckboxes.Where(Function(kvp) kvp.Value.Checked).Select(Function(kvp) kvp.Key).ToList()
        If selected.Count = 0 Then Return

        Dim result = MessageBox.Show($"Are you sure you want to bring back the {selected.Count} selected account(s) to active staff?" & vbCrLf & vbCrLf &
                                     "Their clinic logins will be reactivated and they will reappear in the active staff directory.",
                                     "Bring Back Selected Accounts",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            For Each acc In selected
                StaffStore.RestoreAccount(acc.Email)
                AuditStore.Log(CurrentUser.FullName, CurrentUser.Role, "User restored", $"{acc.Name} ({acc.Email}) was restored from archive", "Success")
            Next
            HasChanges = True
            chkSelectAll.Checked = False
            RefreshList()
            MessageBox.Show($"{selected.Count} staff account(s) have been restored successfully.", "Accounts Restored", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class
