<h1 align="center">CSV Dataset Tool</h1>
<h3 align="center">Staff Management Application</h3>

<p align="center">
C# • WPF • CSV Data Storage • Agile Development
</p>

---

## 📋 Overview

This project is a Windows desktop application developed for **Malin Space Science Systems (MSSS)**.  
The application manages staff records stored in a CSV file and provides fast searching, filtering, and administrative record management.

---

## 🎯 Project Objectives

The application was designed to:

- Load staff records from a **CSV file**
- Display staff records in a **read-only list**
- Allow users to **filter results by Staff ID or Name**
- Display selected staff details in text fields
- Provide **Create, Update, and Delete** functionality through an Admin interface
- Prevent **duplicate staff ID numbers**
- Display **confirmation messages** before destructive actions
- Support **keyboard-driven interaction** using Alt, Ctrl and key combinations
- Demonstrate **efficient file I/O and search performance**

---

## 🖥️ Application Structure

The system contains **two main interfaces**.

### Main Window (User Interface)

Used by staff to:

- Load and view the staff list
- Filter records by ID or name
- Select records to view details
- Open the Admin interface when edits are required

### Admin Window (Administrative Interface)

Used by authorised users to:

- Create new staff records
- Update existing records
- Delete staff records
- Save changes back to the CSV file

Confirmation messages are displayed before important operations.

---

## 📂 Data Format

Staff records are stored in a **CSV file**.

Example format:

#### StaffID,StaffName
#### 771234567,John Smith
#### 772345678,Sarah Jones


### Staff ID Rules

| Rule | Description |
|-----|-------------|
| Length | 9 digits |
| Prefix | Must start with **77** |
| Uniqueness | Duplicate IDs are not allowed |

The leading zero from UK mobile numbers has been removed as per MSSS requirements.

---

## ⚙️ Technologies Used

| Technology | Purpose |
|-----------|--------|
| C# | Application logic |
| .NET | Framework |
| WPF | User interface |
| Visual Studio | Development environment |
| Git & GitHub | Version control and Agile tracking |
| CSV Files | Data storage |

---

## 🧠 Data Structures

Two data structures were evaluated for performance:

| Structure | Description |
|----------|-------------|
| `Dictionary<int,string>` | Fast insertion and lookup |
| `SortedDictionary<int,string>` | Maintains sorted order |

Performance testing compared:

- CPU usage
- Memory usage
- File I/O efficiency

Results showed **Dictionary** provides better performance for this application because constant sorting is unnecessary.

---

## ⌨️ Keyboard Controls

This application is designed to be **keyboard driven**.

| Shortcut | Action |
|--------|--------|
| Alt + A | Open Admin window |
| Alt + L | Close Admin window |
| Tab | Navigate between fields |
| Enter | Confirm actions |

---

## 📊 Performance Testing

Performance testing was conducted using:

- `Stopwatch` for execution timing
- `Trace.WriteLine()` for performance logging
- Visual Studio **Performance Profiler**

Tests included:

- CSV file read speed
- CSV file write speed
- Dictionary insertion performance
- SortedDictionary insertion performance

These tests demonstrated the efficiency of the chosen data structure.

---

## 🛠️ Project Structure

MainWindow.xaml
MainWindow.xaml.cs
AdminWindow.xaml
AdminWindow.xaml.cs
BackProcessor.cs
FrontProcessor.cs
AssemblyInfo.cs
App.xaml


### Key Components

| File | Purpose |
|-----|--------|
| `BackProcessor.cs` | Handles data processing and file operations |
| `FrontProcessor.cs` | Manages UI logic and interaction |
| `MainWindow` | Primary staff interface |
| `AdminWindow` | Administrative record management |

---

## 🔄 Development Methodology

This project followed an **Agile development approach**, including:

- Iterative development
- Feature commits tracked in **GitHub**
- Branching and pull requests
- Continuous testing and optimisation

---

## 👨‍💻 Author

**Developer:** Ethan Daly
**Project:** Malin Space Science Systems

---
