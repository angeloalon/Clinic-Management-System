Imports System.Windows.Forms

Public Class ForgotPasswordDialog

    Public Property ResetEmail As String = ""

    Private Sub ForgotPasswordDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not String.IsNullOrEmpty(ResetEmail) Then
            txtEmail.Text = ResetEmail
        End If
    End Sub

    Private Sub chkAdminOverride_CheckedChanged(sender As Object, e As EventArgs) Handles chkAdminOverride.CheckedChanged
        pnlAdminOverride.Visible = chkAdminOverride.Checked
    End Sub

    Private Sub btnRequestReset_Click(sender As Object, e As EventArgs) Handles btnRequestReset.Click
        Dim email = txtEmail.Text.Trim()
        If String.IsNullOrWhiteSpace(email) Then
            MessageBox.Show("Please enter your work email address.", "Validation Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmail.Focus()
            Return
        End If

        Dim account = StaffStore.FindByEmail(email)
        If account Is Nothing Then
            MessageBox.Show("No staff account was found matching this email address. Please check your spelling or contact your clinic administrator.", "Account Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtEmail.SelectAll()
            txtEmail.Focus()
            Return
        End If

        ' Log request in Audit Store
        Dim token = "RST-" & DateTime.Now.ToString("HHmmss")
        AuditStore.Log(account.Name, account.Role, "Password Reset Requested", $"Staff requested admin assistance. Ref Token: {token} for {email}", "Pending")

        MessageBox.Show($"Password reset request logged successfully!{Environment.NewLine}{Environment.NewLine}Reference Token: {token}{Environment.NewLine}Staff Name: {account.Name} ({account.Role}){Environment.NewLine}{Environment.NewLine}Please notify Clinic Administrator Rosa Dela Cruz to issue you a temporary password or reset your account in User Management.", "Reset Request Logged", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.ResetEmail = email
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnImmediateReset_Click(sender As Object, e As EventArgs) Handles btnImmediateReset.Click
        Dim email = txtEmail.Text.Trim()
        Dim adminKey = txtAdminKey.Text.Trim()
        Dim newPass = txtNewPass.Text.Trim()

        If String.IsNullOrWhiteSpace(email) Then
            MessageBox.Show("Please enter the staff email address.", "Validation Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmail.Focus()
            Return
        End If

        Dim account = StaffStore.FindByEmail(email)
        If account Is Nothing Then
            MessageBox.Show("No staff account was found matching this email address.", "Account Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtEmail.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(adminKey) Then
            MessageBox.Show("Please enter the Clinic Administrator password or master authorization key.", "Admin Authorization Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAdminKey.Focus()
            Return
        End If

        ' Verify Admin Master Key or Admin Password
        ' Acceptable admin authorization: admin password verification or clinic master keys
        Dim isAdminAuthorized As Boolean = False
        If adminKey = "UCC-CLINIC-2026" OrElse adminKey = "admin123" OrElse adminKey = "UCC-ADMIN-RESET" Then
            isAdminAuthorized = True
        Else
            ' Check against actual admin account in database
            Dim adminStaff = SqliteStaffRepository.GetAll().FirstOrDefault(Function(s) s.Role.Equals("Administrator", StringComparison.OrdinalIgnoreCase))
            If adminStaff IsNot Nothing Then
                isAdminAuthorized = SqliteStaffRepository.VerifyPassword(adminStaff.Email, adminKey)
            End If
        End If

        If Not isAdminAuthorized Then
            AuditStore.Log(account.Name, account.Role, "Admin Reset Attempt", $"Unauthorized admin key attempt for {email}", "Denied")
            MessageBox.Show("Invalid Administrator authorization key or password. Reset cannot proceed.", "Authorization Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtAdminKey.SelectAll()
            txtAdminKey.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(newPass) OrElse newPass.Length < 6 Then
            MessageBox.Show("The new password must be at least 6 characters long.", "Validation Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNewPass.Focus()
            Return
        End If

        ' Execute password update
        SqliteStaffRepository.SetPassword(account.Email, newPass)
        SqliteStaffRepository.ResetFailedAttempts(account.Email)
        account.Password = newPass

        AuditStore.Log(account.Name, account.Role, "Password Reset", $"Password reset by administrator for {email}", "Success")

        MessageBox.Show($"Password has been successfully updated for {account.Name}!{Environment.NewLine}You can now sign in immediately with the new password.", "Password Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.ResetEmail = email
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
