using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyttMOA
{
    class Program
    {
        public static User user { get; set; }

        static void Main()
        {
            Register.LoadUserListFromXml();
            Register.LoadClassroomListFromXml();
            inloggning();
        }

        public static void inloggning()
        {
            while (true)
            {
                Console.Write("Användarnamn: ");
                user = Register.SearchForUsername(Console.ReadLine());

                Console.Write("Lösenord: ");

                if (Register.CheckPassword(user, Console.ReadLine()))
                {
                    Console.Clear();
                    user.showMenu();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Fel användarnamn eller lösenord.");
                    continue;
                }
                break;
            }
        }
    }
}
