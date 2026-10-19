Public Class AdminFormSidebar
    Private sidebarHandler As SidebarHandler

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FitToScreen()

        If CurrentUser.IsAuthenticated Then
            txtName.Text = CurrentUser.FullName
            txtRole.Text = CurrentUser.RoleDisplay
        End If

        ' Sidebar now has 4 items:
        '   btnDashboard      = "Dashboard"
        '   btnUserManagement = "User management"
        '   btnClinicSettings = "Clinic settings"
        '   btnAudit          = "Audit log"
        sidebarHandler = New SidebarHandler(btnDashboard, btnUserManagement, btnClinicSettings, btnAudit)

        ' build each page once
        Dim dashForm As New AdminDashboard()
        Dim dash As Control = MakePage(dashForm)
        Dim usersForm As New UserManagement()
        Dim users As Control = MakePage(usersForm)
        Dim settingsForm As New ClinicSettings()
        Dim settings As Control = MakePage(settingsForm)
        Dim audit As Control = MakePage(New AuditLog())

        AddHandler settingsForm.SettingsSaved, Sub()
                                                   Label2.Text = " " & ClinicProfile.ClinicName
                                               End Sub

        ' Wire dashboard shortcut to User management
        AddHandler dashForm.NavigateUsersRequested, Sub()
                                                        If Not ConfirmDiscardWizard() Then Return
                                                        sidebarHandler.SetActive(btnUserManagement)
                                                        usersForm.RefreshData()
                                                        ShowPage(users)
                                                    End Sub

        ' Wire edit user action
        AddHandler usersForm.EditUserRequested,
            Sub(email As String)
                Dim acc = StaffStore.FindByEmail(email)
                If acc Is Nothing Then Return
                Using dlg As New EditUserDialog(acc.Name, acc.Email, acc.Role, acc.Status, acc.Clinic)
                    If dlg.ShowDialog(Me) = DialogResult.OK Then
                        If dlg.WasArchived Then
                            usersForm.RefreshData()
                            dashForm.RefreshDashboard()
                            Return
                        End If
                        acc.Role = dlg.UpdatedRole
                        acc.Status = dlg.UpdatedStatus
                        acc.Clinic = dlg.UpdatedClinic
                        SqliteStaffRepository.UpdateAccount(acc.Email, dlg.UpdatedRole, dlg.UpdatedStatus, dlg.UpdatedClinic)
                        usersForm.RefreshData()
                        dashForm.RefreshDashboard()
                        AuditStore.Log(CurrentUser.FullName, CurrentUser.Role, "User edited", $"{acc.Name} ({acc.Role}, {acc.Status})", "Success")
                    End If
                End Using
            End Sub

        AddHandler btnDashboard.Click, Sub()
                                           If Not ConfirmDiscardWizard() Then Return
                                           dashForm.RefreshDashboard()
                                           ShowPage(dash)
                                       End Sub
        AddHandler btnUserManagement.Click, Sub()
                                                If Not ConfirmDiscardWizard() Then Return
                                                usersForm.RefreshData()
                                                ShowPage(users)
                                            End Sub
        AddHandler btnClinicSettings.Click, Sub()
                                                If Not ConfirmDiscardWizard() Then Return
                                                ShowPage(settings)
                                            End Sub
        AddHandler btnAudit.Click, Sub()
                                       If Not ConfirmDiscardWizard() Then Return
                                       ShowPage(audit)
                                   End Sub

        ' Profile card can also trigger logout / sign out
        AddHandler namePlaceHolder.Click, AddressOf btnLogout_Click
        AddHandler txtName.Click, AddressOf btnLogout_Click
        AddHandler txtRole.Click, AddressOf btnLogout_Click
        namePlaceHolder.Cursor = Cursors.Hand
        txtName.Cursor = Cursors.Hand
        txtRole.Cursor = Cursors.Hand

        sidebarHandler.SetActive(btnDashboard)   ' start on Dashboard
        ShowPage(dash)
        LayoutSidebarBottom()
    End Sub

    Private Sub AdminFormSidebar_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        FitToScreen()
        LayoutSidebarBottom()
    End Sub

    Private Sub AdminFormSidebar_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        LayoutSidebarBottom()
    End Sub

    Private Sub AdminFormSidebar_Move(sender As Object, e As EventArgs) Handles MyBase.Move
        LayoutSidebarBottom()
    End Sub

    ' Keeps the window inside the usable screen area (above the taskbar)
    Private Sub FitToScreen()
        If WindowState <> FormWindowState.Normal Then Return
        Dim wa = Screen.FromControl(Me).WorkingArea
        If Height > wa.Height Then Height = wa.Height
        If Bottom > wa.Bottom Then Top = Math.Max(wa.Top, wa.Bottom - Height)
    End Sub

    Private Sub LayoutSidebarBottom()
        If sideBar Is Nothing OrElse btnLogout Is Nothing OrElse namePlaceHolder Is Nothing Then Return
        If Not IsHandleCreated Then Return

        ' Only use the part of the sidebar that is actually visible on screen
        Dim availH As Integer = sideBar.ClientSize.Height
        Dim wa = Screen.FromControl(Me).WorkingArea
        Dim overflow = sideBar.PointToScreen(New Point(0, availH)).Y - wa.Bottom
        If overflow > 0 Then availH -= overflow

        btnLogout.Top = availH - btnLogout.Height - 16
        namePlaceHolder.Top = btnLogout.Top - namePlaceHolder.Height - 8
        btnLogout.Left = (sideBar.ClientSize.Width - btnLogout.Width) \ 2
        namePlaceHolder.Left = (sideBar.ClientSize.Width - namePlaceHolder.Width) \ 2
    End Sub

    ' Check if user is currently filling AddUser form and warns if dirty
    Private Function ConfirmDiscardWizard() As Boolean
        Dim activeAddUser = mainScreen.Controls.OfType(Of AddUser)().FirstOrDefault()
        If activeAddUser IsNot Nothing AndAlso activeAddUser.IsDirty Then
            Dim res = MessageBox.Show("You have unsaved changes in the Add User wizard. Are you sure you want to leave?",
                                      "Discard Changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If res <> DialogResult.Yes Then
                Return False
            End If
        End If
        Return True
    End Function

    ' makes a form or usercontrol able to sit inside mainScreen
    Private Function MakePage(ctl As Control) As Control
        If TypeOf ctl Is Form Then
            Dim f As Form = DirectCast(ctl, Form)
            f.TopLevel = False
            f.FormBorderStyle = FormBorderStyle.None
        End If
        ctl.Dock = DockStyle.Fill
        Return ctl
    End Function

    ' temporary page until the real form exists
    Private Function MakePlaceholderPage(title As String) As Control
        Dim f As New Form()
        f.BackColor = Color.FromArgb(244, 247, 249)
        f.Controls.Add(New Label() With {
            .AutoSize = False,
            .Dock = DockStyle.Fill,
            .TextAlign = ContentAlignment.MiddleCenter,
            .Font = New Font("Segoe UI", 12.0F),
            .ForeColor = Color.FromArgb(115, 138, 148),
            .Text = title & " page goes here"
        })
        Return MakePage(f)
    End Function

    ' shows one page inside mainScreen
    Private Sub ShowPage(ctl As Control)
        mainScreen.Controls.Clear()
        mainScreen.Controls.Add(ctl)
        ctl.Show()
    End Sub

    Private _isLoggingOut As Boolean = False

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim res = MessageBox.Show("Are you sure you want to log out of the Administrator portal?", "Confirm Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If res = DialogResult.Yes Then
            AuditStore.Log(CurrentUser.FullName, CurrentUser.Role, "Sign-out", "User logged out", "Success")
            CurrentUser.SignOut()
            _isLoggingOut = True
            Dim login = Application.OpenForms.OfType(Of LoginForm)().FirstOrDefault()
            If login IsNot Nothing Then
                login.ResetForm()
                login.Show()
            Else
                Dim newLogin As New LoginForm()
                newLogin.Show()
            End If
            Me.Close()
        End If
    End Sub

    Private Sub AdminFormSidebar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Not _isLoggingOut Then
            Application.Exit()
        End If
    End Sub

End Class