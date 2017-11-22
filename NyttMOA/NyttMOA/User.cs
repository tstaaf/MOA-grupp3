using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NyttMOA
{
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
    }

    public class Admin : User
    {
        public Admin(string name, string username, string password) : base(name, username, password)
        {

        }

        public override void showMenu()
        {
            var menuChoice = true;

            while (menuChoice)
            {
                Console.WriteLine("[1] Add Student");
                Console.WriteLine("[2] Show Students");
                Console.WriteLine("[3] Add Teacher");
                Console.WriteLine("[4] Add Course");
                Console.WriteLine("[5] Add classroom / View booked classrooms");
                Console.WriteLine("[6] View Grades");
                Console.WriteLine("[7] Schedule");
                Console.WriteLine("[8] Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine(" Enter name:  ");
                        var studentName = Console.ReadLine();
                        Console.WriteLine("Enter Username:  ");
                        var studentUserName = Console.ReadLine();
                        Console.WriteLine("Enter Password:  ");
                        var studentPassword = Console.ReadLine();
                        Register.AddUser(new Student(studentName, studentUserName, studentPassword));
                        Console.WriteLine("Student added, press any key to go back.");

                        break;

                    case "2":
                        foreach (var student in Register.UserList.OfType<Student>())
                        {
                            Console.WriteLine("Name: {0} Username: {1} Password: {2}", student.Name, student.UserName, student.Password);

                        }
                        break;

                    case "3":
                        Console.WriteLine(" Enter name:  ");
                        var a = Console.ReadLine();
                        Console.WriteLine("Enter Username:  ");
                        var b = Console.ReadLine();
                        Console.WriteLine("Enter Password:  ");
                        var c = Console.ReadLine();
                        Register.AddUser(new Student(a, b, c));
                        Console.WriteLine("Student added, press any key to go back.");

                        break;

                    case "4":

                        break;

                    case "5":

                        break;

                    case "6":
                        
                        break;

                    case "7":
                        
                        break;

                    case "8":
                        menuChoice = false;
                        break;

                    default:
                        Console.WriteLine("Invalid selection, Try again");
                        break;
                }
            }
        }
    }

    public class Student : User
    {
        public string Grade { get; set; }

        public Student(string name, string username, string password, string grade) : base(name, username, password)
        {
            Grade = grade;
        }

        public override void showMenu()
        {
            var menuChoice = true;

            while (menuChoice)
            {
                Console.WriteLine("[1] Schedule");
                Console.WriteLine("[2] Grades");
                Console.WriteLine("[3] Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":

                        break;

                    case "2":

                        break;

                    case "3":
                        menuChoice = false;
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

        public override void showMenu()
        {
            var menuChoice = true;

            while (menuChoice)
            {
                Console.WriteLine("[1] Add / Remove students to course");
                Console.WriteLine("[2] Grades");
                Console.WriteLine("[3] Classrooms / Courses");
                Console.WriteLine("[4] Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":

                        break;

                    case "2":

                        break;

                    case "3":

                        break;

                    case "4":
                        menuChoice = false;
                        break;

                    default:
                        Console.WriteLine("Invalid selection, Try again");
                        break;
                }
            }
        }
    }
}
