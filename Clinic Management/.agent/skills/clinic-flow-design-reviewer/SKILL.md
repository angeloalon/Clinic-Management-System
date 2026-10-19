---
name: clinic-flow-design-reviewer
description: Reviews both the user flow and the visual design of the "Clinic Management" VB.NET WinForms project (UCC Health Clinic), and researches current UI/UX best practices online to back up its findings. Use whenever the user asks to review, critique, audit, or improve the clinic app's design, layout, colors, fonts, navigation, workflow, usability, or screens (Dashboard, Patients, Appointment, Doctor, Consultation, Reports), or says things like "is my UI good?", "check my flow", or "compare my design to the mockup", even if they do not say "review".
---

# Clinic Flow + Design Reviewer

Review the app on two axes: **flow** (can a clinic receptionist/doctor complete tasks without confusion?) and **design** (does it look consistent, readable, and professional?). Base findings on the code, Designer files, and any design images the user provides. Use web search when available to check current best practices, and cite the sources you used.

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
## Step 1: Gather
List forms/UserControls and their Designer files, which sidebar button opens each, and any mockup images. Ask for missing files instead of guessing.

## Step 2: Research (online)
Search the web for current guidance relevant to what you find, for example: Nielsen's 10 usability heuristics, healthcare/clinic management dashboard UI patterns, WinForms layout and DPI guidance, WCAG color-contrast rules. Prefer original sources (Nielsen Norman Group, W3C/WCAG, Microsoft docs). Paraphrase, do not copy text, and name each source in the report. If search is unavailable, say so and use the checklists below.

## Step 3: Flow review (Nielsen heuristics applied to this app)
1. **System status**: is the current screen obvious (active sidebar highlight, screen title)? Are there loading/saved/error messages?
2. **Real-world match**: clinic wording (Patient, Appointment, Consultation) used consistently, no developer jargon.
3. **User control**: can the user cancel, go back, or clear a form? Any screen that traps them?
4. **Consistency**: same button positions, labels, and colors for Add / Edit / Delete / Save across all screens.
5. **Error prevention**: required-field checks, date validation, confirmation before delete, no duplicate patient/appointment.
6. **Recognition over recall**: dropdowns for doctors and patients rather than typing IDs.
7. **Efficiency**: tab order, Enter-key submit, search and filters on list screens.
8. **Task flow**: walk real tasks end to end and flag dead ends: register patient -> book appointment -> doctor consultation -> view in reports.

## Step 4: Design review
- **Layout**: alignment, spacing, grid consistency, Anchor/Dock behavior on resize and maximize, nothing clipped or overlapping.
- **Color**: consistent palette across screens, text/background contrast readable (aim for WCAG AA: 4.5:1 normal text), meaning of colors consistent (e.g. red only for errors/delete).
- **Typography**: one font family, clear size hierarchy (title > section > body), no text cut off.
- **Components**: FCard/FButton styles uniform, icon set consistent (FontAwesome.Sharp), table/list headers aligned and readable.
- **Admin screens**: compare each against its Figma frame in `references/ADMIN_FLOW.md` (frame names and node IDs listed there) and against the Doctor and Receptionist screens for consistent sidebar, header, tables, badges, stepper, and forms. Check sidebar icons match their labels (the design uses calendar-check for Clinic settings and message-circle for Audit log, which look wrong).
- **Fidelity**: if a mockup image exists, compare screen against it and list differences.

## Report format
- **Works well**: short.
- **Findings table**: screen, issue, heuristic or design principle, severity (Breaks / Should fix / Polish), suggested fix.
- **Quick wins**: the 3-5 changes with the most visible improvement for least effort.
- **Sources**: links to any pages used.
- **Not reviewed**: anything missing or unverifiable.

## Rules
- Only report what you actually saw in the files or images; say "could not verify" otherwise.
- Match existing naming (btnXxx) and VB.NET style in any suggested code.
- Heuristic review finds likely problems but does not replace testing with real users. Say so.
- For checking that the app builds and runs, use clinic-functional-tester instead.
