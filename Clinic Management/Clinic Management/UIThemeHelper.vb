Imports System.Drawing
Imports System.Windows.Forms
Imports Ferrando.UI.WinForms.Controles

Public Class UIThemeHelper

    ' Core Brand Colors
    Public Shared ReadOnly ColorTealPrimary As Color = Color.FromArgb(29, 124, 107)        ' #1D7C6B
    Public Shared ReadOnly ColorTealHover As Color = Color.FromArgb(23, 105, 90)           ' #17695A
    Public Shared ReadOnly ColorTealPressed As Color = Color.FromArgb(19, 84, 72)          ' #135448

    Public Shared ReadOnly ColorSecondaryBorder As Color = Color.FromArgb(210, 222, 228)   ' #D2DEE4
    Public Shared ReadOnly ColorSecondaryHoverBack As Color = Color.FromArgb(245, 249, 251)' #F5F9FB
    Public Shared ReadOnly ColorSecondaryHoverBorder As Color = Color.FromArgb(29, 124, 107)
    Public Shared ReadOnly ColorSecondaryPressedBack As Color = Color.FromArgb(228, 237, 241)

    Public Shared ReadOnly ColorDangerBack As Color = Color.FromArgb(253, 236, 236)        ' #FDECEC
    Public Shared ReadOnly ColorDangerFore As Color = Color.FromArgb(205, 80, 75)          ' #CD504B
    Public Shared ReadOnly ColorDangerBorder As Color = Color.FromArgb(244, 204, 202)
    Public Shared ReadOnly ColorDangerHoverBack As Color = Color.FromArgb(251, 215, 214)
    Public Shared ReadOnly ColorDangerPressedBack As Color = Color.FromArgb(249, 188, 186)

    Public Shared ReadOnly ColorNeutralBack As Color = Color.FromArgb(243, 246, 248)       ' #F3F6F8
    Public Shared ReadOnly ColorNeutralFore As Color = Color.FromArgb(35, 45, 55)
    Public Shared ReadOnly ColorNeutralBorder As Color = Color.FromArgb(220, 228, 232)
    Public Shared ReadOnly ColorNeutralHoverBack As Color = Color.FromArgb(232, 238, 241)
    Public Shared ReadOnly ColorNeutralPressedBack As Color = Color.FromArgb(220, 228, 232)

    Public Shared ReadOnly ColorSuccessBack As Color = Color.FromArgb(230, 245, 235)       ' #E6F5EB
    Public Shared ReadOnly ColorSuccessFore As Color = Color.FromArgb(40, 135, 75)         ' #28874B
    Public Shared ReadOnly ColorSuccessBorder As Color = Color.FromArgb(201, 231, 211)

    Public Shared ReadOnly ColorWarningBack As Color = Color.FromArgb(254, 243, 226)       ' #FEF3E2
    Public Shared ReadOnly ColorWarningFore As Color = Color.FromArgb(217, 119, 6)         ' #D97706
    Public Shared ReadOnly ColorWarningBorder As Color = Color.FromArgb(253, 219, 178)

    Public Shared ReadOnly ColorInfoBack As Color = Color.FromArgb(232, 240, 254)          ' #E8F0FE
    Public Shared ReadOnly ColorInfoFore As Color = Color.FromArgb(26, 115, 232)           ' #1A73E8
    Public Shared ReadOnly ColorInfoBorder As Color = Color.FromArgb(194, 217, 250)

    ''' <summary>
    ''' Applies Primary (Teal) styling to a button (e.g. Save, Confirm Booking, Register, Check-in).
    ''' </summary>
    Public Shared Sub ApplyPrimary(btn As Control)
        If btn Is Nothing Then Return
        btn.Cursor = Cursors.Hand

        If TypeOf btn Is FButton Then
            Dim fb = DirectCast(btn, FButton)
            fb.BackColor = ColorTealPrimary
            fb.ForeColor = Color.White
            fb.BorderRadius = 8
            fb.BorderSize = 0
            fb.TextAlign = ContentAlignment.MiddleCenter

            fb.MouseLeaveBackColor = ColorTealPrimary
            fb.MouseLeaveForeColor = Color.White
            fb.MouseLeaveBorderSize = 0
            fb.MouseLeaveFont = fb.Font

            fb.MouseEnterBackColor = ColorTealHover
            fb.MouseEnterForeColor = Color.White
            fb.MouseEnterBorderSize = 0
            fb.MouseEnterFont = fb.Font

            fb.Invalidate()
        ElseIf TypeOf btn Is Button Then
            Dim b = DirectCast(btn, Button)
            b.FlatStyle = FlatStyle.Flat
            b.BackColor = ColorTealPrimary
            b.ForeColor = Color.White
            b.FlatAppearance.BorderSize = 0
            b.FlatAppearance.MouseOverBackColor = ColorTealHover
            b.FlatAppearance.MouseDownBackColor = ColorTealPressed
        End If
    End Sub

    ''' <summary>
    ''' Applies Secondary (Outline) styling to a button (e.g. Cancel, Reschedule, Back).
    ''' </summary>
    Public Shared Sub ApplySecondary(btn As Control, Optional activeTealFore As Boolean = True)
        If btn Is Nothing Then Return
        btn.Cursor = Cursors.Hand
        Dim normalFore = If(activeTealFore, ColorTealPrimary, Color.FromArgb(45, 60, 70))
        Dim normalBorder = ColorSecondaryBorder

        If TypeOf btn Is FButton Then
            Dim fb = DirectCast(btn, FButton)
            fb.BackColor = Color.White
            fb.ForeColor = normalFore
            fb.BorderRadius = 8
            fb.BorderSize = 1
            fb.BorderColor = normalBorder
            fb.TextAlign = ContentAlignment.MiddleCenter

            fb.MouseLeaveBackColor = Color.White
            fb.MouseLeaveForeColor = normalFore
            fb.MouseLeaveBorderColor = normalBorder
            fb.MouseLeaveBorderSize = 1
            fb.MouseLeaveFont = fb.Font

            fb.MouseEnterBackColor = ColorSecondaryHoverBack
            fb.MouseEnterForeColor = ColorTealHover
            fb.MouseEnterBorderColor = ColorSecondaryHoverBorder
            fb.MouseEnterBorderSize = 1
            fb.MouseEnterFont = fb.Font

            fb.Invalidate()
        ElseIf TypeOf btn Is Button Then
            Dim b = DirectCast(btn, Button)
            b.FlatStyle = FlatStyle.Flat
            b.BackColor = Color.White
            b.ForeColor = normalFore
            b.FlatAppearance.BorderSize = 1
            b.FlatAppearance.BorderColor = normalBorder
            b.FlatAppearance.MouseOverBackColor = ColorSecondaryHoverBack
            b.FlatAppearance.MouseDownBackColor = ColorSecondaryPressedBack
        End If
    End Sub

    ''' <summary>
    ''' Applies Danger styling to a button (e.g. No-Show, Cancel Appointment).
    ''' </summary>
    Public Shared Sub ApplyDanger(btn As Control)
        If btn Is Nothing Then Return
        btn.Cursor = Cursors.Hand

        If TypeOf btn Is FButton Then
            Dim fb = DirectCast(btn, FButton)
            fb.BackColor = ColorDangerBack
            fb.ForeColor = ColorDangerFore
            fb.BorderRadius = 6
            fb.BorderSize = 1
            fb.BorderColor = ColorDangerBorder
            fb.TextAlign = ContentAlignment.MiddleCenter

            fb.MouseLeaveBackColor = ColorDangerBack
            fb.MouseLeaveForeColor = ColorDangerFore
            fb.MouseLeaveBorderColor = ColorDangerBorder
            fb.MouseLeaveBorderSize = 1
            fb.MouseLeaveFont = fb.Font

            fb.MouseEnterBackColor = ColorDangerHoverBack
            fb.MouseEnterForeColor = ColorDangerFore
            fb.MouseEnterBorderColor = ColorDangerBorder
            fb.MouseEnterBorderSize = 1
            fb.MouseEnterFont = fb.Font

            fb.Invalidate()
        ElseIf TypeOf btn Is Button Then
            Dim b = DirectCast(btn, Button)
            b.FlatStyle = FlatStyle.Flat
            b.BackColor = ColorDangerBack
            b.ForeColor = ColorDangerFore
            b.FlatAppearance.BorderSize = 1
            b.FlatAppearance.BorderColor = ColorDangerBorder
            b.FlatAppearance.MouseOverBackColor = ColorDangerHoverBack
            b.FlatAppearance.MouseDownBackColor = ColorDangerPressedBack
        End If
    End Sub

    ''' <summary>
    ''' Applies Neutral / Copy Code styling to a button.
    ''' </summary>
    Public Shared Sub ApplyNeutral(btn As Control)
        If btn Is Nothing Then Return
        btn.Cursor = Cursors.Hand

        If TypeOf btn Is FButton Then
            Dim fb = DirectCast(btn, FButton)
            fb.BackColor = ColorNeutralBack
            fb.ForeColor = ColorNeutralFore
            fb.BorderRadius = 6
            fb.BorderSize = 1
            fb.BorderColor = ColorNeutralBorder

            fb.MouseLeaveBackColor = ColorNeutralBack
            fb.MouseLeaveForeColor = ColorNeutralFore
            fb.MouseLeaveBorderColor = ColorNeutralBorder
            fb.MouseLeaveBorderSize = 1

            fb.MouseEnterBackColor = ColorNeutralHoverBack
            fb.MouseEnterForeColor = Color.FromArgb(17, 54, 70)
            fb.MouseEnterBorderColor = Color.FromArgb(180, 200, 210)
            fb.MouseEnterBorderSize = 1

            fb.Invalidate()
        ElseIf TypeOf btn Is Button Then
            Dim b = DirectCast(btn, Button)
            b.FlatStyle = FlatStyle.Flat
            b.BackColor = ColorNeutralBack
            b.ForeColor = ColorNeutralFore
            b.FlatAppearance.BorderSize = 1
            b.FlatAppearance.BorderColor = ColorNeutralBorder
            b.FlatAppearance.MouseOverBackColor = ColorNeutralHoverBack
            b.FlatAppearance.MouseDownBackColor = ColorNeutralPressedBack
        End If
    End Sub

    ''' <summary>
    ''' Applies Success styling (Green pill) to a control.
    ''' </summary>
    Public Shared Sub ApplySuccess(btn As Control)
        If btn Is Nothing Then Return
        If TypeOf btn Is FButton Then
            Dim fb = DirectCast(btn, FButton)
            fb.BackColor = ColorSuccessBack
            fb.ForeColor = ColorSuccessFore
            fb.BorderRadius = 6
            fb.BorderSize = 1
            fb.BorderColor = ColorSuccessBorder
            fb.MouseLeaveBackColor = ColorSuccessBack
            fb.MouseLeaveForeColor = ColorSuccessFore
            fb.MouseLeaveBorderColor = ColorSuccessBorder
            fb.MouseLeaveBorderSize = 1
            fb.MouseEnterBackColor = ColorSuccessBack
            fb.MouseEnterForeColor = ColorSuccessFore
            fb.MouseEnterBorderColor = ColorSuccessBorder
            fb.MouseEnterBorderSize = 1
            fb.Invalidate()
        ElseIf TypeOf btn Is Button Then
            Dim b = DirectCast(btn, Button)
            b.FlatStyle = FlatStyle.Flat
            b.BackColor = ColorSuccessBack
            b.ForeColor = ColorSuccessFore
            b.FlatAppearance.BorderSize = 1
            b.FlatAppearance.BorderColor = ColorSuccessBorder
        End If
    End Sub

    ''' <summary>
    ''' Applies Warning styling (Amber pill) to a control.
    ''' </summary>
    Public Shared Sub ApplyWarning(btn As Control)
        If btn Is Nothing Then Return
        If TypeOf btn Is FButton Then
            Dim fb = DirectCast(btn, FButton)
            fb.BackColor = ColorWarningBack
            fb.ForeColor = ColorWarningFore
            fb.BorderRadius = 6
            fb.BorderSize = 1
            fb.BorderColor = ColorWarningBorder
            fb.MouseLeaveBackColor = ColorWarningBack
            fb.MouseLeaveForeColor = ColorWarningFore
            fb.MouseLeaveBorderColor = ColorWarningBorder
            fb.MouseLeaveBorderSize = 1
            fb.MouseEnterBackColor = ColorWarningBack
            fb.MouseEnterForeColor = ColorWarningFore
            fb.MouseEnterBorderColor = ColorWarningBorder
            fb.MouseEnterBorderSize = 1
            fb.Invalidate()
        ElseIf TypeOf btn Is Button Then
            Dim b = DirectCast(btn, Button)
            b.FlatStyle = FlatStyle.Flat
            b.BackColor = ColorWarningBack
            b.ForeColor = ColorWarningFore
            b.FlatAppearance.BorderSize = 1
            b.FlatAppearance.BorderColor = ColorWarningBorder
        End If
    End Sub

    ''' <summary>
    ''' Applies Info styling (Blue pill) to a control.
    ''' </summary>
    Public Shared Sub ApplyInfo(btn As Control)
        If btn Is Nothing Then Return
        If TypeOf btn Is FButton Then
            Dim fb = DirectCast(btn, FButton)
            fb.BackColor = ColorInfoBack
            fb.ForeColor = ColorInfoFore
            fb.BorderRadius = 6
            fb.BorderSize = 1
            fb.BorderColor = ColorInfoBorder
            fb.MouseLeaveBackColor = ColorInfoBack
            fb.MouseLeaveForeColor = ColorInfoFore
            fb.MouseLeaveBorderColor = ColorInfoBorder
            fb.MouseLeaveBorderSize = 1
            fb.MouseEnterBackColor = ColorInfoBack
            fb.MouseEnterForeColor = ColorInfoFore
            fb.MouseEnterBorderColor = ColorInfoBorder
            fb.MouseEnterBorderSize = 1
            fb.Invalidate()
        ElseIf TypeOf btn Is Button Then
            Dim b = DirectCast(btn, Button)
            b.FlatStyle = FlatStyle.Flat
            b.BackColor = ColorInfoBack
            b.ForeColor = ColorInfoFore
            b.FlatAppearance.BorderSize = 1
            b.FlatAppearance.BorderColor = ColorInfoBorder
        End If
    End Sub

End Class
