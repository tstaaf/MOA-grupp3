using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyttMOA
{
    public class MenuManager
    {
        User user;

        public MenuManager(User _user)
        {
            user = _user;
        }

        public static string CheckTextInput(string msg)
        {
            string input;

            while (true)
            {
                Console.Clear();
                Console.WriteLine(msg);
                input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
            }
        }

        void AdminManageStudents()
        {
            void DisplayStudents()
            {
                Console.Clear();
                foreach (var student in Register.UserList.OfType<Student>())
                {
                    Console.WriteLine("Name: {0} Username: {1} Password: {2}",
                        student.Name, student.UserName, student.Password);
                }
                Console.WriteLine("Press any key to go back");
                Console.ReadKey();
            }

            void AddStudent()
            {
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
            }

            void RemoveStudent()
            {
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
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("[1] Display students");
                Console.WriteLine("[2] Add student");
                Console.WriteLine("[3] Remove student");
                Console.WriteLine("[4] Go back");
                
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        DisplayStudents();
                        break;

                    case ConsoleKey.D2:
                        AddStudent();
                        break;

                    case ConsoleKey.D3:
                        RemoveStudent();
                        break;

                    case ConsoleKey.D4:
                        user.showMenu();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid selection, Try again");
                        Console.ReadKey();
                        break;
                }
            }
        }

        void AdminManageTeachers()
        {
            void DisplayTeachers()
            {
                Console.Clear();
                foreach (var teacher in Register.UserList.OfType<Teacher>())
                {
                    Console.WriteLine("Name: {0} Username: {1} Password: {2}",
                        teacher.Name, teacher.UserName, teacher.Password);
                }
                Console.WriteLine("Press any key to go back");
                Console.ReadKey();
            }

            void AddTeacher()
            {
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
            }

            void RemoveTeacher()
            {
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
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("[1] Display teachers");
                Console.WriteLine("[2] Add Teacher");
                Console.WriteLine("[3] Remove teacher");
                Console.WriteLine("[4] Go back");

                switch (Console.ReadKey().Key)
                {

                    case ConsoleKey.D1:
                        DisplayTeachers();
                        break;

                    case ConsoleKey.D2:
                        AddTeacher();
                        break;

                    case ConsoleKey.D3:
                        RemoveTeacher();
                        break;

                    case ConsoleKey.D4:
                        Console.Clear();
                        user.showMenu();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid selection, Try again");
                        Console.ReadKey();
                        break;
                }
            }
        }

        void AdminManageCourses()
        {
            void DisplayCourses()
            {
                Console.Clear();
                foreach (var course in Register.CourseList)
                {
                    Console.WriteLine("Course: {0} Startdate: {1} Enddate: {2} Max students: {3} Teacher: {4}", course.Name, course.StartDate, course.EndDate, course.MaxStudents, course.Teacher.Name);
                }
                Console.WriteLine("Press any key to go back");
                Console.ReadKey();
            }

            void AddCourse()
            {
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
                Register.SaveCourseListToXml();
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("[1] Display courses");
                Console.WriteLine("[2] Add Course");
                Console.WriteLine("[3] Go back");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        DisplayCourses();
                        break;

                    case ConsoleKey.D2:
                        AddCourse();
                        break;

                    case ConsoleKey.D3:
                        Console.Clear();
                        user.showMenu();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong input, try again");
                        Console.ReadKey();
                        break;
                }
            }
        }

        void AdminManageClassrooms()
        {
            void DisplayClassrooms()
            {
                Console.Clear();
                foreach (var classroom in Register.ClassroomList)
                {
                    Console.WriteLine("Classroom: {0} Seats: {1}", classroom.Name, classroom.Seats);
                }
                Console.ReadLine();
            }

            void AddClassroom()
            {
                Console.Clear();
                Console.WriteLine("Enter name of classroom: ");
                var a = Console.ReadLine();
                Console.WriteLine("How many seats are there in the classroom?");
                var b = int.Parse(Console.ReadLine());
                Register.AddClassroom(new Classroom(a, b));
                Register.SaveClassroomListToXml();
                Console.WriteLine("Classroom added!");
                Console.ReadLine();
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("[1] Display classrooms");
                Console.WriteLine("[2] Add classroom");
                Console.WriteLine("[3] Go back");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        DisplayClassrooms();
                        break;
                    case ConsoleKey.D2:
                        AddClassroom();
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        user.showMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;

                }
            }
        }

        void AdminSchedule()
        {


            while (true)
            {

            }
        }
    }
}
