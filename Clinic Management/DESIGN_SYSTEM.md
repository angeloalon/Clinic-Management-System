# Clinic Management System — UI & Design System Specification

> Extracted directly from the application codebase (`LoginForm`, `DoctorDashboard`, `DoctorPatients`, `DoctorPatientInformation`, and `SidebarHandler`).

---

## 1. Typography Hierarchy & Font Specifications

The application utilizes two primary font families:
- **`Noto Sans Georgian`**: Sidebar branding, navigation buttons, and profile credentials.
- **`Segoe UI`**: Forms, dashboards, tables, KPI metrics, buttons, inputs, and status badges.

### Font Family & Size Matrix

| Font Family | Size (`pt`) | Style / Weight | UI Role / Usage | Associated Controls & Screen Context |
| :--- | :--- | :--- | :--- | :--- |
| **Segoe UI** | **`25.0 pt`** | Regular | KPI Metric Value | Dashboard numerical statistics (`lblCard1Value`, `lblCard2Value`, `lblCard3Value`, `lblCard4Value`) — Displays *"3"*, *"2"*, *"1"*, *"0"* |
| **Segoe UI** | **`24.0 pt`** | Regular | Hero Headline | Login form hero title (`lblHeroTitle`): *"Care coordination,\nclearly managed."* |
| **Segoe UI** | **`18.0 pt`** | Regular | Primary Page Title (H1) | • `DoctorDashboard.lblGreeting`: *"Good morning, Dr. Cruz"*<br>• `DoctorPatients.lblHeaderTitle`: *"My Patients"*<br>• `DoctorPatientInformation.lblPatientName`: *"Maria Santos"* |
| **Segoe UI** | **`16.0 pt`** | Bold | App Logo Glyph | Login logo symbol (`lblLogo`): `"+"` |
| **Segoe UI** | **`16.0 pt`** | Regular | Card Header (H2) | Login modal heading (`lblWelcome`): *"Welcome back"* |
| **Noto Sans Georgian Bold** | **`12.0 pt`** | Bold | Active Nav & Brand | • Sidebar active navigation button (`ActiveFont` in `SidebarHandler.vb`)<br>• Sidebar logo (`Label3`): `"+"` |
| **Noto Sans Georgian** | **`12.0 pt`** | Regular | Inactive Nav Button | Inactive sidebar menu buttons (`btnDashboard`, `btnPatients`, `btnAppointment`, `btnDoctor`, `btnConsultation`, `btnReports`) |
| **Noto Sans Georgian Bold** | **`11.25 pt`** | Bold | User Profile Name | Doctor name in sidebar profile card (`txtName`): *"Dr. Elena Cruz"* |
| **Segoe UI** | **`10.5 pt`** | Bold | Primary Card Header | • Dashboard appointments header (`lblApptsHeader`)<br>• Patient directory table header (`lblCardTitle`) |
| **Segoe UI** | **`10.0 pt`** | Bold | Section / Card Title | • Card titles: *"Quick actions"*, *"Recent patients"*, *"Demographics"*, *"Medical history"*, *"Visit timeline"*, *"Upcoming appointments"*<br>• Upcoming appointment date (`lblUpcomingDate`): *"Oct 20 • 9:00 AM"* |
| **Segoe UI** | **`9.75 pt`** | Bold | Sidebar App Title | Sidebar brand header (`Label1`): *"Clinic Management"* |
| **Segoe UI** | **`9.5 pt`** | Regular | Hero Subtitle & Inputs | • Login hero subtitle (`lblHeroSubtitle`)<br>• Text inputs (`txtEmail`, `txtPassword`)<br>• Empty table search state notice (`lblEmpty`)<br>• Search icon (`lblSearchIcon`): *"🔍"* |
| **Segoe UI** | **`9.0 pt`** | Bold | Metric Titles & Row Time | • KPI card labels: *"Today's appointments"*, *"Waiting now"*, *"Completed"*, *"Cancelled"*<br>• Schedule timestamps: *"8:00 AM"*, *"10:30 AM"*, *"3:30 PM"* |
| **Segoe UI** | **`9.0 pt`** | Regular | Subtitles & Primary Rows | • Screen header subtitles (`lblSubtitle`, `lblHeaderSubtitle`, `lblPatientSubtitle`)<br>• Patient name in table rows (`lblPatient`, `lblRow1Patient`)<br>• Search input text (`txtSearch`)<br>• Dropdown filter menus (`cmsFilterAll`, `cmsFilterVisit`) |
| **Noto Sans Georgian** | **`9.0 pt`** | Regular | User Profile Role | Doctor role subtitle in sidebar profile card (`txtRole`): *"General Physician"* |
| **Segoe UI** | **`8.75 pt`** | Regular | Feed List Items | Recent patient items (`lblRecent1`, `lblRecent2`, `lblRecent3`): *"Maria Santos • PT-1048"* |
| **Segoe UI** | **`8.5 pt`** | Bold | Buttons & Filters | • Login submit button (`btnSignIn`): *"Sign in securely"*<br>• Active role button (`btnRoleDoctor`)<br>• Quick action buttons (`btnScheduleAppt`, `btnOpenConsultation`)<br>• Dropdown filter buttons (`btnFilterAll`, `btnFilterVisit`) |
| **Segoe UI** | **`8.5 pt`** | Regular | Table Data & Details | • Table column headers (`lblColPatient`, `lblColPatientId`, `lblColAgeSex`, `lblColContact`, `lblColLastVisit`)<br>• Table secondary cells (ID, Contact, Visit Date, Doctor)<br>• Inactive role button (`btnRoleReceptionist`)<br>• Demographics field values (`lblAgeSex`, `lblBirthDate`, `lblPhone`, `lblEmail`, `lblAddress`)<br>• Medical conditions and timeline details |
| **Segoe UI** | **`8.25 pt`** | Regular | Footers & Navigation | • KPI context text: *"2 remaining"*, *"Avg. 11 min"*, *"67% of today"*, *"2 rescheduled"*<br>• Back button (`btnBackToPatients`): *"← Back to Patients"* |
| **Segoe UI Light** | **`8.25 pt`** | Regular | Sidebar Brand Sub-Label| Sidebar sub-caption (`Label2`): *" UCC Health Clinic"* |
| **Segoe UI** | **`8.0 pt`** | Bold | Badges & Brand Tagline | • Status Badges: *"Completed"*, *"Pending"*, *"Confirmed"*<br>• Login footer mark: *"UNIVERSITY OF CALOOCAN CITY • HEALTH CLINIC"* |
| **Segoe UI** | **`7.5 pt`** | Bold | Eyebrow Section Headers | Uppercase field headers: *"EMAIL ADDRESS"*, *"PASSWORD"*, *"KNOWN CONDITIONS"*, *"DRUG ALLERGIES"* |
| **Segoe UI** | **`7.5 pt`** | Regular | Security Notice | Login disclaimer (`lblNotice`): *"⦿ Authorized clinic personnel only"* |

