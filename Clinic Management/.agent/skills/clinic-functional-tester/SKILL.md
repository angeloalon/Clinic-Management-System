---
name: clinic-functional-tester
description: Builds, runs, and tests the "Clinic Management" VB.NET WinForms project (UCC Health Clinic) to check that it actually works. Use whenever the user asks whether the clinic app works, to test it, run it, find bugs, check that buttons/screens/forms behave, or verify a feature after a change, even if they only say "does it work?" or "test my app". Builds the solution, reports compiler errors, and drives the running app with FlaUI UI-automation tests. For code-reading design/flow review use clinic-ui-reviewer instead.
---

# Clinic Functional Tester

Goal: prove what works and what breaks by **building and running** the app, not by guessing from code.

## Requirements (check first, tell the user if missing)
- Windows machine with the .NET SDK or Visual Studio Build Tools (WinForms apps do not run on Mac/Linux).
- A desktop session. UI automation needs a real, unlocked desktop, so it will not work headless or over a locked screen.
- If the agent runs somewhere that is not Windows, stop after step 1's static checks and give the user the manual checklist instead.

## Project facts
- VB.NET WinForms "Clinic Management" (UCC Health Clinic) at `D:\repos\Clinic Management\Clinic Management`. There is no `Form1`. Entry point: `LoginForm` (role selector: Receptionist / Doctor / Administrator).
- **Read `references/STRUCTURE_FLOW.md` first.** It is the user's own architecture document (diagrams, navigation, data model). Treat it as the *intended design*: verify it against the real code and report drift (screens in the doc but missing, or in the code but undocumented).
- Summary: `LoginForm` -> `DoctorShell` (SidebarHandler + tab viewport) or `ReceptionistDashboard` (host form that swaps views inside `mainScreen`). Shared in-memory services: `PatientRepository` (patients, visits) and `ClinicData` (appointments, timetable slots, vitals). Entities: `PatientItem`, `VisitItem`, `AppointmentItem`, `SlotItem`. Modal dialogs: `DoctorPrescriptionDialog`, `DoctorLaboratoryDialog`.
- Doctor screens: DoctorDashboard, DoctorPatients, DoctorPatientInformation, DoctorAppointment, DoctorsSchedule, DoctorConsultation, DoctorReports.
- Receptionist screens: pnlDashboard, ReceptionistPatients, ReceptionistRegisterPatient, ReceptionistPatientInformation, ReceptionistAppointment, ReceptionistDoctorSchedules, ReceptionistConsultation, ReceptionistConsultationDetail, ReceptionistClinicReports.
- Administrator screens (designed in Figma, may not be built yet): sign-in states (error, account locked, first-sign-in set password), admin dashboard, user management, Add user wizard (3 steps), clinic settings, audit log. **Read `references/ADMIN_FLOW.md`** for the full spec, frame node IDs, and known design issues. Code names are unknown: discover them. If a screen is not built, report "not implemented", not "bug".
- Third-party libraries (e.g. Ferrando.UI.WinForms, FontAwesome.Sharp) may be used: confirm in the project references. Real control and button names come from the .Designer.vb files.
- If a file is missing from the workspace, ask the user to add it. Do not guess its contents.
- Report first. Do not change code unless the user approves.

