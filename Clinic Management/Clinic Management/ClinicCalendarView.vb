Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.Windows.Forms

Public Class ClinicCalendarView
    Inherits UserControl

    Public Event EventClicked(item As AppointmentItem)
    Public Event SlotClicked(targetDate As DateTime, startMinutes As Integer)
    Public Event AvailabilitySlotClicked(slot As SlotItem)

    Private Const GutterWidth As Integer = 56
    Private Const StartHour As Integer = 8        ' 8:00 AM
    Private Const EndHour As Integer = 18         ' 6:00 PM
    Private Const TotalHours As Integer = 10      ' 8 to 18
    Private Const HourHeight As Integer = 52
    Private Const DayCount As Integer = 5         ' Mon - Fri (or Sat if needed)

    ' Space above the first (8 AM) gridline so its time label is not clipped
    Private Const GridTopPad As Integer = 10

    Private _currentWeekMonday As DateTime
    Private _appointments As New List(Of AppointmentItem)()
    Private _slots As New List(Of SlotItem)()

    ' Cached bounds for hit-testing (stored WITHOUT the GridTopPad offset)
    Private Class RenderedEvent
        Public Bounds As Rectangle
        Public Appointment As AppointmentItem
        Public Slot As SlotItem
    End Class
    Private ReadOnly _renderedEvents As New List(Of RenderedEvent)()

    Private pnlHeader As Panel
    Private pnlScroll As Panel
    Private pnlGrid As Panel

    Public Property WeekMonday As DateTime
        Get
            Return _currentWeekMonday
        End Get
        Set(value As DateTime)
            _currentWeekMonday = value.Date
            InvalidateAll()
        End Set
    End Property

    Public Sub New()
        SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint, True)
        Me.DoubleBuffered = True
        Me.BackColor = Color.White
        Me.Font = New Font("Segoe UI", 9.0F)

        Dim today = DateTime.Today
        Dim diff = (7 + (CInt(today.DayOfWeek) - CInt(DayOfWeek.Monday))) Mod 7
        _currentWeekMonday = today.AddDays(-diff).Date

        BuildUi()
    End Sub

    Private Sub BuildUi()
        Me.Controls.Clear()

        ' 1. Sticky Header
        pnlHeader = New Panel With {
            .Dock = DockStyle.Top,
            .Height = 52,
            .BackColor = Color.White
        }
        AddHandler pnlHeader.Paint, AddressOf Header_Paint
        Me.Controls.Add(pnlHeader)

        ' 2. Scrollable Body
        pnlScroll = New Panel With {
            .Dock = DockStyle.Fill,
            .AutoScroll = True,
            .BackColor = Color.White
        }

        pnlGrid = New Panel With {
            .Location = New Point(0, 0),
            .Size = New Size(pnlHeader.Width, TotalHours * HourHeight + GridTopPad + 20),
            .BackColor = Color.White
        }
        AddHandler pnlGrid.Paint, AddressOf Grid_Paint
        AddHandler pnlGrid.MouseClick, AddressOf Grid_MouseClick
        AddHandler pnlGrid.MouseMove, AddressOf Grid_MouseMove

        pnlScroll.Controls.Add(pnlGrid)
        Me.Controls.Add(pnlScroll)
        pnlHeader.SendToBack()

        AddHandler Me.Resize, Sub()
                                  pnlHeader.Invalidate()
                                  pnlGrid.Width = Math.Max(pnlScroll.ClientSize.Width, 600)
                                  pnlGrid.Invalidate()
                              End Sub
    End Sub

    Public Sub SetAppointments(appts As List(Of AppointmentItem))
        _appointments = If(appts, New List(Of AppointmentItem)())
        InvalidateAll()
    End Sub

    Public Sub SetSlots(slots As List(Of SlotItem))
        _slots = If(slots, New List(Of SlotItem)())
        InvalidateAll()
    End Sub

    Public Sub InvalidateAll()
        If pnlHeader IsNot Nothing Then pnlHeader.Invalidate()
        If pnlGrid IsNot Nothing Then
            pnlGrid.Width = Math.Max(pnlScroll.ClientSize.Width, 600)
            pnlGrid.Invalidate()
        End If
    End Sub

    ' =========================================================================
    '  Painting: Sticky Day Header
    ' =========================================================================

    Private Sub Header_Paint(sender As Object, e As PaintEventArgs)
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        Dim w = pnlHeader.ClientSize.Width
        Dim availW = w - GutterWidth
        Dim colW = availW / CDbl(DayCount)
        Dim today = DateTime.Today

        ' Timezone / Gutter label
        Using brMuted As New SolidBrush(Color.FromArgb(128, 140, 150))
            Using fTz As New Font("Segoe UI", 7.5F, FontStyle.Regular)
                g.DrawString("GMT+8", fTz, brMuted, 10, 20)
            End Using
        End Using

        ' Day columns
        Dim dayNames = {"MON", "TUE", "WED", "THU", "FRI"}
        For d As Integer = 0 To DayCount - 1
            Dim colDate = _currentWeekMonday.AddDays(d)
            Dim colLeft = CInt(GutterWidth + d * colW)
            Dim colCenter = colLeft + CInt(colW / 2.0)
            Dim isToday = (colDate.Date = today.Date)

            ' Day name (e.g. MON)
            Dim dayText = dayNames(d)
            Using fDay As New Font("Segoe UI", 7.5F, FontStyle.Bold)
                Using brDay As New SolidBrush(If(isToday, Color.FromArgb(35, 137, 120), Color.FromArgb(115, 125, 135)))
                    Dim sz = g.MeasureString(dayText, fDay)
                    g.DrawString(dayText, fDay, brDay, colCenter - (sz.Width / 2.0F), 6)
                End Using
            End Using

            ' Date circle badge (e.g. 21)
            Dim dateText = colDate.Day.ToString()
            Dim circleSize = 28
            Dim circleRect As New Rectangle(colCenter - 14, 20, circleSize, circleSize)

            Using fDate As New Font("Segoe UI", 9.5F, FontStyle.Bold)
                If isToday Then
                    Using brCircle As New SolidBrush(Color.FromArgb(35, 137, 120))
                        g.FillEllipse(brCircle, circleRect)
                    End Using
                    Using brText As New SolidBrush(Color.White)
                        Dim sz = g.MeasureString(dateText, fDate)
                        g.DrawString(dateText, fDate, brText, colCenter - (sz.Width / 2.0F), 20 + ((circleSize - sz.Height) / 2.0F))
                    End Using
                Else
                    Using brText As New SolidBrush(Color.FromArgb(30, 45, 55))
                        Dim sz = g.MeasureString(dateText, fDate)
                        g.DrawString(dateText, fDate, brText, colCenter - (sz.Width / 2.0F), 20 + ((circleSize - sz.Height) / 2.0F))
                    End Using
                End If
            End Using

            ' Vertical separator
            If d > 0 Then
                Using pLine As New Pen(Color.FromArgb(232, 237, 240))
                    g.DrawLine(pLine, colLeft, 0, colLeft, pnlHeader.Height)
                End Using
            End If
        Next

        ' Bottom border of header
        Using pBorder As New Pen(Color.FromArgb(220, 226, 230), 1)
            g.DrawLine(pBorder, 0, pnlHeader.Height - 1, w, pnlHeader.Height - 1)
        End Using
    End Sub

    ' =========================================================================
    '  Painting: Main Calendar Grid & Events
    ' =========================================================================

    Private Sub Grid_Paint(sender As Object, e As PaintEventArgs)
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        ' Shift everything down so the 8 AM label (centered on the first line) is not cut off
        g.TranslateTransform(0, GridTopPad)

        _renderedEvents.Clear()
        Dim w = pnlGrid.ClientSize.Width
        Dim availW = w - GutterWidth
        Dim colW = availW / CDbl(DayCount)
        Dim today = DateTime.Today

        ' 1. Grid Lines & Time Labels
        Using pGridHour As New Pen(Color.FromArgb(232, 237, 240), 1)
            Using pGridHalf As New Pen(Color.FromArgb(246, 248, 250), 1)
                pGridHalf.DashStyle = DashStyle.Dash
                Using fTime As New Font("Segoe UI", 7.5F, FontStyle.Regular)
                    Using brTime As New SolidBrush(Color.FromArgb(120, 135, 145))

                        For h As Integer = 0 To TotalHours
                            Dim y = h * HourHeight
                            Dim hourVal = StartHour + h
                            Dim ampm = If(hourVal >= 12, "PM", "AM")
                            Dim h12 = hourVal Mod 12
                            If h12 = 0 Then h12 = 12
                            Dim timeLabel = $"{h12} {ampm}"

                            ' Draw Time Label (centered vertically on the line)
                            If h < TotalHours Then
                                Dim sz = g.MeasureString(timeLabel, fTime)
                                g.DrawString(timeLabel, fTime, brTime, GutterWidth - sz.Width - 8, y - (sz.Height / 2.0F) + 1)
                            End If

                            ' Horizontal hour line
                            g.DrawLine(pGridHour, GutterWidth, y, w, y)

                            ' Half-hour dashed line
                            If h < TotalHours Then
                                Dim halfY = y + CInt(HourHeight / 2)
                                g.DrawLine(pGridHalf, GutterWidth, halfY, w, halfY)
                            End If
                        Next
                    End Using
                End Using
            End Using
        End Using

        ' Vertical day dividers
        Using pCol As New Pen(Color.FromArgb(232, 237, 240), 1)
            For d As Integer = 0 To DayCount
                Dim x = CInt(GutterWidth + d * colW)
                g.DrawLine(pCol, x, 0, x, TotalHours * HourHeight)
            Next
        End Using

        ' 2. Render Slots & Appointments for each Day column
        For d As Integer = 0 To DayCount - 1
            Dim colDate = _currentWeekMonday.AddDays(d)
            Dim colLeft = CInt(GutterWidth + d * colW) + 2
            Dim eventW = CInt(colW) - 4

            ' Render Booked Appointments for this day
            Dim dayAppts = _appointments.Where(Function(a) a.MatchesDate(colDate)).ToList()
            For Each appt In dayAppts
                Dim startMins = appt.Minutes
                If startMins >= (StartHour * 60) AndAlso startMins < (EndHour * 60) Then
                    Dim y = CInt((startMins - (StartHour * 60)) * (HourHeight / 60.0))
                    Dim dur = 30
                    Dim h = Math.Max(28, CInt(dur * (HourHeight / 60.0)) - 2)

                    Dim rect As New Rectangle(colLeft, y, eventW, h)
                    DrawAppointmentChip(g, rect, appt)
                    _renderedEvents.Add(New RenderedEvent With {.Bounds = rect, .Appointment = appt})
                End If
            Next

            ' Render Slots (Available / Blocked)
            Dim daySlots = _slots.Where(Function(s) s.MatchesDate(colDate)).ToList()
            For Each slot In daySlots
                ' Don't draw ANY slot chip (Available or Blocked) if an appointment is already booked at that time
                If dayAppts.Any(Function(a) a.Minutes = slot.Minutes) Then
                    Continue For
                End If

                Dim startMins = slot.Minutes
                If startMins >= (StartHour * 60) AndAlso startMins < (EndHour * 60) Then
                    Dim y = CInt((startMins - (StartHour * 60)) * (HourHeight / 60.0))
                    Dim dur = If(slot.DurationMinutes > 0, slot.DurationMinutes, 30)
                    Dim h = Math.Max(24, CInt(dur * (HourHeight / 60.0)) - 2)

                    Dim rect As New Rectangle(colLeft, y, eventW, h)
                    DrawSlotChip(g, rect, slot)
                    _renderedEvents.Add(New RenderedEvent With {.Bounds = rect, .Slot = slot})
                End If
            Next
        Next

        ' 4. Real-Time Red Indicator Line for Today
        If today >= _currentWeekMonday AndAlso today <= _currentWeekMonday.AddDays(DayCount - 1) Then
            Dim todayOffset = CInt((today.Date - _currentWeekMonday.Date).TotalDays)
            Dim nowMins = DateTime.Now.Hour * 60 + DateTime.Now.Minute
            If nowMins >= (StartHour * 60) AndAlso nowMins <= (EndHour * 60) Then
                Dim nowY = CInt((nowMins - (StartHour * 60)) * (HourHeight / 60.0))
                Dim colLeft = CInt(GutterWidth + todayOffset * colW)
                Dim colRight = colLeft + CInt(colW)

                Using pRed As New Pen(Color.FromArgb(234, 67, 53), 2)
                    g.DrawLine(pRed, colLeft, nowY, colRight, nowY)
                End Using
                Using brRed As New SolidBrush(Color.FromArgb(234, 67, 53))
                    g.FillEllipse(brRed, colLeft - 4, nowY - 4, 8, 8)
                End Using
            End If
        End If
    End Sub

    Private Sub DrawAppointmentChip(g As Graphics, rect As Rectangle, a As AppointmentItem)
        Dim fillClr = Color.FromArgb(232, 240, 254)   ' Google Calendar Soft Blue
        Dim accentClr = Color.FromArgb(26, 115, 232)  ' Google Blue
        Dim titleClr = Color.FromArgb(26, 60, 120)

        Select Case a.Status.ToLower()
            Case "confirmed"
                fillClr = Color.FromArgb(230, 245, 235)  ' Teal soft
                accentClr = Color.FromArgb(35, 137, 120)
                titleClr = Color.FromArgb(20, 80, 70)
            Case "pending"
                fillClr = Color.FromArgb(254, 243, 226)  ' Amber soft
                accentClr = Color.FromArgb(217, 119, 6)
                titleClr = Color.FromArgb(140, 75, 5)
            Case "completed"
                fillClr = Color.FromArgb(243, 246, 248)  ' Slate light
                accentClr = Color.FromArgb(100, 116, 139)
                titleClr = Color.FromArgb(60, 75, 90)
            Case "cancelled"
                fillClr = Color.FromArgb(254, 235, 235)  ' Red soft
                accentClr = Color.FromArgb(205, 80, 75)
                titleClr = Color.FromArgb(140, 40, 35)
        End Select

        ' Rounded Chip Background
        Using path = GetRoundedRect(rect, 5)
            Using brFill As New SolidBrush(fillClr)
                g.FillPath(brFill, path)
            End Using

            ' Left Accent Strip (Google Calendar style)
            Using brAccent As New SolidBrush(accentClr)
                g.FillRectangle(brAccent, rect.X, rect.Y, 4, rect.Height)
            End Using

            Using pBorder As New Pen(Color.FromArgb(40, accentClr), 1)
                g.DrawPath(pBorder, path)
            End Using
        End Using

        ' Event Content: Patient Name & Time
        Dim textRect As New Rectangle(rect.X + 8, rect.Y + 2, rect.Width - 12, rect.Height - 4)
        Dim timeStr = ClinicData.FormatTime(a.Minutes)
        Dim patientText = If(String.IsNullOrEmpty(a.PatientName), "Appointment", a.PatientName)

        Using fTitle As New Font("Segoe UI", 8.0F, FontStyle.Bold)
            Using brText As New SolidBrush(titleClr)
                Dim sz = g.MeasureString(patientText, fTitle)
                g.DrawString(patientText, fTitle, brText, textRect.X, textRect.Y)

                If rect.Height > 32 Then
                    Using fSub As New Font("Segoe UI", 7.0F, FontStyle.Regular)
                        Using brSub As New SolidBrush(Color.FromArgb(100, 115, 125))
                            Dim subText = $"{timeStr} • {a.VisitType}"
                            g.DrawString(subText, fSub, brSub, textRect.X, textRect.Y + sz.Height - 1)
                        End Using
                    End Using
                End If
            End Using
        End Using
    End Sub

    Private Sub DrawSlotChip(g As Graphics, rect As Rectangle, s As SlotItem)
        If s.Kind = "Blocked" Then
            Using path = GetRoundedRect(rect, 4)
                Using brFill As New SolidBrush(Color.FromArgb(253, 237, 237))
                    g.FillPath(brFill, path)
                End Using
                Using pBorder As New Pen(Color.FromArgb(239, 68, 68), 1)
                    pBorder.DashStyle = DashStyle.Dash
                    g.DrawPath(pBorder, path)
                End Using
            End Using
            Using fText As New Font("Segoe UI", 7.5F, FontStyle.Regular)
                Using brText As New SolidBrush(Color.FromArgb(185, 28, 28))
                    g.DrawString("Blocked", fText, brText, rect.X + 6, rect.Y + (rect.Height - 14) \ 2)
                End Using
            End Using
        ElseIf s.Kind = "Available" Then
            Using path = GetRoundedRect(rect, 4)
                Using brFill As New SolidBrush(Color.FromArgb(240, 253, 244))
                    g.FillPath(brFill, path)
                End Using
                Using pBorder As New Pen(Color.FromArgb(134, 239, 172), 1)
                    pBorder.DashStyle = DashStyle.Dot
                    g.DrawPath(pBorder, path)
                End Using
            End Using
            Using fText As New Font("Segoe UI", 7.5F, FontStyle.Regular)
                Using brText As New SolidBrush(Color.FromArgb(22, 101, 52))
                    g.DrawString("Available", fText, brText, rect.X + 6, rect.Y + (rect.Height - 14) \ 2)
                End Using
            End Using
        End If
    End Sub

    Private Function GetRoundedRect(r As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        Dim d = radius * 2
        path.AddArc(r.X, r.Y, d, d, 180, 90)
        path.AddArc(r.Right - d, r.Y, d, d, 270, 90)
        path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90)
        path.AddArc(r.X, r.Bottom - d, d, d, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    ' =========================================================================
    '  Hit Testing & Interactive Navigation
    ' =========================================================================

    Private Sub Grid_MouseMove(sender As Object, e As MouseEventArgs)
        ' Mouse position in grid coordinates (undo the GridTopPad shift used when painting)
        Dim p As New Point(e.X, e.Y - GridTopPad)

        For Each ev In _renderedEvents
            If ev.Bounds.Contains(p) Then
                pnlGrid.Cursor = Cursors.Hand
                Return
            End If
        Next
        pnlGrid.Cursor = Cursors.Default
    End Sub

    Private Sub Grid_MouseClick(sender As Object, e As MouseEventArgs)
        ' Mouse position in grid coordinates (undo the GridTopPad shift used when painting)
        Dim p As New Point(e.X, e.Y - GridTopPad)

        ' Check if an event or slot was clicked
        For Each ev In _renderedEvents
            If ev.Bounds.Contains(p) Then
                If ev.Appointment IsNot Nothing Then
                    RaiseEvent EventClicked(ev.Appointment)
                    Return
                ElseIf ev.Slot IsNot Nothing Then
                    RaiseEvent AvailabilitySlotClicked(ev.Slot)
                    Return
                End If
            End If
        Next

        ' Otherwise: user clicked an empty space on the calendar grid
        Dim availW = pnlGrid.ClientSize.Width - GutterWidth
        Dim colW = availW / CDbl(DayCount)
        Dim clickX = p.X - GutterWidth

        If clickX >= 0 Then
            Dim dayIdx = CInt(Math.Floor(clickX / colW))
            If dayIdx >= 0 AndAlso dayIdx < DayCount Then
                Dim clickedDate = _currentWeekMonday.AddDays(dayIdx)
                Dim clickMins = (StartHour * 60) + CInt((p.Y / CDbl(HourHeight)) * 60)
                ' Round to nearest 30 mins
                Dim roundedMins = (CInt(Math.Round(clickMins / 30.0))) * 30
                If roundedMins >= (StartHour * 60) AndAlso roundedMins <= (EndHour * 60) Then
                    RaiseEvent SlotClicked(clickedDate, roundedMins)
                End If
            End If
        End If
    End Sub

End Class