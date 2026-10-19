Imports Microsoft.Data.Sqlite

Public Class SqlitePatientRepository

    Public Shared Function GetAll() As List(Of PatientItem)
        DatabaseInitializer.Initialize()
        Dim list As New List(Of PatientItem)()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    SELECT patient_id, full_name, age, gender, birth_date, contact, email, address,
                           known_conditions, drug_allergies, has_allergies, last_visit_date,
                           last_visit_display, record_updated, upcoming_date, upcoming_details, upcoming_status
                    FROM patients
                    ORDER BY id DESC;
                "
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim p As New PatientItem With {
                            .PatientId = reader.GetString(0),
                            .Name = reader.GetString(1),
                            .Age = reader.GetInt32(2),
                            .Gender = reader.GetString(3),
                            .BirthDate = reader.GetString(4),
                            .Contact = reader.GetString(5),
                            .Email = If(reader.IsDBNull(6), "", reader.GetString(6)),
                            .Address = If(reader.IsDBNull(7), "", reader.GetString(7)),
                            .KnownConditions = If(reader.IsDBNull(8), "", reader.GetString(8)),
                            .DrugAllergies = If(reader.IsDBNull(9), "", reader.GetString(9)),
                            .HasAllergies = (reader.GetInt32(10) = 1),
                            .LastVisitDisplay = If(reader.IsDBNull(12), "", reader.GetString(12)),
                            .RecordUpdated = If(reader.IsDBNull(13), "", reader.GetString(13)),
                            .UpcomingDate = If(reader.IsDBNull(14), "", reader.GetString(14)),
                            .UpcomingDetails = If(reader.IsDBNull(15), "", reader.GetString(15)),
                            .UpcomingStatus = If(reader.IsDBNull(16), "", reader.GetString(16))
                        }
                        If Not reader.IsDBNull(11) Then
                            Date.TryParse(reader.GetString(11), p.LastVisitDate)
                        End If
                        list.Add(p)
                    End While
                End Using
            End Using

            ' Attach visits for each patient
            For Each pat In list
                pat.Visits = GetVisits(conn, pat.PatientId)
            Next
        End Using

        Return list
    End Function

    Public Shared Function GetPatientsForDoctor(doctorName As String) As List(Of PatientItem)
        If String.IsNullOrWhiteSpace(doctorName) Then Return New List(Of PatientItem)()
        DatabaseInitializer.Initialize()
        Dim list As New List(Of PatientItem)()
        Dim docShort = doctorName.Replace("Dr.", "").Trim()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    SELECT patient_id, full_name, age, gender, birth_date, contact, email, address,
                           known_conditions, drug_allergies, has_allergies, last_visit_date,
                           last_visit_display, record_updated, upcoming_date, upcoming_details, upcoming_status
                    FROM patients
                    WHERE patient_id IN (
                        SELECT DISTINCT patient_id FROM appointments 
                        WHERE doctor_name = @doc OR (doctor_name LIKE '%' || @docShort || '%' AND @docShort <> '')
                        UNION
                        SELECT DISTINCT patient_id FROM consultations
                        WHERE doctor_name = @doc OR (doctor_name LIKE '%' || @docShort || '%' AND @docShort <> '')
                    )
                    OR upcoming_details LIKE '%' || @doc || '%'
                    OR (@docShort <> '' AND upcoming_details LIKE '%' || @docShort || '%')
                    ORDER BY id DESC;
                "
                cmd.Parameters.AddWithValue("@doc", doctorName.Trim())
                cmd.Parameters.AddWithValue("@docShort", docShort)

                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim p As New PatientItem With {
                            .PatientId = reader.GetString(0),
                            .Name = reader.GetString(1),
                            .Age = reader.GetInt32(2),
                            .Gender = reader.GetString(3),
                            .BirthDate = reader.GetString(4),
                            .Contact = reader.GetString(5),
                            .Email = If(reader.IsDBNull(6), "", reader.GetString(6)),
                            .Address = If(reader.IsDBNull(7), "", reader.GetString(7)),
                            .KnownConditions = If(reader.IsDBNull(8), "", reader.GetString(8)),
                            .DrugAllergies = If(reader.IsDBNull(9), "", reader.GetString(9)),
                            .HasAllergies = (reader.GetInt32(10) = 1),
                            .LastVisitDisplay = If(reader.IsDBNull(12), "", reader.GetString(12)),
                            .RecordUpdated = If(reader.IsDBNull(13), "", reader.GetString(13)),
                            .UpcomingDate = If(reader.IsDBNull(14), "", reader.GetString(14)),
                            .UpcomingDetails = If(reader.IsDBNull(15), "", reader.GetString(15)),
                            .UpcomingStatus = If(reader.IsDBNull(16), "", reader.GetString(16))
                        }
                        If Not reader.IsDBNull(11) Then
                            Date.TryParse(reader.GetString(11), p.LastVisitDate)
                        End If
                        list.Add(p)
                    End While
                End Using
            End Using

            ' Attach visits for each patient
            For Each pat In list
                pat.Visits = GetVisits(conn, pat.PatientId)
            Next
        End Using

        Return list
    End Function

    Public Shared Function GetById(patientId As String) As PatientItem
        If String.IsNullOrWhiteSpace(patientId) Then Return Nothing
        DatabaseInitializer.Initialize()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    SELECT patient_id, full_name, age, gender, birth_date, contact, email, address,
                           known_conditions, drug_allergies, has_allergies, last_visit_date,
                           last_visit_display, record_updated, upcoming_date, upcoming_details, upcoming_status
                    FROM patients
                    WHERE patient_id = @pid OR full_name = @pid COLLATE NOCASE
                    LIMIT 1;
                "
                cmd.Parameters.AddWithValue("@pid", patientId.Trim())
                Using reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim p As New PatientItem With {
                            .PatientId = reader.GetString(0),
                            .Name = reader.GetString(1),
                            .Age = reader.GetInt32(2),
                            .Gender = reader.GetString(3),
                            .BirthDate = reader.GetString(4),
                            .Contact = reader.GetString(5),
                            .Email = If(reader.IsDBNull(6), "", reader.GetString(6)),
                            .Address = If(reader.IsDBNull(7), "", reader.GetString(7)),
                            .KnownConditions = If(reader.IsDBNull(8), "", reader.GetString(8)),
                            .DrugAllergies = If(reader.IsDBNull(9), "", reader.GetString(9)),
                            .HasAllergies = (reader.GetInt32(10) = 1),
                            .LastVisitDisplay = If(reader.IsDBNull(12), "", reader.GetString(12)),
                            .RecordUpdated = If(reader.IsDBNull(13), "", reader.GetString(13)),
                            .UpcomingDate = If(reader.IsDBNull(14), "", reader.GetString(14)),
                            .UpcomingDetails = If(reader.IsDBNull(15), "", reader.GetString(15)),
                            .UpcomingStatus = If(reader.IsDBNull(16), "", reader.GetString(16))
                        }
                        If Not reader.IsDBNull(11) Then
                            Date.TryParse(reader.GetString(11), p.LastVisitDate)
                        End If
                        p.Visits = GetVisits(conn, p.PatientId)
                        Return p
                    End If
                End Using
            End Using
        End Using

        Return Nothing
    End Function

    Public Shared Sub AddPatient(item As PatientItem)
        If item Is Nothing Then Return
        DatabaseInitializer.Initialize()

        Dim parts = item.Name.Trim().Split(" "c)
        Dim first = parts(0)
        Dim last = If(parts.Length > 1, parts(parts.Length - 1), "")
        Dim mid = If(parts.Length > 2, parts(1), "")

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    INSERT OR REPLACE INTO patients (
                        patient_id, first_name, middle_name, last_name, full_name,
                        age, gender, birth_date, contact, email, address,
                        known_conditions, drug_allergies, has_allergies,
                        last_visit_date, last_visit_display, record_updated,
                        upcoming_date, upcoming_details, upcoming_status
                    ) VALUES (
                        @pid, @fn, @mn, @ln, @name,
                        @age, @gender, @dob, @contact, @email, @address,
                        @conditions, @allergies, @hasAllergies,
                        @lastDate, @lastDisp, @recUpdated,
                        @upDate, @upDet, @upStat
                    );
                "
                DatabaseService.AddParam(cmd, "@pid", If(item.PatientId, ""))
                DatabaseService.AddParam(cmd, "@fn", first)
                DatabaseService.AddParam(cmd, "@mn", mid)
                DatabaseService.AddParam(cmd, "@ln", last)
                DatabaseService.AddParam(cmd, "@name", If(item.Name, ""))
                DatabaseService.AddParam(cmd, "@age", item.Age)
                DatabaseService.AddParam(cmd, "@gender", If(item.Gender, ""))
                DatabaseService.AddParam(cmd, "@dob", If(item.BirthDate, ""))
                DatabaseService.AddParam(cmd, "@contact", If(item.Contact, ""))
                DatabaseService.AddParam(cmd, "@email", If(item.Email, ""))
                DatabaseService.AddParam(cmd, "@address", If(item.Address, ""))
                DatabaseService.AddParam(cmd, "@conditions", If(item.KnownConditions, ""))
                DatabaseService.AddParam(cmd, "@allergies", If(item.DrugAllergies, ""))
                DatabaseService.AddParam(cmd, "@hasAllergies", If(item.HasAllergies, 1, 0))
                DatabaseService.AddParam(cmd, "@lastDate", If(item.LastVisitDate = Date.MinValue, "", item.LastVisitDate.ToString("yyyy-MM-dd")))
                DatabaseService.AddParam(cmd, "@lastDisp", If(item.LastVisitDisplay, ""))
                DatabaseService.AddParam(cmd, "@recUpdated", If(item.RecordUpdated, ""))
                DatabaseService.AddParam(cmd, "@upDate", If(item.UpcomingDate, ""))
                DatabaseService.AddParam(cmd, "@upDet", If(item.UpcomingDetails, ""))
                DatabaseService.AddParam(cmd, "@upStat", If(item.UpcomingStatus, ""))
                cmd.ExecuteNonQuery()
            End Using

            ' If there are any visits provided, insert them
            If item.Visits IsNot Nothing Then
                For Each v In item.Visits
                    AddVisitInternal(conn, item.PatientId, v)
                Next
            End If
        End Using
    End Sub

    Public Shared Sub AddVisit(patientId As String, v As VisitItem)
        If String.IsNullOrWhiteSpace(patientId) OrElse v Is Nothing Then Return
        DatabaseInitializer.Initialize()

        Using conn = DatabaseService.CreateOpenConnection()
            AddVisitInternal(conn, patientId, v)

            ' Update patient's last visit information
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    UPDATE patients
                    SET last_visit_date = @vdate,
                        last_visit_display = @vdisp,
                        record_updated = @recUp,
                        updated_at = datetime('now', 'localtime')
                    WHERE patient_id = @pid;
                "
                DatabaseService.AddParam(cmd, "@pid", patientId)
                DatabaseService.AddParam(cmd, "@vdate", DateTime.Now.ToString("yyyy-MM-dd"))
                DatabaseService.AddParam(cmd, "@vdisp", If(v.VisitDate, ""))
                DatabaseService.AddParam(cmd, "@recUp", "Record updated today at " & DateTime.Now.ToString("h:mm tt"))
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Shared Sub AddVisitInternal(conn As SqliteConnection, patientId As String, v As VisitItem)
        Using cmd = conn.CreateCommand()
            cmd.CommandText = "
                INSERT INTO consultations (patient_id, doctor_name, visit_date, visit_type, diagnosis, status)
                VALUES (@pid, @doc, @vdate, @vtype, @diag, @stat);
            "
            DatabaseService.AddParam(cmd, "@pid", If(patientId, ""))
            DatabaseService.AddParam(cmd, "@doc", If(v.Doctor, ""))
            DatabaseService.AddParam(cmd, "@vdate", If(v.VisitDate, ""))
            DatabaseService.AddParam(cmd, "@vtype", If(v.VisitType, ""))
            DatabaseService.AddParam(cmd, "@diag", If(v.Diagnosis, ""))
            DatabaseService.AddParam(cmd, "@stat", If(v.Status, ""))
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Shared Function GetVisits(conn As SqliteConnection, patientId As String) As List(Of VisitItem)
        Dim visits As New List(Of VisitItem)()
        Using cmd = conn.CreateCommand()
            cmd.CommandText = "
                SELECT visit_date, visit_type, diagnosis, doctor_name, status
                FROM consultations
                WHERE patient_id = @pid
                ORDER BY id DESC;
            "
            cmd.Parameters.AddWithValue("@pid", patientId)
            Using reader = cmd.ExecuteReader()
                While reader.Read()
                    visits.Add(New VisitItem(
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4)
                    ))
                End While
            End Using
        End Using
        Return visits
    End Function

    ''' <summary>
    ''' Checks if a patient with the given phone number already exists (optionally excluding a patient ID).
    ''' </summary>
    Public Shared Function FindDuplicateByPhone(phone As String, Optional excludePatientId As String = Nothing) As PatientItem
        If String.IsNullOrWhiteSpace(phone) Then Return Nothing
        DatabaseInitializer.Initialize()
        Dim cleanPhone = phone.Replace(" ", "").Trim()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    SELECT patient_id, full_name, age, gender, birth_date, contact, email, address,
                           known_conditions, drug_allergies, has_allergies, last_visit_date,
                           last_visit_display, record_updated, upcoming_date, upcoming_details, upcoming_status
                    FROM patients
                    WHERE replace(contact, ' ', '') = @ph
                " & If(Not String.IsNullOrEmpty(excludePatientId), " AND patient_id != @exId", "") & "
                    LIMIT 1;
                "
                cmd.Parameters.AddWithValue("@ph", cleanPhone)
                If Not String.IsNullOrEmpty(excludePatientId) Then
                    cmd.Parameters.AddWithValue("@exId", excludePatientId)
                End If
                Using reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Return New PatientItem With {
                            .PatientId = reader.GetString(0),
                            .Name = reader.GetString(1),
                            .Age = reader.GetInt32(2),
                            .Gender = reader.GetString(3),
                            .BirthDate = reader.GetString(4),
                            .Contact = reader.GetString(5)
                        }
                    End If
                End Using
            End Using
        End Using
        Return Nothing
    End Function

    ''' <summary>
    ''' Checks if an identical patient profile exists matching Name and BirthDate.
    ''' </summary>
    Public Shared Function FindDuplicateProfile(name As String, birthDate As String, Optional excludePatientId As String = Nothing) As PatientItem
        If String.IsNullOrWhiteSpace(name) Then Return Nothing
        DatabaseInitializer.Initialize()
        Dim normName = ValidationHelper.NormalizeProperCase(name)

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    SELECT patient_id, full_name, age, gender, birth_date, contact, email, address,
                           known_conditions, drug_allergies, has_allergies, last_visit_date,
                           last_visit_display, record_updated, upcoming_date, upcoming_details, upcoming_status
                    FROM patients
                    WHERE full_name = @fn COLLATE NOCASE AND birth_date = @bd
                " & If(Not String.IsNullOrEmpty(excludePatientId), " AND patient_id != @exId", "") & "
                    LIMIT 1;
                "
                cmd.Parameters.AddWithValue("@fn", normName)
                cmd.Parameters.AddWithValue("@bd", birthDate.Trim())
                If Not String.IsNullOrEmpty(excludePatientId) Then
                    cmd.Parameters.AddWithValue("@exId", excludePatientId)
                End If
                Using reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Return New PatientItem With {
                            .PatientId = reader.GetString(0),
                            .Name = reader.GetString(1),
                            .Age = reader.GetInt32(2),
                            .Gender = reader.GetString(3),
                            .BirthDate = reader.GetString(4),
                            .Contact = reader.GetString(5)
                        }
                    End If
                End Using
            End Using
        End Using
        Return Nothing
    End Function

End Class
