Imports Microsoft.Data.Sqlite

Public Class ConsultationAccessRequestRecord
    Public Property Id As Integer
    Public Property AppointmentId As String
    Public Property PatientId As String
    Public Property PatientName As String
    Public Property DoctorName As String
    Public Property RequestedByUserId As Integer
    Public Property RequestedByName As String
    Public Property Reason As String
    Public Property Status As String ' Pending, Approved, Declined, Expired
    Public Property RequestedAt As String
    Public Property DecidedAt As String
    Public Property DecidedByName As String
    Public Property DecisionNote As String
    Public Property ExpiresAt As String
End Class

Public Class SqliteConsultationAccessRepository

    Public Shared Function CreateRequest(appointmentId As String, patientId As String, patientName As String,
                                         doctorName As String, requestedByUserId As Integer,
                                         requestedByName As String, reason As String) As Integer
        DatabaseInitializer.Initialize()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    INSERT INTO consultation_access_requests (
                        appointment_id, patient_id, patient_name, doctor_name,
                        requested_by_user_id, requested_by_name, reason,
                        status, requested_at
                    ) VALUES (
                        @apptId, @pid, @pname, @docName,
                        @reqUserId, @reqName, @reason,
                        'Pending', datetime('now', 'localtime')
                    );
                    SELECT last_insert_rowid();
                "
                cmd.Parameters.AddWithValue("@apptId", If(appointmentId, "").Trim())
                cmd.Parameters.AddWithValue("@pid", If(patientId, "").Trim())
                cmd.Parameters.AddWithValue("@pname", If(patientName, "").Trim())
                cmd.Parameters.AddWithValue("@docName", If(doctorName, "").Trim())
                cmd.Parameters.AddWithValue("@reqUserId", requestedByUserId)
                cmd.Parameters.AddWithValue("@reqName", If(requestedByName, "").Trim())
                cmd.Parameters.AddWithValue("@reason", If(reason, "").Trim())

                Dim newId = Convert.ToInt32(cmd.ExecuteScalar())
                Return newId
            End Using
        End Using
    End Function

    Public Shared Function GetLatestRequest(appointmentId As String, patientId As String,
                                            requestedByUserId As Integer) As ConsultationAccessRequestRecord
        DatabaseInitializer.Initialize()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    SELECT id, appointment_id, patient_id, patient_name, doctor_name,
                           requested_by_user_id, requested_by_name, reason, status,
                           requested_at, decided_at, decided_by_name, decision_note, expires_at
                    FROM consultation_access_requests
                    WHERE (appointment_id = @apptId OR patient_id = @pid)
                      AND (requested_by_user_id = @uid OR @uid = 0)
                    ORDER BY id DESC
                    LIMIT 1;
                "
                cmd.Parameters.AddWithValue("@apptId", If(appointmentId, "").Trim())
                cmd.Parameters.AddWithValue("@pid", If(patientId, "").Trim())
                cmd.Parameters.AddWithValue("@uid", requestedByUserId)

                Using r = cmd.ExecuteReader()
                    If r.Read() Then
                        Return ReadRecord(r)
                    End If
                End Using
            End Using
        End Using

        Return Nothing
    End Function

    Public Shared Function HasApprovedAccess(appointmentId As String, patientId As String,
                                             requestedByUserId As Integer) As Boolean
        DatabaseInitializer.Initialize()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    SELECT COUNT(*)
                    FROM consultation_access_requests
                    WHERE (appointment_id = @apptId OR patient_id = @pid)
                      AND (requested_by_user_id = @uid OR @uid = 0)
                      AND status = 'Approved'
                      AND (expires_at IS NULL OR expires_at > datetime('now', 'localtime'));
                "
                cmd.Parameters.AddWithValue("@apptId", If(appointmentId, "").Trim())
                cmd.Parameters.AddWithValue("@pid", If(patientId, "").Trim())
                cmd.Parameters.AddWithValue("@uid", requestedByUserId)

                Dim count = Convert.ToInt32(cmd.ExecuteScalar())
                Return count > 0
            End Using
        End Using
    End Function

    Public Shared Function GetPendingRequestsForDoctor(doctorName As String) As List(Of ConsultationAccessRequestRecord)
        DatabaseInitializer.Initialize()
        Dim list As New List(Of ConsultationAccessRequestRecord)()
        If String.IsNullOrWhiteSpace(doctorName) Then Return list

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                Dim cleanName = doctorName.Replace("Dr.", "").Trim()
                Dim sql As String = "
                    SELECT id, appointment_id, patient_id, patient_name, doctor_name,
                           requested_by_user_id, requested_by_name, reason, status,
                           requested_at, decided_at, decided_by_name, decision_note, expires_at
                    FROM consultation_access_requests
                    WHERE status = 'Pending'
                      AND doctor_name LIKE @doc
                    ORDER BY id DESC;
                "
                cmd.Parameters.AddWithValue("@doc", "%" & cleanName & "%")

                cmd.CommandText = sql
                Using r = cmd.ExecuteReader()
                    While r.Read()
                        list.Add(ReadRecord(r))
                    End While
                End Using
            End Using
        End Using

        Return list
    End Function

    Public Shared Function GetPendingCountForDoctor(doctorName As String) As Integer
        DatabaseInitializer.Initialize()
        If String.IsNullOrWhiteSpace(doctorName) Then Return 0

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                Dim cleanName = doctorName.Replace("Dr.", "").Trim()
                Dim sql As String = "SELECT COUNT(*) FROM consultation_access_requests WHERE status = 'Pending' AND doctor_name LIKE @doc;"
                cmd.Parameters.AddWithValue("@doc", "%" & cleanName & "%")

                cmd.CommandText = sql
                Dim count = Convert.ToInt32(cmd.ExecuteScalar())
                Return count
            End Using
        End Using
    End Function

    Public Shared Sub ApproveRequest(requestId As Integer, hoursValid As Integer, doctorName As String, Optional note As String = "")
        DatabaseInitializer.Initialize()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    UPDATE consultation_access_requests
                    SET status = 'Approved',
                        decided_at = datetime('now', 'localtime'),
                        decided_by_name = @docName,
                        decision_note = @note,
                        expires_at = datetime('now', 'localtime', '+' || @hours || ' hours')
                    WHERE id = @id;
                "
                cmd.Parameters.AddWithValue("@id", requestId)
                cmd.Parameters.AddWithValue("@docName", If(doctorName, "").Trim())
                cmd.Parameters.AddWithValue("@note", If(String.IsNullOrWhiteSpace(note), "Approved by attending physician", note.Trim()))
                cmd.Parameters.AddWithValue("@hours", Math.Max(1, hoursValid))
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Shared Sub DeclineRequest(requestId As Integer, doctorName As String, Optional reason As String = "")
        DatabaseInitializer.Initialize()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    UPDATE consultation_access_requests
                    SET status = 'Declined',
                        decided_at = datetime('now', 'localtime'),
                        decided_by_name = @docName,
                        decision_note = @note
                    WHERE id = @id;
                "
                cmd.Parameters.AddWithValue("@id", requestId)
                cmd.Parameters.AddWithValue("@docName", If(doctorName, "").Trim())
                cmd.Parameters.AddWithValue("@note", If(String.IsNullOrWhiteSpace(reason), "Declined due to clinical data privacy policy", reason.Trim()))
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Shared Function ReadRecord(r As SqliteDataReader) As ConsultationAccessRequestRecord
        Return New ConsultationAccessRequestRecord With {
            .Id = Convert.ToInt32(r("id")),
            .AppointmentId = If(Convert.IsDBNull(r("appointment_id")), "", r("appointment_id").ToString()),
            .PatientId = If(Convert.IsDBNull(r("patient_id")), "", r("patient_id").ToString()),
            .PatientName = If(Convert.IsDBNull(r("patient_name")), "", r("patient_name").ToString()),
            .DoctorName = If(Convert.IsDBNull(r("doctor_name")), "", r("doctor_name").ToString()),
            .RequestedByUserId = If(Convert.IsDBNull(r("requested_by_user_id")), 0, Convert.ToInt32(r("requested_by_user_id"))),
            .RequestedByName = If(Convert.IsDBNull(r("requested_by_name")), "", r("requested_by_name").ToString()),
            .Reason = If(Convert.IsDBNull(r("reason")), "", r("reason").ToString()),
            .Status = If(Convert.IsDBNull(r("status")), "Pending", r("status").ToString()),
            .RequestedAt = If(Convert.IsDBNull(r("requested_at")), "", r("requested_at").ToString()),
            .DecidedAt = If(Convert.IsDBNull(r("decided_at")), "", r("decided_at").ToString()),
            .DecidedByName = If(Convert.IsDBNull(r("decided_by_name")), "", r("decided_by_name").ToString()),
            .DecisionNote = If(Convert.IsDBNull(r("decision_note")), "", r("decision_note").ToString()),
            .ExpiresAt = If(Convert.IsDBNull(r("expires_at")), "", r("expires_at").ToString())
        }
    End Function

End Class
