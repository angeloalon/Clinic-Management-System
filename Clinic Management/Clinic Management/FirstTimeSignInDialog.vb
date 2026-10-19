Public Class FirstTimeSignInDialog

    Public Property ActivatedAccount As StaffAccount

    Public Sub New()
        InitializeComponent()
        UIThemeHelper.ApplyPrimary(btnActivate)
        UIThemeHelper.ApplySecondary(btnCancel)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnActivate_Click(sender As Object, e As EventArgs) Handles btnActivate.Click
        Dim email = txtEmail.Text.Trim()
        Dim codeInput = txtCode.Text.Trim()
        Dim pass = txtNewPass.Text
        Dim confirmPass = txtConfirmPass.Text

        If String.IsNullOrWhiteSpace(email) Then
            MessageBox.Show("Please enter your work email address.", "Validation Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmail.Focus()
            Return
        End If

        Dim account = StaffStore.FindByEmail(email)
        If account Is Nothing Then
            MessageBox.Show("No staff account was found matching this email address. Please verify your email or contact your clinic administrator.", "Account Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtEmail.SelectAll()
            txtEmail.Focus()
            Return
        End If

        If account.Status.Equals("Active", StringComparison.OrdinalIgnoreCase) Then
            MessageBox.Show("This account has already been activated. Please return to the sign-in screen and sign in with your password.", "Account Already Active", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If account.Status.Equals("Suspended", StringComparison.OrdinalIgnoreCase) Then
            MessageBox.Show("This account is currently suspended. Please contact your clinic administrator for assistance.", "Account Suspended", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        If String.IsNullOrWhiteSpace(codeInput) Then
            MessageBox.Show("Please enter the 8-character invitation code provided by your administrator.", "Validation Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCode.Focus()
            Return
        End If

        ' Normalize code comparison (strip hyphens and compare case-insensitively)
        Dim cleanInput = codeInput.Replace("-", "").Trim().ToUpperInvariant()
        Dim cleanExpected = If(account.InviteCode, "").Replace("-", "").Trim().ToUpperInvariant()

        If Not String.IsNullOrEmpty(cleanExpected) AndAlso cleanInput <> cleanExpected Then
            MessageBox.Show("The invitation code you entered is invalid or does not match this account. Please check the code and try again.", "Invalid Invitation Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCode.SelectAll()
            txtCode.Focus()
            Return
        End If

        If String.IsNullOrEmpty(pass) OrElse pass.Length < 8 Then
            MessageBox.Show("Please choose a secure password that is at least 8 characters long.", "Password Too Short", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNewPass.SelectAll()
            txtNewPass.Focus()
            Return
        End If

        If pass <> confirmPass Then
            MessageBox.Show("The passwords you entered do not match. Please verify and re-type your password.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtConfirmPass.SelectAll()
            txtConfirmPass.Focus()
            Return
        End If

        ' Activate the account in SQLite database
        account.Status = "Active"
        account.Password = pass
        account.LastActive = "Just now"
        SqliteStaffRepository.SetPassword(account.Email, pass)

        ' Log security audit entries
        AuditStore.Log(account.Name, account.Role, "Invitation used", $"Invite code redeemed ({codeInput.ToUpperInvariant()})", "Success")
        AuditStore.Log(account.Name, account.Role, "Password set", "First-time sign-in activation completed", "Success")

        ActivatedAccount = account

        MessageBox.Show($"Account activated successfully for {account.Name} ({account.Role}). You can now sign in using your new password.", "Account Activated", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

End Class
