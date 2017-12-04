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

        public User(string name, string username, string password)
        {
            Name = name;
            UserName = username;
            Password = password;
        }

        public abstract void showMenu();

        public User()
        {
            
        }

        public string ShowLogInMessage()
        {
            return "Logged in as " + Name;
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
                Console.WriteLine("[5] Schedule");
                Console.WriteLine("[0] Log Out");

                var choice = Console.ReadKey();

                switch (choice.Key)
                {
                    case ConsoleKey.D1:
                        Menus.AdminManageStudents();
                        break;

                    case ConsoleKey.D2:
                        Menus.AdminManageTeachers();
                        break;

                    case ConsoleKey.D3:
                        Menus.AdminManageCourses();
                        break;
                        
                    case ConsoleKey.D4:
                        Menus.AdminManageClassrooms();
                        break;

                    case ConsoleKey.D5:
                        Menus.AdminSchedule();
                        break;


                    case ConsoleKey.D0:
                        Console.Clear();
                        Program.LogIn();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid selection, try again");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }

    public class Student : User
    {
        public string Grade { get; set; }

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
                Console.WriteLine("[2] Grades");
                Console.WriteLine("[3] Log Out");

                var choice = Console.ReadKey();

                switch (choice.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:

                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:

                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.Clear();
                        Program.LogIn();
                        break;

                    default:
                        Console.WriteLine("Invalid selection, Try again");
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
                Console.WriteLine("[1] Add / Remove students to course");
                Console.WriteLine("[2] Grades");
                Console.WriteLine("[3] Classrooms / Courses");
                Console.WriteLine("[4] Log Out");

                var choice = Console.ReadKey();

                switch (choice.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:

                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:

                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:

                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Console.Clear();
                        Program.LogIn();
                        break;

                    default:
                        Console.WriteLine("Invalid selection, Try again");
                        break;
                }
            }
        }
    }
}
