Public Class PatientItem
    Public Property PatientId As String
    Public Property Name As String
    Public Property Age As Integer
    Public Property Gender As String
    Public Property BirthDate As String
    Public Property Contact As String
    Public Property Email As String
    Public Property Address As String
    Public Property LastVisitDate As Date
    Public Property LastVisitDisplay As String
    Public Property KnownConditions As String
    Public Property DrugAllergies As String
    Public Property HasAllergies As Boolean
    Public Property RecordUpdated As String

    Public Property UpcomingDate As String
    Public Property UpcomingDetails As String
    Public Property UpcomingStatus As String

    Public Property Visits As New List(Of VisitItem)
End Class

Public Class VisitItem
    Public Property VisitDate As String
    Public Property VisitType As String
    Public Property Diagnosis As String
    Public Property Doctor As String
    Public Property Status As String

    Public Sub New(vDate As String, vType As String, vDiag As String, vDoc As String, vStat As String)
        VisitDate = vDate
        VisitType = vType
        Diagnosis = vDiag
        Doctor = vDoc
        Status = vStat
    End Sub
End Class

Public Class PatientRepository

    Public Shared Function GetAll() As List(Of PatientItem)
        Return SqlitePatientRepository.GetAll()
    End Function

    Public Shared Function GetPatientsForDoctor(doctorName As String) As List(Of PatientItem)
        Return SqlitePatientRepository.GetPatientsForDoctor(doctorName)
    End Function

    Public Shared Function GetById(patientId As String) As PatientItem
        Return SqlitePatientRepository.GetById(patientId)
    End Function

    Public Shared Sub AddPatient(item As PatientItem)
        SqlitePatientRepository.AddPatient(item)
    End Sub

    Public Shared Function FindDuplicateByPhone(phone As String, Optional excludePatientId As String = Nothing) As PatientItem
        Return SqlitePatientRepository.FindDuplicateByPhone(phone, excludePatientId)
    End Function

    Public Shared Function FindDuplicateProfile(name As String, birthDate As String, Optional excludePatientId As String = Nothing) As PatientItem
        Return SqlitePatientRepository.FindDuplicateProfile(name, birthDate, excludePatientId)
    End Function

    Public Shared Function InitializeMockPatients() As List(Of PatientItem)
        Dim list As New List(Of PatientItem)

        ' 1. Maria Santos
        Dim p1 As New PatientItem With {
            .PatientId = "PT-1048",
            .Name = "Maria Santos",
            .Age = 34,
            .Gender = "Female",
            .BirthDate = "Born March 14, 1992",
            .Contact = "0917 432 8801",
            .Email = "maria.santos@email.com",
            .Address = "Bagong Silang, Caloocan City",
            .LastVisitDate = New Date(2026, 9, 22),
            .LastVisitDisplay = "Sep 22, 2026",
            .KnownConditions = "Mild asthma • Seasonal allergies",
            .DrugAllergies = "Penicillin",
            .HasAllergies = True,
            .RecordUpdated = "Record updated today at 8:42 AM",
            .UpcomingDate = "Oct 20 • 9:00 AM",
            .UpcomingDetails = "Dr. Elena Cruz • Follow-up",
            .UpcomingStatus = "Confirmed"
        }
        p1.Visits.Add(New VisitItem("Sep 22, 2026", "Follow-up", "Asthma controlled", "Dr. Elena Cruz", "Completed"))
        p1.Visits.Add(New VisitItem("Jun 16, 2026", "Consultation", "Allergic rhinitis", "Dr. Elena Cruz", "Completed"))
        p1.Visits.Add(New VisitItem("Jan 08, 2026", "Check-up", "Routine assessment", "Dr. Marco Lim", "Completed"))
        list.Add(p1)

        ' 2. Joshua Reyes
        Dim p2 As New PatientItem With {
            .PatientId = "PT-1051",
            .Name = "Joshua Reyes",
            .Age = 27,
            .Gender = "Male",
            .BirthDate = "Born August 19, 1999",
            .Contact = "0921 673 2188",
            .Email = "joshua.reyes@email.com",
            .Address = "Grace Park, Caloocan City",
            .LastVisitDate = New Date(2026, 9, 18),
            .LastVisitDisplay = "Sep 18, 2026",
            .KnownConditions = "Hypertension (Stage 1)",
            .DrugAllergies = "None reported",
            .HasAllergies = False,
            .RecordUpdated = "Record updated yesterday at 3:15 PM",
            .UpcomingDate = "Oct 15 • 10:30 AM",
            .UpcomingDetails = "Dr. Elena Cruz • Consultation",
            .UpcomingStatus = "Confirmed"
        }
        p2.Visits.Add(New VisitItem("Sep 18, 2026", "Consultation", "BP elevated, diet advised", "Dr. Elena Cruz", "Completed"))
        p2.Visits.Add(New VisitItem("May 10, 2026", "Check-up", "Initial health screening", "Dr. Elena Cruz", "Completed"))
        p2.Visits.Add(New VisitItem("Feb 14, 2026", "Follow-up", "Routine blood work", "Dr. Marco Lim", "Completed"))
        list.Add(p2)

        ' 3. Ana Villanueva
        Dim p3 As New PatientItem With {
            .PatientId = "PT-1028",
            .Name = "Ana Villanueva",
            .Age = 42,
            .Gender = "Female",
            .BirthDate = "Born November 05, 1983",
            .Contact = "0918 554 9921",
            .Email = "ana.villanueva@email.com",
            .Address = "Maypajo, Caloocan City",
            .LastVisitDate = New Date(2026, 9, 10),
            .LastVisitDisplay = "Sep 10, 2026",
            .KnownConditions = "Type 2 Diabetes • Hyperlipidemia",
            .DrugAllergies = "Aspirin",
            .HasAllergies = True,
            .RecordUpdated = "Record updated Sep 10 at 11:20 AM",
            .UpcomingDate = "Oct 22 • 2:00 PM",
            .UpcomingDetails = "Dr. Elena Cruz • Follow-up",
            .UpcomingStatus = "Confirmed"
        }
        p3.Visits.Add(New VisitItem("Sep 10, 2026", "Follow-up", "HbA1c 6.8%, medication refilled", "Dr. Elena Cruz", "Completed"))
        p3.Visits.Add(New VisitItem("Jun 02, 2026", "Consultation", "Fasting blood sugar check", "Dr. Elena Cruz", "Completed"))
        p3.Visits.Add(New VisitItem("Feb 19, 2026", "Check-up", "Annual comprehensive checkup", "Dr. Elena Cruz", "Completed"))
        list.Add(p3)

        ' 4. Roberto Diaz
        Dim p4 As New PatientItem With {
            .PatientId = "PT-1033",
            .Name = "Roberto Diaz",
            .Age = 58,
            .Gender = "Male",
            .BirthDate = "Born December 12, 1967",
            .Contact = "0928 331 4452",
            .Email = "roberto.diaz@email.com",
            .Address = "Camarin, Caloocan City",
            .LastVisitDate = New Date(2026, 8, 29),
            .LastVisitDisplay = "Aug 29, 2026",
            .KnownConditions = "Chronic Lower Back Pain",
            .DrugAllergies = "Ibuprofen",
            .HasAllergies = True,
            .RecordUpdated = "Record updated Aug 29 at 4:05 PM",
            .UpcomingDate = "Oct 25 • 3:30 PM",
            .UpcomingDetails = "Dr. Elena Cruz • Follow-up",
            .UpcomingStatus = "Confirmed"
        }
        p4.Visits.Add(New VisitItem("Aug 29, 2026", "Follow-up", "Physical therapy progress review", "Dr. Elena Cruz", "Completed"))
        p4.Visits.Add(New VisitItem("May 15, 2026", "Consultation", "Lumbar strain management", "Dr. Elena Cruz", "Completed"))
        p4.Visits.Add(New VisitItem("Jan 22, 2026", "Check-up", "Initial spine x-ray review", "Dr. Marco Lim", "Completed"))
        list.Add(p4)

        ' 5. Carlos Mendoza
        Dim p5 As New PatientItem With {
            .PatientId = "PT-1065",
            .Name = "Carlos Mendoza",
            .Age = 19,
            .Gender = "Male",
            .BirthDate = "Born July 03, 2007",
            .Contact = "0919 882 1104",
            .Email = "carlos.mendoza@email.com",
            .Address = "Monumento, Caloocan City",
            .LastVisitDate = New Date(2026, 8, 14),
            .LastVisitDisplay = "Aug 14, 2026",
            .KnownConditions = "Gastroesophageal Reflux (GERD)",
            .DrugAllergies = "None reported",
            .HasAllergies = False,
            .RecordUpdated = "Record updated Aug 14 at 1:40 PM",
            .UpcomingDate = "Oct 28 • 11:00 AM",
            .UpcomingDetails = "Dr. Elena Cruz • Check-up",
            .UpcomingStatus = "Confirmed"
        }
        p5.Visits.Add(New VisitItem("Aug 14, 2026", "Consultation", "Acid reflux symptoms improved", "Dr. Elena Cruz", "Completed"))
        p5.Visits.Add(New VisitItem("Apr 20, 2026", "Check-up", "Gastric discomfort evaluation", "Dr. Elena Cruz", "Completed"))
        p5.Visits.Add(New VisitItem("Jan 15, 2026", "Consultation", "Dietary consultation", "Dr. Marco Lim", "Completed"))
        list.Add(p5)

        ' 6. Lea Mendoza
        Dim p6 As New PatientItem With {
            .PatientId = "PT-1057",
            .Name = "Lea Mendoza",
            .Age = 19,
            .Gender = "Female",
            .BirthDate = "Born October 14, 2006",
            .Contact = "0916 337 8002",
            .Email = "lea.mendoza@email.com",
            .Address = "Morning Breeze, Caloocan City",
            .LastVisitDate = New Date(2026, 9, 24),
            .LastVisitDisplay = "Sep 24, 2026",
            .KnownConditions = "None reported",
            .DrugAllergies = "None reported",
            .HasAllergies = False,
            .RecordUpdated = "Record updated Sep 24 at 10:15 AM",
            .UpcomingDate = "Nov 02 • 10:00 AM",
            .UpcomingDetails = "Dr. Marco Lim • Consultation",
            .UpcomingStatus = "Confirmed"
        }
        p6.Visits.Add(New VisitItem("Sep 24, 2026", "Consultation", "General wellness checkup", "Dr. Marco Lim", "Completed"))
        list.Add(p6)

        ' 7. Teresa Ramos
        Dim p7 As New PatientItem With {
            .PatientId = "PT-1070",
            .Name = "Teresa Ramos",
            .Age = 51,
            .Gender = "Female",
            .BirthDate = "Born May 21, 1975",
            .Contact = "0922 811 4053",
            .Email = "teresa.ramos@email.com",
            .Address = "Barangay 171, Caloocan City",
            .LastVisitDate = New Date(2026, 7, 19),
            .LastVisitDisplay = "Jul 19, 2026",
            .KnownConditions = "Migraine • Vertigo",
            .DrugAllergies = "Sulfa drugs",
            .HasAllergies = True,
            .RecordUpdated = "Record updated Jul 19 at 2:30 PM",
            .UpcomingDate = "Nov 05 • 1:30 PM",
            .UpcomingDetails = "Dr. Marco Lim • Check-up",
            .UpcomingStatus = "Confirmed"
        }
        p7.Visits.Add(New VisitItem("Jul 19, 2026", "Check-up", "Vestibular assessment", "Dr. Marco Lim", "Completed"))
        list.Add(p7)

        ' 8. Gabriel Cruz
        Dim p8 As New PatientItem With {
            .PatientId = "PT-1074",
            .Name = "Gabriel Cruz",
            .Age = 38,
            .Gender = "Male",
            .BirthDate = "Born December 03, 1987",
            .Contact = "0917 502 9941",
            .Email = "gabriel.cruz@email.com",
            .Address = "Grace Park West, Caloocan City",
            .LastVisitDate = New Date(2026, 6, 5),
            .LastVisitDisplay = "Jun 05, 2026",
            .KnownConditions = "Hyperuricemia • Gout",
            .DrugAllergies = "Aspirin",
            .HasAllergies = True,
            .RecordUpdated = "Record updated Jun 05 at 11:10 AM",
            .UpcomingDate = "Nov 12 • 9:30 AM",
            .UpcomingDetails = "Dr. Elena Cruz • Follow-up",
            .UpcomingStatus = "Confirmed"
        }
        p8.Visits.Add(New VisitItem("Jun 05, 2026", "Follow-up", "Uric acid 6.2 mg/dL", "Dr. Elena Cruz", "Completed"))
        list.Add(p8)

        ' 9. Patricia Gomez
        Dim p9 As New PatientItem With {
            .PatientId = "PT-1081",
            .Name = "Patricia Gomez",
            .Age = 29,
            .Gender = "Female",
            .BirthDate = "Born August 11, 1997",
            .Contact = "0927 344 1290",
            .Email = "patricia.gomez@email.com",
            .Address = "Bagong Barrio, Caloocan City",
            .LastVisitDate = New Date(2026, 5, 12),
            .LastVisitDisplay = "May 12, 2026",
            .KnownConditions = "Mild Gastritis",
            .DrugAllergies = "None reported",
            .HasAllergies = False,
            .RecordUpdated = "Record updated May 12 at 4:20 PM",
            .UpcomingDate = "Nov 18 • 11:00 AM",
            .UpcomingDetails = "Dr. Marco Lim • Consultation",
            .UpcomingStatus = "Confirmed"
        }
        p9.Visits.Add(New VisitItem("May 12, 2026", "Consultation", "Dyspepsia symptoms resolved", "Dr. Marco Lim", "Completed"))
        list.Add(p9)

        Return list
    End Function

End Class
