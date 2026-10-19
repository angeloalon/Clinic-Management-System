Imports Microsoft.Data.Sqlite

Public Class SqliteAppointmentRepository

    Public Shared Function GetAllAppointments() As List(Of AppointmentItem)
        DatabaseInitializer.Initialize()
        Dim list As New List(Of AppointmentItem)()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    SELECT a.day_number, a.start_minutes, a.patient_name, a.patient_id,
                           p.age, p.gender, a.visit_type, a.status, a.reason, a.notes,
                           a.symptoms, a.diagnosis, a.medication, a.advice,
                           a.bp, a.pulse, a.temperature, a.spo2, a.is_draft,
                           a.doctor_name, a.doctor_role, a.appointment_date, a.room_number,
                           COALESCE(a.appointment_id, 'AP-' || a.id) AS appt_id,
                           a.id, COALESCE(a.created_at, '') AS created_at, COALESCE(a.updated_at, '') AS updated_at
                    FROM appointments a
                    LEFT JOIN patients p ON a.patient_id = p.patient_id
                    ORDER BY a.day_number, a.start_minutes;
                "
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim item As New AppointmentItem With {
                            .Day = reader.GetInt32(0),
                            .Minutes = reader.GetInt32(1),
                            .PatientName = reader.GetString(2),
                            .PatientId = reader.GetString(3),
                            .Age = If(reader.IsDBNull(4), 0, reader.GetInt32(4)),
                            .Sex = If(reader.IsDBNull(5), "Unknown", reader.GetString(5)),
                            .VisitType = reader.GetString(6),
                            .Status = reader.GetString(7),
                            .Reason = If(reader.IsDBNull(8), "", reader.GetString(8)),
                            .Note = If(reader.IsDBNull(9), "", reader.GetString(9)),
                            .Symptoms = If(reader.IsDBNull(10), "", reader.GetString(10)),
                            .Diagnosis = If(reader.IsDBNull(11), "", reader.GetString(11)),
                            .Medication = If(reader.IsDBNull(12), "", reader.GetString(12)),
                            .Advice = If(reader.IsDBNull(13), "", reader.GetString(13)),
                            .Bp = If(reader.IsDBNull(14), "", reader.GetString(14)),
                            .Pulse = If(reader.IsDBNull(15), "", reader.GetString(15)),
                            .Temperature = If(reader.IsDBNull(16), "", reader.GetString(16)),
                            .Spo2 = If(reader.IsDBNull(17), "", reader.GetString(17)),
                            .IsDraft = (reader.GetInt32(18) = 1),
                            .DoctorName = reader.GetString(19),
                            .DoctorRole = If(reader.IsDBNull(20), "General Physician", reader.GetString(20)),
                            .AppointmentDate = If(reader.IsDBNull(21), "", reader.GetString(21)),
                            .RoomNumber = If(reader.IsDBNull(22), "Room 101", reader.GetString(22)),
                            .AppointmentId = If(reader.IsDBNull(23), "", reader.GetString(23)),
                            .Id = reader.GetInt32(24),
                            .CreatedAt = If(reader.IsDBNull(25), "", reader.GetString(25)),
                            .UpdatedAt = If(reader.IsDBNull(26), "", reader.GetString(26))
                        }
                        list.Add(item)
                    End While
                End Using
            End Using
        End Using

        Return list
    End Function

    Public Shared Sub AddAppointment(a As AppointmentItem)
        If a Is Nothing Then Return
        DatabaseInitializer.Initialize()

        Dim apptDate = If(Not String.IsNullOrEmpty(a.AppointmentDate), a.AppointmentDate, DateTime.Today.ToString("yyyy-MM-dd"))
        Dim roomNum = If(Not String.IsNullOrEmpty(a.RoomNumber), a.RoomNumber, "Room 101")
        Dim parsedDate As DateTime
        If DateTime.TryParse(apptDate, parsedDate) AndAlso a.Day <= 0 Then
            a.Day = parsedDate.Day
        End If

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    INSERT INTO appointments (
                        patient_id, patient_name, doctor_name, doctor_role,
                        day_number, start_minutes, visit_type, status,
                        reason, notes, symptoms, diagnosis, medication, advice,
                        bp, pulse, temperature, spo2, is_draft, appointment_date, room_number
                    ) VALUES (
                        @pid, @pname, @dname, @drole,
                        @day, @mins, @vtype, @status,
                        @reason, @notes, @symptoms, @diag, @med, @advice,
                        @bp, @pulse, @temp, @spo2, @draft, @adate, @room
                    );
                "
                DatabaseService.AddParam(cmd, "@pid", If(a.PatientId, ""))
                DatabaseService.AddParam(cmd, "@pname", If(a.PatientName, ""))
                DatabaseService.AddParam(cmd, "@dname", If(a.DoctorName, ""))
                DatabaseService.AddParam(cmd, "@drole", If(a.DoctorRole, "General Physician"))
                DatabaseService.AddParam(cmd, "@day", a.Day)
                DatabaseService.AddParam(cmd, "@mins", a.Minutes)
                DatabaseService.AddParam(cmd, "@vtype", If(a.VisitType, "Consultation"))
                DatabaseService.AddParam(cmd, "@status", If(a.Status, "Confirmed"))
                DatabaseService.AddParam(cmd, "@reason", If(a.Reason, ""))
                DatabaseService.AddParam(cmd, "@notes", If(a.Note, ""))
                DatabaseService.AddParam(cmd, "@symptoms", If(a.Symptoms, ""))
                DatabaseService.AddParam(cmd, "@diag", If(a.Diagnosis, ""))
                DatabaseService.AddParam(cmd, "@med", If(a.Medication, ""))
                DatabaseService.AddParam(cmd, "@advice", If(a.Advice, ""))
                DatabaseService.AddParam(cmd, "@bp", If(a.Bp, ""))
                DatabaseService.AddParam(cmd, "@pulse", If(a.Pulse, ""))
                DatabaseService.AddParam(cmd, "@temp", If(a.Temperature, ""))
                DatabaseService.AddParam(cmd, "@spo2", If(a.Spo2, ""))
                DatabaseService.AddParam(cmd, "@draft", If(a.IsDraft, 1, 0))
                DatabaseService.AddParam(cmd, "@adate", apptDate)
                DatabaseService.AddParam(cmd, "@room", roomNum)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Shared Sub UpdateAppointment(a As AppointmentItem)
        If a Is Nothing Then Return
        DatabaseInitializer.Initialize()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    UPDATE appointments
                    SET status = @status,
                        symptoms = @symptoms,
                        diagnosis = @diag,
                        medication = @med,
                        advice = @advice,
                        bp = @bp,
                        pulse = @pulse,
                        temperature = @temp,
                        spo2 = @spo2,
                        is_draft = @draft,
                        notes = @notes,
                        updated_at = datetime('now', 'localtime')
                    WHERE (appointment_id = @aid AND @aid <> '')
                       OR (patient_id = @pid AND (appointment_date = @adate OR day_number = @day) AND start_minutes = @mins);
                "
                DatabaseService.AddParam(cmd, "@status", If(a.Status, "Confirmed"))
                DatabaseService.AddParam(cmd, "@symptoms", If(a.Symptoms, ""))
                DatabaseService.AddParam(cmd, "@diag", If(a.Diagnosis, ""))
                DatabaseService.AddParam(cmd, "@med", If(a.Medication, ""))
                DatabaseService.AddParam(cmd, "@advice", If(a.Advice, ""))
                DatabaseService.AddParam(cmd, "@bp", If(a.Bp, ""))
                DatabaseService.AddParam(cmd, "@pulse", If(a.Pulse, ""))
                DatabaseService.AddParam(cmd, "@temp", If(a.Temperature, ""))
                DatabaseService.AddParam(cmd, "@spo2", If(a.Spo2, ""))
                DatabaseService.AddParam(cmd, "@draft", If(a.IsDraft, 1, 0))
                DatabaseService.AddParam(cmd, "@notes", If(a.Note, ""))
                DatabaseService.AddParam(cmd, "@aid", If(a.AppointmentId, ""))
                DatabaseService.AddParam(cmd, "@pid", If(a.PatientId, ""))
                DatabaseService.AddParam(cmd, "@adate", If(a.AppointmentDate, ""))
                DatabaseService.AddParam(cmd, "@day", a.Day)
                DatabaseService.AddParam(cmd, "@mins", a.Minutes)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Shared Sub RescheduleAppointment(pid As String, oldDay As Integer, oldMins As Integer, newDay As Integer, newMins As Integer, newDoctor As String, newNote As String, Optional newDate As String = "")
        DatabaseInitializer.Initialize()
        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                If Not String.IsNullOrEmpty(newDate) Then
                    cmd.CommandText = "
                        UPDATE appointments
                        SET day_number = @newDay,
                            appointment_date = @newDate,
                            start_minutes = @newMins,
                            doctor_name = @newDoc,
                            notes = @notes,
                            status = 'Confirmed'
                        WHERE patient_id = @pid AND (day_number = @oldDay OR appointment_date LIKE '%' || printf('%02d', @oldDay)) AND start_minutes = @oldMins;
                    "
                    DatabaseService.AddParam(cmd, "@newDate", newDate)
                Else
                    cmd.CommandText = "
                        UPDATE appointments
                        SET day_number = @newDay,
                            start_minutes = @newMins,
                            doctor_name = @newDoc,
                            notes = @notes,
                            status = 'Confirmed'
                        WHERE patient_id = @pid AND day_number = @oldDay AND start_minutes = @oldMins;
                    "
                End If
                DatabaseService.AddParam(cmd, "@newDay", newDay)
                DatabaseService.AddParam(cmd, "@newMins", newMins)
                DatabaseService.AddParam(cmd, "@newDoc", If(newDoctor, "Dr. Elena Cruz"))
                DatabaseService.AddParam(cmd, "@notes", If(newNote, "Rescheduled"))
                DatabaseService.AddParam(cmd, "@pid", pid)
                DatabaseService.AddParam(cmd, "@oldDay", oldDay)
                DatabaseService.AddParam(cmd, "@oldMins", oldMins)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Shared Function GetAllSlots() As List(Of SlotItem)
        DatabaseInitializer.Initialize()
        Dim list As New List(Of SlotItem)()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    SELECT day_number, start_minutes, slot_kind, patient_name, doctor_index
                    FROM schedule_slots
                    ORDER BY day_number, start_minutes;
                "
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        list.Add(New SlotItem With {
                            .Day = reader.GetInt32(0),
                            .Minutes = reader.GetInt32(1),
                            .Kind = reader.GetString(2),
                            .PatientName = If(reader.IsDBNull(3), "", reader.GetString(3)),
                            .DoctorIndex = reader.GetInt32(4)
                        })
                    End While
                End Using
            End Using
        End Using

        Return list
    End Function

    Public Shared Sub AddSlot(slot As SlotItem)
        If slot Is Nothing Then Return
        DatabaseInitializer.Initialize()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    INSERT INTO schedule_slots (day_number, start_minutes, slot_kind, patient_name, doctor_index)
                    VALUES (@day, @mins, @kind, @pname, @docIdx);
                "
                cmd.Parameters.AddWithValue("@day", slot.Day)
                cmd.Parameters.AddWithValue("@mins", slot.Minutes)
                cmd.Parameters.AddWithValue("@kind", slot.Kind)
                cmd.Parameters.AddWithValue("@pname", If(slot.PatientName, ""))
                cmd.Parameters.AddWithValue("@docIdx", slot.DoctorIndex)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Class
