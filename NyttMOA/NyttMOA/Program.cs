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
            Admin user = new Admin("Erik", "Erik14", "1234");
            inloggning();
            Console.ReadLine();
        }

        public static void MainMenu(User user)
        {
            Console.WriteLine("Innloggad som " + user.Name);
            Console.WriteLine(" 1) Administration");
            Console.WriteLine(" 2) Your Schedule");
            Console.WriteLine(" 3) Your Courses");
            var userValue = Console.ReadKey();

            switch (userValue.Key)
            {
                case ConsoleKey.D1:
                    {
                        Console.Clear();
                        user.showMenu();
                        break;
                    }

                case ConsoleKey.D2:
                    {
                        Console.Clear();
                        Console.WriteLine("2222222"); //Sida för schema
                        loggOutorgoBack();
                        break;
                    }

                case ConsoleKey.D3:
                    {
                        Console.Clear();
                        Console.WriteLine("333333333"); //Sida för kurser
                        loggOutorgoBack();
                        break;
                    }
                default:
                    Console.WriteLine("Sorry didn't understand that...");
                    Console.Clear();
                    MainMenu(user);
                    break;
            }
        }

        public static void inloggning()
        {
            User user;

            Console.Write("Användarnamn: ");
            user = Register.SearchForUsername(Console.ReadLine());

            Console.Write("Lösenord: ");

            if (Register.CheckPassword(user, Console.ReadLine()))
            {
                Console.Clear();
                MainMenu(user);
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
                        
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Sorry did not understand that");
                        loggOutorgoBack();
                        break;
                    }
            }
        }
    }
}
