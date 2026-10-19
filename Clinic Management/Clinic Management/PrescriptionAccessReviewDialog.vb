Imports System.Drawing
Imports System.Windows.Forms
Imports Ferrando.UI.WinForms.Controles

Public Class PrescriptionAccessReviewDialog
    Inherits Form

    Private lvRequests As ListView
    Private btnApprove As FButton
    Private btnDeny As FButton
    Private btnClose As FButton
    Private lblStatusMsg As Label

    Public Sub New()
        InitializeComponentCustom()
        LoadPendingRequests()
    End Sub

    Private Sub InitializeComponentCustom()
        Me.Text = "Prescription Access Requests — Doctor Review"
        Me.Size = New Size(760, 480)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.BackColor = Color.FromArgb(244, 247, 249)
        Me.Font = New Font("Segoe UI", 9.0F)

        ' Header
        Dim pnlHeader As New Panel With {
            .Dock = DockStyle.Top,
            .Height = 65,
            .BackColor = Color.White
        }
        Dim lblTitle As New Label With {
            .Text = "Review Prescription Access Requests",
            .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(22, 51, 65),
            .Location = New Point(20, 12),
            .AutoSize = True
        }
        Dim lblSub As New Label With {
            .Text = "Under clinical data privacy rules, receptionists require time-limited doctor approval to view medication details.",
            .Font = New Font("Segoe UI", 8.25F, FontStyle.Regular),
            .ForeColor = Color.FromArgb(115, 138, 148),
            .Location = New Point(22, 38),
            .AutoSize = True
        }
        pnlHeader.Controls.AddRange(New Control() {lblTitle, lblSub})
        Me.Controls.Add(pnlHeader)

        ' ListView
        lvRequests = New ListView With {
            .Dock = DockStyle.Fill,
            .View = View.Details,
            .FullRowSelect = True,
            .GridLines = True,
            .Font = New Font("Segoe UI", 8.75F)
        }
        lvRequests.Columns.Add("Req ID", 65)
        lvRequests.Columns.Add("Patient", 150)
        lvRequests.Columns.Add("Requested By", 130)
        lvRequests.Columns.Add("Business Reason", 220)
        lvRequests.Columns.Add("Time Requested", 140)

        ' Bottom Action Bar
        Dim pnlBottom As New Panel With {
            .Dock = DockStyle.Bottom,
            .Height = 60,
            .BackColor = Color.White
        }

        lblStatusMsg = New Label With {
            .Text = "Select a request above to approve or deny.",
            .Font = New Font("Segoe UI", 8.25F, FontStyle.Italic),
            .ForeColor = Color.FromArgb(115, 138, 148),
            .Location = New Point(20, 20),
            .AutoSize = True
        }

        btnApprove = New FButton With {
            .Text = "Approve (2 Hours)",
            .Size = New Size(145, 34),
            .Location = New Point(380, 13),
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        }
        UIThemeHelper.ApplyPrimary(btnApprove)
        AddHandler btnApprove.Click, AddressOf BtnApprove_Click

        btnDeny = New FButton With {
            .Text = "Deny Access",
            .Size = New Size(110, 34),
            .Location = New Point(535, 13),
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        }
        UIThemeHelper.ApplyDanger(btnDeny)
        AddHandler btnDeny.Click, AddressOf BtnDeny_Click

        btnClose = New FButton With {
            .Text = "Close",
            .Size = New Size(85, 34),
            .Location = New Point(655, 13),
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Regular)
        }
        UIThemeHelper.ApplySecondary(btnClose)
        AddHandler btnClose.Click, Sub() Me.Close()

        pnlBottom.Controls.AddRange(New Control() {lblStatusMsg, btnApprove, btnDeny, btnClose})

        Me.Controls.Add(lvRequests)
        Me.Controls.Add(pnlBottom)
    End Sub

    Private Sub LoadPendingRequests()
        lvRequests.Items.Clear()
        Dim doctorId = If(CurrentUser.IsAuthenticated, CurrentUser.UserId, 0)
        Dim list = SqlitePrescriptionAccessRepository.GetPendingRequestsForDoctor(doctorId)

        For Each r In list
            Dim item = lvRequests.Items.Add(r.Id.ToString())
            item.SubItems.Add($"{r.PatientName} ({r.PatientId})")
            item.SubItems.Add(r.RequestedByName)
            item.SubItems.Add(r.Reason)
            item.SubItems.Add(r.RequestedAt)
            item.Tag = r
        Next

        If lvRequests.Items.Count > 0 Then
            lvRequests.Items(0).Selected = True
            lblStatusMsg.Text = $"{lvRequests.Items.Count} pending access request(s) awaiting review."
        Else
            lblStatusMsg.Text = "No pending access requests."
            btnApprove.Enabled = False
            btnDeny.Enabled = False
        End If
    End Sub

    Private Sub BtnApprove_Click(sender As Object, e As EventArgs)
        If lvRequests.SelectedItems.Count = 0 Then Return
        Dim req = TryCast(lvRequests.SelectedItems(0).Tag, PrescriptionAccessRequestRecord)
        If req Is Nothing Then Return

        SqlitePrescriptionAccessRepository.ApproveRequest(req.Id, 2, False, $"Approved by {CurrentUser.FullName}")
        AuditStore.Log(CurrentUser.FullName, CurrentUser.Role, "Prescription access approved",
                       $"Doctor approved temporary (2h) prescription access for {req.PatientName} ({req.PatientId}) to {req.RequestedByName}", "Success")

        MessageBox.Show($"Temporary 2-hour prescription access approved for {req.RequestedByName} to view {req.PatientName}'s prescription.",
                        "Access Approved", MessageBoxButtons.OK, MessageBoxIcon.Information)

        LoadPendingRequests()
    End Sub

    Private Sub BtnDeny_Click(sender As Object, e As EventArgs)
        If lvRequests.SelectedItems.Count = 0 Then Return
        Dim req = TryCast(lvRequests.SelectedItems(0).Tag, PrescriptionAccessRequestRecord)
        If req Is Nothing Then Return

        SqlitePrescriptionAccessRepository.DenyRequest(req.Id, $"Denied by {CurrentUser.FullName}")
        AuditStore.Log(CurrentUser.FullName, CurrentUser.Role, "Prescription access denied",
                       $"Doctor denied prescription access for {req.PatientName} to {req.RequestedByName}", "Success")

        MessageBox.Show($"Prescription access request denied for {req.RequestedByName}.",
                        "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information)

        LoadPendingRequests()
    End Sub

End Class
