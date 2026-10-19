Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports System.Text
Imports Ferrando.UI.WinForms.Controles

Public Class DoctorReports

    Private sidebarHandler As SidebarHandler

    ' Dynamic UI for date filtering
    Private txtStart As TextBox
    Private txtEnd As TextBox
    Private dtpStart As DateTimePicker
    Private dtpEnd As DateTimePicker
    Private btnApplyFilter As FButton
    Private pnlFilter As Panel

    ' Data containers
    Private _dailyLabels As New List(Of String)
    Private _dailyCounts As New List(Of Integer)
    Private _visitTypes As New List(Of ReportCountItem)
    Private _doctorRows As New List(Of ReportCountItem)
    Private _clinicalOrders As New List(Of ReportCountItem)
    Private ReadOnly _tip As New ToolTip()
    Private pnlChart As Panel

    Public Sub New()
        InitializeComponent()
        SetupDateFilter()
        UIThemeHelper.ApplySecondary(btnExport)
        If cardVolume IsNot Nothing Then
            pnlChart = New Panel With {
                .Location = New Point(16, 38),
                .Size = New Size(cardVolume.ClientSize.Width - 32, cardVolume.ClientSize.Height - 48),
                .BackColor = Color.White
            }
            cardVolume.Controls.Add(pnlChart)
            pnlChart.BringToFront()
            AddHandler pnlChart.Paint, AddressOf CardVolume_Paint
        End If
    End Sub

    Private Sub SetupDateFilter()
        pnlFilter = New Panel With {
            .Location = New Point(230, 18),
            .Size = New Size(470, 36),
            .BackColor = Color.Transparent
        }

        Dim lblFrom As New Label With {
            .Text = "From:",
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(70, 90, 105),
            .AutoSize = True,
            .Location = New Point(0, 8)
        }

        txtStart = New TextBox With {
            .Font = New Font("Segoe UI", 8.5F),
            .Text = "2026-09-01",
            .Location = New Point(42, 6),
            .Width = 82
        }

        dtpStart = New DateTimePicker With {
            .Format = DateTimePickerFormat.Custom,
            .CustomFormat = " ",
            .Font = New Font("Segoe UI", 8.5F),
            .Value = New DateTime(2026, 9, 1),
            .Location = New Point(125, 5),
            .Width = 20
        }
        AddHandler dtpStart.ValueChanged, Sub() txtStart.Text = dtpStart.Value.ToString("yyyy-MM-dd")
        AddHandler txtStart.TextChanged, Sub()
                                             Dim parsed As DateTime
                                             If DateTime.TryParse(txtStart.Text.Trim(), parsed) Then
                                                 If parsed >= dtpStart.MinDate AndAlso parsed <= dtpStart.MaxDate Then
                                                     dtpStart.Value = parsed
                                                 End If
                                             End If
                                         End Sub

        Dim lblTo As New Label With {
            .Text = "To:",
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(70, 90, 105),
            .AutoSize = True,
            .Location = New Point(152, 8)
        }

        txtEnd = New TextBox With {
            .Font = New Font("Segoe UI", 8.5F),
            .Text = "2026-09-30",
            .Location = New Point(176, 6),
            .Width = 82
        }

        dtpEnd = New DateTimePicker With {
            .Format = DateTimePickerFormat.Custom,
            .CustomFormat = " ",
            .Font = New Font("Segoe UI", 8.5F),
            .Value = New DateTime(2026, 9, 30),
            .Location = New Point(259, 5),
            .Width = 20
        }
        AddHandler dtpEnd.ValueChanged, Sub() txtEnd.Text = dtpEnd.Value.ToString("yyyy-MM-dd")
        AddHandler txtEnd.TextChanged, Sub()
                                           Dim parsed As DateTime
                                           If DateTime.TryParse(txtEnd.Text.Trim(), parsed) Then
                                               If parsed >= dtpEnd.MinDate AndAlso parsed <= dtpEnd.MaxDate Then
                                                   dtpEnd.Value = parsed
                                               End If
                                           End If
                                       End Sub

        btnApplyFilter = New FButton With {
            .Text = "Filter",
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
            .Location = New Point(288, 5),
            .Size = New Size(75, 27)
        }
        UIThemeHelper.ApplyPrimary(btnApplyFilter)
        AddHandler btnApplyFilter.Click, Sub(s, e) RefreshReportData()

        pnlFilter.Controls.AddRange(New Control() {lblFrom, txtStart, dtpStart, lblTo, txtEnd, dtpEnd, btnApplyFilter})
        mainScreen.Controls.Add(pnlFilter)
        pnlFilter.BringToFront()
    End Sub

    Private Sub DoctorReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sidebarHandler = New SidebarHandler(btnDashboard, btnPatients, btnAppointment,
                                            btnDoctor, btnConsultation, btnReports)
        sidebarHandler.SetActive(btnReports)

        If CurrentUser.IsAuthenticated Then
            txtName.Text = CurrentUser.FullName
            txtRole.Text = If(CurrentUser.Role = "Doctor", "General Physician", CurrentUser.RoleDisplay)
        End If

        ' Wire Clickable KPI Metrics (Drill-down to matching patient list)
        For Each c In New Control() {Ctl(Of Control)("cardKpi1"), Ctl(Of Control)("lblKpi1Value"), Ctl(Of Control)("lblKpi1Context")}
            If c IsNot Nothing Then
                c.Cursor = Cursors.Hand
                AddHandler c.Click, Sub() ShowDrillDown("Total")
            End If
        Next
        For Each c In New Control() {Ctl(Of Control)("cardKpi2"), Ctl(Of Control)("lblKpi2Value"), Ctl(Of Control)("lblKpi2Context")}
            If c IsNot Nothing Then
                c.Cursor = Cursors.Hand
                AddHandler c.Click, Sub() ShowDrillDown("Completed")
            End If
        Next
        For Each c In New Control() {Ctl(Of Control)("cardKpi3"), Ctl(Of Control)("lblKpi3Value"), Ctl(Of Control)("lblKpi3Context")}
            If c IsNot Nothing Then
                c.Cursor = Cursors.Hand
                AddHandler c.Click, Sub() ShowDrillDown("PatientsSeen")
            End If
        Next

        RefreshReportData()
    End Sub

    Private Sub ShowDrillDown(metricType As String)
        Dim startDate = dtpStart.Value.Date
        Dim endDate = dtpEnd.Value.Date
        Dim currentDoc = If(CurrentUser.IsAuthenticated, CurrentUser.FullName, "Dr. Elena Cruz")
        Dim isDoctor = (CurrentUser.Role = "Doctor" OrElse Not CurrentUser.IsAuthenticated)
        Dim queryDoc = If(isDoctor, currentDoc, Nothing)

        Dim title As String = ""
        Select Case metricType
            Case "Total"
                title = $"Total Appointments ({Ctl(Of Label)("lblKpi1Value").Text})"
            Case "Completed"
                title = $"Completed Consultations ({Ctl(Of Label)("lblKpi2Value").Text})"
            Case "PatientsSeen"
                title = $"Unique Patients Seen ({Ctl(Of Label)("lblKpi3Value").Text})"
        End Select

        Dim items = SqliteReportsRepository.GetAppointmentsForMetric(metricType, startDate, endDate, queryDoc)
        Dim dlg As New DoctorReportsDrillDownDialog(title, items)
        dlg.ShowDialog(Me)
    End Sub

    Private Function Ctl(Of T As Control)(name As String) As T
        Dim found As Control() = Controls.Find(name, True)
        If found.Length = 0 Then Return Nothing
        Return DirectCast(found(0), T)
    End Function

    Public Sub RefreshReportData()
        Dim startDate = dtpStart.Value.Date
        Dim endDate = dtpEnd.Value.Date
        If startDate > endDate Then
            Dim temp = startDate
            startDate = endDate
            endDate = temp
            dtpStart.Value = startDate
            dtpEnd.Value = endDate
        End If

        Dim currentDoc = If(CurrentUser.IsAuthenticated, CurrentUser.FullName, "Dr. Elena Cruz")
        Dim isDoctor = (CurrentUser.Role = "Doctor" OrElse Not CurrentUser.IsAuthenticated)
        Dim queryDoc = If(isDoctor, currentDoc, Nothing)

        ' Query 1: Daily counts (scoped to current doctor)
        Dim dailyData = SqliteReportsRepository.GetDailyPatientCounts(startDate, endDate, queryDoc)
        _dailyLabels.Clear()
        _dailyCounts.Clear()
        If dailyData.Count > 0 Then
            For Each itm In dailyData
                _dailyLabels.Add(DateTime.Parse(itm.DateString).ToString("MMM dd"))
                _dailyCounts.Add(itm.Count)
            Next
        Else
            _dailyLabels.AddRange(New String() {"No data"})
            _dailyCounts.Add(0)
        End If

        ' Query 2: Visit type distribution (scoped to current doctor)
        _visitTypes = SqliteReportsRepository.GetVisitTypeDistribution(startDate, endDate, queryDoc)

        ' Query 3: Clinical orders (prescriptions & labs) for doctor; per-doctor breakdown for admin
        _clinicalOrders = SqliteReportsRepository.GetTopClinicalOrders(startDate, endDate, queryDoc)
        _doctorRows = SqliteReportsRepository.GetPerDoctorBreakdown(startDate, endDate)

        ' Summary Stats (scoped to current doctor)
        Dim stats = SqliteReportsRepository.GetSummaryStats(startDate, endDate, queryDoc)

        Dim ci = CultureInfo.InvariantCulture
        Dim docScopeNotice = If(isDoctor, $" • Doctor: {currentDoc}", "")
        lblSubtitle.Text = $"Operational insights • {startDate.ToString("MMM d", ci)} - {endDate.ToString("MMM d, yyyy", ci)}{docScopeNotice}"

        Ctl(Of Label)("lblKpi1Value").Text = stats.Total.ToString()
        Ctl(Of Label)("lblKpi1Context").Text = $"{stats.Total} total appointments (Click to view)"

        Ctl(Of Label)("lblKpi2Value").Text = stats.Completed.ToString()
        Ctl(Of Label)("lblKpi2Context").Text = If(stats.Total > 0, $"{Math.Round(stats.Completed * 100.0 / stats.Total)}% completion rate (Click to view)", "0% completion rate (Click to view)")

        Ctl(Of Label)("lblKpi3Value").Text = stats.PatientsSeen.ToString()
        Ctl(Of Label)("lblKpi3Context").Text = $"{stats.PatientsSeen} unique patients (Click to view)"

        BuildVolumeChart()
        BuildDiagnoses()
        BuildDoctorBreakdown()
    End Sub

    ' ------------------------------------------------------------------ chart

    Private Sub BuildVolumeChart()
        ' Hide legacy bar elements so the smooth line graph renders cleanly
        For i As Integer = 0 To 4
            Dim bar As FCard = Ctl(Of FCard)("cardBar" & (i + 1))
            Dim lbl As Label = Ctl(Of Label)("lblWeek" & (i + 1))
            If bar IsNot Nothing Then bar.Visible = False
            If lbl IsNot Nothing Then lbl.Visible = False
        Next

        If pnlChart IsNot Nothing Then
            pnlChart.Invalidate()
        End If
    End Sub

    Private Sub CardVolume_Paint(sender As Object, e As PaintEventArgs)
        If pnlChart Is Nothing Then Return
        Dim g = e.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        Const innerLeft As Integer = 20
        Const innerTop As Integer = 16
        Dim innerWidth As Integer = pnlChart.ClientSize.Width - innerLeft - 20
        Dim innerHeight As Integer = pnlChart.ClientSize.Height - innerTop - 30
        Dim baseline As Integer = innerTop + innerHeight

        If _dailyCounts.Count = 0 OrElse (_dailyCounts.Count = 1 AndAlso _dailyCounts(0) = 0) Then
            Using fontMsg As New Font("Segoe UI", 9.0F, FontStyle.Regular),
                  msgBrush As New SolidBrush(Color.FromArgb(140, 155, 165)),
                  sfMsg As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                g.DrawString("No appointment activity recorded in this period", fontMsg, msgBrush, New RectangleF(0, 0, pnlChart.ClientSize.Width, pnlChart.ClientSize.Height), sfMsg)
            End Using
            Return
        End If

        Dim maxCount As Integer = Math.Max(1, _dailyCounts.Max())
        Dim n = _dailyCounts.Count

        ' Draw subtle grid lines
        Using gridPen As New Pen(Color.FromArgb(238, 243, 246), 1)
            g.DrawLine(gridPen, innerLeft, innerTop, innerLeft + innerWidth, innerTop)
            g.DrawLine(gridPen, innerLeft, innerTop + innerHeight \ 2, innerLeft + innerWidth, innerTop + innerHeight \ 2)
            g.DrawLine(gridPen, innerLeft, baseline, innerLeft + innerWidth, baseline)
        End Using

        Dim points As New List(Of PointF)
        For i As Integer = 0 To n - 1
            Dim x As Single = If(n > 1, innerLeft + CSng(i * innerWidth / (n - 1)), innerLeft + innerWidth / 2.0F)
            Dim y As Single = baseline - CSng(_dailyCounts(i) / maxCount * (innerHeight - 20))
            points.Add(New PointF(x, y))
        Next

        If points.Count >= 2 Then
            ' Gradient under line
            Using path As New Drawing2D.GraphicsPath()
                path.AddLine(points(0).X, baseline, points(0).X, points(0).Y)
                path.AddLines(points.ToArray())
                path.AddLine(points.Last().X, points.Last().Y, points.Last().X, baseline)
                path.CloseFigure()
                Using fillBrush As New Drawing2D.LinearGradientBrush(New PointF(0, innerTop), New PointF(0, baseline), Color.FromArgb(45, 35, 137, 120), Color.FromArgb(4, 35, 137, 120))
                    g.FillPath(fillBrush, path)
                End Using
            End Using

            ' Trend line
            Using linePen As New Pen(Color.FromArgb(35, 137, 120), 2.5F)
                g.DrawLines(linePen, points.ToArray())
            End Using
        End If

        ' Data points and labels
        Using dotBrush As New SolidBrush(Color.FromArgb(35, 137, 120)),
              dotBorder As New Pen(Color.White, 2.0F),
              lblBrush As New SolidBrush(Color.FromArgb(22, 51, 65)),
              dateBrush As New SolidBrush(Color.FromArgb(120, 140, 150)),
              fontVal As New Font("Segoe UI", 8.0F, FontStyle.Bold),
              fontDate As New Font("Segoe UI", 7.5F, FontStyle.Regular)

            Dim sf As New StringFormat() With {.Alignment = StringAlignment.Center}
            For i As Integer = 0 To points.Count - 1
                Dim pt = points(i)
                g.FillEllipse(dotBrush, pt.X - 4.5F, pt.Y - 4.5F, 9.0F, 9.0F)
                g.DrawEllipse(dotBorder, pt.X - 4.5F, pt.Y - 4.5F, 9.0F, 9.0F)

                ' Number above point
                g.DrawString(_dailyCounts(i).ToString(), fontVal, lblBrush, pt.X, pt.Y - 17, sf)

                ' Date label below baseline
                If i < _dailyLabels.Count Then
                    g.DrawString(_dailyLabels(i), fontDate, dateBrush, pt.X, baseline + 5, sf)
                End If
            Next
        End Using
    End Sub

    Private Sub BuildDiagnoses()
        Dim ci = CultureInfo.InvariantCulture
        For i As Integer = 1 To 4
            Dim nameLbl = Ctl(Of Label)("lblDiag" & i & "Name")
            Dim valLbl = Ctl(Of Label)("lblDiag" & i & "Value")
            If nameLbl Is Nothing OrElse valLbl Is Nothing Then Continue For

            If i - 1 < _visitTypes.Count Then
                Dim itm = _visitTypes(i - 1)
                nameLbl.Visible = True
                valLbl.Visible = True
                nameLbl.Text = itm.Label
                valLbl.Text = $"{itm.Count} • {itm.Percentage:0.0}%"
            Else
                nameLbl.Visible = False
                valLbl.Visible = False
            End If
        Next
    End Sub

    Private Sub BuildDoctorBreakdown()
        Dim ci = CultureInfo.InvariantCulture
        Dim isDoctor = (CurrentUser.Role = "Doctor" OrElse Not CurrentUser.IsAuthenticated)

        If isDoctor Then
            ' Doctor Portal shows Top Prescribed Medications and Ordered Diagnostic Tests
            Dim lblHist = Ctl(Of Label)("lblHistoryTitle")
            If lblHist IsNot Nothing Then
                lblHist.UseMnemonic = False
                lblHist.Text = "Most Prescribed Medications & Diagnostic Orders"
            End If
            Ctl(Of Label)("lblCol1").Text = "Medication / Lab Test"
            Ctl(Of Label)("lblCol2").Text = "Frequency"
            Ctl(Of Label)("lblCol3").Text = "Share"
            Ctl(Of Label)("lblCol4").Text = "Category"

            For i As Integer = 1 To 3
                Dim r1 = Ctl(Of Label)("lblRow" & i & "Col1")
                Dim r2 = Ctl(Of Label)("lblRow" & i & "Col2")
                Dim r3 = Ctl(Of Label)("lblRow" & i & "Col3")
                Dim r4 = Ctl(Of Label)("lblRow" & i & "Col4")
                If r1 Is Nothing Then Continue For

                If i - 1 < _clinicalOrders.Count Then
                    Dim ord = _clinicalOrders(i - 1)
                    r1.Visible = True
                    r2.Visible = True
                    r3.Visible = True
                    r4.Visible = True
                    r1.Text = ord.Label
                    r2.Text = ord.Count.ToString(ci) & " orders"
                    r3.Text = $"{ord.Percentage:0.0}%"
                    r4.Text = ord.Category
                Else
                    r1.Visible = False
                    r2.Visible = False
                    r3.Visible = False
                    r4.Visible = False
                End If
            Next
        Else
            ' Admin Portal maintains per-doctor breakdown
            Ctl(Of Label)("lblHistoryTitle").Text = "Per-Doctor Appointments Breakdown"
            Ctl(Of Label)("lblCol1").Text = "Doctor"
            Ctl(Of Label)("lblCol2").Text = "Appointments"
            Ctl(Of Label)("lblCol3").Text = "Share"
            Ctl(Of Label)("lblCol4").Text = "Role"

            For i As Integer = 1 To 3
                Dim r1 = Ctl(Of Label)("lblRow" & i & "Col1")
                Dim r2 = Ctl(Of Label)("lblRow" & i & "Col2")
                Dim r3 = Ctl(Of Label)("lblRow" & i & "Col3")
                Dim r4 = Ctl(Of Label)("lblRow" & i & "Col4")
                If r1 Is Nothing Then Continue For

                If i - 1 < _doctorRows.Count Then
                    Dim d = _doctorRows(i - 1)
                    r1.Visible = True
                    r2.Visible = True
                    r3.Visible = True
                    r4.Visible = True
                    r1.Text = d.Label
                    r2.Text = d.Count.ToString(ci) & " appts"
                    r3.Text = $"{d.Percentage:0.0}%"
                    r4.Text = "Doctor"
                Else
                    r1.Visible = False
                    r2.Visible = False
                    r3.Visible = False
                    r4.Visible = False
                End If
            Next
        End If
    End Sub

    ' ------------------------------------------------------------------ export

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Using dlg As New SaveFileDialog()
            dlg.Title = "Export report"
            dlg.Filter = "CSV file (*.csv)|*.csv"
            dlg.FileName = "clinic-report.csv"

            If dlg.ShowDialog() <> DialogResult.OK Then Return

            Try
                File.WriteAllText(dlg.FileName, BuildCsv(), New UTF8Encoding(True))
                MessageBox.Show("Report exported.", "Export report", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Could not export the report: " & ex.Message, "Export report",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Shared Function Q(value As String) As String
        Return """" & value.Replace("""", """""") & """"
    End Function

    Private Function BuildCsv() As String
        Dim sb As New StringBuilder()

        sb.AppendLine(Q("Report") & "," & Q(lblSubtitle.Text))
        sb.AppendLine()

        sb.AppendLine(Q("Summary"))
        For i As Integer = 1 To 3
            sb.AppendLine(Q(Ctl(Of Label)("lblKpi" & i & "Title").Text) & "," &
                          Q(Ctl(Of Label)("lblKpi" & i & "Value").Text) & "," &
                          Q(Ctl(Of Label)("lblKpi" & i & "Context").Text))
        Next
        sb.AppendLine()

        sb.AppendLine(Q("Daily Patient Counts"))
        sb.AppendLine(Q("Date") & "," & Q("Patients"))
        For i As Integer = 0 To _dailyCounts.Count - 1
            sb.AppendLine(Q(_dailyLabels(i)) & "," & _dailyCounts(i))
        Next
        sb.AppendLine()

        sb.AppendLine(Q("Visit Types Distribution"))
        sb.AppendLine(Q("Visit Type") & "," & Q("Count") & "," & Q("Share"))
        For Each vt In _visitTypes
            sb.AppendLine(Q(vt.Label) & "," & vt.Count & "," & vt.Percentage & "%")
        Next
        sb.AppendLine()

        sb.AppendLine(Q("Per-Doctor Breakdown"))
        sb.AppendLine(Q("Doctor") & "," & Q("Appointments") & "," & Q("Share"))
        For Each dr In _doctorRows
            sb.AppendLine(Q(dr.Label) & "," & dr.Count & "," & dr.Percentage & "%")
        Next

        Return sb.ToString()
    End Function

    ' ------------------------------------------------------------------ sidebar navigation

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        If DoctorShell.Current IsNot Nothing Then
            DoctorShell.Current.NavigateTo(DoctorTab.Dashboard)
        Else
            Dim f As New DoctorDashboard()
            f.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub btnPatients_Click(sender As Object, e As EventArgs) Handles btnPatients.Click
        If DoctorShell.Current IsNot Nothing Then
            DoctorShell.Current.NavigateTo(DoctorTab.Patients)
        Else
            Dim f As New DoctorPatients()
            f.Show()
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
        If DoctorShell.Current IsNot Nothing Then DoctorShell.Current.NavigateTo(DoctorTab.Reports)
    End Sub

    Private Sub DoctorReports_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If DoctorShell.Current Is Nothing Then
            Application.Exit()
        End If
    End Sub

End Class

' Compatibility alias
Public Class Reports
    Inherits DoctorReports
End Class