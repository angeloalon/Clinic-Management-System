Imports System.Drawing
Imports System.Windows.Forms
Imports Ferrando.UI.WinForms.Controles

Public Class CalendarEventDetailsDialog
    Inherits Form

    Private _item As AppointmentItem
    Private ReadOnly _allowConsultation As Boolean

    Public Sub New(item As AppointmentItem, Optional allowConsultation As Boolean = True)
        _item = item
        _allowConsultation = allowConsultation
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.Text = "Appointment Details"
        Me.Size = New Size(470, 440)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.BackColor = Color.FromArgb(244, 247, 249)
        Me.Font = New Font("Segoe UI", 9.0F)

        Dim card As New FCard With {
            .Location = New Point(18, 16),
            .Size = New Size(420, 365),
            .BackColor = Color.White,
            .BorderColor = Color.FromArgb(232, 237, 240),
            .BorderRadius = 12,
            .BorderSize = 1,
            .EnableShadow = True,
            .ShadowDepth = 4,
            .HoverTintColor = Color.White
        }

        Dim patientName = If(_item IsNot Nothing, _item.PatientName, "Unknown Patient")
        Dim patientId = If(_item IsNot Nothing, _item.PatientId, "PT-0000")
        Dim status = If(_item IsNot Nothing, _item.Status, "Confirmed")
        Dim docName = If(_item IsNot Nothing AndAlso Not String.IsNullOrEmpty(_item.DoctorName), _item.DoctorName, "Attending Physician")
        Dim room = If(_item IsNot Nothing, _item.RoomNumber, "Room 101")
        Dim visitType = If(_item IsNot Nothing, _item.VisitType, "Consultation")
        Dim reason = If(_item IsNot Nothing AndAlso Not String.IsNullOrEmpty(_item.Reason), _item.Reason, "Routine clinic consultation")

        Dim timeStr = If(_item IsNot Nothing, $"{ClinicData.FormatTime(_item.Minutes)} – {ClinicData.FormatTime(_item.Minutes + 30)}", "10:00 AM – 10:30 AM")
        Dim dateStr = If(_item IsNot Nothing AndAlso Not String.IsNullOrEmpty(_item.AppointmentDate), _item.AppointmentDate, "Today")

        ' 1. Title & Status
        Dim lblName As New Label With {
            .Text = patientName,
            .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(22, 51, 65),
            .Location = New Point(18, 16),
            .AutoSize = True
        }
        card.Controls.Add(lblName)

        Dim lblId As New Label With {
            .Text = patientId,
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(115, 138, 148),
            .Location = New Point(18, 40),
            .AutoSize = True
        }
        card.Controls.Add(lblId)

        Dim statusPill As New FButton With {
            .Text = status,
            .Size = New Size(80, 24),
            .Location = New Point(320, 16),
            .Font = New Font("Segoe UI", 8.0F, FontStyle.Bold),
            .BorderRadius = 6,
            .BorderSize = 0,
            .Cursor = Cursors.Default
        }
        Select Case status.ToLower()
            Case "completed"
                UIThemeHelper.ApplySuccess(statusPill)
            Case "pending"
                UIThemeHelper.ApplyWarning(statusPill)
            Case "cancelled"
                UIThemeHelper.ApplyDanger(statusPill)
            Case Else
                UIThemeHelper.ApplyInfo(statusPill)
        End Select
        card.Controls.Add(statusPill)

        ' Divider
        Dim div1 As New Panel With {
            .Location = New Point(18, 66),
            .Size = New Size(384, 1),
            .BackColor = Color.FromArgb(232, 237, 240)
        }
        card.Controls.Add(div1)

        ' 2. Details Grid
        Dim y As Integer = 76
        AddDetailRow(card, "📅 SCHEDULE", $"{dateStr} • {timeStr}", y)
        AddDetailRow(card, "👨‍⚕️ PHYSICIAN", $"{docName} • {room}", y)
        AddDetailRow(card, "🩺 VISIT TYPE", visitType, y)
        AddDetailRow(card, "📝 CLINICAL REASON", reason, y)

        If _item IsNot Nothing AndAlso Not String.IsNullOrEmpty(_item.Bp) Then
            AddDetailRow(card, "❤️ VITALS", $"BP: {_item.Bp} | Pulse: {_item.Pulse} | Temp: {_item.Temperature}", y)
        End If

        ' 3. Action Buttons
        Dim btnClose As New FButton With {
            .Text = "Close",
            .Size = New Size(85, 32),
            .Location = New Point(318, 318),
            .BorderRadius = 6,
            .BorderSize = 0,
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
            .Cursor = Cursors.Hand
        }
        UIThemeHelper.ApplySecondary(btnClose)
        AddHandler btnClose.Click, Sub() Me.Close()
        card.Controls.Add(btnClose)

        If _allowConsultation Then
            Dim btnConsult As New FButton With {
                .Text = "Open Consultation",
                .Size = New Size(140, 32),
                .Location = New Point(170, 318),
                .BorderRadius = 6,
                .BorderSize = 0,
                .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
                .Cursor = Cursors.Hand
            }
            UIThemeHelper.ApplyPrimary(btnConsult)
            AddHandler btnConsult.Click, Sub()
                Me.DialogResult = DialogResult.OK
                If DoctorShell.Current IsNot Nothing Then
                    DoctorShell.Current.OpenConsultation(_item)
                End If
                Me.Close()
            End Sub
            card.Controls.Add(btnConsult)
        End If

        Me.Controls.Add(card)
    End Sub

    Private Sub AddDetailRow(card As FCard, header As String, text As String, ByRef y As Integer)
        Dim lblH As New Label With {
            .Text = header,
            .Font = New Font("Segoe UI", 7.5F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(140, 155, 165),
            .Location = New Point(18, y),
            .AutoSize = True
        }
        card.Controls.Add(lblH)
        y += 16

        Dim lblV As New Label With {
            .Text = text,
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Regular),
            .ForeColor = Color.FromArgb(30, 45, 55),
            .Location = New Point(18, y),
            .Size = New Size(384, 18),
            .AutoEllipsis = True
        }
        card.Controls.Add(lblV)
        y += 24
    End Sub

End Class
