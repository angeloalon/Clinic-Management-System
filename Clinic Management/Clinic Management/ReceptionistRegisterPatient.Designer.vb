<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReceptionistRegisterPatient
    Inherits System.Windows.Forms.UserControl

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Me.pnlScroll = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'pnlScroll
        '
        Me.pnlScroll.AutoScroll = True
        Me.pnlScroll.BackColor = System.Drawing.Color.FromArgb(244, 247, 249)
        Me.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlScroll.Location = New System.Drawing.Point(0, 0)
        Me.pnlScroll.Name = "pnlScroll"
        Me.pnlScroll.Size = New System.Drawing.Size(831, 730)
        Me.pnlScroll.TabIndex = 0
        '
        'RegisterPatient
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(244, 247, 249)
        Me.Controls.Add(Me.pnlScroll)
        Me.Name = "ReceptionistRegisterPatient"
        Me.Size = New System.Drawing.Size(831, 730)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlScroll As System.Windows.Forms.Panel

End Class