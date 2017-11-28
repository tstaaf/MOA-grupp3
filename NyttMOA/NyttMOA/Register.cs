using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NyttMOA
{
    public static class Register
    {
        public static string savePath = Directory.GetCurrentDirectory() + @"\XML Data";

        static Register()
        {
            AddUser(new Admin("Admin", "admin", "admin"));
        }

        static List<User> userList = new List<User>();
        public static IEnumerable<User> UserList => userList;

        public static bool AddUser(User user)
        {
            if (!userList.Any(a => a.Name == user.Name || a.UserName == user.UserName))
            {
                userList.Add(user);
                return true;
            }
            return false;
        }

        public static void RemoveUser(User user)
        {
            userList.Remove(user);
        }

        static List<Classroom> classroomList = new List<Classroom>();
        public static IEnumerable<Classroom> ClassroomList => classroomList;

        public static bool AddClassroom(Classroom classroom)
        {
            if (classroomList.All(a => a.Name != classroom.Name))
            {
                classroomList.Add(classroom);
                return true;
            }
            return false;
        }

        static List<Course> courseList = new List<Course>();
        public static IEnumerable<Course> CourseList => courseList;

        public static ScheduleManager schedules = new ScheduleManager();

        public static bool AddCourse(Course course)
        {
            if (courseList.All(a => a.Name != course.Name))
            {
                courseList.Add(course);
                return true;
            }
            return false;
        }

        public static void SaveUserListToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
            TextWriter filestream = new StreamWriter(savePath + @"\userlist.xml");
            serializer.Serialize(filestream, UserList);
            filestream.Close();
        }

        public static void LoadUserListFromXml()
        {

            if (!File.Exists(savePath + @"\userlist.xml"))
                return;
            XmlSerializer deSerializer = new XmlSerializer(typeof(List<User>));
            using (var stream = new StreamReader(savePath + @"\userlist.xml"))
                userList = (List<User>)deSerializer.Deserialize(stream);
        }

        public static void SaveCourseToXml()
        {
            var file = Directory.GetCurrentDirectory();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Course>));
            TextWriter filestream = new StreamWriter(savePath + @"\course.xml");
            serializer.Serialize(filestream, courseList);
            filestream.Close();
        }

        public static void LoadcourseFromXml()
        {
            var file = Directory.GetCurrentDirectory();
            if (!File.Exists(file + @"\XML Data\course.xml"))
                return;
            XmlSerializer deSerializer = new XmlSerializer(typeof(List<Course>));
            using (var stream = new StreamReader(file + @"\XML Data\course.xml"))
                courseList = (List<Course>)deSerializer.Deserialize(stream);
        }

        public static void SaveScheduleToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
            TextWriter filestream = new StreamWriter(savePath + @"\schedules.xml");
            serializer.Serialize(filestream, schedules);
            filestream.Close();
        }

        public static void LoadScheduleFromXml()
        {
            ScheduleManager schedulesTemp;
            if (!File.Exists(savePath + @"\schedules.xml"))
                return;
            XmlSerializer deSerializer = new XmlSerializer(typeof(List<User>));
            using (var stream = new StreamReader(savePath + @"\schedules.xml"))
                schedulesTemp = (ScheduleManager)deSerializer.Deserialize(stream);

            foreach (Lesson a in schedulesTemp.Lessons)
            {
                foreach (Lesson b in schedules.Lessons)
                {
                    if (a.Course.Name == b.Course.Name &&
                        a.Classroom.Name == b.Classroom.Name)
                    {

                    }
                }
            }
        }

        public static void SaveClassroomListToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Classroom>));
            TextWriter filestream = new StreamWriter(savePath + @"\classroomlist.xml");
            serializer.Serialize(filestream, ClassroomList);
            filestream.Close();
        }

        public static void LoadClassroomListFromXml()
        {
            if (!File.Exists(savePath + @"\classroomlist.xml"))
                return;
            XmlSerializer deSerializer = new XmlSerializer(typeof(List<Classroom>));
            using (var stream = new StreamReader(savePath + @"\classroomlist.xml"))
            classroomList = (List<Classroom>)deSerializer.Deserialize(stream);

        }

        public static User SearchForUsername(string username)
        {
            return UserList.FirstOrDefault(i => i.UserName == username);
        }

        public static bool CheckPassword(User user, string password)
        {
            if (user != null)
            {
                return password == user.Password;
            }
            return false;
        }
    }
}
