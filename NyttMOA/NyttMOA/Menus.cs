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
                Console.Clear();
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

        public static DateTime CheckDateTimeInput(string msg)
        {
            while (true)
            {
                DateTime output;
                if (DateTime.TryParse(CheckTextInput(msg), out output))
                {
                    return output;
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
                if (Program.register.UserList.OfType<Student>().Count() == 0)
                {
                    Console.WriteLine("No students to remove!");
                    Pause();
                    return;
                }
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
                    case ConsoleKey.NumPad1:
                        DisplayStudents();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        AddStudent();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        RemoveStudent();
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
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
                if (Program.register.UserList.OfType<Teacher>().Count() == 0)
                {
                    Console.WriteLine("No teachers to remove!");
                    Pause();
                    return;
                }
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
                    case ConsoleKey.NumPad1:
                        DisplayTeachers();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        AddTeacher();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        RemoveTeacher();
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
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
                    Console.WriteLine(course.ToString());
                }
                Pause();
            }

            void AddCourse()
            {
                Console.Clear();
                if (Program.register.UserList.OfType<Teacher>().Count() == 0)
                {
                    Console.WriteLine("No teachers in the system!");
                    Pause();
                    return;
                }
                var courseName = CheckTextInput("Enter name:");
                DateTime startDate = CheckDateTimeInput("Enter start date (YYYY-MM-DD):");
                DateTime endDate = CheckDateTimeInput("Enter end date (YYYY-MM-DD):");
                var hours = CheckIntInput("Enter total hours:");
                var maxStudents = CheckIntInput("Enter max amount of students:");

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
                    hours,
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
                if (Program.register.CourseList.Count() == 0)
                {
                    Console.WriteLine("No courses to remove!");
                    Pause();
                    return;
                }
                int courseIndex;
                IEnumerable<Course> sample = Program.register.CourseList;

                foreach (var course in sample)
                {
                    courseIndex = sample.ToList().IndexOf(course);
                    Console.WriteLine("[{0}] Course: {1} Startdate: {2} Enddate: {3} Max students: {4} Teacher: {5}",
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
                    case ConsoleKey.NumPad1:
                        DisplayCourses();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        AddCourse();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        RemoveCourse();
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
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
                if (Program.register.ClassroomList.Count() == 0)
                {
                    Console.WriteLine("No classrooms to remove!");
                    Pause();
                    return;
                }
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
                    case ConsoleKey.NumPad1:
                        DisplayClassrooms();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        AddClassroom();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        RemoveClassroom();
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        return;

                    default:
                        Console.WriteLine("Invalid selection, try again!");
                        break;

                }
            }
        }

        public static void AdminManageSchedule()
        {
            void DisplaySchedule()
            {
                void FullSchedule()
                {
                    Console.Clear();
                    Console.WriteLine(Program.register.schedule.ToString());
                    Pause();
                }

                void TodaysSchedule()
                {
                    Console.Clear();
                    Console.WriteLine(Program.register.schedule.GetSchedule(DateTime.Today, DateTime.Today.AddHours(24)));
                    Pause();
                }

                void CustomPeriod()
                {
                    Console.Clear();
                    Console.WriteLine(Program.register.schedule.GetSchedule(
                        CheckDateTimeInput("Enter start date (YYYY-MM-DD):"),
                        CheckDateTimeInput("Enter end date (YYYY-MM-DD):")));
                    Pause();
                }

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("[1] Full schedule");
                    Console.WriteLine("[2] Today's schedule");
                    Console.WriteLine("[3] Custom period");
                    Console.WriteLine("[4] Go back");

                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            FullSchedule();
                            break;

                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            TodaysSchedule();
                            break;

                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            CustomPeriod();
                            break;

                        case ConsoleKey.D4:
                        case ConsoleKey.NumPad4:
                            return;

                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid selection, try again");
                            Pause();
                            break;
                    }
                }
            }

            void AddLesson()
            {
                Console.Clear();
                if (Program.register.CourseList.Count() == 0)
                {
                    Console.WriteLine("No courses!");
                    Pause();
                    return;
                }
                if (Program.register.ClassroomList.Count() == 0)
                {
                    Console.WriteLine("No classrooms!");
                    Pause();
                    return;
                }

                Console.Clear();
                Console.WriteLine("Assign classroom: ");
                IEnumerable<Classroom> classrooms = Program.register.ClassroomList;
                foreach (var classroom in classrooms)
                {
                    Console.WriteLine("[{0}] : {1}",
                        classrooms.ToList().IndexOf(classroom), classroom.Name);
                }
                var lessonClassroom = classrooms.ToList()[CheckIntInput(0, classrooms.Count() - 1)];

                Console.Clear();
                Console.WriteLine("Assign course: ");
                IEnumerable<Course> courses = Program.register.CourseList;
                foreach (var course in courses)
                {
                    Console.WriteLine("[{0}] : {1}",
                        courses.ToList().IndexOf(course), course.Name);
                }
                var lessonCourse = courses.ToList()[CheckIntInput(0, courses.Count() - 1)];

                var startTime = CheckDateTimeInput("End start date and time (YYYY-MM-DD HH:MM):");
                var endTime = CheckDateTimeInput("End end date and time (YYYY-MM-DD HH:MM):");

                if(Program.register.AddLesson(new Lesson(
                    lessonClassroom,
                    lessonCourse,
                    startTime,
                    endTime)))
                {
                    Console.WriteLine("Lesson added!");
                }
                else
                {
                    Console.WriteLine("Lesson can not be added! (Teacher or classroom unavailable, or lesson is outside of course start and end times)");
                }
                Pause();
            }

            void RemoveLesson()
            {
                Console.Clear();
                if (Program.register.schedule.Lessons.Count() == 0)
                {
                    Console.WriteLine("No lessons to remove!");
                    Pause();
                    return;
                }
                int lessonIndex;
                IEnumerable<Lesson> sample = Program.register.schedule.Lessons;

                foreach (var lesson in sample)
                {
                    lessonIndex = sample.ToList().IndexOf(lesson);
                    Console.WriteLine(lessonIndex);
                    Console.WriteLine(lesson.ToString());
                }

                Console.WriteLine("Remove lesson by number: ");
                Program.register.RemoveLesson(sample.ToList()[
                    CheckIntInput(0, sample.Count() - 1)]);
                Console.WriteLine("Lesson removed!");
                Pause();
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("[1] Display schedule");
                Console.WriteLine("[2] Add lesson");
                Console.WriteLine("[3] Remove lesson");
                Console.WriteLine("[4] Go back");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        DisplaySchedule();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        AddLesson();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        RemoveLesson();
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        return;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid selection, try again");
                        Pause();
                        break;
                }
            }
        }


        public static void StudentSchedule()
        {
            void FullSchedule()
            {
                Console.Clear();
                Console.WriteLine(Program.register.schedule.GetSchedule((Student)Program.user).ToString());
                Pause();
            }

            void TodaysSchedule()
            {
                Console.Clear();
                Console.WriteLine(Program.register.schedule.GetSchedule(
                    (Student)Program.user,
                    DateTime.Today,
                    DateTime.Today.AddHours(24)));
                Pause();
            }

            void CustomPeriod()
            {
                Console.Clear();
                Console.WriteLine(Program.register.schedule.GetSchedule(
                    (Student)Program.user,
                    CheckDateTimeInput("Enter start date (YYYY-MM-DD):"),
                    CheckDateTimeInput("Enter end date (YYYY-MM-DD):")));
                Pause();
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("[1] Full schedule");
                Console.WriteLine("[2] Today's schedule");
                Console.WriteLine("[3] Custom period");
                Console.WriteLine("[4] Go back");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        FullSchedule();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        TodaysSchedule();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        CustomPeriod();
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        return;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid selection, try again");
                        Pause();
                        break;
                }
            }
        }

        public static void StudentCourses()
        {
            foreach (Course course in Program.register.CourseList)
            {
                foreach (StudentData studentData in course.Students)
                {
                    if (studentData.Student == Program.user)
                    {
                        Console.WriteLine(course.Name + ": " + studentData.Grade);
                        break;
                    }
                }
            }
            Pause();
        }


        public static void TeacherDisplayStudentsInCourse()
        {
            Console.Clear();
            foreach (Course course in Program.register.CourseList.Where(a => a.Teacher == Program.user))
            {
                Console.WriteLine(course.Name);
                foreach (StudentData studentData in course.Students)
                {
                    Console.WriteLine("  " + studentData.Student.Name);
                }
            }
            Pause();
        }

        public static void TeacherAddStudentToCourse()
        {
            Console.Clear();
            Console.WriteLine("Select course: ");
            IEnumerable<Course> courses = Program.register.CourseList;
            foreach (var course in courses)
            {
                Console.WriteLine("[{0}] : {1}",
                    courses.ToList().IndexOf(course),
                    course.Name);
            }
            var selectedCourse = courses.ToArray()[
                CheckIntInput(0, courses.Count() - 1)];

            Console.Clear();
            Console.WriteLine("Select student: ");
            IEnumerable<Student> students = Program.register.UserList.OfType<Student>();
            foreach (var student in students)
            {
                Console.WriteLine("[{0}] : {1}",
                    students.ToList().IndexOf(student),
                    student.Name);
            }
            var selectedStudent = students.ToArray()[
                CheckIntInput(0, students.Count() - 1)];

            selectedCourse.AddStudent(selectedStudent);

            Console.WriteLine("Student added!");
            Pause();
        }

        public static void TeacherRemoveStudentFromCourse()
        {
            Console.Clear();
            Console.WriteLine("Select course: ");
            IEnumerable<Course> courses = Program.register.CourseList;
            foreach (var course in courses)
            {
                Console.WriteLine("[{0}] : {1}",
                    courses.ToList().IndexOf(course),
                    course.Name);
            }
            var selectedCourse = courses.ToArray()[
                CheckIntInput(0, courses.Count() - 1)];

            Console.Clear();
            Console.WriteLine("Select student: ");
            IEnumerable<StudentData> students = selectedCourse.Students;
            foreach (var studentData in students)
            {
                Console.WriteLine("[{0}] : {1}",
                    students.ToList().IndexOf(studentData),
                    studentData.Student.Name);
            }
            var selectedStudent = students.ToArray()[
                CheckIntInput(0, students.Count() - 1)];

            selectedCourse.RemoveStudent(selectedStudent);

            Console.WriteLine("Student removed!");
            Pause();
        }

        public static void TeacherGrades()
        {
            void DisplayGrades()
            {
                void ByName()
                {
                    Console.Clear();
                    Console.WriteLine("Select course: ");
                    IEnumerable<Course> courses = Program.register.CourseList;
                    foreach (var course in courses)
                    {
                        Console.WriteLine("[{0}] : {1}",
                            courses.ToList().IndexOf(course),
                            course.Name);
                    }
                    var selectedCourse = courses.ToArray()[
                        CheckIntInput(0, courses.Count() - 1)];

                    Console.Clear();
                    foreach (StudentData studentData in selectedCourse.Students)
                    {
                        Console.WriteLine(studentData.Student.Name + ": " + studentData.Grade);
                    }
                    Pause();
                }

                void UngradedFirst()
                {
                    Console.Clear();
                    Console.WriteLine("Select course: ");
                    IEnumerable<Course> courses = Program.register.CourseList;
                    foreach (var course in courses)
                    {
                        Console.WriteLine("[{0}] : {1}",
                            courses.ToList().IndexOf(course),
                            course.Name);
                    }
                    var selectedCourse = courses.ToArray()[
                        CheckIntInput(0, courses.Count() - 1)];

                    Console.Clear();
                    foreach (StudentData studentData in selectedCourse.Students)
                    {
                        if (studentData.Grade == "-")
                        {
                            Console.WriteLine(studentData.Student.Name + ": " + studentData.Grade);
                        }
                    }
                    foreach (StudentData studentData in selectedCourse.Students)
                    {
                        if (studentData.Grade != "-")
                        {
                            Console.WriteLine(studentData.Student.Name + ": " + studentData.Grade);
                        }
                    }
                    Pause();
                }

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("[1] Sort by name");
                    Console.WriteLine("[2] Ungraded first");
                    Console.WriteLine("[3] Go back");

                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            ByName();
                            break;

                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            UngradedFirst();
                            break;

                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad4:
                            return;

                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid selection, try again");
                            Pause();
                            break;
                    }
                }
            }

            void ChangeGrades()
            {
                Console.Clear();
                Console.WriteLine("Select course: ");
                IEnumerable<Course> courses = Program.register.CourseList;
                foreach (var course in courses)
                {
                    Console.WriteLine("[{0}] : {1}",
                        courses.ToList().IndexOf(course),
                        course.Name);
                }
                var selectedCourse = courses.ToArray()[
                    CheckIntInput(0, courses.Count() - 1)];

                Console.Clear();
                Console.WriteLine("Select student: ");
                IEnumerable<StudentData> students = selectedCourse.Students;
                foreach (var studentData in students)
                {
                    Console.WriteLine("[{0}] : {1}",
                        students.ToList().IndexOf(studentData),
                        studentData.Student.Name);
                }
                var selectedStudent = students.ToArray()[
                    CheckIntInput(0, students.Count() - 1)];

                selectedStudent.Grade = CheckTextInput("New grade:");
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("[1] Display grades");
                Console.WriteLine("[2] Change grades");
                Console.WriteLine("[3] Go back");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        DisplayGrades();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        ChangeGrades();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad4:
                        return;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid selection, try again");
                        Pause();
                        break;
                }
            }
        }
    }
}
