Imports System.Drawing
Imports System.Windows.Forms
Imports Ferrando.UI.WinForms.Controles

Public Class ConsultationAccessRequestDialog
    Inherits Form

    Private _apptId As String
    Private _patientId As String
    Private _patientName As String
    Private _doctorName As String

    Private cboReason As ComboBox
    Private txtNotes As TextBox
    Private btnSubmit As FButton
    Private btnCancel As FButton

    Public Sub New(appointmentId As String, patientId As String, patientName As String, doctorName As String)
        _apptId = appointmentId
        _patientId = patientId
        _patientName = patientName
        _doctorName = If(String.IsNullOrWhiteSpace(doctorName), "Attending Physician", doctorName)

        InitializeComponentCustom()
    End Sub

    Private Sub InitializeComponentCustom()
        Me.Text = "Request Consultation Record Access"
        Me.ClientSize = New Size(540, 470)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.BackColor = Color.FromArgb(246, 249, 251)
        Me.Font = New Font("Segoe UI", 9.0F)

        ' 1. Header
        Dim pnlHeader As New Panel With {
            .Dock = DockStyle.Top,
            .Height = 72,
            .BackColor = Color.White
        }
        Dim lblTitle As New Label With {
            .Text = "Request Clinical Record Access",
            .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(22, 51, 65),
            .Location = New Point(20, 14),
            .AutoSize = True
        }
        Dim lblSub As New Label With {
            .Text = "Under RA 10173 (Data Privacy Act), consultation notes require attending physician authorization.",
            .Font = New Font("Segoe UI", 8.25F, FontStyle.Regular),
            .ForeColor = Color.FromArgb(115, 138, 148),
            .Location = New Point(22, 40),
            .AutoSize = True
        }
        pnlHeader.Controls.AddRange(New Control() {lblTitle, lblSub})
        Me.Controls.Add(pnlHeader)

        ' 2. Patient Context Card
        Dim cardContext As New FCard With {
            .Location = New Point(20, 86),
            .Size = New Size(500, 78),
            .BackColor = Color.White,
            .BorderColor = Color.FromArgb(232, 237, 240),
            .BorderHoverColor = Color.FromArgb(232, 237, 240),
            .BorderRadius = 10,
            .BorderSize = 1,
            .EnableShadow = False
        }

        Dim lblPtInfo As New Label With {
            .Text = $"{_patientName} • {_patientId}",
            .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(22, 51, 65),
            .Location = New Point(14, 12),
            .AutoSize = True
        }
        Dim lblApptDoctor As New Label With {
            .Text = $"Appointment: {_apptId}    Attending Doctor: {_doctorName}",
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Regular),
            .ForeColor = Color.FromArgb(90, 115, 125),
            .Location = New Point(14, 34),
            .AutoSize = True
        }
        Dim lblSecurityNote As New Label With {
            .Text = "🛡 Submitting this request sends a notification to the doctor for review.",
            .Font = New Font("Segoe UI", 8.0F, FontStyle.Italic),
            .ForeColor = Color.FromArgb(146, 92, 10),
            .Location = New Point(14, 54),
            .AutoSize = True
        }
        cardContext.Controls.AddRange(New Control() {lblPtInfo, lblApptDoctor, lblSecurityNote})
        Me.Controls.Add(cardContext)

        ' 3. Form Body Card
        Dim cardForm As New FCard With {
            .Location = New Point(20, 174),
            .Size = New Size(500, 222),
            .BackColor = Color.White,
            .BorderColor = Color.FromArgb(232, 237, 240),
            .BorderHoverColor = Color.FromArgb(232, 237, 240),
            .BorderRadius = 10,
            .BorderSize = 1,
            .EnableShadow = False
        }

        Dim lblReasonHeader As New Label With {
            .Text = "BUSINESS PURPOSE / REASON *",
            .Font = New Font("Segoe UI", 8.0F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(90, 110, 120),
            .Location = New Point(14, 14),
            .AutoSize = True
        }

        cboReason = New ComboBox With {
            .Location = New Point(14, 34),
            .Width = 470,
            .DropDownStyle = ComboBoxStyle.DropDownList,
            .Font = New Font("Segoe UI", 9.0F)
        }
        cboReason.Items.AddRange(New Object() {
            "Billing & HMO reimbursement processing",
            "Patient referral / transfer coordination",
            "Medical certificate / clearance preparation",
            "Patient assistance request / verification",
            "Administrative / Legal compliance review",
            "Other (Specify in notes below)"
        })
        cboReason.SelectedIndex = 0

        Dim lblNotesHeader As New Label With {
            .Text = "SPECIFIC JUSTIFICATION / DETAILS (OPTIONAL)",
            .Font = New Font("Segoe UI", 8.0F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(90, 110, 120),
            .Location = New Point(14, 76),
            .AutoSize = True
        }

        txtNotes = New TextBox With {
            .Location = New Point(14, 96),
            .Size = New Size(470, 72),
            .Multiline = True,
            .ScrollBars = ScrollBars.Vertical,
            .Font = New Font("Segoe UI", 9.0F),
            .PlaceholderText = "Provide context for the physician (e.g. PhilHealth verification, insurance query)..."
        }

        Dim lblTimeNotice As New Label With {
            .Text = "⏱ If approved, access will remain active for 2 hours.",
            .Font = New Font("Segoe UI", 8.0F, FontStyle.Regular),
            .ForeColor = Color.FromArgb(115, 135, 145),
            .Location = New Point(14, 185),
            .AutoSize = True
        }

        cardForm.Controls.AddRange(New Control() {lblReasonHeader, cboReason, lblNotesHeader, txtNotes, lblTimeNotice})
        Me.Controls.Add(cardForm)

        ' 4. Bottom Actions
        Dim pnlBottom As New Panel With {
            .Dock = DockStyle.Bottom,
            .Height = 58,
            .BackColor = Color.White
        }

        btnSubmit = New FButton With {
            .Text = "Send Request to Doctor",
            .Size = New Size(180, 36),
            .Location = New Point(210, 11),
            .Cursor = Cursors.Hand,
            .Font = New Font("Segoe UI", 8.75F, FontStyle.Bold)
        }
        UIThemeHelper.ApplyPrimary(btnSubmit)
        AddHandler btnSubmit.Click, AddressOf BtnSubmit_Click

        btnCancel = New FButton With {
            .Text = "Cancel",
            .Size = New Size(95, 36),
            .Location = New Point(400, 11),
            .Cursor = Cursors.Hand,
            .Font = New Font("Segoe UI", 8.75F, FontStyle.Regular),
            .DialogResult = DialogResult.Cancel
        }
        UIThemeHelper.ApplySecondary(btnCancel)

        pnlBottom.Controls.AddRange(New Control() {btnSubmit, btnCancel})
        Me.Controls.Add(pnlBottom)
        Me.CancelButton = btnCancel
    End Sub

    Private Sub BtnSubmit_Click(sender As Object, e As EventArgs)
        Dim reasonText = cboReason.SelectedItem.ToString()
        If Not String.IsNullOrWhiteSpace(txtNotes.Text) Then
            reasonText &= " - " & txtNotes.Text.Trim()
        End If

        Dim userId = If(CurrentUser.IsAuthenticated, CurrentUser.UserId, 0)
        Dim userName = If(CurrentUser.IsAuthenticated, CurrentUser.FullName, "Receptionist")

        SqliteConsultationAccessRepository.CreateRequest(_apptId, _patientId, _patientName, _doctorName,
                                                        userId, userName, reasonText)

        AuditStore.Log(userName, If(CurrentUser.IsAuthenticated, CurrentUser.Role, "Receptionist"),
                       "Consultation record access requested",
                       $"Requested clinical access to {_patientName} ({_patientId}) consultation record from {_doctorName}. Reason: {reasonText}",
                       "Success")

        ClinicData.NotifyDataChanged()

        MessageBox.Show($"Access request sent to {_doctorName}. You will be notified once the doctor accepts or declines your request.",
                        "Request Sent", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

End Class
