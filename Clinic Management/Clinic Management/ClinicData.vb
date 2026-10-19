Imports System.Drawing

Public Class AppointmentItem
    Public Property AppointmentId As String = ""
    Public Property Day As Integer
    Public Property Minutes As Integer
    Public Property PatientName As String
    Public Property PatientId As String
    Public Property Age As Integer
    Public Property Sex As String
    Public Property VisitType As String
    Public Property Status As String
    Public Property Reason As String
    Public Property Note As String
    Public Property Symptoms As String
    Public Property Diagnosis As String
    Public Property Medication As String
    Public Property Advice As String
    Public Property Bp As String
    Public Property Pulse As String
    Public Property Temperature As String
    Public Property Spo2 As String
    Public Property IsDraft As Boolean
    Public Property IsRescheduled As Boolean = False
    Public Property DoctorName As String
    Public Property DoctorRole As String
    Public Property AppointmentDate As String = ""
    Public Property RoomNumber As String = "Room 101"
    Public Property Id As Integer = 0
    Public Property CreatedAt As String = ""
    Public Property UpdatedAt As String = ""

    Public Function MatchesDate(targetDate As DateTime) As Boolean
        If Not String.IsNullOrEmpty(AppointmentDate) Then
            Dim parsed As DateTime
            If DateTime.TryParse(AppointmentDate, parsed) Then
                Return parsed.Date = targetDate.Date
            End If
            If AppointmentDate = targetDate.ToString("yyyy-MM-dd") Then
                Return True
            End If
            Return False
        End If
        Return Day = targetDate.Day
    End Function
End Class

Public Class SlotItem
    Public Property Day As Integer
    Public Property Minutes As Integer
    Public Property DurationMinutes As Integer = 30
    Public Property Kind As String
    Public Property PatientName As String
    Public Property DoctorIndex As Integer = 0
    Public Property DoctorName As String = ""
    Public Property SlotDate As String = ""

    Public Function MatchesDate(targetDate As DateTime) As Boolean
        If Not String.IsNullOrEmpty(SlotDate) Then
            Dim parsed As DateTime
            If DateTime.TryParse(SlotDate, parsed) Then
                Return parsed.Date = targetDate.Date
            End If
            If SlotDate = targetDate.ToString("yyyy-MM-dd") Then
                Return True
            End If
            Return False
        End If
        Return Day = targetDate.Day
    End Function
End Class

