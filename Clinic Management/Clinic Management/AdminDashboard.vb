Imports System.Drawing.Drawing2D
Imports System.Linq

Public Class AdminDashboard

    Public Event AddUserRequested()
    Public Event NavigateUsersRequested()

    Private Const RowHeight As Integer = 44
    Private _firstName As String = "Rosa"

    ' ------------------------------------------------------------------
    '  Setup
    ' ------------------------------------------------------------------
    Public Sub New()
        InitializeComponent()
        SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        DoubleBuffered = True
    End Sub

    ' Call this after login:  dashboard.SetUser("Rosa")
    Public Sub SetUser(firstName As String)
        _firstName = firstName
        UpdateGreeting()
    End Sub

    Private Sub AdminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateGreeting()
        lblSubtitle.Text = "Clinic administration " & ChrW(&H2022) & " UCC Health Clinic"

        ' Interactive cursors
        cardKpi1.Cursor = Cursors.Hand
        lblKpi1Title.Cursor = Cursors.Hand
        lblKpi1Value.Cursor = Cursors.Hand
        lblKpi1Note.Cursor = Cursors.Hand
        cardKpi4.Cursor = Cursors.Hand
        lblKpi4Title.Cursor = Cursors.Hand
        lblKpi4Value.Cursor = Cursors.Hand
        lblKpi4Note.Cursor = Cursors.Hand
        cardStaff.Cursor = Cursors.Hand
        lblStaffTitle.Cursor = Cursors.Hand

        RefreshDashboard()
    End Sub

    Public Sub RefreshDashboard()
        Dim activeStaff = StaffStore.Accounts.Where(Function(a) a.Status = "Active").Count()
        Dim onLeave = StaffStore.Accounts.Where(Function(a) a.Status = "On leave").Count()
        Dim toReview = StaffStore.Accounts.Where(Function(a) a.Status = "Invited" OrElse a.Status = "Suspended").Count()

        Dim allAppts = ClinicData.Appointments
        Dim todayCount = allAppts.Where(Function(a) a.MatchesDate(DateTime.Today)).Count()
        Dim pendingCount = allAppts.Where(Function(a) a.Status = "Pending").Count()

        lblKpi1Value.Text = activeStaff.ToString()
        lblKpi1Note.Text = $"{StaffStore.Accounts.Count} total accounts"
        lblKpi2Value.Text = todayCount.ToString()
        lblKpi2Note.Text = If(pendingCount = 1, "1 awaiting confirmation", $"{pendingCount} awaiting confirmation")
        lblKpi3Value.Text = onLeave.ToString()
        lblKpi3Note.Text = If(onLeave = 1, "1 staff on leave", $"{onLeave} staff on leave")
        lblKpi4Value.Text = toReview.ToString()
        lblKpi4Note.Text = If(toReview = 1, "1 account to review", $"{toReview} accounts to review")

        BuildActivity()
        BuildRoles(activeStaff)
    End Sub

    Private Sub UpdateGreeting()
        Dim h As Integer = Date.Now.Hour
        Dim part As String = If(h < 12, "Good morning", If(h < 18, "Good afternoon", "Good evening"))
        lblGreeting.Text = part & ", " & _firstName
    End Sub

    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        AddUser.ShowFrom(Me,
                         onFinished:=Sub(created)
                                         If created Then
                                             RefreshDashboard()
                                         End If
                                     End Sub,
                         onUserCreated:=Sub(u)
                                             StaffStore.AddAccount(u.FullName, u.Email, u.Role, "Invited", u.Clinic, u.InviteCode)
                                         End Sub)
    End Sub

    Private Sub cardKpi1_Click(sender As Object, e As EventArgs) Handles cardKpi1.Click, lblKpi1Title.Click, lblKpi1Value.Click, lblKpi1Note.Click,
                                                                         cardKpi4.Click, lblKpi4Title.Click, lblKpi4Value.Click, lblKpi4Note.Click,
                                                                         cardStaff.Click, lblStaffTitle.Click
        RaiseEvent NavigateUsersRequested()
    End Sub

    ' ------------------------------------------------------------------
    '  Recent activity list
    ' ------------------------------------------------------------------
    Private Sub BuildActivity()
        pnlActivity.SuspendLayout()
        pnlActivity.Controls.Clear()

        Dim textFont As New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Dim timeFont As New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))

        Dim logs = AuditStore.Entries.Take(6).ToList()
        If logs.Count = 0 Then
            Dim lblEmpty As New Label With {
                .Text = "No recent activity recorded.",
                .Font = New Font("Segoe UI", 9.0F, FontStyle.Regular),
                .ForeColor = Color.FromArgb(140, 155, 165),
                .TextAlign = ContentAlignment.MiddleCenter,
                .Size = New Size(pnlActivity.Width, 50),
                .Location = New Point(0, 14),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
            }
            pnlActivity.Controls.Add(lblEmpty)
        Else
            Dim y As Integer = 0
            For Each log In logs
                Dim row As New Panel With {
                    .Location = New Point(0, y),
                    .Size = New Size(pnlActivity.Width, RowHeight),
                    .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right,
                    .BackColor = Color.White
                }

                Dim summary = $"{log.UserName} ({log.Role}) • {log.Action}"
                If Not String.IsNullOrWhiteSpace(log.Details) Then
                    summary &= ": " & log.Details
                End If

                row.Controls.Add(New Label With {
                    .AutoSize = False,
                    .AutoEllipsis = True,
                    .BackColor = Color.White,
                    .Font = textFont,
                    .ForeColor = Color.FromArgb(45, 60, 70),
                    .Location = New Point(6, 14),
                    .Size = New Size(Math.Max(50, row.Width - 90), 18),
                    .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right,
                    .Text = summary
                })

                Dim timeStr = If(log.Time.Date = DateTime.Today, log.Time.ToString("h:mm tt"), log.Time.ToString("MMM d"))
                Dim timeW As Integer = TextRenderer.MeasureText(timeStr, timeFont).Width
                row.Controls.Add(New Label With {
                    .AutoSize = True,
                    .BackColor = Color.White,
                    .Font = timeFont,
                    .ForeColor = Color.FromArgb(135, 148, 158),
                    .Location = New Point(row.Width - timeW - 8, 14),
                    .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
                    .Text = timeStr
                })

                row.Controls.Add(New Panel With {
                    .Dock = DockStyle.Bottom,
                    .Height = 1,
                    .BackColor = Color.FromArgb(242, 244, 247)
                })

                pnlActivity.Controls.Add(row)
                y += RowHeight
            Next
        End If

        pnlActivity.ResumeLayout()
    End Sub

    ' ------------------------------------------------------------------
    '  Staff by role
    ' ------------------------------------------------------------------
    Private Sub BuildRoles(activeStaff As Integer)
        Dim docCount = StaffStore.Accounts.Where(Function(a) a.Role = "Doctor").Count()
        Dim recCount = StaffStore.Accounts.Where(Function(a) a.Role = "Receptionist").Count()
        Dim admCount = StaffStore.Accounts.Where(Function(a) a.Role = "Administrator").Count()
        Dim suspendedCount = StaffStore.Accounts.Where(Function(a) a.Status = "Suspended").Count()
        Dim total = StaffStore.Accounts.Count

        Dim names() As Label = {lblRoleName1, lblRoleName2, lblRoleName3}
        Dim counts() As Label = {lblRoleCount1, lblRoleCount2, lblRoleCount3}
        Dim roleCounts() As Integer = {docCount, recCount, admCount}
        Dim roleNames() As String = {"Doctors", "Receptionists", "Administrators"}
        Dim tracks() As Panel = {pnlTrack1, pnlTrack2, pnlTrack3}
        Dim fills() As Panel = {pnlFill1, pnlFill2, pnlFill3}

        For i As Integer = 0 To 2
            names(i).Text = roleNames(i)
            counts(i).Text = roleCounts(i).ToString()
            counts(i).Left = 238 - TextRenderer.MeasureText(counts(i).Text, counts(i).Font).Width - 6

            Dim fillW As Integer = If(total > 0, CInt(tracks(i).Width * roleCounts(i) / total), 0)
            fills(i).Width = fillW
            fills(i).Height = tracks(i).Height
            RoundCorners(tracks(i))
            If fillW >= tracks(i).Height Then
                RoundCorners(fills(i))
            End If
        Next

        lblStaffFooter.Text = activeStaff & " active accounts " & ChrW(&H2022) & " " & suspendedCount & " suspended"
    End Sub

    Private Shared Sub RoundCorners(c As Control)
        Dim d As Integer = c.Height
        Using p As New GraphicsPath()
            p.AddArc(0, 0, d, d, 90, 180)
            p.AddArc(c.Width - d, 0, d, d, 270, 180)
            p.CloseFigure()
            c.Region = New Region(p)
        End Using
    End Sub

End Class

