Imports Microsoft.Data.Sqlite

Public Class SqliteClinicSettingsRepository

    Public Shared Function GetSettings() As (ClinicName As String, ClinicType As String, Address As String, Contact As String, Email As String, ApptMinutes As Integer)
        DatabaseInitializer.Initialize()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    SELECT clinic_name, clinic_type, address, contact, email, appt_minutes
                    FROM clinic_settings
                    WHERE id = 1
                    LIMIT 1;
                "
                Using reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Return (
                            reader.GetString(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetInt32(5)
                        )
                    End If
                End Using
            End Using
        End Using

        Return ("UCC Health Clinic", "General practice", "Health Clinic, Caloocan City", "(02) 8555 0142", "clinic@uccclinic.edu.ph", 30)
    End Function

    Public Shared Sub SaveSettings(clinicName As String, clinicType As String, address As String,
                                   contact As String, email As String, apptMinutes As Integer)
        DatabaseInitializer.Initialize()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    INSERT INTO clinic_settings (id, clinic_name, clinic_type, address, contact, email, appt_minutes, updated_at)
                    VALUES (1, @name, @type, @addr, @contact, @email, @mins, datetime('now', 'localtime'))
                    ON CONFLICT(id) DO UPDATE SET
                        clinic_name = excluded.clinic_name,
                        clinic_type = excluded.clinic_type,
                        address = excluded.address,
                        contact = excluded.contact,
                        email = excluded.email,
                        appt_minutes = excluded.appt_minutes,
                        updated_at = datetime('now', 'localtime');
                "
                cmd.Parameters.AddWithValue("@name", clinicName)
                cmd.Parameters.AddWithValue("@type", clinicType)
                cmd.Parameters.AddWithValue("@addr", address)
                cmd.Parameters.AddWithValue("@contact", contact)
                cmd.Parameters.AddWithValue("@email", email)
                cmd.Parameters.AddWithValue("@mins", apptMinutes)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Class
