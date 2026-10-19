Imports System.Globalization
Imports Ferrando.UI.WinForms.Controles

' ------------------------------------------------------------------
'  Receptionist Consultation Directory
'  Displays list of clinic consultations: Date, Patient, Doctor, Visit Type, Status
'  Stretches across full width of the view and allows search and filtering.
'  Includes pagination (Prev/Next) and a scrollable main area.
' ------------------------------------------------------------------
Public Class ReceptionistConsultation

    Private Class ConsultationItemRecord
        Public Property AppointmentId As String
        Public Property PatientId As String
        Public Property PatientName As String
        Public Property DoctorName As String
        Public Property VisitDate As Date
        Public Property RecordTimestamp As DateTime
        Public Property VisitType As String
        Public Property Status As String
        Public Property HasRx As Boolean
    End Class

    Private Enum ConsultationFilter
        All
        Completed
        Pending
    End Enum

    Private Enum SortMode
        DateDesc
        PatientName
        Doctor
    End Enum

    Public Event PatientSelected(patientId As String, appointmentId As String)

    Private _filter As ConsultationFilter = ConsultationFilter.All
    Private _sort As SortMode = SortMode.DateDesc
    Private _doctorFilter As String = "All doctors"

    Private ReadOnly cmsFilterAll As New ContextMenuStrip()
    Private ReadOnly cmsFilterVisit As New ContextMenuStrip()
    Private ReadOnly cmsFilterDoctor As New ContextMenuStrip()

    Private Const RowHeight As Integer = 46
    Private ReadOnly Arrow As String = " " & ChrW(&H25BE)

    Private _currentPage As Integer = 1
    Private Const PageSize As Integer = 10
    Private pnlPagination As Panel
    Private lblPageInfo As Label
    Private btnPrevPage As FButton
    Private btnNextPage As FButton

    Public Sub New()
        InitializeComponent()
        SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        DoubleBuffered = True
    End Sub

    Private ReadOnly Property _consultations As List(Of ConsultationItemRecord)
        Get
            Dim list As New List(Of ConsultationItemRecord)
            For Each appt In ClinicData.Appointments
                Dim d As Date
                If Not String.IsNullOrEmpty(appt.AppointmentDate) AndAlso DateTime.TryParse(appt.AppointmentDate, d) Then
                    d = d.Date.AddMinutes(appt.Minutes)
                Else
                    d = New Date(2026, 9, Math.Min(Math.Max(appt.Day, 1), 30)).AddMinutes(appt.Minutes)
                End If

                Dim recordTs As DateTime = d
                If Not String.IsNullOrEmpty(appt.UpdatedAt) AndAlso DateTime.TryParse(appt.UpdatedAt, recordTs) Then
                    ' populated from updated_at
                ElseIf Not String.IsNullOrEmpty(appt.CreatedAt) AndAlso DateTime.TryParse(appt.CreatedAt, recordTs) Then
                    ' populated from created_at
                End If

                Dim hasPrescription = Not String.IsNullOrWhiteSpace(appt.Medication) AndAlso Not appt.Medication.Equals("None prescribed", StringComparison.OrdinalIgnoreCase)

                list.Add(New ConsultationItemRecord With {
                    .AppointmentId = If(Not String.IsNullOrEmpty(appt.AppointmentId), appt.AppointmentId, "AP-" & Math.Abs(appt.PatientId.GetHashCode() Mod 8999 + 1000).ToString()),
                    .PatientId = appt.PatientId,
                    .PatientName = appt.PatientName,
                    .DoctorName = If(String.IsNullOrEmpty(appt.DoctorName), "Dr. Elena Cruz", appt.DoctorName),
                    .VisitDate = d,
                    .RecordTimestamp = recordTs,
                    .VisitType = If(String.IsNullOrEmpty(appt.VisitType), "General Checkup", appt.VisitType),
                    .Status = If(String.IsNullOrEmpty(appt.Status), "Confirmed", appt.Status),
                    .HasRx = hasPrescription
                })
            Next
            Return list
        End Get
    End Property

    Private Sub ReceptionistConsultation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ---- Scrolling setup ----
        mainScreen.AutoScroll = True
        mainScreen.HorizontalScroll.Enabled = False
        mainScreen.HorizontalScroll.Visible = False
        cardPatients.Anchor = AnchorStyles.Top Or AnchorStyles.Left   ' don't anchor Bottom, or the card can't grow
        AddHandler cardPatients.MouseEnter, Sub() mainScreen.Focus()  ' lets the mouse wheel scroll over the card

        lblSearchIcon.Font = New Font("Segoe MDL2 Assets", 10.0F)
        lblSearchIcon.Text = ChrW(&HE721)

        btnFilterAll.Text = "All consultations" & Arrow
        btnFilterDoctor.Text = "All doctors" & Arrow
        btnFilterVisit.Text = "Date" & Arrow

        BuildMenu(cmsFilterAll, {
            ("All consultations", ConsultationFilter.All),
            ("Completed", ConsultationFilter.Completed),
            ("Waiting / Pending", ConsultationFilter.Pending)
        })
        BuildDoctorMenu()
        BuildSortMenu()

        AddHandler ClinicData.DataChanged, Sub()
                                               If IsHandleCreated AndAlso Not IsDisposed Then
                                                   BeginInvoke(Sub()
                                                                   BuildDoctorMenu()
                                                                   RefreshRows()
                                                               End Sub)
                                               End If
                                           End Sub

        AlignHeaderColumns()
        RefreshRows()
    End Sub

    Private Sub ReceptionistConsultation_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Visible Then RefreshRows()
    End Sub

    Private Sub ReceptionistConsultation_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        AlignHeaderColumns()
        RefreshRows()
    End Sub

    Private Sub AlignHeaderColumns()
        If cardPatients Is Nothing OrElse pnlRows Is Nothing Then Return

        ' Stretch table across full width (reserve room for the vertical scrollbar)
        Dim padLeft = 28
        Dim totalW = mainScreen.ClientSize.Width - (padLeft * 2) - SystemInformation.VerticalScrollBarWidth
        If totalW > 400 Then
            cardPatients.Width = totalW
            pnlRows.Width = totalW - 40
            pnlHeaderLine.Width = totalW - 40
            cardSearch.Width = Math.Max(200, totalW - btnFilterDoctor.Width - btnFilterAll.Width - btnFilterVisit.Width - 44)
            btnFilterDoctor.Left = cardSearch.Right + 12
            btnFilterAll.Left = btnFilterDoctor.Right + 12
            btnFilterVisit.Left = btnFilterAll.Right + 12
        End If

        ' Distribute columns evenly
        Dim w = pnlRows.Width
        lblColPatient.Left = 24
        lblColPatientId.Left = 24 + CInt(w * 0.18)
        lblColAgeSex.Left = 24 + CInt(w * 0.42)
        lblColContact.Left = 24 + CInt(w * 0.65)
        lblColLastVisit.Left = 24 + CInt(w * 0.84)
    End Sub

    Private Sub BuildDoctorMenu()
        cmsFilterDoctor.Font = New Font("Segoe UI", 9.0F)
        cmsFilterDoctor.ShowImageMargin = False
        cmsFilterDoctor.Items.Clear()

        Dim doctors As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        For Each appt In ClinicData.Appointments
            If Not String.IsNullOrWhiteSpace(appt.DoctorName) Then
                doctors.Add(appt.DoctorName.Trim())
            End If
        Next
        For Each st In SqliteStaffRepository.GetDoctorAccounts()
            If Not String.IsNullOrWhiteSpace(st.Name) Then
                Dim dName = If(st.Name.StartsWith("Dr.", StringComparison.OrdinalIgnoreCase), st.Name.Trim(), "Dr. " & st.Name.Trim())
                doctors.Add(dName)
            End If
        Next

        Dim sortedDocs = doctors.OrderBy(Function(d) d).ToList()
        sortedDocs.Insert(0, "All doctors")

        For Each docName In sortedDocs
            Dim captured = docName
            Dim mi As New ToolStripMenuItem(captured)
            AddHandler mi.Click,
                Sub()
                    _doctorFilter = captured
                    _currentPage = 1
                    btnFilterDoctor.Text = captured & Arrow
                    RefreshRows()
                End Sub
            cmsFilterDoctor.Items.Add(mi)
        Next
    End Sub

    Private Sub BuildMenu(cms As ContextMenuStrip, items As (String, ConsultationFilter)())
        cms.Font = New Font("Segoe UI", 9.0F)
        cms.ShowImageMargin = False
        cms.Items.Clear()
        For Each it In items
            Dim text As String = it.Item1
            Dim value As ConsultationFilter = it.Item2
            Dim mi As New ToolStripMenuItem(text)
            AddHandler mi.Click,
                Sub()
                    _filter = value
                    _currentPage = 1
                    btnFilterAll.Text = text & Arrow
                    RefreshRows()
                End Sub
            cms.Items.Add(mi)
        Next
    End Sub

    Private Sub BuildSortMenu()
        cmsFilterVisit.Font = New Font("Segoe UI", 9.0F)
        cmsFilterVisit.ShowImageMargin = False
        cmsFilterVisit.Items.Clear()

        Dim options As (String, SortMode)() = {
            ("Date (Newest)", SortMode.DateDesc),
            ("Patient name", SortMode.PatientName),
            ("Doctor name", SortMode.Doctor)
        }
        For Each it In options
            Dim text As String = it.Item1
            Dim value As SortMode = it.Item2
            Dim mi As New ToolStripMenuItem(text)
            AddHandler mi.Click,
                Sub()
                    _sort = value
                    _currentPage = 1
                    btnFilterVisit.Text = text & Arrow
                    RefreshRows()
                End Sub
            cmsFilterVisit.Items.Add(mi)
        Next
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        _currentPage = 1
        RefreshRows()
    End Sub

    Private Sub btnFilterDoctor_Click(sender As Object, e As EventArgs) Handles btnFilterDoctor.Click
        BuildDoctorMenu()
        cmsFilterDoctor.Show(btnFilterDoctor, New Point(0, btnFilterDoctor.Height + 2))
    End Sub

    Private Sub btnFilterAll_Click(sender As Object, e As EventArgs) Handles btnFilterAll.Click
        cmsFilterAll.Show(btnFilterAll, New Point(0, btnFilterAll.Height + 2))
    End Sub

    Private Sub btnFilterVisit_Click(sender As Object, e As EventArgs) Handles btnFilterVisit.Click
        cmsFilterVisit.Show(btnFilterVisit, New Point(0, btnFilterVisit.Height + 2))
    End Sub

    Public Sub RefreshRows()
        Dim term As String = txtSearch.Text.Trim()

        Dim result As List(Of ConsultationItemRecord) =
            _consultations.Where(Function(c)
                                     If _filter = ConsultationFilter.Completed AndAlso Not c.Status.Equals("Completed", StringComparison.OrdinalIgnoreCase) Then Return False
                                     If _filter = ConsultationFilter.Pending AndAlso Not c.Status.Equals("Pending", StringComparison.OrdinalIgnoreCase) Then Return False
                                     If _doctorFilter <> "All doctors" AndAlso Not String.IsNullOrEmpty(_doctorFilter) Then
                                         If Not c.DoctorName.Equals(_doctorFilter, StringComparison.OrdinalIgnoreCase) Then Return False
                                     End If
                                     If term = "" Then Return True
                                     Return c.PatientName.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0 OrElse
                                            c.PatientId.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0 OrElse
                                            c.DoctorName.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0 OrElse
                                            c.VisitType.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0
                                 End Function).ToList()

        Select Case _sort
            Case SortMode.PatientName
                result = result.OrderBy(Function(c) c.PatientName).ToList()
            Case SortMode.Doctor
                result = result.OrderBy(Function(c) c.DoctorName).ToList()
            Case Else
                result = result.OrderByDescending(Function(c) c.VisitDate.Date).ThenByDescending(Function(c) c.RecordTimestamp).ToList()
        End Select

        Dim totalCount = result.Count
        Dim totalPages = Math.Max(1, CInt(Math.Ceiling(totalCount / CDbl(PageSize))))
        If _currentPage > totalPages Then _currentPage = totalPages
        If _currentPage < 1 Then _currentPage = 1

        Dim pageRows = result.Skip((_currentPage - 1) * PageSize).Take(PageSize).ToList()

        SuspendLayout()
        pnlRows.SuspendLayout()

        For i As Integer = pnlRows.Controls.Count - 1 To 0 Step -1
            Dim c As Control = pnlRows.Controls(i)
            pnlRows.Controls.RemoveAt(i)
            c.Dispose()
        Next

        Dim y As Integer = 0
        For Each item In pageRows
            pnlRows.Controls.Add(BuildRow(item, y))
            y += RowHeight
        Next
        pnlRows.Height = Math.Max(y, 1)

        EnsurePaginationControls()
        Dim startItem = If(totalCount = 0, 0, (_currentPage - 1) * PageSize + 1)
        Dim endItem = Math.Min(_currentPage * PageSize, totalCount)
        lblPageInfo.Text = $"Showing {startItem}-{endItem} of {totalCount} consultations  •  Page {_currentPage} of {totalPages}"
        btnPrevPage.Enabled = (_currentPage > 1)
        btnNextPage.Enabled = (_currentPage < totalPages)

        pnlPagination.Top = pnlRows.Bottom + 8
        pnlPagination.Width = pnlRows.Width
        cardPatients.Height = Math.Max(320, pnlPagination.Bottom + 16)

        lblEmpty.Text = "No consultations match your search."
        lblEmpty.Visible = (totalCount = 0)
        pnlPagination.Visible = (totalCount > 0)

        ' Keep the scroll range in sync with the card height
        mainScreen.AutoScrollMinSize = New Size(0, cardPatients.Bottom + 24)

        pnlRows.ResumeLayout()
        ResumeLayout()
    End Sub

    Private Sub EnsurePaginationControls()
        If pnlPagination IsNot Nothing Then Return

        pnlPagination = New Panel With {
            .Location = New Point(20, pnlRows.Bottom + 8),
            .Size = New Size(pnlRows.Width, 36),
            .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right,
            .BackColor = Color.White
        }

        lblPageInfo = New Label With {
            .AutoSize = True,
            .Location = New Point(4, 9),
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Regular),
            .ForeColor = Color.FromArgb(115, 138, 148),
            .BackColor = Color.Transparent
        }
        pnlPagination.Controls.Add(lblPageInfo)

        btnNextPage = New FButton With {
            .Text = "Next ›",
            .Size = New Size(76, 30),
            .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
            .Location = New Point(pnlPagination.Width - 76, 3),
            .Cursor = Cursors.Hand,
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        }
        UIThemeHelper.ApplySecondary(btnNextPage)
        AddHandler btnNextPage.Click, Sub()
                                          _currentPage += 1
                                          RefreshRows()
                                          mainScreen.AutoScrollPosition = New Point(0, 0)
                                      End Sub
        pnlPagination.Controls.Add(btnNextPage)

        btnPrevPage = New FButton With {
            .Text = "‹ Prev",
            .Size = New Size(76, 30),
            .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
            .Location = New Point(pnlPagination.Width - 160, 3),
            .Cursor = Cursors.Hand,
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        }
        UIThemeHelper.ApplySecondary(btnPrevPage)
        AddHandler btnPrevPage.Click, Sub()
                                          _currentPage -= 1
                                          RefreshRows()
                                          mainScreen.AutoScrollPosition = New Point(0, 0)
                                      End Sub
        pnlPagination.Controls.Add(btnPrevPage)

        cardPatients.Controls.Add(pnlPagination)
    End Sub

    Private Function BuildRow(c As ConsultationItemRecord, y As Integer) As Panel
        Dim row As New Panel With {
            .Location = New Point(0, y),
            .Size = New Size(pnlRows.Width, RowHeight),
            .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right,
            .BackColor = Color.White,
            .Cursor = Cursors.Hand
        }

        Dim w = pnlRows.Width
        Dim col0 = 4
        Dim col1 = 4 + CInt(w * 0.18)
        Dim col2 = 4 + CInt(w * 0.42)
        Dim col3 = 4 + CInt(w * 0.65)
        Dim col4 = 4 + CInt(w * 0.84)

        Dim muted As Color = Color.FromArgb(115, 130, 140)
        Dim dateStr = c.VisitDate.ToString("MMM dd, yyyy", CultureInfo.InvariantCulture)
        Dim normPatient = ValidationHelper.NormalizeProperCase(c.PatientName)

        row.Controls.Add(MakeCell(dateStr, col0, Color.FromArgb(35, 45, 55), 8.5F, True))
        row.Controls.Add(MakeCell(normPatient & " (" & c.PatientId & ")", col1, Color.FromArgb(23, 105, 90), 8.5F, True))
        row.Controls.Add(MakeCell(c.DoctorName, col2, Color.FromArgb(40, 55, 65)))
        row.Controls.Add(MakeCell(c.VisitType, col3, muted))

        ' Status Pill
        Dim pill As New Label With {
            .AutoSize = False,
            .Size = New Size(76, 22),
            .Location = New Point(col4, 11),
            .TextAlign = ContentAlignment.MiddleCenter,
            .Text = c.Status,
            .Font = New Font("Segoe UI", 7.5F, FontStyle.Bold)
        }
        Select Case c.Status.ToLowerInvariant()
            Case "completed"
                pill.BackColor = Color.FromArgb(230, 245, 235) : pill.ForeColor = Color.FromArgb(40, 135, 75)
            Case "pending"
                pill.BackColor = Color.FromArgb(254, 243, 226) : pill.ForeColor = Color.FromArgb(217, 119, 6)
            Case "cancelled"
                pill.BackColor = Color.FromArgb(253, 236, 235) : pill.ForeColor = Color.FromArgb(205, 80, 75)
            Case Else
                pill.BackColor = Color.FromArgb(243, 246, 248) : pill.ForeColor = Color.FromArgb(120, 140, 150)
        End Select
        row.Controls.Add(pill)

        row.Controls.Add(New Panel With {
            .Dock = DockStyle.Bottom,
            .Height = 1,
            .BackColor = Color.FromArgb(242, 244, 247)
        })

        Dim id As String = c.PatientId
        Dim apptId As String = c.AppointmentId
        Dim hoverOn As Action =
            Sub()
                row.BackColor = Color.FromArgb(246, 249, 251)
                ' Give focus to the scroll container so the mouse wheel works over rows
                If Not mainScreen.Focused Then mainScreen.Focus()
            End Sub
        Dim hoverOff As Action =
            Sub()
                If Not row.ClientRectangle.Contains(row.PointToClient(Cursor.Position)) Then
                    row.BackColor = Color.White
                End If
            End Sub

        AddHandler row.MouseEnter, Sub() hoverOn()
        AddHandler row.MouseLeave, Sub() hoverOff()
        AddHandler row.Click, Sub() RaiseEvent PatientSelected(id, apptId)
        For Each ctrl As Control In row.Controls
            ctrl.Cursor = Cursors.Hand
            AddHandler ctrl.MouseEnter, Sub() hoverOn()
            AddHandler ctrl.MouseLeave, Sub() hoverOff()
            AddHandler ctrl.Click, Sub() RaiseEvent PatientSelected(id, apptId)
        Next

        Return row
    End Function

    Private Function MakeCell(text As String, x As Integer, color As Color, Optional size As Single = 8.5F, Optional isBold As Boolean = False) As Label
        Return New Label With {
            .AutoSize = True,
            .BackColor = Color.Transparent,
            .Font = New Font("Segoe UI", size, If(isBold, FontStyle.Bold, FontStyle.Regular), GraphicsUnit.Point, CByte(0)),
            .ForeColor = color,
            .Location = New Point(x, 13),
            .Text = text
        }
    End Function

End Class