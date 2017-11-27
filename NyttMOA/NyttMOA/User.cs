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
                Console.WriteLine("[1] Add student");
                Console.WriteLine("[2] Display students");
                Console.WriteLine("[3] Add teacher");
                Console.WriteLine("[4] Display teachers");
                Console.WriteLine("[5] Add course");
                Console.WriteLine("[6] Add classroom / View booked classrooms");
                Console.WriteLine("[7] View Grades");
                Console.WriteLine("[8] Schedule");
                Console.WriteLine("[9] Exit");

                var choice = Console.ReadKey();

                switch (choice.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine(" Enter name:  ");
                        var studentName = Console.ReadLine();
                        Console.WriteLine("Enter Username:  ");
                        var studentUserName = Console.ReadLine();
                        Console.WriteLine("Enter Password:  ");
                        var studentPassword = Console.ReadLine();
                        Register.AddUser(new Student(studentName, studentUserName, studentPassword));
                        Console.WriteLine("Student added!");

                        break;

                    case ConsoleKey.D2:
                        foreach (var student in Register.UserList.OfType<Student>())
                        {
                            Console.WriteLine("Name: {0} Username: {1} Password: {2}", student.Name, student.UserName, student.Password);

                        }
                        break;

                    case ConsoleKey.D3:
                        Console.WriteLine(" Enter name:  ");
                        var teacherName = Console.ReadLine();
                        Console.WriteLine("Enter Username:  ");
                        var teacherUserName = Console.ReadLine();
                        Console.WriteLine("Enter Password:  ");
                        var teacherPassword = Console.ReadLine();
                        Register.AddUser(new Teacher(teacherName, teacherUserName, teacherPassword));
                        Console.WriteLine("Teacher added!");

                        break;

                    case ConsoleKey.D4:
                        foreach (var teacher in Register.UserList.OfType<Teacher>())
                        {
                            Console.WriteLine("Name: {0} Username: {1} Password: {2}", teacher.Name, teacher.UserName, teacher.Password);
                        }

                        break;

                    case ConsoleKey.D5:
                        Console.WriteLine("Enter name of the course: ");
                        var courseName = Console.ReadLine();
                        Console.WriteLine("Enter Startdate of the course: ");
                        var startDate = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Enter end date of the course: ");
                        var endDate = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Enter max amount of students: ");
                        var maxStudents = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Pick teacher for the class: ");
                        int n;
                        foreach (var teacher in Register.UserList.OfType<Teacher>())
                        {
                            n = Register.UserList.IndexOf(teacher);
                            Console.WriteLine("[{0}] : {1}", n, teacher.Name);
                        }

                        n = int.Parse(Console.ReadKey().KeyChar.ToString());
                        var courseTeacher = Convert.ToString(n);
                        //Register.AddCourse(new Course(courseName, startDate, endDate, maxStudents, courseTeacher));

                        break;

                    case ConsoleKey.D6:
                        foreach (var course in Register.CourseList)
                        {
                            Console.WriteLine("Course: {0} Startdate: {1} Enddate: {2} Max students: {3} Teacher: {4}", course.Name, course.StartDate, course.EndDate, course.MaxStudents, course.Teacher);
                        }

                        break;

                    case ConsoleKey.D7:

                        break;

                    case ConsoleKey.D8:

                        break;

                    case ConsoleKey.D9:
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
