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
            inloggning();
        }

        public static void inloggning()
        {
            while (true)
            {
                Console.Write("Username: ");

                user = Program.register.SearchForUsername(Console.ReadLine());

                Console.Write("Password: ");

                if (Program.register.CheckPassword(user, Console.ReadLine()))
                {
                    Console.Clear();
                    user.showMenu();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong username or password.");
                    continue;
                }
                break;
            }
        }
    }
}
