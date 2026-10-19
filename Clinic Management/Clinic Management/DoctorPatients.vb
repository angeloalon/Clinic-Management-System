Imports Ferrando.UI.WinForms.Controles

Public Class DoctorPatients
    Private sidebarHandler As SidebarHandler
    Private Const SearchPlaceholder As String = "Search name, patient ID, phone..."

    Private _genderFilter As String = "All"
    Private _sortOption As String = "Newest"
    Private _currentPage As Integer = 1
    Private Const PageSize As Integer = 10

    Private cmsFilterAll As ContextMenuStrip
    Private cmsFilterVisit As ContextMenuStrip
    Private pnlPagination As Panel
    Private btnPrevPage As FButton
    Private btnNextPage As FButton
    Private lblPageInfo As Label

    ' ---- responsive layout settings
    Private Const SideBarWidth As Integer = 178
    Private Const PageMargin As Integer = 28
    Private Const MinContentWidth As Integer = 640
    Private Const RowHeight As Integer = 44
    ' column start positions as a fraction of the row width: Patient, ID, Age/sex, Contact, Last visit
    Private ReadOnly ColFractions() As Double = {0.0, 0.22, 0.4, 0.58, 0.78}
    Private _layouting As Boolean = False

    Private Sub DoctorPatients_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sidebarHandler = New SidebarHandler(btnDashboard, btnPatients, btnAppointment,
                                    btnDoctor, btnConsultation, btnReports)

        sidebarHandler.SetActive(btnPatients)   ' start on Patients

        InitializeFilterMenus()
        SetupPaginationControls()
        SetupResponsiveLayout()
        RefreshPatientsList()
        ApplyResponsiveLayout()
    End Sub

    Private Sub DoctorPatients_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Visible Then
            RefreshPatientsList()
        End If
    End Sub

    ' =========================================================================
    ' Responsive layout
    ' =========================================================================

    ' x position of a column, proportional to the row width
    Private Function ColX(col As Integer, rowWidth As Integer) As Integer
        Return 10 + CInt(ColFractions(col) * (rowWidth - 10))
    End Function

    Private Sub SetupResponsiveLayout()
        sideBar.Dock = DockStyle.Left
        sideBar.Width = SideBarWidth

        mainScreen.Dock = DockStyle.Fill
        mainScreen.AutoScroll = True        ' scrolls when the window is too small
        mainScreen.BringToFront()           ' Fill must be laid out after the sidebar

        AddHandler mainScreen.ClientSizeChanged, Sub() ApplyResponsiveLayout()
    End Sub

    Private Sub ApplyResponsiveLayout()
        If _layouting Then Return
        If pnlRowsContainer Is Nothing Then Return
        _layouting = True
        Try
            mainScreen.SuspendLayout()

            Dim contentW As Integer = Math.Max(MinContentWidth, mainScreen.ClientSize.Width - PageMargin * 2)

            ' Search + filter row (filters pinned to the right edge)
            btnFilterVisit.Left = PageMargin + contentW - btnFilterVisit.Width
            btnFilterAll.Left = btnFilterVisit.Left - 12 - btnFilterAll.Width
            cardSearch.Left = PageMargin
            cardSearch.Width = Math.Max(150, btnFilterAll.Left - 12 - PageMargin)
            txtSearch.Width = Math.Max(50, cardSearch.Width - 32 - 30)
            lblClearSearch.Left = cardSearch.Width - 26

            ' Table card
            cardPatientsTable.Left = PageMargin
            cardPatientsTable.Width = contentW
            pnlRowsContainer.Width = contentW - 32
            dividerHeader.Left = pnlRowsContainer.Left
            dividerHeader.Width = pnlRowsContainer.Width

            ' Column headers line up with the row columns
            Dim headers() As Label = {lblColPatient, lblColPatientId, lblColAgeSex, lblColContact, lblColLastVisit}
            For i As Integer = 0 To headers.Length - 1
                headers(i).Left = pnlRowsContainer.Left + ColX(i, pnlRowsContainer.Width)
            Next

            LayoutRows()
            LayoutPagination()

            mainScreen.ResumeLayout()
        Finally
            _layouting = False
        End Try
    End Sub

    ' Re-positions existing rows without rebuilding them
    Private Sub LayoutRows()
        Dim w As Integer = pnlRowsContainer.Width
        For Each ctl As Control In pnlRowsContainer.Controls
            ctl.Width = w
            If TypeOf ctl Is Panel Then
                For Each child As Control In ctl.Controls
                    If TypeOf child Is Label AndAlso TypeOf child.Tag Is Integer Then
                        Dim col As Integer = CInt(child.Tag)
                        Dim x As Integer = ColX(col, w)
                        Dim nextX As Integer = If(col < ColFractions.Length - 1, ColX(col + 1, w), w)
                        child.Left = x
                        child.Width = Math.Max(30, nextX - x - 8)
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub LayoutPagination()
        If pnlPagination Is Nothing Then Return
        btnPrevPage.Location = New Point(10, 7)
        btnNextPage.Location = New Point(Math.Max(btnPrevPage.Right + 10, pnlPagination.Width - btnNextPage.Width - 10), 7)
        lblPageInfo.Left = btnPrevPage.Right + 15
        lblPageInfo.Width = Math.Max(50, btnNextPage.Left - lblPageInfo.Left - 15)
        lblPageInfo.TextAlign = ContentAlignment.MiddleCenter
    End Sub

    Private Sub SetupPaginationControls()
        If pnlPagination IsNot Nothing Then Return
        pnlPagination = New Panel With {
            .Height = 44,
            .Dock = DockStyle.Bottom,
            .BackColor = Color.White
        }

        btnPrevPage = New FButton With {
            .Text = "‹ Previous",
            .Size = New Size(90, 30),
            .Location = New Point(10, 7),
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        }
        UIThemeHelper.ApplySecondary(btnPrevPage)
        AddHandler btnPrevPage.Click, Sub()
                                          If _currentPage > 1 Then
                                              _currentPage -= 1
                                              RefreshPatientsList()
                                          End If
                                      End Sub

        lblPageInfo = New Label With {
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Regular),
            .ForeColor = Color.FromArgb(100, 120, 130),
            .AutoSize = False,
            .Size = New Size(240, 30),
            .Location = New Point(125, 7),
            .TextAlign = ContentAlignment.MiddleCenter
        }

        btnNextPage = New FButton With {
            .Text = "Next ›",
            .Size = New Size(90, 30),
            .Location = New Point(380, 7),
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        }
        UIThemeHelper.ApplySecondary(btnNextPage)
        AddHandler btnNextPage.Click, Sub()
                                          _currentPage += 1
                                          RefreshPatientsList()
                                      End Sub

        pnlPagination.Controls.AddRange(New Control() {btnPrevPage, lblPageInfo, btnNextPage})
        AddHandler pnlPagination.Resize, Sub() LayoutPagination()
        cardPatientsTable.Controls.Add(pnlPagination)
        pnlPagination.BringToFront()
    End Sub

    ' ------------------------------------------------------------------ sidebar navigation

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        If DoctorShell.Current IsNot Nothing Then
            DoctorShell.Current.NavigateTo(DoctorTab.Dashboard)
        Else
            Dim docDash As New DoctorDashboard()
            docDash.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub btnPatients_Click(sender As Object, e As EventArgs) Handles btnPatients.Click
        If DoctorShell.Current IsNot Nothing Then DoctorShell.Current.NavigateTo(DoctorTab.Patients)
    End Sub

    Private Sub btnAppointment_Click(sender As Object, e As EventArgs) Handles btnAppointment.Click
        If DoctorShell.Current IsNot Nothing Then
            DoctorShell.Current.NavigateTo(DoctorTab.Appointments)
        Else
            Dim f As New DoctorAppointment()
            f.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub btnDoctor_Click(sender As Object, e As EventArgs) Handles btnDoctor.Click
        If DoctorShell.Current IsNot Nothing Then
            DoctorShell.Current.NavigateTo(DoctorTab.Schedule)
        Else
            Dim f As New DoctorSchedule()
            f.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub btnConsultation_Click(sender As Object, e As EventArgs) Handles btnConsultation.Click
        If DoctorShell.Current IsNot Nothing Then
            DoctorShell.Current.NavigateTo(DoctorTab.Consultation)
        Else
            Dim f As New DoctorConsultation()
            f.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        If DoctorShell.Current IsNot Nothing Then
            DoctorShell.Current.NavigateTo(DoctorTab.Reports)
        Else
            Dim f As New DoctorReports()
            f.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub DoctorPatients_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If DoctorShell.Current Is Nothing Then
            Application.Exit()
        End If
    End Sub


    ' =========================================================================
    ' Dropdown Filter Menus
    ' =========================================================================
    Private Sub InitializeFilterMenus()
        ' Dropdown for All patients (gender / category filter)
        cmsFilterAll = New ContextMenuStrip()
        cmsFilterAll.Font = New Font("Segoe UI", 9.0F)

        Dim itemAll = cmsFilterAll.Items.Add("All patients")
        AddHandler itemAll.Click, Sub() SetGenderFilter("All", "All patients  ▾")

        Dim itemFemale = cmsFilterAll.Items.Add("Female only")
        AddHandler itemFemale.Click, Sub() SetGenderFilter("Female", "Female  ▾")

        Dim itemMale = cmsFilterAll.Items.Add("Male only")
        AddHandler itemMale.Click, Sub() SetGenderFilter("Male", "Male  ▾")

        ' Dropdown for Last visit (sorting filter)
        cmsFilterVisit = New ContextMenuStrip()
        cmsFilterVisit.Font = New Font("Segoe UI", 9.0F)

        Dim itemNewest = cmsFilterVisit.Items.Add("Newest visit first")
        AddHandler itemNewest.Click, Sub() SetSortOption("Newest", "Newest  ▾")

        Dim itemOldest = cmsFilterVisit.Items.Add("Oldest visit first")
        AddHandler itemOldest.Click, Sub() SetSortOption("Oldest", "Oldest  ▾")

        Dim itemAlpha = cmsFilterVisit.Items.Add("Name (A - Z)")
        AddHandler itemAlpha.Click, Sub() SetSortOption("NameAZ", "Name (A-Z)  ▾")

        Dim itemPatientId = cmsFilterVisit.Items.Add("Patient ID")
        AddHandler itemPatientId.Click, Sub() SetSortOption("PatientID", "ID  ▾")
    End Sub

    Private Sub btnFilterAll_Click(sender As Object, e As EventArgs) Handles btnFilterAll.Click
        cmsFilterAll.Show(btnFilterAll, 0, btnFilterAll.Height)
    End Sub

    Private Sub btnFilterVisit_Click(sender As Object, e As EventArgs) Handles btnFilterVisit.Click
        cmsFilterVisit.Show(btnFilterVisit, 0, btnFilterVisit.Height)
    End Sub

    Private Sub SetGenderFilter(gender As String, buttonText As String)
        _genderFilter = gender
        _currentPage = 1
        btnFilterAll.Text = buttonText
        RefreshPatientsList()
    End Sub

    Private Sub SetSortOption(sort As String, buttonText As String)
        _sortOption = sort
        _currentPage = 1
        btnFilterVisit.Text = buttonText
        RefreshPatientsList()
    End Sub

    ' =========================================================================
    ' Search Input UX
    ' =========================================================================
    Private Sub txtSearch_GotFocus(sender As Object, e As EventArgs) Handles txtSearch.GotFocus
        If txtSearch.Text = SearchPlaceholder Then
            txtSearch.Text = ""
            txtSearch.ForeColor = Color.FromArgb(30, 45, 55)
        End If
    End Sub

    Private Sub txtSearch_LostFocus(sender As Object, e As EventArgs) Handles txtSearch.LostFocus
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            txtSearch.Text = SearchPlaceholder
            txtSearch.ForeColor = Color.FromArgb(100, 120, 130)
            lblClearSearch.Visible = False
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text = SearchPlaceholder Then
            lblClearSearch.Visible = False
            Return
        End If
        _currentPage = 1
        lblClearSearch.Visible = Not String.IsNullOrWhiteSpace(txtSearch.Text)
        RefreshPatientsList()
    End Sub

    Private Sub lblClearSearch_Click(sender As Object, e As EventArgs) Handles lblClearSearch.Click
        txtSearch.Text = ""
        _currentPage = 1
        txtSearch_LostFocus(Nothing, Nothing)
        RefreshPatientsList()
    End Sub

    ' =========================================================================
    ' Dynamic Patient Rendering & Filtering
    ' =========================================================================

    ' Builds one table cell label; col is stored in Tag so LayoutRows can reposition it
    Private Function CreateCell(text As String, fontSize As Single, color As Color, col As Integer) As Label
        Return New Label With {
            .Text = text,
            .Font = New Font("Segoe UI", fontSize, FontStyle.Regular),
            .ForeColor = color,
            .AutoSize = False,
            .AutoEllipsis = True,
            .Size = New Size(100, 18),
            .Location = New Point(10, 12),
            .Cursor = Cursors.Hand,
            .Tag = col
        }
    End Function

    Private Sub RefreshPatientsList()
        Dim currentDoc = If(CurrentUser.IsAuthenticated, CurrentUser.FullName, "Dr. Elena Cruz")
        Dim all = PatientRepository.GetPatientsForDoctor(currentDoc)

        ' Update dynamic header subtitle to real database patient count
        If lblHeaderSubtitle IsNot Nothing Then
            lblHeaderSubtitle.Text = String.Format(Globalization.CultureInfo.InvariantCulture, "{0:N0} registered patients • Assigned to your care", all.Count)
        End If

        ' 1. Filter by Search Query
        Dim query As String = ""
        If txtSearch.Text <> SearchPlaceholder Then
            query = txtSearch.Text.Trim().ToLower()
        End If

        Dim filtered = all.Where(Function(p)
                                     Dim matchSearch = String.IsNullOrWhiteSpace(query) OrElse
                                                       p.Name.ToLower().Contains(query) OrElse
                                                       p.PatientId.ToLower().Contains(query) OrElse
                                                       p.Contact.Replace(" ", "").Contains(query.Replace(" ", "")) OrElse
                                                       p.Email.ToLower().Contains(query) OrElse
                                                       p.KnownConditions.ToLower().Contains(query) OrElse
                                                       p.DrugAllergies.ToLower().Contains(query)

                                     Dim matchGender = True
                                     If _genderFilter = "Female" Then
                                         matchGender = p.Gender.Equals("Female", StringComparison.OrdinalIgnoreCase)
                                     ElseIf _genderFilter = "Male" Then
                                         matchGender = p.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase)
                                     End If

                                     Return matchSearch AndAlso matchGender
                                 End Function).ToList()

        ' Update patient count indicator
        If lblPatientCount IsNot Nothing Then
            If Not String.IsNullOrWhiteSpace(query) OrElse _genderFilter <> "All" Then
                lblPatientCount.Text = "• " & filtered.Count & " of " & all.Count & " patients"
            Else
                lblPatientCount.Text = "• " & all.Count & " registered"
            End If
        End If

        ' 2. Sort Patients
        Select Case _sortOption
            Case "Newest"
                filtered = filtered.OrderByDescending(Function(p) p.LastVisitDate).ToList()
            Case "Oldest"
                filtered = filtered.OrderBy(Function(p) p.LastVisitDate).ToList()
            Case "NameAZ"
                filtered = filtered.OrderBy(Function(p) p.Name).ToList()
            Case "PatientID"
                filtered = filtered.OrderBy(Function(p) p.PatientId).ToList()
        End Select

        ' 3. Calculate Pagination
        Dim totalPages = Math.Max(1, CInt(Math.Ceiling(filtered.Count / CDbl(PageSize))))
        If _currentPage > totalPages Then _currentPage = totalPages
        If _currentPage < 1 Then _currentPage = 1

        If lblPageInfo IsNot Nothing Then
            lblPageInfo.Text = $"Page {_currentPage} of {totalPages} ({filtered.Count} patients)"
        End If
        If btnPrevPage IsNot Nothing Then
            btnPrevPage.Enabled = (_currentPage > 1)
        End If
        If btnNextPage IsNot Nothing Then
            btnNextPage.Enabled = (_currentPage < totalPages)
        End If

        Dim pageItems = filtered.Skip((_currentPage - 1) * PageSize).Take(PageSize).ToList()

        ' 4. Render dynamically in pnlRowsContainer
        pnlRowsContainer.SuspendLayout()

        ' dispose old rows so they don't leak GDI handles
        Dim oldRows = pnlRowsContainer.Controls.Cast(Of Control)().ToList()
        pnlRowsContainer.Controls.Clear()
        For Each oldRow In oldRows
            oldRow.Dispose()
        Next

        If pageItems.Count = 0 Then
            Dim emptyMsg = If(all.Count = 0, "No registered patients assigned to your schedule yet.", "No patients match your search or filter.")
            Dim lblEmpty As New Label With {
                .Text = emptyMsg,
                .Font = New Font("Segoe UI", 9.5F, FontStyle.Regular),
                .ForeColor = Color.FromArgb(140, 155, 165),
                .TextAlign = ContentAlignment.MiddleCenter,
                .Size = New Size(pnlRowsContainer.Width, 50),
                .Location = New Point(0, 10)
            }
            pnlRowsContainer.Controls.Add(lblEmpty)
            pnlRowsContainer.Height = 60
        Else
            Dim mutedColor = Color.FromArgb(110, 125, 135)

            For i As Integer = 0 To pageItems.Count - 1
                Dim patient = pageItems(i)
                Dim rowPanel As New Panel With {
                    .Size = New Size(pnlRowsContainer.Width, RowHeight),
                    .Location = New Point(0, i * RowHeight),
                    .BackColor = Color.White,
                    .Cursor = Cursors.Hand
                }

                Dim displayName = ValidationHelper.NormalizeProperCase(patient.Name)
                Dim lblPatient = CreateCell(displayName, 9.0F, Color.FromArgb(35, 45, 55), 0)
                Dim lblId = CreateCell(patient.PatientId, 8.5F, mutedColor, 1)
                Dim lblAgeSex = CreateCell(patient.Age & " • " & patient.Gender, 8.5F, mutedColor, 2)
                Dim lblContact = CreateCell(patient.Contact, 8.5F, mutedColor, 3)
                Dim lblVisit = CreateCell(patient.LastVisitDisplay, 8.5F, mutedColor, 4)

                Dim divRow As New Panel With {
                    .Height = 1,
                    .Dock = DockStyle.Bottom,
                    .BackColor = Color.FromArgb(242, 244, 247)
                }

                ' Click event opens PatientInformation
                Dim patId = patient.PatientId
                Dim clickAction = Sub(s As Object, ev As EventArgs) OpenPatient(patId)

                AddHandler rowPanel.Click, clickAction
                AddHandler lblPatient.Click, clickAction
                AddHandler lblId.Click, clickAction
                AddHandler lblAgeSex.Click, clickAction
                AddHandler lblContact.Click, clickAction
                AddHandler lblVisit.Click, clickAction

                ' Hover effect
                Dim hoverEnter = Sub() rowPanel.BackColor = Color.FromArgb(246, 249, 251)
                Dim hoverLeave = Sub() rowPanel.BackColor = Color.White

                AddHandler rowPanel.MouseEnter, Sub() hoverEnter()
                AddHandler rowPanel.MouseLeave, Sub() hoverLeave()
                AddHandler lblPatient.MouseEnter, Sub() hoverEnter()
                AddHandler lblId.MouseEnter, Sub() hoverEnter()
                AddHandler lblAgeSex.MouseEnter, Sub() hoverEnter()
                AddHandler lblContact.MouseEnter, Sub() hoverEnter()
                AddHandler lblVisit.MouseEnter, Sub() hoverEnter()

                rowPanel.Controls.Add(lblPatient)
                rowPanel.Controls.Add(lblId)
                rowPanel.Controls.Add(lblAgeSex)
                rowPanel.Controls.Add(lblContact)
                rowPanel.Controls.Add(lblVisit)
                rowPanel.Controls.Add(divRow)

                pnlRowsContainer.Controls.Add(rowPanel)
            Next

            ' only the rows on the current page (was filtered.Count, which overflowed the card)
            pnlRowsContainer.Height = pageItems.Count * RowHeight
        End If

        ' Position the new rows' columns to match the current width
        LayoutRows()

        ' Card height = header (84) + rows + pagination bar + bottom padding
        Dim pagerH As Integer = If(pnlPagination IsNot Nothing, pnlPagination.Height, 0)
        cardPatientsTable.Height = Math.Max(160, 84 + pnlRowsContainer.Height + pagerH + 16)

        pnlRowsContainer.ResumeLayout()
    End Sub

    Private Sub OpenPatient(patientId As String)
        If DoctorShell.Current IsNot Nothing Then
            DoctorShell.Current.OpenPatient(patientId)
        Else
            Dim infoForm As New DoctorPatientInformation(patientId)
            infoForm.Show()
            Me.Hide()
        End If
    End Sub

End Class