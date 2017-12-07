using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NyttMOA
{
    public class Register
    {
        public string savePath;

        public Register()
        {
            userList.Add(new Admin("Admin", "admin", "admin"));
            savePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Directory.CreateDirectory(savePath + @"\MOAGrupp3\XML Data");
            savePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MOAGrupp3\XML Data";
        }

        List<User> userList = new List<User>();
        List<Course> courseList = new List<Course>();
        List<Classroom> classroomList = new List<Classroom>();

        public IEnumerable<User> UserList => userList;
        public IEnumerable<Course> CourseList => courseList;
        public IEnumerable<Classroom> ClassroomList => classroomList;

        public bool AddUser(User user)
        {
            if (!userList.Any(a => a.Name == user.Name || a.UserName == user.UserName))
            {
                userList.Add(user);
                SaveUserListToXml();
                return true;
            }
            return false;
        }

        public bool AddCourse(Course course)
        {
            if (courseList.All(a => a.Name != course.Name))
            {
                courseList.Add(course);
                SaveCourseListToXml();
                return true;
            }
            return false;
        }

        public bool AddClassroom(Classroom classroom)
        {
            if (classroomList.All(a => a.Name != classroom.Name))
            {
                classroomList.Add(classroom);
                SaveClassroomListToXml();
                return true;
            }
            return false;
        }

        public bool AddLesson(Lesson lesson)
        {
            if (schedule.AddLesson(lesson))
            {
                SaveScheduleToXml();
                return true;
            }
            return false;
        }

        public void RemoveUser(User user)
        {
            userList.Remove(user);
            SaveUserListToXml();
            if (user is Teacher)
            {
                foreach (Course course in courseList.Where(a => a.Teacher == user))
                {
                    RemoveCourse(course);
                }
                var sample = courseList.Where(a => a.Teacher == user).ToList();
                for (int course = sample.Count() - 1; course >= 0; course--)
                {
                    RemoveCourse(sample[course]);
                }
            }
        }

        public void RemoveClassroom(Classroom classroom)
        {
            classroomList.Remove(classroom);
            SaveClassroomListToXml();
        }

        public void RemoveCourse(Course course)
        {
            courseList.Remove(course);
            SaveCourseListToXml();
        }

        public void RemoveLesson(Lesson lesson)
        {
            schedule.RemoveLesson(lesson);
            SaveScheduleToXml();
        }


        public ScheduleManager schedule = new ScheduleManager();

        public void SaveUserListToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
            TextWriter filestream = new StreamWriter(savePath + @"\userlist.xml");
            serializer.Serialize(filestream, UserList);
            filestream.Close();
        }

        public void LoadUserListFromXml()
        {
            if (!File.Exists(savePath + @"\userlist.xml"))
                return;
            XmlSerializer deSerializer = new XmlSerializer(typeof(List<User>));
            using (var stream = new StreamReader(savePath + @"\userlist.xml"))
                userList = (List<User>)deSerializer.Deserialize(stream);
        }

        public void SaveCourseListToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Course>));
            TextWriter filestream = new StreamWriter(savePath + @"\courseList.xml");
            serializer.Serialize(filestream, courseList);
            filestream.Close();
        }

        public void LoadCourseListFromXml()
        {
            if (!File.Exists(savePath + @"\courseList.xml"))
                return;
            XmlSerializer deSerializer = new XmlSerializer(typeof(List<Course>));
            using (var stream = new StreamReader(savePath + @"\courseList.xml"))
                courseList = (List<Course>)deSerializer.Deserialize(stream);

            foreach (Course currentCourse in courseList)
            {
                foreach (Teacher currentTeacher in UserList.OfType<Teacher>())
                {
                    if (currentTeacher.UserName == currentCourse.Teacher.Name)
                    {
                        currentCourse.Teacher = currentTeacher;
                        break;
                    }
                }

                foreach (StudentData currentStudentData in currentCourse.Students)
                {
                    foreach (Student loadedStudent in UserList.OfType<Student>())
                    {
                        if (currentStudentData.Student.UserName == loadedStudent.UserName)
                        {
                            currentStudentData.Student = loadedStudent;
                            break;
                        }
                    }
                }
            }
        }

        public void SaveClassroomListToXml()
        {
            Directory.CreateDirectory(savePath);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Classroom>));
            TextWriter filestream = new StreamWriter(savePath + @"\classroomlist.xml");
            serializer.Serialize(filestream, ClassroomList);
            filestream.Close();
        }

        public void LoadClassroomListFromXml()
        {
            if (!File.Exists(savePath + @"\classroomlist.xml"))
                return;
            XmlSerializer deSerializer = new XmlSerializer(typeof(List<Classroom>));
            using (var stream = new StreamReader(savePath + @"\classroomlist.xml"))
                classroomList = (List<Classroom>)deSerializer.Deserialize(stream);
        }

        public void SaveScheduleToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Lesson>));
            TextWriter filestream = new StreamWriter(savePath + @"\schedules.xml");
            serializer.Serialize(filestream, schedule.mainSchedule.Lessons);
            filestream.Close();
        }

        public void LoadScheduleFromXml()
        {
            if (!File.Exists(savePath + @"\schedules.xml"))
                return;
            XmlSerializer deSerializer = new XmlSerializer(typeof(List<Lesson>));
            using (var stream = new StreamReader(savePath + @"\schedules.xml"))
                schedule.AddLesson((List<Lesson>)deSerializer.Deserialize(stream));

            foreach (Lesson currentLesson in schedule.Lessons)
            {
                foreach (Classroom currentClassroom in classroomList)
                {
                    if (currentLesson.Classroom.Name == currentClassroom.Name)
                    {
                        currentLesson.Classroom = currentClassroom;
                    }
                }
                foreach (Course currentCourse in courseList)
                {
                    if (currentLesson.Course.Name == currentCourse.Name)
                    {
                        currentLesson.Course = currentCourse;
                    }
                }
            }
        }

        public User SearchForUsername(string username)
        {
            return UserList.FirstOrDefault(i => i.UserName == username);
        }

        public bool CheckPassword(User user, string password)
        {
            if (user != null)
            {
                return password == user.Password;
            }
            return false;
        }

        public List<string> notificationQueue = new List<string>();

        void OnNotification(object sender, EventArgs e)
        {

        }
    }
}
