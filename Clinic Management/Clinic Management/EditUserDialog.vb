Imports Ferrando.UI.WinForms.Controles

Public Class EditUserDialog

    Public Property UpdatedRole As String
    Public Property UpdatedStatus As String
    Public Property UpdatedClinic As String
    Public Property WasArchived As Boolean = False

    Private _staffName As String = ""
    Private _staffEmail As String = ""
    Private _staffRole As String = ""

    Public Sub New()
        InitializeComponent()
        UIThemeHelper.ApplyPrimary(btnSave)
        UIThemeHelper.ApplySecondary(btnCancel)
        If btnArchiveUser IsNot Nothing Then
            UIThemeHelper.ApplyDanger(btnArchiveUser)
        End If
    End Sub

    Public Sub New(name As String, email As String, role As String, status As String, Optional clinic As String = "UCC Health Clinic")
        Me.New()

        _staffName = name
        _staffEmail = email
        _staffRole = role

        lblStaffName.Text = name
        lblStaffEmail.Text = email

        ' Populate Dropdowns
        cboRole.Items.Clear()
        cboRole.Items.AddRange(New Object() {"Doctor", "Receptionist", "Administrator"})
        If cboRole.Items.Contains(role) Then
            cboRole.SelectedItem = role
        Else
            cboRole.SelectedIndex = 0
        End If

        cboStatus.Items.Clear()
        cboStatus.Items.AddRange(New Object() {"Active", "On leave", "Invited", "Suspended"})
        If cboStatus.Items.Contains(status) Then
            cboStatus.SelectedItem = status
        Else
            cboStatus.SelectedIndex = 0
        End If

        cboClinic.Items.Clear()
        cboClinic.Items.AddRange(New Object() {"UCC Health Clinic"})
        cboClinic.SelectedIndex = 0

        UpdatedRole = cboRole.SelectedItem.ToString()
        UpdatedStatus = cboStatus.SelectedItem.ToString()
        UpdatedClinic = cboClinic.SelectedItem.ToString()
    End Sub

    Private Sub btnArchiveUser_Click(sender As Object, e As EventArgs) Handles btnArchiveUser.Click
        If CurrentUser.IsAuthenticated AndAlso String.Equals(CurrentUser.Email, _staffEmail, StringComparison.OrdinalIgnoreCase) Then
            MessageBox.Show("You cannot delete or archive your own currently active administrator account.",
                            "Action Blocked",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
            Return
        End If

        Dim confirm = MessageBox.Show($"Are you sure you want to delete '{_staffName}' ({_staffRole})?" & vbCrLf & vbCrLf &
                                      "This account will be moved to the Archive and their clinic login access will be deactivated." & vbCrLf &
                                      "You can bring them back at any time from the Archive.",
                                      "Delete Staff Account",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Warning)

        If confirm = DialogResult.Yes Then
            StaffStore.ArchiveAccount(_staffEmail)
            AuditStore.Log(CurrentUser.FullName, CurrentUser.Role, "User archived", $"{_staffName} ({_staffRole}, {_staffEmail}) was moved to archive", "Success")
            WasArchived = True
            MessageBox.Show($"'{_staffName}' has been moved to the archive.", "User Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DialogResult = DialogResult.OK
            Close()
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        UpdatedRole = cboRole.SelectedItem.ToString()
        UpdatedStatus = cboStatus.SelectedItem.ToString()
        UpdatedClinic = cboClinic.SelectedItem.ToString()

        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

End Class
