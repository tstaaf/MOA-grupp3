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
        public string Teacher { get; set; }

        public List<Student> Students { get; set; }
        //La till den för att få schemat o funka, vi får se om de ska va kvar här sen... :D /Anton

        public Course(string name, DateTime startdate, DateTime enddate, int maxstudents, string teacher)
        {
            Name = name;
            StartDate = startdate;
            EndDate = enddate;
            MaxStudents = maxstudents;
            Teacher = teacher;

        }

    }
}
