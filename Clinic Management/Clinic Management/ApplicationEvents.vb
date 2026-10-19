Imports System.IO
Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.

    ' **NEW** ApplyApplicationDefaults: Raised when the application queries default values to be set for the application.

    ' Example:
    ' Private Sub MyApplication_ApplyApplicationDefaults(sender As Object, e As ApplyApplicationDefaultsEventArgs) Handles Me.ApplyApplicationDefaults
    '
    '   ' Setting the application-wide default Font:
    '   e.Font = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular)
    '
    '   ' Setting the HighDpiMode for the Application:
    '   e.HighDpiMode = HighDpiMode.PerMonitorV2
    '
    '   ' If a splash dialog is used, this sets the minimum display time:
    '   e.MinimumSplashScreenDisplayTime = 4000
    ' End Sub

    Partial Friend Class MyApplication

        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            DatabaseInitializer.Initialize()

            If e.CommandLine.Contains("--test-db") Then
                Dim patCount = SqlitePatientRepository.GetAll().Count
                Dim apptCount = SqliteAppointmentRepository.GetAllAppointments().Count
                Dim staffCount = SqliteStaffRepository.GetAll().Count
                Dim auditCount = SqliteAuditRepository.GetAll().Count
                Dim isDocValid = SqliteStaffRepository.VerifyPassword("elena.cruz@uccclinic.edu.ph", "doctor123")
                Dim settings = SqliteClinicSettingsRepository.GetSettings()

                Dim testLog = $"DB_TEST_OK|Patients={patCount}|Appts={apptCount}|Staff={staffCount}|Audit={auditCount}|DocAuth={isDocValid}|Clinic={settings.ClinicName}"
                Dim outPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db_test_result.txt")
                File.WriteAllText(outPath, testLog)
                Console.WriteLine(testLog)
                e.Cancel = True
            End If
        End Sub

    End Class
End Namespace
