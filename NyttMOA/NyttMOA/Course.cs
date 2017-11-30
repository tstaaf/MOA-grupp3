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
        public int MaxStudents { get; set; }
        public Teacher Teacher { get; set; }
        List<Student> students = new List<Student>();
        public IEnumerable<Student> Students => students;

        public Course(string name, DateTime startdate, DateTime enddate, int maxstudents, Teacher teacher)
        {
            Name = name;
            StartDate = startdate;
            EndDate = enddate;
            MaxStudents = maxstudents;
            Teacher = teacher;
        }

        public Course()
        {
            
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            students.Remove(student);
        }

        public void ReplaceStudents(IEnumerable<Student> newStudents)
        {
            students = new List<Student>(newStudents);
        }
    }
}
