# Administrator Part — Design Spec (from Figma)

Source: Figma file "Clinic Management System", page "Admin" (fileKey `EkgxAg3d9mF239k7ehHZYe`, node `130-2`).
https://www.figma.com/design/EkgxAg3d9mF239k7ehHZYe/Clinic-Management-System?node-id=130-2

This is the **intended design** for the Administrator role. Verify the code against it. If a screen is not built yet, report "not implemented", not "bug".

## Frames (name -> node id)
| Frame | Node |
|---|---|
| Sign in - Administrator | 134:2 |
| Sign in - Error | 134:63 |
| Account locked | 134:183 |
| Set password - first sign in | 134:240 |
| Admin dashboard | 130:3 |
| User management | 131:2 |
| Add user - Step 1 Account details | 137:2 |
| Add user - Step 1 Validation errors | 137:134 |
| Add user - Step 2 Role and access | 137:269 |
| Add user - Step 3 Review and send | 138:2 |
| Clinic settings | 131:148 |
| Audit log | 131:269 |

If a Figma connection is available, fetch these frames for visual comparison. If not, rely on this text.

## Shared shell
Sidebar (232 px): brand "Clinic Management / UCC Health Clinic", nav Dashboard, User management, Clinic settings, Audit log, and a user card (Rosa Dela Cruz, Clinic Administrator). Sidebar icons in the design: layout-dashboard, user, calendar-check, message-circle (in that nav order).

## Screens
1. **Sign in**: role selector (Receptionist / Doctor / Administrator), email, password, "Forgot password?", "Sign in securely", note "Authorized clinic personnel only".
2. **Sign in - Error**: "Incorrect email or password. 2 of 5 attempts remaining." with helper "Check your password and try again."
3. **Account locked**: after 5 of 5 attempts; shows unlock time (15 minutes), attempts used, account email; actions "Reset password" and "Contact another administrator"; "This event was recorded in the audit log."
4. **Set password - first sign in**: for invited staff ("Your administrator invited you as a Receptionist"); new password + confirm; rules: at least 12 characters, one number, one symbol; "Save password and continue".
5. **Admin dashboard**: stat cards Active staff (12, +1 this week), Appointments today (38, 6 awaiting confirmation), Leave requests (3, pending approval), Accounts to review (2, inactive 30+ days); Recent activity feed; Staff by role (Doctors 5, Receptionists 4, Administrators 3; "12 active accounts - 0 suspended"); "+ Add user".
6. **User management**: "12 staff accounts - 3 roles"; search; filters All roles / All statuses; table Name, Email, Role, Status, Last active, Edit; statuses Active, On leave, Invited, Suspended; Role permissions card (Doctor: patient records, consultations, own schedule; Receptionist: patient registration, appointments, all doctor schedules).
7. **Add user (3-step wizard)**: Step 1 Account details (names/username, work email, mobile, staff ID auto-generated, start date; validation: duplicate email, invalid mobile; "What happens next": account saved as Invited -> invitation email with link that expires in 72 hours -> staff sets password -> account becomes Active and is recorded in the audit log). Step 2 Role and access (Doctor or Receptionist card; Doctor details: specialty, PRC license number, default consultation length, assigned clinic; Access preview). Step 3 Review and send (account + role summary with Edit links; doctor shows "Verification code: Required at every sign-in"; Back / Create user).
8. **Clinic settings**: clinic profile (name, type, address, contact number, email, default appointment length), opening hours (Mon-Fri 8-5, Sat 8-12, Sun closed), appointment types (General consultation 30, Follow-up 15, Check-up 45, Vaccination 15 min); Save changes.
9. **Audit log**: "Every sign-in and record change, for accountability"; search; filters users / actions / date range; Export CSV; table Time, User, Role, Action, Details, Result (Success / Failed / Denied). Example events: availability updated, appointments booked, user created, password reset, "Record access blocked - Admins cannot open clinical notes" (Denied), clinic hours edited, failed and successful sign-ins.

## Core admin flows
- Admin signs in -> dashboard -> Add user -> 3 steps -> account Invited -> admin sees a one-time invite code -> staff enters email + code -> staff sets password -> Active -> visible in User management and the audit log.
- Failed sign-ins: counted, shown ("n of 5 remaining"), lock at 5 for 15 minutes, logged.
- Admin never opens clinical notes; the attempt is Denied and logged.

## Decision: one-time invite code (chosen approach)
The desktop app has no email server, so invitations use a one-time code instead of an emailed link.
1. After "Create user" the admin sees a success screen with a generated code (format `XXXX-XXXX`, letters and digits without 0/O/1/I) and a Copy button. The code is shown **once**.
2. The account is saved with status **Invited**. Store only a salted hash of the code, its expiry (72 hours), and a used flag. Never store the code itself.
3. The admin gives the code to the staff member in person or by message. Optionally the app also writes a simulated invitation to an "Outbox" screen or text file, clearly labelled as simulated.
4. On the sign-in screen the staff member clicks **First time signing in?**, enters their work email and the code, then lands on **Set password - first sign in**.
5. The code works once and only before it expires. Wrong codes count toward the same 5-attempt lockout (15 minutes) as sign-in. Expired or used codes show a clear message and the admin can **Resend invite** (new code, old one invalid).
6. A password is saved only as a salted hash (e.g. PBKDF2). The account becomes **Active**. While status is Invited, normal password sign-in must be refused.
7. Audit log entries: Invitation created, Invitation used, Invitation expired or invalid (Failed), Invitation resent, Password set.
Use a cryptographically secure random generator for codes, not `Random`.

New screens this needs in Figma: "First time signing in?" link, Enter invite code, Code expired or invalid state, Create-user success screen showing the code, Resend invite action in User management.

## Issues found in the design (fix or decide before building)
1. Add user Step 1 has two different field sets: one version has Username and Password, the "Validation errors" version has First name and Last name. Step 3 then shows both Username and Password and a full Name.
2. The admin types a Password in Step 1, but "What happens next" says the staff member sets their own password. Remove the admin-set password and use the one-time invite code (see Decision above). Also change "secure link that expires in 72 hours" to "one-time code that expires in 72 hours".
3. Doctors need a verification code "at every sign-in" (Step 3), but no verification-code sign-in screen exists.
4. The sign-in role selector lets the user choose a role. Role should come from the account; a mismatch should fail with the same generic error.
5. "Forgot password?" and "Reset password" have no destination screens.
6. User management rows only offer "Edit". No Reset password, Unlock, Suspend/Reactivate, Resend invite (invite expires in 72 hours), or Deactivate actions, and no Edit user screen.
7. Dashboard cards "Leave requests (3)" and "Accounts to review (2)" have no screen to act on them; the sidebar has only four items. Nothing in the Doctor part creates a leave request.
8. Dashboard says "12 active accounts - 0 suspended", but User management lists a Suspended, an Invited, and an On leave account. Define what "active" counts.
9. "Administrators: 3" but the table shows one administrator and no pagination. Step 2 cannot create an Administrator; decide if that is intended.
10. Sidebar icons do not match: Clinic settings uses calendar-check, Audit log uses message-circle.
11. Clinic settings has no holidays/closures section, yet the audit log and dashboard show "All Saints' Day closure added".
12. Appointment types here (General consultation, Follow-up, Check-up, Vaccination) differ from the app's VisitType values (Follow-up, Consultation, Check-up).
13. No Admin logout/profile menu design, no success state after "Create user", no pagination or empty states on lists.
14. Export CSV in the audit log should itself be logged, and the log should be read-only (no delete or edit).
