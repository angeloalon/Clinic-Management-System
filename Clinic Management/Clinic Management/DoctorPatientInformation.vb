Imports Ferrando.UI.WinForms.Controles

Public Class DoctorPatientInformation
    Private sidebarHandler As SidebarHandler
    Private _currentPatientId As String = "PT-1048"

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(patientId As String)
        Me.New()
        _currentPatientId = patientId
    End Sub

    Public Sub New(patient As PatientItem)
        Me.New(If(patient IsNot Nothing, patient.PatientId, "PT-1048"))
    End Sub

    Private btnNewPrescription As FButton
    Private btnPastPrescription As FButton
    Private cardVitals As FCard
    Private cardEmergency As FCard
    Private cardAttachments As FCard
    Private txtTimelineSearch As TextBox
    Private lblNoVisits As Label
    Private _allVisits As New List(Of VisitItem)()

    ' ---- responsive layout settings
    Private Const SideBarWidth As Integer = 178
    Private Const PageMargin As Integer = 28
    Private Const CardGap As Integer = 16
    Private Const MinContentWidth As Integer = 640
    Private Const TwoColumnMinWidth As Integer = 820     ' below this, cards stack in one column
    Private Const HeaderInlineMinWidth As Integer = 900  ' below this, header buttons move under the name
    Private Const CardPadX As Integer = 16
    Private Const CardPadY As Integer = 14
    Private _layouting As Boolean = False

    Private Sub DoctorPatientInformation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sidebarHandler = New SidebarHandler(btnDashboard, btnPatients, btnAppointment,
                                    btnDoctor, btnConsultation, btnReports)

        sidebarHandler.SetActive(btnPatients)   ' Stay on Patients tab

        SetupResponsiveLayout()
        SetupClinicalActions()
        SetupClinicalPanels()
        LoadPatientData(_currentPatientId)      ' ends with ApplyResponsiveLayout()
    End Sub

    ' =========================================================================
    ' Card / control factories (match the designer cards so everything looks the same)
    ' =========================================================================
    Private Function CreateCard() As FCard
        Return New FCard With {
            .BorderRadius = 12,
            .BorderSize = 1,
            .BorderColor = Color.FromArgb(232, 237, 240),
            .BorderHoverColor = Color.FromArgb(210, 222, 228),
            .HoverTintColor = Color.White,
            .BackColor = Color.White,
            .EnableShadow = True,
            .ShadowDepth = 4,
            .Padding = New Padding(CardPadX, CardPadY, CardPadX, CardPadY)
        }
    End Function

    ' UseMnemonic = False so "&" is shown as text ("Emergency Contact & Guardian")
    Private Function CreateLabel(text As String, size As Single, style As FontStyle, color As Color,
                                 Optional clickable As Boolean = False) As Label
        Return New Label With {
            .Text = text,
            .Font = New Font("Segoe UI", size, style),
            .ForeColor = color,
            .AutoSize = False,
            .UseMnemonic = False,
            .Size = New Size(200, 18),
            .Cursor = If(clickable, Cursors.Hand, Cursors.Default)
        }
    End Function

    ' =========================================================================
    ' Responsive layout
    ' =========================================================================
    Private Sub SetupResponsiveLayout()
        sideBar.Dock = DockStyle.Left
        sideBar.Width = SideBarWidth

        mainScreen.Dock = DockStyle.Fill
        mainScreen.AutoScroll = True
        mainScreen.AutoScrollMargin = New Size(PageMargin, PageMargin)
        mainScreen.BringToFront()

        AddHandler mainScreen.ClientSizeChanged, Sub() ApplyResponsiveLayout()
    End Sub

    Private Sub ApplyResponsiveLayout()
        If _layouting Then Return
        If btnNewPrescription Is Nothing OrElse cardVitals Is Nothing OrElse
           cardEmergency Is Nothing OrElse cardAttachments Is Nothing Then Return

        _layouting = True

        ' Child positions are relative to the scrolled area, so reset scroll, lay out, then restore it
        Dim sx As Integer = -mainScreen.AutoScrollPosition.X
        Dim sy As Integer = -mainScreen.AutoScrollPosition.Y

        Try
            mainScreen.SuspendLayout()
            mainScreen.AutoScrollPosition = New Point(0, 0)

            Dim contentW As Integer = Math.Max(MinContentWidth, mainScreen.ClientSize.Width - PageMargin * 2)
            Dim rightEdge As Integer = PageMargin + contentW
            Dim twoCol As Boolean = contentW >= TwoColumnMinWidth

            ' ---- header action buttons
            btnBackToPatients.Size = New Size(150, 32)
            Dim top As Integer
            If contentW >= HeaderInlineMinWidth Then
                ' one row, right-aligned: [Back] [+ New Prescription] [Past Prescriptions]
                btnPastPrescription.Location = New Point(rightEdge - btnPastPrescription.Width, 20)
                btnNewPrescription.Location = New Point(btnPastPrescription.Left - 10 - btnNewPrescription.Width, 20)
                btnBackToPatients.Location = New Point(btnNewPrescription.Left - 10 - btnBackToPatients.Width, 20)
                top = 86
            Else
                ' narrow: buttons get their own row under the subtitle
                btnBackToPatients.Location = New Point(PageMargin, 84)
                btnNewPrescription.Location = New Point(btnBackToPatients.Right + 10, 84)
                btnPastPrescription.Location = New Point(btnNewPrescription.Right + 10, 84)
                top = 132
            End If

            ' ---- cards
            If twoCol Then
                Dim leftW As Integer = CInt((contentW - CardGap) * 0.38)
                Dim rightW As Integer = contentW - CardGap - leftW
                StackCards({cardDemographics, cardVitals, cardEmergency, cardAttachments}, PageMargin, top, leftW)
                StackCards({cardMedicalHistory, cardUpcoming, cardVisitTimeline}, PageMargin + leftW + CardGap, top, rightW)
            Else
                StackCards({cardDemographics, cardMedicalHistory, cardUpcoming, cardVisitTimeline,
                            cardVitals, cardEmergency, cardAttachments}, PageMargin, top, contentW)
            End If

            mainScreen.ResumeLayout(True)
            mainScreen.AutoScrollPosition = New Point(sx, sy)
        Finally
            _layouting = False
        End Try
    End Sub

    ' Places cards one under another in a column and sizes each to its content
    Private Sub StackCards(cards As FCard(), x As Integer, y As Integer, w As Integer)
        For Each c As FCard In cards
            c.Width = w
            LayoutCardContents(c, w)
            c.Location = New Point(x, y)
            y = c.Bottom + CardGap
        Next
    End Sub

    Private Sub LayoutCardContents(card As FCard, w As Integer)
        Dim iw As Integer = w - CardPadX * 2

        If card Is cardDemographics Then
            FlowLabels(card, {lblDemoTitle, lblAgeSex, lblBirthDate, lblPhone, lblEmail, lblAddress}, iw, CardPadY, 8)

        ElseIf card Is cardMedicalHistory Then
            LayoutMedicalHistory(w)

        ElseIf card Is cardUpcoming Then
            FlowLabels(card, {lblUpcomingTitle, lblUpcomingDate, lblUpcomingDetails}, iw, CardPadY, 6)
            If btnUpcomingBadge.Visible Then
                btnUpcomingBadge.Location = New Point(CardPadX, card.Height - CardPadY + 8)
                card.Height = btnUpcomingBadge.Bottom + CardPadY
            End If

        ElseIf card Is cardVisitTimeline Then
            LayoutTimeline(w)

        Else
            ' vitals / emergency / attachments: title + lines, wrapped
            FlowLabels(card, card.Controls.OfType(Of Label)().ToArray(), iw, CardPadY, 6)
        End If
    End Sub

    ' Stacks labels vertically, wrapping each to the inner width, then sizes the card to fit
    Private Sub FlowLabels(card As Control, labels As IEnumerable(Of Label), innerWidth As Integer,
                           startY As Integer, gap As Integer)
        Dim y As Integer = startY
        For Each lbl As Label In labels
            If Not lbl.Visible Then Continue For
            lbl.AutoSize = False
            Dim h As Integer = Math.Max(lbl.Font.Height, lbl.GetPreferredSize(New Size(innerWidth, 0)).Height)
            lbl.SetBounds(CardPadX, y, innerWidth, h)
            y += h + gap
        Next
        card.Height = y - gap + CardPadY
    End Sub

    Private Sub LayoutMedicalHistory(w As Integer)
        Dim iw As Integer = w - CardPadX * 2
        Dim splitX As Integer = CInt(iw * 0.6)               ' conditions get 60%, allergies 40%
        Dim leftW As Integer = splitX - 12
        Dim rightX As Integer = CardPadX + splitX
        Dim rightW As Integer = iw - splitX

        lblMedHistoryTitle.Location = New Point(CardPadX, CardPadY)
        lblConditionsHeader.Location = New Point(CardPadX, 44)
        lblAllergiesHeader.Location = New Point(rightX, 44)

        For Each pair In {Tuple.Create(lblConditionsValue, CardPadX, leftW),
                          Tuple.Create(lblAllergiesValue, rightX, rightW)}
            Dim lbl As Label = pair.Item1
            lbl.AutoSize = False
            Dim h As Integer = Math.Max(lbl.Font.Height, lbl.GetPreferredSize(New Size(pair.Item3, 0)).Height)
            lbl.SetBounds(pair.Item2, 62, pair.Item3, h)
        Next

        cardMedicalHistory.Height = Math.Max(lblConditionsValue.Bottom, lblAllergiesValue.Bottom) + CardPadY
    End Sub

    Private Sub LayoutTimeline(w As Integer)
        Dim iw As Integer = w - CardPadX * 2
        Const BadgeW As Integer = 72

        ' search box, right-aligned in the card header
        If txtTimelineSearch IsNot Nothing Then
            Dim sw As Integer = Math.Max(100, Math.Min(220, iw - 130))
            txtTimelineSearch.SetBounds(w - CardPadX - sw, 11, sw, 22)
        End If

        ' column start positions as a fraction of the inner width: date, type, diagnosis, doctor
        Dim fx() As Double = {0.0, 0.19, 0.37, 0.64}
        Dim rowY() As Integer = {62, 112, 162}
        Dim rows()() As Label = {
            New Label() {lblV1Date, lblV1Type, lblV1Diag, lblV1Doc},
            New Label() {lblV2Date, lblV2Type, lblV2Diag, lblV2Doc},
            New Label() {lblV3Date, lblV3Type, lblV3Diag, lblV3Doc}
        }
        Dim badges() As FButton = {btnV1Badge, btnV2Badge, btnV3Badge}

        For r As Integer = 0 To 2
            For c As Integer = 0 To 3
                Dim lbl As Label = rows(r)(c)
                Dim x As Integer = CardPadX + CInt(fx(c) * iw)
                Dim endX As Integer = If(c < 3, CardPadX + CInt(fx(c + 1) * iw) - 8, w - CardPadX - BadgeW - 8)
                lbl.AutoSize = False
                lbl.AutoEllipsis = True
                lbl.SetBounds(x, rowY(r), Math.Max(30, endX - x), 18)
            Next
            badges(r).Location = New Point(w - CardPadX - BadgeW, rowY(r) - 4)
        Next

        divV1.SetBounds(CardPadX, 96, iw, 1)
        divV2.SetBounds(CardPadX, 146, iw, 1)

        If lblNoVisits IsNot Nothing Then lblNoVisits.SetBounds(CardPadX, 62, iw, 18)

        cardVisitTimeline.Height = 206
    End Sub

    ' =========================================================================
    ' Header actions
    ' =========================================================================
    Private Sub SetupClinicalActions()
        If btnNewPrescription IsNot Nothing Then Return

        btnNewPrescription = New FButton With {
            .Text = "+ New Prescription",
            .Size = New Size(140, 32),
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
            .Cursor = Cursors.Hand
        }
        UIThemeHelper.ApplyPrimary(btnNewPrescription)
        AddHandler btnNewPrescription.Click, AddressOf OpenNewPrescription
        mainScreen.Controls.Add(btnNewPrescription)

        btnPastPrescription = New FButton With {
            .Text = "Past Prescriptions",
            .Size = New Size(130, 32),
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
            .Cursor = Cursors.Hand
        }
        UIThemeHelper.ApplySecondary(btnPastPrescription)
        AddHandler btnPastPrescription.Click, AddressOf OpenPastPrescriptions
        mainScreen.Controls.Add(btnPastPrescription)
    End Sub

    ' =========================================================================
    ' Extra clinical cards (positions/sizes are set by ApplyResponsiveLayout)
    ' =========================================================================
    Private Sub SetupClinicalPanels()
        Dim titleColor = Color.FromArgb(30, 45, 55)

        ' Timeline search + empty message
        If txtTimelineSearch Is Nothing AndAlso cardVisitTimeline IsNot Nothing Then
            txtTimelineSearch = New TextBox With {
                .Font = New Font("Segoe UI", 8.5F),
                .PlaceholderText = "Search diagnoses, doctors..."
            }
            AddHandler txtTimelineSearch.TextChanged, Sub() FilterVisits()

            lblNoVisits = CreateLabel("No visits match your search.", 8.5F, FontStyle.Regular, Color.FromArgb(120, 135, 145))
            lblNoVisits.Visible = False

            cardVisitTimeline.Controls.Add(txtTimelineSearch)
            cardVisitTimeline.Controls.Add(lblNoVisits)
        End If

        ' Vitals
        If cardVitals Is Nothing Then
            cardVitals = CreateCard()
            cardVitals.Controls.Add(CreateLabel("Vital Signs (Latest Visit)", 10.0F, FontStyle.Bold, titleColor))
            cardVitals.Controls.Add(CreateLabel("BP: 120/80 mmHg • Pulse: 72 bpm • SpO2: 98%", 8.5F, FontStyle.Bold, Color.FromArgb(30, 75, 65)))
            cardVitals.Controls.Add(CreateLabel("Temp: 36.6 °C • Weight: 62 kg • Height: 165 cm", 8.5F, FontStyle.Regular, Color.FromArgb(40, 60, 72)))
            mainScreen.Controls.Add(cardVitals)
        End If

        ' Emergency contact
        If cardEmergency Is Nothing Then
            cardEmergency = CreateCard()
            cardEmergency.Controls.Add(CreateLabel("Emergency Contact & Guardian", 10.0F, FontStyle.Bold, titleColor))
            cardEmergency.Controls.Add(CreateLabel("Name: Roberto Santos (Spouse / Guardian)", 8.5F, FontStyle.Bold, Color.FromArgb(30, 45, 55)))
            cardEmergency.Controls.Add(CreateLabel("Contact: 0917 888 1234 • Caloocan City", 8.5F, FontStyle.Regular, Color.FromArgb(50, 70, 80)))
            mainScreen.Controls.Add(cardEmergency)
        End If

        ' Attachments
        If cardAttachments Is Nothing Then
            cardAttachments = CreateCard()
            Dim teal = Color.FromArgb(35, 110, 95)

            Dim lblAtt1 = CreateLabel("Chest X-Ray (PA view) – Sep 22, 2026", 8.5F, FontStyle.Regular, teal, True)
            Dim lblAtt2 = CreateLabel("Complete Blood Count (CBC) – Jun 16, 2026", 8.5F, FontStyle.Regular, teal, True)
            Dim lblAtt3 = CreateLabel("Urinalysis Routine Report – Jan 08, 2026", 8.5F, FontStyle.Regular, teal, True)

            AddHandler lblAtt1.Click, Sub() MessageBox.Show("Viewing attached laboratory document: Chest X-Ray (PA view) [Archived]", "Diagnostic Attachment", MessageBoxButtons.OK, MessageBoxIcon.Information)
            AddHandler lblAtt2.Click, Sub() MessageBox.Show("Viewing attached laboratory document: Complete Blood Count (CBC) [Archived]", "Diagnostic Attachment", MessageBoxButtons.OK, MessageBoxIcon.Information)
            AddHandler lblAtt3.Click, Sub() MessageBox.Show("Viewing attached laboratory document: Urinalysis Report [Archived]", "Diagnostic Attachment", MessageBoxButtons.OK, MessageBoxIcon.Information)

            cardAttachments.Controls.Add(CreateLabel("Diagnostic Attachments & Labs", 10.0F, FontStyle.Bold, titleColor))
            cardAttachments.Controls.Add(lblAtt1)
            cardAttachments.Controls.Add(lblAtt2)
            cardAttachments.Controls.Add(lblAtt3)
            mainScreen.Controls.Add(cardAttachments)
        End If
    End Sub

    ''' <summary>
    ''' Loads and displays patient information dynamically by ID with high-contrast WCAG styling.
    ''' </summary>
    Public Sub LoadPatientData(patientId As String)
        _currentPatientId = patientId
        Dim p = PatientRepository.GetById(patientId)

        If p Is Nothing Then
            lblPatientName.Text = "Patient Not Found"
            lblPatientSubtitle.Text = $"No record found for ID: {patientId}"
            lblAgeSex.Text = "—"
            lblBirthDate.Text = "—"
            lblPhone.Text = "—"
            lblEmail.Text = "—"
            lblAddress.Text = "—"
            lblConditionsValue.Text = "—"
            lblAllergiesValue.Text = "—"
            ApplyResponsiveLayout()
            Return
        End If

        Dim normName = ValidationHelper.NormalizeProperCase(p.Name)
        lblPatientName.Text = normName
        lblPatientSubtitle.Text = "Patient " & p.PatientId & " • " & p.RecordUpdated
        lblPatientSubtitle.ForeColor = Color.FromArgb(30, 48, 60) ' WCAG High contrast

        ' High Contrast Demographics
        lblAgeSex.Text = p.Age & " years old • " & p.Gender
        lblAgeSex.ForeColor = Color.FromArgb(20, 35, 45)

        lblBirthDate.Text = p.BirthDate
        lblBirthDate.ForeColor = Color.FromArgb(35, 50, 60)

        lblPhone.Text = p.Contact
        lblPhone.ForeColor = Color.FromArgb(35, 50, 60)

        lblEmail.Text = p.Email
        lblEmail.ForeColor = Color.FromArgb(35, 50, 60)

        lblAddress.Text = p.Address
        lblAddress.ForeColor = Color.FromArgb(35, 50, 60)

        ' Medical History
        lblConditionsValue.Text = p.KnownConditions & vbCrLf & "Meds: Maintenance inhaler • Surgeries: None • Immunized: Complete"
        lblConditionsValue.ForeColor = Color.FromArgb(25, 40, 50)

        lblAllergiesValue.Text = p.DrugAllergies
        lblAllergiesValue.ForeColor = If(p.HasAllergies, Color.FromArgb(185, 28, 28), Color.FromArgb(40, 70, 80))

        ' Store visits and bind timeline
        _allVisits = p.Visits
        FilterVisits()

        ' Upcoming appointment (shows an empty state instead of a blank card)
        Dim hasUpcoming As Boolean = Not String.IsNullOrWhiteSpace(p.UpcomingDate)
        If hasUpcoming Then
            lblUpcomingDate.Text = p.UpcomingDate
            lblUpcomingDate.ForeColor = Color.FromArgb(22, 51, 65)
            lblUpcomingDetails.Text = p.UpcomingDetails
            lblUpcomingDetails.ForeColor = Color.FromArgb(40, 60, 70)
            btnUpcomingBadge.Text = p.UpcomingStatus
        Else
            lblUpcomingDate.Text = "No upcoming appointments"
            lblUpcomingDate.ForeColor = Color.FromArgb(120, 135, 145)
            lblUpcomingDetails.Text = ""
        End If
        lblUpcomingDetails.Visible = hasUpcoming AndAlso Not String.IsNullOrWhiteSpace(lblUpcomingDetails.Text)
        btnUpcomingBadge.Visible = hasUpcoming AndAlso Not String.IsNullOrWhiteSpace(btnUpcomingBadge.Text)

        ' Text changed, so card heights need recalculating
        ApplyResponsiveLayout()
    End Sub

    Private Sub FilterVisits()
        Dim query As String = If(txtTimelineSearch IsNot Nothing, txtTimelineSearch.Text.Trim().ToLower(), "")
        Dim visitsToShow = _allVisits.Where(Function(v)
                                                If String.IsNullOrEmpty(query) Then Return True
                                                Return v.Diagnosis.ToLower().Contains(query) OrElse
                                                       v.Doctor.ToLower().Contains(query) OrElse
                                                       v.VisitType.ToLower().Contains(query)
                                            End Function).ToList()

        ' Render visit rows
        If visitsToShow.Count > 0 Then
            lblV1Date.Text = visitsToShow(0).VisitDate
            lblV1Type.Text = visitsToShow(0).VisitType
            lblV1Diag.Text = visitsToShow(0).Diagnosis
            lblV1Doc.Text = visitsToShow(0).Doctor
            btnV1Badge.Text = visitsToShow(0).Status
            lblV1Date.Visible = True : lblV1Type.Visible = True : lblV1Diag.Visible = True : lblV1Doc.Visible = True : btnV1Badge.Visible = True
        Else
            lblV1Date.Visible = False : lblV1Type.Visible = False : lblV1Diag.Visible = False : lblV1Doc.Visible = False : btnV1Badge.Visible = False
        End If

        If visitsToShow.Count > 1 Then
            lblV2Date.Text = visitsToShow(1).VisitDate
            lblV2Type.Text = visitsToShow(1).VisitType
            lblV2Diag.Text = visitsToShow(1).Diagnosis
            lblV2Doc.Text = visitsToShow(1).Doctor
            btnV2Badge.Text = visitsToShow(1).Status
            lblV2Date.Visible = True : lblV2Type.Visible = True : lblV2Diag.Visible = True : lblV2Doc.Visible = True : btnV2Badge.Visible = True : divV1.Visible = True
        Else
            lblV2Date.Visible = False : lblV2Type.Visible = False : lblV2Diag.Visible = False : lblV2Doc.Visible = False : btnV2Badge.Visible = False : divV1.Visible = False
        End If

        If visitsToShow.Count > 2 Then
            lblV3Date.Text = visitsToShow(2).VisitDate
            lblV3Type.Text = visitsToShow(2).VisitType
            lblV3Diag.Text = visitsToShow(2).Diagnosis
            lblV3Doc.Text = visitsToShow(2).Doctor
            btnV3Badge.Text = visitsToShow(2).Status
            lblV3Date.Visible = True : lblV3Type.Visible = True : lblV3Diag.Visible = True : lblV3Doc.Visible = True : btnV3Badge.Visible = True : divV2.Visible = True
        Else
            lblV3Date.Visible = False : lblV3Type.Visible = False : lblV3Diag.Visible = False : lblV3Doc.Visible = False : btnV3Badge.Visible = False : divV2.Visible = False
        End If

        If lblNoVisits IsNot Nothing Then lblNoVisits.Visible = (visitsToShow.Count = 0)
    End Sub

    Private Sub OpenNewPrescription()
        Dim p = PatientRepository.GetById(_currentPatientId)
        If p Is Nothing Then Return
        Dim currentDoc = If(CurrentUser.IsAuthenticated, CurrentUser.FullName, "Dr. Elena Cruz")
        Using dlg As New DoctorPrescriptionDialog(ValidationHelper.NormalizeProperCase(p.Name), p.PatientId, p.Age & " • " & p.Gender, "1. ", "Standard general precautions.", p.DrugAllergies)
            dlg.ShowDialog(Me)
        End Using
    End Sub

    Private Sub OpenPastPrescriptions()
        Dim rxList = SqliteConsultationRepository.GetPrescriptionsForPatient(_currentPatientId)
        If rxList.Count = 0 Then
            MessageBox.Show($"No past prescriptions on file for this patient ({_currentPatientId}).", "Past Prescriptions", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim sb As New System.Text.StringBuilder()
        sb.AppendLine($"PAST PRESCRIPTIONS FOR PATIENT {_currentPatientId}:")
        sb.AppendLine()
        For Each rx In rxList
            sb.AppendLine($"• [{rx.CreatedAt}] {rx.Code} (by {rx.Doctor})")
            sb.AppendLine($"  Medications: {rx.Medication}")
            If Not String.IsNullOrEmpty(rx.Advice) Then sb.AppendLine($"  Advice: {rx.Advice}")
            sb.AppendLine()
        Next

        MessageBox.Show(sb.ToString(), "Past Prescriptions Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Sub ConfigureBackButton(returnTo As DoctorTab)
        SetReturnTab(returnTo)
    End Sub

    Public Sub SetReturnTab(returnTo As DoctorTab)
        If returnTo = DoctorTab.Consultation Then
            btnBackToPatients.Text = "← Back to consultation"
        Else
            btnBackToPatients.Text = "← Back to patients"
        End If
    End Sub

    Private Sub btnBackToPatients_Click(sender As Object, e As EventArgs) Handles btnBackToPatients.Click
        If DoctorShell.Current IsNot Nothing Then
            DoctorShell.Current.ReturnFromPatientDetails()
        Else
            Dim patForm As New DoctorPatients()
            patForm.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub btnPatients_Click(sender As Object, e As EventArgs) Handles btnPatients.Click
        If DoctorShell.Current IsNot Nothing Then
            DoctorShell.Current.NavigateTo(DoctorTab.Patients)
        Else
            Dim patForm As New DoctorPatients()
            patForm.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        If DoctorShell.Current IsNot Nothing Then
            DoctorShell.Current.NavigateTo(DoctorTab.Dashboard)
        Else
            Dim docDash As New DoctorDashboard()
            docDash.Show()
            Me.Hide()
        End If
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

    Private Sub DoctorPatientInformation_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If DoctorShell.Current Is Nothing Then
            Application.Exit()
        End If
    End Sub

End Class