---

## 2. Color Palette & Roles

### A. Primary Brand & Accent Colors (Medical Teal)
| Token Name | Hex Code | RGB | Usage in System |
| :--- | :--- | :--- | :--- |
| **Teal Primary / Accent** | `#238978` | `rgb(35, 137, 120)` | • Brand logo container (`cardLogo`, `FCard1`)<br>• Active role tab text on Login (`btnRoleDoctor`)<br>• Border highlight on hover/focus for inputs & search bar<br>• Border and text on secondary button hover (`btnScheduleAppt`, `btnBackToPatients`) |
| **Teal Action / Button** | `#1D7C6B` | `rgb(29, 124, 107)` | Primary action button background (`btnSignIn`) |
| **Teal Dark / Button Hover**| `#17695A` | `rgb(23, 105, 90)` | Primary action button hover state (`btnSignIn.MouseEnterBackColor`) |

### B. Dark Navy & Slate (Sidebar & Hero)
| Token Name | Hex Code | RGB | Usage in System |
| :--- | :--- | :--- | :--- |
| **Sidebar Navy (Deep)** | `#113646` | `rgb(17, 54, 70)` | • Sidebar background (`sideBar`)<br>• Login hero left panel (`leftPanel`)<br>• Normal inactive sidebar button background (`DefaultBack`) |
| **Sidebar Navy (Active / Hover)** | `#274957` | `rgb(39, 73, 87)` | • Active sidebar button background (`ActiveBack`)<br>• Inactive sidebar button hover background (`MouseEnterBackColor`) |
| **Sidebar Profile Slate** | `#1D404F` | `rgb(29, 64, 79)` | Sidebar profile card container (`namePlaceHolder`) |
| **Sidebar Nav Inactive Text** | `#B6CCD2` | `rgb(182, 204, 210)` | Inactive sidebar menu button text (`DefaultFore`) |
| **Sidebar Nav Active Text** | `#FFFEFF` | `rgb(255, 254, 255)` | Active navigation text (`ActiveFore`), doctor name (`txtName`), and logo mark (`+`) |
| **Sidebar Role Subtitle Text** | `#C8D7E1` | `rgb(200, 215, 225)` | Doctor role designation in profile card (`txtRole`) |
| **Hero Muted Subtitle** | `#B4CCD4` | `rgb(180, 204, 212)` | Hero description text on Login left panel |
| **Hero Brand Tagline** | `#5F8291` | `rgb(95, 130, 145)` | Institution tagline on Login left panel (`lblFooterBrand`) |

