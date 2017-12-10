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

        public delegate void AdminNotificationEventHandler();
        public static event AdminNotificationEventHandler AdminNotifications;

        public delegate void StudentNotificationEventHandler();
        public static event StudentNotificationEventHandler StudentNotifications;

        public delegate void TeacherNotificationEventHandler();
        public static event TeacherNotificationEventHandler TeacherNotifications;

        static List<string> notifications = new List<string>();

        static void Main()
        {
            Directory.CreateDirectory(register.savePath);
            register.LoadEverything();
            if (register.UserList.OfType<Admin>().Count() == 0)
            {
                register.AddUser(new Admin("Admin", "admin", "admin"));
            }
            LogIn();
        }

        public static void LogIn()
        {
            user = Menus.LogIn();
            user.showMenu();
        }

        public static IEnumerable<string> GetNotifications()
        {
            if (user is Admin)
            {
                if (AdminNotifications != null)
                {
                    notifications.Clear();
                    AdminNotifications();
                }
            }
            else if (user is Student)
            {
                if (StudentNotifications != null)
                {
                    notifications.Clear();
                    StudentNotifications();
                }
            }
            else if (user is Teacher)
            {
                if (TeacherNotifications != null)
                {
                    notifications.Clear();
                    TeacherNotifications();
                }
            }
            return notifications;
        }

        public static void AddNotification(string msg)
        {
            notifications.Add(msg);
        }
    }
}
