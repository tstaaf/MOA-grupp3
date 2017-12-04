using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyttMOA
{
    public static class Menus
    {
        public static string CheckTextInput(string msg)
        {
            string input;

            while (true)
            {
                Console.Clear();
                Console.WriteLine(msg);
                input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    return input;
            }
        }

        public static int CheckIntInput(string msg)
        {
            while (true)
            {
                Console.WriteLine(msg);
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    return input;
                }
                Console.WriteLine("Invalid input!");
            }
        }

        public static int CheckIntInput(int min, int max)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if (input >= min && input <= max)
                    {
                        return input;
                    }
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        public static void Pause()
        {
            Console.WriteLine("Press any key to go back");
            Console.ReadKey();
        }


        public static User LogIn()
        {
            while (true)
            {
                Console.Clear();
                User user = Program.register.SearchForUsername(CheckTextInput("Username:"));

                if (Program.register.CheckPassword(user, CheckTextInput("Password:")))
                {
                    return user;
                }
                else
                {
                    Console.WriteLine("Wrong username or password.");
                    Pause();
                }
            }
        }


        public static void AdminManageStudents()
        {
            void DisplayStudents()
            {
                Console.Clear();
                foreach (var student in Program.register.UserList.OfType<Student>())
                {
                    Console.WriteLine("Name: {0} Username: {1} Password: {2}",
                        student.Name, student.UserName, student.Password);
                }
                Pause();
            }

            void AddStudent()
            {
                Console.Clear();
                if (Program.register.AddUser(new Student(
                    CheckTextInput("Enter name:"),
                    CheckTextInput("Enter username:"),
                    CheckTextInput("Enter password:"))))
                {
                    Console.WriteLine("Student added!");
                }
                else
                {
                    Console.WriteLine("Name or username is not available!");
                }
                Pause();
            }

            void RemoveStudent()
            {
                Console.Clear();
                int studentIndex;
                IEnumerable<Student> sample = Program.register.UserList.OfType<Student>();

                foreach (var student in sample)
                {
                    studentIndex = sample.ToList().IndexOf(student);
                    Console.WriteLine("[{0}] Name: {1} Username: {2} Password: {3}",
                        studentIndex, student.Name, student.UserName, student.Password);
                }

                Console.WriteLine("Remove student by number: ");
                Program.register.RemoveUser(sample.ToList()[
                    CheckIntInput(0, sample.Count() - 1)]);
                Console.WriteLine("Student removed!");
                Pause();
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
                        return;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid selection, try again");
                        Pause();
                        break;
                }
            }
        }

        public static void AdminManageTeachers()
        {
            void DisplayTeachers()
            {
                Console.Clear();
                foreach (var teacher in Program.register.UserList.OfType<Teacher>())
                {
                    Console.WriteLine("Name: {0} Username: {1} Password: {2}",
                        teacher.Name, teacher.UserName, teacher.Password);
                }
                Pause();
            }

            void AddTeacher()
            {
                Console.Clear();
                if (Program.register.AddUser(new Teacher(
                    CheckTextInput("Enter name:"),
                    CheckTextInput("Enter username:"),
                    CheckTextInput("Enter password:"))))
                {
                    Console.WriteLine("Teacher added!");
                }
                else
                {
                    Console.WriteLine("Name or username is not available");
                }
                
                Pause();
            }

            void RemoveTeacher()
            {
                Console.Clear();
                int teacherIndex;
                IEnumerable<Teacher> sample = Program.register.UserList.OfType<Teacher>();

                foreach (var teacher in sample)
                {
                    teacherIndex = sample.ToList().IndexOf(teacher);
                    Console.WriteLine("[{0}] Name: {1} Username: {2} Password: {3}",
                        teacherIndex, teacher.Name, teacher.UserName, teacher.Password);
                }

                Console.WriteLine("Remove teacher by number: ");
                Program.register.RemoveUser(sample.ToList()[
                    CheckIntInput(0, sample.Count() - 1)]);
                Console.WriteLine("Teacher removed!");
                Pause();
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
                        return;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid selection, try again");
                        Pause();
                        break;
                }
            }
        }

        public static void AdminManageCourses()
        {
            void DisplayCourses()
            {
                Console.Clear();
                foreach (var course in Program.register.CourseList)
                {
                    Console.WriteLine("Course: {0} Startdate: {1} Enddate: {2} Max students: {3} Teacher: {4}",
                        course.Name, course.StartDate, course.EndDate, course.MaxStudents, course.Teacher.Name);
                }
                Pause();
            }

            void AddCourse()
            {
                Console.Clear();
                var courseName = CheckTextInput("Enter name:");
                var startDate = Convert.ToDateTime(CheckTextInput("Enter start date:"));
                var endDate = Convert.ToDateTime(CheckTextInput("Enter end date:"));
                var maxStudents = Convert.ToInt32(CheckTextInput("Enter max amount of students:"));

                Console.WriteLine("Assign teacher: ");
                IEnumerable<Teacher> sample = Program.register.UserList.OfType<Teacher>();
                int n;
                foreach (var teacher in sample)
                {
                    n = sample.ToList().IndexOf(teacher);
                    Console.WriteLine("[{0}] : {1}", n, teacher.Name);
                }
                var courseTeacher = Program.register.UserList.OfType<Teacher>().ToArray()[
                    CheckIntInput(0, sample.Count() - 1)];
                if (Program.register.AddCourse(new Course(
                    courseName,
                    startDate,
                    endDate,
                    maxStudents,
                    courseTeacher)))
                {
                    Console.WriteLine("Course added!");
                }
                else
                {
                    Console.WriteLine("Name not available!");
                }
                Pause();
            }

            void RemoveCourse()
            {
                Console.Clear();
                int courseIndex;
                IEnumerable<Course> sample = Program.register.CourseList;

                foreach (var course in sample)
                {
                    courseIndex = sample.ToList().IndexOf(course);
                    Console.WriteLine("[{0]} Course: {1} Startdate: {2} Enddate: {3} Max students: {4} Teacher: {5}",
                        courseIndex, course.Name, course.StartDate, course.EndDate, course.MaxStudents, course.Teacher.Name);
                }

                Console.WriteLine("Remove course by number: ");
                Program.register.RemoveCourse(sample.ToList()[
                    CheckIntInput(0, sample.Count() - 1)]);
                Console.WriteLine("Course removed!");
                Pause();
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("[1] Display courses");
                Console.WriteLine("[2] Add course");
                Console.WriteLine("[3] Remove course");
                Console.WriteLine("[4] Go back");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        DisplayCourses();
                        break;

                    case ConsoleKey.D2:
                        AddCourse();
                        break;

                    case ConsoleKey.D3:
                        RemoveCourse();
                        break;

                    case ConsoleKey.D4:
                        Console.Clear();
                        return;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid selection, try again!");
                        Pause();
                        break;
                }
            }
        }

        public static void AdminManageClassrooms()
        {
            void DisplayClassrooms()
            {
                Console.Clear();
                foreach (var classroom in Program.register.ClassroomList)
                {
                    Console.WriteLine("Classroom: {0} Seats: {1}", classroom.Name, classroom.Seats);
                }
                Pause();
            }

            void AddClassroom()
            {
                Console.Clear();
                var classroomName = CheckTextInput("Enter name of classroom:");
                var classroomSeats = CheckIntInput("How many seats are there in the classroom?");
                if (Program.register.AddClassroom(new Classroom(
                    classroomName,
                    classroomSeats)))
                {
                    Console.WriteLine("Classroom added!");
                }
                else
                {
                    Console.WriteLine("Name not available!");
                }
                Pause();
            }

            void RemoveClassroom()
            {
                Console.Clear();
                int classroomIndex;
                IEnumerable<Classroom> sample = Program.register.ClassroomList;

                foreach (var classroom in sample)
                {
                    classroomIndex = sample.ToList().IndexOf(classroom);
                    Console.WriteLine("[{0}] Classroom: {1} Seats: {2}",
                        classroomIndex, classroom.Name, classroom.Seats);
                }

                Console.WriteLine("Remove classroom by number: ");
                Program.register.RemoveClassroom(sample.ToList()[
                    CheckIntInput(0, sample.Count() - 1)]);
                Console.WriteLine("Classroom removed!");
                Pause();
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("[1] Display classrooms");
                Console.WriteLine("[2] Add classroom");
                Console.WriteLine("[3] Remove classroom");
                Console.WriteLine("[4] Go back");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        DisplayClassrooms();
                        break;

                    case ConsoleKey.D2:
                        AddClassroom();
                        break;

                    case ConsoleKey.D3:
                        RemoveClassroom();
                        break;

                    case ConsoleKey.D4:
                        return;

                    default:
                        Console.WriteLine("Invalid selection, try again!");
                        break;

                }
            }
        }

        public static void AdminSchedule() // Inte färdig
        {
            return;
        }
    }
}