### C. Canvas & Surface Colors
| Token Name | Hex Code | RGB | Usage in System |
| :--- | :--- | :--- | :--- |
| **App Canvas Background** | `#F4F7F9` | `rgb(244, 247, 249)` | Main content workspace background (`mainScreen`) |
| **Login Canvas Background**| `#F6F8FA` | `rgb(246, 248, 250)` | Right panel background on Login (`rightPanel`) |
| **Pure White Surface** | `#FFFFFF` | `rgb(255, 255, 255)` | Cards (`FCard`), dropdown filter buttons, table rows, and input boxes |
| **Table Row Hover Surface**| `#F6F9FB` | `rgb(246, 249, 251)` | Patient table rows on cursor hover |
| **Secondary Button Hover** | `#F5F9FB` | `rgb(245, 249, 251)` | Hover background for secondary action buttons (`btnScheduleAppt`, `btnBackToPatients`) |
| **Filter Button Hover** | `#F8FAFC` | `rgb(248, 250, 252)` | Hover background for filter dropdown buttons (`btnFilterAll`, `btnFilterVisit`) |
| **Role Switcher Track / Inactive** | `#F3F6F8` | `rgb(243, 246, 248)` | Role switcher container background (`pnlRoleSwitcher`) & inactive tab |

### D. Borders & Dividers
| Token Name | Hex Code | RGB | Usage in System |
| :--- | :--- | :--- | :--- |
| **Card Default Border** | `#E8EDF0` | `rgb(232, 237, 240)` | Standard border for white cards (`cardLogin`, KPI cards, tables, timeline) |
| **Card Hover / Button Border** | `#D2DEE4` | `rgb(210, 222, 228)` | Card border on hover (`BorderHoverColor`) and secondary button borders |
| **Input Box Border** | `#DCE4E8` | `rgb(220, 228, 232)` | Borders for email & password cards (`cardEmailBox`, `cardPasswordBox`) |
| **Pill / Sub-Button Border**| `#DCE6EB` | `rgb(220, 230, 235)` | Active role pill border (`btnRoleDoctor`) and back button border |
| **Switcher Track Border** | `#EBF0F3` | `rgb(235, 240, 243)` | Outer border of role switcher track (`pnlRoleSwitcher`) |
| **Divider Line** | `#F2F4F7` | `rgb(242, 244, 247)` | 1px horizontal dividers between rows, header lines, and timeline events |

