using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyttMOA
{
    public class Classroom
    {
        public string Name { get; set; }
        public int Seats { get; set; }

        public Classroom(string name, int seats)
        {
            Name = name;
            Seats = seats;
        }

        public Classroom()
        {

        }
    }
}
