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
                Console.WriteLine("[2] Add Teacher");
                Console.WriteLine("[3] Add Course");
                Console.WriteLine("[4] Add classroom / View booked classrooms");
                Console.WriteLine("[5] View Grades");
                Console.WriteLine("[6] Schedule");
                Console.WriteLine("[7] Exit");

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

                        break;

                    case "5":

                        break;

                    case "6":
                        
                        break;

                    case "7":
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
        public Student(string name, string username, string password) : base(name, username, password)
        {

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