### E. Typography & Text Colors
| Token Name | Hex Code | RGB | Usage in System |
| :--- | :--- | :--- | :--- |
| **Title Dark Teal** | `#163341` | `rgb(22, 51, 65)` | Primary page titles (`lblGreeting`, `lblHeaderTitle`, `lblPatientName`, `lblWelcome`) and large KPI numbers |
| **Card Header Dark Slate** | `#1E2D37` | `rgb(30, 45, 55)` | Card headers, table titles, text inputs (`txtEmail`, `txtPassword`), and active search text |
| **Primary Body Slate** | `#232D37` | `rgb(35, 45, 55)` | Patient names in tables, schedule row names, and known condition values |
| **Secondary Body Slate** | `#2D3C46` | `rgb(45, 60, 70)` | Recent patient feed rows and list items |
| **Muted Body Slate** | `#4B5F69` | `rgb(75, 95, 105)` | Demographics contact values (phone, email, address, birthdate) |
| **Header Subtitle Grey** | `#738A94` | `rgb(115, 138, 148)` | Subtitle text directly below page headers |
| **Field Eyebrow / Meta Grey** | `#738791` | `rgb(115, 135, 145)` | Eyebrow labels (*"EMAIL ADDRESS"*, *"PASSWORD"*), diagnosis text, and doctor labels |
| **Table Column Header Grey**| `#788791` | `rgb(120, 135, 145)` | Patient table header column names (*"Patient"*, *"Age / sex"*, *"Contact"*, *"Last visit"*) |
| **Inactive Role / Note Grey**| `#788C96` | `rgb(120, 140, 150)` | Inactive role switcher text and login instructions |
| **KPI Context Grey** | `#87949E` | `rgb(135, 148, 158)` | Context indicators below KPI values (*"2 remaining"*, *"Avg. 11 min"*, *"67% of today"*) |
| **Placeholder / Tertiary Grey**| `#8C9BA5` | `rgb(140, 155, 165)` | Search box placeholder, security notices (*"Authorized clinic personnel only"*), and empty list state |

### F. Semantic & Status Accents
| Status Meaning | Background Color | Text Color | Controls & Screen Context |
| :--- | :--- | :--- | :--- |
| **Completed / Confirmed** (Success) | `#E6F5EB` / `#E8F6EB`<br>`rgb(230, 245, 235)` | `#28874B`<br>`rgb(40, 135, 75)` | • Dashboard appointment pill: *"Completed"*<br>• Timeline badge: *"Completed"*<br>• Upcoming appointment pill: *"Confirmed"* |
| **Pending** (Warning / Amber) | `#FEF3E2`<br>`rgb(254, 243, 226)` | `#D97706`<br>`rgb(217, 119, 6)` | Dashboard appointment status pill: *"Pending"* |
| **Cancelled / Alert** (Danger Red) | None (Text only) | `#CD504B` / `#CD4B4B`<br>`rgb(205, 80, 75)` | • Dashboard KPI value: *"0"* cancelled appointments<br>• Drug allergy alert text: *"Penicillin"* (switches conditionally) |

---

## 3. UI Component Anatomy & Design Tokens

### Layout & Window Metrics
- **Window Form Size**: `1008 px` width × `729 px` height (`StartPosition = CenterScreen`).
- **Sidebar Dimensions**: `178 px` width × `736 px` height, docked left.
- **Main Workspace Canvas**: `832 px` width × `730 px` height, located at `Point(176, 0)`.
- **Canvas Margins**:
  - Left content margin: `28 px` from the sidebar boundary.
  - Page header top margin: `20 px` from the window top.

### Component Design Tokens (`Ferrando.UI.WinForms`)

