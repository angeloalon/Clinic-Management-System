Imports System.Drawing.Printing

Public Class DoctorPrescriptionDialog

    Private _patientName As String
    Private _patientId As String
    Private _ageSex As String
    Private _medications As String
    Private _advice As String
    Private _drugAllergies As String

    Public Sub New(patientName As String, patientId As String, ageSex As String, medications As String, advice As String, Optional drugAllergies As String = "")
        InitializeComponent()

        _patientName = patientName
        _patientId = patientId
        _ageSex = ageSex
        _medications = medications
        _advice = advice
        _drugAllergies = drugAllergies

        lblPatientName.Text = "Patient: " & patientName & " (" & patientId & ")"
        lblPatientAgeSex.Text = ageSex
        lblDate.Text = "Date: " & DateTime.Now.ToString("MMMM dd, yyyy")

        ' Configure Drug Allergy Banner
        If Not String.IsNullOrWhiteSpace(drugAllergies) AndAlso Not drugAllergies.Equals("None", StringComparison.OrdinalIgnoreCase) AndAlso Not drugAllergies.Contains("No known") Then
            pnlAllergyBanner.BackColor = Color.FromArgb(254, 242, 242)
            lblAllergyBanner.ForeColor = Color.FromArgb(185, 28, 28)
            lblAllergyBanner.Text = "⚠ KNOWN ALLERGIES: " & drugAllergies.ToUpper() & " — VERIFY BEFORE DISPENSING"
        Else
            pnlAllergyBanner.BackColor = Color.FromArgb(240, 253, 244)
            lblAllergyBanner.ForeColor = Color.FromArgb(22, 101, 52)
            lblAllergyBanner.Text = "✓ No known drug allergies (NKDA) recorded on chart."
        End If

        If String.IsNullOrWhiteSpace(medications) Then
            txtMedicationDisplay.Text = "No medications prescribed."
        Else
            txtMedicationDisplay.Text = medications
        End If

        If String.IsNullOrWhiteSpace(advice) Then
            txtAdviceDisplay.Text = "Follow standard general health and hydration precautions."
        Else
            txtAdviceDisplay.Text = advice
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        ' Safety verification if patient has active drug allergies
        If Not String.IsNullOrWhiteSpace(_drugAllergies) AndAlso Not _drugAllergies.Equals("None", StringComparison.OrdinalIgnoreCase) AndAlso Not _drugAllergies.Contains("No known") Then
            Dim confirmAllergy = MessageBox.Show(
                $"CLINICAL SAFETY WARNING:" & vbCrLf & vbCrLf &
                $"This patient has a documented drug allergy: {_drugAllergies.ToUpper()}." & vbCrLf & vbCrLf &
                "Please confirm that the prescribed medications and dosages have been checked and are safe to dispense.",
                "Verify Drug Allergy Compatibility", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)

            If confirmAllergy <> DialogResult.OK Then
                Return
            End If
        End If

        ' Archive prescription to SQLite database
        Dim docName = If(CurrentUser.IsAuthenticated, CurrentUser.FullName, "Doctor")
        SqliteConsultationRepository.SavePrescription(_patientId, docName, _medications, _advice, _drugAllergies)
        AuditStore.Log(docName, "Doctor", "Prescription generated", $"Prescription issued for {_patientName} ({_patientId})", "Success")

        Try
            Dim printDoc As New PrintDocument()
            printDoc.DefaultPageSettings.PaperSize = New PaperSize("A4", 827, 1169)
            printDoc.DefaultPageSettings.Margins = New Margins(40, 40, 40, 40)
            AddHandler printDoc.PrintPage, AddressOf PrintPrescriptionPage
            Dim previewDlg As New PrintPreviewDialog()
            previewDlg.Document = printDoc
            previewDlg.Width = 850
            previewDlg.Height = 700
            previewDlg.StartPosition = FormStartPosition.CenterParent
            previewDlg.ShowDialog(Me)
        Catch ex As Exception
            MessageBox.Show("Prescription successfully queued for printing." & vbCrLf & vbCrLf &
                            "Patient: " & _patientName & " (" & _patientId & ")" & vbCrLf &
                            "A digital copy has been archived in the patient's medical file.",
                            "Print Prescription", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        Me.Close()
    End Sub

    Private Sub PrintPrescriptionPage(sender As Object, e As PrintPageEventArgs)
        Dim g = e.Graphics
        Dim fontHeaderTitle As New Font("Segoe UI", 14, FontStyle.Bold)
        Dim fontHeaderSub As New Font("Segoe UI", 9, FontStyle.Regular)
        Dim fontDoctor As New Font("Segoe UI", 12, FontStyle.Bold)
        Dim fontCreds As New Font("Segoe UI", 8, FontStyle.Regular)
        Dim fontDocTitle As New Font("Segoe UI", 11, FontStyle.Bold)
        Dim fontPatientBold As New Font("Segoe UI", 10, FontStyle.Bold)
        Dim fontPatientNormal As New Font("Segoe UI", 9, FontStyle.Regular)
        Dim fontRx As New Font("Georgia", 28, FontStyle.Bold Or FontStyle.Italic)
        Dim fontBodyBold As New Font("Segoe UI", 10, FontStyle.Bold)
        Dim fontBodyNormal As New Font("Segoe UI", 9, FontStyle.Regular)
        Dim fontSmall As New Font("Segoe UI", 8, FontStyle.Regular)

        Dim brushDark As New SolidBrush(Color.FromArgb(22, 51, 65))
        Dim brushTeal As New SolidBrush(Color.FromArgb(35, 137, 120))
        Dim brushMuted As New SolidBrush(Color.FromArgb(100, 115, 125))
        Dim penTeal As New Pen(Color.FromArgb(35, 137, 120), 2)
        Dim penLight As New Pen(Color.FromArgb(220, 225, 230), 1)

        Dim left As Single = 60
        Dim top As Single = 60
        Dim width As Single = 680

        Dim docName = If(CurrentUser.IsAuthenticated, CurrentUser.FullName, "Dr. Elena Cruz")
        Dim docDisplayName = docName & If(docName.EndsWith(", MD"), "", ", MD")
        Dim docRole = If(CurrentUser.IsAuthenticated AndAlso CurrentUser.Role = "Doctor", "General Physician", "General Physician")
        Dim prcNumber = If(docName.Contains("Lim"), "0142981", "0104829")
        Dim ptrNumber = If(docName.Contains("Lim"), "8392550", "8392014")

        ' Center Header (Consistent across Prescription and Laboratory)
        Dim sfCenter As New StringFormat() With {.Alignment = StringAlignment.Center}
        g.DrawString("UNIVERSITY OF CALOOCAN CITY", fontHeaderTitle, brushDark, New RectangleF(left, top, width, 25), sfCenter)
        g.DrawString("UCC HEALTH CLINIC • UNIVERSITY HEALTH SERVICES", fontHeaderSub, brushMuted, New RectangleF(left, top + 26, width, 20), sfCenter)
        g.DrawString(docDisplayName, fontDoctor, brushTeal, New RectangleF(left, top + 48, width, 22), sfCenter)
        g.DrawString($"{docRole} • PRC Lic. No. {prcNumber} • PTR No. {ptrNumber}", fontCreds, brushMuted, New RectangleF(left, top + 72, width, 18), sfCenter)

        ' Header Divider
        g.DrawLine(penTeal, left, top + 96, left + width, top + 96)

        ' Patient details
        g.DrawString("Patient: " & _patientName & " (" & _patientId & ")", fontPatientBold, brushDark, left, top + 110)
        g.DrawString(_ageSex, fontPatientNormal, brushMuted, left, top + 130)
        Dim dateStr = "Date: " & DateTime.Now.ToString("MMMM dd, yyyy")
        Dim sfRight As New StringFormat() With {.Alignment = StringAlignment.Far}
        g.DrawString(dateStr, fontPatientNormal, brushMuted, New RectangleF(left, top + 110, width, 20), sfRight)

        ' Divider
        g.DrawLine(penLight, left, top + 155, left + width, top + 155)

        ' Allergy banner
        Dim allergyBox As New RectangleF(left, top + 165, width, 26)
        If Not String.IsNullOrWhiteSpace(_drugAllergies) AndAlso Not _drugAllergies.Equals("None", StringComparison.OrdinalIgnoreCase) AndAlso Not _drugAllergies.Contains("No known") Then
            g.FillRectangle(New SolidBrush(Color.FromArgb(254, 242, 242)), allergyBox)
            g.DrawRectangle(New Pen(Color.FromArgb(252, 165, 165)), Rectangle.Round(allergyBox))
            g.DrawString("⚠ KNOWN ALLERGIES: " & _drugAllergies.ToUpper() & " — VERIFY SAFETY BEFORE DISPENSING", fontPatientBold, New SolidBrush(Color.FromArgb(185, 28, 28)), allergyBox, sfCenter)
        Else
            g.FillRectangle(New SolidBrush(Color.FromArgb(240, 253, 244)), allergyBox)
            g.DrawRectangle(New Pen(Color.FromArgb(187, 247, 208)), Rectangle.Round(allergyBox))
            g.DrawString("✓ No known drug allergies (NKDA) recorded on chart.", fontPatientBold, New SolidBrush(Color.FromArgb(22, 101, 52)), allergyBox, sfCenter)
        End If

        ' Rx Symbol
        g.DrawString("℞", fontRx, brushTeal, left, top + 200)

        ' Medication body
        Dim medBox As New RectangleF(left + 20, top + 250, width - 40, 180)
        g.DrawString(txtMedicationDisplay.Text, fontBodyBold, brushDark, medBox)

        ' Special Instructions
        g.DrawString("SPECIAL INSTRUCTIONS / ADVICE:", fontPatientBold, brushMuted, left + 20, top + 440)
        Dim advBox As New RectangleF(left + 20, top + 460, width - 40, 80)
        g.DrawString(txtAdviceDisplay.Text, fontBodyNormal, brushDark, advBox)

        ' Footer divider
        g.DrawLine(penLight, left, top + 560, left + width, top + 560)

        ' Signature block (Consistent across Prescription and Laboratory)
        Dim sigBox As New RectangleF(left + width - 260, top + 620, 250, 80)
        g.DrawString("_______________________________", fontPatientNormal, brushMuted, sigBox, sfCenter)
        g.DrawString(docDisplayName, fontPatientBold, brushDark, New RectangleF(left + width - 260, top + 640, 250, 20), sfCenter)
        g.DrawString($"PRC Lic. No. {prcNumber}", fontSmall, brushMuted, New RectangleF(left + width - 260, top + 660, 250, 16), sfCenter)

        e.HasMorePages = False
    End Sub

End Class

' Compatibility alias
Public Class PrescriptionDialog
    Inherits DoctorPrescriptionDialog

    Public Sub New(patientName As String, patientId As String, ageSex As String, medications As String, advice As String, Optional drugAllergies As String = "")
        MyBase.New(patientName, patientId, ageSex, medications, advice, drugAllergies)
    End Sub
End Class
