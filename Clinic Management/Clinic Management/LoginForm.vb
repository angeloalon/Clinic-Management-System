Public Class LoginForm

    Private Shared _adminFailedAttempts As Integer = 0
    Private Shared _adminLockedUntil As Nullable(Of DateTime) = Nothing
    Private Const MaxAdminAttempts As Integer = 5

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterLoginCard()
        If txtEmail.Text.Trim() = "" Then
            txtEmail.Text = "elena.cruz@uccclinic.edu.ph"
        End If

        ' Quick background check if configured as network client
        If ClinicFilePath.IsNetworkPath() Then
            Dim activePath = ClinicFilePath.GetDatabasePath()
            Task.Run(Sub()
                         Dim latency As Long = 0
                         Dim tables As Integer = 0
                         Dim errMsg As String = ""
                         Dim ok = DatabaseService.TestDatabaseConnection(activePath, latency, tables, errMsg)
                         If Not ok Then
                             Me.BeginInvoke(Sub()
                                                lblNotice.Text = "⚠ Cannot reach host database. Check connection."
                                                lblNotice.ForeColor = Color.FromArgb(205, 80, 75)
                                            End Sub)
                         Else
                             Me.BeginInvoke(Sub()
                                                lblNotice.Text = $"✔ Connected to host ({latency}ms)"
                                                lblNotice.ForeColor = Color.FromArgb(40, 135, 75)
                                            End Sub)
                         End If
                     End Sub)
        End If
    End Sub

    Private Sub LoginForm_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        CenterLoginCard()
    End Sub

    Private Sub CenterLoginCard()
        If rightPanel IsNot Nothing AndAlso cardLogin IsNot Nothing Then
            cardLogin.Left = Math.Max(20, (rightPanel.ClientSize.Width - cardLogin.Width) \ 2)
            cardLogin.Top = Math.Max(20, (rightPanel.ClientSize.Height - cardLogin.Height) \ 2)
        End If
    End Sub

    Private Sub btnTogglePassword_Click(sender As Object, e As EventArgs) Handles btnTogglePassword.Click
        txtPassword.UseSystemPasswordChar = Not txtPassword.UseSystemPasswordChar
        btnTogglePassword.Text = If(txtPassword.UseSystemPasswordChar, "👁", "🔒")
    End Sub

    Private Sub lnkForgotPassword_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkForgotPassword.LinkClicked
        MessageBox.Show(
            "FORGOT PASSWORD" & Environment.NewLine & Environment.NewLine &
            "To reset your clinic account password, please contact the Clinic Administrator:" & Environment.NewLine & Environment.NewLine &
            "• Administrator: Rosa Dela Cruz" & Environment.NewLine &
            "• Email: rosa.delacruz@uccclinic.edu.ph" & Environment.NewLine &
            "• Office: UCC Health Clinic Administration, 2nd Floor" & Environment.NewLine & Environment.NewLine &
            "An administrator can issue a one-time reset code or unlock your account.",
            "Password Reset Assistance", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnSignIn_Click(sender As Object, e As EventArgs) Handles btnSignIn.Click
        PerformLogin()
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            PerformLogin()
        End If
    End Sub

    Private Sub txtEmail_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmail.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            PerformLogin()
        End If
    End Sub

    Private Sub lnkFirstTime_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkFirstTime.LinkClicked
        Using dlg As New FirstTimeSignInDialog()
            If dlg.ShowDialog(Me) = DialogResult.OK AndAlso dlg.ActivatedAccount IsNot Nothing Then
                Dim acc = dlg.ActivatedAccount
                txtEmail.Text = acc.Email
                txtPassword.Text = acc.Password
                txtPassword.Focus()
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Authenticates user and auto-detects their role from database.
    ''' </summary>
    Private Sub PerformLogin()
        Dim email As String = txtEmail.Text.Trim().ToLower()
        Dim password As String = txtPassword.Text.Trim()

        If String.IsNullOrWhiteSpace(email) Then
            MessageBox.Show("Please enter your email address.", "Sign In", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmail.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(password) Then
            MessageBox.Show("Please enter your password.", "Sign In", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return
        End If

        ' Acceptable passwords for seeded demo accounts
        Dim validDoctorPasswords = {"doctor123", "password123", "clinic123", "doctor"}
        Dim validReceptionistPasswords = {"receptionist123", "password123", "clinic123", "receptionist"}
        Dim validAdminPasswords = {"admin123", "password123", "admin", "clinic123"}

        ' Check if staff exists in staff repository (with safe network connection diagnostics)
        Dim staffAcc As StaffAccount = Nothing
        Dim isDbPasswordMatch As Boolean = False
        Dim lockStatus As (IsLocked As Boolean, LockedUntil As Nullable(Of DateTime), FailedAttempts As Integer) = (False, Nothing, 0)

        Try
            staffAcc = StaffStore.FindByEmail(email)
            isDbPasswordMatch = SqliteStaffRepository.VerifyPassword(email, password)
            lockStatus = SqliteStaffRepository.GetLockoutStatus(email)
        Catch ex As Exception
            Dim activeDb = ClinicFilePath.GetDatabasePath()
            Dim isNet = ClinicFilePath.IsNetworkPath()
            Dim msg = $"Could not connect to the clinic database:{Environment.NewLine}{Environment.NewLine}" &
                      $"Target Path: {activeDb}{Environment.NewLine}{Environment.NewLine}" &
                      $"Error Details: {ex.Message}{Environment.NewLine}{Environment.NewLine}"

            If isNet Then
                msg &= "═══════════════════════════════════════════════════════" & Environment.NewLine &
                       "TROUBLESHOOTING CHECKLIST FOR 2 LAPTOPS:" & Environment.NewLine &
                       "═══════════════════════════════════════════════════════" & Environment.NewLine &
                       "1. Make sure Laptop 1 (Host) is running and on the same Wi-Fi / Tailscale." & Environment.NewLine &
                       "2. On Laptop 1, right-click Data folder > Properties > Sharing > Advanced Sharing:" & Environment.NewLine &
                       "   • Check 'Share this folder' as 'data'." & Environment.NewLine &
                       "   • Permissions: Everyone -> Full Control (Read/Write)." & Environment.NewLine &
                       "3. On this laptop (Laptop 2), open File Explorer (Win+R) and test typing:" & Environment.NewLine &
                       "   \\<Host-IP>\data  (verify Windows can open the folder)."
            Else
                msg &= "Please ensure the local database file exists and is not locked by another process."
            End If

            MessageBox.Show(msg, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        If lockStatus.IsLocked Then
            Dim remainingMins As Integer = Math.Max(1, CInt(Math.Ceiling((lockStatus.LockedUntil.Value - DateTime.Now).TotalMinutes)))
            AuditStore.Log(If(staffAcc IsNot Nothing, staffAcc.Name, email), "Staff", "Sign-in attempt", $"Sign-in blocked: account locked for {remainingMins} more min(s)", "Denied")
            MessageBox.Show($"This account is locked due to consecutive failed sign-in attempts.{Environment.NewLine}{Environment.NewLine}Unlock time: {remainingMins} minute(s) remaining (until {lockStatus.LockedUntil.Value:h:mm tt}).{Environment.NewLine}Account: {email}{Environment.NewLine}{Environment.NewLine}This event was recorded in the audit log.", "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return
        End If

        ' Determine the true account role
        Dim actualRole As String = ""
        Dim accountName As String = ""
        If staffAcc IsNot Nothing Then
            actualRole = staffAcc.Role
            accountName = staffAcc.Name

            ' Enforce account status restrictions
            If staffAcc.IsArchived Then
                AuditStore.Log(staffAcc.Name, staffAcc.Role, "Sign-in attempt", "Sign-in blocked: account is archived/deleted", "Denied")
                MessageBox.Show($"This staff account has been deleted or archived.{Environment.NewLine}Please contact clinic administration for assistance.", "Account Inactive", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            ElseIf String.Equals(staffAcc.Status, "Suspended", StringComparison.OrdinalIgnoreCase) Then
                AuditStore.Log(staffAcc.Name, staffAcc.Role, "Sign-in attempt", "Sign-in blocked: account is suspended", "Denied")
                MessageBox.Show($"This account has been suspended by an administrator.{Environment.NewLine}Please contact clinic administration for assistance.", "Account Suspended", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return
            ElseIf String.Equals(staffAcc.Status, "Invited", StringComparison.OrdinalIgnoreCase) Then
                MessageBox.Show($"This account is not yet activated.{Environment.NewLine}Please click 'First time signing in?' below to set your password with your invite code.", "Account Not Activated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
        Else
            ' Fallback inference for standard seeded demo emails
            If email.Contains("rosa") OrElse email.Contains("admin") Then
                actualRole = "Administrator" : accountName = "Rosa Dela Cruz"
            ElseIf email.Contains("diana") OrElse email.Contains("ana") OrElse email.Contains("receptionist") Then
                actualRole = "Receptionist" : accountName = "Ms. Diana Dina"
            ElseIf email.Contains("elena") OrElse email.Contains("marco") OrElse email.Contains("paolo") OrElse email.Contains("doctor") Then
                actualRole = "Doctor" : accountName = "Dr. Elena Cruz"
            End If
        End If

        ' Validate password
        Dim isPasswordValid As Boolean = False
        If isDbPasswordMatch Then
            isPasswordValid = True
        ElseIf staffAcc IsNot Nothing AndAlso Not String.IsNullOrEmpty(staffAcc.Password) AndAlso staffAcc.Password = password Then
            isPasswordValid = True
        Else
            Select Case actualRole
                Case "Administrator"
                    isPasswordValid = validAdminPasswords.Contains(password.ToLower())
                Case "Receptionist"
                    isPasswordValid = validReceptionistPasswords.Contains(password.ToLower())
                Case "Doctor"
                    isPasswordValid = validDoctorPasswords.Contains(password.ToLower())
            End Select
        End If

        If String.IsNullOrEmpty(actualRole) OrElse Not isPasswordValid Then
            Dim attemptResult = SqliteStaffRepository.RecordFailedAttempt(email, MaxAdminAttempts)
            If attemptResult.Locked Then
                AuditStore.Log(If(accountName <> "", accountName, email), If(actualRole <> "", actualRole, "Staff"), "Sign-in attempt", "Account locked for 15 minutes after 5 failed tries", "Locked")
                MessageBox.Show($"You have entered an incorrect password 5 times.{Environment.NewLine}This account is now locked for 15 minutes.{Environment.NewLine}Account: {email}{Environment.NewLine}{Environment.NewLine}This event was recorded in the audit log.", "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                AuditStore.Log(If(accountName <> "", accountName, email), If(actualRole <> "", actualRole, "Staff"), "Sign-in attempt", $"Sign-in failure ({MaxAdminAttempts - attemptResult.Remaining} of 5 tries)", "Failed")
                MessageBox.Show($"Incorrect email or password. {attemptResult.Remaining} of 5 attempts remaining.{Environment.NewLine}Check your password and try again.", "Sign In Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            txtPassword.SelectAll()
            txtPassword.Focus()
            Return
        End If

        ' Successful Authentication -> Reset attempts and route to designated role shell
        SqliteStaffRepository.ResetFailedAttempts(email)
        SqliteStaffRepository.UpdateLastActive(email)
        CurrentUser.SignIn(accountName, email, actualRole, If(staffAcc IsNot Nothing, staffAcc.Clinic, "UCC Health Clinic"))
        AuditStore.Log(CurrentUser.FullName, CurrentUser.Role, "Sign-in", "Signed in securely", "Success")

        Select Case actualRole
            Case "Administrator"
                Dim adminShell As New AdminFormSidebar()
                adminShell.Show()
                Me.Hide()
            Case "Receptionist"
                Dim receptionistDash As New ReceptionistDashboard()
                receptionistDash.Show()
                Me.Hide()
            Case "Doctor"
                Dim doctorShell As New DoctorShell()
                doctorShell.Show()
                Me.Hide()
        End Select
    End Sub

    ''' <summary>
    ''' Resets input fields and restores form state upon user logout.
    ''' </summary>
    Public Sub ResetForm()
        CurrentUser.SignOut()
        txtPassword.Text = ""
        txtPassword.Focus()
    End Sub

End Class
