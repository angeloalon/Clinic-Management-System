Imports Microsoft.Data.Sqlite

Public Class PrescriptionAccessRequestRecord
    Public Property Id As Integer
    Public Property PrescriptionId As Integer
    Public Property PrescriptionCode As String
    Public Property PatientId As String
    Public Property PatientName As String
    Public Property RequestedByUserId As Integer
    Public Property RequestedByName As String
    Public Property DoctorId As Integer
    Public Property DoctorName As String
    Public Property Reason As String
    Public Property Status As String ' Pending, Approved, Denied, Expired, Revoked, Used
    Public Property RequestedAt As String
    Public Property DecidedAt As String
    Public Property DecisionNote As String
    Public Property AccessType As String ' view_once, time_limited
    Public Property ExpiresAt As String
    Public Property AllowPrint As Boolean
End Class

Public Class SqlitePrescriptionAccessRepository

    ''' <summary>
    ''' Submits a new time-limited prescription access request from a receptionist/staff member to a doctor.
    ''' </summary>
    Public Shared Function CreateRequest(patientId As String, requestedByUserId As Integer, doctorId As Integer, reason As String, Optional prescriptionId As Integer = 0) As Integer
        DatabaseInitializer.Initialize()

        ' If prescriptionId is 0, find latest prescription for the patient
        Using conn = DatabaseService.CreateOpenConnection()
            If prescriptionId <= 0 Then
                Using cmdFind = conn.CreateCommand()
                    cmdFind.CommandText = "SELECT id FROM prescriptions WHERE patient_id = @pid ORDER BY id DESC LIMIT 1;"
                    cmdFind.Parameters.AddWithValue("@pid", patientId)
                    Dim obj = cmdFind.ExecuteScalar()
                    If obj IsNot Nothing AndAlso Not Convert.IsDBNull(obj) Then
                        prescriptionId = Convert.ToInt32(obj)
                    Else
                        prescriptionId = 1 ' Fallback placeholder
                    End If
                End Using
            End If

            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    INSERT INTO prescription_access_requests (
                        prescription_id, patient_id, requested_by_user_id, doctor_id,
                        reason, status, requested_at
                    ) VALUES (
                        @rxId, @pid, @reqUserId, @docId,
                        @reason, 'Pending', datetime('now', 'localtime')
                    );
                    SELECT last_insert_rowid();
                "
                cmd.Parameters.AddWithValue("@rxId", prescriptionId)
                cmd.Parameters.AddWithValue("@pid", patientId)
                cmd.Parameters.AddWithValue("@reqUserId", requestedByUserId)
                cmd.Parameters.AddWithValue("@docId", doctorId)
                cmd.Parameters.AddWithValue("@reason", If(reason, "").Trim())

                Dim newId = Convert.ToInt32(cmd.ExecuteScalar())
                Return newId
            End Using
        End Using
    End Function

    ''' <summary>
    ''' Checks whether the given user has active, unexpired, approved access to view the patient's prescription.
    ''' </summary>
    Public Shared Function HasActiveAccessForPatient(patientId As String, userId As Integer) As Boolean
        If String.IsNullOrWhiteSpace(patientId) Then Return False
        DatabaseInitializer.Initialize()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    SELECT COUNT(*)
                    FROM prescription_access_requests
                    WHERE patient_id = @pid
                      AND requested_by_user_id = @uid
                      AND status = 'Approved'
                      AND (expires_at IS NULL OR expires_at > datetime('now', 'localtime'))
                      AND revoked_at IS NULL;
                "
                cmd.Parameters.AddWithValue("@pid", patientId.Trim())
                cmd.Parameters.AddWithValue("@uid", userId)

                Dim count = Convert.ToInt32(cmd.ExecuteScalar())
                Return count > 0
            End Using
        End Using
    End Function

    ''' <summary>
    ''' Gets count of pending access requests awaiting review for a specific doctor (or all doctors if doctorId is 0).
    ''' </summary>
    Public Shared Function GetPendingCountForDoctor(doctorId As Integer) As Integer
        DatabaseInitializer.Initialize()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                Dim sql = "SELECT COUNT(*) FROM prescription_access_requests WHERE status = 'Pending'"
                If doctorId > 0 Then
                    sql &= " AND (doctor_id = @docId OR doctor_id = 0)"
                    cmd.Parameters.AddWithValue("@docId", doctorId)
                End If
                cmd.CommandText = sql & ";"
                Return Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        End Using
    End Function

    ''' <summary>
    ''' Retrieves all pending access requests for doctor review.
    ''' </summary>
    Public Shared Function GetPendingRequestsForDoctor(doctorId As Integer) As List(Of PrescriptionAccessRequestRecord)
        DatabaseInitializer.Initialize()
        Dim list As New List(Of PrescriptionAccessRequestRecord)()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                Dim sql = "
                    SELECT r.id, r.prescription_id, COALESCE(p.prescription_code, 'RX-GENERAL'),
                           r.patient_id, COALESCE(pat.full_name, r.patient_id),
                           r.requested_by_user_id, COALESCE(st.name, 'Staff Member'),
                           r.doctor_id, COALESCE(doc.name, 'Attending Doctor'),
                           r.reason, r.status, r.requested_at, r.decided_at, r.decision_note,
                           r.access_type, r.expires_at, r.allow_print
                    FROM prescription_access_requests r
                    LEFT JOIN prescriptions p ON r.prescription_id = p.id
                    LEFT JOIN patients pat ON r.patient_id = pat.patient_id
                    LEFT JOIN staff_accounts st ON r.requested_by_user_id = st.id
                    LEFT JOIN staff_accounts doc ON r.doctor_id = doc.id
                    WHERE r.status = 'Pending'
                "
                If doctorId > 0 Then
                    sql &= " AND (r.doctor_id = @docId OR r.doctor_id = 0)"
                    cmd.Parameters.AddWithValue("@docId", doctorId)
                End If
                sql &= " ORDER BY r.id DESC;"

                cmd.CommandText = sql
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        list.Add(New PrescriptionAccessRequestRecord With {
                            .Id = reader.GetInt32(0),
                            .PrescriptionId = reader.GetInt32(1),
                            .PrescriptionCode = reader.GetString(2),
                            .PatientId = reader.GetString(3),
                            .PatientName = reader.GetString(4),
                            .RequestedByUserId = reader.GetInt32(5),
                            .RequestedByName = reader.GetString(6),
                            .DoctorId = reader.GetInt32(7),
                            .DoctorName = reader.GetString(8),
                            .Reason = reader.GetString(9),
                            .Status = reader.GetString(10),
                            .RequestedAt = reader.GetString(11),
                            .DecidedAt = If(reader.IsDBNull(12), "", reader.GetString(12)),
                            .DecisionNote = If(reader.IsDBNull(13), "", reader.GetString(13)),
                            .AccessType = If(reader.IsDBNull(14), "", reader.GetString(14)),
                            .ExpiresAt = If(reader.IsDBNull(15), "", reader.GetString(15)),
                            .AllowPrint = (reader.GetInt32(16) = 1)
                        })
                    End While
                End Using
            End Using
        End Using

        Return list
    End Function

    ''' <summary>
    ''' Approves a prescription access request with a time window (e.g. 2 hours).
    ''' </summary>
    Public Shared Sub ApproveRequest(requestId As Integer, hoursValid As Integer, allowPrint As Boolean, Optional note As String = "Approved by doctor")
        DatabaseInitializer.Initialize()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    UPDATE prescription_access_requests
                    SET status = 'Approved',
                        decided_at = datetime('now', 'localtime'),
                        access_type = 'time_limited',
                        expires_at = datetime('now', '+' || @hrs || ' hours', 'localtime'),
                        allow_print = @allowPrint,
                        decision_note = @note
                    WHERE id = @reqId;
                "
                cmd.Parameters.AddWithValue("@hrs", Math.Max(hoursValid, 1))
                cmd.Parameters.AddWithValue("@allowPrint", If(allowPrint, 1, 0))
                cmd.Parameters.AddWithValue("@note", If(note, "Approved"))
                cmd.Parameters.AddWithValue("@reqId", requestId)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Denies a prescription access request.
    ''' </summary>
    Public Shared Sub DenyRequest(requestId As Integer, Optional note As String = "Denied by doctor")
        DatabaseInitializer.Initialize()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    UPDATE prescription_access_requests
                    SET status = 'Denied',
                        decided_at = datetime('now', 'localtime'),
                        decision_note = @note
                    WHERE id = @reqId;
                "
                cmd.Parameters.AddWithValue("@note", If(note, "Denied"))
                cmd.Parameters.AddWithValue("@reqId", requestId)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Revokes a previously approved prescription access request.
    ''' </summary>
    Public Shared Sub RevokeRequest(requestId As Integer)
        DatabaseInitializer.Initialize()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    UPDATE prescription_access_requests
                    SET status = 'Revoked',
                        revoked_at = datetime('now', 'localtime')
                    WHERE id = @reqId;
                "
                cmd.Parameters.AddWithValue("@reqId", requestId)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Class
