Imports Ferrando.UI.WinForms.Controles

Public Class SidebarHandler

    Private _activeButton As FButton = Nothing

    ' Remembers each button's own hover font from the designer
    Private ReadOnly _hoverFonts As New Dictionary(Of FButton, Font)

    ' Default (normal) style
    Private ReadOnly DefaultBack As Color = Color.FromArgb(17, 54, 70)
    Private ReadOnly DefaultFore As Color = Color.FromArgb(182, 204, 210)
    Private ReadOnly DefaultFont As New Font("Noto Sans Georgian", 12, FontStyle.Regular, GraphicsUnit.Point)

    ' Pressed (active) style
    Private ReadOnly ActiveBack As Color = Color.FromArgb(39, 73, 87)
    Private ReadOnly ActiveFore As Color = Color.FromArgb(255, 254, 255)
    Private ReadOnly ActiveFont As New Font("Noto Sans Georgian Bold", 12, FontStyle.Bold, GraphicsUnit.Point)

    Public Sub New(ParamArray buttons() As FButton)
        For Each btn In buttons
            _hoverFonts(btn) = btn.MouseEnterFont   ' save designer value
            ApplyDefault(btn)
            AddHandler btn.Click, AddressOf Button_Click
        Next
    End Sub

    Private Sub Button_Click(sender As Object, e As EventArgs)
        SetActive(DirectCast(sender, FButton))
    End Sub

    Public Sub SetActive(btn As FButton)
        If btn Is _activeButton Then Return

        If _activeButton IsNot Nothing Then
            ApplyDefault(_activeButton)
        End If

        ApplyActive(btn)
        _activeButton = btn
    End Sub

    Private Sub ApplyDefault(btn As FButton)
        btn.BackColor = DefaultBack
        btn.ForeColor = DefaultFore
        btn.Font = DefaultFont

        btn.MouseLeaveBackColor = DefaultBack
        btn.MouseLeaveForeColor = DefaultFore
        btn.MouseLeaveFont = DefaultFont

        btn.MouseEnterFont = _hoverFonts(btn)   ' back to the designer's hover font
    End Sub

    Private Sub ApplyActive(btn As FButton)
        btn.BackColor = ActiveBack
        btn.ForeColor = ActiveFore
        btn.Font = ActiveFont

        btn.MouseLeaveBackColor = ActiveBack
        btn.MouseLeaveForeColor = ActiveFore
        btn.MouseLeaveFont = ActiveFont

        btn.MouseEnterFont = ActiveFont         ' stay bold while hovering
    End Sub

End Class