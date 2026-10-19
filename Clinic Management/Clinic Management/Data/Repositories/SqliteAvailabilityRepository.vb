Imports Microsoft.Data.Sqlite

Public Class AvailabilityItem
    Public Property Id As Integer
    Public Property DoctorName As String
    Public Property DoctorRole As String = "General Physician"
    Public Property AvailableDate As String
    Public Property StartMinutes As Integer
    Public Property EndMinutes As Integer
    Public Property Status As String = "Available"
    Public Property IsRecurring As Boolean = False
    Public Property DayOfWeek As Integer = 0
End Class

Public Class SqliteAvailabilityRepository

    Private Structure AvailRecord
        Public Id As Integer
        Public DoctorName As String
        Public DoctorRole As String
        Public AvailableDate As String
        Public StartMinutes As Integer
        Public EndMinutes As Integer
        Public Status As String
        Public IsRecurring As Boolean
        Public DayOfWeek As Integer
    End Structure

    ''' <summary>
    ''' Core engine for inserting, updating, splitting, trimming, or clearing an availability/blocked window.
    ''' When status is non-empty, sets [startMin, endMin) to status.
    ''' When status is empty (""), removes [startMin, endMin) from availability.
    ''' </summary>
    Private Shared Sub ApplyAvailabilityWindow(doctorName As String, targetDate As String, startMin As Integer, endMin As Integer, status As String, isRecurring As Boolean, dayOfWeek As Integer)
        DatabaseInitializer.Initialize()
        Dim dt As DateTime
        DateTime.TryParse(targetDate, dt)
        Dim dow = If(dayOfWeek > 0, dayOfWeek, CInt(dt.DayOfWeek))
        Dim dayNum = dt.Day
        Dim docShort = If(String.IsNullOrEmpty(doctorName), "", doctorName.Replace("Dr.", "").Trim())

        Using conn = DatabaseService.CreateOpenConnection()
            Using tx = conn.BeginTransaction()

                ' 1. If modifying a single specific date and no date-specific records exist yet,
                '    materialize the recurring template for this day so we can safely edit/block individual slots.
                If Not isRecurring AndAlso Not String.IsNullOrEmpty(targetDate) Then
                    Dim hasDateSpecific = False
                    Using chkCmd = conn.CreateCommand()
                        chkCmd.Transaction = tx
                        chkCmd.CommandText = "
                            SELECT COUNT(*) FROM doctor_availability
                            WHERE (doctor_name = @doc OR @doc = '' OR doctor_name LIKE '%' || @docShort || '%')
                              AND is_recurring = 0 AND available_date = @adate;
                        "
                        chkCmd.Parameters.AddWithValue("@doc", doctorName)
                        chkCmd.Parameters.AddWithValue("@docShort", docShort)
                        chkCmd.Parameters.AddWithValue("@adate", targetDate)
                        hasDateSpecific = (Convert.ToInt64(chkCmd.ExecuteScalar()) > 0)
                    End Using

                    If Not hasDateSpecific Then
                        ' Fetch recurring records to materialize
                        Dim recurringRows As New List(Of AvailRecord)()
                        Using recCmd = conn.CreateCommand()
                            recCmd.Transaction = tx
                            recCmd.CommandText = "
                                SELECT doctor_name, doctor_role, start_minutes, end_minutes, status
                                FROM doctor_availability
                                WHERE (doctor_name = @doc OR @doc = '' OR doctor_name LIKE '%' || @docShort || '%')
                                  AND is_recurring = 1 AND day_of_week = @dow;
                            "
                            recCmd.Parameters.AddWithValue("@doc", doctorName)
                            recCmd.Parameters.AddWithValue("@docShort", docShort)
                            recCmd.Parameters.AddWithValue("@dow", dow)
                            Using reader = recCmd.ExecuteReader()
                                While reader.Read()
                                    recurringRows.Add(New AvailRecord With {
                                        .DoctorName = reader.GetString(0),
                                        .DoctorRole = If(reader.IsDBNull(1), "General Physician", reader.GetString(1)),
                                        .StartMinutes = reader.GetInt32(2),
                                        .EndMinutes = reader.GetInt32(3),
                                        .Status = reader.GetString(4)
                                    })
                                End While
                            End Using
                        End Using

                        For Each r In recurringRows
                            Using insCmd = conn.CreateCommand()
                                insCmd.Transaction = tx
                                insCmd.CommandText = "
                                    INSERT INTO doctor_availability (doctor_name, doctor_role, available_date, start_minutes, end_minutes, status, is_recurring, day_of_week)
                                    VALUES (@doc, @role, @adate, @startM, @endM, @status, 0, @dow);
                                "
                                insCmd.Parameters.AddWithValue("@doc", If(String.IsNullOrEmpty(r.DoctorName), doctorName, r.DoctorName))
                                insCmd.Parameters.AddWithValue("@role", r.DoctorRole)
                                insCmd.Parameters.AddWithValue("@adate", targetDate)
                                insCmd.Parameters.AddWithValue("@startM", r.StartMinutes)
                                insCmd.Parameters.AddWithValue("@endM", r.EndMinutes)
                                insCmd.Parameters.AddWithValue("@status", r.Status)
                                insCmd.Parameters.AddWithValue("@dow", dow)
                                insCmd.ExecuteNonQuery()
                            End Using
                        Next
                    End If
                End If

                ' 2. Find all existing rows in the matching scope that overlap with [startMin, endMin)
                Dim overlapping As New List(Of AvailRecord)()
                Using queryCmd = conn.CreateCommand()
                    queryCmd.Transaction = tx
                    If isRecurring Then
                        queryCmd.CommandText = "
                            SELECT id, doctor_name, doctor_role, available_date, start_minutes, end_minutes, status
                            FROM doctor_availability
                            WHERE (doctor_name = @doc OR @doc = '' OR doctor_name LIKE '%' || @docShort || '%')
                              AND is_recurring = 1 AND day_of_week = @dow
                              AND start_minutes < @endM AND end_minutes > @startM;
                        "
                    Else
                        queryCmd.CommandText = "
                            SELECT id, doctor_name, doctor_role, available_date, start_minutes, end_minutes, status
                            FROM doctor_availability
                            WHERE (doctor_name = @doc OR @doc = '' OR doctor_name LIKE '%' || @docShort || '%')
                              AND is_recurring = 0 AND available_date = @adate
                              AND start_minutes < @endM AND end_minutes > @startM;
                        "
                    End If
                    queryCmd.Parameters.AddWithValue("@doc", doctorName)
                    queryCmd.Parameters.AddWithValue("@docShort", docShort)
                    queryCmd.Parameters.AddWithValue("@dow", dow)
                    queryCmd.Parameters.AddWithValue("@adate", targetDate)
                    queryCmd.Parameters.AddWithValue("@startM", startMin)
                    queryCmd.Parameters.AddWithValue("@endM", endMin)

                    Using reader = queryCmd.ExecuteReader()
                        While reader.Read()
                            overlapping.Add(New AvailRecord With {
                                .Id = reader.GetInt32(0),
                                .DoctorName = reader.GetString(1),
                                .DoctorRole = If(reader.IsDBNull(2), "General Physician", reader.GetString(2)),
                                .AvailableDate = If(reader.IsDBNull(3), targetDate, reader.GetString(3)),
                                .StartMinutes = reader.GetInt32(4),
                                .EndMinutes = reader.GetInt32(5),
                                .Status = reader.GetString(6)
                            })
                        End While
                    End Using
                End Using

                ' 3. Process overlapping rows (split, trim, or delete)
                For Each ov In overlapping
                    If ov.StartMinutes < startMin AndAlso ov.EndMinutes > endMin Then
                        ' Strictly encloses [startMin, endMin) -> split into two
                        Using updCmd = conn.CreateCommand()
                            updCmd.Transaction = tx
                            updCmd.CommandText = "UPDATE doctor_availability SET end_minutes = @cut WHERE id = @id;"
                            updCmd.Parameters.AddWithValue("@cut", startMin)
                            updCmd.Parameters.AddWithValue("@id", ov.Id)
                            updCmd.ExecuteNonQuery()
                        End Using

                        Using insCmd = conn.CreateCommand()
                            insCmd.Transaction = tx
                            insCmd.CommandText = "
                                INSERT INTO doctor_availability (doctor_name, doctor_role, available_date, start_minutes, end_minutes, status, is_recurring, day_of_week)
                                VALUES (@doc, @role, @adate, @startM, @endM, @status, @rec, @dow);
                            "
                            insCmd.Parameters.AddWithValue("@doc", ov.DoctorName)
                            insCmd.Parameters.AddWithValue("@role", ov.DoctorRole)
                            insCmd.Parameters.AddWithValue("@adate", ov.AvailableDate)
                            insCmd.Parameters.AddWithValue("@startM", endMin)
                            insCmd.Parameters.AddWithValue("@endM", ov.EndMinutes)
                            insCmd.Parameters.AddWithValue("@status", ov.Status)
                            insCmd.Parameters.AddWithValue("@rec", If(isRecurring, 1, 0))
                            insCmd.Parameters.AddWithValue("@dow", dow)
                            insCmd.ExecuteNonQuery()
                        End Using

                    ElseIf ov.StartMinutes >= startMin AndAlso ov.EndMinutes <= endMin Then
                        ' Entirely inside new window -> delete
                        Using delCmd = conn.CreateCommand()
                            delCmd.Transaction = tx
                            delCmd.CommandText = "DELETE FROM doctor_availability WHERE id = @id;"
                            delCmd.Parameters.AddWithValue("@id", ov.Id)
                            delCmd.ExecuteNonQuery()
                        End Using

                    ElseIf ov.StartMinutes < startMin AndAlso ov.EndMinutes <= endMin Then
                        ' Overlaps start -> trim end
                        Using updCmd = conn.CreateCommand()
                            updCmd.Transaction = tx
                            updCmd.CommandText = "UPDATE doctor_availability SET end_minutes = @cut WHERE id = @id;"
                            updCmd.Parameters.AddWithValue("@cut", startMin)
                            updCmd.Parameters.AddWithValue("@id", ov.Id)
                            updCmd.ExecuteNonQuery()
                        End Using

                    ElseIf ov.StartMinutes >= startMin AndAlso ov.EndMinutes > endMin Then
                        ' Overlaps end -> trim start
                        Using updCmd = conn.CreateCommand()
                            updCmd.Transaction = tx
                            updCmd.CommandText = "UPDATE doctor_availability SET start_minutes = @cut WHERE id = @id;"
                            updCmd.Parameters.AddWithValue("@cut", endMin)
                            updCmd.Parameters.AddWithValue("@id", ov.Id)
                            updCmd.ExecuteNonQuery()
                        End Using
                    End If
                Next

                ' 4. If status is provided (not a deletion), insert the new window
                If Not String.IsNullOrEmpty(status) Then
                    Using insCmd = conn.CreateCommand()
                        insCmd.Transaction = tx
                        insCmd.CommandText = "
                            INSERT INTO doctor_availability (
                                doctor_name, doctor_role, available_date,
                                start_minutes, end_minutes, status, is_recurring, day_of_week
                            ) VALUES (
                                @doc, 'General Physician', @adate,
                                @startM, @endM, @status, @rec, @dow
                            );
                        "
                        insCmd.Parameters.AddWithValue("@doc", doctorName)
                        insCmd.Parameters.AddWithValue("@adate", targetDate)
                        insCmd.Parameters.AddWithValue("@startM", startMin)
                        insCmd.Parameters.AddWithValue("@endM", endMin)
                        insCmd.Parameters.AddWithValue("@status", status)
                        insCmd.Parameters.AddWithValue("@rec", If(isRecurring, 1, 0))
                        insCmd.Parameters.AddWithValue("@dow", dow)
                        insCmd.ExecuteNonQuery()
                    End Using
                End If

                ' 5. Also update schedule_slots to keep legacy views synchronized (protecting existing appointments)
                Dim docIdx = If(doctorName.Contains("Lim"), 1, 0)
                Dim currMin = startMin
                Do While currMin + 30 <= endMin
                    ' Check if an appointment is booked in schedule_slots at this time
                    Dim hasApptInSlot = False
                    Using chkSlot = conn.CreateCommand()
                        chkSlot.Transaction = tx
                        chkSlot.CommandText = "
                            SELECT COUNT(*) FROM schedule_slots
                            WHERE (doctor_name = @doc OR doctor_name LIKE '%' || @docShort || '%' OR @doc = '')
                              AND day_number = @dayNum
                              AND start_minutes = @m
                              AND slot_kind = 'Appointment';
                        "
                        chkSlot.Parameters.AddWithValue("@doc", doctorName)
                        chkSlot.Parameters.AddWithValue("@docShort", docShort)
                        chkSlot.Parameters.AddWithValue("@dayNum", dayNum)
                        chkSlot.Parameters.AddWithValue("@m", currMin)
                        hasApptInSlot = (Convert.ToInt64(chkSlot.ExecuteScalar()) > 0)
                    End Using

                    If Not hasApptInSlot Then
                        Using delSlotCmd = conn.CreateCommand()
                            delSlotCmd.Transaction = tx
                            delSlotCmd.CommandText = "
                                DELETE FROM schedule_slots
                                WHERE (doctor_name = @doc OR doctor_name LIKE '%' || @docShort || '%' OR @doc = '')
                                  AND day_number = @dayNum
                                  AND start_minutes = @m
                                  AND slot_kind <> 'Appointment';
                            "
                            delSlotCmd.Parameters.AddWithValue("@doc", doctorName)
                            delSlotCmd.Parameters.AddWithValue("@docShort", docShort)
                            delSlotCmd.Parameters.AddWithValue("@dayNum", dayNum)
                            delSlotCmd.Parameters.AddWithValue("@m", currMin)
                            delSlotCmd.ExecuteNonQuery()
                        End Using

                        If Not String.IsNullOrEmpty(status) Then
                            Using insSlotCmd = conn.CreateCommand()
                                insSlotCmd.Transaction = tx
                                insSlotCmd.CommandText = "
                                    INSERT INTO schedule_slots (day_number, start_minutes, slot_kind, patient_name, doctor_index, doctor_name)
                                    VALUES (@dayNum, @m, @kind, '', @docIdx, @doc);
                                "
                                insSlotCmd.Parameters.AddWithValue("@dayNum", dayNum)
                                insSlotCmd.Parameters.AddWithValue("@m", currMin)
                                insSlotCmd.Parameters.AddWithValue("@kind", status)
                                insSlotCmd.Parameters.AddWithValue("@docIdx", docIdx)
                                insSlotCmd.Parameters.AddWithValue("@doc", doctorName)
                                insSlotCmd.ExecuteNonQuery()
                            End Using
                        End If
                    End If
                    currMin += 30
                Loop

                tx.Commit()
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Adds a doctor availability window to the database.
    ''' </summary>
    Public Shared Sub AddAvailability(item As AvailabilityItem)
        If item Is Nothing Then Return
        ApplyAvailabilityWindow(item.DoctorName, item.AvailableDate, item.StartMinutes, item.EndMinutes, item.Status, item.IsRecurring, item.DayOfWeek)
    End Sub

    ''' <summary>
    ''' Updates the status of a specific 30-min slot (Available -> Blocked or Blocked -> Available).
    ''' </summary>
    Public Shared Sub UpdateSlotStatus(doctorName As String, slotDate As String, startMinutes As Integer, newStatus As String)
        ApplyAvailabilityWindow(doctorName, slotDate, startMinutes, startMinutes + 30, newStatus, False, 0)
    End Sub

    ''' <summary>
    ''' Deletes an availability slot completely from the database.
    ''' </summary>
    Public Shared Sub DeleteSlot(doctorName As String, slotDate As String, startMinutes As Integer)
        ApplyAvailabilityWindow(doctorName, slotDate, startMinutes, startMinutes + 30, "", False, 0)
    End Sub

    ''' <summary>
    ''' Retrieves distinct doctors who currently have availability records.
    ''' </summary>
    Public Shared Function GetAvailableDoctors() As List(Of String)
        DatabaseInitializer.Initialize()
        Dim list As New List(Of String)()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    SELECT DISTINCT doctor_name FROM doctor_availability
                    WHERE status = 'Available'
                    ORDER BY doctor_name ASC;
                "
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        list.Add(reader.GetString(0))
                    End While
                End Using
            End Using
        End Using

        If list.Count = 0 Then
            ' Fallback to active staff doctors if no availability rows entered yet
            Using conn = DatabaseService.CreateOpenConnection()
                Using cmd = conn.CreateCommand()
                    cmd.CommandText = "SELECT name FROM staff_accounts WHERE role = 'Doctor' AND status = 'Active' ORDER BY name ASC;"
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            list.Add(reader.GetString(0))
                        End While
                    End Using
                End Using
            End Using
        End If

        Return list
    End Function

    ''' <summary>
    ''' Checks if a doctor is available on a specific date (YYYY-MM-DD).
    ''' </summary>
    Public Shared Function IsDoctorAvailableOnDate(doctorName As String, dateStr As String) As Boolean
        DatabaseInitializer.Initialize()
        Dim d As DateTime
        DateTime.TryParse(dateStr, d)
        Dim dow As Integer = CInt(d.DayOfWeek)

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    SELECT COUNT(*) FROM doctor_availability
                    WHERE (doctor_name = @doc OR @doc = '' OR @doc = 'All Doctors')
                      AND status = 'Available'
                      AND (available_date = @adate OR (is_recurring = 1 AND day_of_week = @dow));
                "
                cmd.Parameters.AddWithValue("@doc", doctorName)
                cmd.Parameters.AddWithValue("@adate", dateStr)
                cmd.Parameters.AddWithValue("@dow", dow)
                Dim count = Convert.ToInt64(cmd.ExecuteScalar())
                Return count > 0
            End Using
        End Using
    End Function

    ''' <summary>
    ''' Retrieves available time slots (in minutes from midnight) for a doctor on a specific date,
    ''' excluding time slots that are already booked in the appointments table.
    ''' </summary>
    Public Shared Function GetAvailableTimeSlots(doctorName As String, dateStr As String, Optional slotDuration As Integer = 30) As List(Of Integer)
        DatabaseInitializer.Initialize()
        Dim slots As New SortedSet(Of Integer)()
        Dim dt As DateTime
        DateTime.TryParse(dateStr, dt)
        Dim dow As Integer = CInt(dt.DayOfWeek)
        Dim docShort = If(String.IsNullOrEmpty(doctorName), "", doctorName.Replace("Dr.", "").Trim())

        Using conn = DatabaseService.CreateOpenConnection()
            ' 1. Retrieve all recurring availability intervals for this day of week
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    SELECT start_minutes, end_minutes FROM doctor_availability
                    WHERE (doctor_name = @doc OR @doc = '' OR doctor_name LIKE '%' || @docShort || '%')
                      AND status = 'Available'
                      AND is_recurring = 1 AND day_of_week = @dow;
                "
                cmd.Parameters.AddWithValue("@doc", doctorName)
                cmd.Parameters.AddWithValue("@docShort", docShort)
                cmd.Parameters.AddWithValue("@dow", dow)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim startM = reader.GetInt32(0)
                        Dim endM = reader.GetInt32(1)
                        Dim curr = startM
                        Do While curr + slotDuration <= endM
                            slots.Add(curr)
                            curr += slotDuration
                        Loop
                    End While
                End Using
            End Using

            ' 2. Retrieve date-specific available intervals (if any date-specific available rows exist, add them)
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    SELECT start_minutes, end_minutes FROM doctor_availability
                    WHERE (doctor_name = @doc OR @doc = '' OR doctor_name LIKE '%' || @docShort || '%')
                      AND status = 'Available'
                      AND is_recurring = 0 AND available_date = @adate;
                "
                cmd.Parameters.AddWithValue("@doc", doctorName)
                cmd.Parameters.AddWithValue("@docShort", docShort)
                cmd.Parameters.AddWithValue("@adate", dateStr)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim startM = reader.GetInt32(0)
                        Dim endM = reader.GetInt32(1)
                        Dim curr = startM
                        Do While curr + slotDuration <= endM
                            slots.Add(curr)
                            curr += slotDuration
                        Loop
                    End While
                End Using
            End Using

            ' Fallback to standard hours if no availability recorded at all
            If slots.Count = 0 AndAlso dow <> 0 Then
                Dim defaultStart = 8 * 60   ' 8:00 AM
                Dim defaultEnd = If(dow = 6, 12 * 60, 17 * 60) ' Sat until 12pm, Mon-Fri until 5pm
                Dim curr = defaultStart
                Do While curr + slotDuration <= defaultEnd
                    slots.Add(curr)
                    curr += slotDuration
                Loop
            End If

            ' 3. Subtract any BLOCKED intervals on this date or recurring
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    SELECT start_minutes, end_minutes FROM doctor_availability
                    WHERE (doctor_name = @doc OR @doc = '' OR doctor_name LIKE '%' || @docShort || '%')
                      AND status = 'Blocked'
                      AND (available_date = @adate OR (is_recurring = 1 AND day_of_week = @dow));
                "
                cmd.Parameters.AddWithValue("@doc", doctorName)
                cmd.Parameters.AddWithValue("@docShort", docShort)
                cmd.Parameters.AddWithValue("@adate", dateStr)
                cmd.Parameters.AddWithValue("@dow", dow)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim bStart = reader.GetInt32(0)
                        Dim bEnd = reader.GetInt32(1)
                        Dim curr = bStart
                        Do While curr < bEnd
                            slots.Remove(curr)
                            curr += slotDuration
                        Loop
                    End While
                End Using
            End Using

            ' 4. Subtract already booked appointments for this doctor OR room on this date
            Dim targetRoom = ReceptionistAppointment.GetDoctorRoom(doctorName)
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    SELECT start_minutes FROM appointments
                    WHERE ((doctor_name = @doc OR @doc = '') OR (room_number = @room AND @room <> ''))
                      AND (appointment_date = @adate OR day_number = @dayNum)
                      AND status IN ('Confirmed', 'Pending');
                "
                cmd.Parameters.AddWithValue("@doc", doctorName)
                cmd.Parameters.AddWithValue("@room", targetRoom)
                cmd.Parameters.AddWithValue("@adate", dateStr)
                cmd.Parameters.AddWithValue("@dayNum", dt.Day)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim bookedMin = reader.GetInt32(0)
                        slots.Remove(bookedMin)
                    End While
                End Using
            End Using
        End Using

        Return slots.ToList()
    End Function

    ''' <summary>
    ''' Gets all availability records for a doctor.
    ''' </summary>
    Public Shared Function GetAvailabilityForDoctor(doctorName As String) As List(Of AvailabilityItem)
        DatabaseInitializer.Initialize()
        Dim list As New List(Of AvailabilityItem)()

        Using conn = DatabaseService.CreateOpenConnection()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "
                    SELECT id, doctor_name, doctor_role, available_date, start_minutes, end_minutes, status, is_recurring, day_of_week
                    FROM doctor_availability
                    WHERE doctor_name = @doc OR @doc = ''
                    ORDER BY available_date ASC, start_minutes ASC;
                "
                cmd.Parameters.AddWithValue("@doc", doctorName)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        list.Add(New AvailabilityItem With {
                            .Id = reader.GetInt32(0),
                            .DoctorName = reader.GetString(1),
                            .DoctorRole = reader.GetString(2),
                            .AvailableDate = reader.GetString(3),
                            .StartMinutes = reader.GetInt32(4),
                            .EndMinutes = reader.GetInt32(5),
                            .Status = reader.GetString(6),
                            .IsRecurring = (reader.GetInt32(7) = 1),
                            .DayOfWeek = If(reader.IsDBNull(8), 0, reader.GetInt32(8))
                        })
                    End While
                End Using
            End Using
        End Using

        Return list
    End Function

    ''' <summary>
    ''' Retrieves all availability and schedule slots for a doctor during a specific week.
    ''' </summary>
    Public Shared Function GetSlotsForDoctor(doctorName As String, weekMonday As DateTime, Optional dayCount As Integer = 5) As List(Of SlotItem)
        DatabaseInitializer.Initialize()
        Dim list As New List(Of SlotItem)()
        Dim docShort = If(String.IsNullOrEmpty(doctorName), "", doctorName.Replace("Dr.", "").Trim())

        Using conn = DatabaseService.CreateOpenConnection()
            For d As Integer = 0 To dayCount - 1
                Dim colDate = weekMonday.AddDays(d).Date
                Dim dateStr = colDate.ToString("yyyy-MM-dd")
                Dim dow = CInt(colDate.DayOfWeek)
                Dim daySlots As New Dictionary(Of Integer, SlotItem)()

                ' 1. Check if recurring availability exists for this day of week (Baseline)
                Using cmd = conn.CreateCommand()
                    cmd.CommandText = "
                        SELECT start_minutes, end_minutes, status
                        FROM doctor_availability
                        WHERE (doctor_name = @doc OR (doctor_name LIKE '%' || @docShort || '%' AND @docShort <> ''))
                          AND is_recurring = 1 AND day_of_week = @dow
                        ORDER BY start_minutes ASC;
                    "
                    cmd.Parameters.AddWithValue("@doc", doctorName)
                    cmd.Parameters.AddWithValue("@docShort", docShort)
                    cmd.Parameters.AddWithValue("@dow", dow)
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim startM = reader.GetInt32(0)
                            Dim endM = reader.GetInt32(1)
                            Dim stat = reader.GetString(2)
                            Dim curr = startM
                            Do While curr < endM
                                daySlots(curr) = New SlotItem With {
                                    .SlotDate = dateStr,
                                    .Day = colDate.Day,
                                    .Minutes = curr,
                                    .DurationMinutes = 30,
                                    .Kind = stat,
                                    .DoctorName = doctorName
                                }
                                curr += 30
                            Loop
                        End While
                    End Using
                End Using

                ' 2. Date-specific records for this exact date (OVERRIDE baseline)
                Using cmd = conn.CreateCommand()
                    cmd.CommandText = "
                        SELECT start_minutes, end_minutes, status
                        FROM doctor_availability
                        WHERE (doctor_name = @doc OR (doctor_name LIKE '%' || @docShort || '%' AND @docShort <> ''))
                          AND is_recurring = 0 AND available_date = @adate
                        ORDER BY start_minutes ASC;
                    "
                    cmd.Parameters.AddWithValue("@doc", doctorName)
                    cmd.Parameters.AddWithValue("@docShort", docShort)
                    cmd.Parameters.AddWithValue("@adate", dateStr)
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim startM = reader.GetInt32(0)
                            Dim endM = reader.GetInt32(1)
                            Dim stat = reader.GetString(2)
                            Dim curr = startM
                            Do While curr < endM
                                daySlots(curr) = New SlotItem With {
                                    .SlotDate = dateStr,
                                    .Day = colDate.Day,
                                    .Minutes = curr,
                                    .DurationMinutes = 30,
                                    .Kind = stat,
                                    .DoctorName = doctorName
                                }
                                curr += 30
                            Loop
                        End While
                    End Using
                End Using

                ' 3. Legacy/mockup schedule_slots fallback if daySlots is empty
                ' Only match legacy seeded doctors Cruz (docIdx 0) and Lim (docIdx 1) when rowDoc is unspecified
                If daySlots.Count = 0 Then
                    Using cmd = conn.CreateCommand()
                        cmd.CommandText = "
                            SELECT start_minutes, slot_kind, patient_name, doctor_index, doctor_name
                            FROM schedule_slots
                            WHERE day_number = @dayNum
                            ORDER BY start_minutes;
                        "
                        cmd.Parameters.AddWithValue("@dayNum", colDate.Day)
                        Using reader = cmd.ExecuteReader()
                            While reader.Read()
                                Dim mins = reader.GetInt32(0)
                                Dim kind = reader.GetString(1)
                                Dim pname = If(reader.IsDBNull(2), "", reader.GetString(2))
                                Dim docIdx = reader.GetInt32(3)
                                Dim rowDoc = If(reader.IsDBNull(4), "", reader.GetString(4))

                                Dim matchesDoctor = False
                                If Not String.IsNullOrWhiteSpace(rowDoc) Then
                                    If rowDoc.Equals(doctorName, StringComparison.OrdinalIgnoreCase) OrElse (Not String.IsNullOrEmpty(docShort) AndAlso rowDoc.IndexOf(docShort, StringComparison.OrdinalIgnoreCase) >= 0) Then
                                        matchesDoctor = True
                                    End If
                                Else
                                    ' Legacy seed slots: only attach if doctor name specifically matches Cruz or Lim
                                    If doctorName.IndexOf("Cruz", StringComparison.OrdinalIgnoreCase) >= 0 AndAlso docIdx = 0 Then
                                        matchesDoctor = True
                                    ElseIf doctorName.IndexOf("Lim", StringComparison.OrdinalIgnoreCase) >= 0 AndAlso docIdx = 1 Then
                                        matchesDoctor = True
                                    End If
                                End If

                                If matchesDoctor Then
                                    daySlots(mins) = New SlotItem With {
                                        .SlotDate = dateStr,
                                        .Day = colDate.Day,
                                        .Minutes = mins,
                                        .DurationMinutes = 30,
                                        .Kind = kind,
                                        .PatientName = pname,
                                        .DoctorIndex = docIdx,
                                        .DoctorName = doctorName
                                    }
                                End If
                            End While
                        End Using
                    End Using
                End If

                For Each s In daySlots.Values.OrderBy(Function(x) x.Minutes)
                    list.Add(s)
                Next
            Next
        End Using

        Return list.OrderBy(Function(s) s.Minutes).ToList()
    End Function

End Class
