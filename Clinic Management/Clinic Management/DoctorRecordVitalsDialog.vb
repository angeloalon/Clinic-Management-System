Imports System.Drawing
Imports System.Windows.Forms
Imports Ferrando.UI.WinForms.Controles

Public Class DoctorRecordVitalsDialog
    Inherits Form

    Private ReadOnly _item As AppointmentItem
    Private ReadOnly _doctorName As String

    Private txtBp As TextBox
    Private txtPulse As TextBox
    Private txtTemp As TextBox
    Private txtSpo2 As TextBox
    Private btnSave As FButton
    Private btnCancel As FButton
    Private btnClear As FButton
    Private lblError As Label
    Private pnlNote As Panel
    Private ReadOnly _containers As New Dictionary(Of TextBox, Panel)()

    Public Sub New(item As AppointmentItem, Optional doctorName As String = "")
        _item = item
        _doctorName = If(Not String.IsNullOrEmpty(doctorName), doctorName, If(item IsNot Nothing, item.DoctorName, "Doctor"))
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.Text = "Record Patient Vitals — Objective (O)"
        Me.Size = New Size(440, 480)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.BackColor = Color.FromArgb(244, 247, 249)
        Me.Font = New Font("Segoe UI", 9.0F)

        Dim card As New FCard With {
            .Location = New Point(18, 14),
            .Size = New Size(390, 412),
            .BackColor = Color.White,
            .BorderColor = Color.FromArgb(232, 237, 240),
            .BorderRadius = 12,
            .BorderSize = 1,
            .EnableShadow = True,
            .ShadowDepth = 4,
            .HoverTintColor = Color.White
        }

        Dim patientText = If(_item IsNot Nothing, $"{_item.PatientName} • {_item.PatientId}", "Patient Consultation")
        Dim lblTitle As New Label With {
            .Text = "Objective (O) — Patient Vitals",
            .Font = New Font("Segoe UI", 11.5F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(22, 51, 65),
            .Location = New Point(18, 14),
            .AutoSize = True
        }
        card.Controls.Add(lblTitle)

        Dim lblSub As New Label With {
            .Text = patientText & vbCrLf & "Enter measured vital signs to evaluate clinical alerts and update SOAP record.",
            .Font = New Font("Segoe UI", 8.0F, FontStyle.Regular),
            .ForeColor = Color.FromArgb(115, 138, 148),
            .Location = New Point(18, 38),
            .Size = New Size(354, 32)
        }
        card.Controls.Add(lblSub)

        ' Divider
        Dim divLine As New Panel With {
            .Location = New Point(18, 74),
            .Size = New Size(354, 1),
            .BackColor = Color.FromArgb(240, 243, 245)
        }
        card.Controls.Add(divLine)

        Dim curY = 86
        Dim rowH = 62

        ' Helper to build field row
        Dim CreateField = Function(labelTitle As String, normalGuide As String, currentVal As String, y As Integer) As TextBox
                              Dim lblField As New Label With {
                                  .Text = labelTitle,
                                  .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
                                  .ForeColor = Color.FromArgb(30, 45, 55),
                                  .Location = New Point(18, y),
                                  .AutoSize = True
                              }
                              card.Controls.Add(lblField)

                              Dim lblGuide As New Label With {
                                  .Text = normalGuide,
                                  .Font = New Font("Segoe UI", 7.5F, FontStyle.Italic),
                                  .ForeColor = Color.FromArgb(130, 150, 160),
                                  .Location = New Point(18, y + 17),
                                  .AutoSize = True
                              }
                              card.Controls.Add(lblGuide)

                              Dim tbContainer As New Panel With {
                                  .Location = New Point(210, y),
                                  .Size = New Size(162, 32),
                                  .BackColor = Color.FromArgb(248, 250, 252),
                                  .BorderStyle = BorderStyle.FixedSingle
                              }
                              Dim tb As New TextBox With {
                                  .Location = New Point(6, 6),
                                  .Size = New Size(148, 20),
                                  .BorderStyle = BorderStyle.None,
                                  .BackColor = Color.FromArgb(248, 250, 252),
                                  .Font = New Font("Segoe UI", 9.0F),
                                  .ForeColor = Color.FromArgb(22, 51, 65),
                                  .Text = currentVal
                              }
                              tbContainer.Controls.Add(tb)
                              card.Controls.Add(tbContainer)
                              _containers(tb) = tbContainer

                              AddHandler tb.TextChanged, Sub()
                                                             tbContainer.BackColor = Color.FromArgb(248, 250, 252)
                                                             tb.BackColor = Color.FromArgb(248, 250, 252)
                                                             If lblError IsNot Nothing AndAlso lblError.Visible Then
                                                                 lblError.Visible = False
                                                                 If pnlNote IsNot Nothing Then pnlNote.Visible = True
                                                             End If
                                                         End Sub
                              Return tb
                          End Function

        Dim curBp = If(_item IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(_item.Bp), _item.Bp, "")
        Dim curPulse = If(_item IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(_item.Pulse), _item.Pulse, "")
        Dim curTemp = If(_item IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(_item.Temperature), _item.Temperature, "")
        Dim curSpo2 = If(_item IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(_item.Spo2), _item.Spo2, "")

        txtBp = CreateField("Blood Pressure (BP)", "Normal: < 120/80 mmHg", curBp, curY)
        curY += rowH

        txtPulse = CreateField("Heart Rate / Pulse", "Normal: 60 – 100 bpm", curPulse, curY)
        curY += rowH

        txtTemp = CreateField("Body Temperature", "Normal: 36.5 – 37.5 °C", curTemp, curY)
        curY += rowH

        txtSpo2 = CreateField("Oxygen Saturation (SpO₂)", "Normal: 95 – 100%", curSpo2, curY)
        curY += rowH + 6

        ' Info note banner
        pnlNote = New Panel With {
            .Location = New Point(18, curY),
            .Size = New Size(354, 30),
            .BackColor = Color.FromArgb(244, 248, 250)
        }
        Dim lblNote As New Label With {
            .Text = "ℹ Values outside normal thresholds trigger automated clinical alerts.",
            .Font = New Font("Segoe UI", 7.5F, FontStyle.Regular),
            .ForeColor = Color.FromArgb(70, 95, 110),
            .Location = New Point(8, 7),
            .AutoSize = True
        }
        pnlNote.Controls.Add(lblNote)
        card.Controls.Add(pnlNote)

        ' Validation error label
        lblError = New Label With {
            .Location = New Point(18, curY),
            .Size = New Size(354, 32),
            .Font = New Font("Segoe UI", 8.0F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(205, 80, 75),
            .Visible = False
        }
        card.Controls.Add(lblError)

        ' Action Buttons
        btnClear = New FButton With {
            .Text = "Clear",
            .Size = New Size(62, 32),
            .Location = New Point(18, 364),
            .Cursor = Cursors.Hand,
            .Font = New Font("Segoe UI", 8.0F, FontStyle.Bold)
        }
        UIThemeHelper.ApplySecondary(btnClear)
        AddHandler btnClear.Click, AddressOf BtnClear_Click
        card.Controls.Add(btnClear)

        btnCancel = New FButton With {
            .Text = "Cancel",
            .Size = New Size(80, 32),
            .Location = New Point(202, 364),
            .Cursor = Cursors.Hand,
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        }
        UIThemeHelper.ApplySecondary(btnCancel)
        AddHandler btnCancel.Click, Sub()
                                       Me.DialogResult = DialogResult.Cancel
                                       Me.Close()
                                   End Sub
        card.Controls.Add(btnCancel)

        btnSave = New FButton With {
            .Text = "Save Vitals",
            .Size = New Size(96, 32),
            .Location = New Point(288, 364),
            .Cursor = Cursors.Hand,
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
        }
        UIThemeHelper.ApplyPrimary(btnSave)
        AddHandler btnSave.Click, AddressOf BtnSave_Click
        card.Controls.Add(btnSave)

        Me.Controls.Add(card)
        Me.AcceptButton = btnSave
        Me.CancelButton = btnCancel
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs)
        txtBp.Text = ""
        txtPulse.Text = ""
        txtTemp.Text = ""
        txtSpo2.Text = ""
        lblError.Visible = False
        pnlNote.Visible = True
        For Each kvp In _containers
            kvp.Value.BackColor = Color.FromArgb(248, 250, 252)
            kvp.Key.BackColor = Color.FromArgb(248, 250, 252)
        Next
    End Sub

    Private Function ValidateVitals(ByRef outBp As String, ByRef outPulse As String, ByRef outTemp As String, ByRef outSpo2 As String, ByRef errorMsg As String, ByRef invalidField As TextBox) As Boolean
        errorMsg = ""
        invalidField = Nothing

        Dim rawBp = txtBp.Text.Trim()
        Dim rawPulse = txtPulse.Text.Trim()
        Dim rawTemp = txtTemp.Text.Trim()
        Dim rawSpo2 = txtSpo2.Text.Trim()

        ' 1. Validate Blood Pressure (if entered)
        outBp = ""
        If Not String.IsNullOrEmpty(rawBp) AndAlso rawBp <> "—" Then
            Dim cleanBp = rawBp.Replace("mmHg", "").Replace("MMHG", "").Trim()
            Dim parts = cleanBp.Split("/"c)
            If parts.Length <> 2 Then
                errorMsg = "Blood Pressure must be in Systolic/Diastolic format (e.g., 120/80)."
                invalidField = txtBp
                Return False
            End If

            Dim sys, dia As Integer
            If Not Integer.TryParse(parts(0).Trim(), sys) OrElse Not Integer.TryParse(parts(1).Trim(), dia) Then
                errorMsg = "Blood Pressure values must both be valid numbers (e.g., 120/80)."
                invalidField = txtBp
                Return False
            End If

            If sys < 50 OrElse sys > 260 Then
                errorMsg = $"Systolic blood pressure ({sys} mmHg) is out of plausible range (50 – 260 mmHg)."
                invalidField = txtBp
                Return False
            End If

            If dia < 30 OrElse dia > 160 Then
                errorMsg = $"Diastolic blood pressure ({dia} mmHg) is out of plausible range (30 – 160 mmHg)."
                invalidField = txtBp
                Return False
            End If

            If sys <= dia Then
                errorMsg = $"Systolic blood pressure ({sys} mmHg) must be greater than diastolic ({dia} mmHg)."
                invalidField = txtBp
                Return False
            End If

            outBp = $"{sys}/{dia}"
        End If

        ' 2. Validate Heart Rate / Pulse (if entered)
        outPulse = ""
        If Not String.IsNullOrEmpty(rawPulse) AndAlso rawPulse <> "—" Then
            Dim cleanPulse = System.Text.RegularExpressions.Regex.Match(rawPulse, "^\s*(\d+)\s*(bpm)?\s*$", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            If Not cleanPulse.Success Then
                errorMsg = "Heart Rate / Pulse must be a valid whole number (e.g., 72 or 72 bpm)."
                invalidField = txtPulse
                Return False
            End If

            Dim pulseVal As Integer
            If Not Integer.TryParse(cleanPulse.Groups(1).Value, pulseVal) OrElse pulseVal < 30 OrElse pulseVal > 250 Then
                errorMsg = $"Heart Rate / Pulse ({cleanPulse.Groups(1).Value} bpm) is out of plausible range (30 – 250 bpm)."
                invalidField = txtPulse
                Return False
            End If

            outPulse = $"{pulseVal} bpm"
        End If

        ' 3. Validate Body Temperature (if entered)
        outTemp = ""
        If Not String.IsNullOrEmpty(rawTemp) AndAlso rawTemp <> "—" Then
            Dim cleanTempMatch = System.Text.RegularExpressions.Regex.Match(rawTemp, "^\s*(\d+(\.\d+)?)\s*(°?C|F)?\s*$", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            If Not cleanTempMatch.Success Then
                errorMsg = "Body Temperature must be a valid number in Celsius (e.g., 36.6 or 36.6 °C)."
                invalidField = txtTemp
                Return False
            End If

            Dim tempVal As Double
            If Not Double.TryParse(cleanTempMatch.Groups(1).Value, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, tempVal) Then
                errorMsg = "Please enter a valid numeric body temperature in Celsius."
                invalidField = txtTemp
                Return False
            End If

            ' Automatic conversion suggestion if entered in Fahrenheit (e.g. 98.6 or 101)
            If tempVal >= 85.0 AndAlso tempVal <= 110.0 Then
                Dim convertedC = Math.Round((tempVal - 32.0) * 5.0 / 9.0, 1)
                If MessageBox.Show($"The temperature entered ({tempVal}) appears to be in Fahrenheit." & vbCrLf &
                                   $"Would you like to convert it to {convertedC:F1} °C?",
                                   "Temperature Unit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    tempVal = convertedC
                Else
                    errorMsg = "Please enter body temperature in Celsius (°C), between 30.0 °C and 44.0 °C."
                    invalidField = txtTemp
                    Return False
                End If
            End If

            If tempVal < 30.0 OrElse tempVal > 44.0 Then
                errorMsg = $"Body temperature ({tempVal:F1} °C) is out of plausible range (30.0 °C – 44.0 °C)."
                invalidField = txtTemp
                Return False
            End If

            outTemp = $"{tempVal:F1} °C"
        End If

        ' 4. Validate Oxygen Saturation SpO2 (if entered)
        outSpo2 = ""
        If Not String.IsNullOrEmpty(rawSpo2) AndAlso rawSpo2 <> "—" Then
            Dim cleanSpo2Match = System.Text.RegularExpressions.Regex.Match(rawSpo2, "^\s*(\d+)\s*(%?)\s*$")
            If Not cleanSpo2Match.Success Then
                errorMsg = "Oxygen Saturation (SpO₂) must be a whole percentage between 50% and 100% (e.g., 98 or 98%)."
                invalidField = txtSpo2
                Return False
            End If

            Dim spo2Val As Integer
            If Not Integer.TryParse(cleanSpo2Match.Groups(1).Value, spo2Val) OrElse spo2Val < 50 OrElse spo2Val > 100 Then
                errorMsg = $"Oxygen Saturation ({cleanSpo2Match.Groups(1).Value}%) is out of range. Valid SpO₂ must be between 50% and 100%."
                invalidField = txtSpo2
                Return False
            End If

            outSpo2 = $"{spo2Val}%"
        End If

        Return True
    End Function

    Private Sub BtnSave_Click(sender As Object, e As EventArgs)
        If _item Is Nothing Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
            Return
        End If

        Dim bpVal As String = ""
        Dim pulseVal As String = ""
        Dim tempVal As String = ""
        Dim spo2Val As String = ""
        Dim errorMsg As String = ""
        Dim invalidField As TextBox = Nothing

        If Not ValidateVitals(bpVal, pulseVal, tempVal, spo2Val, errorMsg, invalidField) Then
            lblError.Text = "⚠️ " & errorMsg
            lblError.Visible = True
            pnlNote.Visible = False

            If invalidField IsNot Nothing AndAlso _containers.ContainsKey(invalidField) Then
                _containers(invalidField).BackColor = Color.FromArgb(254, 242, 242)
                invalidField.BackColor = Color.FromArgb(254, 242, 242)
                invalidField.Focus()
                invalidField.SelectAll()
            End If

            MessageBox.Show(errorMsg, "Invalid Vital Signs Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        _item.Bp = bpVal
        _item.Pulse = pulseVal
        _item.Temperature = tempVal
        _item.Spo2 = spo2Val

        ' Persist to database
        SqliteAppointmentRepository.UpdateAppointment(_item)
        AuditStore.Log(_doctorName, "Doctor", "Vitals updated", $"Vitals recorded for {_item.PatientName}: BP {bpVal}, Pulse {pulseVal}, Temp {tempVal}, SpO2 {spo2Val}", "Success")
        ClinicData.NotifyDataChanged()

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class
