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

        public static void SaveToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
            TextWriter filestream = new StreamWriter(@"C:\Users\timmy\Desktop\gitHub\MOA-grupp3\NyttMOA\NyttMOA\XML Data\datalist.xml");
            serializer.Serialize(filestream, UserList);
            filestream.Close();
        }

        public static void LoadFromXml()
        {
            XmlSerializer deSerializer = new XmlSerializer(typeof(List<User>));
            using (var stream = System.IO.File.OpenRead(@"C:\Users\timmy\Desktop\gitHub\MOA-grupp3\NyttMOA\NyttMOA\XML Data\datalist.xml"))
                UserList = (List<User>) deSerializer.Deserialize(stream);
        }
        

        public static User SearchForUsername(string username)
        {
            foreach (User i in UserList)
            {
                if (i.UserName == username)
                {
                    return i;
                }
            }
            return null;
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
