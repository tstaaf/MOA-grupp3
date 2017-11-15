using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyttMOA
{
    class Classroom
    {
        public string Name { get; set; }
        public int Seats { get; set; }
        public string Course { get; set; }

        public Classroom(string name, int seats, string course)
        {
            Name = name;
            Seats = seats;
            Course = course;
        }
        
    }
}
