Imports System.IO
Imports Microsoft.Data.Sqlite

Public Class DatabaseInitializer

    Private Shared _isInitialized As Boolean = False
    Private Shared ReadOnly _initLock As New Object()

    Public Shared Sub Initialize()
        If _isInitialized Then Return

        SyncLock _initLock
            If _isInitialized Then Return

            Using conn = DatabaseService.CreateOpenConnection()
                Using tx = conn.BeginTransaction()
                    CreateTables(conn, tx)
                    CreateIndexes(conn, tx)
                    SeedInitialData(conn, tx)
                    tx.Commit()
                End Using
            End Using

            _isInitialized = True
        End SyncLock
    End Sub

    Public Shared Sub ResetInitialization()
        SyncLock _initLock
            _isInitialized = False
        End SyncLock
    End Sub

    Private Shared Sub CreateTables(conn As SqliteConnection, tx As SqliteTransaction)
        Dim ddl As String = "
            CREATE TABLE IF NOT EXISTS clinic_settings (
                id INTEGER PRIMARY KEY CHECK (id = 1),
                clinic_name TEXT NOT NULL DEFAULT 'UCC Health Clinic',
                clinic_type TEXT NOT NULL DEFAULT 'General practice',
                address TEXT NOT NULL DEFAULT 'Health Clinic, Caloocan City',
                contact TEXT NOT NULL DEFAULT '(02) 8555 0142',
                email TEXT NOT NULL DEFAULT 'clinic@uccclinic.edu.ph',
                appt_minutes INTEGER NOT NULL DEFAULT 30,
                updated_at TEXT NOT NULL DEFAULT (datetime('now', 'localtime'))
            );

            CREATE TABLE IF NOT EXISTS staff_accounts (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                email TEXT NOT NULL COLLATE NOCASE UNIQUE,
                name TEXT NOT NULL,
                role TEXT NOT NULL CHECK(role IN ('Doctor', 'Receptionist', 'Administrator')),
                status TEXT NOT NULL DEFAULT 'Active' CHECK(status IN ('Active', 'Invited', 'On leave', 'Suspended')),
                password_hash TEXT NULL,
                password_salt TEXT NULL,
                clinic TEXT NOT NULL DEFAULT 'UCC Health Clinic',
                invite_code TEXT NULL,
                failed_attempts INTEGER NOT NULL DEFAULT 0,
                locked_until TEXT NULL,
                last_active TEXT NULL,
                is_archived INTEGER NOT NULL DEFAULT 0,
                archived_at TEXT NULL,
                created_at TEXT NOT NULL DEFAULT (datetime('now', 'localtime'))
            );

            CREATE TABLE IF NOT EXISTS patients (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                patient_id TEXT NOT NULL COLLATE NOCASE UNIQUE,
                first_name TEXT NOT NULL,
                middle_name TEXT NULL,
                last_name TEXT NOT NULL,
                full_name TEXT NOT NULL COLLATE NOCASE,
                age INTEGER NOT NULL,
                gender TEXT NOT NULL,
                birth_date TEXT NOT NULL,
                contact TEXT NOT NULL,
                email TEXT NULL,
                address TEXT NOT NULL,
                known_conditions TEXT NULL,
                drug_allergies TEXT NULL,
                has_allergies INTEGER NOT NULL DEFAULT 0,
                last_visit_date TEXT NULL,
                last_visit_display TEXT NULL,
                record_updated TEXT NULL,
                upcoming_date TEXT NULL,
                upcoming_details TEXT NULL,
                upcoming_status TEXT NULL,
                created_at TEXT NOT NULL DEFAULT (datetime('now', 'localtime')),
                updated_at TEXT NOT NULL DEFAULT (datetime('now', 'localtime'))
            );

            CREATE TABLE IF NOT EXISTS appointments (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                appointment_id TEXT UNIQUE,
                patient_id TEXT NOT NULL REFERENCES patients(patient_id) ON DELETE RESTRICT,
                patient_name TEXT NOT NULL,
                doctor_id INTEGER NULL REFERENCES staff_accounts(id),
                doctor_name TEXT NOT NULL,
                doctor_role TEXT NOT NULL DEFAULT 'General Physician',
                day_number INTEGER NOT NULL,
                start_minutes INTEGER NOT NULL,
                duration_minutes INTEGER NOT NULL DEFAULT 30,
                visit_type TEXT NOT NULL,
                status TEXT NOT NULL,
                reason TEXT NULL,
                notes TEXT NULL,
                symptoms TEXT NULL,
                diagnosis TEXT NULL,
                medication TEXT NULL,
                advice TEXT NULL,
                bp TEXT NULL,
                pulse TEXT NULL,
                temperature TEXT NULL,
                spo2 TEXT NULL,
                is_draft INTEGER NOT NULL DEFAULT 0,
                room_number TEXT NOT NULL DEFAULT 'Room 101',
                created_at TEXT NOT NULL DEFAULT (datetime('now', 'localtime'))
            );

            CREATE TABLE IF NOT EXISTS consultations (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                consultation_id TEXT UNIQUE,
                appointment_id INTEGER NULL REFERENCES appointments(id),
                patient_id TEXT NOT NULL REFERENCES patients(patient_id) ON DELETE RESTRICT,
                doctor_name TEXT NOT NULL,
                visit_date TEXT NOT NULL DEFAULT (datetime('now', 'localtime')),
                visit_type TEXT NOT NULL,
                symptoms TEXT NULL,
                diagnosis TEXT NOT NULL,
                medication_notes TEXT NULL,
                advice TEXT NULL,
                bp TEXT NULL,
                pulse TEXT NULL,
                temperature TEXT NULL,
                spo2 TEXT NULL,
                status TEXT NOT NULL DEFAULT 'Completed',
                created_at TEXT NOT NULL DEFAULT (datetime('now', 'localtime'))
            );

            CREATE TABLE IF NOT EXISTS prescriptions (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                prescription_code TEXT UNIQUE,
                consultation_id INTEGER NULL REFERENCES consultations(id),
                patient_id TEXT NOT NULL REFERENCES patients(patient_id),
                doctor_name TEXT NOT NULL,
                medication_text TEXT NOT NULL,
                advice_text TEXT NULL,
                allergy_warning TEXT NULL,
                created_at TEXT NOT NULL DEFAULT (datetime('now', 'localtime'))
            );

            CREATE TABLE IF NOT EXISTS lab_requests (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                request_code TEXT UNIQUE,
                consultation_id INTEGER NULL REFERENCES consultations(id),
                patient_id TEXT NOT NULL REFERENCES patients(patient_id),
                doctor_name TEXT NOT NULL,
                diagnosis TEXT NULL,
                ordered_tests_json TEXT NOT NULL,
                status TEXT NOT NULL DEFAULT 'Pending',
                created_at TEXT NOT NULL DEFAULT (datetime('now', 'localtime'))
            );

            CREATE TABLE IF NOT EXISTS schedule_slots (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                day_number INTEGER NOT NULL,
                start_minutes INTEGER NOT NULL,
                slot_kind TEXT NOT NULL,
                patient_name TEXT NULL,
                doctor_index INTEGER NOT NULL DEFAULT 0,
                doctor_name TEXT NULL
            );

            CREATE TABLE IF NOT EXISTS doctor_availability (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                doctor_id INTEGER NULL REFERENCES staff_accounts(id),
                doctor_name TEXT NOT NULL,
                doctor_role TEXT NOT NULL DEFAULT 'General Physician',
                available_date TEXT NOT NULL,
                start_minutes INTEGER NOT NULL,
                end_minutes INTEGER NOT NULL,
                status TEXT NOT NULL DEFAULT 'Available',
                is_recurring INTEGER NOT NULL DEFAULT 0,
                day_of_week INTEGER NULL,
                created_at TEXT NOT NULL DEFAULT (datetime('now', 'localtime'))
            );

            CREATE TABLE IF NOT EXISTS psgc_geographic (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                region_name TEXT NOT NULL,
                province_name TEXT NOT NULL,
                city_name TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS audit_logs (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                log_time TEXT NOT NULL DEFAULT (datetime('now', 'localtime')),
                user_name TEXT NOT NULL,
                role TEXT NOT NULL,
                action TEXT NOT NULL,
                details TEXT NULL,
                result TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS consultation_access_requests (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                appointment_id TEXT NOT NULL,
                patient_id TEXT NOT NULL,
                patient_name TEXT NOT NULL,
                doctor_name TEXT NOT NULL,
                requested_by_user_id INTEGER NOT NULL DEFAULT 0,
                requested_by_name TEXT NOT NULL,
                reason TEXT NOT NULL,
                status TEXT NOT NULL DEFAULT 'Pending' CHECK(status IN ('Pending', 'Approved', 'Declined', 'Expired')),
                requested_at TEXT NOT NULL DEFAULT (datetime('now', 'localtime')),
                decided_at TEXT NULL,
                decided_by_name TEXT NULL,
                decision_note TEXT NULL,
                expires_at TEXT NULL
            );
        "

        Using cmd = conn.CreateCommand()
            cmd.Transaction = tx
            cmd.CommandText = ddl
            cmd.ExecuteNonQuery()
        End Using

        ' Safe schema migrations for existing database files
        EnsureColumn(conn, tx, "appointments", "appointment_date", "TEXT NULL")
        EnsureColumn(conn, tx, "appointments", "room_number", "TEXT NOT NULL DEFAULT 'Room 101'")
        EnsureColumn(conn, tx, "appointments", "updated_at", "TEXT NULL")
        EnsureColumn(conn, tx, "staff_accounts", "is_archived", "INTEGER NOT NULL DEFAULT 0")
        EnsureColumn(conn, tx, "staff_accounts", "archived_at", "TEXT NULL")
        Using updCmd = conn.CreateCommand()
            updCmd.Transaction = tx
            updCmd.CommandText = "
                UPDATE appointments SET appointment_date = printf('2026-09-%02d', day_number) WHERE appointment_date IS NULL OR appointment_date = '';
                UPDATE appointments SET room_number = CASE
                    WHEN doctor_name LIKE '%Cruz%' THEN 'Room 101'
                    WHEN doctor_name LIKE '%Lim%' THEN 'Room 102'
                    WHEN doctor_name LIKE '%Vega%' THEN 'Room 103'
                    WHEN doctor_name LIKE '%Bautista%' OR doctor_name LIKE '%salas%' THEN 'Room 104'
                    ELSE 'Room 105'
                END WHERE room_number IS NULL OR room_number = '' OR room_number = 'Room 101';
            "
            updCmd.ExecuteNonQuery()
        End Using

        ' Ensure Diana Dina and Dr. Marco Lim exist in staff accounts
        EnsureStaffAccount(conn, tx, "Diana Dina", "diana.dina@uccclinic.edu.ph", "Receptionist", "Active", "Today, 8:30 AM", "receptionist123")
        EnsureStaffAccount(conn, tx, "Dr. Marco Lim", "marco.lim@uccclinic.edu.ph", "Doctor", "Active", "Today, 9:00 AM", "doctor123")

        ' Ensure the current active week has populated appointments so the live view is never blank
        EnsureActiveWeekAppointments(conn, tx)

        ' Normalize all patient and appointment names to Proper Case
        NormalizeExistingPatientNames(conn, tx)
    End Sub

    Private Shared Sub NormalizeExistingPatientNames(conn As SqliteConnection, tx As SqliteTransaction)
        Dim patientsToFix As New List(Of (Id As Long, Name As String))()
        Using cmd = conn.CreateCommand()
            cmd.Transaction = tx
            cmd.CommandText = "SELECT id, full_name FROM patients;"
            Using reader = cmd.ExecuteReader()
                While reader.Read()
                    Dim idVal = reader.GetInt64(0)
                    Dim nameVal = reader.GetString(1)
                    Dim fixedName = ValidationHelper.NormalizeProperCase(nameVal)
                    If fixedName <> nameVal Then
                        patientsToFix.Add((idVal, fixedName))
                    End If
                End While
            End Using
        End Using

        For Each item In patientsToFix
            Using upd = conn.CreateCommand()
                upd.Transaction = tx
                upd.CommandText = "UPDATE patients SET full_name = @n WHERE id = @id;"
                upd.Parameters.AddWithValue("@n", item.Name)
                upd.Parameters.AddWithValue("@id", item.Id)
                upd.ExecuteNonQuery()
            End Using
        Next

        Dim apptsToFix As New List(Of (Id As Long, Name As String))()
        Using cmd = conn.CreateCommand()
            cmd.Transaction = tx
            cmd.CommandText = "SELECT id, patient_name FROM appointments;"
            Using reader = cmd.ExecuteReader()
                While reader.Read()
                    Dim idVal = reader.GetInt64(0)
                    Dim nameVal = reader.GetString(1)
                    Dim fixedName = ValidationHelper.NormalizeProperCase(nameVal)
                    If fixedName <> nameVal Then
                        apptsToFix.Add((idVal, fixedName))
                    End If
                End While
            End Using
        End Using

        For Each item In apptsToFix
            Using upd = conn.CreateCommand()
                upd.Transaction = tx
                upd.CommandText = "UPDATE appointments SET patient_name = @n WHERE id = @id;"
                upd.Parameters.AddWithValue("@n", item.Name)
                upd.Parameters.AddWithValue("@id", item.Id)
                upd.ExecuteNonQuery()
            End Using
        Next
    End Sub

    Private Shared Sub EnsureStaffAccount(conn As SqliteConnection, tx As SqliteTransaction, name As String, email As String, role As String, status As String, lastActive As String, pass As String)
        Using chk = conn.CreateCommand()
            chk.Transaction = tx
            chk.CommandText = "SELECT COUNT(*) FROM staff_accounts WHERE email = @email;"
            chk.Parameters.AddWithValue("@email", email)
            Dim cnt = Convert.ToInt64(chk.ExecuteScalar())
            If cnt = 0 Then
                Dim salt = SecurityHelper.GenerateSalt()
                Dim hash = SecurityHelper.HashPassword(pass, salt)
                Using ins = conn.CreateCommand()
                    ins.Transaction = tx
                    ins.CommandText = "
                        INSERT INTO staff_accounts (name, email, role, status, last_active, password_hash, password_salt, invite_code)
                        VALUES (@name, @email, @role, @status, @lastActive, @hash, @salt, '');
                    "
                    ins.Parameters.AddWithValue("@name", name)
                    ins.Parameters.AddWithValue("@email", email)
                    ins.Parameters.AddWithValue("@role", role)
                    ins.Parameters.AddWithValue("@status", status)
                    ins.Parameters.AddWithValue("@lastActive", lastActive)
                    ins.Parameters.AddWithValue("@hash", hash)
                    ins.Parameters.AddWithValue("@salt", salt)
                    ins.ExecuteNonQuery()
                End Using
            End If
        End Using
    End Sub

    Private Shared Sub EnsureActiveWeekAppointments(conn As SqliteConnection, tx As SqliteTransaction)
        Dim today = DateTime.Today
        Dim diff = (7 + (CInt(today.DayOfWeek) - CInt(DayOfWeek.Monday))) Mod 7
        Dim monday = today.AddDays(-diff)
        Dim friday = monday.AddDays(4)
        Dim monStr = monday.ToString("yyyy-MM-dd")
        Dim friStr = friday.ToString("yyyy-MM-dd")

        Using chk = conn.CreateCommand()
            chk.Transaction = tx
            chk.CommandText = "SELECT COUNT(*) FROM appointments WHERE appointment_date >= @monStr AND appointment_date <= @friStr;"
            chk.Parameters.AddWithValue("@monStr", monStr)
            chk.Parameters.AddWithValue("@friStr", friStr)
            Dim cnt = Convert.ToInt64(chk.ExecuteScalar())
            If cnt = 0 Then
                Dim weekAppts = {
                    (monday, 540, "Maria Santos", "PT-1048", "Dr. Elena Cruz", "General Physician", "Follow-up", "Completed", "Asthma evaluation", "Room 101"),
                    (monday.AddDays(1), 570, "Ana Villanueva", "PT-1028", "Dr. Elena Cruz", "General Physician", "Consultation", "Confirmed", "Routine glucose check", "Room 101"),
                    (monday.AddDays(1), 630, "Joshua Reyes", "PT-1051", "Dr. Elena Cruz", "General Physician", "Consultation", "Pending", "BP check and routine exam", "Room 101"),
                    (monday.AddDays(1), 840, "Carlos Mendoza", "PT-1065", "Dr. Marco Lim", "General Physician", "Check-up", "Confirmed", "Gastric discomfort follow-up", "Room 102"),
                    (monday.AddDays(2), 570, "Lea Mendoza", "PT-1057", "Dr. Elena Cruz", "General Physician", "Check-up", "Confirmed", "General wellness evaluation", "Room 101"),
                    (monday.AddDays(2), 660, "Roberto Diaz", "PT-1033", "Dr. Elena Cruz", "General Physician", "Follow-up", "Confirmed", "Lower back pain follow-up", "Room 101"),
                    (monday.AddDays(3), 540, "Teresa Ramos", "PT-1070", "Dr. Elena Cruz", "General Physician", "Consultation", "Confirmed", "Headache and vertigo assessment", "Room 101"),
                    (monday.AddDays(3), 795, "Gabriel Cruz", "PT-1074", "Dr. Elena Cruz", "General Physician", "Follow-up", "Confirmed", "Periodic uric acid review", "Room 101"),
                    (monday.AddDays(4), 930, "Roberto Diaz", "PT-1033", "Dr. Elena Cruz", "General Physician", "Follow-up", "Pending", "Spine evaluation progress", "Room 101"),
                    (monday.AddDays(4), 840, "Carlos Mendoza", "PT-1065", "Dr. Marco Lim", "General Physician", "Check-up", "Confirmed", "Sports physical follow-up", "Room 102")
                }

                For Each a In weekAppts
                    Using cmd = conn.CreateCommand()
                        cmd.Transaction = tx
                        cmd.CommandText = "
                            INSERT INTO appointments (
                                patient_id, patient_name, doctor_name, doctor_role,
                                day_number, start_minutes, visit_type, status,
                                reason, notes, symptoms, diagnosis, medication, advice,
                                bp, pulse, temperature, spo2, is_draft, appointment_date, room_number
                            ) VALUES (
                                @pid, @pname, @dname, @drole,
                                @day, @mins, @vtype, @status,
                                @reason, @notes, '', '', '', '',
                                '120/80', '72 bpm', '36.5 °C', '98%', 0, @adate, @room
                            );
                        "
                        cmd.Parameters.AddWithValue("@pid", a.Item4)
                        cmd.Parameters.AddWithValue("@pname", a.Item3)
                        cmd.Parameters.AddWithValue("@dname", a.Item5)
                        cmd.Parameters.AddWithValue("@drole", a.Item6)
                        cmd.Parameters.AddWithValue("@day", a.Item1.Day)
                        cmd.Parameters.AddWithValue("@mins", a.Item2)
                        cmd.Parameters.AddWithValue("@vtype", a.Item7)
                        cmd.Parameters.AddWithValue("@status", a.Item8)
                        cmd.Parameters.AddWithValue("@reason", a.Item9)
                        cmd.Parameters.AddWithValue("@notes", "")
                        cmd.Parameters.AddWithValue("@adate", a.Item1.ToString("yyyy-MM-dd"))
                        cmd.Parameters.AddWithValue("@room", a.Item10)
                        cmd.ExecuteNonQuery()
                    End Using
                Next
            End If
        End Using
    End Sub

    Private Shared Sub EnsureColumn(conn As SqliteConnection, tx As SqliteTransaction, table As String, col As String, colDef As String)
        Using chk = conn.CreateCommand()
            chk.Transaction = tx
            chk.CommandText = $"PRAGMA table_info({table});"
            Using r = chk.ExecuteReader()
                While r.Read()
                    If String.Equals(r.GetString(1), col, StringComparison.OrdinalIgnoreCase) Then
                        Return
                    End If
                End While
            End Using
        End Using

        Using alterCmd = conn.CreateCommand()
            alterCmd.Transaction = tx
            alterCmd.CommandText = $"ALTER TABLE {table} ADD COLUMN {col} {colDef};"
            alterCmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Shared Sub CreateIndexes(conn As SqliteConnection, tx As SqliteTransaction)
        Dim indexDdl As String = "
            CREATE INDEX IF NOT EXISTS idx_staff_email ON staff_accounts(email);
            CREATE INDEX IF NOT EXISTS idx_staff_role ON staff_accounts(role);
            CREATE INDEX IF NOT EXISTS idx_staff_archived ON staff_accounts(is_archived);
            CREATE INDEX IF NOT EXISTS idx_patients_pid ON patients(patient_id);
            CREATE INDEX IF NOT EXISTS idx_patients_name ON patients(full_name);
            CREATE INDEX IF NOT EXISTS idx_patients_contact ON patients(contact);
            CREATE INDEX IF NOT EXISTS idx_appt_day_status ON appointments(day_number, status);
            CREATE INDEX IF NOT EXISTS idx_appt_patient ON appointments(patient_id);
            CREATE INDEX IF NOT EXISTS idx_appt_doctor ON appointments(doctor_name);
            CREATE INDEX IF NOT EXISTS idx_consult_patient ON consultations(patient_id, visit_date DESC);
            CREATE INDEX IF NOT EXISTS idx_slots_day_doc ON schedule_slots(day_number, doctor_index);
            CREATE INDEX IF NOT EXISTS idx_audit_time ON audit_logs(log_time DESC);
            CREATE INDEX IF NOT EXISTS idx_doc_avail_date ON doctor_availability(doctor_name, available_date);
            CREATE INDEX IF NOT EXISTS idx_psgc_province ON psgc_geographic(province_name);
            CREATE INDEX IF NOT EXISTS idx_consult_req_doc ON consultation_access_requests(doctor_name, status);
            CREATE INDEX IF NOT EXISTS idx_consult_req_appt ON consultation_access_requests(appointment_id, patient_id);
        "

        Using cmd = conn.CreateCommand()
            cmd.Transaction = tx
            cmd.CommandText = indexDdl
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Shared Sub SeedInitialData(conn As SqliteConnection, tx As SqliteTransaction)
        SeedClinicSettings(conn, tx)
        SeedStaff(conn, tx)
        SeedPatients(conn, tx)
        SeedAppointments(conn, tx)
        SeedSlots(conn, tx)
        SeedDoctorAvailability(conn, tx)
        SeedPsgcData(conn, tx)
        SeedAudit(conn, tx)
    End Sub

    Private Shared Sub SeedClinicSettings(conn As SqliteConnection, tx As SqliteTransaction)
        Using chk = conn.CreateCommand()
            chk.Transaction = tx
            chk.CommandText = "SELECT COUNT(*) FROM clinic_settings;"
            Dim cnt = Convert.ToInt64(chk.ExecuteScalar())
            If cnt = 0 Then
                Using cmd = conn.CreateCommand()
                    cmd.Transaction = tx
                    cmd.CommandText = "
                        INSERT INTO clinic_settings (id, clinic_name, clinic_type, address, contact, email, appt_minutes)
                        VALUES (1, 'UCC Health Clinic', 'General practice', 'Health Clinic, Caloocan City', '(02) 8555 0142', 'clinic@uccclinic.edu.ph', 30);
                    "
                    cmd.ExecuteNonQuery()
                End Using
            End If
        End Using
    End Sub

    Private Shared Sub SeedStaff(conn As SqliteConnection, tx As SqliteTransaction)
        Using chk = conn.CreateCommand()
            chk.Transaction = tx
            chk.CommandText = "SELECT COUNT(*) FROM staff_accounts;"
            Dim cnt = Convert.ToInt64(chk.ExecuteScalar())
            If cnt = 0 Then
                Dim defaultAccounts = {
                    ("Dr. Elena Cruz", "elena.cruz@uccclinic.edu.ph", "Doctor", "Active", "Today, 9:12 AM", "doctor123", ""),
                    ("Dr. Marco Lim", "marco.lim@uccclinic.edu.ph", "Doctor", "Active", "Today, 9:00 AM", "doctor123", ""),
                    ("Dr. Paolo Vega", "paolo.vega@uccclinic.edu.ph", "Doctor", "Active", "Yesterday", "doctor123", ""),
                    ("Dr. Lorna Bautista", "lorna.bautista@uccclinic.edu.ph", "Doctor", "On leave", "Sep 24", "doctor123", ""),
                    ("Ana Reyes", "ana.reyes@uccclinic.edu.ph", "Receptionist", "Active", "Today, 8:47 AM", "receptionist123", ""),
                    ("Diana Dina", "diana.dina@uccclinic.edu.ph", "Receptionist", "Active", "Today, 8:30 AM", "receptionist123", ""),
                    ("Mark Tolentino", "mark.tolentino@uccclinic.edu.ph", "Receptionist", "Invited", "—", "receptionist123", "T9XK-4M2P"),
                    ("Rosa Dela Cruz", "rosa.delacruz@uccclinic.edu.ph", "Administrator", "Active", "Just now", "admin123", ""),
                    ("Joel Ramos", "joel.ramos@uccclinic.edu.ph", "Receptionist", "Suspended", "Aug 30", "receptionist123", "")
                }

                For Each acc In defaultAccounts
                    Dim salt = SecurityHelper.GenerateSalt()
                    Dim hash = SecurityHelper.HashPassword(acc.Item6, salt)

                    Using cmd = conn.CreateCommand()
                        cmd.Transaction = tx
                        cmd.CommandText = "
                            INSERT INTO staff_accounts (name, email, role, status, last_active, password_hash, password_salt, invite_code)
                            VALUES (@name, @email, @role, @status, @lastActive, @hash, @salt, @code);
                        "
                        cmd.Parameters.AddWithValue("@name", acc.Item1)
                        cmd.Parameters.AddWithValue("@email", acc.Item2)
                        cmd.Parameters.AddWithValue("@role", acc.Item3)
                        cmd.Parameters.AddWithValue("@status", acc.Item4)
                        cmd.Parameters.AddWithValue("@lastActive", acc.Item5)
                        cmd.Parameters.AddWithValue("@hash", hash)
                        cmd.Parameters.AddWithValue("@salt", salt)
                        cmd.Parameters.AddWithValue("@code", acc.Item7)
                        cmd.ExecuteNonQuery()
                    End Using
                Next
            End If
        End Using
    End Sub

    Private Shared Sub SeedPatients(conn As SqliteConnection, tx As SqliteTransaction)
        Using chk = conn.CreateCommand()
            chk.Transaction = tx
            chk.CommandText = "SELECT COUNT(*) FROM patients;"
            Dim cnt = Convert.ToInt64(chk.ExecuteScalar())
            If cnt = 0 Then
                Dim baselinePatients = PatientRepository.InitializeMockPatients()
                For Each p In baselinePatients
                    Dim parts = p.Name.Split(" "c)
                    Dim first = parts(0)
                    Dim last = If(parts.Length > 1, parts(parts.Length - 1), "")
                    Dim mid = If(parts.Length > 2, parts(1), "")

                    Using cmd = conn.CreateCommand()
                        cmd.Transaction = tx
                        cmd.CommandText = "
                            INSERT INTO patients (
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
                        cmd.Parameters.AddWithValue("@pid", p.PatientId)
                        cmd.Parameters.AddWithValue("@fn", first)
                        cmd.Parameters.AddWithValue("@mn", mid)
                        cmd.Parameters.AddWithValue("@ln", last)
                        cmd.Parameters.AddWithValue("@name", p.Name)
                        cmd.Parameters.AddWithValue("@age", p.Age)
                        cmd.Parameters.AddWithValue("@gender", p.Gender)
                        cmd.Parameters.AddWithValue("@dob", p.BirthDate)
                        cmd.Parameters.AddWithValue("@contact", p.Contact)
                        cmd.Parameters.AddWithValue("@email", If(p.Email, ""))
                        cmd.Parameters.AddWithValue("@address", p.Address)
                        cmd.Parameters.AddWithValue("@conditions", If(p.KnownConditions, ""))
                        cmd.Parameters.AddWithValue("@allergies", If(p.DrugAllergies, ""))
                        cmd.Parameters.AddWithValue("@hasAllergies", If(p.HasAllergies, 1, 0))
                        cmd.Parameters.AddWithValue("@lastDate", p.LastVisitDate.ToString("yyyy-MM-dd"))
                        cmd.Parameters.AddWithValue("@lastDisp", If(p.LastVisitDisplay, ""))
                        cmd.Parameters.AddWithValue("@recUpdated", If(p.RecordUpdated, ""))
                        cmd.Parameters.AddWithValue("@upDate", If(p.UpcomingDate, ""))
                        cmd.Parameters.AddWithValue("@upDet", If(p.UpcomingDetails, ""))
                        cmd.Parameters.AddWithValue("@upStat", If(p.UpcomingStatus, ""))
                        cmd.ExecuteNonQuery()
                    End Using

                    ' Also seed their past visits as consultations
                    For Each v In p.Visits
                        Using vcmd = conn.CreateCommand()
                            vcmd.Transaction = tx
                            vcmd.CommandText = "
                                INSERT INTO consultations (patient_id, doctor_name, visit_date, visit_type, diagnosis, status)
                                VALUES (@pid, @doc, @vdate, @vtype, @diag, @stat);
                            "
                            vcmd.Parameters.AddWithValue("@pid", p.PatientId)
                            vcmd.Parameters.AddWithValue("@doc", v.Doctor)
                            vcmd.Parameters.AddWithValue("@vdate", v.VisitDate)
                            vcmd.Parameters.AddWithValue("@vtype", v.VisitType)
                            vcmd.Parameters.AddWithValue("@diag", v.Diagnosis)
                            vcmd.Parameters.AddWithValue("@stat", v.Status)
                            vcmd.ExecuteNonQuery()
                        End Using
                    Next
                Next
            End If
        End Using
    End Sub

    Private Shared Sub SeedAppointments(conn As SqliteConnection, tx As SqliteTransaction)
        Using chk = conn.CreateCommand()
            chk.Transaction = tx
            chk.CommandText = "SELECT COUNT(*) FROM appointments;"
            Dim cnt = Convert.ToInt64(chk.ExecuteScalar())
            If cnt = 0 Then
                Dim appts = ClinicData.InitializeAppointments()
                For Each a In appts
                    Using cmd = conn.CreateCommand()
                        cmd.Transaction = tx
                        cmd.CommandText = "
                            INSERT INTO appointments (
                                patient_id, patient_name, doctor_name, doctor_role,
                                day_number, start_minutes, visit_type, status,
                                reason, notes, symptoms, diagnosis, medication, advice,
                                bp, pulse, temperature, spo2, is_draft
                            ) VALUES (
                                @pid, @pname, @dname, @drole,
                                @day, @mins, @vtype, @status,
                                @reason, @notes, @symptoms, @diag, @med, @advice,
                                @bp, @pulse, @temp, @spo2, @draft
                            );
                        "
                        cmd.Parameters.AddWithValue("@pid", a.PatientId)
                        cmd.Parameters.AddWithValue("@pname", a.PatientName)
                        cmd.Parameters.AddWithValue("@dname", a.DoctorName)
                        cmd.Parameters.AddWithValue("@drole", If(a.DoctorRole, "General Physician"))
                        cmd.Parameters.AddWithValue("@day", a.Day)
                        cmd.Parameters.AddWithValue("@mins", a.Minutes)
                        cmd.Parameters.AddWithValue("@vtype", a.VisitType)
                        cmd.Parameters.AddWithValue("@status", a.Status)
                        cmd.Parameters.AddWithValue("@reason", If(a.Reason, ""))
                        cmd.Parameters.AddWithValue("@notes", If(a.Note, ""))
                        cmd.Parameters.AddWithValue("@symptoms", If(a.Symptoms, ""))
                        cmd.Parameters.AddWithValue("@diag", If(a.Diagnosis, ""))
                        cmd.Parameters.AddWithValue("@med", If(a.Medication, ""))
                        cmd.Parameters.AddWithValue("@advice", If(a.Advice, ""))
                        cmd.Parameters.AddWithValue("@bp", If(a.Bp, ""))
                        cmd.Parameters.AddWithValue("@pulse", If(a.Pulse, ""))
                        cmd.Parameters.AddWithValue("@temp", If(a.Temperature, ""))
                        cmd.Parameters.AddWithValue("@spo2", If(a.Spo2, ""))
                        cmd.Parameters.AddWithValue("@draft", If(a.IsDraft, 1, 0))
                        cmd.ExecuteNonQuery()
                    End Using
                Next
            End If
        End Using
    End Sub

    Private Shared Sub SeedSlots(conn As SqliteConnection, tx As SqliteTransaction)
        Using chk = conn.CreateCommand()
            chk.Transaction = tx
            chk.CommandText = "SELECT COUNT(*) FROM schedule_slots;"
            Dim cnt = Convert.ToInt64(chk.ExecuteScalar())
            If cnt = 0 Then
                Dim slots = ClinicData.InitializeSlots()
                For Each s In slots
                    Using cmd = conn.CreateCommand()
                        cmd.Transaction = tx
                        cmd.CommandText = "
                            INSERT INTO schedule_slots (day_number, start_minutes, slot_kind, patient_name, doctor_index)
                            VALUES (@day, @mins, @kind, @pname, @docIdx);
                        "
                        cmd.Parameters.AddWithValue("@day", s.Day)
                        cmd.Parameters.AddWithValue("@mins", s.Minutes)
                        cmd.Parameters.AddWithValue("@kind", s.Kind)
                        cmd.Parameters.AddWithValue("@pname", If(s.PatientName, ""))
                        cmd.Parameters.AddWithValue("@docIdx", s.DoctorIndex)
                        cmd.ExecuteNonQuery()
                    End Using
                Next
            End If
        End Using
    End Sub

    Private Shared Sub SeedAudit(conn As SqliteConnection, tx As SqliteTransaction)
        Using chk = conn.CreateCommand()
            chk.Transaction = tx
            chk.CommandText = "SELECT COUNT(*) FROM audit_logs;"
            Dim cnt = Convert.ToInt64(chk.ExecuteScalar())
            If cnt = 0 Then
                Dim t As DateTime = DateTime.Today
                Dim baselineLogs = {
                    (t.AddHours(9).AddMinutes(12), "Elena Cruz", "Doctor", "Availability updated", "Tuesday slots changed to 9 AM – 12 PM", "Success"),
                    (t.AddHours(8).AddMinutes(47), "Ana Reyes", "Receptionist", "Appointments booked", "8 appointments created", "Success"),
                    (t.AddDays(-1).AddHours(16).AddMinutes(5), "Rosa Dela Cruz", "Administrator", "User created", "Mark Tolentino (Receptionist)", "Success"),
                    (t.AddDays(-1).AddHours(15).AddMinutes(40), "Rosa Dela Cruz", "Administrator", "Password reset", "Dr. Paolo Vega", "Success"),
                    (t.AddDays(-1).AddHours(15).AddMinutes(12), "Rosa Dela Cruz", "Administrator", "Record access blocked", "Admins cannot open clinical notes", "Denied"),
                    (t.AddDays(-2).AddHours(10).AddMinutes(15), "Rosa Dela Cruz", "Administrator", "Clinic hours edited", "All Saints' Day closure added", "Success"),
                    (t.AddDays(-3).AddHours(7).AddMinutes(58), "ana.reyes", "Unknown", "Sign-in attempt", "Incorrect password (2 of 5 tries)", "Failed"),
                    (t.AddDays(-3).AddHours(7).AddMinutes(59), "Ana Reyes", "Receptionist", "Sign-in", "Succeeded on retry", "Success")
                }

                For Each log In baselineLogs
                    Using cmd = conn.CreateCommand()
                        cmd.Transaction = tx
                        cmd.CommandText = "
                            INSERT INTO audit_logs (log_time, user_name, role, action, details, result)
                            VALUES (@time, @user, @role, @action, @details, @result);
                        "
                        cmd.Parameters.AddWithValue("@time", log.Item1.ToString("yyyy-MM-dd HH:mm:ss"))
                        cmd.Parameters.AddWithValue("@user", log.Item2)
                        cmd.Parameters.AddWithValue("@role", log.Item3)
                        cmd.Parameters.AddWithValue("@action", log.Item4)
                        cmd.Parameters.AddWithValue("@details", log.Item5)
                        cmd.Parameters.AddWithValue("@result", log.Item6)
                        cmd.ExecuteNonQuery()
                    End Using
                Next
            End If
        End Using
    End Sub

    Private Shared Sub SeedDoctorAvailability(conn As SqliteConnection, tx As SqliteTransaction)
        Using chk = conn.CreateCommand()
            chk.Transaction = tx
            chk.CommandText = "SELECT COUNT(*) FROM doctor_availability;"
            Dim cnt = Convert.ToInt64(chk.ExecuteScalar())
            If cnt = 0 Then
                Dim today = DateTime.Today
                Dim initialAvail = {
                    ("Dr. Elena Cruz", "General Physician", today.ToString("yyyy-MM-dd"), 480, 1020, 1, CInt(today.DayOfWeek)),
                    ("Dr. Elena Cruz", "General Physician", today.AddDays(1).ToString("yyyy-MM-dd"), 480, 1020, 1, CInt(today.AddDays(1).DayOfWeek)),
                    ("Dr. Elena Cruz", "General Physician", today.AddDays(2).ToString("yyyy-MM-dd"), 480, 1020, 1, CInt(today.AddDays(2).DayOfWeek)),
                    ("Dr. Marco Lim", "General Physician", today.ToString("yyyy-MM-dd"), 540, 1020, 1, CInt(today.DayOfWeek)),
                    ("Dr. Marco Lim", "General Physician", today.AddDays(1).ToString("yyyy-MM-dd"), 540, 1020, 1, CInt(today.AddDays(1).DayOfWeek)),
                    ("Dr. Paolo Vega", "General Physician", today.ToString("yyyy-MM-dd"), 480, 960, 1, CInt(today.DayOfWeek)),
                    ("Dr. Paolo Vega", "General Physician", today.AddDays(2).ToString("yyyy-MM-dd"), 480, 960, 1, CInt(today.AddDays(2).DayOfWeek))
                }

                For Each a In initialAvail
                    Using cmd = conn.CreateCommand()
                        cmd.Transaction = tx
                        cmd.CommandText = "
                            INSERT INTO doctor_availability (doctor_name, doctor_role, available_date, start_minutes, end_minutes, status, is_recurring, day_of_week)
                            VALUES (@doc, @role, @adate, @startM, @endM, 'Available', @rec, @dow);
                        "
                        cmd.Parameters.AddWithValue("@doc", a.Item1)
                        cmd.Parameters.AddWithValue("@role", a.Item2)
                        cmd.Parameters.AddWithValue("@adate", a.Item3)
                        cmd.Parameters.AddWithValue("@startM", a.Item4)
                        cmd.Parameters.AddWithValue("@endM", a.Item5)
                        cmd.Parameters.AddWithValue("@rec", a.Item6)
                        cmd.Parameters.AddWithValue("@dow", a.Item7)
                        cmd.ExecuteNonQuery()
                    End Using
                Next
            End If
        End Using
    End Sub

    Private Shared Sub SeedPsgcData(conn As SqliteConnection, tx As SqliteTransaction)
        Using chk = conn.CreateCommand()
            chk.Transaction = tx
            chk.CommandText = "SELECT COUNT(*) FROM psgc_geographic;"
            Dim cnt = Convert.ToInt64(chk.ExecuteScalar())
            If cnt = 0 Then
                Dim geoData = {
                    ("National Capital Region (NCR)", "Metro Manila", "Caloocan City"),
                    ("National Capital Region (NCR)", "Metro Manila", "Quezon City"),
                    ("National Capital Region (NCR)", "Metro Manila", "Manila"),
                    ("National Capital Region (NCR)", "Metro Manila", "Pasig"),
                    ("National Capital Region (NCR)", "Metro Manila", "Taguig"),
                    ("National Capital Region (NCR)", "Metro Manila", "Makati"),
                    ("National Capital Region (NCR)", "Metro Manila", "Mandaluyong"),
                    ("National Capital Region (NCR)", "Metro Manila", "Marikina"),
                    ("National Capital Region (NCR)", "Metro Manila", "Parañaque"),
                    ("National Capital Region (NCR)", "Metro Manila", "Pasay"),
                    ("National Capital Region (NCR)", "Metro Manila", "Valenzuela"),
                    ("National Capital Region (NCR)", "Metro Manila", "Las Piñas"),
                    ("National Capital Region (NCR)", "Metro Manila", "Muntinlupa"),
                    ("National Capital Region (NCR)", "Metro Manila", "Malabon"),
                    ("National Capital Region (NCR)", "Metro Manila", "Navotas"),
                    ("National Capital Region (NCR)", "Metro Manila", "San Juan"),
                    ("National Capital Region (NCR)", "Metro Manila", "Pateros"),
                    ("Region IV-A (CALABARZON)", "Cavite", "Bacoor"),
                    ("Region IV-A (CALABARZON)", "Cavite", "Imus"),
                    ("Region IV-A (CALABARZON)", "Cavite", "Dasmariñas"),
                    ("Region IV-A (CALABARZON)", "Cavite", "General Trias"),
                    ("Region IV-A (CALABARZON)", "Cavite", "Tagaytay"),
                    ("Region IV-A (CALABARZON)", "Cavite", "Cavite City"),
                    ("Region IV-A (CALABARZON)", "Cavite", "Trece Martires"),
                    ("Region IV-A (CALABARZON)", "Cavite", "Silang"),
                    ("Region IV-A (CALABARZON)", "Cavite", "Carmona"),
                    ("Region IV-A (CALABARZON)", "Cavite", "Kawit"),
                    ("Region IV-A (CALABARZON)", "Cavite", "Rosario"),
                    ("Region IV-A (CALABARZON)", "Laguna", "Calamba"),
                    ("Region IV-A (CALABARZON)", "Laguna", "Santa Rosa"),
                    ("Region IV-A (CALABARZON)", "Laguna", "Biñan"),
                    ("Region IV-A (CALABARZON)", "Laguna", "San Pedro"),
                    ("Region IV-A (CALABARZON)", "Laguna", "Cabuyao"),
                    ("Region IV-A (CALABARZON)", "Laguna", "San Pablo"),
                    ("Region IV-A (CALABARZON)", "Laguna", "Los Baños"),
                    ("Region IV-A (CALABARZON)", "Laguna", "Santa Cruz"),
                    ("Region IV-A (CALABARZON)", "Batangas", "Batangas City"),
                    ("Region IV-A (CALABARZON)", "Batangas", "Lipa"),
                    ("Region IV-A (CALABARZON)", "Batangas", "Tanauan"),
                    ("Region IV-A (CALABARZON)", "Batangas", "Santo Tomas"),
                    ("Region IV-A (CALABARZON)", "Batangas", "Bauan"),
                    ("Region IV-A (CALABARZON)", "Batangas", "Nasugbu"),
                    ("Region IV-A (CALABARZON)", "Rizal", "Antipolo"),
                    ("Region IV-A (CALABARZON)", "Rizal", "Cainta"),
                    ("Region IV-A (CALABARZON)", "Rizal", "Taytay"),
                    ("Region IV-A (CALABARZON)", "Rizal", "Binangonan"),
                    ("Region IV-A (CALABARZON)", "Rizal", "San Mateo"),
                    ("Region IV-A (CALABARZON)", "Rizal", "Rodriguez"),
                    ("Region IV-A (CALABARZON)", "Rizal", "Angono"),
                    ("Region III (Central Luzon)", "Bulacan", "San Jose del Monte"),
                    ("Region III (Central Luzon)", "Bulacan", "Malolos"),
                    ("Region III (Central Luzon)", "Bulacan", "Meycauayan"),
                    ("Region III (Central Luzon)", "Bulacan", "Marilao"),
                    ("Region III (Central Luzon)", "Bulacan", "Santa Maria"),
                    ("Region III (Central Luzon)", "Bulacan", "Baliwag"),
                    ("Region III (Central Luzon)", "Bulacan", "Bocaue"),
                    ("Region III (Central Luzon)", "Pampanga", "Angeles City"),
                    ("Region III (Central Luzon)", "Pampanga", "San Fernando"),
                    ("Region III (Central Luzon)", "Pampanga", "Mabalacat"),
                    ("Region III (Central Luzon)", "Pampanga", "Guagua"),
                    ("Region III (Central Luzon)", "Pampanga", "Lubao"),
                    ("Region I (Ilocos Region)", "Pangasinan", "Dagupan"),
                    ("Region I (Ilocos Region)", "Pangasinan", "San Carlos"),
                    ("Region I (Ilocos Region)", "Pangasinan", "Urdaneta"),
                    ("Region I (Ilocos Region)", "Pangasinan", "Alaminos"),
                    ("Region I (Ilocos Region)", "Pangasinan", "Lingayen"),
                    ("Region VII (Central Visayas)", "Cebu", "Cebu City"),
                    ("Region VII (Central Visayas)", "Cebu", "Mandaue"),
                    ("Region VII (Central Visayas)", "Cebu", "Lapu-Lapu"),
                    ("Region VII (Central Visayas)", "Cebu", "Talisay"),
                    ("Region VII (Central Visayas)", "Cebu", "Toledo"),
                    ("Region VII (Central Visayas)", "Cebu", "Danao"),
                    ("Region VI (Western Visayas)", "Iloilo", "Iloilo City"),
                    ("Region VI (Western Visayas)", "Iloilo", "Passi"),
                    ("Region VI (Western Visayas)", "Iloilo", "Oton"),
                    ("Region VI (Western Visayas)", "Iloilo", "Pavia"),
                    ("Region VI (Western Visayas)", "Negros Occidental", "Bacolod"),
                    ("Region VI (Western Visayas)", "Negros Occidental", "Bago"),
                    ("Region VI (Western Visayas)", "Negros Occidental", "Cadiz"),
                    ("Region VI (Western Visayas)", "Negros Occidental", "Silay"),
                    ("Region VI (Western Visayas)", "Negros Occidental", "Talisay"),
                    ("Region XI (Davao Region)", "Davao del Sur", "Davao City"),
                    ("Region XI (Davao Region)", "Davao del Sur", "Digos"),
                    ("Region X (Northern Mindanao)", "Misamis Oriental", "Cagayan de Oro"),
                    ("Region X (Northern Mindanao)", "Misamis Oriental", "Gingoog"),
                    ("Cordillera Administrative Region (CAR)", "Benguet", "Baguio City"),
                    ("Cordillera Administrative Region (CAR)", "Benguet", "La Trinidad"),
                    ("Region XII (SOCCSKSARGEN)", "South Cotabato", "General Santos"),
                    ("Region XII (SOCCSKSARGEN)", "South Cotabato", "Koronadal"),
                    ("Region IX (Zamboanga Peninsula)", "Zamboanga del Sur", "Zamboanga City"),
                    ("Region IX (Zamboanga Peninsula)", "Zamboanga del Sur", "Pagadian"),
                    ("Region VIII (Eastern Visayas)", "Leyte", "Tacloban"),
                    ("Region VIII (Eastern Visayas)", "Leyte", "Ormoc")
                }

                For Each g In geoData
                    Using cmd = conn.CreateCommand()
                        cmd.Transaction = tx
                        cmd.CommandText = "
                            INSERT INTO psgc_geographic (region_name, province_name, city_name)
                            VALUES (@reg, @prov, @city);
                        "
                        cmd.Parameters.AddWithValue("@reg", g.Item1)
                        cmd.Parameters.AddWithValue("@prov", g.Item2)
                        cmd.Parameters.AddWithValue("@city", g.Item3)
                        cmd.ExecuteNonQuery()
                    End Using
                Next
            End If
        End Using
    End Sub

End Class
