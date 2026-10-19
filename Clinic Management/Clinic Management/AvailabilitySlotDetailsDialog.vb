Imports System.Drawing
Imports System.Windows.Forms
Imports Ferrando.UI.WinForms.Controles

Public Class AvailabilitySlotDetailsDialog
    Inherits Form

    Private ReadOnly _slot As SlotItem
    Private ReadOnly _doctorName As String
    Private ReadOnly _allowEdit As Boolean

    Public Sub New(slot As SlotItem, Optional doctorName As String = "", Optional allowEdit As Boolean = True)
        _slot = slot
        _doctorName = If(Not String.IsNullOrEmpty(doctorName), doctorName, If(slot IsNot Nothing, slot.DoctorName, "Doctor"))
        _allowEdit = allowEdit
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.Text = "Availability Slot Details"
        Me.Size = New Size(440, 340)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.BackColor = Color.FromArgb(244, 247, 249)
        Me.Font = New Font("Segoe UI", 9.0F)

        Dim card As New FCard With {
            .Location = New Point(18, 16),
            .Size = New Size(388, 265),
            .BackColor = Color.White,
            .BorderColor = Color.FromArgb(232, 237, 240),
            .BorderRadius = 12,
            .BorderSize = 1,
            .EnableShadow = True,
            .ShadowDepth = 4,
            .HoverTintColor = Color.White
        }

        Dim isAvailable = (_slot IsNot Nothing AndAlso _slot.Kind = "Available")
        Dim statusText = If(isAvailable, "Available", "Blocked / Unavailable")
        Dim dur = If(_slot IsNot Nothing AndAlso _slot.DurationMinutes > 0, _slot.DurationMinutes, 30)
        Dim startM = If(_slot IsNot Nothing, _slot.Minutes, 540)
        Dim timeStr = $"{ClinicData.FormatTime(startM)} – {ClinicData.FormatTime(startM + dur)}"
        Dim dateStr = If(_slot IsNot Nothing AndAlso Not String.IsNullOrEmpty(_slot.SlotDate), _slot.SlotDate, $"Day {_slot.Day}")

        ' 1. Header: Status Title & Pill
        Dim lblTitle As New Label With {
            .Text = If(isAvailable, "Available Slot", "Blocked Slot"),
            .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(22, 51, 65),
            .Location = New Point(18, 16),
            .AutoSize = True
        }
        card.Controls.Add(lblTitle)

        Dim statusPill As New FButton With {
            .Text = If(isAvailable, "Available", "Blocked"),
            .Size = New Size(86, 24),
            .Location = New Point(284, 16),
            .Font = New Font("Segoe UI", 8.0F, FontStyle.Bold),
            .BorderRadius = 6,
            .BorderSize = 0,
            .Cursor = Cursors.Default
        }
        If isAvailable Then
            UIThemeHelper.ApplySuccess(statusPill)
        Else
            UIThemeHelper.ApplyDanger(statusPill)
        End If
        card.Controls.Add(statusPill)

        ' Divider
        Dim div1 As New Panel With {
            .Location = New Point(18, 54),
            .Size = New Size(352, 1),
            .BackColor = Color.FromArgb(232, 237, 240)
        }
        card.Controls.Add(div1)

        ' 2. Details Rows
        Dim y As Integer = 66
        AddDetailRow(card, "📅 DATE", dateStr, y)
        y += 34
        AddDetailRow(card, "⏰ TIME", timeStr, y)
        y += 34
        AddDetailRow(card, "👨‍⚕️ DOCTOR", _doctorName, y)

        ' 3. Action Buttons
        If _allowEdit Then
            Dim btnToggle As New FButton With {
                .Text = If(isAvailable, "Mark as Blocked", "Mark as Available"),
                .Size = New Size(140, 34),
                .Location = New Point(18, 205),
                .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
                .BorderRadius = 6,
                .BorderSize = 0,
                .Cursor = Cursors.Hand
            }
            If isAvailable Then
                UIThemeHelper.ApplyDanger(btnToggle)
            Else
                UIThemeHelper.ApplyPrimary(btnToggle)
            End If

            Dim targetDateStr As String = ""
            If _slot IsNot Nothing AndAlso Not String.IsNullOrEmpty(_slot.SlotDate) Then
                targetDateStr = _slot.SlotDate
            ElseIf _slot IsNot Nothing AndAlso _slot.Day > 0 Then
                Dim today = DateTime.Today
                Dim candidateYear = today.Year
                Dim candidateMonth = today.Month
                Dim dayVal = Math.Min(_slot.Day, DateTime.DaysInMonth(candidateYear, candidateMonth))
                targetDateStr = New DateTime(candidateYear, candidateMonth, dayVal).ToString("yyyy-MM-dd")
            Else
                targetDateStr = DateTime.Today.ToString("yyyy-MM-dd")
            End If

            AddHandler btnToggle.Click, Sub()
                Dim newKind = If(isAvailable, "Blocked", "Available")
                ClinicData.UpdateSlotStatus(_doctorName, targetDateStr, _slot.Minutes, newKind)
                AuditStore.Log(_doctorName, "Staff", "Availability status toggled", $"{dateStr} at {ClinicData.FormatTime(_slot.Minutes)} marked as {newKind}", "Success")
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End Sub
            card.Controls.Add(btnToggle)

            Dim btnDelete As New FButton With {
                .Text = "Remove Slot",
                .Size = New Size(110, 34),
                .Location = New Point(164, 205),
                .Font = New Font("Segoe UI", 8.5F, FontStyle.Regular),
                .BorderRadius = 6,
                .BorderSize = 1,
                .Cursor = Cursors.Hand
            }
            UIThemeHelper.ApplySecondary(btnDelete)
            AddHandler btnDelete.Click, Sub()
                ClinicData.DeleteSlot(_doctorName, targetDateStr, _slot.Minutes)
                AuditStore.Log(_doctorName, "Staff", "Availability slot removed", $"{dateStr} at {ClinicData.FormatTime(_slot.Minutes)} removed", "Success")
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End Sub
            card.Controls.Add(btnDelete)

            Dim btnClose As New FButton With {
                .Text = "Close",
                .Size = New Size(80, 34),
                .Location = New Point(280, 205),
                .Font = New Font("Segoe UI", 8.5F, FontStyle.Regular),
                .BorderRadius = 6,
                .BorderSize = 1,
                .Cursor = Cursors.Hand
            }
            UIThemeHelper.ApplySecondary(btnClose, activeTealFore:=False)
            AddHandler btnClose.Click, Sub()
                Me.DialogResult = DialogResult.Cancel
                Me.Close()
            End Sub
            card.Controls.Add(btnClose)
        Else
            ' View-only mode for receptionist
            Dim btnClose As New FButton With {
                .Text = "Close",
                .Size = New Size(100, 34),
                .Location = New Point((card.Width - 100) \ 2, 205),
                .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
                .BorderRadius = 6,
                .BorderSize = 1,
                .Cursor = Cursors.Hand
            }
            UIThemeHelper.ApplySecondary(btnClose, activeTealFore:=False)
            AddHandler btnClose.Click, Sub()
                Me.DialogResult = DialogResult.Cancel
                Me.Close()
            End Sub
            card.Controls.Add(btnClose)
        End If

        Me.Controls.Add(card)
    End Sub

    Private Sub AddDetailRow(parent As Control, label As String, value As String, y As Integer)
        Dim lblKey As New Label With {
            .Text = label,
            .Font = New Font("Segoe UI", 7.5F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(120, 140, 150),
            .Location = New Point(18, y),
            .Size = New Size(110, 20),
            .TextAlign = ContentAlignment.MiddleLeft
        }
        Dim lblVal As New Label With {
            .Text = value,
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(30, 45, 55),
            .Location = New Point(130, y),
            .Size = New Size(240, 20),
            .TextAlign = ContentAlignment.MiddleLeft
        }
        parent.Controls.Add(lblKey)
        parent.Controls.Add(lblVal)
    End Sub

End Class
