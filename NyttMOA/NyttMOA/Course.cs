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




        public List<StudentData> Students { get; set; } = new List<StudentData>();

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

        public bool AddStudent(Student student)
        {
            if (!Students.Any(a => a.Student == student))
            {
                Students.Add(new StudentData(student));
                Program.register.SaveCourseListToXml();
                return true;
            }
            return false;
        }
        
        public void RemoveStudent(StudentData student)
        {
            Students.Remove(student);
            Program.register.SaveCourseListToXml();
        }

        public void ReplaceStudents(IEnumerable<StudentData> newStudents)
        {
            Students = new List<StudentData>(newStudents);
        }

        public string GetGrade(Student student)
        {
            foreach (StudentData studentData in Students)
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

        void OnAdminNotifications()
        {

        }
    }
}
