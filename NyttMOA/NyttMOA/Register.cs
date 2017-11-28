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

        static List<Classroom> classroomList = new List<Classroom>();
        public static IEnumerable<Classroom> ClassroomList => classroomList;

        public static bool AddClassroom(Classroom classroom)
        {
            if (!classroomList.Any(a => a.Name == classroom.Name))
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
            if (!courseList.Any(a => a.Name == course.Name))
            {
                courseList.Add(course);
                return true;
            }
            return false;
        }

        public static void SaveUserListToXml()
        {
            var file = Directory.GetCurrentDirectory();
            XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
            TextWriter filestream = new StreamWriter(file + @"\XML Data\userlist.xml");
            serializer.Serialize(filestream, UserList);
            filestream.Close();
        }

        public static void LoadUserListFromXml()
        {
            var file = Directory.GetCurrentDirectory();
            if (!File.Exists(file + @"\XML Data\userlist.xml"))
                return;
            XmlSerializer deSerializer = new XmlSerializer(typeof(List<User>));
            using (var stream = new StreamReader(file + @"\XML Data\userlist.xml"))
<<<<<<< HEAD
                userList = (List<User>)deSerializer.Deserialize(stream);
        }
        
        public static void SaveScheduleToXml()
        {
            var file = Directory.GetCurrentDirectory();
            XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
            TextWriter filestream = new StreamWriter(savePath + @"\schedules.xml");
            serializer.Serialize(filestream, schedules);
            filestream.Close();
        }

        public static void LoadScheduleFromXml()
        {
            ScheduleManager schedulesTemp;
            var file = Directory.GetCurrentDirectory();
            if (!File.Exists(file + @"\XML Data\schedules.xml"))
                return;
            XmlSerializer deSerializer = new XmlSerializer(typeof(List<User>));
            using (var stream = new StreamReader(file + @"\XML Data\schedules.xml"))
                schedulesTemp = (ScheduleManager)deSerializer.Deserialize(stream);

            foreach (Lesson i in schedulesTemp.Lessons)
            {

            }
        }
=======
            UserList = (List<User>)deSerializer.Deserialize(stream);

        }
        public static void SaveClassroomListToXml()
        {
            var file = Directory.GetCurrentDirectory();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Classroom>));
            TextWriter filestream = new StreamWriter(file + @"\XML Data\classroomlist.xml");
            serializer.Serialize(filestream, ClassroomList);
            filestream.Close();
        }

        public static void LoadClassroomListFromXml()
        {
            var file = Directory.GetCurrentDirectory();
            XmlSerializer deSerializer = new XmlSerializer(typeof(List<Classroom>));
            using (var stream = new StreamReader(file + @"\XML Data\classroomlist.xml"))
            ClassroomList = (List<Classroom>)deSerializer.Deserialize(stream);

        }

>>>>>>> 0ec4428e9ab8af9a4af356c49dee4ca5d882b8c0

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
