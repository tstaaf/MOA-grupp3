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
        static Register()
        {
            AddUser(new Admin("Admin", "admin", "admin"));
        }

        public static List<User> UserList = new List<User>();

        public static void AddUser(User user)
        {
            UserList.Add(user);
        }

        public static List<Classroom> ClassroomList = new List<Classroom>();

        public static void AddClassroom(Classroom classroom)
        {
            ClassroomList.Add(classroom);
        }

        public static List<Course> CourseList = new List<Course>();

        public static void AddCourse(Course course)
        {
            CourseList.Add(course);
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
            XmlSerializer deSerializer = new XmlSerializer(typeof(List<User>));
            using (var stream = new StreamReader(file + @"\XML Data\userlist.xml"))
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
