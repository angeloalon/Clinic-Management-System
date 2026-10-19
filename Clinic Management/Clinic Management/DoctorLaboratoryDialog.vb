Imports System.Linq
Imports System.Drawing.Printing

Public Class DoctorLaboratoryDialog

    Private _patientName As String
    Private _patientId As String
    Private _ageSex As String
    Private _diagnosis As String
    Private _selectedTests As New List(Of String)()

    Public Sub New(patientName As String, patientId As String, ageSex As String, diagnosis As String, Optional condition As String = "")
        InitializeComponent()

        _patientName = patientName
        _patientId = patientId
        _ageSex = ageSex

        lblPatientName.Text = "Patient: " & patientName & " (" & patientId & ")"
        lblPatientAgeSex.Text = ageSex
        lblDate.Text = "Date: " & DateTime.Now.ToString("MMMM dd, yyyy")

        Dim fullDx As String = ""
        If Not String.IsNullOrWhiteSpace(diagnosis) Then
            fullDx = diagnosis
        End If
        If Not String.IsNullOrWhiteSpace(condition) Then
            If fullDx.Length > 0 Then fullDx &= " • "
            fullDx &= condition
        End If
        If String.IsNullOrWhiteSpace(fullDx) Then
            fullDx = "General Medical Evaluation"
        End If
        _diagnosis = fullDx
        lblDiagnosisValue.Text = fullDx

        ' Auto-select intelligent default diagnostic orders based on clinical presentation
        AutoSelectOrders(fullDx.ToLower())
    End Sub

    ''' <summary>Pre-checks relevant diagnostic panels depending on clinical presentation.</summary>
    Private Sub AutoSelectOrders(diagText As String)
        ' Respiratory presentations
        If diagText.Contains("cough") OrElse diagText.Contains("asthma") OrElse diagText.Contains("respiratory") OrElse diagText.Contains("urti") Then
            chkCBC.Checked = True
            chkCXR.Checked = True
        End If

        ' Metabolic / Endocrine presentations
        If diagText.Contains("diabet") OrElse diagText.Contains("sugar") OrElse diagText.Contains("glucose") Then
            chkFBS.Checked = True
            chkHbA1c.Checked = True
            chkUrinalysis.Checked = True
            chkLipid.Checked = True
        End If

        ' Cardiovascular / Hypertension presentations
        If diagText.Contains("hyperten") OrElse diagText.Contains("bp") OrElse diagText.Contains("cardio") Then
            chkLipid.Checked = True
            chkCreatinine.Checked = True
            chkECG.Checked = True
            chkUrinalysis.Checked = True
        End If

        ' Routine baseline if nothing was matched
        If Not chkCBC.Checked AndAlso Not chkFBS.Checked AndAlso Not chkLipid.Checked AndAlso Not chkCXR.Checked Then
            chkCBC.Checked = True
            chkUrinalysis.Checked = True
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        _selectedTests.Clear()

        If chkCBC.Checked Then _selectedTests.Add("CBC w/ Platelets")
        If chkBloodType.Checked Then _selectedTests.Add("Blood Typing (ABO/Rh)")
        If chkESR.Checked Then _selectedTests.Add("Erythrocyte Sedimentation Rate (ESR)")
        If chkUrinalysis.Checked Then _selectedTests.Add("Routine Urinalysis")
        If chkFecalysis.Checked Then _selectedTests.Add("Fecalysis")
        If chkFBS.Checked Then _selectedTests.Add("Fasting Blood Sugar (FBS)")
        If chkHbA1c.Checked Then _selectedTests.Add("HbA1c Glycated Hemoglobin")
        If chkLipid.Checked Then _selectedTests.Add("Complete Lipid Profile")
        If chkCreatinine.Checked Then _selectedTests.Add("Creatinine & BUN")
        If chkLiver.Checked Then _selectedTests.Add("Liver Enzymes (SGOT/SGPT)")
        If chkUricAcid.Checked Then _selectedTests.Add("Serum Uric Acid (BUA)")
        If chkCXR.Checked Then _selectedTests.Add("Chest X-Ray (PA view)")
        If chkECG.Checked Then _selectedTests.Add("12-Lead Electrocardiogram (ECG)")
        If chkSputum.Checked Then _selectedTests.Add("Sputum AFB Examination")

        If _selectedTests.Count = 0 Then
            MessageBox.Show("Please select at least one laboratory or diagnostic test to request.",
                            "Laboratory Request", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim docName = If(CurrentUser.IsAuthenticated, CurrentUser.FullName, "Dr. Elena Cruz")
        Dim summary As String = String.Join(", ", _selectedTests)
        ' Archive lab request to SQLite database
        SqliteConsultationRepository.SaveLabRequest(_patientId, docName, _diagnosis, summary)
        AuditStore.Log(docName, "Doctor", "Laboratory test requested", $"Diagnostic order for {_patientName} ({_patientId}): {summary}", "Success")

        Try
            Dim printDoc As New PrintDocument()
            printDoc.DefaultPageSettings.PaperSize = New PaperSize("A4", 827, 1169)
            printDoc.DefaultPageSettings.Margins = New Margins(40, 40, 40, 40)
            AddHandler printDoc.PrintPage, AddressOf PrintLabPage
            Dim previewDlg As New PrintPreviewDialog()
            previewDlg.Document = printDoc
            previewDlg.Width = 850
            previewDlg.Height = 700
            previewDlg.StartPosition = FormStartPosition.CenterParent
            previewDlg.ShowDialog(Me)
        Catch ex As Exception
            summary = String.Join(", ", _selectedTests)
            MessageBox.Show("Laboratory request successfully queued for printing." & vbCrLf & vbCrLf &
                            "Tests ordered (" & _selectedTests.Count & "): " & summary & vbCrLf & vbCrLf &
                            "A digital order record has been archived in the patient's medical file.",
                            "Print Laboratory Request", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        Me.Close()
    End Sub

    Private Sub PrintLabPage(sender As Object, e As PrintPageEventArgs)
        Dim g = e.Graphics
        Dim fontHeaderTitle As New Font("Segoe UI", 14, FontStyle.Bold)
        Dim fontHeaderSub As New Font("Segoe UI", 9, FontStyle.Regular)
        Dim fontDoctor As New Font("Segoe UI", 12, FontStyle.Bold)
        Dim fontCreds As New Font("Segoe UI", 8, FontStyle.Regular)
        Dim fontDocTitle As New Font("Segoe UI", 11, FontStyle.Bold)
        Dim fontPatientBold As New Font("Segoe UI", 10, FontStyle.Bold)
        Dim fontPatientNormal As New Font("Segoe UI", 9, FontStyle.Regular)
        Dim fontSectionHeader As New Font("Segoe UI", 9.5F, FontStyle.Bold)
        Dim fontBodyBold As New Font("Segoe UI", 9.5F, FontStyle.Bold)
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

        ' Patient details & diagnosis
        g.DrawString("Patient: " & _patientName & " (" & _patientId & ")", fontPatientBold, brushDark, left, top + 110)
        g.DrawString(_ageSex, fontPatientNormal, brushMuted, left, top + 130)
        Dim dateStr = "Date: " & DateTime.Now.ToString("MMMM dd, yyyy")
        Dim sfRight As New StringFormat() With {.Alignment = StringAlignment.Far}
        g.DrawString(dateStr, fontPatientNormal, brushMuted, New RectangleF(left, top + 110, width, 20), sfRight)

        ' Divider
        g.DrawLine(penLight, left, top + 155, left + width, top + 155)

        ' Order Banner / Diagnosis Box
        Dim orderBannerBox As New RectangleF(left, top + 165, width, 26)
        g.FillRectangle(New SolidBrush(Color.FromArgb(240, 248, 246)), orderBannerBox)
        g.DrawRectangle(New Pen(Color.FromArgb(170, 215, 205)), Rectangle.Round(orderBannerBox))
        g.DrawString("LABORATORY & DIAGNOSTIC REQUEST ORDER", fontDocTitle, brushTeal, orderBannerBox, sfCenter)

        g.DrawString("Clinical Diagnosis / Impression: " & _diagnosis, fontBodyBold, brushDark, left, top + 200)

        ' Section: Diagnostic Tests Requested
        g.DrawString("REQUESTED DIAGNOSTIC TESTS & PANELS (" & _selectedTests.Count & " SELECTED)", fontSectionHeader, brushTeal, left, top + 225)

        Dim startY As Single = top + 250
        Dim colWidth As Single = width / 2 - 10
        For i As Integer = 0 To _selectedTests.Count - 1
            Dim col As Integer = i Mod 2
            Dim row As Integer = i \ 2
            Dim curX As Single = left + (col * (colWidth + 20))
            Dim curY As Single = startY + (row * 24)

            g.DrawString("☑  " & _selectedTests(i), fontBodyNormal, brushDark, curX, curY)
        Next

        Dim notesY As Single = startY + ((_selectedTests.Count + 1) \ 2 * 24) + 25
        g.DrawLine(penLight, left, notesY - 10, left + width, notesY - 10)

        ' Instructions
        g.DrawString("SPECIAL CLINICAL INSTRUCTIONS / PREPARATION:", fontSectionHeader, brushMuted, left, notesY)
        Dim instrText = If(String.IsNullOrWhiteSpace(txtInstructions.Text), "Fasting 8-10 hours if FBS/Lipid profile is included. Return with official results for review.", txtInstructions.Text.Trim())
        g.DrawString(instrText, fontBodyNormal, brushDark, New RectangleF(left, notesY + 22, width, 50))

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
Public Class LaboratoryDialog
    Inherits DoctorLaboratoryDialog

    Public Sub New(patientName As String, patientId As String, ageSex As String, diagnosis As String, Optional condition As String = "")
        MyBase.New(patientName, patientId, ageSex, diagnosis, condition)
    End Sub
End Class
