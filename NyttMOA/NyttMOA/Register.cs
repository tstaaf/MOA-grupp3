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
        const string filePath = @"C:\Users\Anton\Desktop\userlist.xml";

        static Register()
        {
            AddUser(new Admin("Admin", "admin", "admin"));
        }

        static List<User> userList = new List<User>();
        public static IEnumerable<User> UserList => userList;

        static List<Classroom> classroomList = new List<Classroom>();
        public static IEnumerable<Classroom> ClassroomList => classroomList;

        static List<Course> courseList = new List<Course>();
        public static IEnumerable<Course> CourseList => courseList;


        public static bool AddUser(User user)
        {
            if (!userList.Any(a => a.UserName == user.UserName))
            {
                userList.Add(user);
                return true;
            }
            return false;
        }

        public static bool AddClassroom(Classroom classroom)
        {
            if (!classroomList.Any(a => a.Name == classroom.Name))
            {
                classroomList.Add(classroom);
                return true;
            }
            return false;
        }

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
            XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
            TextWriter filestream = new StreamWriter(filePath);
            serializer.Serialize(filestream, UserList);
            filestream.Close();
        }

        public static void LoadUserListFromXml()
        {
            if (!File.Exists(filePath))
                return;
            XmlSerializer deSerializer = new XmlSerializer(typeof(List<User>));
            using (var stream = System.IO.File.OpenRead(filePath))
                userList = (List<User>) deSerializer.Deserialize(stream);
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
