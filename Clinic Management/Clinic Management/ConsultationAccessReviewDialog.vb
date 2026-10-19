Imports System.Drawing
Imports System.Windows.Forms
Imports Ferrando.UI.WinForms.Controles

Public Class ConsultationAccessReviewDialog
    Inherits Form

    Private lvRequests As ListView
    Private lblDoctorContext As Label
    Private btnRefresh As FButton
    Private btnApprove As FButton
    Private btnDeny As FButton
    Private btnClose As FButton
    Private lblStatusMsg As Label

    ' Dedicated Reason & Justification Display
    Private lblReasonPurpose As Label
    Private lblReasonMeta As Label
    Private txtReasonNotes As TextBox

    Public Sub New()
        InitializeComponentCustom()
        LoadPendingRequests()
    End Sub

    Private Sub InitializeComponentCustom()
        Me.Text = "Consultation Record Access Requests — Doctor Review"
        Me.Size = New Size(880, 620)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.BackColor = Color.FromArgb(244, 247, 249)
        Me.Font = New Font("Segoe UI", 9.0F)

        Dim currentDoc = If(CurrentUser.IsAuthenticated, CurrentUser.FullName, "Doctor")

        ' 1. Top Header
        Dim pnlHeader As New Panel With {
            .Dock = DockStyle.Top,
            .Height = 72,
            .BackColor = Color.White
        }
        Dim lblTitle As New Label With {
            .Text = "Review Consultation Record Access Requests",
            .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(22, 51, 65),
            .Location = New Point(20, 12),
            .AutoSize = True
        }
        Dim lblSub As New Label With {
            .Text = "Under clinical data privacy rules (RA 10173), receptionists require your authorization to view consultation notes.",
            .Font = New Font("Segoe UI", 8.25F, FontStyle.Regular),
            .ForeColor = Color.FromArgb(115, 138, 148),
            .Location = New Point(22, 38),
            .AutoSize = True
        }

        lblDoctorContext = New Label With {
            .Text = $"🩺 Assigned to: {currentDoc}",
            .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(29, 124, 107),
            .Location = New Point(530, 22),
            .Size = New Size(230, 24),
            .TextAlign = ContentAlignment.MiddleRight,
            .UseMnemonic = False
        }

        btnRefresh = New FButton With {
            .Text = "↻ Refresh",
            .Size = New Size(85, 30),
            .Location = New Point(765, 18),
            .Cursor = Cursors.Hand,
            .Font = New Font("Segoe UI", 8.25F, FontStyle.Regular)
        }
        UIThemeHelper.ApplySecondary(btnRefresh)
        AddHandler btnRefresh.Click, Sub() LoadPendingRequests()

        pnlHeader.Controls.AddRange(New Control() {lblTitle, lblSub, lblDoctorContext, btnRefresh})

        ' 2. Center ListView
        lvRequests = New ListView With {
            .Dock = DockStyle.Fill,
            .View = View.Details,
            .FullRowSelect = True,
            .GridLines = True,
            .MultiSelect = False,
            .HideSelection = False,
            .Font = New Font("Segoe UI", 9.0F)
        }
        lvRequests.Columns.Add("Req ID", 65)
        lvRequests.Columns.Add("Patient", 160)
        lvRequests.Columns.Add("Attending Doctor", 140)
        lvRequests.Columns.Add("Requested By", 130)
        lvRequests.Columns.Add("Purpose / Reason", 200)
        lvRequests.Columns.Add("Time Requested", 135)

        AddHandler lvRequests.SelectedIndexChanged, AddressOf LvRequests_SelectedIndexChanged

        ' 3. Bottom Container (Reason Details Panel + Action Bar)
        Dim pnlBottomContainer As New Panel With {
            .Dock = DockStyle.Bottom,
            .Height = 225,
            .BackColor = Color.FromArgb(244, 247, 249)
        }

        ' 3a. Dedicated Reason & Justification Details Card
        Dim cardReasonDetails As New FCard With {
            .Dock = DockStyle.Fill,
            .BackColor = Color.FromArgb(248, 251, 252),
            .BorderColor = Color.FromArgb(215, 228, 235),
            .BorderHoverColor = Color.FromArgb(215, 228, 235),
            .BorderRadius = 8,
            .BorderSize = 1,
            .EnableShadow = False,
            .Padding = New Padding(14, 10, 14, 10)
        }

        Dim lblReasonHeader As New Label With {
            .Text = "📋 RECEPTIONIST'S REASON & ACCESS JUSTIFICATION",
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(22, 51, 65),
            .Location = New Point(14, 8),
            .AutoSize = True,
            .UseMnemonic = False
        }

        lblReasonPurpose = New Label With {
            .Text = "Purpose: (Select a request above)",
            .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(29, 124, 107),
            .Location = New Point(14, 28),
            .AutoSize = True,
            .UseMnemonic = False
        }

        lblReasonMeta = New Label With {
            .Text = "Select a request from the table above to view full details.",
            .Font = New Font("Segoe UI", 8.25F, FontStyle.Regular),
            .ForeColor = Color.FromArgb(115, 138, 148),
            .Location = New Point(14, 48),
            .AutoSize = True,
            .UseMnemonic = False
        }

        txtReasonNotes = New TextBox With {
            .Location = New Point(14, 70),
            .Size = New Size(836, 75),
            .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom,
            .Multiline = True,
            .ReadOnly = True,
            .ScrollBars = ScrollBars.Vertical,
            .BackColor = Color.White,
            .ForeColor = Color.FromArgb(22, 51, 65),
            .Font = New Font("Segoe UI", 9.0F),
            .Text = "← Select an access request from the list above to view the receptionist's business reason and justification notes."
        }

        cardReasonDetails.Controls.AddRange(New Control() {lblReasonHeader, lblReasonPurpose, lblReasonMeta, txtReasonNotes})

        ' 3b. Bottom Action Bar
        Dim pnlBottom As New Panel With {
            .Dock = DockStyle.Bottom,
            .Height = 58,
            .BackColor = Color.White
        }

        lblStatusMsg = New Label With {
            .Text = "Select a request above to accept or decline.",
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Italic),
            .ForeColor = Color.FromArgb(115, 138, 148),
            .Location = New Point(20, 19),
            .AutoSize = True
        }

        btnApprove = New FButton With {
            .Text = "✓ Accept (Grant 2h)",
            .UseMnemonic = False,
            .Size = New Size(170, 36),
            .Location = New Point(420, 11),
            .Cursor = Cursors.Hand,
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
            .Enabled = False
        }
        UIThemeHelper.ApplyPrimary(btnApprove)
        AddHandler btnApprove.Click, AddressOf BtnApprove_Click

        btnDeny = New FButton With {
            .Text = "✕ Decline",
            .Size = New Size(115, 36),
            .Location = New Point(600, 11),
            .Cursor = Cursors.Hand,
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
            .Enabled = False
        }
        UIThemeHelper.ApplyDanger(btnDeny)
        AddHandler btnDeny.Click, AddressOf BtnDeny_Click

        btnClose = New FButton With {
            .Text = "Close",
            .Size = New Size(95, 36),
            .Location = New Point(725, 11),
            .Cursor = Cursors.Hand,
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Regular)
        }
        UIThemeHelper.ApplySecondary(btnClose)
        AddHandler btnClose.Click, Sub() Me.Close()

        pnlBottom.Controls.AddRange(New Control() {lblStatusMsg, btnApprove, btnDeny, btnClose})

        ' Assemble bottom container
        pnlBottomContainer.Controls.Add(cardReasonDetails)
        pnlBottomContainer.Controls.Add(pnlBottom)

        ' Add to Form and configure docking z-order
        Me.Controls.Add(lvRequests)
        Me.Controls.Add(pnlBottomContainer)
        Me.Controls.Add(pnlHeader)

        pnlHeader.SendToBack()
        pnlBottomContainer.SendToBack()
        lvRequests.BringToFront()
    End Sub

    Private Sub LvRequests_SelectedIndexChanged(sender As Object, e As EventArgs)
        If lvRequests.SelectedItems.Count = 0 Then
            btnApprove.Enabled = False
            btnDeny.Enabled = False
            lblReasonPurpose.Text = "Purpose: (None selected)"
            lblReasonPurpose.ForeColor = Color.FromArgb(115, 138, 148)
            lblReasonMeta.Text = "Select a request from the table above."
            txtReasonNotes.Text = "← Select an access request from the list above to view the receptionist's business reason and justification notes."
            lblStatusMsg.Text = "Select a request above to accept or decline."
            Return
        End If

        Dim req = TryCast(lvRequests.SelectedItems(0).Tag, ConsultationAccessRequestRecord)
        If req Is Nothing Then Return

        btnApprove.Enabled = True
        btnDeny.Enabled = True

        ' Parse raw reason into purpose category and specific notes
        Dim rawReason = If(req.Reason, "").Trim()
        Dim purposeText As String = rawReason
        Dim notesText As String = ""

        Dim delimIndex = rawReason.IndexOf(" - ")
        If delimIndex >= 0 Then
            purposeText = rawReason.Substring(0, delimIndex).Trim()
            notesText = rawReason.Substring(delimIndex + 3).Trim()
        End If

        lblReasonPurpose.Text = $"Purpose: {purposeText}"
        lblReasonPurpose.ForeColor = Color.FromArgb(29, 124, 107)

        lblReasonMeta.Text = $"Requested by: {req.RequestedByName} • Patient: {req.PatientName} ({req.PatientId}) • Attending Doctor: {req.DoctorName} • Submitted: {req.RequestedAt}"

        If Not String.IsNullOrWhiteSpace(notesText) Then
            txtReasonNotes.Text = notesText
        ElseIf Not String.IsNullOrWhiteSpace(rawReason) Then
            txtReasonNotes.Text = rawReason
        Else
            txtReasonNotes.Text = "(No additional notes provided by receptionist)"
        End If

        lblStatusMsg.Text = $"Request #{req.Id} selected. Click Accept to authorize 2-hour access."
    End Sub

    Public Sub LoadPendingRequests()
        lvRequests.Items.Clear()
        Dim doctorName = If(CurrentUser.IsAuthenticated, CurrentUser.FullName, "")
        lblDoctorContext.Text = $"🩺 Assigned to: {If(String.IsNullOrWhiteSpace(doctorName), "Doctor", doctorName)}"

        Dim list = SqliteConsultationAccessRepository.GetPendingRequestsForDoctor(doctorName)

        For Each r In list
            Dim item = lvRequests.Items.Add(r.Id.ToString())
            item.SubItems.Add($"{r.PatientName} ({r.PatientId})")
            item.SubItems.Add(If(String.IsNullOrWhiteSpace(r.DoctorName), doctorName, r.DoctorName))
            item.SubItems.Add(r.RequestedByName)
            item.SubItems.Add(r.Reason)
            item.SubItems.Add(r.RequestedAt)
            item.Tag = r
        Next

        If lvRequests.Items.Count > 0 Then
            lvRequests.Items(0).Selected = True
            lblStatusMsg.Text = $"{lvRequests.Items.Count} pending access request(s) assigned to you awaiting review."
            btnApprove.Enabled = True
            btnDeny.Enabled = True
        Else
            lblStatusMsg.Text = "No pending consultation record access requests assigned to you."
            btnApprove.Enabled = False
            btnDeny.Enabled = False
            LvRequests_SelectedIndexChanged(Nothing, EventArgs.Empty)
        End If
    End Sub

    Private Sub BtnApprove_Click(sender As Object, e As EventArgs)
        If lvRequests.SelectedItems.Count = 0 Then Return
        Dim req = TryCast(lvRequests.SelectedItems(0).Tag, ConsultationAccessRequestRecord)
        If req Is Nothing Then Return

        Dim docName = If(CurrentUser.IsAuthenticated, CurrentUser.FullName, "Attending Physician")
        SqliteConsultationAccessRepository.ApproveRequest(req.Id, 2, docName, $"Approved by {docName}")

        AuditStore.Log(docName, If(CurrentUser.IsAuthenticated, CurrentUser.Role, "Doctor"),
                       "Consultation record access approved",
                       $"Doctor approved temporary (2h) clinical record access for {req.PatientName} ({req.PatientId}) to {req.RequestedByName}",
                       "Success")

        ClinicData.NotifyDataChanged()

        MessageBox.Show($"Temporary 2-hour clinical record access approved for {req.RequestedByName} to view {req.PatientName}'s consultation notes.",
                        "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information)

        LoadPendingRequests()
    End Sub

    Private Sub BtnDeny_Click(sender As Object, e As EventArgs)
        If lvRequests.SelectedItems.Count = 0 Then Return
        Dim req = TryCast(lvRequests.SelectedItems(0).Tag, ConsultationAccessRequestRecord)
        If req Is Nothing Then Return

        Dim docName = If(CurrentUser.IsAuthenticated, CurrentUser.FullName, "Attending Physician")
        Dim reason = Microsoft.VisualBasic.Interaction.InputBox("Optional reason for declining access:", "Decline Access Request", "Confidential clinical data")

        SqliteConsultationAccessRepository.DeclineRequest(req.Id, docName, reason)

        AuditStore.Log(docName, If(CurrentUser.IsAuthenticated, CurrentUser.Role, "Doctor"),
                       "Consultation record access declined",
                       $"Doctor declined clinical record access for {req.PatientName} to {req.RequestedByName}. Reason: {reason}",
                       "Success")

        ClinicData.NotifyDataChanged()

        MessageBox.Show($"Access request declined for {req.RequestedByName}.",
                        "Access Declined", MessageBoxButtons.OK, MessageBoxIcon.Information)

        LoadPendingRequests()
    End Sub

End Class
