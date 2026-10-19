Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports System.Text
Imports Ferrando.UI.WinForms.Controles

Public Class ReceptionistClinicReports

    ' ------------------------------------------------------------------
    '  Look
    ' ------------------------------------------------------------------
    Private ReadOnly _teal As Color = Color.FromArgb(29, 124, 107)
    Private ReadOnly _navy As Color = Color.FromArgb(30, 45, 55)
    Private ReadOnly _blue As Color = Color.FromArgb(22, 80, 115)
    Private ReadOnly _muted As Color = Color.FromArgb(115, 138, 148)
    Private ReadOnly _line As Color = Color.FromArgb(232, 237, 240)

    Private ReadOnly _fontSmall As New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
    Private ReadOnly _fontBody As New Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
    Private ReadOnly _fontBold As New Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))

    ' UI Controls for Date Range Filter & Export
    Private txtStart As TextBox
    Private dtpStart As DateTimePicker
    Private txtEnd As TextBox
    Private dtpEnd As DateTimePicker
    Private btnApplyFilter As FButton
    Private btnExport As FButton
    Private pnlFilter As Panel

    ' Dynamic Data Containers
    Private _dailyLabels As New List(Of String)
    Private _dailyCounts As New List(Of Integer)
    Private _visitTypes As New List(Of ReportCountItem)
    Private _doctorRows As New List(Of ReportCountItem)
    Private pnlChart As Panel

    Public Sub New()
        InitializeComponent()
        SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        DoubleBuffered = True
        SetupDateFilter()
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
            .Location = New Point(280, 18),
            .Size = New Size(530, 36),
            .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
            .BackColor = Color.Transparent
        }

        Dim lblFrom As New Label With {
            .Text = "From:",
            .Font = _fontBold,
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
            .Font = _fontBold,
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
            .Text = "Apply Filter",
            .Font = _fontBold,
            .Location = New Point(288, 5),
            .Size = New Size(95, 27)
        }
        UIThemeHelper.ApplyPrimary(btnApplyFilter)
        AddHandler btnApplyFilter.Click, Sub(s, e) RefreshReportData()

        btnExport = New FButton With {
            .Text = "Export CSV",
            .Font = _fontBold,
            .Location = New Point(390, 5),
            .Size = New Size(95, 27)
        }
        UIThemeHelper.ApplySecondary(btnExport)
        AddHandler btnExport.Click, AddressOf BtnExport_Click

        pnlFilter.Controls.AddRange(New Control() {lblFrom, txtStart, dtpStart, lblTo, txtEnd, dtpEnd, btnApplyFilter, btnExport})
        Controls.Add(pnlFilter)
        pnlFilter.BringToFront()
    End Sub

    Private Sub ReceptionistClinicReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshReportData()
    End Sub

    Public Sub RefreshReportData()
        SuspendLayout()
        Dim startDate = dtpStart.Value.Date
        Dim endDate = dtpEnd.Value.Date

        If startDate > endDate Then
            Dim temp = startDate
            startDate = endDate
            endDate = temp
            dtpStart.Value = startDate
            dtpEnd.Value = endDate
        End If

        ' Query 1: Daily patient counts
        Dim dailyData = SqliteReportsRepository.GetDailyPatientCounts(startDate, endDate)
        _dailyLabels.Clear()
        _dailyCounts.Clear()
        If dailyData.Count > 0 Then
            For Each itm In dailyData
                _dailyLabels.Add(DateTime.Parse(itm.DateString).ToString("MMM dd"))
                _dailyCounts.Add(itm.Count)
            Next
        Else
            _dailyLabels.AddRange(New String() {"No Data"})
            _dailyCounts.Add(0)
        End If

        ' Query 2: Visit type distribution
        _visitTypes = SqliteReportsRepository.GetVisitTypeDistribution(startDate, endDate)

        ' Query 3: Per-doctor breakdown
        _doctorRows = SqliteReportsRepository.GetPerDoctorBreakdown(startDate, endDate)

        ' Summary Stats
        Dim stats = SqliteReportsRepository.GetSummaryStats(startDate, endDate)

        FillSummary(stats.Total, stats.Completed, stats.PatientsSeen, startDate, endDate)
        BuildDailyVolumeChart()
        BuildVisitTypes()
        BuildDoctorBreakdown()
        ResumeLayout()
    End Sub

    Private Sub FillSummary(total As Integer, completed As Integer, patientsSeen As Integer, startDate As DateTime, endDate As DateTime)
        Dim ci As CultureInfo = CultureInfo.InvariantCulture
        Dim rate As Integer = If(total > 0, CInt(Math.Round(completed * 100.0 / total)), 0)

        lblSubtitle.Text = $"Operational insights • {startDate.ToString("MMM d", ci)} - {endDate.ToString("MMM d, yyyy", ci)}"

        lblApptValue.Text = total.ToString(ci)
        lblApptNote.Text = $"{total} appointments booked"
        lblApptNote.ForeColor = _teal

        lblRateValue.Text = rate.ToString(ci) & "%"
        lblRateNote.Text = $"{completed} completed"

        lblSeenValue.Text = patientsSeen.ToString(ci)
        lblSeenNote.Text = $"{patientsSeen} unique patients"
    End Sub

    Private Sub BuildDailyVolumeChart()
        For i As Integer = cardVolume.Controls.Count - 1 To 0 Step -1
            Dim c = cardVolume.Controls(i)
            If c IsNot lblVolumeTitle AndAlso c IsNot pnlChart Then
                cardVolume.Controls.RemoveAt(i)
            End If
        Next

        lblVolumeTitle.Text = "Daily Patient Volume Trend"
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

                Using gradBrush As New Drawing2D.LinearGradientBrush(
                    New PointF(0, innerTop), New PointF(0, baseline),
                    Color.FromArgb(50, 29, 124, 107), Color.FromArgb(5, 29, 124, 107))
                    g.FillPath(gradBrush, path)
                End Using
            End Using

            ' Draw smooth line
            Using linePen As New Pen(_teal, 2.5F)
                linePen.LineJoin = Drawing2D.LineJoin.Round
                g.DrawLines(linePen, points.ToArray())
            End Using
        End If

        ' Data dots and labels
        Using dotBrush As New SolidBrush(_teal),
              centerBrush As New SolidBrush(Color.White),
              txtBrush As New SolidBrush(_navy),
              mutedBrush As New SolidBrush(_muted)

            For i As Integer = 0 To n - 1
                Dim pt = points(i)
                g.FillEllipse(dotBrush, pt.X - 4.5F, pt.Y - 4.5F, 9.0F, 9.0F)
                g.FillEllipse(centerBrush, pt.X - 2.0F, pt.Y - 2.0F, 4.0F, 4.0F)

                ' Value on top
                Dim valStr = _dailyCounts(i).ToString()
                Dim valSize = g.MeasureString(valStr, _fontSmall)
                g.DrawString(valStr, _fontSmall, txtBrush, pt.X - valSize.Width / 2.0F, pt.Y - 16)

                ' Date below baseline
                If i < _dailyLabels.Count Then
                    Dim lblStr = _dailyLabels(i)
                    Dim lblSize = g.MeasureString(lblStr, _fontSmall)
                    g.DrawString(lblStr, _fontSmall, mutedBrush, pt.X - lblSize.Width / 2.0F, baseline + 6)
                End If
            Next
        End Using
    End Sub

    Private Sub BuildVisitTypes()
        For i As Integer = cardDiagnoses.Controls.Count - 1 To 0 Step -1
            Dim c = cardDiagnoses.Controls(i)
            If c IsNot lblDiagTitle Then
                cardDiagnoses.Controls.RemoveAt(i)
            End If
        Next

        lblDiagTitle.Text = "Visit Types Distribution"

        Dim ci As CultureInfo = CultureInfo.InvariantCulture
        Dim bullet As String = " • "
        Dim valueX As Integer = 168
        Dim valueW As Integer = cardDiagnoses.Width - 18 - valueX

        Dim maxRows = Math.Min(_visitTypes.Count, 4)
        For i As Integer = 0 To maxRows - 1
            Dim row = _visitTypes(i)
            Dim y As Integer = 50 + i * 32

            cardDiagnoses.Controls.Add(MakeLabel(row.Label, 18, y, 145, 20, _fontBody, _navy))
            cardDiagnoses.Controls.Add(MakeLabel(row.Count.ToString(ci) & bullet & row.Percentage.ToString("0.0", ci) & "%",
                                                 valueX, y, valueW, 20, _fontBold, _blue, ContentAlignment.MiddleRight))
        Next
    End Sub

    Private Sub BuildDoctorBreakdown()
        For i As Integer = cardHistory.Controls.Count - 1 To 0 Step -1
            Dim c = cardHistory.Controls(i)
            If c IsNot lblHistoryTitle Then
                cardHistory.Controls.RemoveAt(i)
            End If
        Next

        lblHistoryTitle.Text = "Per-Doctor Appointments Breakdown"

        Dim ci As CultureInfo = CultureInfo.InvariantCulture
        Dim cols As Integer() = {18, 260, 480}
        Dim widths As Integer() = {230, 200, cardHistory.Width - 18 - 480}
        Dim headers As String() = {"Doctor Name", "Total Appointments", "Workload Share"}
        Dim lineWidth As Integer = cardHistory.Width - 36

        For c As Integer = 0 To headers.Length - 1
            cardHistory.Controls.Add(MakeLabel(headers(c), cols(c), 45, widths(c), 18, _fontSmall, _muted))
        Next
        cardHistory.Controls.Add(MakeLine(18, 68, lineWidth))

        Dim maxRows = Math.Min(_doctorRows.Count, 4)
        For i As Integer = 0 To maxRows - 1
            Dim d = _doctorRows(i)
            Dim top As Integer = 70 + i * 32
            Dim values As String() = {d.Label, d.Count.ToString(ci) & " appts", d.Percentage.ToString("0.0", ci) & "%"}

            For c As Integer = 0 To values.Length - 1
                cardHistory.Controls.Add(MakeLabel(values(c), cols(c), top + 6, widths(c), 18, _fontBody, _navy))
            Next
            cardHistory.Controls.Add(MakeLine(18, top + 28, lineWidth))
        Next
    End Sub

    ' ------------------------------------------------------------------
    '  Export CSV
    ' ------------------------------------------------------------------
    Private Sub BtnExport_Click(sender As Object, e As EventArgs)
        Using dlg As New SaveFileDialog()
            dlg.Title = "Export Clinic Report"
            dlg.Filter = "CSV file (*.csv)|*.csv"
            dlg.FileName = "clinic-operations-report.csv"

            If dlg.ShowDialog() = DialogResult.OK Then
                Try
                    File.WriteAllText(dlg.FileName, BuildCsv(), New UTF8Encoding(True))
                    MessageBox.Show("Report exported successfully to CSV.", "Export Report", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Failed to export report: " & ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Function BuildCsv() As String
        Dim sb As New StringBuilder()
        Dim Q = Function(v As String) """" & v.Replace("""", """""") & """"

        sb.AppendLine(Q("Clinic Report") & "," & Q(lblSubtitle.Text))
        sb.AppendLine()

        sb.AppendLine(Q("SUMMARY METRICS"))
        sb.AppendLine(Q("Total Booked") & "," & Q(lblApptValue.Text) & "," & Q(lblApptNote.Text))
        sb.AppendLine(Q("Completion Rate") & "," & Q(lblRateValue.Text) & "," & Q(lblRateNote.Text))
        sb.AppendLine(Q("Patients Seen") & "," & Q(lblSeenValue.Text) & "," & Q(lblSeenNote.Text))
        sb.AppendLine()

        sb.AppendLine(Q("DAILY PATIENT COUNTS"))
        sb.AppendLine(Q("Date") & "," & Q("Patients Seen"))
        For i As Integer = 0 To _dailyCounts.Count - 1
            Dim lbl = If(i < _dailyLabels.Count, _dailyLabels(i), "")
            sb.AppendLine(Q(lbl) & "," & _dailyCounts(i))
        Next
        sb.AppendLine()

        sb.AppendLine(Q("VISIT TYPES DISTRIBUTION"))
        sb.AppendLine(Q("Visit Type") & "," & Q("Count") & "," & Q("Percentage"))
        For Each v In _visitTypes
            sb.AppendLine(Q(v.Label) & "," & v.Count & "," & v.Percentage.ToString("0.0") & "%")
        Next
        sb.AppendLine()

        sb.AppendLine(Q("PER-DOCTOR BREAKDOWN"))
        sb.AppendLine(Q("Doctor Name") & "," & Q("Appointments") & "," & Q("Workload Share"))
        For Each d In _doctorRows
            sb.AppendLine(Q(d.Label) & "," & d.Count & "," & d.Percentage.ToString("0.0") & "%")
        Next

        Return sb.ToString()
    End Function

    Private Function MakeLabel(text As String, x As Integer, y As Integer, w As Integer, h As Integer,
                               f As Font, fore As Color,
                               Optional align As ContentAlignment = ContentAlignment.MiddleLeft) As Label
        Return New Label With {
            .AutoSize = False,
            .BackColor = Color.Transparent,
            .Font = f,
            .ForeColor = fore,
            .Location = New Point(x, y),
            .Size = New Size(w, h),
            .Text = text,
            .TextAlign = align
        }
    End Function

    Private Function MakeLine(x As Integer, y As Integer, w As Integer) As Panel
        Return New Panel With {
            .BackColor = _line,
            .Location = New Point(x, y),
            .Size = New Size(w, 1)
        }
    End Function

End Class