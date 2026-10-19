<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReceptionistClinicReports
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblTitle = New Label()
        lblSubtitle = New Label()
        lblApptTitle = New Label()
        lblApptValue = New Label()
        lblApptNote = New Label()
        cardAppointments = New Ferrando.UI.WinForms.Controles.FCard()
        lblRateTitle = New Label()
        lblRateValue = New Label()
        lblRateNote = New Label()
        cardCompletion = New Ferrando.UI.WinForms.Controles.FCard()
        lblSeenTitle = New Label()
        lblSeenValue = New Label()
        lblSeenNote = New Label()
        cardPatientsSeen = New Ferrando.UI.WinForms.Controles.FCard()
        lblVolumeTitle = New Label()
        cardVolume = New Ferrando.UI.WinForms.Controles.FCard()
        lblDiagTitle = New Label()
        cardDiagnoses = New Ferrando.UI.WinForms.Controles.FCard()
        lblHistoryTitle = New Label()
        cardHistory = New Ferrando.UI.WinForms.Controles.FCard()
        cardAppointments.SuspendLayout()
        cardCompletion.SuspendLayout()
        cardPatientsSeen.SuspendLayout()
        cardVolume.SuspendLayout()
        cardDiagnoses.SuspendLayout()
        cardHistory.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.BackColor = Color.Transparent
        lblTitle.Font = New Font("Segoe UI", 18.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.FromArgb(CByte(22), CByte(51), CByte(65))
        lblTitle.Location = New Point(26, 20)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(154, 32)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Clinic reports"
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.AutoSize = True
        lblSubtitle.BackColor = Color.Transparent
        lblSubtitle.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSubtitle.ForeColor = Color.FromArgb(CByte(115), CByte(138), CByte(148))
        lblSubtitle.Location = New Point(28, 58)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(113, 15)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "Operational insights"
        ' 
        ' lblApptTitle
        ' 
        lblApptTitle.AutoSize = True
        lblApptTitle.BackColor = Color.Transparent
        lblApptTitle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblApptTitle.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblApptTitle.Location = New Point(16, 12)
        lblApptTitle.Name = "lblApptTitle"
        lblApptTitle.Size = New Size(86, 15)
        lblApptTitle.TabIndex = 0
        lblApptTitle.Text = "Appointments"
        ' 
        ' lblApptValue
        ' 
        lblApptValue.AutoSize = True
        lblApptValue.BackColor = Color.Transparent
        lblApptValue.Font = New Font("Segoe UI", 20.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblApptValue.ForeColor = Color.FromArgb(CByte(22), CByte(51), CByte(65))
        lblApptValue.Location = New Point(14, 30)
        lblApptValue.Name = "lblApptValue"
        lblApptValue.Size = New Size(32, 37)
        lblApptValue.TabIndex = 1
        lblApptValue.Text = "0"
        ' 
        ' lblApptNote
        ' 
        lblApptNote.AutoSize = True
        lblApptNote.BackColor = Color.Transparent
        lblApptNote.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblApptNote.ForeColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        lblApptNote.Location = New Point(16, 72)
        lblApptNote.Name = "lblApptNote"
        lblApptNote.Size = New Size(0, 12)
        lblApptNote.TabIndex = 2
        ' 
        ' cardAppointments
        ' 
        cardAppointments.BackColor = Color.White
        cardAppointments.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardAppointments.BorderHoverColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardAppointments.BorderRadius = 12
        cardAppointments.BorderSize = 1
        cardAppointments.Controls.Add(lblApptNote)
        cardAppointments.Controls.Add(lblApptValue)
        cardAppointments.Controls.Add(lblApptTitle)
        cardAppointments.EnableShadow = True
        cardAppointments.HoverTintColor = Color.White
        cardAppointments.Location = New Point(28, 92)
        cardAppointments.Name = "cardAppointments"
        cardAppointments.ShadowDepth = 4
        cardAppointments.Size = New Size(246, 96)
        cardAppointments.TabIndex = 2
        ' 
        ' lblRateTitle
        ' 
        lblRateTitle.AutoSize = True
        lblRateTitle.BackColor = Color.Transparent
        lblRateTitle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRateTitle.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblRateTitle.Location = New Point(16, 12)
        lblRateTitle.Name = "lblRateTitle"
        lblRateTitle.Size = New Size(97, 15)
        lblRateTitle.TabIndex = 0
        lblRateTitle.Text = "Completion rate"
        ' 
        ' lblRateValue
        ' 
        lblRateValue.AutoSize = True
        lblRateValue.BackColor = Color.Transparent
        lblRateValue.Font = New Font("Segoe UI", 20.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRateValue.ForeColor = Color.FromArgb(CByte(22), CByte(51), CByte(65))
        lblRateValue.Location = New Point(14, 30)
        lblRateValue.Name = "lblRateValue"
        lblRateValue.Size = New Size(54, 37)
        lblRateValue.TabIndex = 1
        lblRateValue.Text = "0%"
        ' 
        ' lblRateNote
        ' 
        lblRateNote.AutoSize = True
        lblRateNote.BackColor = Color.Transparent
        lblRateNote.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRateNote.ForeColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        lblRateNote.Location = New Point(16, 72)
        lblRateNote.Name = "lblRateNote"
        lblRateNote.Size = New Size(0, 12)
        lblRateNote.TabIndex = 2
        ' 
        ' cardCompletion
        ' 
        cardCompletion.BackColor = Color.White
        cardCompletion.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardCompletion.BorderHoverColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardCompletion.BorderRadius = 12
        cardCompletion.BorderSize = 1
        cardCompletion.Controls.Add(lblRateNote)
        cardCompletion.Controls.Add(lblRateValue)
        cardCompletion.Controls.Add(lblRateTitle)
        cardCompletion.EnableShadow = True
        cardCompletion.HoverTintColor = Color.White
        cardCompletion.Location = New Point(292, 92)
        cardCompletion.Name = "cardCompletion"
        cardCompletion.ShadowDepth = 4
        cardCompletion.Size = New Size(246, 96)
        cardCompletion.TabIndex = 3
        ' 
        ' lblSeenTitle
        ' 
        lblSeenTitle.AutoSize = True
        lblSeenTitle.BackColor = Color.Transparent
        lblSeenTitle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSeenTitle.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblSeenTitle.Location = New Point(16, 12)
        lblSeenTitle.Name = "lblSeenTitle"
        lblSeenTitle.Size = New Size(81, 15)
        lblSeenTitle.TabIndex = 0
        lblSeenTitle.Text = "Patients seen"
        ' 
        ' lblSeenValue
        ' 
        lblSeenValue.AutoSize = True
        lblSeenValue.BackColor = Color.Transparent
        lblSeenValue.Font = New Font("Segoe UI", 20.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSeenValue.ForeColor = Color.FromArgb(CByte(22), CByte(51), CByte(65))
        lblSeenValue.Location = New Point(14, 30)
        lblSeenValue.Name = "lblSeenValue"
        lblSeenValue.Size = New Size(32, 37)
        lblSeenValue.TabIndex = 1
        lblSeenValue.Text = "0"
        ' 
        ' lblSeenNote
        ' 
        lblSeenNote.AutoSize = True
        lblSeenNote.BackColor = Color.Transparent
        lblSeenNote.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSeenNote.ForeColor = Color.FromArgb(CByte(29), CByte(124), CByte(107))
        lblSeenNote.Location = New Point(16, 72)
        lblSeenNote.Name = "lblSeenNote"
        lblSeenNote.Size = New Size(0, 12)
        lblSeenNote.TabIndex = 2
        ' 
        ' cardPatientsSeen
        ' 
        cardPatientsSeen.BackColor = Color.White
        cardPatientsSeen.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardPatientsSeen.BorderHoverColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardPatientsSeen.BorderRadius = 12
        cardPatientsSeen.BorderSize = 1
        cardPatientsSeen.Controls.Add(lblSeenNote)
        cardPatientsSeen.Controls.Add(lblSeenValue)
        cardPatientsSeen.Controls.Add(lblSeenTitle)
        cardPatientsSeen.EnableShadow = True
        cardPatientsSeen.HoverTintColor = Color.White
        cardPatientsSeen.Location = New Point(556, 92)
        cardPatientsSeen.Name = "cardPatientsSeen"
        cardPatientsSeen.ShadowDepth = 4
        cardPatientsSeen.Size = New Size(246, 96)
        cardPatientsSeen.TabIndex = 4
        ' 
        ' lblVolumeTitle
        ' 
        lblVolumeTitle.AutoSize = True
        lblVolumeTitle.BackColor = Color.Transparent
        lblVolumeTitle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblVolumeTitle.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblVolumeTitle.Location = New Point(18, 14)
        lblVolumeTitle.Name = "lblVolumeTitle"
        lblVolumeTitle.Size = New Size(126, 15)
        lblVolumeTitle.TabIndex = 0
        lblVolumeTitle.Text = "Appointment volume"
        ' 
        ' cardVolume
        ' 
        cardVolume.BackColor = Color.White
        cardVolume.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardVolume.BorderHoverColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardVolume.BorderRadius = 12
        cardVolume.BorderSize = 1
        cardVolume.Controls.Add(lblVolumeTitle)
        cardVolume.EnableShadow = True
        cardVolume.HoverTintColor = Color.White
        cardVolume.Location = New Point(28, 206)
        cardVolume.Name = "cardVolume"
        cardVolume.ShadowDepth = 4
        cardVolume.Size = New Size(490, 190)
        cardVolume.TabIndex = 5
        ' 
        ' lblDiagTitle
        ' 
        lblDiagTitle.AutoSize = True
        lblDiagTitle.BackColor = Color.Transparent
        lblDiagTitle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDiagTitle.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblDiagTitle.Location = New Point(18, 14)
        lblDiagTitle.Name = "lblDiagTitle"
        lblDiagTitle.Size = New Size(114, 15)
        lblDiagTitle.TabIndex = 0
        lblDiagTitle.Text = "Common diagnoses"
        ' 
        ' cardDiagnoses
        ' 
        cardDiagnoses.BackColor = Color.White
        cardDiagnoses.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardDiagnoses.BorderHoverColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardDiagnoses.BorderRadius = 12
        cardDiagnoses.BorderSize = 1
        cardDiagnoses.Controls.Add(lblDiagTitle)
        cardDiagnoses.EnableShadow = True
        cardDiagnoses.HoverTintColor = Color.White
        cardDiagnoses.Location = New Point(536, 206)
        cardDiagnoses.Name = "cardDiagnoses"
        cardDiagnoses.ShadowDepth = 4
        cardDiagnoses.Size = New Size(266, 190)
        cardDiagnoses.TabIndex = 6
        ' 
        ' lblHistoryTitle
        ' 
        lblHistoryTitle.AutoSize = True
        lblHistoryTitle.BackColor = Color.Transparent
        lblHistoryTitle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblHistoryTitle.ForeColor = Color.FromArgb(CByte(30), CByte(45), CByte(55))
        lblHistoryTitle.Location = New Point(18, 14)
        lblHistoryTitle.Name = "lblHistoryTitle"
        lblHistoryTitle.Size = New Size(114, 15)
        lblHistoryTitle.TabIndex = 0
        lblHistoryTitle.Text = "Patient visit history"
        ' 
        ' cardHistory
        ' 
        cardHistory.BackColor = Color.White
        cardHistory.BorderColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardHistory.BorderHoverColor = Color.FromArgb(CByte(232), CByte(237), CByte(240))
        cardHistory.BorderRadius = 12
        cardHistory.BorderSize = 1
        cardHistory.Controls.Add(lblHistoryTitle)
        cardHistory.EnableShadow = True
        cardHistory.HoverTintColor = Color.White
        cardHistory.Location = New Point(28, 414)
        cardHistory.Name = "cardHistory"
        cardHistory.ShadowDepth = 4
        cardHistory.Size = New Size(774, 208)
        cardHistory.TabIndex = 7
        ' 
        ' ClinicReports
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(244), CByte(247), CByte(249))
        ClientSize = New Size(830, 729)
        Controls.Add(cardHistory)
        Controls.Add(cardDiagnoses)
        Controls.Add(cardVolume)
        Controls.Add(cardPatientsSeen)
        Controls.Add(cardCompletion)
        Controls.Add(cardAppointments)
        Controls.Add(lblSubtitle)
        Controls.Add(lblTitle)
        FormBorderStyle = FormBorderStyle.None
        Name = "ReceptionistClinicReports"
        Text = "ReceptionistClinicReports"
        cardAppointments.ResumeLayout(False)
        cardAppointments.PerformLayout()
        cardCompletion.ResumeLayout(False)
        cardCompletion.PerformLayout()
        cardPatientsSeen.ResumeLayout(False)
        cardPatientsSeen.PerformLayout()
        cardVolume.ResumeLayout(False)
        cardVolume.PerformLayout()
        cardDiagnoses.ResumeLayout(False)
        cardDiagnoses.PerformLayout()
        cardHistory.ResumeLayout(False)
        cardHistory.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents lblApptTitle As Label
    Friend WithEvents lblApptValue As Label
    Friend WithEvents lblApptNote As Label
    Friend WithEvents cardAppointments As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblRateTitle As Label
    Friend WithEvents lblRateValue As Label
    Friend WithEvents lblRateNote As Label
    Friend WithEvents cardCompletion As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblSeenTitle As Label
    Friend WithEvents lblSeenValue As Label
    Friend WithEvents lblSeenNote As Label
    Friend WithEvents cardPatientsSeen As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblVolumeTitle As Label
    Friend WithEvents cardVolume As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblDiagTitle As Label
    Friend WithEvents cardDiagnoses As Ferrando.UI.WinForms.Controles.FCard
    Friend WithEvents lblHistoryTitle As Label
    Friend WithEvents cardHistory As Ferrando.UI.WinForms.Controles.FCard

End Class