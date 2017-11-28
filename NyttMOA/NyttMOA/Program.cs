using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NyttMOA
{
    class Program
    {
        public static User user { get; set; }

        static void Main()
        {
            Directory.CreateDirectory(Register.savePath);
            Register.LoadUserListFromXml();
            Register.LoadClassroomListFromXml();
            Register.LoadcourseFromXml();
            inloggning();
        }

        public static void inloggning()
        {
            while (true)
            {
<<<<<<< HEAD

                Console.Write("Username: ");
=======
                Console.Write("Användarnamn: ");
>>>>>>> 5ef4be088655c4319de85ec8a50bf0d332d32681
                user = Register.SearchForUsername(Console.ReadLine());

                Console.Write("Password: ");

                if (Register.CheckPassword(user, Console.ReadLine()))
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
