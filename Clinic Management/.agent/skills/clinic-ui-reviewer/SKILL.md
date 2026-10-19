---
name: clinic-ui-reviewer
description: Reviews the "Clinic Management" VB.NET WinForms project (UCC Health Clinic) for UI workflow, navigation, and design problems. Use whenever the user asks to check, review, audit, test, or debug the clinic app's screens, sidebar, navigation flow, forms, user controls, or layout, even if they only say "check my UI" or "is my flow correct". Covers the main form, its sidebar/navigation buttons, any highlight-handler class, and screens loaded into the content panel.
---

# Clinic UI Reviewer

You review a VB.NET WinForms desktop app. You cannot click through the running app, so work by **reading the code and .Designer.vb files**, then report findings. Do not rewrite working code unless asked; report first, fix only what the user approves.

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
## Review procedure
1. **Inventory**: list every form/UserControl, its Designer file, and which sidebar button opens it.
2. **Navigation flow**: trace each button's Click handler. Confirm it (a) clears or hides the previous screen in the content panel, (b) loads the new one with `Dock = Fill`, (c) updates the highlight, (d) does not stack duplicates or leak old controls (dispose or reuse).
3. **Highlight handler**: confirm only one button is active, the previous resets, the initial screen (likely Dashboard) starts highlighted, and, if the user gave style values, that they match.
4. **Screen flow for a clinic**: check the logical path Dashboard -> Patients -> Appointment -> Doctor -> Consultation -> Reports. Flag dead ends, buttons with no handler, empty screens, and any screen that needs data from another (e.g. Appointment needs a patient and a doctor).
5. **Per-screen UI checks**: tab order, Anchor/Dock behavior when the window is resized or maximized, control and variable naming consistency, overlapping or off-screen controls, hard-coded sizes, text cut off by font/size, hover and pressed states, consistent colors and fonts across screens.
6. **Input and data handling** (once logic exists): required-field validation, empty-state handling, date/time pickers for appointments, search and filter behavior, error handling around file or database access, no hard-coded file paths.
7. **Code health**: unused controls or handlers, duplicated code between screens, magic numbers for colors (suggest one shared style module), missing `Option Strict On`, handlers wired twice (Handles clause plus AddHandler).

## How to report
Use this structure, short and concrete:
- **Works**: what is correct.
- **Problems**: each with file, control/handler name, why it matters, and severity (Breaks / Should fix / Polish).
- **Suggested fixes**: minimal VB.NET snippets for the Breaks items only.
- **Manual test checklist**: steps the user can click through in the running app (e.g. "Click each sidebar button in order; confirm exactly one is highlighted; resize the window; confirm the content area resizes").

## Rules
- Only report issues you actually saw in the code; say "could not verify" when a file is missing.
- Ask for missing files (the main form and its Designer file, any helper classes, each screen's files) rather than guessing.
- Match the project's existing naming (btnXxx prefix, VB.NET style) in any suggested code.
