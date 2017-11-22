﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NyttMOA
{
    public abstract class User
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public User(string name, string username, string password)
        {
            Name = name;
            UserName = username;
            Password = password;
        }
        public User() { }
    }

    public class Admin : User
    {
        public Admin(string name, string username, string password) : base(name, username, password)
        {
            
        }
        public Admin() { }
    }

    public class Student : User
    {
        public string Grade { get; set; }

        public Student(string name, string username, string password, string grade) : base(name, username, password)
        {
            Grade = grade;
        }
    }

    public class Teacher : User
    {
        public Teacher(string name, string username, string password) : base(name, username, password)
        {

        }
    }
}
