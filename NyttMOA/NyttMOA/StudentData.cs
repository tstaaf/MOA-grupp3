using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyttMOA
{
    public class StudentData
    {
        public Student Student { get; set; }
        public string Grade { get; set; } = "-";

        public StudentData(Student student)
        {
            Student = student;
        }

        public StudentData()
        {

        }
    }
}
