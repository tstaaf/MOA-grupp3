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
                Console.WriteLine("[4] Add course");
                Console.WriteLine("[5] Display courses");
                Console.WriteLine("[6] Add classroom");
                Console.WriteLine("[7] Display classrooms");
                Console.WriteLine("[8] Schedule");
                Console.WriteLine("[0] Log Out");

                var choice = Console.ReadKey();

                switch (choice.Key)
                {


                    case ConsoleKey.D1:
                      
                        var studentRemove = true;
                        while (studentRemove)

                        {
                            Console.Clear();
                            Console.WriteLine("[1] Display students");
                            Console.WriteLine("[2] Add student");
                            Console.WriteLine("[3] Remove student");
                            Console.WriteLine("[4] Go back");
                            

                            switch (Console.ReadKey().Key)
                            {

                                case ConsoleKey.D1:
                                    Console.Clear();
                                    foreach (var student in Register.UserList.OfType<Student>())
                                    {
                                        Console.WriteLine("Name: {0} Username: {1} Password: {2}",
                                            student.Name, student.UserName, student.Password);
                                    }
                                    Console.WriteLine("Press any key to go back");
                                    Console.ReadKey();
                                    break;

                                case ConsoleKey.D2:
                                    Console.Clear();
                                    Console.WriteLine(" Enter name:  ");
                                    var studentName = Console.ReadLine();
                                    Console.WriteLine("Enter Username:  ");
                                    var studentUserName = Console.ReadLine();
                                    Console.WriteLine("Enter Password:  ");
                                    var studentPassword = Console.ReadLine();
                                    Register.AddUser(new Student(studentName, studentUserName, studentPassword));
                                    Console.WriteLine("Student added!");
                                    Register.SaveUserListToXml();

                                    break;

                                case ConsoleKey.D3:
                                    Console.Clear();
                                    int studentIndex;

                                    foreach (var student in Register.UserList.OfType<Student>())
                                    {
                                        studentIndex = Register.UserList.OfType<Student>().ToList().IndexOf(student);
                                        Console.WriteLine("[{0}] Name: {1} Username: {2} Password: {3}", studentIndex,
                                            student.Name, student.UserName, student.Password);
                                    }

                                    Console.WriteLine("Remove student by number: ");
                                    studentIndex = int.Parse(Console.ReadLine());
                                    Register.RemoveUser(Register.UserList.OfType<Student>().ToList()[studentIndex]);
                                    Register.SaveUserListToXml();
                                    break;

                                case ConsoleKey.D4:
                                    Console.Clear();
                                    showMenu();
                                    break;



                                default:
                                    Console.Clear();
                                    Console.WriteLine("Invalid selection, Try again");
                                    break;
                            }

                        }
                        break;

                    case ConsoleKey.D2:

                        var teacherRemove = true;
                        while (teacherRemove)

                        {
                            Console.Clear();
                            Console.WriteLine("[1] Display teachers");
                            Console.WriteLine("[2] Add Teacher");
                            Console.WriteLine("[3] Remove teachers");
                            Console.WriteLine("[4] Go back");


                            switch (Console.ReadKey().Key)
                            {

                                case ConsoleKey.D1:
                                    Console.Clear();
                                    foreach (var teacher in Register.UserList.OfType<Teacher>())
                                    {
                                        Console.WriteLine("Name: {0} Username: {1} Password: {2}",
                                            teacher.Name, teacher.UserName, teacher.Password);
                                    }
                                    Console.WriteLine("Press any key to go back");
                                    Console.ReadKey();
                                    break;

                                case ConsoleKey.D2:
                                    Console.Clear();
                                    Console.WriteLine(" Enter name:  ");
                                    var teacherName = Console.ReadLine();
                                    Console.WriteLine("Enter Username:  ");
                                    var teacherUserName = Console.ReadLine();
                                    Console.WriteLine("Enter Password:  ");
                                    var teacherPassword = Console.ReadLine();
                                    Register.AddUser(new Teacher(teacherName, teacherUserName, teacherPassword));
                                    Console.WriteLine("Teacher added!");
                                    Register.SaveUserListToXml();

                                    break;

                                case ConsoleKey.D3:
                                    Console.Clear();
                                    int teacherIndex;

                                    foreach (var teacher in Register.UserList.OfType<Teacher>())
                                    {
                                        teacherIndex = Register.UserList.OfType<Teacher>().ToList().IndexOf(teacher);
                                        Console.WriteLine("[{0}] Name: {1} Username: {2} Password: {3}", teacherIndex,
                                            teacher.Name, teacher.UserName, teacher.Password);
                                    }

                                    Console.WriteLine("Remove teacher by number: ");
                                    teacherIndex = int.Parse(Console.ReadLine());
                                    Register.RemoveUser(Register.UserList.OfType<Teacher>().ToList()[teacherIndex]);
                                    Register.SaveUserListToXml();
                                    break;

                                case ConsoleKey.D4:
                                    Console.Clear();
                                    showMenu();
                                    break;



                                default:
                                    Console.Clear();
                                    Console.WriteLine("Invalid selection, Try again");
                                    break;
                            }

                        }
                        break;

                    case ConsoleKey.D4:
                        Console.Clear();
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
                            n = Register.UserList.OfType<Teacher>().ToList().IndexOf(teacher);
                            Console.WriteLine("[{0}] : {1}", n, teacher.Name);
                        }

                        n = int.Parse(Console.ReadKey().KeyChar.ToString());
                        var courseTeacher = Register.UserList.OfType<Teacher>().ToArray()[n];
                        Register.AddCourse(new Course(courseName, startDate, endDate, maxStudents, courseTeacher));
                        

                        break;

                    case ConsoleKey.D5:
                        Console.Clear();
                        foreach (var course in Register.CourseList)
                        {
                            Console.WriteLine("Course: {0} Startdate: {1} Enddate: {2} Max students: {3} Teacher: {4}", course.Name, course.StartDate, course.EndDate, course.MaxStudents, course.Teacher.Name);
                        }
                        Console.ReadLine();

                        break;

                    case ConsoleKey.D6:
                        Console.WriteLine("Enter name of classroom: ");
                        var a = Console.ReadLine();
                        Console.WriteLine("How many seats are there in the classroom?");
                        var b = int.Parse(Console.ReadLine());
                        Register.AddClassroom(new Classroom(a, b));
                        Register.SaveClassroomListToXml();
                        Console.WriteLine("Classroom added!");
                        Console.ReadLine();
                        break;

                    case ConsoleKey.D7:
                        Console.Clear();
                        foreach (var classroom in Register.ClassroomList)
                        {
                            Console.WriteLine("Classroom: {0} Seats: {1}", classroom.Name, classroom.Seats);
                        }
                        Console.ReadLine();
                        break;

                    case ConsoleKey.D0:
                        Console.Clear();
                        Program.inloggning();
                        break;

                    case ConsoleKey.D9:

                        break;

                    default:
                        Console.Clear();
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
                        Program.inloggning();
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
                        Program.inloggning();
                        break;

                    default:
                        Console.WriteLine("Invalid selection, Try again");
                        break;
                }
            }
        }
    }
}
