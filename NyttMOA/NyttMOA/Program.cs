﻿using System;
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
            Register.LoadUserListFromXml();
            inloggning();

        }

        public static User user { get; set; }


        public static void inloggning()
        {
            while (true)
            {

                Console.Write("Username: ");
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
