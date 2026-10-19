Imports System.Security.Cryptography

Public Class InviteCodeDialog

    Private ReadOnly _staffName As String
    Private ReadOnly _staffRole As String
    Private ReadOnly _inviteCode As String

    Public ReadOnly Property InviteCode As String
        Get
            Return _inviteCode
        End Get
    End Property

    Public Sub New(staffName As String, staffRole As String)
        InitializeComponent()
        _staffName = staffName
        _staffRole = staffRole
        _inviteCode = GenerateCode()

        lblStaffDetail.Text = $"Staff: {_staffName} ({_staffRole})"
        lblInviteCode.Text = _inviteCode

        UIThemeHelper.ApplyNeutral(btnCopy)
        UIThemeHelper.ApplyPrimary(btnDone)
    End Sub

    ''' <summary>
    ''' Generates an 8-character code formatted as XXXX-XXXX excluding 0, O, 1, I using RNGCryptoServiceProvider / RandomNumberGenerator.
    ''' </summary>
    Private Shared Function GenerateCode() As String
        Const chars As String = "23456789ABCDEFGHJKLMNPQRSTUVWXYZ"
        Dim bytes(7) As Byte
        RandomNumberGenerator.Fill(bytes)

        Dim part1 As String = ""
        For i As Integer = 0 To 3
            part1 &= chars(bytes(i) Mod chars.Length)
        Next

        Dim part2 As String = ""
        For i As Integer = 4 To 7
            part2 &= chars(bytes(i) Mod chars.Length)
        Next

        Return $"{part1}-{part2}"
    End Function

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        Try
            Clipboard.SetText(_inviteCode)
            btnCopy.Text = "Copied!"
            btnCopy.BackColor = Color.FromArgb(221, 240, 235)
            btnCopy.ForeColor = Color.FromArgb(35, 137, 120)
        Catch ex As Exception
            MessageBox.Show("Could not copy to clipboard. Please copy manually: " & _inviteCode, "Copy Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

End Class
