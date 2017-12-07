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

        static List<string> notifications;

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

        public static IEnumerable<string> GetNotifications()
        {
            if (user is Admin)
            {
                if (AdminNotifications != null)
                {
                    notifications = new List<string>();
                    AdminNotifications();
                }
            }
            else if (user is Student)
            {
                if (StudentNotifications != null)
                {
                    notifications = new List<string>();
                    StudentNotifications();
                }
            }
            else if (user is Teacher)
            {
                if (TeacherNotifications != null)
                {
                    notifications = new List<string>();
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
