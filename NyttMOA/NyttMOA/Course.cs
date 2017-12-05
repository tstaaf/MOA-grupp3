using System;
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
        public int Hours { get; set; }
        public int MaxStudents { get; set; }
        public Teacher Teacher { get; set; }


        List<StudentData> students = new List<StudentData>();
        public IEnumerable<StudentData> Students => students;

        public Course(string name, DateTime startdate, DateTime enddate, int hours, int maxstudents, Teacher teacher)
        {
            Name = name;
            StartDate = startdate;
            EndDate = enddate;
            Hours = hours;
            MaxStudents = maxstudents;
            Teacher = teacher;
        }

        public Course()
        {
            
        }

        public void AddStudent(Student student)
        {
            students.Add(new StudentData(student));
        }

        public void RemoveStudent(StudentData student)
        {
            students.Remove(student);
        }

        public void ReplaceStudents(IEnumerable<StudentData> newStudents)
        {
            students = new List<StudentData>(newStudents);
        }

        public string GetGrade(Student student)
        {
            foreach (StudentData studentData in students)
            {
                if (studentData.Student == student)
                {
                    return studentData.Grade;
                }
            }
            return "Student not registered in this course";
        }

        public override string ToString()
        {
            return
                "Name: " + Name +
                " Start date: " + StartDate.ToShortDateString() +
                " End date: " + EndDate.ToShortDateString() +
                " Max students: " + MaxStudents.ToString() +
                " Teacher: " + Teacher.Name;
        }
    }
}
