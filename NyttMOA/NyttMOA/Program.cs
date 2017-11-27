using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyttMOA
{
    class Program
    {
        static void Main()
        {
            Register.LoadFromXml();
            inloggning();
            Console.ReadLine();
        }

        public static User user;

        

        public static void inloggning()
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
                inloggning();
            }
        }

        public static void loggOutorgoBack()
        {
            Console.WriteLine("Press 'Q' to switch user \nPress 'K' to go back");
            var input = Console.ReadKey();

            switch (input.Key) //Switch on Key enum
            {
                case ConsoleKey.Q:
                    {
                        Console.Clear();
                        inloggning();
                        break;
                    }
                case ConsoleKey.K:
                    {
                        Console.Clear();
                        user.showMenu();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Sorry did not understand that");
                        
                        break;
                    }
            }
        }
    }
}
