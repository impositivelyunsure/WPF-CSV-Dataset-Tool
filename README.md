This project is a Windows desktop application developed to manage staff records stored in a CSV file.
The application provides a fast and simple way for staff to search, view, and administer staff records using a keyboard-driven interface.



**Project Objectives**

-The application was designed to:

-Load staff data from a CSV file

-Display the staff records in an immutable list box

-Allow users to filter records by ID or staff name

-Display selected record details in text fields

-Allow administrators to Create, Update, and Delete staff records

-Prevent duplicate staff ID numbers

-Provide confirmation messages for update and delete actions

-Use keyboard shortcuts (Alt / Ctrl / character keys) for navigation

-Demonstrate efficient File I/O and search performance


**Technologies Used**

-C#
-.NET
-Windows Presentation Foundation (WPF)
-Visual Studio
-Git & GitHub
-CSV File Storage



**Application Structure**

-The application consists of two main windows:

-Main Window (General Interface)

-Used by staff to:

-Load CSV data

-Seach and filter staff records

-View selected staff details

-Open the Admin interface if modifications are required



**Data Format**

-Staff records are stored in a CSV file using the format:

StaffID,StaffName
771234567,John Smith
772345678,Sarah Jones

-Rules for staff IDs:
-Must be 9 digits
-Must begin with 77
-Must be unique
-The leading zero used in UK mobile numbers is removed.



**Admin Window (Administration Interface)**

-Used by authorised users to:

-Create new staff records

-Update existing staff details

-Delete staff records

-Save changes to the CSV file

-Confirmation messages are displayed before critical operations such as updates and deletions.
