Imports System.Drawing
Imports System.Windows.Forms
Imports Ferrando.UI.WinForms.Controles

Public Class DoctorReportsDrillDownDialog
    Inherits Form

    Private _grid As DataGridView
    Private _items As List(Of AppointmentItem)
    Private _metricTitle As String

    Public Sub New(metricTitle As String, items As List(Of AppointmentItem))
        _metricTitle = metricTitle
        _items = items
        InitializeComponentCustom()
    End Sub

    Private Sub InitializeComponentCustom()
        Me.Text = _metricTitle
        Me.Size = New Size(820, 520)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.StartPosition = FormStartPosition.CenterParent
        Me.BackColor = Color.FromArgb(244, 247, 249)
        Me.Font = New Font("Segoe UI", 9.0F)

        Dim pnlHeader As New Panel With {
            .Dock = DockStyle.Top,
            .Height = 70,
            .BackColor = Color.White
        }

        Dim lblTitle As New Label With {
            .Text = _metricTitle,
            .Font = New Font("Segoe UI", 13.0F, FontStyle.Bold),
            .ForeColor = Color.FromArgb(22, 51, 65),
            .Location = New Point(20, 14),
            .AutoSize = True
        }

        Dim lblSub As New Label With {
            .Text = $"Showing {_items.Count} patient record(s) matching this metric • UCC Health Clinic",
            .Font = New Font("Segoe UI", 8.5F),
            .ForeColor = Color.FromArgb(115, 138, 148),
            .Location = New Point(22, 40),
            .AutoSize = True
        }
        pnlHeader.Controls.AddRange(New Control() {lblTitle, lblSub})
        Me.Controls.Add(pnlHeader)

        ' Grid panel
        Dim pnlBody As New Panel With {
            .Dock = DockStyle.Fill,
            .Padding = New Padding(20)
        }

        _grid = New DataGridView With {
            .Dock = DockStyle.Fill,
            .BackgroundColor = Color.White,
            .BorderStyle = BorderStyle.None,
            .RowHeadersVisible = False,
            .AllowUserToAddRows = False,
            .AllowUserToDeleteRows = False,
            .ReadOnly = True,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            .MultiSelect = False,
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            .Font = New Font("Segoe UI", 9.0F),
            .RowTemplate = New DataGridViewRow() With {.Height = 36}
        }

        _grid.Columns.Add("Date", "Date & Time")
        _grid.Columns.Add("PatientId", "Patient ID")
        _grid.Columns.Add("Name", "Patient Name")
        _grid.Columns.Add("VisitType", "Visit Type")
        _grid.Columns.Add("Status", "Status")
        _grid.Columns.Add("Reason", "Reason / Diagnosis")

        _grid.Columns("Date").FillWeight = 20
        _grid.Columns("PatientId").FillWeight = 15
        _grid.Columns("Name").FillWeight = 25
        _grid.Columns("VisitType").FillWeight = 15
        _grid.Columns("Status").FillWeight = 12
        _grid.Columns("Reason").FillWeight = 28

        For Each item In _items
            Dim dateStr = If(Not String.IsNullOrEmpty(item.AppointmentDate), item.AppointmentDate, $"Day {item.Day}")
            Dim timeStr = ClinicData.FormatTime(item.Minutes)
            Dim reasonOrDiag = If(Not String.IsNullOrWhiteSpace(item.Diagnosis), item.Diagnosis, item.Reason)
            _grid.Rows.Add($"{dateStr} {timeStr}", item.PatientId, item.PatientName, item.VisitType, item.Status, reasonOrDiag)
        Next

        AddHandler _grid.CellDoubleClick, AddressOf Grid_CellDoubleClick
        pnlBody.Controls.Add(_grid)
        Me.Controls.Add(pnlBody)

        ' Bottom buttons panel
        Dim pnlBottom As New Panel With {
            .Dock = DockStyle.Bottom,
            .Height = 55,
            .BackColor = Color.White,
            .Padding = New Padding(20, 10, 20, 10)
        }

        Dim btnView As New FButton With {
            .Text = "Open Patient Chart",
            .Size = New Size(150, 34),
            .Dock = DockStyle.Left,
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
            .Cursor = Cursors.Hand
        }
        UIThemeHelper.ApplyPrimary(btnView)
        AddHandler btnView.Click, AddressOf BtnView_Click

        Dim btnClose As New FButton With {
            .Text = "Close",
            .Size = New Size(90, 34),
            .Dock = DockStyle.Right,
            .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
            .Cursor = Cursors.Hand
        }
        UIThemeHelper.ApplySecondary(btnClose)
        AddHandler btnClose.Click, Sub() Me.Close()

        pnlBottom.Controls.AddRange(New Control() {btnView, btnClose})
        Me.Controls.Add(pnlBottom)
    End Sub

    Private Sub Grid_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then
            OpenSelectedPatient()
        End If
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs)
        OpenSelectedPatient()
    End Sub

    Private Sub OpenSelectedPatient()
        If _grid.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a patient row from the list.", "View Patient", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim selIdx = _grid.SelectedRows(0).Index
        If selIdx >= 0 AndAlso selIdx < _items.Count Then
            Dim appt = _items(selIdx)
            Dim patient = PatientRepository.GetById(appt.PatientId)
            If patient IsNot Nothing Then
                Dim dlg As New DoctorPatientInformation(patient)
                dlg.ShowDialog(Me)
            Else
                MessageBox.Show($"Patient record {appt.PatientId} not found in repository.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

End Class