| Component | Dimensions | Border Radius | Border Style | Shadow / Elevation |
| :--- | :--- | :--- | :--- | :--- |
| **Login Modal Card** (`cardLogin`) | `356 × 420 px` | `16 px` | `1 px` solid `#E8EDF0` | `EnableShadow = True`, `ShadowDepth = 8` |
| **KPI Metric Summary Cards** | `184 × 104 px` | `12 px` | `1 px` solid `#E8EDF0` | `EnableShadow = True`, `ShadowDepth = 4` |
| **Content Cards** (Timeline, Demographics, etc.) | Variable | `12 px` | `1 px` solid `#E8EDF0` | `EnableShadow = True`, `ShadowDepth = 4` |
| **Sidebar Profile Card** (`namePlaceHolder`) | `162 × 64 px` | `12 px` | `1 px` solid `#1D404F` | `EnableShadow = True`, `ShadowDepth = 8` |
| **Brand Logo Box** (`cardLogo`, `FCard1`) | `48 × 48 px` or `52 × 50 px` | `12 px` | `0 px` / `1 px` solid `#238978` | `EnableShadow = True`, `ShadowDepth = 8` |
| **Sidebar Navigation Buttons** | `171 × 35 px` | `10 px` | `0 px` (Flat) | Flat (no shadow) |
| **Status Badges / Pills** | `72-76 × 22-24 px` | `10 px` | `0 px` (Flat) | Flat |
| **Text Inputs & Search Container** | `Height: 36 px` | `8 px` | `1 px` solid `#DCE4E8` | `EnableShadow = False`, `ShadowDepth = 2` |
| **Action & Filter Buttons** | `Height: 30-36 px` | `8 px` | `1 px` solid `#D2DEE4` | Flat / bordered |
| **Role Switcher Outer Track** | `308 × 38 px` | `8 px` | `1 px` solid `#EBF0F3` | `EnableShadow = False` |
| **Role Switcher Tab Buttons** | `148 × 30 px` | `6 px` | `1 px` solid `#DCE6EB` (Active) | Flat pill |
| **Patient Directory Table Rows** | `Width: 738 px`, `Height: 44 px` | `0 px` | Bottom `1 px` line `#F2F4F7` | Flat, interactive hover |

---

## 4. Interactive States & Behaviors

### 1. Sidebar Navigation (`SidebarHandler.vb`)
- **Default (Inactive)**:
  - Background: `#113646` (`DefaultBack`)
  - ForeColor: `#B6CCD2` (`DefaultFore`)
  - Font: `Noto Sans Georgian`, `12pt`, Regular
- **Hover**:
  - Background: `#274957`
  - ForeColor: `#FFFEFF`
- **Active (Selected)**:
  - Background: `#274957` (`ActiveBack`)
  - ForeColor: `#FFFEFF` (`ActiveFore`)
  - Font: `Noto Sans Georgian Bold`, `12pt`, Bold (persists when hovering)

### 2. Role Switcher (`LoginForm.vb`)
- **Active Tab** (e.g. Doctor):
  - Background: `#FFFFFF`
  - Border: `1px solid #DCE6EB`
  - ForeColor: `#238978`
  - Font: `Segoe UI`, `8.5pt`, Bold
- **Inactive Tab** (e.g. Receptionist):
  - Background: `#F3F6F8`
  - Border: `0px`
  - ForeColor: `#788C96`
  - Font: `Segoe UI`, `8.5pt`, Regular

### 3. Text Inputs & Search Box
- **Normal**: Background `#FFFFFF`, Border `#DCE4E8` or `#E8EDF0`.
- **Hover / Focus**: Border transitions to Brand Teal `#238978`.
- **Search Placeholder Behavior**: Text `#8C9BA5` (*"Search name, patient ID, phone..."*), clears and switches to dark slate `#1E2D37` upon focus.

### 4. Interactive Table Rows
- **Normal**: Pure white `#FFFFFF`.
- **Hover**: Subtle tint `#F6F9FB` with `Cursors.Hand`.
- **Click**: Instantiates `DoctorPatientInformation(patientId)` with clean view switching.
