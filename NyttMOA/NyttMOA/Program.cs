using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NyttMOA
{
    public class Program
    {
        public static Register register { get; set; } = new Register();
        public static User user { get; set; }

        static void Main()
        {
            Directory.CreateDirectory(register.savePath);
            register.LoadUserListFromXml();
            register.LoadClassroomListFromXml();
            register.LoadCourseListFromXml();
            register.LoadScheduleFromXml();
            LogIn();
        }

        public static void LogIn()
        {
            user = Menus.LogIn();
            user.showMenu();
        }
    }
}
