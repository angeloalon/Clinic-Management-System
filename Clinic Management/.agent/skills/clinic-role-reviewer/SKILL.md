---
name: clinic-role-reviewer
description: Reviews the "Clinic Management" VB.NET WinForms project (UCC Health Clinic) from several expert and user viewpoints in turn: senior developer, UX designer, QA tester, receptionist, doctor, and administrator (security and account management). Use whenever the user asks to review, check, or critique the clinic app "as a senior developer", "as a doctor", "as a receptionist", "from the user's side", or wants a multi-perspective or second-opinion review of the code, screens, workflow, or design, even if they do not name the roles.
---

# Clinic Role Reviewer

Review the project through separate **lenses**. Each lens has a concrete checklist and a fixed job, because a bare "act as an expert" instruction adds little by itself: put the real value in the steps each role follows. Run each lens as its own pass, in order, and keep findings labeled by lens. Search online for current guidance when the web is available, and name the sources used.

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
## Lens 1: Senior developer (code quality)
Read the .vb and .Designer.vb files. Check: naming consistency (btnXxx), duplicated code between screens, long handlers that should be split, magic numbers for colors/sizes, handlers wired twice (Handles plus AddHandler), unused controls, `Option Strict On`, resource disposal (connections, files, old controls removed from the content panel), error handling around file/database access, hard-coded paths, SQL built by string concatenation (injection risk), and passwords or secrets in code. For each issue: file, line or control, why it matters, a short fix.

## Lens 2: UX designer (flow and look)
Apply Nielsen's usability heuristics: visible system status (active sidebar highlight, saved/error messages), clinic-friendly wording, cancel/back/undo available, consistent Add/Edit/Delete/Save placement, error prevention (required fields, delete confirmation), dropdowns instead of typing IDs, tab order, Enter-key submit. Check layout alignment, Anchor/Dock on resize, color contrast (aim for WCAG AA 4.5:1), one font family, consistent FCard/FButton styling. Compare to any mockup image the user provides.

## Lens 3: QA tester (what could break)
List test cases per screen: empty required fields, wrong data types, very long text, duplicate entries, invalid or past dates for appointments, delete of a record that other screens use, rapid repeated clicks, resize/maximize, closing with unsaved input, missing or locked data file. State which are handled in the code and which are not. For running the app and automating clicks, defer to clinic-functional-tester.

## Lens 4: Receptionist (daily user)
Using the Receptionist* screens, walk the tasks a front-desk user does most: register a new patient, search an existing patient, book/reschedule/cancel an appointment, see today's queue. Count clicks per task, flag anything slow, confusing, or easy to do wrong, and anything missing that a receptionist would expect (search box, today's appointments on the dashboard, clear status labels).

## Lens 5: Doctor (consultation workflow)
Using the Doctor* screens, walk the doctor's tasks: see today's patients, open a patient's history, record a consultation (complaint, diagnosis, notes, prescription), schedule a follow-up. Check that the needed fields exist, are in a sensible order, and that previous visits are easy to find. Also check privacy basics: patient data not shown unnecessarily, no data in plain-text files without the user being aware.
**Important:** this lens judges workflow and usability from a clinician's viewpoint only. Do not give medical advice, and do not claim to verify clinical correctness (dosage, diagnosis lists, medical terms). Flag those items as "needs review by a real clinician or the instructor."

## Lens 6: Administrator (account management and security)
Using the admin screens in `references/ADMIN_FLOW.md`, walk the admin's tasks: sign in, add a user through the 3-step wizard, handle validation errors, invite and first sign-in, suspend/reactivate, reset a password, unlock a locked account, change clinic hours and appointment types, read and export the audit log. Check: the invite flow matches "What happens next", passwords are hashed and never admin-set, lockout works, the admin is blocked from clinical notes and the attempt is logged, every admin action writes an audit entry, destructive actions ask for confirmation, and dashboard counts match the tables. Check the design issues listed at the end of `ADMIN_FLOW.md` against the code. For privacy of patient and staff data, flag anything that should be confirmed against the Philippine Data Privacy Act with the instructor; do not give legal advice.

## Report format
For each lens: **Looks fine** (short), then a findings table (issue, where, severity: Breaks / Should fix / Polish, suggested fix). End with:
- **Top 5 fixes** across all lenses, ordered by impact.
- **Conflicts**: where two lenses disagree (e.g. more fields for the doctor vs. fewer clicks for the receptionist) with a recommended trade-off.
- **Sources** used and **Not reviewed** items.

## Rules
- Only report what you actually saw in the files or images. Say "could not verify" otherwise, and ask for missing files.
- Do not invent features the project lacks as if they exist; label them "missing".
- Match the project's VB.NET style in any suggested code.
- A role-based review is a structured opinion, not proof. Say that real users (a receptionist, a clinician) should try the app before it is called finished.
