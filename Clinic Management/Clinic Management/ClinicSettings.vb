Imports System.Text.RegularExpressions
Imports Ferrando.UI.WinForms.Controles

Public Class ClinicSettings

    ''' <summary>Raised after the settings were saved successfully.</summary>
    Public Event SettingsSaved()

    Private Class FieldUi
        Public Box As FCard
        Public Txt As TextBox
    End Class

    Private ReadOnly _fields As New List(Of FieldUi)()

    Public Sub New()
        InitializeComponent()

        AddField("cardClinicNameBox", "txtClinicName")
        AddField("cardClinicTypeBox", "txtClinicType")
        AddField("cardAddressBox", "txtAddress")
        AddField("cardContactBox", "txtContact")
        AddField("cardEmailBox", "txtEmail")
        AddField("cardApptLengthBox", "txtApptLength")

        UIThemeHelper.ApplyPrimary(btnSave)
        AddHandler btnSave.Click, AddressOf Save_Click
        LoadProfile()
    End Sub

    Private Function Ctl(Of T As Control)(name As String) As T
        Dim found As Control() = Controls.Find(name, True)
        If found.Length = 0 Then Return Nothing
        Return DirectCast(found(0), T)
    End Function

    ' Click anywhere on the box to focus; teal border while focused
    Private Sub AddField(boxName As String, txtName As String)
        Dim f As New FieldUi()
        f.Box = Ctl(Of FCard)(boxName)
        f.Txt = Ctl(Of TextBox)(txtName)
        AddHandler f.Box.Click, Sub() f.Txt.Focus()
        AddHandler f.Txt.Enter, Sub() SetBorder(f.Box, Hx("#238978"))
        AddHandler f.Txt.Leave, Sub() SetBorder(f.Box, Hx("#DCE4E8"))
        _fields.Add(f)
    End Sub

    Private Shared Sub SetBorder(box As FCard, c As Color)
        box.BorderColor = c
        box.BorderHoverColor = c
        box.Invalidate()
    End Sub

    ' ------------------------------------------------------------------ data

    Private Sub LoadProfile()
        txtClinicName.Text = ClinicProfile.ClinicName
        txtClinicType.Text = ClinicProfile.ClinicType
        txtAddress.Text = ClinicProfile.Address
        txtContact.Text = ClinicProfile.Contact
        txtEmail.Text = ClinicProfile.Email
        txtApptLength.Text = ClinicProfile.ApptMinutes & " minutes"
    End Sub

    Private Sub Save_Click(sender As Object, e As EventArgs)
        If Not ValidateInputs() Then Return

        ClinicProfile.ClinicName = txtClinicName.Text.Trim()
        ClinicProfile.ClinicType = txtClinicType.Text.Trim()
        ClinicProfile.Address = txtAddress.Text.Trim()
        ClinicProfile.Contact = txtContact.Text.Trim()
        ClinicProfile.Email = txtEmail.Text.Trim()
        ClinicProfile.ApptMinutes = ParseMinutes()
        txtApptLength.Text = ClinicProfile.ApptMinutes & " minutes"

        AuditStore.Log("Rosa Dela Cruz", "Administrator", "Clinic settings edited", "Clinic profile updated", "Success")

        MessageBox.Show("Clinic settings saved.", "Clinic settings",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
        RaiseEvent SettingsSaved()
    End Sub

    ' ------------------------------------------------------------------ validation

    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(txtClinicName.Text) Then Return Fail("Clinic name is required.", txtClinicName)
        If String.IsNullOrWhiteSpace(txtClinicType.Text) Then Return Fail("Clinic type is required.", txtClinicType)
        If String.IsNullOrWhiteSpace(txtAddress.Text) Then Return Fail("Address is required.", txtAddress)

        Dim contact As String = txtContact.Text.Trim()
        If Not Regex.IsMatch(contact, "^[\d\s\(\)\+\-]+$") OrElse Regex.Replace(contact, "\D", "").Length < 7 Then
            Return Fail("Enter a valid contact number.", txtContact)
        End If

        If Not Regex.IsMatch(txtEmail.Text.Trim(), "^[^@\s]+@[^@\s]+\.[^@\s]+$") Then
            Return Fail("Enter a valid email address.", txtEmail)
        End If

        Dim mins As Integer = ParseMinutes()
        If mins < 5 OrElse mins > 240 Then
            Return Fail("Appointment length must be 5 to 240 minutes (e.g. 30 minutes).", txtApptLength)
        End If
        Return True
    End Function

    Private Function ParseMinutes() As Integer
        Dim m As Match = Regex.Match(txtApptLength.Text, "\d+")
        Return If(m.Success, CInt(m.Value), 0)
    End Function

    Private Function Fail(msg As String, target As TextBox) As Boolean
        MessageBox.Show(msg, "Clinic settings", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        target.Focus()
        target.SelectAll()
        Return False
    End Function

    ' Local hex-to-Color helper (no dependency on ClinicData)
    Private Shared Function Hx(code As String) As Color
        Return ColorTranslator.FromHtml(code)
    End Function

End Class