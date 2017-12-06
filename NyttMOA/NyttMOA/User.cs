using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NyttMOA
{
    [XmlInclude(typeof(Admin))]
    [XmlInclude(typeof(Teacher))]
    [XmlInclude(typeof(Student))]
    public abstract class User
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public delegate void NotificationEventHandler(object sender, EventArgs e);
        event NotificationEventHandler Notifications;
        List<string> notifications;

        public User(string name, string username, string password)
        {
            Name = name;
            UserName = username;
            Password = password;
        }

        public User()
        {

        }

        public string ShowLogInMessage()
        {
            return "Logged in as " + Name;
        }

        public abstract void showMenu();

        internal void GetNotifications(User sender)
        {
            if (Notifications != null)
            {
                notifications = new List<string>();
                Notifications(sender, null);
            }
        }

        public void AddNotification(string msg)
        {
            notifications.Add(msg);
        }
    }
    
    public class Admin : User
    {
        public Admin(string name, string username, string password) : base(name, username, password)
        {

        }

        public Admin()
        {
            
        }

        public override void showMenu()
        {
            var menuChoice = true;

            while (menuChoice)
            {
                Console.Clear();
                Console.WriteLine(ShowLogInMessage());
                Console.WriteLine("[1] Manage students");
                Console.WriteLine("[2] Manage teachers");
                Console.WriteLine("[3] Manage courses");
                Console.WriteLine("[4] Manage classrooms");
                Console.WriteLine("[5] Manage schedule");
                Console.WriteLine("[0] Log Out");

                var choice = Console.ReadKey();

                switch (choice.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Menus.AdminManageStudents();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Menus.AdminManageTeachers();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Menus.AdminManageCourses();
                        break;
                        
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Menus.AdminManageClassrooms();
                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        Menus.AdminManageSchedule();
                        break;


                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        Console.Clear();
                        Program.LogIn();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid selection, try again");
                        Menus.Pause();
                        break;
                }
            }
        }
    }

    public class Student : User
    {
        public Student(string name, string username, string password) : base(name, username, password)
        {
            
        }
        
        public Student()
        {
            
        }

        public override void showMenu()
        {
            var menuChoice = true;

            while (menuChoice)
            {
                Console.Clear();
                Console.WriteLine(ShowLogInMessage());
                Console.WriteLine("[1] Schedule");
                Console.WriteLine("[2] Courses");
                Console.WriteLine("[3] Classmates");
                Console.WriteLine("[4] Log Out");

                var choice = Console.ReadKey();

                switch (choice.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Menus.StudentSchedule();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Menus.StudentCourses();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Menus.StudentClassmates();
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Program.LogIn();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid selection, try again");
                        Menus.Pause();
                        break;
                }
            }
        }
    }

    public class Teacher : User
    {
        public Teacher(string name, string username, string password) : base(name, username, password)
        {

        }

        public Teacher()
        {
            
        }

        public override void showMenu()
        {
            var menuChoice = true;

            while (menuChoice)
            {
                Console.Clear();
                Console.WriteLine(ShowLogInMessage());
                Console.WriteLine("[1] Display students in courses");
                Console.WriteLine("[2] Add student to course");
                Console.WriteLine("[3] Remove student from course");
                Console.WriteLine("[4] Grades");
                Console.WriteLine("[5] Schedule");
                Console.WriteLine("[6] Log Out");

                var choice = Console.ReadKey();

                switch (choice.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Menus.TeacherDisplayStudentsInCourses();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Menus.TeacherAddStudentToCourse();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Menus.TeacherRemoveStudentFromCourse();
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Menus.TeacherGrades();
                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        Menus.TeacherSchedule();
                        break;

                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        Console.Clear();
                        Program.LogIn();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid selection, try again");
                        Menus.Pause();
                        break;
                }
            }
        }
    }
}
