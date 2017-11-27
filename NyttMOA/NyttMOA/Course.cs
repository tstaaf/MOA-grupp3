﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyttMOA
{
    public class Course
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaxStudents { get; set; }

        public Course(string name, DateTime startdate, DateTime enddate, int maxstudents)
        {
            Name = name;
            StartDate = startdate;
            EndDate = enddate;
            MaxStudents = maxstudents;
        }

        public class StudentList
        {
            List<Student> students;
            public IEnumerable<Student> Students => students;

            public StudentList(IEnumerable<Student> _students)
            {
                students = new List<Student>(_students);
            }

            public void AddStudent(Student student)
            {
                students.Add(student);
            }

            public void RemoveStudent(Student student)
            {
                students.Remove(student);
            }
        }


    }
}
