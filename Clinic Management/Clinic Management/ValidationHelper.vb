Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class ValidationHelper

    Private Shared ReadOnly NameRegex As New Regex("^[a-zA-ZñÑ\s\-]+$", RegexOptions.Compiled)
    Private Shared ReadOnly PhoneRegex As New Regex("^09\d{9}$", RegexOptions.Compiled)

    ''' <summary>
    ''' Validates names allowing only letters, spaces, hyphens, and ñ/Ñ.
    ''' </summary>
    Public Shared Function IsValidName(name As String) As Boolean
        If String.IsNullOrWhiteSpace(name) Then Return False
        Return NameRegex.IsMatch(name.Trim())
    End Function

    ''' <summary>
    ''' Validates Philippine mobile numbers starting with 09 and having 11 digits total.
    ''' </summary>
    Public Shared Function IsValidPhone(phone As String) As Boolean
        If String.IsNullOrWhiteSpace(phone) Then Return False
        Dim digits = Regex.Replace(phone, "\D", "")
        Return PhoneRegex.IsMatch(digits)
    End Function

    ''' <summary>
    ''' Wires a name TextBox with real-time character blocking (letters, spaces, hyphen, ñ only) and ErrorProvider feedback.
    ''' </summary>
    Public Shared Sub AttachNameValidation(tb As TextBox, errProvider As ErrorProvider, Optional fieldName As String = "Name")
        If tb Is Nothing OrElse errProvider Is Nothing Then Return

        AddHandler tb.KeyPress,
            Sub(sender As Object, e As KeyPressEventArgs)
                If Char.IsControl(e.KeyChar) Then Return
                Dim ch = e.KeyChar
                Dim isAllowed = Char.IsLetter(ch) OrElse ch = " "c OrElse ch = "-"c OrElse ch = "ñ"c OrElse ch = "Ñ"c
                If Not isAllowed Then
                    e.Handled = True
                End If
            End Sub

        Dim validateAction =
            Sub()
                Dim val = tb.Text.Trim()
                If val.Length = 0 Then
                    errProvider.SetError(tb, $"{fieldName} is required.")
                ElseIf Not IsValidName(val) Then
                    errProvider.SetError(tb, $"{fieldName} may only contain letters, spaces, hyphens, and ñ.")
                Else
                    errProvider.SetError(tb, "")
                End If
            End Sub

        AddHandler tb.TextChanged, Sub(s, e) validateAction()
    End Sub

    ''' <summary>
    ''' Wires a phone TextBox with real-time letter blocking, 11-digit cap, and ErrorProvider feedback.
    ''' </summary>
    Public Shared Sub AttachPhoneValidation(tb As TextBox, errProvider As ErrorProvider)
        If tb Is Nothing OrElse errProvider Is Nothing Then Return

        AddHandler tb.KeyPress,
            Sub(sender As Object, e As KeyPressEventArgs)
                If Char.IsControl(e.KeyChar) Then Return
                ' Block non-digits
                If Not Char.IsDigit(e.KeyChar) Then
                    e.Handled = True
                    Return
                End If

                ' Prevent typing more than 11 digits
                Dim currentDigits = Regex.Replace(tb.Text, "\D", "")
                If currentDigits.Length >= 11 AndAlso tb.SelectionLength = 0 Then
                    e.Handled = True
                End If
            End Sub

        Dim validateAction =
            Sub()
                Dim val = tb.Text.Trim()
                Dim digits = Regex.Replace(val, "\D", "")
                If digits.Length = 0 Then
                    errProvider.SetError(tb, "Phone number is required.")
                ElseIf Not digits.StartsWith("09") Then
                    errProvider.SetError(tb, "Phone number must start with 09.")
                ElseIf digits.Length < 11 Then
                    errProvider.SetError(tb, $"Phone number must be 11 digits (currently {digits.Length} digits).")
                ElseIf digits.Length = 11 Then
                    errProvider.SetError(tb, "")
                Else
                    errProvider.SetError(tb, "Phone number cannot exceed 11 digits.")
                End If
            End Sub

        AddHandler tb.TextChanged, Sub(s, e) validateAction()
    End Sub

    ''' <summary>
    ''' Capitalizes the first letter of each word and lowercases the rest (e.g. "angelo a alon" -> "Angelo A Alon").
    ''' </summary>
    Public Shared Function NormalizeProperCase(input As String) As String
        If String.IsNullOrWhiteSpace(input) Then Return ""
        Dim textInfo = System.Globalization.CultureInfo.CurrentCulture.TextInfo
        Dim cleaned = Regex.Replace(input.Trim(), "\s+", " ")
        Return textInfo.ToTitleCase(cleaned.ToLower())
    End Function

    ''' <summary>
    ''' Standardizes Philippine mobile numbers into the format "09XX XXX XXXX".
    ''' </summary>
    Public Shared Function FormatPhoneNumber(phone As String) As String
        If String.IsNullOrWhiteSpace(phone) Then Return ""
        Dim digits = Regex.Replace(phone, "\D", "")
        If digits.Length = 11 AndAlso digits.StartsWith("09") Then
            Return $"{digits.Substring(0, 4)} {digits.Substring(4, 3)} {digits.Substring(7, 4)}"
        ElseIf digits.Length = 10 AndAlso digits.StartsWith("9") Then
            Return $"0{digits.Substring(0, 3)} {digits.Substring(3, 3)} {digits.Substring(6, 4)}"
        End If
        Return phone.Trim()
    End Function

End Class