## Known risks to verify (from the architecture doc)
1. **Two navigation patterns**: Doctor uses `DoctorShell` + `SidebarHandler`; Receptionist swaps views inside `mainScreen`. Check for duplicated navigation code, and that sidebar highlight and "current screen" feedback work on both sides.
2. **In-memory data**: `PatientRepository` and `ClinicData` are shared in-memory. Confirm whether anything persists after the app closes. If not, state it as a limitation, not a bug, unless the user expects persistence.
3. **Hard-coded dates**: the doctor appointment screen shows day tabs (Day 21-25), and `AppointmentItem` stores only Day and Minutes (no month/year). Check for hard-coded days and wrong behavior across month boundaries.
4. **Status vocabulary**: the workflow says "Pending / Waiting" but the data model lists Pending / Confirmed / Completed / Cancelled. Check that "Waiting" is handled the same way everywhere, including dashboard counters (Today's Appointments, Waiting Now, Completed, Cancelled) on both sides.
5. **Consultation sync**: completing a consultation should set the appointment to Completed, add a `VisitItem` to patient history, and update dashboard counts and the receptionist consultation log. Trace this end to end.
6. **Drafts**: `IsDraft` consultations: check they can be saved, resumed, and are not counted as completed.
7. **Allergy visibility**: drug-allergy warning shows in the patient record and consultation, and in the prescription dialog. Judge visibility and workflow only, not clinical correctness.
8. **Dialogs**: prescription and laboratory sheets are printable; check print/preview works and shows the right patient and data.
9. **Loose ends in the flow**: "Patient Discharged / Follow-Up Scheduled" has no listed screen; check whether a follow-up can actually be booked.
10. **Naming**: `DoctorsSchedule` vs `ReceptionistDoctorSchedules`. Flag it, do not rename without approval.
11. **Existence**: confirm every screen listed above exists as a .vb/.Designer.vb/.resx file.
12. **Admin accounts and passwords**: accounts the admin creates must work with the login (Invited -> set password -> Active). Passwords must be hashed, never stored or shown in plain text, and the admin must not set the staff member's password (one-time invite code only).
13. **Lockout**: 5 failed attempts lock the account for 15 minutes, the screen shows attempts used and unlock time, and the event is logged. Check the counter resets after a successful sign-in.
14. **Role from account, not selector**: the sign-in role selector must not let someone enter a role their account does not have. Mismatch gives the generic "Incorrect email or password" message.
15. **Verification code**: doctors are marked "Required at every sign-in" in Add user Step 3, but no verification screen is designed. Check whether it exists in code.
16. **Missing admin destinations**: Forgot password, Reset password, Edit user, Suspend/Reactivate, Resend invite, Leave requests, Accounts to review, holidays/closures in Clinic settings. Report which exist.
17. **Admin cannot read clinical notes**: attempts are blocked and logged as Denied. Verify the admin shell has no route to patient records or consultations.
18. **Audit log**: sign-ins (success and failed), user created, password reset, clinic hours edited, availability updated, blocked access. Entries cannot be edited or deleted, Export CSV is itself logged.
19. **Settings drive the rest of the app**: opening hours and appointment types set in Clinic settings must be what the receptionist's booking and the doctor's schedule use. Note the mismatch between design appointment types (General consultation, Follow-up, Check-up, Vaccination) and VisitType (Follow-up, Consultation, Check-up).
20. **Counts consistency**: dashboard "Active staff", "Staff by role", and the User management table must agree with each other and with account statuses (Active, On leave, Invited, Suspended).
21. **Persistence**: user accounts, audit log, and settings must survive closing the app. If the shared services are in memory, flag it as a Should fix for admin data.
22. **Invite code**: the admin sees the one-time code once after Create user. Only a salted hash of the code is stored, with a 72-hour expiry and a used flag. Check: code is generated with a secure random generator (not `Random`), single use, rejected when expired or reused, wrong attempts count toward the 5-attempt lockout, "First time signing in?" and Enter-invite-code screens exist, Resend invite replaces the old code, the Invited account cannot sign in with a password, and audit entries exist (created, used, invalid, resent, password set).

## Role-based checks (always include)
- **Login**: valid and invalid credentials, empty fields, Enter key submits, password masked, clear generic error message with attempts remaining, lockout after 5 attempts for 15 minutes, no credentials hard-coded in code or stored in plain text.
- **Role routing**: Doctor login opens `DoctorShell`, Receptionist login opens `ReceptionistDashboard`, Administrator login opens the admin dashboard, and no role can reach another role's screens. The admin cannot open patient records or consultation notes.
- **Logout/switch user**: exists on both sides, returns to `LoginForm`, and clears the previous user's data from screens.
- **Parity**: shared concepts (Patients, PatientInformation, Consultation, Reports) look and behave consistently across roles, differing only where the role needs it.
- **Core flow** (from the doc): receptionist registers or finds a patient -> books/queues appointment -> check-in (Pending/Waiting) -> doctor sees the live queue -> opens consultation -> notes, optional prescription or lab request -> completes -> history syncs -> receptionist log shows it. Flag every dead end and every step where data does not carry over.
- **Admin flow**: admin adds a user (3-step wizard) -> account is Invited -> admin sees a one-time invite code -> staff enters email + code -> staff sets a password -> account becomes Active -> appears in User management and the audit log. Also check: suspend/reactivate, password reset, unlock, clinic settings changes reaching booking and schedules.
## Procedure
1. **Build**: run `dotnet build` (or `msbuild` for .NET Framework projects) on the solution. Report every error and warning with file and line. Fix nothing until the user approves. If it fails to build, stop here and report.
2. **Smoke run (starts at LoginForm)**: launch the built .exe. Confirm the main window ("UCC Health Clinic") opens without an unhandled exception and shows its navigation and content area.
3. **Login and navigation test**: log in as a receptionist, a doctor, and an administrator (ask the user for test accounts; never guess or bypass passwords). For each role, click every navigation button in turn (find real names in the Designer files). After each click check: the expected screen appears in the content panel, no exception dialog, and the clicked button is the highlighted one (pressed style) while the others are reset.
3a. **Administrator tests** (test data only): sign in as an admin; add a user through all 3 wizard steps with valid data, then with a duplicate email and a bad mobile number; confirm the new account shows as Invited and a one-time invite code is shown once; then test "First time signing in?": a wrong code (counts toward lockout), an expired or reused code (rejected), and the right code, which leads to setting a password (12+ characters, a number, a symbol); confirm the user can then sign in and the account becomes Active. Confirm the Invited account cannot sign in with a password before that. Fail sign-in 5 times and confirm the lock (15 minutes), attempts counter, and audit entry. Suspend and reactivate an account. Change opening hours or an appointment type and confirm the receptionist's booking reflects it. Confirm the audit log records each action and that the admin cannot open patient records or consultation notes.
4. **Per-screen tests**: for every screen that has logic, test the happy path (valid input saved/shown), invalid input (empty required fields, bad dates, duplicates), search/filter boxes, and empty-data states. Record expected vs. actual.
5. **Resize and repeat**: maximize and restore the window, re-click sidebar buttons rapidly 20 times, confirm no stacked screens, flicker-lock, or crash.
6. **Data and sync check**: data is shared in memory (`PatientRepository`, `ClinicData`), so test that a patient registered by the receptionist appears for the doctor, that completing a consultation updates history, counters, and the receptionist log, and what happens to the data when the app is closed and reopened. Test the prescription and laboratory dialogs (open, fill, print preview). Use test data only.

## Automating the clicks (FlaUI)
FlaUI is a .NET library for UI-testing Windows apps including WinForms. Create a small test project next to the solution (VB.NET, MSTest or NUnit) and add NuGet packages `FlaUI.Core` and `FlaUI.UIA2` (UIA2 is the safer choice for WinForms). Sketch:

```vb
Using app = FlaUI.Core.Application.Launch("path\to\ClinicManagement.exe")
    Using automation As New FlaUI.UIA2.UIA2Automation()
        Dim win = app.GetMainWindow(automation)
        Dim btn = win.FindFirstDescendant(Function(cf) cf.ByAutomationId("btnPatients")).AsButton()
        btn.Invoke()
        ' assert the matching screen is now shown in the content panel
    End Using
End Using
```

- WinForms exposes a control's `Name` as its AutomationId, so the button names from the Designer file are what tests look up.
- Third-party controls (Ferrando `FButton`, `FCard`) may be custom-drawn and not appear in the UI tree. If `FindFirstDescendant` returns nothing, set `AccessibleName` on those controls or fall back to clicking by screen coordinates, and tell the user which controls were unreachable.
- Keep tests in the repo so the user can re-run them after every change.

## Report format
- **Build**: pass/fail with errors.
- **Results table**: test, expected, actual, pass/fail.
- **Bugs found**: steps to reproduce, severity (Breaks / Should fix / Polish).
- **Not tested**: anything skipped and why.

## Rules
- Never claim something works unless a test actually ran it. Say "not tested" otherwise.
- Do not modify project code to make a test pass. Report the bug.
- Do not delete or overwrite the user's real data; test against a copy of any CSV/database file.