Public Class ClinicData

    Public Shared Function Hx(hex As String) As Color
        Return ColorTranslator.FromHtml(hex)
    End Function

    Public Shared Function FormatTime(minutes As Integer, Optional includeAmPm As Boolean = True) As String
        Dim h As Integer = (minutes \ 60) Mod 24
        Dim m As Integer = minutes Mod 60
        Dim ampm As String = If(h >= 12, "PM", "AM")
        Dim h12 As Integer = h Mod 12
        If h12 = 0 Then h12 = 12
        If includeAmPm Then
            Return $"{h12}:{m:D2} {ampm}"
        Else
            Return $"{h12}:{m:D2}"
        End If
    End Function

    Public Shared ReadOnly Property Appointments As List(Of AppointmentItem)
        Get
            Return SqliteAppointmentRepository.GetAllAppointments()
        End Get
    End Property

    Public Shared ReadOnly Property Slots As List(Of SlotItem)
        Get
            Return SqliteAppointmentRepository.GetAllSlots()
        End Get
    End Property

    Public Shared Function NextPending() As AppointmentItem
        Dim all = Appointments
        Dim item = all.FirstOrDefault(Function(a) a.Status = "Pending")
        If item Is Nothing AndAlso all.Count > 0 Then
            Return all(0)
        End If
        Return item
    End Function

    Public Shared Event DataChanged()

    Public Shared Sub NotifyDataChanged()
        RaiseEvent DataChanged()
    End Sub

    Public Shared Sub AddAppointment(appt As AppointmentItem)
        SqliteAppointmentRepository.AddAppointment(appt)
        NotifyDataChanged()
    End Sub

    Public Shared Sub AddSlot(slot As SlotItem)
        SqliteAppointmentRepository.AddSlot(slot)
        NotifyDataChanged()
    End Sub

    ''' <summary>
    ''' Checks for any active appointments (not cancelled) that overlap with [startMinutes, endMinutes)
    ''' for a given doctor on targetDate (or on target day-of-week if recurring).
    ''' </summary>
    Public Shared Function GetConflictingAppointments(doctorName As String, targetDate As DateTime, startMinutes As Integer, endMinutes As Integer, Optional isRecurring As Boolean = False) As List(Of AppointmentItem)
        Dim list As New List(Of AppointmentItem)()
        Dim allAppts = Appointments
        Dim docShort = If(String.IsNullOrEmpty(doctorName), "", doctorName.Replace("Dr.", "").Trim())
        Dim dow = CInt(targetDate.DayOfWeek)

        For Each a In allAppts
            If String.Equals(a.Status, "Cancelled", StringComparison.OrdinalIgnoreCase) Then Continue For

            Dim matchesDoctor As Boolean = False
            If String.IsNullOrEmpty(doctorName) OrElse String.IsNullOrEmpty(a.DoctorName) Then
                matchesDoctor = True
            ElseIf a.DoctorName.Equals(doctorName, StringComparison.OrdinalIgnoreCase) Then
                matchesDoctor = True
            ElseIf Not String.IsNullOrEmpty(docShort) AndAlso a.DoctorName.Contains(docShort, StringComparison.OrdinalIgnoreCase) Then
                matchesDoctor = True
            End If
            If Not matchesDoctor Then Continue For

            Dim matchesDate As Boolean = False
            If isRecurring Then
                Dim apptDate As DateTime
                If DateTime.TryParse(a.AppointmentDate, apptDate) Then
                    matchesDate = (CInt(apptDate.DayOfWeek) = dow)
                Else
                    matchesDate = a.MatchesDate(targetDate)
                End If
            Else
                matchesDate = a.MatchesDate(targetDate)
            End If
            If Not matchesDate Then Continue For

            ' Time interval overlap [a.Minutes, a.Minutes + 30) with [startMinutes, endMinutes)
            If a.Minutes < endMinutes AndAlso (a.Minutes + 30) > startMinutes Then
                list.Add(a)
            End If
        Next

        Return list
    End Function

    Public Shared Function GetSlotsForDoctor(doctorName As String, weekMonday As DateTime, Optional dayCount As Integer = 5) As List(Of SlotItem)
        Return SqliteAvailabilityRepository.GetSlotsForDoctor(doctorName, weekMonday, dayCount)
    End Function

    Public Shared Sub UpdateSlotStatus(doctorName As String, slotDate As String, startMinutes As Integer, newStatus As String)
        SqliteAvailabilityRepository.UpdateSlotStatus(doctorName, slotDate, startMinutes, newStatus)
        NotifyDataChanged()
    End Sub

    Public Shared Sub DeleteSlot(doctorName As String, slotDate As String, startMinutes As Integer)
        SqliteAvailabilityRepository.DeleteSlot(doctorName, slotDate, startMinutes)
        NotifyDataChanged()
    End Sub

    Public Shared Sub RescheduleAppointment(pid As String, oldDay As Integer, oldMins As Integer, newDay As Integer, newMins As Integer, newDoctor As String, newNote As String, Optional newDate As String = "")
        SqliteAppointmentRepository.RescheduleAppointment(pid, oldDay, oldMins, newDay, newMins, newDoctor, newNote, newDate)
        NotifyDataChanged()
    End Sub

    Public Shared Sub UpdateAppointment(appt As AppointmentItem)
        SqliteAppointmentRepository.UpdateAppointment(appt)
        NotifyDataChanged()
    End Sub

    Public Shared Function InitializeAppointments() As List(Of AppointmentItem)
        Dim list As New List(Of AppointmentItem)()

        ' ---- Day 21 (Mon, Sep 21) ----
        list.Add(New AppointmentItem With {
            .Day = 21, .Minutes = 540, .PatientName = "Maria Santos", .PatientId = "PT-1048",
            .DoctorName = "Dr. Elena Cruz", .DoctorRole = "General Physician",
            .Age = 34, .Sex = "Female", .VisitType = "Follow-up", .Status = "Completed",
            .Reason = "Asthma evaluation", .Symptoms = "Mild wheezing in morning",
            .Diagnosis = "Controlled bronchial asthma", .Medication = "Salbutamol inhaler 100mcg",
            .Advice = "Continue prescribed dosage, avoid sudden temperature changes",
            .Bp = "118/76", .Pulse = "72 bpm", .Temperature = "36.6 °C", .Spo2 = "99%"
        })
        list.Add(New AppointmentItem With {
            .Day = 21, .Minutes = 570, .PatientName = "Ana Villanueva", .PatientId = "PT-1028",
            .DoctorName = "Dr. Marco Lim", .DoctorRole = "General Physician",
            .Age = 42, .Sex = "Female", .VisitType = "Consultation", .Status = "Completed",
            .Reason = "Routine assessment and blood glucose check", .Symptoms = "Mild fatigue",
            .Diagnosis = "Type 2 Diabetes Mellitus - monitored", .Medication = "Metformin 500mg BID",
            .Advice = "Maintain balanced diet",
            .Bp = "120/78", .Pulse = "72 bpm", .Temperature = "36.5 °C", .Spo2 = "98%"
        })
        list.Add(New AppointmentItem With {
            .Day = 21, .Minutes = 630, .PatientName = "Joshua Reyes", .PatientId = "PT-1051",
            .DoctorName = "Dr. Elena Cruz", .DoctorRole = "General Physician",
            .Age = 27, .Sex = "Male", .VisitType = "Consultation", .Status = "Completed",
            .Reason = "BP check and routine exam", .Symptoms = "Occasional dizziness after exercise",
            .Diagnosis = "Essential hypertension stage 1", .Medication = "Losartan 50mg daily",
            .Advice = "Reduce sodium intake, 30 min daily walking",
            .Bp = "138/88", .Pulse = "78 bpm", .Temperature = "36.7 °C", .Spo2 = "98%"
        })
        list.Add(New AppointmentItem With {
            .Day = 21, .Minutes = 840, .PatientName = "Carlos Mendoza", .PatientId = "PT-1065",
            .DoctorName = "Dr. Marco Lim", .DoctorRole = "General Physician",
            .Age = 19, .Sex = "Male", .VisitType = "Check-up", .Status = "Completed",
            .Reason = "Gastric discomfort follow-up", .Symptoms = "Occasional heartburn",
            .Diagnosis = "Mild GERD", .Medication = "Antacid 1 tab chewable PRN",
            .Advice = "Avoid late-night meals",
            .Bp = "116/74", .Pulse = "70 bpm", .Temperature = "36.5 °C", .Spo2 = "99%"
        })

        ' ---- Day 22 (Tue, Sep 22) ----
        list.Add(New AppointmentItem With {
            .Day = 22, .Minutes = 540, .PatientName = "Maria Santos", .PatientId = "PT-1048",
            .DoctorName = "Dr. Elena Cruz", .DoctorRole = "General Physician",
            .Age = 34, .Sex = "Female", .VisitType = "Follow-up", .Status = "Completed",
            .Reason = "Asthma review", .Symptoms = "No acute symptoms",
            .Diagnosis = "Asthma controlled", .Medication = "Salbutamol inhaler PRN",
            .Advice = "Avoid dusty surroundings",
            .Bp = "120/80", .Pulse = "74 bpm", .Temperature = "36.5 °C", .Spo2 = "99%"
        })
        list.Add(New AppointmentItem With {
            .Day = 22, .Minutes = 570, .PatientName = "Lea Mendoza", .PatientId = "PT-1057",
            .DoctorName = "Dr. Marco Lim", .DoctorRole = "General Physician",
            .Age = 19, .Sex = "Female", .VisitType = "Check-up", .Status = "Completed",
            .Reason = "General wellness evaluation", .Symptoms = "None",
            .Diagnosis = "Healthy", .Medication = "Multivitamins",
            .Advice = "Maintain hydration and balanced diet",
            .Bp = "112/72", .Pulse = "68 bpm", .Temperature = "36.6 °C", .Spo2 = "99%"
        })
        list.Add(New AppointmentItem With {
            .Day = 22, .Minutes = 660, .PatientName = "Roberto Diaz", .PatientId = "PT-1033",
            .DoctorName = "Dr. Elena Cruz", .DoctorRole = "General Physician",
            .Age = 58, .Sex = "Male", .VisitType = "Follow-up", .Status = "Completed",
            .Reason = "Lower back pain follow-up", .Symptoms = "Stiffness in lower back",
            .Diagnosis = "Lumbar strain", .Medication = "Paracetamol 500mg as needed",
            .Advice = "Gentle stretching and ergonomic chair usage",
            .Bp = "130/82", .Pulse = "70 bpm", .Temperature = "36.4 °C", .Spo2 = "98%"
        })
        list.Add(New AppointmentItem With {
            .Day = 22, .Minutes = 870, .PatientName = "Teresa Ramos", .PatientId = "PT-1070",
            .DoctorName = "Dr. Marco Lim", .DoctorRole = "General Physician",
            .Age = 51, .Sex = "Female", .VisitType = "Consultation", .Status = "Completed",
            .Reason = "Headache and vertigo assessment", .Symptoms = "Mild dizziness on standing",
            .Diagnosis = "Benign positional vertigo", .Medication = "Betahistine 16mg TID",
            .Advice = "Avoid sudden head movements",
            .Bp = "124/80", .Pulse = "72 bpm", .Temperature = "36.6 °C", .Spo2 = "98%"
        })

        ' ---- Day 23 (Wed, Sep 23) ----
        list.Add(New AppointmentItem With {
            .Day = 23, .Minutes = 540, .PatientName = "Gabriel Cruz", .PatientId = "PT-1074",
            .DoctorName = "Dr. Elena Cruz", .DoctorRole = "General Physician",
            .Age = 38, .Sex = "Male", .VisitType = "Follow-up", .Status = "Completed",
            .Reason = "Uric acid follow-up", .Symptoms = "Occasional joint pain",
            .Diagnosis = "Hyperuricemia, improving", .Medication = "Allopurinol 100mg daily",
            .Advice = "Avoid high-purine foods",
            .Bp = "126/82", .Pulse = "74 bpm", .Temperature = "36.5 °C", .Spo2 = "98%"
        })
        list.Add(New AppointmentItem With {
            .Day = 23, .Minutes = 600, .PatientName = "Ana Villanueva", .PatientId = "PT-1028",
            .DoctorName = "Dr. Marco Lim", .DoctorRole = "General Physician",
            .Age = 42, .Sex = "Female", .VisitType = "Consultation", .Status = "Completed",
            .Reason = "Blood sugar review", .Symptoms = "Fatigue, increased thirst",
            .Diagnosis = "Type 2 Diabetes Mellitus", .Medication = "Metformin 500mg BID",
            .Advice = "Dietary moderation, log fasting glucose",
            .Bp = "124/80", .Pulse = "75 bpm", .Temperature = "36.6 °C", .Spo2 = "98%"
        })
        list.Add(New AppointmentItem With {
            .Day = 23, .Minutes = 840, .PatientName = "Carlos Mendoza", .PatientId = "PT-1065",
            .DoctorName = "Dr. Elena Cruz", .DoctorRole = "General Physician",
            .Age = 19, .Sex = "Male", .VisitType = "Check-up", .Status = "Completed",
            .Reason = "Routine check-up", .Symptoms = "None",
            .Diagnosis = "Healthy", .Medication = "Multivitamins",
            .Advice = "Maintain active lifestyle",
            .Bp = "115/75", .Pulse = "68 bpm", .Temperature = "36.5 °C", .Spo2 = "99%"
        })
        list.Add(New AppointmentItem With {
            .Day = 23, .Minutes = 900, .PatientName = "Patricia Gomez", .PatientId = "PT-1081",
            .DoctorName = "Dr. Marco Lim", .DoctorRole = "General Physician",
            .Age = 29, .Sex = "Female", .VisitType = "Consultation", .Status = "Confirmed",
            .Reason = "Dyspepsia evaluation", .Symptoms = "Upper abdominal discomfort after meals",
            .Diagnosis = "Mild gastritis", .Medication = "Omeprazole 20mg OD before breakfast",
            .Advice = "Small frequent meals, avoid spicy foods",
            .Bp = "118/76", .Pulse = "72 bpm", .Temperature = "36.6 °C", .Spo2 = "99%"
        })

        ' ---- Day 24 (Thu, Sep 24) ----
        list.Add(New AppointmentItem With {
            .Day = 24, .Minutes = 570, .PatientName = "Joshua Reyes", .PatientId = "PT-1051",
            .DoctorName = "Dr. Elena Cruz", .DoctorRole = "General Physician",
            .Age = 27, .Sex = "Male", .VisitType = "Follow-up", .Status = "Completed",
            .Reason = "Follow-up consultation", .Symptoms = "Headaches reduced",
            .Diagnosis = "Improving hypertension", .Medication = "Losartan 50mg daily",
            .Advice = "Continue current regimen",
            .Bp = "128/82", .Pulse = "72 bpm", .Temperature = "36.6 °C", .Spo2 = "98%"
        })
        list.Add(New AppointmentItem With {
            .Day = 24, .Minutes = 600, .PatientName = "Lea Mendoza", .PatientId = "PT-1057",
            .DoctorName = "Dr. Marco Lim", .DoctorRole = "General Physician",
            .Age = 19, .Sex = "Female", .VisitType = "Consultation", .Status = "Completed",
            .Reason = "Allergy symptoms assessment", .Symptoms = "Sneezing and runny nose in mornings",
            .Diagnosis = "Allergic rhinitis", .Medication = "Cetirizine 10mg tab once daily",
            .Advice = "Avoid dust exposure",
            .Bp = "114/74", .Pulse = "70 bpm", .Temperature = "36.5 °C", .Spo2 = "99%"
        })
        list.Add(New AppointmentItem With {
            .Day = 24, .Minutes = 870, .PatientName = "Roberto Diaz", .PatientId = "PT-1033",
            .DoctorName = "Dr. Elena Cruz", .DoctorRole = "General Physician",
            .Age = 58, .Sex = "Male", .VisitType = "Consultation", .Status = "Confirmed",
            .Reason = "Pain management review", .Symptoms = "Mild ache when walking",
            .Diagnosis = "Chronic lumbar strain", .Medication = "Paracetamol 500mg PRN",
            .Advice = "Follow physical therapy exercises",
            .Bp = "128/84", .Pulse = "74 bpm", .Temperature = "36.5 °C", .Spo2 = "98%"
        })
        list.Add(New AppointmentItem With {
            .Day = 24, .Minutes = 930, .PatientName = "Teresa Ramos", .PatientId = "PT-1070",
            .DoctorName = "Dr. Marco Lim", .DoctorRole = "General Physician",
            .Age = 51, .Sex = "Female", .VisitType = "Check-up", .Status = "Confirmed",
            .Reason = "Routine check-up", .Symptoms = "None",
            .Diagnosis = "Stable", .Medication = "Multivitamins",
            .Advice = "Continue routine care",
            .Bp = "122/78", .Pulse = "72 bpm", .Temperature = "36.6 °C", .Spo2 = "98%"
        })

        ' ---- Day 25 (Fri, Sep 25 - Active Day) ----
        list.Add(New AppointmentItem With {
            .Day = 25, .Minutes = 480, .PatientName = "Maria Santos", .PatientId = "PT-1048",
            .DoctorName = "Dr. Elena Cruz", .DoctorRole = "General Physician",
            .Age = 34, .Sex = "Female", .VisitType = "Follow-up", .Status = "Completed",
            .Reason = "Asthma progress check", .Symptoms = "Occasional nighttime cough",
            .Diagnosis = "Asthma controlled", .Medication = "Salbutamol 100mcg inhaler",
            .Advice = "Keep inhaler accessible, avoid sudden chilling",
            .Bp = "120/80", .Pulse = "74 bpm", .Temperature = "36.6 °C", .Spo2 = "99%"
        })
        list.Add(New AppointmentItem With {
            .Day = 25, .Minutes = 570, .PatientName = "Ana Villanueva", .PatientId = "PT-1028",
            .DoctorName = "Dr. Marco Lim", .DoctorRole = "General Physician",
            .Age = 42, .Sex = "Female", .VisitType = "Check-up", .Status = "Confirmed",
            .Reason = "Periodic glucose check and dietary guidance",
            .Symptoms = "No complaints, fasting glucose logs brought",
            .Diagnosis = "Type 2 Diabetes Mellitus - stable",
            .Medication = "Metformin 500mg tab BID",
            .Advice = "Continue current diet and exercise program",
            .Bp = "122/78", .Pulse = "72 bpm", .Temperature = "36.5 °C", .Spo2 = "98%"
        })
        list.Add(New AppointmentItem With {
            .Day = 25, .Minutes = 630, .PatientName = "Joshua Reyes", .PatientId = "PT-1051",
            .DoctorName = "Dr. Elena Cruz", .DoctorRole = "General Physician",
            .Age = 27, .Sex = "Male", .VisitType = "Consultation", .Status = "Pending",
            .Reason = "Recurrent tension headache and blood pressure check",
            .Symptoms = "Throbbing headache on occipital region for 2 days",
            .Diagnosis = "Tension-type headache, secondary to stress",
            .Medication = "Paracetamol 500mg q6h PRN",
            .Advice = "Proper hydration, 8 hours sleep, reduce screen time",
            .Bp = "132/86", .Pulse = "80 bpm", .Temperature = "36.8 °C", .Spo2 = "98%"
        })
        list.Add(New AppointmentItem With {
            .Day = 25, .Minutes = 675, .PatientName = "Lea Mendoza", .PatientId = "PT-1057",
            .DoctorName = "Dr. Marco Lim", .DoctorRole = "General Physician",
            .Age = 19, .Sex = "Female", .VisitType = "Consultation", .Status = "Confirmed",
            .Reason = "Sore throat and mild fever", .Symptoms = "Throat tickle, slight discomfort",
            .Diagnosis = "Early pharyngitis", .Medication = "Throat lozenges q4h PRN",
            .Advice = "Warm saline gargle, rest",
            .Bp = "115/75", .Pulse = "72 bpm", .Temperature = "37.1 °C", .Spo2 = "99%"
        })
        list.Add(New AppointmentItem With {
            .Day = 25, .Minutes = 795, .PatientName = "Gabriel Cruz", .PatientId = "PT-1074",
            .DoctorName = "Dr. Elena Cruz", .DoctorRole = "General Physician",
            .Age = 38, .Sex = "Male", .VisitType = "Follow-up", .Status = "Confirmed",
            .Reason = "Periodic uric acid review", .Symptoms = "Joint discomfort subsided",
            .Diagnosis = "Hyperuricemia, controlled", .Medication = "Allopurinol 100mg daily",
            .Advice = "Hydration and low-purine diet",
            .Bp = "124/80", .Pulse = "72 bpm", .Temperature = "36.5 °C", .Spo2 = "98%"
        })
        list.Add(New AppointmentItem With {
            .Day = 25, .Minutes = 840, .PatientName = "Carlos Mendoza", .PatientId = "PT-1065",
            .DoctorName = "Dr. Marco Lim", .DoctorRole = "General Physician",
            .Age = 19, .Sex = "Male", .VisitType = "Check-up", .Status = "Cancelled",
            .Reason = "Annual sports physical exam", .Note = "Cancelled by patient",
            .Symptoms = "", .Diagnosis = "", .Medication = "", .Advice = "",
            .Bp = "118/76", .Pulse = "70 bpm", .Temperature = "36.5 °C", .Spo2 = "99%"
        })
        list.Add(New AppointmentItem With {
            .Day = 25, .Minutes = 930, .PatientName = "Roberto Diaz", .PatientId = "PT-1033",
            .DoctorName = "Dr. Elena Cruz", .DoctorRole = "General Physician",
            .Age = 58, .Sex = "Male", .VisitType = "Follow-up", .Status = "Pending",
            .Reason = "Spine evaluation and physical therapy progress",
            .Symptoms = "Lower back stiffness after sitting for more than 1 hour",
            .Diagnosis = "Lumbar spondylosis",
            .Medication = "Celecoxib 200mg daily as needed for pain",
            .Advice = "Physical therapy sessions twice weekly",
            .Bp = "134/86", .Pulse = "76 bpm", .Temperature = "36.7 °C", .Spo2 = "97%"
        })
        list.Add(New AppointmentItem With {
            .Day = 25, .Minutes = 975, .PatientName = "Teresa Ramos", .PatientId = "PT-1070",
            .DoctorName = "Dr. Marco Lim", .DoctorRole = "General Physician",
            .Age = 51, .Sex = "Female", .VisitType = "Check-up", .Status = "Confirmed",
            .Reason = "Routine check-up", .Symptoms = "None",
            .Diagnosis = "Healthy", .Medication = "Multivitamins",
            .Advice = "Regular checkup in 6 months",
            .Bp = "120/78", .Pulse = "70 bpm", .Temperature = "36.5 °C", .Spo2 = "99%"
        })

        Return list
    End Function

    Public Shared Function InitializeSlots() As List(Of SlotItem)
        Dim list As New List(Of SlotItem)()

        ' Day 22 (Tue)
        list.Add(New SlotItem With {.Day = 22, .Minutes = 540, .Kind = "Appointment", .PatientName = "Maria Santos"})
        list.Add(New SlotItem With {.Day = 22, .Minutes = 600, .Kind = "Available", .PatientName = ""})
        list.Add(New SlotItem With {.Day = 22, .Minutes = 660, .Kind = "Appointment", .PatientName = "Roberto Diaz"})
        list.Add(New SlotItem With {.Day = 22, .Minutes = 840, .Kind = "Blocked", .PatientName = ""})
        list.Add(New SlotItem With {.Day = 22, .Minutes = 900, .Kind = "Available", .PatientName = ""})

        ' Day 23 (Wed)
        list.Add(New SlotItem With {.Day = 23, .Minutes = 540, .Kind = "Available", .PatientName = ""})
        list.Add(New SlotItem With {.Day = 23, .Minutes = 600, .Kind = "Appointment", .PatientName = "Ana Villanueva"})
        list.Add(New SlotItem With {.Day = 23, .Minutes = 720, .Kind = "Blocked", .PatientName = ""})
        list.Add(New SlotItem With {.Day = 23, .Minutes = 840, .Kind = "Appointment", .PatientName = "Carlos Mendoza"})

        ' Day 24 (Thu)
        list.Add(New SlotItem With {.Day = 24, .Minutes = 540, .Kind = "Blocked", .PatientName = ""})
        list.Add(New SlotItem With {.Day = 24, .Minutes = 570, .Kind = "Appointment", .PatientName = "Joshua Reyes"})
        list.Add(New SlotItem With {.Day = 24, .Minutes = 660, .Kind = "Available", .PatientName = ""})
        list.Add(New SlotItem With {.Day = 24, .Minutes = 870, .Kind = "Appointment", .PatientName = "Roberto Diaz"})

        ' Day 25 (Fri)
        list.Add(New SlotItem With {.Day = 25, .Minutes = 480, .Kind = "Appointment", .PatientName = "Maria Santos"})
        list.Add(New SlotItem With {.Day = 25, .Minutes = 630, .Kind = "Appointment", .PatientName = "Joshua Reyes"})
        list.Add(New SlotItem With {.Day = 25, .Minutes = 795, .Kind = "Appointment", .PatientName = "Ana Villanueva"})
        list.Add(New SlotItem With {.Day = 25, .Minutes = 930, .Kind = "Appointment", .PatientName = "Roberto Diaz"})
        list.Add(New SlotItem With {.Day = 25, .Minutes = 975, .Kind = "Blocked", .PatientName = ""})

        ' Day 26 (Sat)
        list.Add(New SlotItem With {.Day = 26, .Minutes = 540, .Kind = "Available", .PatientName = ""})
        list.Add(New SlotItem With {.Day = 26, .Minutes = 600, .Kind = "Available", .PatientName = ""})
        list.Add(New SlotItem With {.Day = 26, .Minutes = 660, .Kind = "Blocked", .PatientName = ""})

        ' Dr. Marco Lim (DoctorIndex = 1)
        list.Add(New SlotItem With {.Day = 22, .Minutes = 570, .Kind = "Appointment", .PatientName = "Ana Villanueva", .DoctorIndex = 1})
        list.Add(New SlotItem With {.Day = 22, .Minutes = 660, .Kind = "Available", .PatientName = "", .DoctorIndex = 1})
        list.Add(New SlotItem With {.Day = 22, .Minutes = 870, .Kind = "Blocked", .PatientName = "", .DoctorIndex = 1})
        list.Add(New SlotItem With {.Day = 23, .Minutes = 600, .Kind = "Appointment", .PatientName = "Lea Mendoza", .DoctorIndex = 1})
        list.Add(New SlotItem With {.Day = 23, .Minutes = 810, .Kind = "Available", .PatientName = "", .DoctorIndex = 1})
        list.Add(New SlotItem With {.Day = 24, .Minutes = 540, .Kind = "Available", .PatientName = "", .DoctorIndex = 1})
        list.Add(New SlotItem With {.Day = 24, .Minutes = 690, .Kind = "Appointment", .PatientName = "Joshua Reyes", .DoctorIndex = 1})
        list.Add(New SlotItem With {.Day = 25, .Minutes = 570, .Kind = "Appointment", .PatientName = "Maria Santos", .DoctorIndex = 1})
        list.Add(New SlotItem With {.Day = 25, .Minutes = 900, .Kind = "Available", .PatientName = "", .DoctorIndex = 1})
        list.Add(New SlotItem With {.Day = 26, .Minutes = 540, .Kind = "Available", .PatientName = "", .DoctorIndex = 1})

        Return list
    End Function

End Class
