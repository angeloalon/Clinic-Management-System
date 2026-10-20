Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports Ferrando.UI.WinForms.Controles

' ============================================================
'  Patient information page (opens when a row in Patients is clicked)
'  Host usage:
'     patientInfo.LoadPatient("PT-1048")
'     ShowPage(patientInfo, btnPatients)
' ============================================================
Public Class ReceptionistPatientInformation

    ' ---------- Events ----------
    Public Event BackRequested()
    Public Event ScheduleAppointmentRequested(patientId As String)

    ' ---------- Palette (from the mockup / design system) ----------
    Private ReadOnly ClrText As Color = ColorTranslator.FromHtml("#16303F")
    Private ReadOnly ClrMuted As Color = ColorTranslator.FromHtml("#7A8B95")
    Private ReadOnly ClrLabel As Color = ColorTranslator.FromHtml("#5F7280")
    Private ReadOnly ClrLine As Color = ColorTranslator.FromHtml("#E6ECEF")
    Private ReadOnly ClrBorder As Color = ColorTranslator.FromHtml("#DCE4E8")
    Private ReadOnly ClrTeal As Color = ColorTranslator.FromHtml("#3A8A78")
    Private ReadOnly ClrDanger As Color = ColorTranslator.FromHtml("#C0392B")
    Private Const FontName As String = "Segoe UI"
    Private ReadOnly Bullet As String = " " & ChrW(&H2022) & " "

    Private _details As PatientDetails
    Private _visits As List(Of PatientVisit)
    Private _appointments As List(Of PatientAppointment)

    Private Const Pad As Integer = 24
    Private Const Gap As Integer = 15

    ' ============================================================
    '  Public API
    ' ============================================================
    Public Sub RefreshCurrentPatient()
        If _details IsNot Nothing AndAlso Not String.IsNullOrEmpty(_details.PatientId) Then
            Dim savedScroll = pnlScroll.AutoScrollPosition
            LoadPatient(_details.PatientId)
            pnlScroll.AutoScrollPosition = New Point(-savedScroll.X, -savedScroll.Y)
        End If
    End Sub

    Public Sub LoadPatient(patientId As String)
        _details = GetPatientDetails(patientId)
        _visits = GetPatientVisits(patientId).OrderByDescending(Function(v) v.VisitDate).ToList()
        _appointments = GetPatientAppointments(patientId).Where(Function(a) a.AppointmentDate >= Date.Now.Date).
                        OrderBy(Function(a) a.AppointmentDate).ToList()
        pnlScroll.AutoScrollPosition = New Point(0, 0)
        Render()
    End Sub

    ' Opens a patient from the Patients list.
    Public Sub LoadPatient(rec As PatientRecord)
        LoadPatient(rec.PatientId)
    End Sub

    Private Sub PatientInformation_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If _details IsNot Nothing Then Render()
    End Sub

    ' ============================================================
    '  Rendering
    ' ============================================================
    Private Sub Render()
        pnlScroll.SuspendLayout()
        For i As Integer = pnlScroll.Controls.Count - 1 To 0 Step -1
            Dim c As Control = pnlScroll.Controls(i)
            pnlScroll.Controls.RemoveAt(i)
            c.Dispose()
        Next

        Dim w As Integer = Math.Max(pnlScroll.ClientSize.Width, 640)
        Dim y As Integer = 16

        ' ----- Back link -----
        Dim back As Label = AddLabel(pnlScroll, "< Back to patients", Pad, y, 8.5F, FontStyle.Regular, ClrTeal)
        back.Cursor = Cursors.Hand
        AddHandler back.Click, Sub() RaiseEvent BackRequested()
        y += 22

        ' ----- Header -----
        Dim displayName = ValidationHelper.NormalizeProperCase(_details.FullName)
        AddLabel(pnlScroll, displayName, Pad, y, 18.0F, FontStyle.Regular, ClrText)
        AddLabel(pnlScroll, "Patient " & _details.PatientId & Bullet & "Record updated " & UpdatedText(), Pad, y + 36, 8.0F, FontStyle.Regular, ClrMuted)

        Dim btn As New FButton()
        btn.Text = "Schedule appointment"
        btn.Size = New Size(148, 30)
        btn.Location = New Point(w - Pad - btn.Width, y + 2)
        btn.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        UIThemeHelper.ApplyPrimary(btn)
        btn.Cursor = Cursors.Hand
        AddHandler btn.Click, Sub() RaiseEvent ScheduleAppointmentRequested(_details.PatientId)
        pnlScroll.Controls.Add(btn)
        y += 64

        ' ----- Row 1: Demographics + Medical history -----
        Dim leftW As Integer = 280
        Dim rightW As Integer = w - Pad * 2 - Gap - leftW
        Dim cardH As Integer = 175

        Dim demo As FCard = MakeCard(Pad, y, leftW, cardH)
        AddLabel(demo, "Demographics", 14, 12, 10.5F, FontStyle.Bold, ClrText)
        Dim formattedPhone = ValidationHelper.FormatPhoneNumber(_details.Phone)
        Dim demoLines As String() = {
            _details.Age.ToString() & " years old" & Bullet & _details.Sex,
            "Born " & _details.BirthDate.ToString("MMMM d, yyyy", CultureInfo.InvariantCulture),
            formattedPhone,
            _details.Email,
            _details.Address
        }
        For i As Integer = 0 To demoLines.Length - 1
            AddLabel(demo, demoLines(i), 14, 38 + i * 24, 8.5F, FontStyle.Regular, ClrText)
        Next

        Dim med As FCard = MakeCard(Pad + leftW + Gap, y, rightW, cardH)
        AddLabel(med, "Medical history", 14, 12, 10.5F, FontStyle.Bold, ClrText)
        AddLabel(med, "KNOWN CONDITIONS", 14, 38, 7.5F, FontStyle.Bold, ClrLabel)
        AddLabel(med, JoinOrDefault(_details.Conditions, "None recorded"), 14, 54, 8.5F, FontStyle.Regular, ClrText)
        
        Dim allergyX As Integer = CInt(rightW * 0.52)
        AddLabel(med, "DRUG ALLERGIES", allergyX, 38, 7.5F, FontStyle.Bold, ClrLabel)
        Dim hasAllergy As Boolean = _details.Allergies IsNot Nothing AndAlso _details.Allergies.Count > 0
        AddLabel(med, JoinOrDefault(_details.Allergies, "No known allergies"), allergyX, 54, 8.5F,
                 FontStyle.Regular, If(hasAllergy, ClrDanger, ClrText))

        ' Past Surgeries & Family History
        Dim divMed As New Panel With {
            .Location = New Point(14, 98),
            .Size = New Size(rightW - 28, 1),
            .BackColor = ClrLine
        }
        med.Controls.Add(divMed)
        AddLabel(med, "SURGICAL & FAMILY HISTORY", 14, 108, 7.5F, FontStyle.Bold, ClrLabel)
        AddLabel(med, "No major surgeries recorded; Family history non-contributory", 14, 124, 8.5F, FontStyle.Regular, ClrMuted)

        y += cardH + 18

        ' ----- Row 2: Visit timeline + Upcoming appointments -----
        Dim upW As Integer = 237
        Dim tlW As Integer = w - Pad * 2 - Gap - upW
        Const RowH As Integer = 45

        Dim tlH As Integer = 46 + Math.Max(_visits.Count, 1) * RowH + 6
        Dim tl As FCard = MakeCard(Pad, y, tlW, tlH)
        AddLabel(tl, "Visit timeline", 14, 12, 10.5F, FontStyle.Bold, ClrText)

        If _visits.Count = 0 Then
            AddLabel(tl, "No visits recorded yet.", 14, 56, 8.0F, FontStyle.Regular, ClrMuted)
        End If

        Dim c2 As Integer = 14 + CInt((tlW - 28) * 0.21)
        Dim c3 As Integer = 14 + CInt((tlW - 28) * 0.43)
        Dim c4 As Integer = 14 + CInt((tlW - 28) * 0.66)
        For i As Integer = 0 To _visits.Count - 1
            Dim v As PatientVisit = _visits(i)
            Dim top As Integer = 46 + i * RowH
            AddLabel(tl, v.VisitDate.ToString("MMM dd, yyyy", CultureInfo.InvariantCulture), 14, top + 12, 8.0F, FontStyle.Regular, ClrText)
            AddLabel(tl, v.VisitType, c2, top + 12, 8.0F, FontStyle.Regular, ClrMuted)
            AddLabel(tl, v.Notes, c3, top + 12, 8.0F, FontStyle.Regular, ClrMuted)
            AddLabel(tl, v.Doctor, c4, top + 12, 8.0F, FontStyle.Regular, ClrMuted)
            AddPill(tl, v.Status, tlW - 14 - 68, top + 9)
            Dim ln As New Panel()
            ln.BackColor = ClrLine
            ln.SetBounds(14, top + RowH - 3, tlW - 28, 1)
            tl.Controls.Add(ln)
        Next

        Dim apptH As Integer = 46 + Math.Max(_appointments.Count, 1) * 82 - 6
        Dim up As FCard = MakeCard(Pad + tlW + Gap, y, upW, Math.Max(apptH, 96))
        AddLabel(up, "Upcoming appointments", 14, 12, 10.5F, FontStyle.Bold, ClrText)

        If _appointments.Count = 0 Then
            AddLabel(up, "No upcoming appointments.", 14, 50, 8.0F, FontStyle.Regular, ClrMuted)
        End If
        For i As Integer = 0 To _appointments.Count - 1
            Dim a As PatientAppointment = _appointments(i)
            Dim top As Integer = 44 + i * 82
            AddLabel(up, a.AppointmentDate.ToString("MMM d", CultureInfo.InvariantCulture) & Bullet &
                     a.AppointmentDate.ToString("h:mm tt", CultureInfo.InvariantCulture), 14, top, 9.5F, FontStyle.Bold, ClrText)
            AddLabel(up, a.Doctor & Bullet & a.Purpose, 14, top + 26, 7.5F, FontStyle.Regular, ClrMuted)
            AddPill(up, a.Status, 14, top + 48, True)
        Next

        ' keep scrollable height a little past the last card
        Dim bottom As Integer = y + Math.Max(tlH, Math.Max(apptH, 96)) + 24
        pnlScroll.AutoScrollMinSize = New Size(0, bottom)
        pnlScroll.ResumeLayout(True)
    End Sub

    ' ============================================================
    '  UI helpers
    ' ============================================================
    ' All card styling is in this one place. If your FCard exposes
    ' radius / border properties (as used in Patients.vb), set them here.
    Private Function MakeCard(x As Integer, y As Integer, w As Integer, h As Integer) As FCard
        Dim c As New FCard()
        c.SetBounds(x, y, w, h)
        c.BackColor = Color.White
        ' c.Radius = 10
        ' c.BorderColor = ClrBorder
        pnlScroll.Controls.Add(c)
        Return c
    End Function

    Private Function AddLabel(parent As Control, text As String, x As Integer, y As Integer,
                              size As Single, style As FontStyle, color As Color) As Label
        Dim l As New Label()
        l.AutoSize = True
        l.BackColor = Color.Transparent
        l.ForeColor = color
        l.Font = New Font(FontName, size, style)
        l.Text = text
        l.Location = New Point(x, y)
        parent.Controls.Add(l)
        Return l
    End Function

    Private Sub AddPill(parent As Control, status As String, x As Integer, y As Integer, Optional leftAligned As Boolean = False)
        Dim back As Color, fore As Color
        Select Case status
            Case "Completed", "Confirmed"
                back = ColorTranslator.FromHtml("#E3F3EA") : fore = ColorTranslator.FromHtml("#1F7A4D")
            Case "Pending"
                back = ColorTranslator.FromHtml("#FFF3D6") : fore = ColorTranslator.FromHtml("#9A6A00")
            Case "Cancelled"
                back = ColorTranslator.FromHtml("#FBE5E5") : fore = ColorTranslator.FromHtml("#B83B3B")
            Case Else
                back = ColorTranslator.FromHtml("#EAEFF2") : fore = ClrLabel
        End Select

        Dim p As New Label()
        p.AutoSize = False
        p.Size = New Size(68, 20)
        p.Location = New Point(x, y)
        p.Text = status
        p.TextAlign = ContentAlignment.MiddleCenter
        p.Font = New Font(FontName, 7.5F, FontStyle.Bold)
        p.BackColor = back
        p.ForeColor = fore
        Using gp As New GraphicsPath()
            Dim r As Integer = 20
            gp.AddArc(0, 0, r, r, 180, 90)
            gp.AddArc(p.Width - r, 0, r, r, 270, 90)
            gp.AddArc(p.Width - r, p.Height - r, r, r, 0, 90)
            gp.AddArc(0, p.Height - r, r, r, 90, 90)
            gp.CloseAllFigures()
            p.Region = New Region(gp)
        End Using
        parent.Controls.Add(p)
    End Sub

    Private Function JoinOrDefault(items As List(Of String), fallback As String) As String
        If items Is Nothing OrElse items.Count = 0 Then Return fallback
        Return String.Join(Bullet, items)
    End Function

    Private Function UpdatedText() As String
        If _details.UpdatedAt.Date = Date.Today Then
            Return "today at " & _details.UpdatedAt.ToString("h:mm tt", CultureInfo.InvariantCulture)
        End If
        Return "on " & _details.UpdatedAt.ToString("MMM d, yyyy", CultureInfo.InvariantCulture)
    End Function

    ' ============================================================
    '  DATA ACCESS  (sample data -> replace with database queries)
    ' ============================================================
    Private Function GetPatientDetails(patientId As String) As PatientDetails
        Dim item As PatientItem = PatientRepository.GetById(patientId)
        If item IsNot Nothing Then
            Dim conds As New List(Of String)()
            If Not String.IsNullOrWhiteSpace(item.KnownConditions) AndAlso Not item.KnownConditions.Equals("None reported", StringComparison.OrdinalIgnoreCase) Then
                conds.AddRange(item.KnownConditions.Split({"•", ",", ";"}, StringSplitOptions.RemoveEmptyEntries).Select(Function(s) s.Trim()))
            End If

            Dim allgs As New List(Of String)()
            If Not String.IsNullOrWhiteSpace(item.DrugAllergies) AndAlso Not item.DrugAllergies.Equals("None reported", StringComparison.OrdinalIgnoreCase) Then
                allgs.AddRange(item.DrugAllergies.Split({"•", ",", ";"}, StringSplitOptions.RemoveEmptyEntries).Select(Function(s) s.Trim()))
            End If

            Dim bDate As Date = Date.Today.AddYears(-item.Age)
            If item.BirthDate IsNot Nothing AndAlso item.BirthDate.Contains("Born ") Then
                Dim raw = item.BirthDate.Replace("Born ", "").Trim()
                Dim parsed As Date
                If Date.TryParse(raw, parsed) Then bDate = parsed
            End If

            Return New PatientDetails With {
                .PatientId = item.PatientId,
                .FullName = item.Name,
                .BirthDate = bDate,
                .Sex = item.Gender,
                .Phone = item.Contact,
                .Email = item.Email,
                .Address = item.Address,
                .Conditions = conds,
                .Allergies = allgs,
                .UpdatedAt = Date.Now
            }
        End If

        ' Fallback
        Return New PatientDetails With {
            .PatientId = patientId,
            .FullName = "Patient " & patientId,
            .BirthDate = New Date(1990, 1, 1),
            .Sex = "-",
            .Phone = "-",
            .Email = "-",
            .Address = "-",
            .Conditions = New List(Of String)(),
            .Allergies = New List(Of String)(),
            .UpdatedAt = Date.Now
        }
    End Function

    Private Function GetPatientVisits(patientId As String) As List(Of PatientVisit)
        Dim item As PatientItem = PatientRepository.GetById(patientId)
        Dim list As New List(Of PatientVisit)()
        If item IsNot Nothing AndAlso item.Visits IsNot Nothing Then
            For Each v In item.Visits
                Dim vDate As Date
                If Not Date.TryParse(v.VisitDate, vDate) Then vDate = Date.Today
                list.Add(New PatientVisit With {
                    .VisitDate = vDate,
                    .VisitType = v.VisitType,
                    .Notes = v.Diagnosis,
                    .Doctor = v.Doctor,
                    .Status = v.Status
                })
            Next
        End If
        Return list
    End Function

    Private Function GetPatientAppointments(patientId As String) As List(Of PatientAppointment)
        Dim item As PatientItem = PatientRepository.GetById(patientId)
        Dim list As New List(Of PatientAppointment)()
        If item IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(item.UpcomingDate) Then
            Dim doc = If(Not String.IsNullOrWhiteSpace(item.UpcomingDetails) AndAlso item.UpcomingDetails.Contains("•"),
                         item.UpcomingDetails.Split("•"c)(0).Trim(), "Dr. Elena Cruz")
            Dim purpose = If(Not String.IsNullOrWhiteSpace(item.UpcomingDetails) AndAlso item.UpcomingDetails.Contains("•"),
                            item.UpcomingDetails.Split("•"c)(1).Trim(), "Check-up")
            list.Add(New PatientAppointment With {
                .AppointmentDate = Date.Today.AddDays(7).AddHours(10),
                .Doctor = doc,
                .Purpose = purpose,
                .Status = If(String.IsNullOrWhiteSpace(item.UpcomingStatus), "Confirmed", item.UpcomingStatus)
            })
        End If
        Return list
    End Function

End Class

' ============================================================
'  Data classes
' ============================================================
Public Class PatientDetails
    Public Property PatientId As String
    Public Property FullName As String
    Public Property BirthDate As Date
    Public Property Sex As String
    Public Property Phone As String
    Public Property Email As String
    Public Property Address As String
    Public Property Conditions As List(Of String)
    Public Property Allergies As List(Of String)
    Public Property UpdatedAt As DateTime

    Public ReadOnly Property Age As Integer
        Get
            Dim today As Date = Date.Today
            Dim a As Integer = today.Year - BirthDate.Year
            If BirthDate.Date > today.AddYears(-a) Then a -= 1
            Return a
        End Get
    End Property
End Class

Public Class PatientVisit
    Public Property VisitDate As Date
    Public Property VisitType As String
    Public Property Notes As String
    Public Property Doctor As String
    Public Property Status As String
End Class

Public Class PatientAppointment
    Public Property AppointmentDate As DateTime
    Public Property Doctor As String
    Public Property Purpose As String
    Public Property Status As String
End Class