Imports Microsoft.Data.Sqlite

Public Class SqliteConsultationRepository

    Public Shared Sub SavePrescription(patientId As String, doctorName As String, medicationText As String, adviceText As String, Optional allergyWarning As String = "")
        DatabaseInitializer.Initialize()

        Dim code = "RX-" & DateTime.Now.ToString("yyyyMMdd-HHmmss")
        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    INSERT INTO prescriptions (prescription_code, patient_id, doctor_name, medication_text, advice_text, allergy_warning)
                    VALUES (@code, @pid, @doc, @med, @adv, @alg);
                "
                DatabaseService.AddParam(cmd, "@code", code)
                DatabaseService.AddParam(cmd, "@pid", If(patientId, ""))
                DatabaseService.AddParam(cmd, "@doc", If(doctorName, ""))
                DatabaseService.AddParam(cmd, "@med", If(medicationText, ""))
                DatabaseService.AddParam(cmd, "@adv", If(adviceText, ""))
                DatabaseService.AddParam(cmd, "@alg", If(allergyWarning, ""))
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Shared Sub SaveLabRequest(patientId As String, doctorName As String, diagnosis As String, testsJson As String)
        DatabaseInitializer.Initialize()

        Dim code = "LAB-" & DateTime.Now.ToString("yyyyMMdd-HHmmss")
        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    INSERT INTO lab_requests (request_code, patient_id, doctor_name, diagnosis, ordered_tests_json, status)
                    VALUES (@code, @pid, @doc, @diag, @tests, 'Pending');
                "
                DatabaseService.AddParam(cmd, "@code", code)
                DatabaseService.AddParam(cmd, "@pid", If(patientId, ""))
                DatabaseService.AddParam(cmd, "@doc", If(doctorName, ""))
                DatabaseService.AddParam(cmd, "@diag", If(diagnosis, ""))
                DatabaseService.AddParam(cmd, "@tests", If(testsJson, "[]"))
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Shared Function GetPrescriptionsForPatient(patientId As String) As List(Of (Code As String, Medication As String, Advice As String, CreatedAt As String, Doctor As String))
        DatabaseInitializer.Initialize()
        Dim list As New List(Of (Code As String, Medication As String, Advice As String, CreatedAt As String, Doctor As String))()
        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    SELECT prescription_code, medication_text, advice_text, created_at, doctor_name
                    FROM prescriptions
                    WHERE patient_id = @pid
                    ORDER BY id DESC;
                "
                cmd.Parameters.AddWithValue("@pid", If(patientId, ""))
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        list.Add((
                            reader.GetString(0),
                            reader.GetString(1),
                            If(reader.IsDBNull(2), "", reader.GetString(2)),
                            reader.GetString(3),
                            reader.GetString(4)
                        ))
                    End While
                End Using
            End Using
        End Using
        Return list
    End Function

End Class
