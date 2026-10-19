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

            CREATE TABLE IF NOT EXISTS prescription_access_requests (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                prescription_id INTEGER NOT NULL,
                patient_id TEXT NOT NULL,
                requested_by_user_id INTEGER NOT NULL DEFAULT 0,
                doctor_id INTEGER NOT NULL DEFAULT 0,
                reason TEXT NOT NULL,
                status TEXT NOT NULL DEFAULT 'Pending' CHECK(status IN ('Pending', 'Approved', 'Denied', 'Expired', 'Revoked', 'Used')),
                requested_at TEXT NOT NULL DEFAULT (datetime('now', 'localtime')),
                decided_at TEXT NULL,
                decision_note TEXT NULL,
                access_type TEXT NULL DEFAULT 'time_limited',
                expires_at TEXT NULL,
                revoked_at TEXT NULL,
                allow_print INTEGER NOT NULL DEFAULT 0
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

        ' Normalize all patient and appointment names to Proper Case if any exist
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
            CREATE INDEX IF NOT EXISTS idx_rx_req_doc ON prescription_access_requests(doctor_id, status);
            CREATE INDEX IF NOT EXISTS idx_rx_req_pat ON prescription_access_requests(patient_id, requested_by_user_id);
        "

        Using cmd = conn.CreateCommand()
            cmd.Transaction = tx
            cmd.CommandText = indexDdl
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Shared Sub SeedInitialData(conn As SqliteConnection, tx As SqliteTransaction)
        ' Automatic application data seeding is intentionally disabled.
        ' Application data is kept clean for actual clinic usage.
        ' Only ensure that at least one Administrator account exists if the database has zero administrators (e.g. fresh installation).
        EnsureDefaultAdministrator(conn, tx)
    End Sub

    Private Shared Sub EnsureDefaultAdministrator(conn As SqliteConnection, tx As SqliteTransaction)
        Using chk = conn.CreateCommand()
            chk.Transaction = tx
            chk.CommandText = "SELECT COUNT(*) FROM staff_accounts WHERE role = 'Administrator';"
            Dim cnt = Convert.ToInt64(chk.ExecuteScalar())
            If cnt = 0 Then
                Dim salt = SecurityHelper.GenerateSalt()
                Dim hash = SecurityHelper.HashPassword("admin123", salt)
                Using ins = conn.CreateCommand()
                    ins.Transaction = tx
                    ins.CommandText = "
                        INSERT INTO staff_accounts (name, email, role, status, last_active, password_hash, password_salt, invite_code)
                        VALUES ('Rosa Dela Cruz', 'rosa.delacruz@uccclinic.edu.ph', 'Administrator', 'Active', 'Just now', @hash, @salt, '');
                    "
                    ins.Parameters.AddWithValue("@hash", hash)
                    ins.Parameters.AddWithValue("@salt", salt)
                    ins.ExecuteNonQuery()
                End Using
            End If
        End Using
    End Sub

End Class
