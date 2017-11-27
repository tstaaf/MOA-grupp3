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
        public List<Student> Students { get; set; } = new List<Student>();

        public Course(string name, DateTime startdate, DateTime enddate, int maxstudents)
        {
            Name = name;
            StartDate = startdate;
            EndDate = enddate;
            MaxStudents = maxstudents;
        }

        public Course()
        {

        }
    }
}
