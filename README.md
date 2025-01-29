# Employee_System_Management

The Employee Management System is a robust and efficient web application developed to simplify and streamline employee management processes for small organizations. Built using ASP.NET Core MVC and MySQL, the system reduces manual HR inefficiencies, ensures data accuracy, and incorporates role-based security for improved data privacy. It’s designed to cater to both administrators and employees, offering tailored features for each user type.

📖 Overview
This project tackles key challenges in traditional HR systems, such as:
- Inefficiencies in manual processes that hinder productivity.
- Data inaccuracies and redundancies due to outdated methods.
- Lack of role-based security, leading to potential data breaches.
- The Employee Management System addresses these pain points with modern technologies, providing an intuitive and secure platform for managing employee records, contracts, payroll, and feedback.

🔑 Key Features
Admin Features
  - Add, update, and delete employee records with ease.
  - Search and filter employee details based on name, surname, or other attributes.
  - Manage employee contracts and calculate salaries automatically.
  - Track employee work status (Active/Inactive).
  - Add, view, and remove non-working days for better scheduling.
  Review employees with ratings (up to 5 stars) and comments.
Employee Features
  - View personal information and contract details.
  - Access a calendar with designated holidays and non-working days.
  - Review other employees for transparency and collaboration.
Shared Features
  - Role-Based Authentication: Admins have full control, while employees can only access relevant information.
  - Secure Login System: Includes password recovery and 'Remember Me' functionality for convenience.
  - Welcome Page and Privacy Policy: Ensures users understand the purpose of the system and their data is protected.

🛠️ Technology Stack
Frameworks: ASP.NET Core MVC, Entity Framework Core
Programming Language: C#
Database: MySQL
Authentication: ASP.NET Identity for role-based security and persistent logins.
Development Tools: Visual Studio, Git, SQL Management Studio

📂 Database Structure
The system employs a well-structured relational database with the following key tables:
Employee Table:
ID (Primary Key)
Name, Surname
Salary
Contract Period (Start and End Dates)
Activity Status (Active/Inactive)
Authentication Table:
Manages user credentials for secure login.
ER Diagram: Displays relationships between employees, contracts, and authentication data.

🎯 Benefits
Efficient Management: Streamlines employee record-keeping and contract management.
Enhanced Security: Implements role-based access and secure authentication.
Cost-Effective Solution: Reduces HR overhead for small organizations.
User-Friendly Interface: Intuitive design for both administrators and employees.

🗓️ Usage Example
Login as Admin or Employee:
  - Admins have full access to all features.
  - Employees can only view relevant information.
Manage Employees:
  - Admins can add a new employee by filling out a form and clicking "Add New Employee."
  - Existing employees can be updated or deleted as needed.
Review and Feedback:
  - Both admins and employees can view employee reviews.
  - Admins can also rate employees with up to 5 stars and leave feedback comments.
Track Non-Working Days:
  - Admins can add non-working days with a description and remove them if necessary.
  - Employees can view these days to plan their schedules.

🌟 Future Enhancements
We plan to extend the functionality of the system with the following features:
  Mobile Compatibility: A responsive design for seamless usage on smartphones and tablets.
  Integration with Payroll Systems: Automate salary processing and tax deductions.
  Advanced Reporting: Generate detailed analytics for employee performance and organizational growth.
  Custom Notifications: Notify users about upcoming contract expirations, holidays, and important events.

👥 Team
This project was developed as part of the Advanced Programming in .NET course by the following team members:
- Agron Berisha
- Arita Ademi 
- Lebibe Mehmedi
Collaboration Tools:
- Version Control: Git
- Development Environment: Shared Visual Studio Projects
- Task Management: Weekly meetings for task allocation and progress tracking

🔐 Privacy & Security
The system incorporates robust security measures:
- Role-Based Access Control: Ensures that admins and employees have clearly defined permissions.
- Data Encryption: Protects sensitive information like passwords and salary data.
- Privacy Policy: Outlines how user data is securely managed and protected.


